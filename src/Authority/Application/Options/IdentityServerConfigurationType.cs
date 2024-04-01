using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Application.Options
{
    public enum IdentityServerConfigurationType
    {
        Unknown = 0,
        
        Developer,
        KeyFile,
        KeyStore,
        ECDSA
    }
}
