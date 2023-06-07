/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * Revision: Initial 10-12-2022 by James Spellman
 * 
 * A Message received to request closing a lobby.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message from the Facilitator to Cancel a Lobby
	public class CancelLobbyMsg : MessageBase
	{
		// The server assigned Lobby ID
		int LobbyID = 0;

		// Constructor: Defines enum message type as this class
		public CancelLobbyMsg()
		{
			MsgType = EMessageType.eCancelLobby;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			LobbyID = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"CancelLobbyMsg::Deserialize LobbyID {LobbyID}" );
		}

		// After deserialization, request to close a lobby is executed
		override public void Execute()
		{
			ServerData.CancelLobby( ClientHandler, LobbyID );
		}
	}
}
