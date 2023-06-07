/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays server information, such as lobbies, players, dates/times, and the server log.
 *	Within the Master Server Main Menu, while a server is running, click an available server
 *	within the Servers pane to view.
 * See Views->Server.xaml and Modals->ServerModal.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	[Name of server]
 * GRID:		Lobbies:		[Lobby #]			Lobbies Panel		Players Panel
 *				Active Players:	[# of Players]		[Names of Lobbies]	[Names of Players]
 *				Time Up:		[Timestamp]
 *				Created:		[Date, Time]
 *				Logs Panel
 * BUTTONS:		Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.ViewModels
{
	public class ServerViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }

		// Constructor: initializes primary communication and UI data
		public ServerViewModel( ILogger InLogger, ServerData InServerData )
		{
			this._logger = InLogger;
			this._serverData = InServerData;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			PlayersList = new ObservableCollection<string>();
			LobbiesList = new ObservableCollection<string>();

			ServerLogs = new ObservableCollection<ServerLog>();
		}

		// Property: Get/Set List of Lobbies
		private ObservableCollection<string> _lobbiesList;
		public ObservableCollection<string> LobbiesList
		{
			get => _lobbiesList;
			set => SetProperty( ref _lobbiesList, value, nameof( LobbiesList ) );
		}

		// Property: Get/Set List of Players
		private ObservableCollection<string> _playersList;
		public ObservableCollection<string> PlayersList
		{
			get => _playersList;
			set => SetProperty( ref _playersList, value, nameof( PlayersList ) );
		}

		// Property: Get/Set List of Server Logs
		private ObservableCollection<ServerLog> _serverLogs;
		public ObservableCollection<ServerLog> ServerLogs
		{
			get => _serverLogs;
			set => SetProperty( ref _serverLogs, value, nameof( ServerLogs ) );
		}

		// Property: Get/Set Server's Display Name
		private string _serverName;
		public string ServerName
		{
			get => _serverName;
			set => SetProperty( ref _serverName, value, nameof( ServerName ) );
		}

		// Property: Get/Set Display Count of the number of Lobbies running
		private string _lobbyCount = "0";
		public string LobbyCount
		{
			get => _lobbyCount;
			set => SetProperty( ref _lobbyCount, value, nameof( LobbyCount ) );
		}

		// Property: Get/Set Display Count of the number of Active Players
		private string _activePlayerCount = "0";
		public string ActivePlayerCount
		{
			get => _activePlayerCount;
			set => SetProperty( ref _activePlayerCount, value, nameof( ActivePlayerCount ) );
		}

		// Property: Get/Set Uptime (how long server has been up) upon opening window
		private string _timeUp;
		public string TimeUp
		{
			get => _timeUp;
			set => SetProperty( ref _timeUp, value, nameof( TimeUp ) );
		}

		// Property: Get/Set Date/Time the server was created
		private string _createdOn;
		public string CreatedOn
		{
			get => _createdOn;
			set => SetProperty( ref _createdOn, value, nameof( CreatedOn ) );
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Upon window opening, obtains server information, such as lobbies, players, and timestamps
		public void LoadActiveServerInformation( int InServerID )
		{
			// Clears lists in case window is reloaded or reopened
			PlayersList.Clear();
			LobbiesList.Clear();

			// Confirms existence of server ID passthrough
			ServerRec CurrentServerRec = _serverData.GetServer( InServerID );
			if (CurrentServerRec != null)
			{
				// Adds Lobbies and Players to local list
				ServerName = CurrentServerRec.Name;
				var LobbyList = _serverData.GetLobbies();
				//var lobbyList = _serverData.GetLobbies().Where(x => x.ServerClientID == serverId); //used for when we implement multiple lobbies
				foreach (var LobbyInstance in LobbyList)
				{
					foreach (var PlayerInstance in LobbyInstance.PlayerRecs)
					{
						PlayersList.Add( PlayerInstance.ToString() );
					}
					LobbiesList.Add( LobbyInstance.ToString() );
				}

				// Saves data to local variables
				ActivePlayerCount = PlayersList.Count().ToString();
				LobbyCount = LobbiesList.Count().ToString();

				CreatedOn = CurrentServerRec.Created.ToString();
				TimeSpan TimeInSeconds = TimeSpan.FromSeconds( (DateTime.Now - CurrentServerRec.Created).TotalSeconds );
				TimeUp = string.Format( "{0:D2}:{1:D2}:{2:D2}", TimeInSeconds.Hours, TimeInSeconds.Minutes, TimeInSeconds.Seconds );
			}

			FilterServerLogData( InServerID );
		}

		// Adds server logs from the Master Server Main Menu and creates a local list
		private void FilterServerLogData( int InServerID )
		{
			// Confirms Master Server Main Window is still open
			var MainWindowVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
			if (MainWindowVM != null)
			{
				// Obtains server logs
				var ServerLogList = MainWindowVM.ServerLogs;
				foreach (var LogInstance in ServerLogList)
				{
					if (LogInstance.LogID.Contains( "Server" ) && LogInstance.LogID.Contains( InServerID.ToString() ))
					{
						ServerLogs.Add( LogInstance );
					}
				}
			}
		}
	}
}
