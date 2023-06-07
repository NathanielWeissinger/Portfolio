// Based on third-party code

using System;
using System.Threading;

namespace MasterServer.Core
{
	class ClientService
	{
		const int MAX_THREADS = 10;

		private bool ContinueProcess = false;

		private ClientConnectionPool ConnectionPool;
		private Thread[] ThreadTask = new Thread[MAX_THREADS];

		public ClientService( ClientConnectionPool InConnectionPool )
		{
			ConnectionPool = InConnectionPool;
		}

		public void Start()
		{
			ContinueProcess = true;

			// Start threads to handle Client Task
			for (int i = 0; i < ThreadTask.Length; i++)
			{
				ThreadTask[i] = new Thread( new ThreadStart( Process ) );
				ThreadTask[i].Start();
			}
		}

		private void Process()
		{
			while (ContinueProcess)
			{
				ClientHandler client = null;

				lock (ConnectionPool.SyncRoot)
				{
					if (ConnectionPool.Count > 0)
						client = ConnectionPool.Dequeue();
				}

				if (client != null)
				{
					client.Process(); // Process client

					// if client still connected, schedule for later processing
					if (client.Alive)
						ConnectionPool.Enqueue( client );
					else
						client.Close();
				}

				Thread.Sleep( 100 );
			}
		}

		public void Stop()
		{
			ContinueProcess = false;
			for (int i = 0; i < ThreadTask.Length; i++)
			{
				if (ThreadTask[i] != null && ThreadTask[i].IsAlive)
					ThreadTask[i].Join();
			}

			// Close all client connections
			while (ConnectionPool.Count > 0)
			{
				ClientHandler client = ConnectionPool.Dequeue();
				client.Close();
				Console.WriteLine( "Client connection is closed!" );
			}
		}

	} // class ClientService
}
