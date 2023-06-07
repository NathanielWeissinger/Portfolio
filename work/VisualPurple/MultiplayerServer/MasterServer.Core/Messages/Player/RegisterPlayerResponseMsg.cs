/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a RegisterPlayer message request.
 * Responds with states listed within the enum.
 */

using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	public class RegisterPlayerResponseMsg : MessageBase
	{
		// Register Player Result message enum states
		public enum RegisterPlayerResult
		{
			eError = 0,
			eAccepted,
			eDenied,
			eCount // 3
		}

		// The result code
		public RegisterPlayerResult Result = RegisterPlayerResult.eError;

		// Constructor: Defines enum message type as this class
		public RegisterPlayerResponseMsg()
		{
			MsgType = EMessageType.eRegisterPlayerResponse;
		}

		// Initializes RegisterPlayerResult as local enum type
		public void Init( RegisterPlayerResult InRegisterPlayerResult )
		{
			Result = InRegisterPlayerResult;

			Console.WriteLine( $"RegisterPlayerResponseMsg::Init result {InRegisterPlayerResult}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.WriteByte( (byte)Result );
		}
	}
}