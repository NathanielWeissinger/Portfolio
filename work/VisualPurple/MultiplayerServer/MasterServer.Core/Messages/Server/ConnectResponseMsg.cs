/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a Connect message request.
 * Responds with states listed within the enum, along with ClientID
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// Connection Result message enum states
	public enum ConnectResult
	{
		eError = 0,
		eAccepted,
		eDenied,
		eCount // 3
	}

	// Respond back to the Client after a successful connection
	public class ConnectResponseMsg : MessageBase
	{
		// The Client ID assigned by the Server
		int ClientID;

		// The result code
		ConnectResult Result = ConnectResult.eError;

		// Constructor: Defines enum message type as this class
		public ConnectResponseMsg()
		{
			MsgType = EMessageType.eConnectResponse;
		}

		// Initializes ClientID as local variable and ConnectResult as local enum type
		public void Init( int InClientID, ConnectResult InConnectResult )
		{
			ClientID = InClientID;
			Result = InConnectResult;

			Console.WriteLine( $"ConnectResponseMsg::Init ClientID {ClientID} result {InConnectResult}" );
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