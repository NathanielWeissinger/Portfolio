/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays and allows the editing of Player information when prompted. Within the Active Player Window
 *	while viewing a player's information, click the Edit button to view.
 *	
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	"EDIT PLAYER"
 * GRID:		Name (Editable Player Name Textbox)
 *				Player ID (Uneditable PlayerID Textbox), Logs Button (New PlayerLogs Window)
 *				Gender (Editable Gender Textbox)
 *				SSN (Editable SSN Textbox)
 *				Password (Editable Password Textbox)
 *				Unit (Unit Dropdown ComboBox)
 *				Rank (Rank Dropdown ComboBox)
 *				Job Code (Code Dropdown ComboBox)
 *				Status (Active, Inactive ToggleSwitch)
 *				Facilitator (Yes, No ToggleSwitch)
 * BUTTONS:		Delete, Reset, Save, Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels.Contracts;
using MasterServer.UI.Views;
using MvvmDialogs;
using Serilog;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MasterServer.UI.ViewModels
{
	public class EditRegisteredPlayerViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _Logger;
		private readonly IViewModelFactory _ViewModelFactory;
		private readonly IDialogService _DialogService;
		private readonly ServerData _ServerData;

		private const string _ServerDataFilePath = "serverdata.json";
		private const string _PlayerDataFilePath = "playerdata.json";

		// Commands
		public IAsyncRelayCommand PlayerLogsCommand { get; }
		public IAsyncRelayCommand CloseWindowCommand { get; }
		public IAsyncRelayCommand DeletePlayerCommand { get; }
		public IAsyncRelayCommand ResetPlayerCommand { get; }
		public IAsyncRelayCommand SavePlayerCommand { get; }

		// Constructor: initializes primary communication, button commands, and UI data
		public EditRegisteredPlayerViewModel( ILogger InLogger,
			IViewModelFactory InViewModelFactory,
			IDialogService InDialogService,
			ServerData InServerData )
		{
			_Logger = InLogger;

			PlayerLogsCommand = new AsyncRelayCommand<string>( ShowPlayerLogsModal );
			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );
			DeletePlayerCommand = new AsyncRelayCommand<Window>( DeletePlayerData );
			ResetPlayerCommand = new AsyncRelayCommand( ResetPlayerData );
			SavePlayerCommand = new AsyncRelayCommand( SavePlayerData );

			_ViewModelFactory = InViewModelFactory;
			_DialogService = InDialogService;
			_ServerData = InServerData;

			OnLoad = new AsyncRelayCommand( OnLoading );
		}

		// Command: Get/Set Asynchronous Relay Load Command
		private IAsyncRelayCommand _OnLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _OnLoad;
			set => SetProperty( ref _OnLoad, value, nameof( OnLoad ) );
		}

		// Property: Get/Set Registered Players ViewModel
		private RegisteredPlayersViewModel _RegisteredPlayersVM;
		public RegisteredPlayersViewModel RegisteredPlayersVM
		{
			get => _RegisteredPlayersVM;
			set => _RegisteredPlayersVM = value;
		}

		// Property: Get/Set Player Data from registered player data record
		private PlayerRec _RegisteredPlayerData;
		public PlayerRec RegisteredPlayerData
		{
			get => _RegisteredPlayerData;
			set => _RegisteredPlayerData = value;
		}

		// Property: Get/Set List of Jobs for Dropdown ComboBox
		private List<string> _JobList;
		public List<string> JobList
		{
			get => _JobList;
			set => SetProperty( ref _JobList, value, nameof( JobList ) );
		}

		// Property: Get/Set List of Units for Dropdown ComboBox
		private List<string> _UnitList;
		public List<string> UnitList
		{
			get => _UnitList;
			set => SetProperty( ref _UnitList, value, nameof( UnitList ) );
		}

		// Property: Get/Set List of Ranks for Dropdown ComboBox
		private List<string> _RankList;
		public List<string> RankList
		{
			get => _RankList;
			set => SetProperty( ref _RankList, value, nameof( RankList ) );
		}

		// Property: Get/Set Player full First and Last Name
		private string _PlayerFullName;
		public string PlayerFullName
		{
			get => _PlayerFullName;
			set => SetProperty( ref _PlayerFullName, value, nameof( PlayerFullName ) );
		}

		// Property: Get/Set Player ID
		private int _PlayerID;
		public int PlayerID
		{
			get => _PlayerID;
			set => SetProperty( ref _PlayerID, value, nameof( PlayerID ) );
		}

		// Property: Get/Set Player Unit
		private string _PlayerUnit;
		public string PlayerUnit
		{
			get => _PlayerUnit;
			set => SetProperty( ref _PlayerUnit, value, nameof( PlayerUnit ) );
		}

		// Property: Get/Set Player Rank
		private string _PlayerRank;
		public string PlayerRank
		{
			get => _PlayerRank;
			set => SetProperty( ref _PlayerRank, value, nameof( PlayerRank ) );
		}

		// Property: Get/Set Player Job Code
		private string _PlayerJobCode;
		public string PlayerJobCode
		{
			get => _PlayerJobCode;
			set => SetProperty( ref _PlayerJobCode, value, nameof( PlayerJobCode ) );
		}

		// Property: Get/Set Player Active Status
		private bool _PlayerStatus;
		public bool PlayerStatus
		{
			get => _PlayerStatus;
			set => SetProperty( ref _PlayerStatus, value, nameof( PlayerStatus ) );
		}

		// Property: Get/Set whether user is a Facilitator
		private bool _PlayerIsFacilitator;
		public bool PlayerIsFacilitator
		{
			get => _PlayerIsFacilitator;
			set => SetProperty( ref _PlayerIsFacilitator, value, nameof( PlayerIsFacilitator ) );
		}

		// Property: Get/Set Player Social Security Number
		private int _PlayerSSN;
		public int PlayerSSN
		{
			get => _PlayerSSN;
			set => SetProperty( ref _PlayerSSN, value, nameof( PlayerSSN ) );
		}

		// Property: Get/Set Player Gender
		private string _PlayerGender;
		public string PlayerGender
		{
			get => _PlayerGender;
			set => SetProperty( ref _PlayerGender, value, nameof( PlayerGender ) );
		}

		// Property: Get/Set Player Password
		private string _PlayerPassword;
		public string PlayerPassword
		{
			get => _PlayerPassword;
			set => SetProperty( ref _PlayerPassword, value, nameof( PlayerPassword ) );
		}

		// Task: Loads data from server and places predefined values into dropdown ComboBoxes
		private ServerDataModel _ServerDataModel;
		private async Task OnLoading()
		{
			LoadServerData( _ServerDataFilePath );
			PopulateEditableDropdowns();
			await Task.CompletedTask;
		}

		// Reads serverdata.json file to obtain server data
		public void LoadServerData( string InFilePath )
		{
			if (File.Exists( InFilePath ))
			{
				using (StreamReader SReader = new StreamReader( InFilePath ))
				{
					string Json = SReader.ReadToEnd();
					_ServerDataModel = JsonConvert.DeserializeObject<ServerDataModel>( Json );
				}
			}
		}

		// Places the lists of Units, Ranks, and Job Codes into their respective dropdown ComboBoxes
		private void PopulateEditableDropdowns()
		{
			UnitList = _ServerDataModel.Units.ToList();
			RankList = _ServerDataModel.Ranks.ToList();
			JobList = _ServerDataModel.Jobs.ToList();
		}

		// Task: When Logs button is pressed, displays new PlayerLogs window
		private async Task ShowPlayerLogsModal( string InPlayerID )
		{
			var LogsViewModel = (PlayerLogsViewModel)_ViewModelFactory.GetInstance( nameof( PlayerLogsViewModel ) );
			LogsViewModel.LoadRegisteredPlayerData( InPlayerID );
			_DialogService.Show( this, LogsViewModel );
			await Task.CompletedTask;
		}

		// Overwrites current Textboxes, ToggleSwitches, and selected dropdown ComboBox values
		// and calls ResetPlayerData function
		public async void LoadRegisteredPlayerData( string InPlayerID )
		{
			var RegPlayerRecs = _ServerData.GetPlayerRecs();
			var RegViewPlayer = RegPlayerRecs.FirstOrDefault( x => x.PlayerUID.Equals( InPlayerID ) );
			RegisteredPlayerData = RegViewPlayer;
			await ResetPlayerData();
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Task: Deletes Player record based on Player ID
		private async Task DeletePlayerData( Window InWindow )
		{
			List<PlayerRec> PlayerDeletedList = PrepareEditPlayerRecordsList();
			// searches ID, and if ID exists, deletes player record
			PlayerRec PlayerToDelete = PlayerDeletedList.FirstOrDefault( r => int.Parse( r.PlayerUID ) == PlayerID );
			if (PlayerToDelete != null)
			{
				PlayerDeletedList.Remove( PlayerToDelete );
				string Json = JsonConvert.SerializeObject( PlayerDeletedList, Formatting.Indented );

				File.WriteAllText( _PlayerDataFilePath, Json );
			}

			// Reloads player registry to program
			if (RegisteredPlayersVM != null)
			{
				await RegisteredPlayersVM.OnLoading();
			}

			// Closes window
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Task: Replaces Textboxes,dropdown ComboBoxes, and ToggleSwitches with original Player data values
		private async Task ResetPlayerData()
		{
			PlayerFullName = RegisteredPlayerData.FullName;
			PlayerID = int.Parse( RegisteredPlayerData.PlayerUID );
			PlayerUnit = RegisteredPlayerData.Unit;
			PlayerRank = RegisteredPlayerData.Rank;
			PlayerJobCode = RegisteredPlayerData.Job;
			PlayerStatus = RegisteredPlayerData.Status.Equals( "Active" );
			PlayerIsFacilitator = RegisteredPlayerData.Role.Equals( "Facilitator" );
			PlayerGender = RegisteredPlayerData.Gender;
			PlayerSSN = int.Parse( RegisteredPlayerData.SSN );
			PlayerPassword = RegisteredPlayerData.Password;

			await Task.CompletedTask;
		}

		// Task: Saves newly entered data to playerdata.json file
		private async Task SavePlayerData()
		{
			List<PlayerRec> SaveList = PrepareEditPlayerRecordsList();
			
			PlayerRec PlayerToUpdate = SaveList.FirstOrDefault( r => int.Parse( r.PlayerUID ) == PlayerID );
			if (PlayerToUpdate != null)
			{
				int PlayerToUpdateIndex = SaveList.IndexOf( PlayerToUpdate );

				// Saves values to variables
				PlayerToUpdate.Gender = PlayerGender;
				PlayerToUpdate.SSN = PlayerSSN.ToString();
				PlayerToUpdate.Password = PlayerPassword;
				PlayerToUpdate.Unit = PlayerUnit;
				PlayerToUpdate.Rank = PlayerRank;
				PlayerToUpdate.Job = PlayerJobCode;
				PlayerToUpdate.Status = PlayerStatus ? "Active" : "Inactive";
				PlayerToUpdate.Role = PlayerIsFacilitator ? "Facilitator" : "Player";

				// Split Name into First and Last Name
				var SplitName = PlayerFullName.Split( ' ' );
				PlayerToUpdate.FirstName = SplitName[0];
				string LastName = "";
				for (int i = 1; i < SplitName.Length; i++)
				{
					LastName += SplitName[i].Trim();
					if (i != SplitName.Length - 1)
					{
						LastName += " ";
					}
				}
				PlayerToUpdate.LastName = LastName;

				SaveList.RemoveAt( PlayerToUpdateIndex );
				SaveList.Insert( PlayerToUpdateIndex, PlayerToUpdate );
			}

			// Serializes and writes data to playerdata.json file
			string Json = JsonConvert.SerializeObject( SaveList, Formatting.Indented );
			File.WriteAllText( _PlayerDataFilePath, Json );

			// Reloads player registry to program
			if (RegisteredPlayersVM != null)
			{
				await RegisteredPlayersVM.OnLoading();
			}

			await Task.CompletedTask;
		}

		// Receives Player Records List by deserializing and reading playerdata.json file
		private List<PlayerRec> PrepareEditPlayerRecordsList()
		{
			List<PlayerRec> PlayerRecList = new List<PlayerRec>();
			// Load in existing player record list
			if (File.Exists( _PlayerDataFilePath ))
			{
				using (StreamReader SReader = new StreamReader( _PlayerDataFilePath ))
				{
					string SPlayers = SReader.ReadToEnd();
					PlayerRecList = JsonConvert.DeserializeObject<List<PlayerRec>>( SPlayers );
				}
			}
			else
			{
				PlayerRecList = null;
			}

			return PlayerRecList;
		}
	}
}
