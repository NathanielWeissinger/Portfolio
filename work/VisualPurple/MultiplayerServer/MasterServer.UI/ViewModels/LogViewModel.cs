/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays Server Logs by date when prompted.
 *	At the top of the Master Server Main Menu, under View, click the Logs button to view.
 * See Views->Log.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	"Server Logs"
 * GRID:		Date Selection Dropdown SplitButton
 *				Pane Title Bar: [Selected Date]
 *				Log Output Pane
 * BUTTONS:		Close
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using MasterServer.UI.Helpers;
using System.IO;
using System.Linq;
using MasterServer.Core.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MasterServer.UI.ViewModels
{
	public class LogViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _logger;

		private const string DateInputFormat = "yyyyMMdd";
		private const string DateOutputFormat = "ddd MMM d yyyy";

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }

		// Constructor: initializes primary communication and UI data
		public LogViewModel( ILogger InLogger )
		{
			_logger = InLogger;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			LogList = new ObservableDictionary<string, string>();

			var FileList = Directory.GetFiles( @".\", "log-*" ).ToList();
			FileList.Sort();
			FileList.Reverse();

			// Sets the Dropdown SplitButton's log file dates
			if (FileList.Count > 0)
			{
				foreach (var file in FileList)
				{
					string StrippedFile = Path.GetFileName( file );

					// Convert file path to date - e.g. Wed Dec 21 2022
					string SplitFilePath = StrippedFile.Split( '.' )[0].Split( '-' )[1];
					DateTime FileDate = DateTime.ParseExact( SplitFilePath, DateInputFormat, CultureInfo.InvariantCulture ); // string in format yyyyMMdd

					string FileDateFormatted = FileDate.ToString( DateOutputFormat );

					LogList.Add( FileDateFormatted, StrippedFile );
				}
				ShowSelectedItem = DateTime.ParseExact( Path.GetFileName( FileList[0] ).Split( '.' )[0].Split( '-' )[1], DateInputFormat, CultureInfo.InvariantCulture ).ToString( DateOutputFormat );
			}
		}

		// Property: Displays the Dropdown SplitButton's log file dates
		private string _showSelectedItem;
		public string ShowSelectedItem
		{
			get => _showSelectedItem;
			set
			{
				SetProperty( ref _showSelectedItem, value, nameof( ShowSelectedItem ) );
				UpdateTextLogDisplay();
			}
		}

		// Property: Get/Set List of Log files
		private ObservableDictionary<string, string> _logList;
		public ObservableDictionary<string, string> LogList
		{
			get => _logList;
			set => SetProperty( ref _logList, value, nameof( LogList ) );
		}

		// Property: Get/Set Text within the selected log file
		private string _selectedServerLogText;
		public string SelectedServerLogText
		{
			get => _selectedServerLogText;
			set => SetProperty( ref _selectedServerLogText, value, nameof( SelectedServerLogText ) );
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Refreshes log text after rereading filepath
		private async void UpdateTextLogDisplay()
		{
			string FilePath = null;
			bool bHasPath = LogList.TryGetValue( ShowSelectedItem, out FilePath );

			//ERROR can't access, used by another process
			if (bHasPath)
			{
				if (File.Exists( FilePath ))
				{
					byte[] ReadResult;
					using (Stream SReader = new FileStream( FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ))
					{
						ReadResult = new byte[SReader.Length];
						await SReader.ReadAsync( ReadResult, 0, (int)SReader.Length );
					}
					SelectedServerLogText = System.Text.Encoding.UTF8.GetString( ReadResult );
				}
			}

			/* TODO:
             * 
             * Change SelectedServerLogText to use the text from the server log .txt file
             * that coresponds to the ShowSelectedItem date.
             */
		}
	}
}
