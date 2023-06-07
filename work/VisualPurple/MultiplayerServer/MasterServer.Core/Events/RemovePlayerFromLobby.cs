/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Removes Player from lobby UI list
 * Unimplemented
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class RemovePlayerFromLobbyArgs
	{
		// Constructor: receives Player record as local variable
		public RemovePlayerFromLobbyArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
