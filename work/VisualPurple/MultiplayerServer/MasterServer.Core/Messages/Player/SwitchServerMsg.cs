/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request a Player to switch servers.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Player client to switch servers
	public class SwitchServerMsg : MessageBase
	{
		// The Player's Client ID
		int ClientID = 0;

		// The Map Name
		string MapName = String.Empty;

		// The Player's Network Name
		string NetName;

		// The Player's Name
		string PlayerName;

		// Is Facilitator
		bool bIsFacilitator = false;

		// Constructor: Defines enum message type as this class
		public SwitchServerMsg()
		{
			MsgType = EMessageType.eSwitchServer;
		}

		// Initializes input arguments as local variables, sent to Map Server
		public void Init( int InClientID, string InNetName, string InPlayerName, bool InbIsFacilitator )
		{
			ClientID = InClientID;
			NetName = InNetName;
			PlayerName = InPlayerName;
			bIsFacilitator = InbIsFacilitator;
		}

		// Encrypts outgoing response message into a serialized byte stream, sent to Map Server
		public override void Serialize( MemoryStream InMStream )
		{
			base.Serialize( InMStream );

			InMStream.SerializeInt( ClientID );
			InMStream.SerializeString( NetName );
			InMStream.SerializeString( PlayerName );
			InMStream.SerializeBool( bIsFacilitator );
		}

		// Decrypts incoming serialized message byte data from Player Client
		override public void Deserialize( byte[] bytes, int index )
		{
			ClientID = bytes.DeSerializeInt( ref index );
			MapName = bytes.DeSerializeString( ref index );

			Console.WriteLine( $"SwitchServerMsg::Deserialize ClientID {ClientID} MapName {MapName}" );
		}

		// After deserialization, request received from Player Client is executed
		// Sends request to join server
		override public void Execute()
		{
			ServerData.JoinServerRequest( ClientHandler, MapName );
		}
	}
}
