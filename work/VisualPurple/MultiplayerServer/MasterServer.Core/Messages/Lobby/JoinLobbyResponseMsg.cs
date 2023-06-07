/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * Revision: Initial 10-12-2022 by James Spellman
 * 
 * A Message sent in response to a JoinLobby message request.
 * Responds with states listed within the enum, along with PlayerName,
 *	PlayerID, and LobbyID.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	public class JoinLobbyResponseMsg : MessageBase
	{
		// Join Lobby Results message enum states
		public enum JoinLobbyResult
		{
			eError = 0,
			eAccepted,
			eDenied,
			eCount // 3
		}

		// The server assigned Lobby ID
		int LobbyID = 0;

		// The Player's ID
		int PlayerID = 0;

		// The Player's Public Name
		string PlayerName;

		// The result code
		JoinLobbyResult Result = JoinLobbyResult.eError;

		// Constructor: Defines enum message type as this class
		public JoinLobbyResponseMsg()
		{
			MsgType = EMessageType.eJoinLobbyResponse;
		}

		// Initializes LobbyID as local variable and JoinLobbyResult as local enum type
		public void Init( int InLobbyID, JoinLobbyResult InJoinLobbyResult )
		{
			LobbyID = InLobbyID;
			Result = InJoinLobbyResult;

			Console.WriteLine( $"JoinLobbyResponseMsg::Init lobbyid {InLobbyID} result {InJoinLobbyResult}" );
		}

		// Initializes input arguments as local variables and JoinLobbyResult as local enum type
		public void Init( int InLobbyID, int InPlayerID, string InPlayerName, JoinLobbyResult InJoinLobbyResult )
		{
			Console.WriteLine( $"JoinLobbyResponseMsg::Init lobbyid {InLobbyID} playerid {InPlayerID} result {InJoinLobbyResult}" );

			LobbyID = InLobbyID;
			PlayerID = InPlayerID;
			this.PlayerName = InPlayerName;
			Result = InJoinLobbyResult;
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.SerializeInt( LobbyID );
			InMStream.SerializeInt( PlayerID );
			InMStream.SerializeString( PlayerName );
			InMStream.WriteByte( (byte)Result );
		}
	}
}