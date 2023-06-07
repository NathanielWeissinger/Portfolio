/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays and allows the editing of Player information when prompted. Within the Active Player Window
 *	while viewing a player's information, click the Edit button to view.
 * See Views->EditRegisteredPlayer.xaml for visual reference.
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
using System.Text;
using System.Security.Policy;
using System;

namespace MasterServer.UI.ViewModels
{
	public class EditRegisteredPlayerViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _logger;
		private readonly IViewModelFactory _vmFactory;
		private readonly IDialogService _dialogService;
		private readonly ServerData _serverData;

		private const string _serverDataFilePath = "serverdata.json";
		private const string _playerDataFilePath = "playerdata.json";

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
			_logger = InLogger;

			PlayerLogsCommand = new AsyncRelayCommand<string>( ShowPlayerLogsModal );
			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );
			DeletePlayerCommand = new AsyncRelayCommand<Window>( DeletePlayerData );
			ResetPlayerCommand = new AsyncRelayCommand( ResetPlayerData );
			SavePlayerCommand = new AsyncRelayCommand( SavePlayerData );

			_vmFactory = InViewModelFactory;
			_dialogService = InDialogService;
			_serverData = InServerData;

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
		private RegisteredPlayersViewModel _registeredPlayersVM;
		public RegisteredPlayersViewModel RegisteredPlayersVM
		{
			get => _registeredPlayersVM;
			set => _registeredPlayersVM = value;
		}

		// Property: Get/Set Player Data from registered player data record
		private PlayerRec _registeredPlayerData;
		public PlayerRec RegisteredPlayerData
		{
			get => _registeredPlayerData;
			set => _registeredPlayerData = value;
		}

		// Property: Get/Set List of Jobs for Dropdown ComboBox
		private List<string> _jobList;
		public List<string> JobList
		{
			get => _jobList;
			set => SetProperty( ref _jobList, value, nameof( JobList ) );
		}

		// Property: Get/Set List of Units for Dropdown ComboBox
		private List<string> _unitList;
		public List<string> UnitList
		{
			get => _unitList;
			set => SetProperty( ref _unitList, value, nameof( UnitList ) );
		}

		// Property: Get/Set List of Ranks for Dropdown ComboBox
		private List<string> _rankList;
		public List<string> RankList
		{
			get => _rankList;
			set => SetProperty( ref _rankList, value, nameof( RankList ) );
		}

		// Property: Get/Set Player full First and Last Name
		private string _playerFullName;
		public string PlayerFullName
		{
			get => _playerFullName;
			set => SetProperty( ref _playerFullName, value, nameof( PlayerFullName ) );
		}

		// Property: Get/Set Player ID
		private int _playerID;
		public int PlayerID
		{
			get => _playerID;
			set => SetProperty( ref _playerID, value, nameof( PlayerID ) );
		}

		// Property: Get/Set Player Unit
		private string _playerUnit;
		public string PlayerUnit
		{
			get => _playerUnit;
			set => SetProperty( ref _playerUnit, value, nameof( PlayerUnit ) );
		}

		// Property: Get/Set Player Rank
		private string _playerRank;
		public string PlayerRank
		{
			get => _playerRank;
			set => SetProperty( ref _playerRank, value, nameof( PlayerRank ) );
		}

		// Property: Get/Set Player Job Code
		private string _playerJobCode;
		public string PlayerJobCode
		{
			get => _playerJobCode;
			set => SetProperty( ref _playerJobCode, value, nameof( PlayerJobCode ) );
		}

		// Property: Get/Set Player Active Status
		private bool _playerStatus;
		public bool PlayerStatus
		{
			get => _playerStatus;
			set => SetProperty( ref _playerStatus, value, nameof( PlayerStatus ) );
		}

		// Property: Get/Set whether user is a Facilitator
		private bool _playerIsFacilitator;
		public bool PlayerIsFacilitator
		{
			get => _playerIsFacilitator;
			set => SetProperty( ref _playerIsFacilitator, value, nameof( PlayerIsFacilitator ) );
		}

		// Property: Get/Set Player Social Security Number
		private int _playerSSN;
		public int PlayerSSN
		{
			get => _playerSSN;
			set => SetProperty( ref _playerSSN, value, nameof( PlayerSSN ) );
		}

		// Property: Get/Set Player Gender
		private string _playerGender;
		public string PlayerGender
		{
			get => _playerGender;
			set => SetProperty( ref _playerGender, value, nameof( PlayerGender ) );
		}

		// Property: Get/Set Player Password
		private string _playerPassword;
		public string PlayerPassword
		{
			get => _playerPassword;
			set => SetProperty( ref _playerPassword, value, nameof( PlayerPassword ) );
		}

		// Task: Loads data from server and places predefined values into dropdown ComboBoxes
		private ServerDataModel _serverDataModel;
		private async Task OnLoading()
		{
			LoadServerData( _serverDataFilePath );
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
					_serverDataModel = JsonConvert.DeserializeObject<ServerDataModel>( Json );
				}
			}
		}

		// Places the lists of Units, Ranks, and Job Codes into their respective dropdown ComboBoxes
		private void PopulateEditableDropdowns()
		{
			UnitList = _serverDataModel.Units.ToList();
			RankList = _serverDataModel.Ranks.ToList();
			JobList = _serverDataModel.Jobs.ToList();
		}

		// Task: When Logs button is pressed, displays new PlayerLogs window
		private async Task ShowPlayerLogsModal( string InPlayerID )
		{
			var LogsVMInstance = (PlayerLogsViewModel)_vmFactory.GetInstance( nameof( PlayerLogsViewModel ) );
			LogsVMInstance.LoadRegisteredPlayerData( InPlayerID );
			_dialogService.Show( this, LogsVMInstance );
			await Task.CompletedTask;
		}

		// Overwrites current Textboxes, ToggleSwitches, and selected dropdown ComboBox values
		// and calls ResetPlayerData function
		public async void LoadRegisteredPlayerData( string InPlayerID )
		{
			var RegPlayerRecs = _serverData.GetPlayerRecs();
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

				File.WriteAllText( _playerDataFilePath, Json );
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

		// Task: Replaces Textboxes, dropdown ComboBoxes, and ToggleSwitches with original Player data values
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
				PlayerToUpdate.Password = CreateMD5(PlayerPassword);
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
			File.WriteAllText( _playerDataFilePath, Json );

			// Reloads player registry to program
			if (RegisteredPlayersVM != null)
			{
				await RegisteredPlayersVM.OnLoading();
			}

			await Task.CompletedTask;
		}

		// Encrypts newly entered password into MD5 Hash
		public static string CreateMD5( string InPassword )
		{
			// Use input string to calculate MD5 hash
			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes( InPassword );
				byte[] hashBytes = md5.ComputeHash( inputBytes );

				//return Convert.ToHexString( hashBytes ); // .NET 5 +

				//Convert the byte array to hexadecimal string prior to .NET 5
				StringBuilder sb = new System.Text.StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append( hashBytes[i].ToString( "X2" ) );
				}
				return sb.ToString().ToLower();
			}
		}

		// Receives Player Records List by deserializing and reading playerdata.json file
		private List<PlayerRec> PrepareEditPlayerRecordsList()
		{
			List<PlayerRec> PlayerRecList = new List<PlayerRec>();
			// Load in existing player record list
			if (File.Exists( _playerDataFilePath ))
			{
				using (StreamReader SReader = new StreamReader( _playerDataFilePath ))
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
