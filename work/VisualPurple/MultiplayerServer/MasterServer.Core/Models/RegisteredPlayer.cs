/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Stores a player's information, loaded from playerdata.json. Displays on UI.
 *	Receives data from RegisteredPlayersViewModel.cs UI class.
 * See ViewModels->RegisteredPlayers.xaml for visual reference.
 */

using CommunityToolkit.Mvvm.ComponentModel;

namespace MasterServer.Core.Models
{
	public class RegisteredPlayer : ObservableObject
	{
		// Property: Get/Set Player ID
		private int _id = 0;
		public int ID
		{
			get => _id;
			set => SetProperty( ref _id, value, nameof( ID ) );
		}

		// Property: Get/Set Player Name
		private string _name = "Test";
		public string Name
		{
			get => _name;
			set => SetProperty( ref _name, value, nameof( Name ) );
		}

		// Property: Get/Set Player Rank
		private string _rank = "Test";
		public string Rank
		{
			get => _rank;
			set => SetProperty( ref _rank, value, nameof( Rank ) );
		}

		// Property: Get/Set Player Unit
		private string _unit = "Test";
		public string Unit
		{
			get => _unit;
			set => SetProperty( ref _unit, value, nameof( Unit ) );
		}

		// Property: Get/Set Player Job Code
		private string _jobCode = "Test";
		public string JobCode
		{
			get => _jobCode;
			set => SetProperty( ref _jobCode, value, nameof( JobCode ) );
		}

		// Property: Get/Set whether Player is a Facilitator
		private bool _bIsFacilitator;
		public bool IsFacilitator
		{
			get => _bIsFacilitator;
			set => SetProperty( ref _bIsFacilitator, value, nameof( IsFacilitator ) );
		}

		// Property: Get/Set Player Active Status
		private bool _bIsActive;
		public bool IsActive
		{
			get => _bIsActive;
			set => SetProperty( ref _bIsActive, value, nameof( IsActive ) );
		}
	}
}
