/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent every second to confirm the connection is valid
 */

using MasterServer.Core.Messages.Enums;

namespace MasterServer.Core.Messages
{
	public class HeartbeatMsg : MessageBase
	{
		// Constructor: Defines enum message type as this class
		public HeartbeatMsg()
		{
			MsgType = EMessageType.eHeartbeat;
		}

		// Perform some function after the message has been deserialized
		override public void Execute()
		{
			// Obtains current time
			ClientHandler.OnHeartbeat();

			//ServerData.OnHeartbeat( ClientHandler.ClientID );
		}
	}
}
