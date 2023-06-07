/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds Connection count to UI for each active client (counts everything,
 *	including players, servers, and lobbies)
 * This event still needs to be set up in ServerData.cs.
 * See ViewModels->ServerStatusBarViewModel.cs UI class for reference
 */

namespace MasterServer.Events
{
	public class ConnectionCountArgs
	{
		// Constructor: receives Connection count as local variable
		public ConnectionCountArgs( int InCount ) { Count = InCount; }

		// Reads Connection count
		public int Count { get; } // readonly
	}
}
