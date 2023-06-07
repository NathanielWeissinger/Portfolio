/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Base class for Messages, implemented by all Message classes.
 * Initializes, Serializes/Deserializes, and Sends/Executes data.
 */

using MasterServer.Core.Messages.Enums;
using MasterServer.Core.Models;
using System;
using System.IO;

namespace MasterServer.Core.Messages
{
	public partial class MessageBase
	{
		// The Message Type
		public EMessageType MsgType = EMessageType.eMessageBase;

		// The Client Handler for sending messages
		public ClientHandler ClientHandler = null;

		// The Form used for Output
		protected ServerData ServerData = null;

		// Receives ClientHandler and ServerData instances from ClientHandler.cs,
		// saves so each message type can acess these variables locally
		public void Init( ClientHandler InClientHandler, ServerData InServerData )
		{
			// Most implementations include additional initializations
			ClientHandler = InClientHandler;
			ServerData = InServerData;
		}

		// Serializes the MessageType as a Byte
		public virtual void Serialize( MemoryStream InMStream )
		{
			// mstream.WriteByte( (byte)MsgType );
		}

		// The MsgType determined before the message was created
		public virtual void Deserialize( byte[] bytes, int index )
		{
			// Test Console Print:
			// Console.WriteLine( $"MessageBase::Deserialize MsgType {MsgType} " );
		}

		// Serialize and send the Message
		public bool Send( ClientHandler InClient )
		{
			var MStream = new MemoryStream();

			// Virtual Serialize method
			Serialize( MStream );

			// Assume the buffer is no longer than an Integer
			if (InClient.SendMessage( (byte)MsgType, MStream ))
			{
				Console.WriteLine( $"MessageBase::Send Client {InClient.ClientID} " );

				return true;
			}

			return false;
		}

		// Perform some function after the message has been deserialized
		// ToDo: This is normally executed from a Queue of Deserialized messages
		// in it's own thread
		public virtual void Execute()
		{
			// Implementation overridden by some subclasses
		}
	}
}
