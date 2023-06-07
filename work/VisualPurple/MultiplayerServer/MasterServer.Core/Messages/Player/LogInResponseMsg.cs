/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a LogIn message request.
 * Responds with states listed within the enum, along with ClientID.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// The response to the Log In message
	public class LogInResponseMsg : MessageBase
	{
		// Log In Result message enum states
		public enum LogInResult
		{
			eError = 0,
			eNotFound,
			eAccepted,
			eDenied,
			eFaciliator,
			eActive, // 5
			eCount // 6
		}

		// The Player's Client ID
		int ClientID = 0;

		// The result code
		LogInResult Result = LogInResult.eError;

		// Constructor: Defines enum message type as this class
		public LogInResponseMsg()
		{
			MsgType = EMessageType.eLogInResponse;
		}

		// Initializes LogInResult as local enum type
		public void Init( int InClientID, LogInResult InLogInResult )
		{
			ClientID = InClientID;
			Result = InLogInResult;

			Console.WriteLine( $"LogInResponseMsg::Init clientid {InClientID} result {InLogInResult}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.SerializeInt( ClientID );
			InMStream.WriteByte( (byte)Result );
		}
	}
}
