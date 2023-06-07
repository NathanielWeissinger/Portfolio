/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * This is the Menu Bar that appears at the top of the Master Server Main Menu, the first window
 *	that appears upon initialization.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * MENU BAR:	File				View					Help
 *				>Restart			>Configuration			>About
 *				>Exit				>Logs
 *									>Registered Players
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using Serilog;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.ViewModels
{
	public class MenuViewModel : ObservableObject
	{
		// Dependencies
		private readonly ILogger _Logger;
		private readonly IViewModelFactory _ViewModelFactory;
		private readonly IDialogService _DialogService;

		// Commands
		public IAsyncRelayCommand RestartServerCommand { get; }
		public IRelayCommand ExitCommand { get; }
		public IAsyncRelayCommand LoadConfigurationCommand { get; }
		public IAsyncRelayCommand ConfigurationCommand { get; }
		public IAsyncRelayCommand LogCommand { get; }
		public IAsyncRelayCommand RegisteredPlayerCommand { get; }
		public IAsyncRelayCommand AboutCommand { get; }

		// Constructor: initializes primary communication, button commands, and UI data
		public MenuViewModel(
			ILogger InLogger,
			IViewModelFactory InViewModelFactory,
			IDialogService InDialogService )
		{
			_Logger = InLogger;
			RestartServerCommand = new AsyncRelayCommand( RestartServer );
			ExitCommand = new RelayCommand( Exit );
			LoadConfigurationCommand = new AsyncRelayCommand( LoadConfiguration );
			ConfigurationCommand = new AsyncRelayCommand( ShowConfigurationModal );
			LogCommand = new AsyncRelayCommand( ShowLogs );
			RegisteredPlayerCommand = new AsyncRelayCommand( ShowRegisteredPlayersModal );
			AboutCommand = new AsyncRelayCommand( ShowAbout );

			_ViewModelFactory = InViewModelFactory;
			_DialogService = InDialogService;
		}

		// Task: Restarts Server
		private async Task RestartServer()
		{
			await Task.CompletedTask;
		}

		// Closes window and program
		private void Exit()
		{
			// Stop the server then Exit the application.
			Environment.Exit( 0 );
		}

		// Task: Loads Configuration from file
		private async Task LoadConfiguration()
		{
			var FileSettings = new OpenFileDialogSettings
			{
				Title = "Load Configuration",
				InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ),
				Filter = "Text Documents (*.csv)|*.csv|All Files (*.*)|*.*"
			};

			bool? bSuccess = _DialogService.ShowOpenFileDialog( this, FileSettings );

			if (bSuccess == true)
			{
				// Call load configuration method
			}

			await Task.CompletedTask;
		}

		// Task: When Configuration option is pressed, displays new Configuration window
		private async Task ShowConfigurationModal()
		{
			var ViewModelInstance = _ViewModelFactory.GetInstance( nameof( ConfigurationViewModel ) );
			_DialogService.Show( this, ViewModelInstance );
			await Task.CompletedTask;
		}

		// Task: When Logs option is pressed, displays new Log window
		private async Task ShowLogs()
		{
			var ViewModelInstance = _ViewModelFactory.GetInstance( nameof( LogViewModel ) );
			_DialogService.Show( this, ViewModelInstance );
			await Task.CompletedTask;
		}

		// Task: When Registered Players option is pressed, displays new RegisteredPlayers window
		private async Task ShowRegisteredPlayersModal()
		{
			var ViewModelInstance = _ViewModelFactory.GetInstance( nameof( RegisteredPlayersViewModel ) );
			_DialogService.Show( this, ViewModelInstance );
			await Task.CompletedTask;
		}

		// Task: When About option is pressed, displays new MessageBox window
		private async Task ShowAbout()
		{
			var AssemblyInstance = Assembly.GetExecutingAssembly();
			_DialogService.ShowMessageBox(
				this,
				$"Version: {AssemblyInstance.GetCustomAttribute<AssemblyVersionAttribute>()}\n{AssemblyInstance.GetCustomAttribute<AssemblyCopyrightAttribute>()}",
				$"{AssemblyInstance.GetCustomAttribute<AssemblyTitleAttribute>()}",
				MessageBoxButton.OK,
				MessageBoxImage.Information );

			await Task.CompletedTask;
		}
	}
}
