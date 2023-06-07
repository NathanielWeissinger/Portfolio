/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * This is the first window that appears upon program initialization. This starts the server,
 *	outputs the server log, and displays the active servers, lobbies, connections, and players.
 * See MainWindow.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	"MASTER SERVER"
 * MENU BAR:	File (Restart, Exit), View (Configuration, Logs, Registered Players), Help (About)
 * GRID:		Server Log Pane		Connections				Servers
 *									Lobbies					Active Players
 *									Servers Pane			Lobbies Pane
 *									Active Players Pane
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core;
using MasterServer.Core.Messages;
using MasterServer.Core.Models;
using MasterServer.Events;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static MasterServer.Core.Models.ServerData;

namespace MasterServer.UI.ViewModels
{
	public class MainWindowViewModel : ObservableObject
	{
		// Dependencies
		private readonly ILogger _logger;
		// Callback
		private event LogMessageEventHandler _logMessageHandler;
		// Network
		private readonly SynchronousSocketListener _socketListener;

		// Constructor: initializes primary communication and UI data
		public MainWindowViewModel(
			ILogger InLogger,
			ServerStatusBarViewModel InServerStatusBarViewModel,
			StatusModalViewModel InStatusModalViewModel,
			MenuViewModel InMenuViewModel,
			SynchronousSocketListener InSocketListener )
		{
			_logger = InLogger;
			_socketListener = InSocketListener;
			_logMessageHandler += UpdateServerLog;

			OnLoad = new AsyncRelayCommand( OnLoading );
			OnClose = new AsyncRelayCommand( OnClosing );

			ServerLogs = new ObservableCollection<ServerLog>();
			MessageQueue = new ConcurrentQueue<MessageBase>();

			ServerStatusBarViewModel = InServerStatusBarViewModel;
			StatusModalViewModel = InStatusModalViewModel;
			MenuViewModel = InMenuViewModel;
		}

		// Destructor: destroys instances created within constructor, updates message log
		~MainWindowViewModel()
		{
			_logMessageHandler -= UpdateServerLog;
		}

		// Property: Get/Set Server Status Bar VM
		public ServerStatusBarViewModel ServerStatusBarViewModel { get; private set; }
		// Property: Get/Set Status Modal VM
		public StatusModalViewModel StatusModalViewModel { get; private set; }
		// Property: Get/Set Menu Bar VM
		public MenuViewModel MenuViewModel { get; private set; }
		// Property: Get/Set Server Logs collection
		public ObservableCollection<ServerLog> ServerLogs { get; private set; }
		// Property: Get/Set Message Queue
		public ConcurrentQueue<MessageBase> MessageQueue { get; private set; }

		// Command: Get/Set Asynchronous Relay Load Command
		private IAsyncRelayCommand _onLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _onLoad;
			set => SetProperty( ref _onLoad, value, nameof( OnLoad ) );
		}

		// Command: Get/Set Asynchronous Relay Close Command
		private IAsyncRelayCommand _onClose;
		public IAsyncRelayCommand OnClose
		{
			get => _onClose;
			set => SetProperty( ref _onClose, value, nameof( OnClose ) );
		}

		// Task: Sends Logger a message when server starts to run
		public async Task OnLoading()
		{
			await Task.Run( () =>
			{
				_socketListener.StartListening( 7787, _logMessageHandler );
				_logger.Information( "Server started..." );
			} );
		}

		// Task: Sends Logger a message when server closes
		public async Task OnClosing()
		{
			_socketListener.Close();
			_logger.Information( "Server stopped..." );
			await Task.CompletedTask;
		}

		// Sends Logger an input message, and updates Server Log with the message
		private void UpdateServerLog( object InSender, LogMessageArgs InLogMsgArgs )
		{
			// Creates Server Log message
			var Msg = new ServerLog
			{
				TimeStamp = DateTime.Now,
				LogMessage = InLogMsgArgs.Message,
				LogID = InLogMsgArgs.ID
			};

			// Sends message to Logger and updates Server Log
			_logger.Information( "{Message}", Msg.LogMessage );
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ServerLogs.Add( Msg );
			} ) );
		}
	}
}
