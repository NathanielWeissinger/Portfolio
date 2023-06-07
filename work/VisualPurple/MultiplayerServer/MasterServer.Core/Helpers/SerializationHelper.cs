/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Serialization/Deserialization static handler class: converts Messages into
 *	byte data MemoryStreams for sending, and decrypts byte data into Messages
 *	for receiving.
 * Used and referenced within all Message classes.
 */

using System.IO;
using System.Text;
using System;

namespace MasterServer.Core.Helpers
{
	public static class SerializationHelper
	{
		// Write a Boolean to the Memory Stream
		public static void SerializeBool( this MemoryStream InMStream, bool InbVal )
		{
			InMStream.WriteByte( (byte)(InbVal ? 1 : 0) );
		}

		// Write an Integer to the Memory Stream
		public static void SerializeInt( this MemoryStream InMStream, int InbVal )
		{
			// Turn the Integer to a Byte Array
			byte[] tmp = BitConverter.GetBytes( InbVal );

			InMStream.Write( tmp, 0, tmp.Length );
		}

		// Write a String to the Memory Stream
		public static void SerializeString( this MemoryStream InMStream, string InStr )
		{
			// Write the String length to the Stream,
			// Adding one Byte for the trailing Zero
			SerializeInt( InMStream, InStr.Length + 1 );

			// Write the String contents
			InMStream.Write( Encoding.UTF8.GetBytes( InStr ), 0, InStr.Length );

			// Write the trailing Zero
			InMStream.WriteByte( 0 );
		}

		// Read a Byte from the Array and increment the Index
		public static byte DeSerializeByte( this byte[] bytes, ref int index )
		{
			// Turn bytes back into an int
			var rval = bytes[index];
			index++;

			return rval;
		}

		// Read an Integer from the Array and increment the Index
		public static int DeSerializeInt( this byte[] bytes, ref int index )
		{
			// Turn bytes back into an int
			var rval = BitConverter.ToInt32( bytes, index );
			index += 4;

			return rval;
		}

		// Read a String from the Array and increment the Index
		public static string DeSerializeString( this byte[] bytes, ref int index )
		{
			// Determine the length of the String
			var length = DeSerializeInt( bytes, ref index );

			// Read the String from the Array
			var rval = Encoding.UTF8.GetString( bytes, index, length );

			// Increment the index based the actual String Length,
			// No trailing Zero
			index += length;

			return rval;
		}
	}
}
