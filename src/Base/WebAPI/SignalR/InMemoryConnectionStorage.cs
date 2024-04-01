using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastExamsHub.Base.WebAPI.SignalR
{
    //https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/mapping-users-to-connections#in-memory-storage
    public class InMemoryConnectionStorage : IConnectionStorage
    {
        readonly Dictionary<string, HashSet<string>> ConnectionsByUser;

        public InMemoryConnectionStorage()
        {
            ConnectionsByUser = new Dictionary<string, HashSet<string>>();
        }

        public int Count
        {
            get
            {
                return ConnectionsByUser.Count;
            }
        }

        public void Add(string userUid, string connectionId)
        {
            lock (ConnectionsByUser)
            {
                HashSet<string> connections;
                if (!ConnectionsByUser.TryGetValue(userUid, out connections))
                {
                    connections = new HashSet<string>();
                    ConnectionsByUser.Add(userUid, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(string userUid)
        {
            HashSet<string> connections;
            if (ConnectionsByUser.TryGetValue(userUid, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(string userUid, string connectionId)
        {
            lock (ConnectionsByUser)
            {
                HashSet<string> connections;
                if (!ConnectionsByUser.TryGetValue(userUid, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        ConnectionsByUser.Remove(userUid);
                    }
                }
            }
        }
    }
}
