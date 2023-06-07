/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a SwitchServers message request.
 * Responds with states listed within the enum, along with ClientID
 * and the ClientHandler.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Server to acknowledge the pending player join
	public class SwitchServerResponseMsg : MessageBase
	{
		// Switch Server Result enum states
		public enum SwitchServerResult
		{
			eError = 0,
			eAccepted,
			eDenied,
			eCount // 3
		}

		// The Player's Client ID
		int ClientID = 0;

		// The result code
		public SwitchServerResult Result = SwitchServerResult.eError;

		// Constructor: Defines enum message type as this class
		public SwitchServerResponseMsg()
		{
			MsgType = EMessageType.eSwitchServerResponse;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			ClientID = bytes.DeSerializeInt( ref index );
			Result = (SwitchServerResult)bytes.DeSerializeByte( ref index );

			Console.WriteLine( $"SwitchServerResponseMsg::Deserialize ClientID {ClientID} Result {Result}" );
		}

		// After deserialization, request to join a server is executed
		override public void Execute()
		{
			ServerData.JoinServer( ClientHandler, ClientID, Result );
		}
	}
}
