/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core;
using MasterServer.Core.Models;
using MasterServer.Events;
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
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		public IAsyncRelayCommand CloseWindowCommand { get; }

		private IAsyncRelayCommand _onLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _onLoad;
			set => SetProperty( ref _onLoad, value, nameof( OnLoad ) );
		}

		public LobbyViewModel(
			ILogger logger,
			ServerData serverData )
		{
			_logger = logger;
			_serverData = serverData;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			ActivePlayersInLobby = new ObservableDictionary<string, string>();
			LobbyLogs = new List<ServerLog>();

			OnLoad = new AsyncRelayCommand( FilterLobbyData );
		}

		private async Task FilterLobbyData()
		{
			var mainWindowVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
			if (mainWindowVM != null)
			{
				var serverLogList = mainWindowVM.ServerLogs;
				foreach (var log in serverLogList)
				{
					if (log.LogID.Contains( "Lobby" ) && log.LogID.Contains( LobbyName ))
					{
						LobbyLogs.Add( log );
					}
				}
			}

			await Task.CompletedTask;
		}

		private async Task CloseWindow( Window window )
		{
			window.Close();
			await Task.CompletedTask;
		}

		private ObservableDictionary<string, string> _activePlayersInLobby;
		public ObservableDictionary<string, string> ActivePlayersInLobby
		{
			get => _activePlayersInLobby;
			set => SetProperty( ref _activePlayersInLobby, value, nameof( ActivePlayersInLobby ) );
		}

		private List<ServerLog> _lobbyLogs;
		public List<ServerLog> LobbyLogs
		{
			get => _lobbyLogs;
			set => SetProperty( ref _lobbyLogs, value, nameof( LobbyLogs ) );
		}

		private string _lobbyName;
		public string LobbyName
		{
			get => _lobbyName;
			set => SetProperty( ref _lobbyName, value, nameof( LobbyName ) );
		}

		private string _serverName;
		public string ServerName
		{
			get => _serverName;
			set => SetProperty( ref _serverName, value, nameof( ServerName ) );
		}

		private string _activePlayers;
		public string ActivePlayers
		{
			get => _activePlayers;
			set => SetProperty( ref _activePlayers, value, nameof( ActivePlayers ) );
		}

		private string _faciliatorName;
		public string FacilitatorName
		{
			get => _faciliatorName;
			set => SetProperty( ref _faciliatorName, value, nameof( FacilitatorName ) );
		}

		private string _timeUp;
		public string TimeUp
		{
			get => _timeUp;
			set => SetProperty( ref _timeUp, value, nameof( TimeUp ) );
		}

		private string _createdOn;
		public string CreatedOn
		{
			get => _createdOn;
			set => SetProperty( ref _createdOn, value, nameof( CreatedOn ) );
		}

		public void LoadLobbyWindowInformation( int lobbyId )
		{
			LobbyRec lobbyRec = _serverData.GetLobby( lobbyId );

			LobbyName = lobbyRec.Name;

			ServerName = _serverData.GetServer( "Lobby" ).Name;

			ActivePlayers = lobbyRec.PlayerRecs.Count.ToString();

			FacilitatorName = lobbyRec.PlayerRecs.FirstOrDefault( x => x.Role.Equals( "Facilitator" ) ).FullName;

			CreatedOn = lobbyRec.Created.ToString();
			TimeSpan timeInSeconds = TimeSpan.FromSeconds( (DateTime.Now - lobbyRec.Created).TotalSeconds );
			TimeUp = string.Format( "{0:D2}:{1:D2}:{2:D2}", timeInSeconds.Hours, timeInSeconds.Minutes, timeInSeconds.Seconds );


			foreach (var player in lobbyRec.PlayerRecs)
			{
				ActivePlayersInLobby.Add( player.PlayerUID, player.ToString() );
			}

		}
	}
}
