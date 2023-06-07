﻿/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays Player Log files when prompted. Within the Active Player Window
 *	while viewing a player's information, click the Current Log button to view.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	"Player Logs"
 * GRID:		Date Selection Dropdown ComboBox
 *				Log Output Pane
 *				"User: ", Player Name
 * BUTTONS:		Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.ViewModels
{
	public class PlayerLogsViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _Logger;
		private readonly ServerData _ServerData;

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }

		// Constructor: initializes primary communication and UI data
		public PlayerLogsViewModel(
			ILogger InLogger,
			ServerData InServerData )
		{
			_Logger = InLogger;
			_ServerData = InServerData;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );
		}

		// Property: Get/Set whether to Show or Hide selected item
		private string _ShowSelectedItem;
		public string ShowSelectedItem
		{
			get => _ShowSelectedItem;
			set
			{
				SetProperty( ref _ShowSelectedItem, value, nameof( ShowSelectedItem ) );
				UpdateTextLogDisplay();
			}
		}

		// Property: Get/Set Log List
		private ObservableCollection<string> _LogList;
		public ObservableCollection<string> LogList
		{
			get => _LogList;
			set => SetProperty( ref _LogList, value, nameof( LogList ) );
		}

		// Property: Get/Set Log Text of selected Player
		private string _SelectedPlayerLogText;
		public string SelectedPlayerLogText
		{
			get => _SelectedPlayerLogText;
			set => SetProperty( ref _SelectedPlayerLogText, value, nameof( SelectedPlayerLogText ) );
		}

		// Property: Get/Set Player Name
		private string _PlayerName;
		public string PlayerName
		{
			get => _PlayerName;
			set => SetProperty( ref _PlayerName, value, nameof( PlayerName ) );
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Reloads Player Log File from text file to program
		private void UpdateTextLogDisplay()
		{
			/* TODO:
             * 
             * Change SelectedPlayerLogText to use the text from the player log .txt file
             * that coresponds to the ShowSelectedItem date.
             */
		}

		// Loads Registered Player data and sorts its respective Server Log files by date
		public void LoadRegisteredPlayerData( string InPlayerUID )
		{
			var PlayerRecs = _ServerData.GetPlayerRecs();
			var ViewPlayer = PlayerRecs.FirstOrDefault( x => x.PlayerUID.Equals( InPlayerUID ) );

			PlayerName = ViewPlayer.FullName;

			/* TODO:
             * 
             * Get list of Player Log .txt files and sort by date
             * 
             * Set ShowSelectedItem to the most recent ServerLog .txt file
             */
		}
	}
}
