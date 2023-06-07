/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * Revision: Initial 10-12-2022 by James Spellman
 * 
 * A Message received to request a Player to join a lobby.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message from a Player to Join a specified Lobby
	public class JoinLobbyMsg : MessageBase
	{
		// The server assigned Lobby ID
		int LobbyID = 0;

		// Constructor: Defines enum message type as this class
		public JoinLobbyMsg()
		{
			MsgType = EMessageType.eJoinLobby;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			LobbyID = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"JoinLobbyMsg::Deserialize LobbyID {LobbyID}" );
		}

		// After deserialization, request to join a lobby is executed
		override public void Execute()
		{
			ServerData.JoinLobby( ClientHandler, LobbyID );
		}
	}
}