/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Primary file for communication with lobby/game servers and the Master Server Core.
 * Handles UE/UI interaction, data management, and sending/receiving messages
 *	to/from the ClientHandler.
 * 
 * TO DO:
 *	-RemoveServer / ServerDisconnect functionality
 *	-Create Connections count update method
 *	-AddPlayerToLobby event
 *	-RemovePlayerFromLobby event
 *	-UpdatePlayerInLobby event
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using MasterServer.Events;
using MasterServer.Core.Messages;
using static MasterServer.Core.Messages.LogInResponseMsg;
using static MasterServer.Core.Messages.LogOutResponseMsg;
using static MasterServer.Core.Messages.CreateLobbyResponseMsg;
using static MasterServer.Core.Messages.JoinLobbyResponseMsg;
using static MasterServer.Core.Messages.SearchLobbyResponseMsg;
using static MasterServer.Core.Messages.CancelLobbyResponseMsg;
using static MasterServer.Core.Messages.SwitchServerResponseMsg;
using MasterServer.Core.Events;
using System.Numerics;
using System.Text;

namespace MasterServer.Core.Models
{
	public class ServerData
	{
		// Dependencies
		Dictionary<int, ServerRec> m_ActiveServers = new Dictionary<int, ServerRec>();
		Dictionary<int, PlayerRec> m_ActivePlayers = new Dictionary<int, PlayerRec>();
		List<LobbyRec> m_LobbyRecs = new List<LobbyRec>();
		List<PlayerRec> m_PlayerRecs = new List<PlayerRec>();

		const string ServerDataFilePath = "serverdata.json";
		const string PlayerFilePath = "playerdata.json";

		ServerDataModel m_ServerDataModel = new ServerDataModel();

		// Delegates
		public delegate void LogMessageEventHandler( object sender, LogMessageArgs e );
		public delegate void ConnectionCountEventHandler( object sender, ConnectionCountArgs e );
		public delegate void AddServerEventHandler( object sender, AddServerArgs e );
		//public delegate void RemoveServerEventHandler( object sender, RemoveServerArgs e ); 
		public delegate void AddPlayerEventHandler( object sender, AddPlayerArgs e );
		public delegate void RemovePlayerEventHandler( object sender, RemovePlayerArgs e );
		public delegate void UpdatePlayerEventHandler( object sender, UpdatePlayerArgs e );
		public delegate void AddLobbyEventHandler( object sender, AddLobbyArgs e );
		public delegate void RemoveLobbyEventHandler( object sender, RemoveLobbyArgs e );
		public delegate void AddPlayerToLobbyEventHandler( object sender, AddPlayerToLobbyArgs e );
		public delegate void RemovePlayerFromLobbyEventHandler( object sender, RemovePlayerFromLobbyArgs e );
		public delegate void UpdatePlayerInLobbyEventHandler( object sender, UpdatePlayerInLobbyArgs e );

		// Events
		public event LogMessageEventHandler OnLogMessage;
		public event ConnectionCountEventHandler OnConnectionCount; // NOTE: This event has not been set up in this class.
																	// Should add all connections together
																	// from server, lobby, and player counts
		public event AddServerEventHandler OnAddServer;
		//public event RemoveServerEventHandler OnRemoveServer; // Not implemented yet
		public event AddPlayerEventHandler OnAddPlayer;
		public event RemovePlayerEventHandler OnRemovePlayer;
		public event UpdatePlayerEventHandler OnUpdatePlayer;
		public event AddLobbyEventHandler OnAddLobby;
		public event RemoveLobbyEventHandler OnRemoveLobby;
		public event AddPlayerToLobbyEventHandler OnAddPlayerToLobby;
		public event RemovePlayerFromLobbyEventHandler OnRemovePlayerFromLobby;
		public event UpdatePlayerInLobbyEventHandler OnUpdatePlayerInLobby;

		// Property: Get/Set Number of connected Clients
		public int ClientCount { get; internal set; }

		// Loads server data (Ranks, Units, Jobs) and player data
		public void Init()
		{
			LoadData( ServerDataFilePath );
			LoadPlayers( PlayerFilePath );

			// For testing purposes
			/*m_ServerDataModel.Test();
			SaveData(ServerDataFilePath);*/
		}

		// Displays log messages to the Server Log pane in the Master Server Main Menu
		public void LogMessage( string InMessage, string InID )
		{
			OnLogMessage?.Invoke( this, new LogMessageArgs( InMessage, InID ) );
		}


		///////////////////////
		/* Player Management */
		///////////////////////

		// Returns a player record based on the Client ID
		public PlayerRec GetPlayer( int InClientID )
		{
			return m_PlayerRecs.Where( x => (x.Client != null) ).
				  FirstOrDefault( x => (x.Client.ClientID == InClientID) );
		}

		// To Do: make a method that returns a player based on both username and password input
		// Used in LogIn method
		/*public PlayerRec GetPlayer( string InWho, string InPass )
		{
			return m_PlayerRecs.FirstOrDefault( x => ((x.FirstName + " " + x.LastName) == InWho) );
		}*/

		// Returns a player record based on whether the name includes an input string
		public PlayerRec GetPlayer( string InWho )
		{
			// Exact name match
			return m_PlayerRecs.FirstOrDefault( x => ((x.FirstName + " " + x.LastName) == InWho) );
		}

		// Returns list of player records
		public List<PlayerRec> GetPlayerRecs()
		{
			return m_PlayerRecs;
		}

		// Loads player data from playerdata.json
		private void LoadPlayers( string InFilePath )
		{
			// Reads/saves to file
			if (File.Exists( InFilePath ))
			{
				// If file exists, but is empty, save empty settings to it
				if (new FileInfo( InFilePath ).Length == 0)
				{
					SavePlayers( InFilePath );
				}
				else // If file doesn't exist
				{
					// Read json from file
					using (StreamReader r = new StreamReader( InFilePath ))
					{
						string json = r.ReadToEnd();
						// Convert json to list
						m_PlayerRecs = JsonConvert.DeserializeObject<List<PlayerRec>>( json );
					}
				}
			}
			else if (m_PlayerRecs.Count > 0) // If no file exists, and there is more than one player
			{
				// Create file
				File.Create( InFilePath ).Close();

				// Wait for filesystem to create file
				while (!File.Exists( InFilePath ))
				{
					System.Threading.Thread.Sleep( 100 );
				}

				// Save empty settings to file
				SavePlayers( InFilePath );
			}
		}

		// Saves player data to playerdata.json
		private void SavePlayers( string InFilePath )
		{
			string Json = JsonConvert.SerializeObject( m_PlayerRecs, Formatting.Indented );

			File.WriteAllText( InFilePath, Json );
		}

		// After receiving a RegisterPlayerMsg, saves new player to playerdata.json
		public void RegisterPlayer( ClientHandler InClient, string InNetName, 
					  string InFirstName, string InLastName, string InPassword,
					  string InSSN, string InGender, string InRole,
					  string InRank, string InUnit, string InJobCode )
		{
			var PlayerCount = m_PlayerRecs.Count() + 1;
			var PlayerInstance = new PlayerRec()
			{
				PlayerUID = PlayerCount.ToString(),
				FirstName = InFirstName,
				LastName = InLastName,
				Password = InPassword,
				SSN = InSSN,
				Gender = InGender,
				Role = InRole,
				Rank = InRank,
				Unit = InUnit,
				Job = InJobCode,
				Status = "Active"
			};

			m_PlayerRecs.Add( PlayerInstance );

			PlayerInstance.NetName = InNetName;
			PlayerInstance.Client = InClient;

			m_ActivePlayers.Add( InClient.ClientID, PlayerInstance );
			OnAddPlayer?.Invoke( this, new AddPlayerArgs( PlayerInstance ) );
			SavePlayers( PlayerFilePath );

			LogMessage( $"Register player {PlayerInstance.FirstName} as role {PlayerInstance.Role}", "MasterServer" );
		}


		////////////////////////////
		/* Server Data Management */
		////////////////////////////

		// Returns a server record based on whether the name includes an input string
		public ServerRec GetServer( string InRole )
		{
			return m_ActiveServers.
				Where( x => (x.Value.Client != null) ).
				FirstOrDefault( x => (x.Value.Role == InRole) ).
				Value;
		}

		// Returns a server record based on the Client ID
		public ServerRec GetServer( int InClientID )
		{
			m_ActiveServers.TryGetValue( InClientID, out var ServerInstance );
			return ServerInstance;
		}

		// Loads server data from serverdata.json
		private void LoadData( string InFilePath )
		{
			if (File.Exists( InFilePath ))
			{
				// If file exists, but is empty, save empty settings to it
				if (new FileInfo( InFilePath ).Length == 0)
				{
					SaveData( InFilePath );
				}
				else
				{
					// Read json from file
					using (StreamReader r = new StreamReader( InFilePath ))
					{
						string Json = r.ReadToEnd();
						// Convert json to object
						m_ServerDataModel = JsonConvert.DeserializeObject<ServerDataModel>( Json );
					}
				}
			}
			else
			{
				// Create file
				File.Create( InFilePath ).Close();

				// Wait for system to create file
				while (!File.Exists( InFilePath ))
				{
					System.Threading.Thread.Sleep( 100 );
				}

				// Save empty settings to file
				SaveData( InFilePath );
			}
		}

		// Saves server data to serverdata.json
		private void SaveData( string InFilePath )
		{
			string Json = JsonConvert.SerializeObject( m_ServerDataModel, Formatting.Indented );

			File.WriteAllText( InFilePath, Json );
		}

		// Sends a request to receive server data
		public void RequestServerData( ClientHandler InClient )
		{
			var ServerMsg = new ServerDataResponseMsg();
			ServerMsg.Init( m_ServerDataModel );
			ServerMsg.Send( InClient );
		}


		//////////////////////
		/* Lobby Management */
		//////////////////////

		// Returns a lobby record based on the Client ID
		public LobbyRec GetLobby( int InLobbyID )
		{
			return m_LobbyRecs.FirstOrDefault( x => (x.LobbyID == InLobbyID) );
		}

		// Returns a lobby record based on whether the name includes an input string
		private LobbyRec GetLobby( string InWho )
		{
			return m_LobbyRecs.FirstOrDefault( x => (x.Name == InWho) );
		}

		// Returns list of lobby records
		public List<LobbyRec> GetLobbies()
		{
			return m_LobbyRecs;
		}

		// Creates lobby, and if accepted, allows player to join
		public void RegisterLobby( ClientHandler InClient, string InLobbyName, int InMaxPlayers )
		{
			var LobbyID = 0;

			LogMessage( $"Register lobby {InLobbyName} maxplayers {InMaxPlayers}", "<Lobby>" + InLobbyName );

			var Response = ValidateRegisterLobby( InLobbyName, InMaxPlayers );
			var ResponseAccepted = (Response == CreateLobbyResult.eAccepted);

			// Add the Facilitator to the Lobby
			var host = GetPlayer( InClient.ClientID );

			// Only join lobby if it was created!!!
			if (ResponseAccepted)
			{
				LobbyID = m_LobbyRecs.Count() + 1;

				// Create and add new lobby
				var LobbyInstance = new LobbyRec()
				{
					LobbyID = LobbyID,
					Name = InLobbyName,
					MaxPlayers = InMaxPlayers,
					Status = "Open",
					PlayerRecs = new List<PlayerRec>()
				};

				m_LobbyRecs.Add( LobbyInstance );
				LobbyInstance.PlayerRecs.Add( host );
				OnAddLobby?.Invoke( this, new AddLobbyArgs( LobbyInstance ) );
			}

			var CreateResponseMsg = new CreateLobbyResponseMsg();
			CreateResponseMsg.Init( LobbyID, Response );
			CreateResponseMsg.Send( InClient );

			// Only join lobby if it was created!!!
			if (ResponseAccepted)
			{
				var ServerInstance = GetServer( "Lobby" );

				LogMessage( $"Send Switch Server request to Lobby", "<Server>" + ServerInstance.Client.ClientID );

				var ServerMsg = new SwitchServerMsg();
				ServerMsg.Init( InClient.ClientID, host.NetName, host.NameAndRank, true );
				ServerMsg.Send( ServerInstance.Client );

				// Immediately launch map after joining lobby
				/*LogMessage( $"Launch Lobby Map {server.GetHostAddress()}" );
				var MapMsg = new LaunchMapMsg();
				MapMsg.Init( server.GetHostAddress() );
				MapMsg.Send( client );*/
			}
		}

		// Goes through checks to see if lobby is valid to run:
		// Checks number of players, and whether the lobby/server exist 
		CreateLobbyResult ValidateRegisterLobby( string InLobbyName, int InMaxPlayers )
		{
			var LobbyInstance = GetLobby( InLobbyName );

			LogMessage( $"ValidateRegisterLobby lobbyname {InLobbyName}", "MasterServer" );

			if (LobbyInstance != null)
			{
				// Lobby already exists
				LogMessage( $"Denied registration: Lobby exists!", "<Lobby>" + LobbyInstance.Name );

				return CreateLobbyResult.eAlreadyExists;
			}

			if (
					(InMaxPlayers < 1) ||
					(InMaxPlayers > 12)
				)
			{
				// Too few or too many players
				LogMessage( $"Denied registration: Failed Validation!", "<Lobby>" + LobbyInstance.Name );

				return CreateLobbyResult.eValidationFailed;
			}

			var ServerInstance = GetServer( "Lobby" );

			if (ServerInstance == null) // May also want to check if it is online
			{
				// Lobby server doesn't exist
				LogMessage( $"Denied registration: No Lobby Servers Online!", "<Server>" + ServerInstance.Client.ClientID );

				return CreateLobbyResult.eServerUnavailable;
			}

			return CreateLobbyResult.eAccepted;
		}

		// Closes a lobby by removing players, removing lobby, and setting instances to null
		public void CancelLobby( ClientHandler InClient, int InLobbyID )
		{
			var Response = CancelLobbyResult.eError;
			LobbyRec LobbyInstance = null;
			LobbyInstance = GetLobby( InLobbyID );

			if (LobbyInstance == null)
			{
				// Lobby already exists
				Response = CancelLobbyResult.eDenied;

				LogMessage( $"Denied lobby cancel!", "<Lobby>" + LobbyInstance.Name );

				var LobbyMsg = new CancelLobbyResponseMsg();
				LobbyMsg.Init( InLobbyID, Response );
				LobbyMsg.Send( InClient );
			}
			else
			{
				Response = CancelLobbyResult.eAccepted;

				LogMessage( $"Cancel lobby {InLobbyID}", "<Lobby>" + LobbyInstance.Name );

				m_LobbyRecs.Remove( LobbyInstance );

				// Send Cancel Lobby message to all players
				foreach (var player in LobbyInstance.PlayerRecs)
				{
					var LobbyMsg = new CancelLobbyResponseMsg();
					LobbyMsg.Init( InLobbyID, Response );
					LobbyMsg.Send( player.Client );
				}
			}
		}

		// Sends a message with a list of open lobbies
		public void SearchLobby( ClientHandler InClient )
		{
			LogMessage( $"Search lobby {InClient.ClientID}", "MasterServer" );

			var LobbyMsg = new SearchLobbyResponseMsg();
			LobbyMsg.Init( SearchLobbyResult.eAccepted );

			// Add all available lobbies
			var OpenLobbies = m_LobbyRecs.Where( x => (x.Status == "Open") );
			foreach (var lobby in OpenLobbies)
				LobbyMsg.LobbyRecs.Add( lobby );

			LobbyMsg.Send( InClient );
		}

		// Sends a message to allow player to join a lobby
		public void JoinLobby( ClientHandler InClient, int InLobbyID )
		{
			// Send Launch Map message to all players including the host
			var LobbyInstance = GetLobby( InLobbyID );
			var PlayerInstance = GetPlayer( InClient.ClientID );

			LogMessage( $"Join lobbyid {InLobbyID} playerid {InClient.ClientID}", "<Lobby>" + LobbyInstance.Name );

			// If lobby or player doesn't exist
			if ((LobbyInstance == null) || (PlayerInstance == null))
			{
				// Return failure
				var LobbyMsg = new JoinLobbyResponseMsg();
				LobbyMsg.Init( InLobbyID, JoinLobbyResult.eError );
				LobbyMsg.Send( InClient );

				return;
			}

			// Send Join Lobby message to all players
			/*foreach (var p in lobby.PlayerRecs)
			{
				var LobbyMsg = new JoinLobbyResponseMsg();
				LobbyMsg.Init( lobbyid, client.ClientID, player.Name, JoinLobbyResult.eAccepted );
				LobbyMsg.Send( p.Client );
			}*/

			// Add new player
			LobbyInstance.PlayerRecs.Add( PlayerInstance );

			// Send Join Lobby message for all players
			/*foreach (var p in lobby.PlayerRecs)
			{
				var LobbyMsg = new JoinLobbyResponseMsg();
				LobbyMsg.Init( lobbyid, p.Client.ClientID, p.Name, JoinLobbyResult.eAccepted );
				LobbyMsg.Send( client );
			}*/

			// Lobby should know what server it is
			//lobby.server 
			var ServerInstance = GetServer( "Lobby" );

			LogMessage( $"Launch Map {ServerInstance.GetHostAddress()}", "<Server>" + ServerInstance.Client.ClientID );

			// Immediately Launch Map
			var JMsg = new LaunchMapMsg();
			JMsg.Init( ServerInstance.GetHostAddress() );
			JMsg.Send( InClient );
		}

		// Sends a message to request a player to switch servers while the player is already in a lobby
		public void JoinServerRequest( ClientHandler InClient, string InMapName )
		{
			// Player requests to join a server
			var ServerInstance = GetServer( InMapName );
			var PlayerInstance = GetPlayer( InClient.ClientID );

			LogMessage( $"JoinServerRequest clientid {InClient.ClientID} mapname {InMapName}", "<Server>" + ServerInstance.Client.ClientID );

			// Pass along request to the server
			var ServerMsg = new SwitchServerMsg();
			ServerMsg.Init( InClient.ClientID, PlayerInstance.NetName, PlayerInstance.NameAndRank, (PlayerInstance.Role == "Facilitator") );
			ServerMsg.Send( ServerInstance.Client );
		}

		// Switches a player who is already in a server lobby into another server's lobby
		public void JoinServer( ClientHandler InClient, int InClientID, SwitchServerResult InSwitchServerResult )
		{
			// Send the player to a server
			var ServerInstance = GetServer( InClient.ClientID );
			var PlayerInstance = GetPlayer( InClientID );

			LogMessage( $"JoinServer clientid {InClientID} result {InSwitchServerResult}", "<Server>" + ServerInstance.Client.ClientID );

			// Send the player to the server
			var MapMsg = new LaunchMapMsg();
			MapMsg.Init( ServerInstance.GetHostAddress() );
			MapMsg.Send( PlayerInstance.Client );
		}

		// Sends a PlayerJoined message to the Server Log and updates player position
		public void PlayerJoined( ClientHandler InClient, int InClientID )
		{
			/* TO DO: Update the player's location */

			LogMessage( $"PlayerJoined clientid {InClientID}", "<Player>" + GetPlayer( InClientID ).PlayerUID );

			/*var ServerInstance = GetServer( client.ClientID );
			var PlayerInstance = GetPlayer( InClientID );*/
		}

		// Once all players are in the lobby, move players to map and send a message to start the game
		public void StartLobby( ClientHandler InClient, int InLobbyID )
		{
			var LobbyInstance = GetLobby( InLobbyID );
			LogMessage( $"Start lobby {InLobbyID}", "<Lobby>" + LobbyInstance.Name );

			// Lobby should know what server it is
			//lobby.server 
			var ServerInstance = GetServer( "Lobby" );

			LogMessage( $"Launch Map {ServerInstance.GetHostAddress()}", "<Server>" + ServerInstance.Client.ClientID );

			// Send Launch Map message to all players including the host
			foreach (var p in LobbyInstance.PlayerRecs)
			{
				var MapMsg = new LaunchMapMsg();
				MapMsg.Init( ServerInstance.GetHostAddress() );
				MapMsg.Send( p.Client );
			}
		}


		///////////////////////////
		/* Connection Management */
		///////////////////////////

		// Set Connect Count
		public void SetConnectionCount( int InCount )
		{
			OnConnectionCount?.Invoke( this, new ConnectionCountArgs( InCount ) );
		}

		// If a client disconnects, removes player from active players list
		// and sends a log message on the Server Log
		public void ClientDisconnect( int InClientID )
		{
			if (m_ActivePlayers.ContainsKey( InClientID ))
			{
				var PlayerInstance = m_ActivePlayers[InClientID];
				PlayerInstance.Client = null;
			}

			LogMessage( $"Client #{InClientID} Disconnected!", "MasterServer" );
		}

		// Server Connect Message:
		public void ServerConnect( ClientHandler InClient, int InCType, string InCName, int InVersion )
		{
			var Response = ConnectResult.eError;
			var bIsLobby = ((ConnectMsg.EClientType)InCType == Messages.ConnectMsg.EClientType.eLobbyServer);

			// Defines server to connect to
			var ServerInstance = new ServerRec()
			{
				Name = InCName,
				Version = InVersion,
				Role = bIsLobby ? "Lobby" : "Game",
				Port = bIsLobby ? 7777 : 7778,
				Status = "Online"
			};

			ServerInstance.Client = InClient;

			LogMessage( $"ServerConnect id {InClient.ClientID} type {InCType} cname {InCName} role {ServerInstance.Role} version {InVersion}", "<Server>" + ServerInstance.Client.ClientID );

			m_ActiveServers.Add( InClient.ClientID, ServerInstance );
			OnAddServer?.Invoke( this, new AddServerArgs( ServerInstance ) );
			Response = ConnectResult.eAccepted;

			var ConnectMsg = new ConnectResponseMsg();
			ConnectMsg.Init( InClient.ClientID, Response );
			ConnectMsg.Send( InClient );
		}

		// To Do: remove the server from the server list,
		// kill any lobbies, set the players back to a log out status,
		// and send them a message to boot them back to the appropriate
		// post-login menu, all before disconnecting a server.
		/*public void ServerDisconnect( int InClientID )
		{
			// Have not tested code, pulled from ClientDisconnect and altered
			if (m_ActiveServers.ContainsKey( InCLientID ))
			{
				var ServerInstance = m_ActiveServers[InClientID];
				ServerInstance.Client = null;
				OnRemoveServer?.Invoke( this, new RemoveServerArgs( ServerInstance ) );
			}
			LogMessage( $"Server #{InClientID} Disconnected!", "MasterServer" );
		}*/

		// Log In Message: checks to see if username/password matches a player's credentials
		public void LogIn( ClientHandler InClient, string InPlayerName, string InPassword, string InNetName )
		{
			var LoginResult = LogInResult.eNotFound;
			PlayerRec PlayerInstance = null;

			LogMessage( $"LogIn client id {InClient.ClientID} playername {InPlayerName} netname {InNetName}", "MasterServer" );

			// TO DO: Replace CheckPassword method with GetPlayer(PlayerName, Password)
			PlayerInstance = GetPlayer( InPlayerName/*, password*/ );
			bool bCheckPassword = CheckPassword( PlayerInstance, InPassword );

			// If Player exists and password input is correct
			if (PlayerInstance != null && bCheckPassword)
			{
				LogMessage( $"Player found {PlayerInstance.PlayerUID}", "<Player>" + PlayerInstance.PlayerUID );

				// Set the Unreal Network Name
				PlayerInstance.NetName = InNetName;

				// Don't let a player log in twice
				if ( m_ActivePlayers.ContainsValue( PlayerInstance )
					&& (PlayerInstance.Client != null) )
				{
					// Active player found!
					LoginResult = LogInResult.eActive;
				}
				else
				{
					PlayerInstance.Client = InClient;

					// Player already exists
					if (m_ActivePlayers.ContainsValue( PlayerInstance ))
					{
						OnUpdatePlayer?.Invoke( this, new UpdatePlayerArgs( PlayerInstance ) );
					}
					else
					{
						m_ActivePlayers.Add( InClient.ClientID, PlayerInstance );

						OnAddPlayer?.Invoke( this, new AddPlayerArgs( PlayerInstance ) );
					}

					if (PlayerInstance.Role == "Facilitator")
						LoginResult = LogInResult.eFaciliator;
					else if (bCheckPassword) //If the input password is the same as the saved
						LoginResult = LogInResult.eAccepted;
				}
			}
			else if (!bCheckPassword) //If the input password is not the same as the saved
				LoginResult = LogInResult.eDenied;

			var LoginMsg = new LogInResponseMsg();
			LoginMsg.Init( InClient.ClientID, LoginResult );
			LoginMsg.Send( InClient );

			// Test code, instantly launches map if logged in player is a facilitator
			/*if (PlayerInstance != null)
			{
				// Tell the client to start a new map
				if (PlayerInstance.Role == "Facilitator")
				{
					var MapMsg = new LaunchMapMsg();
					MapMsg.Init( "Map_Game" );
					MapMsg.Send( m_Client );
				}
			}*/
		}

		// Checks to ensure input password hash equals saved password hash
		public bool CheckPassword( PlayerRec InPlayer, string InPassword )
		{
			if (string.Equals( InPlayer.Password, InPassword ))
				return true;
			else
				return false;
		}

		// Log Out Message: logs player out of server
		public void LogOut( ClientHandler InClient )
		{
			var LogoutResponse = LogOutResult.eNotFound;

			// Look up Player
			var PlayerInstance = GetPlayer( InClient.ClientID );

			LogMessage( $"LogOut clientid {InClient.ClientID}", "MasterServer" );

			if (PlayerInstance != null)
			{
				LogoutResponse = LogOutResult.eAccepted;
				m_ActivePlayers.Remove( InClient.ClientID );
				OnRemovePlayer?.Invoke( this, new RemovePlayerArgs( PlayerInstance ) );
			}

			// Send Response message to Client
			var LogoutMsg = new LogOutResponseMsg();
			LogoutMsg.Init( LogoutResponse );
			LogoutMsg.Send( InClient );
		}

		// Generic Message handler, used for testing
		public void HandleGenericMessage( ClientHandler InClient, int InParam1, int InParam2 )
		{
			Console.WriteLine( $"Handle Generic Message param1 {InParam1} param2 {InParam2}" );

			// If param1 is 1, launch the Game Map
			if (InParam1 == 1)
			{
				var ServerInstance = GetServer( "Game" );

				var MapMsg = new LaunchMapMsg();
				MapMsg.Init( ServerInstance.GetHostAddress() );
				MapMsg.Send( InClient );
			}

			// If param1 is 2, launch the Lobby Map
			if (InParam1 == 2)
			{
				var ServerInstance = GetServer( "Lobby" );

				var MapMsg = new LaunchMapMsg();
				MapMsg.Init( ServerInstance.GetHostAddress() );
				MapMsg.Send( InClient );
			}
		}
	}
}
