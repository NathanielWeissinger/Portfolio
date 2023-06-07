/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Player instance's server data record interface.
 * Used to serialize to the disk.
 */

using System;

namespace MasterServer.Core.Models
{
	public class ServerRec
	{
		// The Server's Name
		public string Name { get; set; }

		// The Server's Version
		public int Version { get; set; }

		// The Server's Socket Connection (increments with each new player connected)
		public int? ClientID { get; set; }

		public ClientHandler Client { get; set; }

		// The Server's Role (Lobby or Game)
		public string Role { get; set; }

		// The Server's Status (Online or Offline)
		public string Status { get; set; }

		// The Server's Port Number (7777 - Lobby Map, 7778 - Game Map)
		public int Port { get; set; }

		// The Server's Creation Time (Date and Time)
		public DateTime Created { get; set; } = DateTime.Now;

		// The Server Info Form
		//public PlayerForm PlayerForm { get; set; }

		// Converts ClientID to String for list index placement
		public override string ToString()
		{
			var name = Name;

			if (ClientID != null)
				name = $"<{ClientID}> {Name}";

			if (ClientID == null)
				name += " (Offline)";

			return name;
		}

		// Tick function for communication between players and servers
		// to ensure connection is maintained
		public void OnHeartbeat()
		{
			//if (PlayerForm != null)
			//PlayerForm.OnHeartbeat();
		}

		// Returns client's host address and port number
		public string GetHostAddress()
		{
			return $"{Client.GetHostAddress()}:{Port}";
		}
	}
}
