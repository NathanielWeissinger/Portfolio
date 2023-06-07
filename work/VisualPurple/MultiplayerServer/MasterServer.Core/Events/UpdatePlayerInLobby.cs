/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Updates Player state if Player changes servers or disconnects from lobby
 * Unimplemented
 */

using MasterServer.Core.Models;

namespace MasterServer.Core.Events
{
	public class UpdatePlayerInLobbyArgs
	{
		// Constructor: receives Player record as local variable
		public UpdatePlayerInLobbyArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
