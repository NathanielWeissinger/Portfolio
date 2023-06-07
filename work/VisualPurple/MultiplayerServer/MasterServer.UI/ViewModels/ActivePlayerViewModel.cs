/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays Player information when prompted. In the Master Server Main Window, within the
 *	Active Players pane, double-click on a player who has connected to the server to view.
 * See Views->ActivePlayer.xaml and Modals->ActivePlayerModal.xaml for visual reference.
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
		private readonly ILogger _logger;
		private readonly IViewModelFactory _vmFactory;
		private readonly IDialogService _dialogService;
		private readonly ServerData _serverData;

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
			_logger = InLogger;
			_vmFactory = InVMFactory;
			_dialogService = InDialogService;
			_serverData = InServerData;

			CloseWindowCommand = new AsyncRelayCommand<CustomWindow>( CloseWindow );
			ShowEditPlayerCommand = new AsyncRelayCommand<string>( ShowEditPlayerWindow );
			ShowPlayerLogCommand = new AsyncRelayCommand<string>( ShowPlayerLogWindow );
		}

		// Property: Get/Set User Client ID
		private string _clientID;
		public string ClientID
		{
			get => _clientID;
			set => SetProperty( ref _clientID, value, nameof( ClientID ) );
		}

		// Property: Get/Set Player Name
		private string _playerName;
		public string PlayerName
		{
			get => _playerName;
			set => SetProperty( ref _playerName, value, nameof( PlayerName ) );
		}

		// Property: Get/Set Player ID
		private string _playerID;
		public string PlayerID
		{
			get => _playerID;
			set => SetProperty( ref _playerID, value, nameof( PlayerID ) );
		}

		// Property: Get/Set Current Server Name
		private string _currentServer;
		public string CurrentServer
		{
			get => _currentServer;
			set => SetProperty( ref _currentServer, value, nameof( CurrentServer ) );
		}

		// Property: Get/Set Current Lobby Name
		private string _currentLobby;
		public string CurrentLobby
		{
			get => _currentLobby;
			set => SetProperty( ref _currentLobby, value, nameof( CurrentLobby ) );
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
			var PlayerRecs = _serverData.GetPlayerRecs();
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
				LobbyRec LobbyRecInstance = _serverData.GetLobbies().FirstOrDefault( x => x.PlayerRecs.Contains( ViewPlayer ) );
				if (LobbyRecInstance != null)
				{
					CurrentLobby = LobbyRecInstance.Name;

					ServerRec ServerRecInstance = _serverData.GetServer( LobbyRecInstance.ServerClientID );
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
			var RegisteredPlayerVMInstance = (EditRegisteredPlayerViewModel)_vmFactory.GetInstance( nameof( EditRegisteredPlayerViewModel ) );
			RegisteredPlayerVMInstance.LoadRegisteredPlayerData( InPlayerID );
			_dialogService.Show( this, RegisteredPlayerVMInstance );

			await Task.CompletedTask;
		}

		// Task: When Current Log button is pressed, displays new PlayerLogs window
		private async Task ShowPlayerLogWindow( string InPlayerID )
		{
			var PlayerVMInstance = (PlayerLogsViewModel)_vmFactory.GetInstance( nameof( PlayerLogsViewModel ) );
			PlayerVMInstance.LoadRegisteredPlayerData( InPlayerID );
			_dialogService.Show( this, PlayerVMInstance );

			await Task.CompletedTask;
		}
	}
}
