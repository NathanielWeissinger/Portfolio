/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request starting a game from the lobby.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message from the Facilitator to Start the Lobby Map
	public class StartLobbyMsg : MessageBase
	{
		// The server assigned Lobby ID
		int LobbyID = 0;

		// Constructor: Defines enum message type as this class
		public StartLobbyMsg()
		{
			MsgType = EMessageType.eStartLobby;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			LobbyID = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"StartLobbyMsg::Deserialize LobbyID {LobbyID}" );
		}

		// After deserialization, request to start lobby is executed
		override public void Execute()
		{
			ServerData.StartLobby( ClientHandler, LobbyID );
		}
	}
}
