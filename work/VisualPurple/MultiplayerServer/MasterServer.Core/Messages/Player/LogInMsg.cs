/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request a Player logging in (after entering
 *	a username and password), along with the NetName and ClientHandler.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Player client to Log In to the system
	public class LogInMsg : MessageBase
	{
		// The Player's Public Name
		string PlayerName;

		// The Player's Password Hash
		string Password;

		// The Player's Network Name
		string NetName;

		// Constructor: Defines enum message type as this class
		public LogInMsg()
		{
			MsgType = EMessageType.eLogIn;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			PlayerName = bytes.DeSerializeString( ref index );
			Password = bytes.DeSerializeString( ref index );
			NetName = bytes.DeSerializeString( ref index );

			Console.WriteLine( $"LogInMsg::Deserialize PlayerName {PlayerName} Password {Password} NetName {NetName}" );
		}

		// After deserialization, request to log in is executed
		override public void Execute()
		{
			ServerData.LogIn( ClientHandler, PlayerName, Password, NetName );
		}
	}
}
