/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Interface that stores record of Lobby information within a server.
 */

using MasterServer.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace MasterServer.Core.Models
{
	// A Lobby created by a Facilitator
	public class LobbyRec
	{
		// The Server assigned Lobby ID
		public int LobbyID { get; set; }

		// The Server ID that the Lobby belongs to
		public int ServerClientID { get; set; } = -1;

		// The Facilitator provided Lobby public name
		public string Name { get; set; }

		// The maximum players supported by the Lobby
		public int MaxPlayers { get; set; }

		// The operational status of the Lobby (Open, Closed)
		public string Status { get; set; }

		// The average round-trip time it takes to communicate with the server in ms
		public int Ping { get; set; }

		public DateTime Created { get; set; } = DateTime.Now;

		// An Array of Players in the Lobby
		public List<PlayerRec> PlayerRecs { get; set; }

		// Serializes Lobby variables for storage
		public void Serialize( MemoryStream InMStream )
		{
			InMStream.SerializeInt( LobbyID );
			InMStream.SerializeString( Name );
			InMStream.SerializeInt( PlayerRecs.Count );
			InMStream.SerializeInt( MaxPlayers );
			InMStream.SerializeInt( Ping );
		}

		// Converts LobbyID, Name, and Status to String for list placement
		public override string ToString()
		{
			return $"<Lobby {LobbyID}> {Name} ({Status})";
		}
	}
}
