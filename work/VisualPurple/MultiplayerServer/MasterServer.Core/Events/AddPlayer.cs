/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds new Player to UI list upon registration or login to server
 * See ViewModels->StatusModalViewModel.cs UI class for reference
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class AddPlayerArgs
	{
		// Constructor: receives Player record as local variable
		public AddPlayerArgs( PlayerRec InPlayer ) { Player = InPlayer; }

		// Reads Player record
		public PlayerRec Player { get; } // readonly
	}
}
