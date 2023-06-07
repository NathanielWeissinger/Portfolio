/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Interface that stores the timestamp, server/lobby log message, and log ID.
 *	Receives data from MainWindowViewModel.cs UI class.
 *	Sends LogID to LobbyViewModel.cs and ServerViewModel.cs UI classes for log searching.
 * See MainWindow.xaml for visual reference.
 */

using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MasterServer.Core.Models
{
	public class ServerLog : ObservableObject
	{
		// Property: Get/Set Current Time
		private DateTime _timeStamp;
		public DateTime TimeStamp
		{
			get => _timeStamp;
			set => SetProperty( ref _timeStamp, value, nameof( TimeStamp ) );
		}

		// Property: Get/Set Server/Lobby Log Message
		private string _logMessage;
		public string LogMessage
		{
			get => _logMessage;
			set => SetProperty( ref _logMessage, value, nameof( LogMessage ) );
		}

		// Property: Get/Set Server/Lobby Log ID
		private string _logID;
		public string LogID
		{
			get => _logID;
			set => _logID = value;
		}
	}
}
