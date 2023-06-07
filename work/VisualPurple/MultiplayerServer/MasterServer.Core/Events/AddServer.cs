/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds new Server to UI list upon server connection
 * See ViewModels->StatusModalViewModel.cs UI class for reference
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class AddServerArgs
	{
		// Constructor: receives Server record as local variable
		public AddServerArgs( ServerRec InServer ) { Server = InServer; }

		// Reads Server record
		public ServerRec Server { get; } // readonly
	}
}
