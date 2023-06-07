/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message sent in response to a ServerData message request.
 * Responds with serialized Ranks, Units, and Jobs Codes list.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using MasterServer.Core.Models;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	public class ServerDataResponseMsg : MessageBase
	{
		ServerDataModel m_ServerDataModel;

		// Constructor: Defines enum message type as this class
		public ServerDataResponseMsg()
		{
			MsgType = EMessageType.eServerDataResponse;
		}

		// Initializes ServerDataModel as local object
		public void Init( ServerDataModel InServerDataModel )
		{
			m_ServerDataModel = InServerDataModel;
		}

		// Encrypts outgoing response message into a serialized byte stream
		public override void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );
			m_ServerDataModel.Serialize( InMStream );
		}
	}
}
