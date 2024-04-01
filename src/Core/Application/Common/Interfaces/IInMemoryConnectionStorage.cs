using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface IInMemoryConnectionStorage<T>
    {
        public IEnumerable<string> GetConnections(T key);
        public void Add(T key, string connectionId);
        public void Remove(T key, string connectionId);


    }
}
