/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Event: Adds Server Log message to Master Server Main Menu UI
 * See ViewModels->MainWindowViewModel.cs UI class for reference
 */

namespace MasterServer.Events
{
	public class LogMessageArgs
	{
		// Constructor: receives Server Log Message and Log ID as local variables
		public LogMessageArgs( string InMessage, string InID )
		{
			Message = InMessage;
			ID = InID;
		}

		// Get/Set Log ID
		public string ID { get; set; } = "0";

		// Reads Log Message
		public string Message { get; } // readonly
	}
}
