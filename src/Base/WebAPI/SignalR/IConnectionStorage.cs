using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastExamsHub.Base.WebAPI.SignalR
{
    //https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/mapping-users-to-connections#in-memory-storage
    public interface IConnectionStorage
    {
        public int Count { get; }

        public void Add(string userUid, string connectionId);

        public IEnumerable<string> GetConnections(string userUid);

        public void Remove(string userUid, string connectionId);
    }
}
