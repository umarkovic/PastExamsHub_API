using IdentityServer4.Configuration;
using IdentityServer4.Hosting;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Infrastructure.Identity
{
    public class CustomDiscoveryResponseGenerator : IdentityServer4.ResponseHandling.DiscoveryResponseGenerator
    {
        public CustomDiscoveryResponseGenerator
        (
            IdentityServerOptions options, 
            IResourceStore resourceStore, 
            IKeyMaterialService keys, 
            ExtensionGrantValidator extensionGrants, 
            ISecretsListParser secretParsers, 
            IResourceOwnerPasswordValidator resourceOwnerValidator, 
            ILogger<IdentityServer4.ResponseHandling.DiscoveryResponseGenerator> logger
        )
            : base(options, resourceStore, keys, extensionGrants, secretParsers, resourceOwnerValidator, logger)
        {
        }

        public async override Task<Dictionary<string, object>> CreateDiscoveryDocumentAsync(string baseUrl, string issuerUri)
        {
            var response =  await base.CreateDiscoveryDocumentAsync(baseUrl, issuerUri);

            foreach (var key in response.Keys)
            {
                var endpoint = response[key] as string;
                if(endpoint == null)
                {
                    continue;
                }
                response[key] = endpoint.Replace("/connect/", "/oauth2/v1/");
            }

            return response;
        }
    }
}
