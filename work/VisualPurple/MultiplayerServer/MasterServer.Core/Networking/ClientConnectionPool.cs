// Based on third-party code

using System.Collections;

namespace MasterServer.Core
{
	class ClientConnectionPool
	{
		// Creates a synchronized wrapper around the Queue.
		private Queue SyncdQ = Queue.Synchronized( new Queue() );

		public void Enqueue( ClientHandler InClient )
		{
			SyncdQ.Enqueue( InClient );
		}

		public ClientHandler Dequeue()
		{
			return (ClientHandler)(SyncdQ.Dequeue());
		}

		public int Count
		{
			get { return SyncdQ.Count; }
		}

		public object SyncRoot
		{
			get { return SyncdQ.SyncRoot; }
		}

	} // class ClientConnectionPool
}
