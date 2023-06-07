/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
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
		private readonly ILogger _logger;

		private const string dateInputFormat = "yyyyMMdd";
		private const string dateOutputFormat = "ddd MMM d yyyy";

		public IAsyncRelayCommand CloseWindowCommand { get; }

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

		private ObservableDictionary<string, string> _logList;
		public ObservableDictionary<string, string> LogList
		{
			get => _logList;
			set => SetProperty( ref _logList, value, nameof( LogList ) );
		}

		private string _selectedServerLogText;
		public string SelectedServerLogText
		{
			get => _selectedServerLogText;
			set => SetProperty( ref _selectedServerLogText, value, nameof( SelectedServerLogText ) );
		}

		public LogViewModel( ILogger logger )
		{
			_logger = logger;

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );

			LogList = new ObservableDictionary<string, string>();

			var fileList = Directory.GetFiles( @".\", "log-*" ).ToList();
			fileList.Sort();
			fileList.Reverse();

			if (fileList.Count > 0)
			{

				foreach (var file in fileList)
				{
					string strippedFile = Path.GetFileName( file );

					// Convert file path to date - e.g. Wed Dec 21 2022
					string splitFilePath = strippedFile.Split( '.' )[0].Split( '-' )[1];
					DateTime fileDate = DateTime.ParseExact( splitFilePath, dateInputFormat, CultureInfo.InvariantCulture ); // string in format yyyyMMdd


					string fileDateFormatted = fileDate.ToString( dateOutputFormat );

					LogList.Add( fileDateFormatted, strippedFile );
				}
				ShowSelectedItem = DateTime.ParseExact( Path.GetFileName( fileList[0] ).Split( '.' )[0].Split( '-' )[1], dateInputFormat, CultureInfo.InvariantCulture ).ToString( dateOutputFormat );
			}
		}

		private async Task CloseWindow( Window window )
		{
			window.Close();
			await Task.CompletedTask;
		}

		private async void UpdateTextLogDisplay()
		{
			string filePath = null;
			bool hasPath = LogList.TryGetValue( ShowSelectedItem, out filePath );


			//ERROR can't access, used by another process

			if (hasPath)
			{
				if (File.Exists( filePath ))
				{
					byte[] result;
					using (Stream r = new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ))
					{
						result = new byte[r.Length];
						await r.ReadAsync( result, 0, (int)r.Length );
					}
					SelectedServerLogText = System.Text.Encoding.UTF8.GetString( result );
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
