/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays Player information when prompted. In the Master Server Main Window, within the
 *	Active Players pane, double-click on a player who has connected to the server to view.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	Player Name (First and Last), Client ID (Computer Name)
 * GRID:		Player ID (Order of Internal Registration)
 *				Current Server 
 *				Current Lobby
 *				Status (Active, Inactive)
 *				Facilitator (Yes, No)
 * BUTTONS:		Current Log (New PlayerLogs Window), Edit (New EditRegisteredPlayer Window), Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels.Contracts;
using MasterServer.UI.Views;
using MvvmDialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.ViewModels
{
	public class ActivePlayerViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _Logger;
		private readonly IViewModelFactory _ViewModelFactory;
		private readonly IDialogService _DialogService;
		private readonly ServerData _ServerData;

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }
		public IAsyncRelayCommand ShowEditPlayerCommand { get; }
		public IAsyncRelayCommand ShowPlayerLogCommand { get; }

		// Constructor: initializes primary communication and UI data
		public ActivePlayerViewModel(
			ILogger InLogger,
			IViewModelFactory InVMFactory,
			IDialogService InDialogService,
			ServerData InServerData )
		{
			_Logger = InLogger;
			_ViewModelFactory = InVMFactory;
			_DialogService = InDialogService;
			_ServerData = InServerData;

			CloseWindowCommand = new AsyncRelayCommand<CustomWindow>( CloseWindow );
			ShowEditPlayerCommand = new AsyncRelayCommand<string>( ShowEditPlayerWindow );
			ShowPlayerLogCommand = new AsyncRelayCommand<string>( ShowPlayerLogWindow );
		}

		// Property: Get/Set User Client ID
		private string _ClientID;
		public string ClientID
		{
			get => _ClientID;
			set => SetProperty( ref _ClientID, value, nameof( ClientID ) );
		}

		// Property: Get/Set Player Name
		private string _PlayerName;
		public string PlayerName
		{
			get => _PlayerName;
			set => SetProperty( ref _PlayerName, value, nameof( PlayerName ) );
		}

		// Property: Get/Set Player ID
		private string _PlayerID;
		public string PlayerID
		{
			get => _PlayerID;
			set => SetProperty( ref _PlayerID, value, nameof( PlayerID ) );
		}

		// Property: Get/Set Current Server Name
		private string _CurrentServer;
		public string CurrentServer
		{
			get => _CurrentServer;
			set => SetProperty( ref _CurrentServer, value, nameof( CurrentServer ) );
		}

		// Property: Get/Set Current Lobby Name
		private string _CurrentLobby;
		public string CurrentLobby
		{
			get => _CurrentLobby;
			set => SetProperty( ref _CurrentLobby, value, nameof( CurrentLobby ) );
		}

		// Property: Get/Set Active Status
		private bool _bStatus;
		public bool Status
		{
			get => _bStatus;
			set => SetProperty( ref _bStatus, value, nameof( Status ) );
		}

		// Property: Get/Set whether user is a Facilitator
		private bool _bIsFacilitator;
		public bool IsFacilitator
		{
			get => _bIsFacilitator;
			set => SetProperty( ref _bIsFacilitator, value, nameof( IsFacilitator ) );
		}

		// Task: Allows CustomWindow to close like a traditional MetroWindow (only used by ActivePlayer to see Client ID).
		// See CustomWindow.cs for reference
		private async Task CloseWindow( CustomWindow InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Loads the Active Player's data, location, and status to be displayed
		public void LoadActivePlayerToView( string InPlayerID )
		{
			var PlayerRecs = _ServerData.GetPlayerRecs();
			var ViewPlayer = PlayerRecs.FirstOrDefault( x => x.PlayerUID.Equals( InPlayerID ) );

			if (ViewPlayer != null)
			{
				// Player Name and Client ID are displayed in the title bar
				ClientID = ViewPlayer.Client.ClientID.ToString();
				PlayerName = ViewPlayer.FullName;

				// Grid: First row displays PlayerID
				PlayerID = ViewPlayer.PlayerUID.ToString();

				// Grid: Placeholder strings for Second and Third rows
				CurrentServer = "None";
				CurrentLobby = "None";

				// Grid: Second and Third rows display Current Server and Current Lobby
				LobbyRec LobbyRecInstance = _ServerData.GetLobbies().FirstOrDefault( x => x.PlayerRecs.Contains( ViewPlayer ) );
				if (LobbyRecInstance != null)
				{
					CurrentLobby = LobbyRecInstance.Name;

					ServerRec ServerRecInstance = _ServerData.GetServer( LobbyRecInstance.ServerClientID );
					if (ServerRecInstance != null)
					{
						CurrentServer = ServerRecInstance.Name;
					}
				}

				// Grid: Fourth and Fifth rows display Player Status and whether the Player is a Facilitator
				Status = ViewPlayer.Status.Equals( "Active", StringComparison.OrdinalIgnoreCase );
				IsFacilitator = ViewPlayer.Role.Equals( "Facilitator", StringComparison.OrdinalIgnoreCase );
			}
		}

		// Task: When Edit button is pressed, displays new EditRegisteredPlayer window
		private async Task ShowEditPlayerWindow( string InPlayerID )
		{
			var RegisteredPlayerViewModel = (EditRegisteredPlayerViewModel)_ViewModelFactory.GetInstance( nameof( EditRegisteredPlayerViewModel ) );
			RegisteredPlayerViewModel.LoadRegisteredPlayerData( InPlayerID );
			_DialogService.Show( this, RegisteredPlayerViewModel );

			await Task.CompletedTask;
		}

		// Task: When Current Log button is pressed, displays new PlayerLogs window
		private async Task ShowPlayerLogWindow( string InPlayerID )
		{
			var PlayerViewModel = (PlayerLogsViewModel)_ViewModelFactory.GetInstance( nameof( PlayerLogsViewModel ) );
			PlayerViewModel.LoadRegisteredPlayerData( InPlayerID );
			_DialogService.Show( this, PlayerViewModel );

			await Task.CompletedTask;
		}
	}
}
