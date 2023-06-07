/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * Revision: Initial 10-12-2022 by James Spellman
 * 
 * A Message received to request creating a lobby.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message from the Facilitator to Create a Lobby
	public class CreateLobbyMsg : MessageBase
	{
		// The public Lobby Name
		string LobbyName;

		// The Maximum Number of Players for the Lobby
		int MaxPlayers = 4;

		// Constructor: Defines enum message type as this class
		public CreateLobbyMsg()
		{
			MsgType = EMessageType.eCreateLobby;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			LobbyName = bytes.DeSerializeString( ref index );
			MaxPlayers = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"CreateLobbyMsg::Deserialize LobbyName {LobbyName} MaxPlayers {MaxPlayers}" );
		}

		// After deserialization, request to register a lobby is executed
		override public void Execute()
		{
			ServerData.RegisterLobby( ClientHandler, LobbyName, MaxPlayers );
		}
	}
}