/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Generic Message used for testing. Not used during implementation.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	public class GenericMsg : MessageBase
	{
		// First Generic Int Parameter
		public int Param1 = 0;

		// Second Generic Int Parameter
		public int Param2 = 0;

		// Constructor: Defines enum message type as this class
		public GenericMsg()
		{
			MsgType = EMessageType.eGeneric;
		}

		// Typical parameters relate to obtaining ID data and a result
		public void Init( int InP1, int InP2 )
		{
			Console.WriteLine( $"ConnectMsg::Init p1 {InP1} p2 {InP2}" );

			Param1 = InP1;
			Param2 = InP2;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			Param1 = bytes.DeSerializeInt( ref index );
			Param2 = bytes.DeSerializeInt( ref index );
		}

		// Perform some function after the message has been deserialized
		override public void Execute()
		{
			// Launches either the Game Map if Param1=1, or the Lobby Map if Param1=2
			ServerData.HandleGenericMessage( ClientHandler, Param1, Param2 );
		}
	}
}
