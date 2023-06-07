/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace MasterServer.UI.ViewModels
{
	public class ServerViewModel : ObservableObject, IViewModel
	{
		private readonly ILogger logger;
		private readonly ServerData serverData;

		public IAsyncRelayCommand CloseWindowCommand { get; }

		public ServerViewModel( ILogger logger, ServerData serverData )
		{
			this.logger = logger;
			this.serverData = serverData;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			PlayersList = new ObservableCollection<string>();
			LobbiesList = new ObservableCollection<string>();

			ServerLogs = new ObservableCollection<ServerLog>();
		}

		private ObservableCollection<string> lobbiesList;
		public ObservableCollection<string> LobbiesList
		{
			get => lobbiesList;
			set => SetProperty( ref lobbiesList, value, nameof( LobbiesList ) );
		}

		private ObservableCollection<string> playersList;
		public ObservableCollection<string> PlayersList
		{
			get => playersList;
			set => SetProperty( ref playersList, value, nameof( PlayersList ) );
		}

		private ObservableCollection<ServerLog> serverLogs;
		public ObservableCollection<ServerLog> ServerLogs
		{
			get => serverLogs;
			set => SetProperty( ref serverLogs, value, nameof( ServerLogs ) );
		}

		private string serverName;
		public string ServerName
		{
			get => serverName;
			set => SetProperty( ref serverName, value, nameof( ServerName ) );
		}

		private string lobbyCount = "0";
		public string LobbyCount
		{
			get => lobbyCount;
			set => SetProperty( ref lobbyCount, value, nameof( LobbyCount ) );
		}

		private string activePlayerCount = "0";
		public string ActivePlayerCount
		{
			get => activePlayerCount;
			set => SetProperty( ref activePlayerCount, value, nameof( ActivePlayerCount ) );
		}

		private string timeUp;
		public string TimeUp
		{
			get => timeUp;
			set => SetProperty( ref timeUp, value, nameof( TimeUp ) );
		}

		private string createdOn;
		public string CreatedOn
		{
			get => createdOn;
			set => SetProperty( ref createdOn, value, nameof( CreatedOn ) );
		}

		private async Task CloseWindow( Window window )
		{
			window.Close();
			await Task.CompletedTask;
		}

		public void LoadActiveServerInformation( int serverId )
		{
			PlayersList.Clear();
			LobbiesList.Clear();

			ServerRec serverRec = serverData.GetServer( serverId );
			if (serverRec != null)
			{
				ServerName = serverRec.Name;
				var lobbyList = serverData.GetLobbies();
				//var lobbyList = _serverData.GetLobbies().Where(x => x.ServerClientID == serverId);
				foreach (var lobby in lobbyList)
				{
					foreach (var player in lobby.PlayerRecs)
					{
						PlayersList.Add( player.ToString() );
					}
					LobbiesList.Add( lobby.ToString() );
				}
				ActivePlayerCount = PlayersList.Count().ToString();
				LobbyCount = LobbiesList.Count().ToString();

				CreatedOn = serverRec.Created.ToString();
				TimeSpan timeInSeconds = TimeSpan.FromSeconds( (DateTime.Now - serverRec.Created).TotalSeconds );
				TimeUp = string.Format( "{0:D2}:{1:D2}:{2:D2}", timeInSeconds.Hours, timeInSeconds.Minutes, timeInSeconds.Seconds );
			}

			FilterServerLogData( serverId );
		}

		private void FilterServerLogData( int id )
		{
			var mainWindowVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
			if (mainWindowVM != null)
			{
				var serverLogList = mainWindowVM.ServerLogs;
				foreach (var log in serverLogList)
				{
					if (log.LogID.Contains( "Server" ) && log.LogID.Contains( id.ToString() ))
					{
						ServerLogs.Add( log );
					}
				}
			}
		}
	}
}
