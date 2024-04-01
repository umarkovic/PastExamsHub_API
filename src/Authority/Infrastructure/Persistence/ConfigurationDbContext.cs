using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Authority.Application.Common.Interfaces;

namespace PastExamsHub.Authority.Infrastructure.Persistence
{
    //https://github.com/IdentityServer/IdentityServer4/blob/main/src/EntityFramework.Storage/src/DbContexts/ConfigurationDbContext.cs
    public class ConfigurationDbContext : IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext<ConfigurationDbContext>, IConfigurationDbContext
    {
        public ConfigurationDbContext
        (
            DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions
        ) 
            : base(options, Configure(storeOptions))
        {
        }

        static ConfigurationStoreOptions Configure(ConfigurationStoreOptions storeOptions)
        {
            storeOptions.DefaultSchema = nameof(IdentityServer4);
            return storeOptions;
        }

        public async Task Migrate()
        {
            if (Database.IsInMemory())
            {
                return;
            }

            await Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //modelBuilder.ConfigureClientContext(_storeOptions);
            //modelBuilder.ConfigureResourcesContext(_storeOptions);

            //TODO: turn seeding on
            Seed(builder);
        }

        //https://deblokt.com/2020/01/24/04-part-3-identityserver4-asp-net-core-identity-net-core-3-1/
        private void Seed(ModelBuilder builder)
        {
            var apiScopeName = "api.access";
            var apiSecret = IdentityServer4.Models.HashExtensions.Sha256("Administrator1!");

            int i = 0;
            var openId = new IdentityServer4.Models.IdentityResources.OpenId().ToEntity();
            var openIdClaims = openId.UserClaims;
            openId.Id = ++i;
            openId.UserClaims = null;

            var profile = new IdentityServer4.Models.IdentityResources.Profile().ToEntity();
            var profileClaims = profile.UserClaims;
            profile.Id = ++i;
            profile.UserClaims = null;

            builder.Entity<IdentityResource>().HasData
            (
                openId,
                /*
                new IdentityResource()
                {
                    Id = 1,
                    Enabled = true,
                    Name = openId.Name,
                    DisplayName = openId.DisplayName,
                    Description = openId.Description,
                    Required = true,
                    Emphasize = false,
                    ShowInDiscoveryDocument = true,
                    Created = DateTime.UtcNow,
                    Updated = null,
                    NonEditable = false
                },
                */
                profile
            /*
            new IdentityResource()
            {
                Id = 2,
                Enabled = true,
                Name = "profile",
                DisplayName = "User profile",
                Description = "Your user profile information (first name, last name, etc.)",
                Required = false,
                Emphasize = true,
                ShowInDiscoveryDocument = true,
                Created = DateTime.UtcNow,
                Updated = null,
                NonEditable = false
            }
            */
            );

            i = 0;
            builder.Entity<IdentityResourceClaim>().HasData
            (
                openIdClaims.Select
                (
                    claim =>
                    new IdentityResourceClaim
                    {
                        Id = ++i,
                        IdentityResourceId = 1,
                        Type = claim.Type
                    }
                )
            );
            builder.Entity<IdentityResourceClaim>().HasData
            (
                profileClaims.Select
                (
                    claim =>
                    new IdentityResourceClaim
                    {
                        Id = ++i,
                        IdentityResourceId = 2,
                        Type = claim.Type
                    }
                )
            );

            i = 0;
            builder.Entity<ApiScope>().HasData
            (
                new ApiScope
                {
                    Id = ++i,
                    Name = apiScopeName, //REVIEW: must match ApiResource?
                    DisplayName = "Template API Scope",
                    Description = null,
                    Required = false,
                    Emphasize = false,
                    ShowInDiscoveryDocument = true,
                }
            );

            i = 0;
            builder.Entity<ApiResource>().HasData
            (
                new ApiResource
                {
                    Id = ++i,
                    Name = apiScopeName,//REVIEW: rename "api.access" -> "Template-api" "entire API"?
                    DisplayName = "Template API"
                }
            );

            i = 0;
            builder.Entity<ApiResourceSecret>().HasData
            (
                new ApiResourceSecret()
                {
                    Id = ++i,
                    ApiResourceId = 1,
                    Value = apiSecret,
                }
            );

            i = 0;
            builder.Entity<ApiResourceScope>().HasData
            (
                new ApiResourceScope()
                {
                    Id = ++i,
                    ApiResourceId = 1,
                    Scope = apiScopeName
                }
            );


            i = 0;
            builder.Entity<Client>().HasData
            (
                new Client
                {
                    Id = ++i,
                    ClientId = "Web",//REVIEW: must match src\Core\WebUI\projects\plane-vr-ui\src\app\app.module.ts
                    ClientName = "Web",//REVIEW: likely not required; 2 clients Core WebUI & Authority WebUI
                    
                    Enabled = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    Description = null,
                    RequirePkce = true,
                    AllowOfflineAccess = true,

                    AccessTokenLifetime = 60*20,//20 mins
                    IdentityTokenLifetime = 60*20,//20 mins,
                    AbsoluteRefreshTokenLifetime = 60*24*7//7 days
                }

                #region Examples
                /*
                new Client
                {
                    Id = 1,
                    Enabled = true,
                    ClientId = "client",
                    ProtocolType = "oidc",
                    RequireClientSecret = true,
                    RequireConsent = true,
                    ClientName = null,
                    Description = null,
                    AllowRememberConsent = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = false,
                    AllowOfflineAccess = false
                },
                new Client
                {
                    Id = 2,
                    Enabled = true,
                    ClientId = "ro.client",
                    ProtocolType = "oidc",
                    RequireClientSecret = true,
                    RequireConsent = true,
                    ClientName = null,
                    Description = null,
                    AllowRememberConsent = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = false,
                    AllowOfflineAccess = false
                },
                new Client
                {
                    Id = 3,
                    Enabled = true,
                    ClientId = "mvc",
                    ProtocolType = "oidc",
                    RequireClientSecret = true,
                    RequireConsent = true,
                    ClientName = "MVC Client",
                    Description = null,
                    AllowRememberConsent = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = false,
                    AllowOfflineAccess = true
                },
                new Client
                {
                    Id = 4,
                    Enabled = true,
                    ClientId = "js",
                    ProtocolType = "oidc",
                    RequireClientSecret = false,
                    RequireConsent = true,
                    ClientName = "JavaScript client",
                    Description = null,
                    AllowRememberConsent = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = false,
                    AllowOfflineAccess = false
                }
                */
                #endregion
            );

            i = 0;
            builder.Entity<ClientGrantType>().HasData
            (
                new ClientGrantType
                {
                    Id = ++i,
                    GrantType = "authorization_code",
                    ClientId = 1
                }

                #region examples
                /*
                IdentityServer4.Models.GrantTypes.Code.Select
                (
                    type =>
                    new ClientGrantType
                    {
                        Id = ++i,
                        ClientId = 1,
                        GrantType = type,
                    }
                ),
                new ClientGrantType
                {
                    Id = 1,
                    GrantType = "client_credentials",
                    ClientId = 1
                },
                new ClientGrantType
                {
                    Id = 2,
                    GrantType = "password",
                    ClientId = 2
                },
                new ClientGrantType
                {
                    Id = 3,
                    GrantType = "hybrid",
                    ClientId = 3
                },
                new ClientGrantType
                {
                    Id = 4,
                    GrantType = "authorization_code",
                    ClientId = 4
                }
                */
                #endregion
            );

            i = 0;
            builder.Entity<ClientScope>().HasData
            (
                new ClientScope
                {
                    Id = ++i,
                    ClientId = 1,
                    Scope = openId.Name,
                },
                new ClientScope
                {
                    Id = ++i,
                    ClientId = 1,
                    Scope = profile.Name,
                },
                new ClientScope
                {
                    Id = ++i,
                    ClientId = 1,
                    Scope = apiScopeName,
                }
            );

            /*
            i = 0;
            //only required for GrantType = "password"
            builder.Entity<ClientSecret>().HasData
            (
                new ClientSecret
                {
                    Id = ++i,
                    Value = "secret".ToSha256(),
                    Type = "SharedSecret",
                    ClientId = 1
                }
            );
            */

            i = 0;
            builder.Entity<ClientPostLogoutRedirectUri>().HasData
            (
                //Core
                new ClientPostLogoutRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    PostLogoutRedirectUri = "http://localhost:4002",
                    //PostLogoutRedirectUri = "http://localhost:4002/signout-callback-oidc",//TODO: check best practices
                },
                new ClientPostLogoutRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    PostLogoutRedirectUri = "http://localhost:4002/silent-renew.html",
                    //PostLogoutRedirectUri = "http://localhost:4002/index.html",//TODO: check best practices
                },
                //Membership
                new ClientPostLogoutRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    PostLogoutRedirectUri = "http://localhost:4001",
                },
                new ClientPostLogoutRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    PostLogoutRedirectUri = "http://localhost:4001/silent-renew.html",
                    //PostLogoutRedirectUri = "http://localhost:4001/index.html",//TODO: check best practices
                }
            );

            i = 0;
            builder.Entity<ClientRedirectUri>().HasData
            (
                //Core
                new ClientRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    RedirectUri = "http://localhost:4002",
                    //RedirectUri = "http://localhost:4002/signin-oidc",//TODO: check best practices
                },
                new ClientRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    RedirectUri = "http://localhost:4002/silent-renew.html",
                    //RedirectUri = "http://localhost:4002/callback.html",//TODO: check best practices
                },
                //Membership
                new ClientRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    RedirectUri = "http://localhost:4001",
                    //RedirectUri = "http://localhost:4001/signin-oidc",//TODO: check best practices
                },
                new ClientRedirectUri
                {
                    Id = ++i,
                    ClientId = 1,
                    RedirectUri = "http://localhost:4001/silent-renew.html",
                    //RedirectUri = "http://localhost:4001/callback.html",//TODO: check best practices
                }
            );

            i = 0;
            builder.Entity<ClientCorsOrigin>().HasData
            (
                /*
                new ClientCorsOrigin
                {
                    Id = ++i,
                    ClientId = 1,
                    Origin = "http://localhost:4000",
                },
                */
                new ClientCorsOrigin
                {
                    Id = ++i,
                    ClientId = 1,
                    Origin = "http://localhost:4001",
                },
                new ClientCorsOrigin
                {
                    Id = ++i,
                    ClientId = 1,
                    Origin = "http://localhost:4002",
                }
            );
        }
    }
}
