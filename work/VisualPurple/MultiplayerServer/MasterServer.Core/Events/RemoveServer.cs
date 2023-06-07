/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Remove Server from server UI list
 * Unimplemented
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class RemoveServerArgs
	{
		// Constructor: receives Server record as local variable
		public RemoveServerArgs( ServerRec InServer ) { Server = InServer; }

		// Reads Server record
		public ServerRec Server { get; } // readonly
	}
}
