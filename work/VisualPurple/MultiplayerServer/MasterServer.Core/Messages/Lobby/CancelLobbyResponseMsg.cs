/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a CancelLobby message request.
 * Responds with states listed within the enum, along with LobbyID.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// The response to the Cancel Lobby message
	public class CancelLobbyResponseMsg : MessageBase
	{
		// Cancel Lobby Result message enum states
		public enum CancelLobbyResult
		{
			eError = 0,
			eAccepted,
			eDenied,
			eCount // 3
		}

		// The server assigned Lobby ID
		int LobbyID = 0;

		// The result code
		CancelLobbyResult Result = CancelLobbyResult.eError;

		// Constructor: Defines enum message type as this class
		public CancelLobbyResponseMsg()
		{
			MsgType = EMessageType.eCancelLobbyResponse;
		}

		// Initializes LobbyID as local variable and CancelLobbyResult as local enum type
		public void Init( int InLobbyID, CancelLobbyResult InCancelLobbyResult )
		{
			LobbyID = InLobbyID;
			Result = InCancelLobbyResult;

			Console.WriteLine( $"CancelLobbyResponseMsg::Init lobbyid {InLobbyID} result {InCancelLobbyResult}" );
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