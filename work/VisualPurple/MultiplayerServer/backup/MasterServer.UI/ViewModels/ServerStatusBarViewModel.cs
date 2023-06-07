/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 */

using CommunityToolkit.Mvvm.ComponentModel;
using MasterServer.Core.Models;
using MasterServer.Events;
using Serilog;
using System;

namespace MasterServer.UI.ViewModels
{
	public class ServerStatusBarViewModel : ObservableObject
	{
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		private ServerStatus _serverStatus;
		public ServerStatus ServerStatus
		{
			get => _serverStatus;
			set => SetProperty( ref _serverStatus, value, nameof( ServerStatus ) );
		}

		public ServerStatusBarViewModel( ILogger logger, ServerData serverData )
		{
			_logger = logger;
			_serverData = serverData;
			ServerStatus = new ServerStatus();
			_serverData.OnConnectionCount += UpdateConnectionCount;
			_serverData.OnAddPlayer += AddPlayerCount;
			_serverData.OnRemovePlayer += RemovePlayerCount;
			_serverData.OnAddServer += AddServerCount;
			//_serverData.OnRemoveServer += RemoveServerCount; // Does not exist
			_serverData.OnAddLobby += AddLobbyCount;
			_serverData.OnRemoveLobby += RemoveLobbyCount;
		}

		~ServerStatusBarViewModel()
		{
			_serverData.OnConnectionCount -= UpdateConnectionCount;
			_serverData.OnAddPlayer -= AddPlayerCount;
			_serverData.OnRemovePlayer -= RemovePlayerCount;
			_serverData.OnAddServer -= AddServerCount;
			//_serverData.OnRemoveServer -= RemoveServerCount; // Does not exist
			_serverData.OnAddLobby -= AddLobbyCount;
			_serverData.OnRemoveLobby -= RemoveLobbyCount;
		}

		private void AddServerCount( object sender, AddServerArgs e )
		{
			var count = ServerStatus.ActiveServers + 1;
			ServerStatus.ActiveServers = count;
		}

		private void RemovePlayerCount( object sender, RemovePlayerArgs e )
		{
			var count = ServerStatus.ActivePlayers - 1;
			ServerStatus.ActivePlayers = count;
		}

		private void AddPlayerCount( object sender, AddPlayerArgs e )
		{
			var count = ServerStatus.ActivePlayers + 1;
			ServerStatus.ActivePlayers = count;
		}

		private void AddLobbyCount( object sender, AddLobbyArgs e )
		{
			var count = ServerStatus.ActiveLobbies + 1;
			ServerStatus.ActiveLobbies = count;
		}

		private void RemoveLobbyCount( object sender, RemoveLobbyArgs e )
		{
			var count = ServerStatus.ActiveLobbies - 1;
			ServerStatus.ActiveLobbies = count;
		}

		private void UpdateConnectionCount( object sender, ConnectionCountArgs e )
		{
			var count = e.Count;
			ServerStatus.ActiveConnections = count;
		}
	}
}
