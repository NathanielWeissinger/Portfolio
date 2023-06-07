/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Primary file for initializing the MasterServer UI. Run Main method to begin.
 * The Master Server hosts multiple clients for multiplayer using the DedicatedLobby in Unreal Engine 5.1.
 * 
 * Instructions for DedicatedLobby server and functionality can be found at:
 * https://docs.google.com/document/d/1MZibsTj-2MzWTI7H9Z0AB6zKMV5wqHFxL2OzK-3GvN8/edit?usp=sharing
 * 
 * Instructions for Dependency Injection functionality can be found at:
 * https://stackify.com/net-core-dependency-injection/
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
		private static readonly string _OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

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
					outputTemplate: _OutputTemplate )
				.WriteTo.File(
					"log-.txt",
					rollingInterval: RollingInterval.Day,
					retainedFileCountLimit: 30,
					restrictedToMinimumLevel: LogEventLevel.Verbose,
					outputTemplate: _OutputTemplate );

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
		private readonly Container _DIContainer;

		public ViewModelFactory( Container InDIContainer ) => _DIContainer = InDIContainer;

		// Dependency Injection requires pre-instantiation of objects using interfaces
		public IViewModel GetInstance( string InName ) => (IViewModel)_DIContainer.GetInstance( this[InName] );
	}
}
