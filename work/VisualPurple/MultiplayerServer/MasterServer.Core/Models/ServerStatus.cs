/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Stores the numbers of connections, servers, lobbies, and players currently
 *	connected to the server. Displays on UI.
 *	Receives data from ServerStatusBarViewModel.cs UI class.
 * See MainWindow.xaml and CustomControls->ServerBarStatusControl.xaml for visual reference.
 */

using CommunityToolkit.Mvvm.ComponentModel;

namespace MasterServer.Core.Models
{
	public class ServerStatus : ObservableObject
	{
		// Property: Get/Set Number of Active Connections
		private int _activeConnections = 0;
		public int ActiveConnections
		{
			get => _activeConnections;
			set => SetProperty( ref _activeConnections, value, nameof( ActiveConnections ) );
		}

		// Property: Get/Set Number of Active Players
		private int _activePlayers = 0;
		public int ActivePlayers
		{
			get => _activePlayers;
			set => SetProperty( ref _activePlayers, value, nameof( ActivePlayers ) );
		}

		// Property: Get/Set Number of Active Lobbies
		private int _activeLobbies = 0;
		public int ActiveLobbies
		{
			get => _activeLobbies;
			set => SetProperty( ref _activeLobbies, value, nameof( ActiveLobbies ) );
		}

		// Property: Get/Set Number of Active Servers
		private int _activeServers = 0;
		public int ActiveServers
		{
			get => _activeServers;
			set => SetProperty( ref _activeServers, value, nameof( ActiveServers ) );
		}
	}
}
