/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Player instance's data record interface.
 * Used to serialize to the disk.
 */

using Newtonsoft.Json;

namespace MasterServer.Core.Models
{
	public class PlayerRec
	{
		// The user-provided Player Unique Identifier
		[JsonProperty( "ID" )]
		public string PlayerUID { get; set; }

		// The Player's First Name
		public string FirstName { get; set; }

		// The Player's Last Name
		public string LastName { get; set; }

		// The Player's Password Hash
		public string Password { get; set; }

		// The Player's SSN
		public string SSN { get; set; }

		// The Player's Gender
		public string Gender { get; set; }

		// The Player's Role (Facilitator, Player, Observer)
		public string Role { get; set; }

		// The Player's Rank 
		public string Rank { get; set; }

		// The Player's Unit
		public string Unit { get; set; }

		// The Player's Job Code
		public string Job { get; set; }

		// The Player's Status (Active, Inactive)
		public string Status { get; set; }


		///////////////////////////////////////////////////
		/* These variables are not serilized to the disk */
		///////////////////////////////////////////////////

		// The Client Connection to the Player
		[JsonIgnore]
		public ClientHandler Client { get; set; }

		// The Player's Network Name
		[JsonIgnore]
		public string NetName { get; set; }

		// The Player Info Form
		//[JsonIgnore]
		//public PlayerForm PlayerForm { get; set; }

		// Returns Player's first and last name
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		// Returns Player's last name and rank
		public string NameAndRank
		{
			get
			{
				var name = LastName;

				if (Rank != null)
					name = $"{Rank} {name}";

				return name;
			}
		}

		// Converts Player information to String for list index placement,
		// depending on the information available
		public override string ToString()
		{
			var name = NameAndRank;

			if (Client != null)
				name = $"<{Client.ClientID}> {name}";

			if (Role == "Facilitator")
				name += " [Facilitator]";

			if (Client == null)
				name += " (Offline)";
			else
				name += $" ({NetName})";

			return name;
		}

		// Tick function for communication between players and servers
		/*public void OnHeartbeat()
		{
		    if (PlayerForm != null)
		        PlayerForm.OnHeartbeat();
		}*/
	}
}
