// Based on third-party code

using System;
using System.Net;
using System.Net.Sockets;
using MasterServer.Core.Models;
using Serilog;
using static MasterServer.Core.Models.ServerData;

namespace MasterServer.Core
{
	public class SynchronousSocketListener
	{
		private readonly ServerData _ServerData;
		private readonly ILogger _Logger;

		public bool bIsActive = true;
		TcpListener Listener = null;
		ClientService ClientTask = null;

		public SynchronousSocketListener( ServerData InServerData, ILogger InLogger )
		{
			_Logger = InLogger;
			_ServerData = InServerData;
			InServerData.Init();
		}

		public void StartListening( int InPort, LogMessageEventHandler InCallback )
		{
			_ServerData.OnLogMessage += InCallback;

			// Client Connections Pool
			var ConnectionPool = new ClientConnectionPool();

			// Client Task to handle client requests
			ClientTask = new ClientService( ConnectionPool );

			ClientTask.Start();

			//*** Use Any, not 127.0.0.1!!!
			var ep = new IPEndPoint( IPAddress.Any, InPort );
			Listener = new TcpListener( ep );

			try
			{
				Listener.Start();

				// Start listening for connections.
				_ServerData.LogMessage( "Waiting for a connection...", "MasterServer" );

				while (bIsActive)
				{
					var handler = Listener.AcceptTcpClient();
					//handler.Client.RemoteEndPoint.

					if (handler != null)
					{
						_ServerData.ClientCount++;
						_ServerData.LogMessage( $"Client #{_ServerData.ClientCount} Accepted!", "MasterServer" );

						// An incoming connection needs to be processed.
						ConnectionPool.Enqueue( new ClientHandler( _ServerData, _ServerData.ClientCount, handler ) );
					}
					else
						break;
				}

				Listener.Stop();

				// Stop client requests handling
				ClientTask.Stop();
			}
			catch (Exception ex)
			{
				_Logger.Error( ex, "StartListening Error: {Error}", ex.Message );
			}

			_ServerData.OnLogMessage -= InCallback;
		}

		public void Close()
		{
			Listener.Stop();
			ClientTask.Stop();

			bIsActive = false;
		}
	}
}
