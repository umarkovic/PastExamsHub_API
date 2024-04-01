using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PastExamsHub.Core.Application.Common.Interfaces;

namespace PastExamsHub.Core.WebAPI.SignalR
{
    //https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/mapping-users-to-connections#in-memory-storage
    public class InMemoryConnectionStorage<T> : IInMemoryConnectionStorage<T>
    {
        private readonly Dictionary<T, HashSet<string>> ConnectionsByUser = new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get
            {
                return ConnectionsByUser.Count;
            }
        }

        public void Add(T key, string connectionId)
        {
            lock (ConnectionsByUser)
            {
                HashSet<string> connections;
                if (!ConnectionsByUser.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    ConnectionsByUser.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (ConnectionsByUser.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (ConnectionsByUser)
            {
                HashSet<string> connections;
                if (!ConnectionsByUser.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        ConnectionsByUser.Remove(key);
                    }
                }
            }
        }
    }
}
