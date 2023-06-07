/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request downloading the lists of data used
 *	for player registration: Ranks, Units, and Job Codes.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	public class ServerDataMsg : MessageBase
	{
		// Constructor: Defines enum message type as this class
		public ServerDataMsg()
		{
			MsgType = EMessageType.eServerData;
		}

		// After deserialization, request for server data is executed
		public override void Execute()
		{
			ServerData.RequestServerData( ClientHandler );
		}
	}
}
