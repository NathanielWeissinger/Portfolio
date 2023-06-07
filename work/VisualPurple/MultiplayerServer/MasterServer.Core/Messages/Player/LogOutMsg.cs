/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request a Player logging out.
 */

using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Player client to Log Out of the system
	public class LogOutMsg : MessageBase
	{
		// Constructor: Defines enum message type as this class
		public LogOutMsg()
		{
			MsgType = EMessageType.eLogOut;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			Console.WriteLine( $"LogOutMsg::Deserialize ClientID {ClientHandler.ClientID}" );
		}

		// After deserialization, request to log out is executed
		override public void Execute()
		{
			ServerData.LogOut( ClientHandler );
		}
	}
}
