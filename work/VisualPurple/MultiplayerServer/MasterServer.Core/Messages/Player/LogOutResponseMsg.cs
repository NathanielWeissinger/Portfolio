/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a LogOut message request.
 * Responds with states listed within the enum.
 */

using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Player client to log out of the system
	public class LogOutResponseMsg : MessageBase
	{
		// Log Out Result message enum states
		public enum LogOutResult
		{
			eError = 0,
			eNotFound,
			eAccepted,
			eCount // 3
		}

		// The result code
		public LogOutResult Result = LogOutResult.eError;

		// Constructor: Defines enum message type as this class
		public LogOutResponseMsg()
		{
			MsgType = EMessageType.eLogOutResponse;
		}

		// Initializes LogOutResult as local enum type
		public void Init( LogOutResult InLogOutResult )
		{
			Result = InLogOutResult;

			Console.WriteLine( $"LogOutResponseMsg::Init result {InLogOutResult}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.WriteByte( (byte)Result );
		}
	}
}
