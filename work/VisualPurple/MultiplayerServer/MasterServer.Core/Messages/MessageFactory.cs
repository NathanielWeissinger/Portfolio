/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Initializes Message within the ClientHandler from byte data, to be deserialized
 * See Messages->Enums->EMessageType.cs for list of enums
 */

using MasterServer.Core.Messages.Enums;
using System;

namespace MasterServer.Core.Messages
{
	public class MessageFactory
	{
		// Determines type of serialized message received,
		// initializes message based on enum type from byte data
		public MessageBase GetMessageByType( EMessageType InMsgType )
		{
			switch (InMsgType)
			{
				case EMessageType.eConnect:
					return new ConnectMsg();
				case EMessageType.eHeartbeat:
					return new HeartbeatMsg();
				case EMessageType.eGeneric:
					return new GenericMsg();
				case EMessageType.eCreateLobby:
					return new CreateLobbyMsg();
				case EMessageType.eCancelLobby:
					return new CancelLobbyMsg();
				case EMessageType.eStartLobby:
					return new StartLobbyMsg();
				case EMessageType.eSearchLobby:
					return new SearchLobbyMsg();
				case EMessageType.eJoinLobby:
					return new JoinLobbyMsg();
				case EMessageType.eLogIn:
					return new LogInMsg();
				case EMessageType.eLogOut:
					return new LogOutMsg();
				case EMessageType.eRegisterPlayer:
					return new RegisterPlayerMsg();
				case EMessageType.eSwitchServer:
					return new SwitchServerMsg();
				case EMessageType.eSwitchServerResponse:
					return new SwitchServerResponseMsg();
				case EMessageType.ePlayerJoined:
					return new PlayerJoinedMsg();
				case EMessageType.eServerData:
					return new ServerDataMsg();
				default:
					Console.WriteLine( "!! Default Message !!" );
					return null;
			}
		}
	}
}