/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Within the Master Server Main Menu, this class displays the number of connections, servers,
 *	lobbies, and players currently connected to the server.
 * See MainWindow.xaml and CustomControls->ServerBarStatusControl.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * GRID:	Connections		[#]			Servers			[#]
 *			Lobbies			[#]			Active Players	[#]
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
		// Dependencies
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		// Constructor: initializes primary communication and UI data
		public ServerStatusBarViewModel( ILogger InLogger, ServerData InServerData )
		{
			_logger = InLogger;
			_serverData = InServerData;
			ServerStatus = new ServerStatus();
			_serverData.OnConnectionCount += UpdateConnectionCount;
			_serverData.OnAddPlayer += AddPlayerCount;
			_serverData.OnRemovePlayer += RemovePlayerCount;
			_serverData.OnAddServer += AddServerCount;
			//_serverData.OnRemoveServer += RemoveServerCount; // Does not exist
			_serverData.OnAddLobby += AddLobbyCount;
			_serverData.OnRemoveLobby += RemoveLobbyCount;
		}

		// Destructor: Removes temporary properties of calls
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

		// Property: Get/Set ServerStatus (stores active states of players/connections)
		private ServerStatus _serverStatus;
		public ServerStatus ServerStatus
		{
			get => _serverStatus;
			set => SetProperty( ref _serverStatus, value, nameof( ServerStatus ) );
		}

		// Adds 1 to the number of active servers
		private void AddServerCount( object sender, AddServerArgs e )
		{
			var count = ServerStatus.ActiveServers + 1;
			ServerStatus.ActiveServers = count;
		}

		// Subtracts 1 from the number of active servers
		/*private void RemoveServerCount( object sender, RemoveServerArgs e )
		{
			var count = ServerStatus.ActiveServers - 1;
			ServerStatus.ActiveServers = count;
		}*/

		// Adds 1 to the number of active players
		private void AddPlayerCount( object InSender, AddPlayerArgs e )
		{
			var Count = ServerStatus.ActivePlayers + 1;
			ServerStatus.ActivePlayers = Count;
		}

		// Subtracts 1 from the number of active players
		private void RemovePlayerCount( object InSender, RemovePlayerArgs e )
		{
			var Count = ServerStatus.ActivePlayers - 1;
			ServerStatus.ActivePlayers = Count;
		}

		// Adds 1 to the number of active lobbies
		private void AddLobbyCount( object InSender, AddLobbyArgs e )
		{
			var Count = ServerStatus.ActiveLobbies + 1;
			ServerStatus.ActiveLobbies = Count;
		}

		// Subtracts 1 from the number of active lobbies
		private void RemoveLobbyCount( object InSender, RemoveLobbyArgs e )
		{
			var Count = ServerStatus.ActiveLobbies - 1;
			ServerStatus.ActiveLobbies = Count;
		}

		// Counts the number of active connections (counts everything,
		// including players, servers, and lobbies)
		// Has not been set up yet in ServerData.cs
		private void UpdateConnectionCount( object InSender, ConnectionCountArgs e )
		{
			var Count = e.Count;
			ServerStatus.ActiveConnections = Count;
		}
	}
}
