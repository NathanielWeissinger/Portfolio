/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays lobby information, such as the connected server, players/facilitators, dates/times, and the server log.
 *	Within the Master Server Main Menu, while a server is running and a lobby is connected, click an available
 *	lobby within the Lobbies pane to view.
 * See Views->Lobby.xaml and Modals->LobbyModal.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * GRID:		"Server:"			[Name of Server]		Players Panel
 *				"Active Players:"	[Number of Players]
 *				"Facilitator:"		[Name of Facilitator]
 *				"Time Up:"			[Uptime]
 *				"Created:"			[Date/Time Created]
 *				Logs Pane
 * BUTTONS:		Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.Helpers;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.ViewModels
{
	public class LobbyViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }

		private IAsyncRelayCommand _onLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _onLoad;
			set => SetProperty( ref _onLoad, value, nameof( OnLoad ) );
		}

		// Constructor: initializes primary communication and UI data
		public LobbyViewModel(
			ILogger InLogger,
			ServerData InServerData )
		{
			_logger = InLogger;
			_serverData = InServerData;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			ActivePlayersInLobby = new ObservableDictionary<string, string>();
			LobbyLogs = new List<ServerLog>();

			OnLoad = new AsyncRelayCommand( FilterLobbyData );
		}

		// Property: Get/Set List of Active Players in Specified Lobby
		private ObservableDictionary<string, string> _activePlayersInLobby;
		public ObservableDictionary<string, string> ActivePlayersInLobby
		{
			get => _activePlayersInLobby;
			set => SetProperty( ref _activePlayersInLobby, value, nameof( ActivePlayersInLobby ) );
		}

		// Property: Get/Set Specified Lobby Server Logs
		private List<ServerLog> _lobbyLogs;
		public List<ServerLog> LobbyLogs
		{
			get => _lobbyLogs;
			set => SetProperty( ref _lobbyLogs, value, nameof( LobbyLogs ) );
		}

		// Property: Get/Set Lobby Name
		private string _lobbyName;
		public string LobbyName
		{
			get => _lobbyName;
			set => SetProperty( ref _lobbyName, value, nameof( LobbyName ) );
		}

		// Property: Get/Set Server Name
		private string _serverName;
		public string ServerName
		{
			get => _serverName;
			set => SetProperty( ref _serverName, value, nameof( ServerName ) );
		}

		// Property: Get/Set Number of Active Players
		private string _activePlayers;
		public string ActivePlayers
		{
			get => _activePlayers;
			set => SetProperty( ref _activePlayers, value, nameof( ActivePlayers ) );
		}

		// Property: Get/Set Facilitator Name
		private string _faciliatorName;
		public string FacilitatorName
		{
			get => _faciliatorName;
			set => SetProperty( ref _faciliatorName, value, nameof( FacilitatorName ) );
		}

		// Property: Get/Set Uptime (how long lobby has been up)
		private string _timeUp;
		public string TimeUp
		{
			get => _timeUp;
			set => SetProperty( ref _timeUp, value, nameof( TimeUp ) );
		}

		// Property: Get/Set Date/Time of Lobby Creation
		private string _createdOn;
		public string CreatedOn
		{
			get => _createdOn;
			set => SetProperty( ref _createdOn, value, nameof( CreatedOn ) );
		}

		// Task: Adds server logs from the Master Server Main Menu and creates a local list
		private async Task FilterLobbyData()
		{
			var MainWindowVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
			if (MainWindowVM != null)
			{
				// Searches for keywords to obtain correct log file
				var ServerLogList = MainWindowVM.ServerLogs;
				foreach (var log in ServerLogList)
				{
					if (log.LogID.Contains( "Lobby" ) && log.LogID.Contains( LobbyName ))
					{
						LobbyLogs.Add( log );
					}
				}
			}

			await Task.CompletedTask;
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// From the Master Server Main Menu, when a Lobby is clicked,
		// this method initializes all data before getting displayed
		public void LoadLobbyWindowInformation( int InLobbyID )
		{
			LobbyRec LobbyInstance = _serverData.GetLobby( InLobbyID );

			LobbyName = LobbyInstance.Name;

			ServerName = _serverData.GetServer( "Lobby" ).Name;

			ActivePlayers = LobbyInstance.PlayerRecs.Count.ToString();

			FacilitatorName = LobbyInstance.PlayerRecs.FirstOrDefault( x => x.Role.Equals( "Facilitator" ) ).FullName;

			CreatedOn = LobbyInstance.Created.ToString();
			TimeSpan TimeInSeconds = TimeSpan.FromSeconds( (DateTime.Now - LobbyInstance.Created).TotalSeconds );
			TimeUp = string.Format( "{0:D2}:{1:D2}:{2:D2}", TimeInSeconds.Hours, TimeInSeconds.Minutes, TimeInSeconds.Seconds );

			foreach (var player in LobbyInstance.PlayerRecs)
			{
				ActivePlayersInLobby.Add( player.PlayerUID, player.ToString() );
			}
		}
	}
}
