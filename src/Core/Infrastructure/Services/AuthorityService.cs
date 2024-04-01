using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using IdentityModel.Client;
using Newtonsoft.Json;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Infrastructure;
using PastExamsHub.Core.Application.Common.Interfaces;

namespace PastExamsHub.Core.Infrastructure.Services
{
    public class AuthorityService : IAuthorityService
    {
        const string CacheKey = nameof(AuthorityService) + ".AccessToken";

        readonly IMemoryCache Cache;
        readonly IHttpClientFactory HttpClientFactory;
        readonly Base.Application.Options.Authentication Options;
        readonly Options.AuthorityCredentials AuthorityCredentials;

        public AuthorityService
        (
            IConfiguration configuration,
            IMemoryCache cache,
            IHttpClientFactory httpClientFactory
        )
        {
            this.Cache = cache;
            this.HttpClientFactory = httpClientFactory;
            Options = configuration.Read<Base.Application.Options.Authentication>();
            AuthorityCredentials = configuration.Read<Options.AuthorityCredentials>();
        }

        string GetAccessToken()
        {
            if (Cache.TryGetValue<string>(CacheKey, out string value))
            {
                return value;
            }
            return null;
        }

        void SetAccessToken(string accessToken)
        {
            Cache.Set<string>(CacheKey, accessToken, TimeSpan.FromMinutes(10));//TODO: settings
        }

        async Task<string> AuthenticateAsync()
        {
            var accessToken = GetAccessToken();
            if(accessToken == null)
            {
                var tokenEndpoint = await QueryTokenEndpointAsync();
                accessToken = await GetTokenAsync(tokenEndpoint);
                SetAccessToken(accessToken);
            }

            return accessToken;
        }

        async Task<string> QueryTokenEndpointAsync()
        {
            using (var httpClient = HttpClientFactory.CreateClient())
            {
                var discoveryDocument = await httpClient.GetDiscoveryDocumentAsync($"{Options.AuthorityUrl}");
                if (discoveryDocument.IsError)
                {
                    throw discoveryDocument.Exception;
                }

                return discoveryDocument.TokenEndpoint;
            }
        }

        async Task<string> GetTokenAsync(string tokenEndpoint)
        {
            using (var httpClient = HttpClientFactory.CreateClient())
            {
                var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = tokenEndpoint,
                    ClientId = AuthorityCredentials.ClientId,
                    ClientSecret = AuthorityCredentials.ClientSecret,
                    Scope = Options.ApiResourceName //TODO: rename to Scope
                });
                if (tokenResponse.IsError)
                {
                    throw tokenResponse.Exception;
                }

                return tokenResponse.AccessToken;
            }
        }

        public async Task<string> CreateOrUpdateUser(IApplicationUser user)
        {
            var accessToken = await AuthenticateAsync();

            var content = JsonConvert.SerializeObject(user);
            var data = new StringContent(content, Encoding.UTF8, "application/json");

            using (var httpClient = HttpClientFactory.CreateClient())
            {
                httpClient.SetBearerToken(accessToken);
                var response = await httpClient.PostAsync($"{Options.AuthorityUrl}/Users/CreateOrUpdate", data);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
