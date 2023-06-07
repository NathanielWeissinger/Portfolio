/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a CreateLobby message request.
 * Responds with states listed within the enum, along with LobbyID.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// The response to the Create Lobby message
	public class CreateLobbyResponseMsg : MessageBase
	{
		// Create Lobby Result message enum states
		public enum CreateLobbyResult
		{
			eError = 0,
			eAccepted,
			eAlreadyExists,
			eValidationFailed,
			eServerUnavailable,
			eCount // 5
		}

		// The server assigned Lobby ID
		int LobbyID = 0;

		// The result code
		CreateLobbyResult Result = CreateLobbyResult.eError;

		// Constructor: Defines enum message type as this class
		public CreateLobbyResponseMsg()
		{
			MsgType = EMessageType.eCreateLobbyResponse;
		}

		// Initializes LobbyID as local variable and CreateLobbyResult as local enum type
		public void Init( int InLobbyID, CreateLobbyResult InCreateLobbyResult )
		{
			LobbyID = InLobbyID;
			Result = InCreateLobbyResult;

			Console.WriteLine( $"CreateLobbyResponseMsg::Init lobbyid {InLobbyID} result {InCreateLobbyResult}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.SerializeInt( LobbyID );
			InMStream.WriteByte( (byte)Result );
		}
	}
}