/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Interface that stores record of the possible Ranks, Units, and Jobs kept by the server.
 */

using MasterServer.Core.Helpers;
using System.Collections.Generic;
using System.IO;

namespace MasterServer.Core.Models
{
	public class ServerDataModel
	{
		// The list of ranks
		public List<string> Ranks = new List<string>();

		// The list of units
		public List<string> Units = new List<string>();

		// The list of jobs
		public List<string> Jobs = new List<string>();

		// Serializes Counts and Names of each of the three lists for storage
		public void Serialize( MemoryStream InMStream )
		{
			InMStream.SerializeInt( Ranks.Count );
			foreach (string r in Ranks)
			{
				InMStream.SerializeString( r );
			}

			InMStream.SerializeInt( Units.Count );
			foreach (string u in Units)
			{
				InMStream.SerializeString( u );
			}

			InMStream.SerializeInt( Jobs.Count );
			foreach (string j in Jobs)
			{
				InMStream.SerializeString( j );
			}
		}

		// Clears lists, and adds default Rank and Unit items
		public void Test()
		{
			Ranks.Clear();
			Units.Clear();
			Jobs.Clear();

			Ranks.Add( "Private" );
			Units.Add( "AF" );
		}
	}
}
