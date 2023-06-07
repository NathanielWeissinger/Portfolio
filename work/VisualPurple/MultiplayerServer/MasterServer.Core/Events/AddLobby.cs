/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds new Lobby to UI list upon new Lobby creation in UE
 * See ViewModels->StatusModalViewModel.cs UI class for reference
 */

using MasterServer.Core.Models;

namespace MasterServer.Events
{
	public class AddLobbyArgs
	{
		// Constructor: receives Lobby record as local variable
		public AddLobbyArgs( LobbyRec InLobby ) { Lobby = InLobby; }

		// Reads Lobby record
		public LobbyRec Lobby { get; } // readonly
	}
}
