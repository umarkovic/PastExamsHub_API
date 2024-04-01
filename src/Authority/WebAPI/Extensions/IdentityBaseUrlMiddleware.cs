using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;

namespace PastExamsHub.Authority.WebAPI.Extensions
{
    //http://amilspage.com/set-identityserver4-url-behind-loadbalancer/
    //This middleware can change baseUrl for authority (all urls in /.well-known/openid-configuration)
    //This middleware will change first url ("issuer") too, but do not change IssuerUri in authority configuration manually, because this middleware couldn't change it
    //and have desired value that we pass through the publicFacingUri
    public class IdentityBaseUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _publicFacingUri;

        public IdentityBaseUrlMiddleware(RequestDelegate next, string publicFacingUri)
        {
            _publicFacingUri = publicFacingUri;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            context.SetIdentityServerOrigin(_publicFacingUri);
            context.SetIdentityServerBasePath(request.PathBase.Value.TrimEnd('/'));

            await _next(context);
        }
    }
}
