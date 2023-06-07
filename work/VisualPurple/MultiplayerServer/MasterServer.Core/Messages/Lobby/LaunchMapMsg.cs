/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a LaunchMap message request.
 * Responds with the name of the level, MapName.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// A Message from the Server to Open a specific Level
	public class LaunchMapMsg : MessageBase
	{
		// The Name of the Level to Open
		string MapName;

		// Constructor: Defines enum message type as this class
		public LaunchMapMsg()
		{
			MsgType = EMessageType.eLaunchMap;
		}

		// Initializes MapName as local string
		public void Init( string InMapName )
		{
			MapName = InMapName;

			Console.WriteLine( $"LaunchMapMsg::Init mapname {InMapName}" );
		}

		// Encrypts outgoing response message into a serialized byte stream
		override public void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			InMStream.SerializeString( MapName );
		}
	}
}
