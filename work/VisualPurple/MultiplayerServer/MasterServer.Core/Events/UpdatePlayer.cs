/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Updates Player if Player already exists, and another Player instance
 *	is created upon login.
 * Unimplimented
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class UpdatePlayerArgs
	{
		// Constructor: receives Player record as local variable
		public UpdatePlayerArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
