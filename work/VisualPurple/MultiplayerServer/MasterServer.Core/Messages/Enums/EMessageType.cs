/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors:	David Begg, James Kitzhaber, Nicholas Ludowese,
 *			Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Defines enum types of all Message classes, allowing the ClientHandler
 * to pass serialized byte data through the MessageFactory to determine
 * what type of message was received.
 */

namespace MasterServer.Core.Messages.Enums
{
	public enum EMessageType
	{
		eMessageBase = 0,
		eConnect,
		eConnectResponse,
		eHeartbeat,
		eGeneric,
		eCreateLobby,           // 5
		eCreateLobbyResponse,
		eCancelLobby,
		eCancelLobbyResponse,
		eStartLobby,
		eSearchLobby,           // 10
		eSearchLobbyResponse,
		eJoinLobby,
		eJoinLobbyResponse,
		eLaunchMap,
		eDisconnect,            // 15
		eLogIn,
		eLogInResponse,
		eLogOut,
		eLogOutResponse,
		eRegisterPlayer,        // 20
		eRegisterPlayerResponse,
		eSwitchServer,
		eSwitchServerResponse,
		ePlayerJoined,
		eServerData,            // 25
		eServerDataResponse,
		eCount                  // 27
	}
}
