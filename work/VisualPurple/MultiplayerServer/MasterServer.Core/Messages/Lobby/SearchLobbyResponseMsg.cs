/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * Revision: Initial 10-12-2022 by James Spellman
 * 
 * A Message sent in response to a SearchLobby message request.
 * Responds with states listed within the enum, along with the number
 * and names of all Lobbies.
 */

using MasterServer.Core.Models;
using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace MasterServer.Core.Messages
{
	// The response to the Search Lobby message
	public class SearchLobbyResponseMsg : MessageBase
	{
		// Searche Lobby Result message enum states
		public enum SearchLobbyResult
		{
			eError = 0,
			eAccepted,
			eDenied,
			eCount // 3
		}

		// The response code
		SearchLobbyResult Result = SearchLobbyResult.eError;

		// An array of available Lobbies
		public List<LobbyRec> LobbyRecs = new List<LobbyRec>();

		// Constructor: Defines enum message type as this class
		public SearchLobbyResponseMsg()
		{
			MsgType = EMessageType.eSearchLobbyResponse;
		}

		// Initializes SearchLobbyResult as local enum type
		public void Init( SearchLobbyResult InSearchLobbyResult )
		{
			Result = InSearchLobbyResult;
			
			Console.WriteLine( $"SearchLobbyResponseMsg::Init result {InSearchLobbyResult}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.WriteByte( (byte)Result );
			InMStream.SerializeInt( LobbyRecs.Count );

			// Serialize all available lobbies
			foreach (var lobby in LobbyRecs)
				lobby.Serialize( InMStream );
		}
	}
}