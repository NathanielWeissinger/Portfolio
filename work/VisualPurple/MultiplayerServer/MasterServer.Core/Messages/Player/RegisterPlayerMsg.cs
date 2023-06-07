/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * A Message received to request registering a Player.
 */

using MasterServer.Core.Helpers;
using MasterServer.Core.Messages.Enums;
using System;
using static MasterServer.Core.Messages.RegisterPlayerResponseMsg;

namespace MasterServer.Core.Messages
{
	// A Message sent by a Player client to Register with the system
	public class RegisterPlayerMsg : MessageBase
	{
		// The player's network name
		string NetName;

		// The player's public first name
		string FirstName;

		// The player's public last name
		string LastName;

		// The Player's password
		string Password; // This is a hash string

		// The last 4 digits of the players Social Security Number
		string SSN;

		// The player's gender
		string Gender;

		// Are we a Facilicator?
		string Role;

		// The player's rank
		string Rank;

		// The player's unit
		string Unit;

		// The player's job
		string Job;

		// Constructor: Defines enum message type as this class
		public RegisterPlayerMsg()
		{
			MsgType = EMessageType.eRegisterPlayer;
		}

		// Decrypts incoming serialized message byte data
		override public void Deserialize( byte[] bytes, int index )
		{
			NetName = bytes.DeSerializeString( ref index );
			FirstName = bytes.DeSerializeString( ref index );
			LastName = bytes.DeSerializeString( ref index );
			Password = bytes.DeSerializeString( ref index );

			SSN = bytes.DeSerializeString( ref index );
			Gender = bytes.DeSerializeString( ref index );
			Role = bytes.DeSerializeString( ref index );

			Rank = bytes.DeSerializeString( ref index );
			Unit = bytes.DeSerializeString( ref index );
			Job = bytes.DeSerializeString( ref index );

			Console.WriteLine( $"RegisterPlayerMsg::Deserialize PlayerName {FirstName} {LastName} Password {Password} Role {Role}" );
		}

		// After deserialization, request to register the Player is executed
		override public void Execute()
		{
			var result = RegisterPlayerResult.eError;

			// Check to see if the PlayerName already exists
			var player = ServerData.GetPlayer( FirstName + " " + LastName );
			if (player != null)
			{
				// Player already exists
				result = RegisterPlayerResult.eDenied;

				ServerData.LogMessage( $"Denied registration for player {FirstName} {LastName}", "MasterServer" );
			}
			else
			{
				// Player is accepted
				result = RegisterPlayerResult.eAccepted;
				ServerData.RegisterPlayer( ClientHandler, NetName, FirstName, LastName, Password, SSN, Gender, Role, Rank, Unit, Job );
			}

			// Send Response message to Client
			var msg = new RegisterPlayerResponseMsg();
			msg.Init( result );
			msg.Send( ClientHandler );
		}
	}
}
