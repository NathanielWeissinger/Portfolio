/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Removes Player from server UI list
 * See ViewModels->StatusModalViewModel.cs UI class for reference
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class RemovePlayerArgs
	{
		// Constructor: receives Player record as local variable
		public RemovePlayerArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
