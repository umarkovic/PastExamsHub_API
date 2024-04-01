using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.WebAPI.Settings
{
    public class IdentityServer
    {
        public IdentityServerConfigurationType KeyType { get; set; }
        public string KeyFilePath { get; set; }
        public string KeyFilePassword { get; set; }
        public string KeyStoreThumbprint { get; set; }
    }
}
