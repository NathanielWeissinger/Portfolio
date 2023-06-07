/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Primary file for initializing the MasterServer UI. Run Main method to begin.
 * The Master Server hosts multiple clients for multiplayer using the DedicatedLobby in Unreal Engine 5.1.
 * Connect to the server by opening Map_MainMenu in RC135.
 */

using MasterServer.Core;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels;
using MasterServer.UI.ViewModels.Contracts;
using MvvmDialogs;
using Serilog;
using Serilog.Events;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace MasterServer.UI
{
	public class Program
	{
		// Create log file with the following format
		private static readonly string _outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

		// Main method: creates Container object for dependency injection, and passes it into the RunApplication method
		[STAThread]
		static void Main()
		{
			var DIContainer = Bootstrap();
			RunApplication( DIContainer );
		}

		// Dependency Injection initialization: registers objects into container for future reference
		private static Container Bootstrap()
		{
			// Configure Serilog to write debug notes to console and file
			var loggerConfiguration = new LoggerConfiguration()
				.WriteTo.Console(
					restrictedToMinimumLevel: LogEventLevel.Debug,
					outputTemplate: _outputTemplate )
				.WriteTo.File(
					"log-.txt",
					rollingInterval: RollingInterval.Day,
					retainedFileCountLimit: 30,
					restrictedToMinimumLevel: LogEventLevel.Verbose,
					outputTemplate: _outputTemplate );

			// Create the container
			var DIContainer = new Container();

			// Register Logging to the container, which handles logger Type requests for verification of container configuration
			DIContainer.Options.DependencyInjectionBehavior = new SerilogContextualLoggerInjectionBehavior( DIContainer.Options, loggerConfiguration );

			// Register Server
			DIContainer.Register<SynchronousSocketListener>();
			DIContainer.RegisterSingleton<ServerData>();

			// Register Views
			DIContainer.Register<MainWindow>();

			// Register ViewModels
			DIContainer.Register<MainWindowViewModel>();
			DIContainer.Register<LobbyViewModel>();
			DIContainer.Register<ServerViewModel>();
			DIContainer.Register<ActivePlayerViewModel>();
			DIContainer.Register<ServerStatusBarViewModel>();
			DIContainer.Register<RegisteredPlayersViewModel>();
			DIContainer.Register<ConfigurationViewModel>();
			DIContainer.Register<MenuViewModel>();
			DIContainer.Register<LogViewModel>();
			DIContainer.Register<StatusModalViewModel>();
			DIContainer.Register<EditRegisteredPlayerViewModel>();
			DIContainer.Register<PlayerLogsViewModel>();

			DIContainer.RegisterInstance<IViewModelFactory>( new ViewModelFactory( DIContainer )
			{
				{nameof(RegisteredPlayersViewModel), typeof(RegisteredPlayersViewModel) },
				{nameof(ConfigurationViewModel), typeof(ConfigurationViewModel) },
				{nameof(LogViewModel), typeof(LogViewModel) },
				{nameof(EditRegisteredPlayerViewModel), typeof(EditRegisteredPlayerViewModel) },
				{nameof(PlayerLogsViewModel), typeof(PlayerLogsViewModel) },
				{nameof(ActivePlayerViewModel), typeof(ActivePlayerViewModel) },
				{nameof(ServerViewModel), typeof(ServerViewModel) },
				{nameof(LobbyViewModel), typeof(LobbyViewModel) }
			} );

			// Register Services
			DIContainer.RegisterInstance<IDialogService>( new DialogService() );

			DIContainer.Verify();

			return DIContainer;
		}

		// Initialization of MasterServer UI application and its window
		private static void RunApplication( Container InDIContainer )
		{
			try
			{
				var AppInstance = new App();
				var MainWindowInstance = InDIContainer.GetInstance<MainWindow>();
				Log.Information( "Starting application..." );
				AppInstance.Run( MainWindowInstance );
			}
			catch (Exception ex)
			{
				Log.Error( ex, ex.Message );
			}
		}
	}

	// Create IViewModelFactory interface
	public interface IViewModelFactory
	{
		IViewModel GetInstance( string InName );
	}

	// Create ViewModelFactory class, used for hosting multiple ViewModels and their corresponding data
	public class ViewModelFactory : Dictionary<string, Type>, IViewModelFactory
	{
		private readonly Container _diContainer;

		public ViewModelFactory( Container InDIContainer ) => _diContainer = InDIContainer;

		// Dependency Injection requires pre-instantiation of objects using interfaces
		public IViewModel GetInstance( string InName ) => (IViewModel)_diContainer.GetInstance( this[InName] );
	}
}
