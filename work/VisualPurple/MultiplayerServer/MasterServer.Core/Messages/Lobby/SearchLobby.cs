/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request searching for a lobby.
 */

using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message from a Player to Search for active Lobbies
	public class SearchLobbyMsg : MessageBase
	{
		// Constructor: Defines enum message type as this class
		public SearchLobbyMsg()
		{
			MsgType = EMessageType.eSearchLobby;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			Console.WriteLine( $"SearchLobbyMsg::Deserialize ClientID {ClientHandler.ClientID}" );
		}

		// After deserialization, request to search for a lobby is executed
		override public void Execute()
		{
			ServerData.SearchLobby( ClientHandler );
		}
	}
}