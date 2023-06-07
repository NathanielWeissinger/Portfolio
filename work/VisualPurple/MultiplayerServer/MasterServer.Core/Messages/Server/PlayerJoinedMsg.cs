/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 *			
 * A Message received to request a Player to join a lobby.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Server when a Player Joins
	public class PlayerJoinedMsg : MessageBase
	{
		// The Player's Client ID
		int ClientID = 0;

		// Constructor: Defines enum message type as this class
		public PlayerJoinedMsg()
		{
			MsgType = EMessageType.ePlayerJoined;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			ClientID = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"PlayerJoinedMsg::Deserialize ClientID {ClientID}" );
		}

		// After deserialization, a request for the player to join the lobby is executed
		// Sends log message to UI and updates player location
		override public void Execute()
		{
			ServerData.PlayerJoined( ClientHandler, ClientID );
		}
	}
}
