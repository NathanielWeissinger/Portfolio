// Based on third-party code

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using MasterServer.Core.Messages;
using MasterServer.Core.Messages.Enums;
using MasterServer.Core.Models;

namespace MasterServer.Core
{
	public class ClientHandler
	{
		public int ClientID = 0;

		private TcpClient ClientSocket;
		private NetworkStream NetworkStream;

		private bool bContinueProcess = false;
		private byte[] Databuffer;      // Data buffer for incoming data.
		private MemoryStream ProcessBuffer;
		private DateTime LastHeartbeat;

		private readonly ServerData _ServerData;
		private readonly MessageFactory _MessageFactory;

		private Thread ProcessThreadTask = null;
		private ConcurrentQueue<MessageBase> MessageQueue = new ConcurrentQueue<MessageBase>();

		//* Message Management

		public void EnqueueMessage( MessageBase InMsg )
		{
			MessageQueue.Enqueue( InMsg );
		}

		private void ProcessMessages()
		{
			while (bContinueProcess)
			{
				if (MessageQueue.Count > 0)
				{
					MessageBase msg = null;
					if (MessageQueue.TryDequeue( out msg ))
					{
						msg.Execute();

						msg = null;
					}
				}

				Thread.Sleep( 100 );
			}
		}

		public ClientHandler( ServerData InServerData, int InClientID, TcpClient InTcpClient )
		{
			OnHeartbeat();

			_ServerData = InServerData;
			_MessageFactory = new MessageFactory();
			ClientID = InClientID;
			ClientSocket = InTcpClient;

			ClientSocket.ReceiveTimeout = 100; // 100 miliseconds

			NetworkStream = ClientSocket.GetStream();
			Databuffer = new byte[ClientSocket.ReceiveBufferSize];
			ProcessBuffer = new MemoryStream();
			bContinueProcess = true;

			ProcessThreadTask = new Thread( new ThreadStart( ProcessMessages ) );
			ProcessThreadTask.Start();
		}

		public void Process()
		{
			var Death = DateTime.Now.AddSeconds( -30 );

			if (Death > LastHeartbeat)
			{
				Console.WriteLine( $"Client {ClientID} Last Heartbeat was over 30 seconds ago!" );
				Close();
				return;
			}

			try
			{
				if (NetworkStream.CanRead && NetworkStream.DataAvailable)
				{
					int BytesRead = NetworkStream.Read( Databuffer, 0, (int)Databuffer.Length );

					ProcessBuffer.Write( Databuffer, 0, BytesRead );
				}

				while (ProcessBuffer.Length >= 5)
				{
					int index = 1;
					var msgtype = (EMessageType)ProcessBuffer.GetBuffer()[0];
					var msg = _MessageFactory.GetMessageByType( msgtype );
					var packagesize = DeSerializeInt( ProcessBuffer.GetBuffer(), ref index );

					// If Buffer is not large enough to deserialize our message, break
					if (ProcessBuffer.Length < (packagesize + 5)) // Message package plus header size
						break;

					if (msg == null)
						continue;

					// Deserialize message
					msg.Init( this, _ServerData );
					msg.Deserialize( Databuffer, 5 );

					EnqueueMessage( msg );

					var msgsize = packagesize + 5;

					if (msgtype != EMessageType.eHeartbeat)
						Console.WriteLine( $"Client {ClientID} Index {index} Message Size {msgsize} Buffer Size {ProcessBuffer.Length}" );

					// Pull it from the buffer
					if (ProcessBuffer.Length == msgsize)
					{
						ProcessBuffer.Seek( 0, SeekOrigin.Begin );
						ProcessBuffer.SetLength( 0 );
						ProcessBuffer.Flush();
						break;
					}
					else
					{
						var TempStream = new byte[ProcessBuffer.Length - msgsize];

						Array.Copy( ProcessBuffer.GetBuffer(), msgsize, TempStream, 0, ProcessBuffer.Length - msgsize );

						ProcessBuffer.Seek( 0, SeekOrigin.Begin );

						ProcessBuffer.Write( TempStream, 0, TempStream.Length );
						ProcessBuffer.SetLength( TempStream.Length );
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine( "Process Error: " + ex.Message );

				//	// All the data has arrived; put it in response.
				//	ProcessDataReceived();
			}
			catch (SocketException)
			{
				Close();

				Console.WriteLine( "Process: Connection is broken!" );
			}
		}  // Process()

		public bool SendMessage( byte mtype, MemoryStream InMStream )
		{
			try
			{
				//NetworkStream.

				// Write message type
				NetworkStream.WriteByte( mtype );

				// Write package size
				byte[] tmp = BitConverter.GetBytes( (int)InMStream.Length );
				NetworkStream.Write( tmp, 0, tmp.Length );

				// Write the package
				NetworkStream.Write( InMStream.GetBuffer(), 0, (int)InMStream.Length );
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public void OnHeartbeat()
		{
			LastHeartbeat = DateTime.Now;
		}

		public void Close()
		{
			NetworkStream.Close();
			ClientSocket.Close();

			if (bContinueProcess)
			{
				bContinueProcess = false;
				_ServerData.ClientDisconnect( ClientID );
				//_ServerData.ServerDisconnect( ClientID ); //no functionality yet
			}
		}

		public bool Alive
		{
			get
			{
				return bContinueProcess;
			}
		}

		public string GetHostAddress()
		{
			var address = ClientSocket.Client.RemoteEndPoint.ToString();
			var idx = address.IndexOf( ':' );
			address = address.Substring( 0, idx );

			return address;
		}

		public int DeSerializeInt( byte[] bytes, ref int index )
		{
			// Turn bytes back into an int
			var rval = BitConverter.ToInt32( bytes, index );

			index += 4;

			return rval;
		}
	}
}
