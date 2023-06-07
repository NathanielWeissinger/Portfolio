/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds Player to UI list upon entering lobby
 * Unimplemented
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class AddPlayerToLobbyArgs
	{
		// Constructor: receives Player record as local variable
		public AddPlayerToLobbyArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
