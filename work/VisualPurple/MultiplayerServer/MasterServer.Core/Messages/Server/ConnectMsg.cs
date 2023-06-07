/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request client connection to the server.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	// Client Connection to the Server, with type
	public class ConnectMsg : MessageBase
	{
		// Received Connection Client Type message enum states
		public enum EClientType
		{
			eUndefined = 0,
			eLobbyServer,
			eGameServer,
			eCount // 3
		}

		// The type of Client connecting to the Server
		EClientType ClientType = EClientType.eUndefined;

		// The public name of the client
		string ClientName;

		// The version of the API
		int VersionNum = 0;

		// Constructor: Defines enum message type as this class
		public ConnectMsg()
		{
			MsgType = EMessageType.eConnect;
		}

		// Initializes ClientType as local enum type
		public void Init( EClientType InClientType )
		{
			ClientType = InClientType;

			Console.WriteLine( $"ConnectMsg::Init ClientType {ClientType}" );
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			ClientType = (EClientType)bytes.DeSerializeByte( ref index );
			ClientName = bytes.DeSerializeString( ref index );
			VersionNum = bytes.DeSerializeInt( ref index );

			Console.WriteLine( $"ConnectMsg::Deserialize ClientType {ClientType} ClientName {ClientName} VersionNum {VersionNum}" );
		}

		// After deserialization, request to connect to the server is executed
		override public void Execute()
		{
			ServerData.ServerConnect( ClientHandler, (int)ClientType, ClientName, VersionNum );
		}
	}
}
