using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Logging;
using PastExamsHub.Base.Infrastructure.Persistence;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.WebAPI.Extensions
{
    internal static class IdentityServerExtensions
    {
        internal static void AddIdentityServer(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment, //TODO: use for isDevelopment
            ConfigurationStoreOptions storeOptions //TODO: DI setup
        )
        {
            
        }

        //TODO: test appsettings support
        // https://stackoverflow.com/questions/57246219/how-to-configure-key-settings-for-identityserver-in-appsettings-json-for-aspnet
        public static IIdentityServerBuilder AddSigninCredential(
            this IIdentityServerBuilder builder,
            Settings.IdentityServer configuration
        )
        {
            var keyType = configuration?.KeyType ?? Settings.IdentityServerConfigurationType.Developer;

            Log.Debug($"Using IdentityServer {keyType} configuration");

            switch (keyType)
            {
                case Settings.IdentityServerConfigurationType.Developer:
                    Log.Debug("Using temporary key");
                    builder.AddDeveloperSigningCredential();
                    break;

                case Settings.IdentityServerConfigurationType.KeyFile:
                    Log.Debug($"Using key file {configuration?.KeyFilePath}");
                    builder.AddCertificateFromFile(configuration?.KeyFilePath, configuration?.KeyFilePassword);
                    break;

                case Settings.IdentityServerConfigurationType.KeyStore:
                    Log.Debug($"Using key thumbprint {configuration?.KeyStoreThumbprint}");
                    builder.AddCertificateFromStore(configuration?.KeyStoreThumbprint);
                    break;
            }

            return builder;
        }

        static void AddCertificateFromStore(
            this IIdentityServerBuilder builder,
            string keyThumbprint
        )
        {
            if (keyThumbprint == null)
            {
                Log.Debug("Using temporary key");
                builder.AddDeveloperSigningCredential();
                return;
            }

            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, keyThumbprint, false);

            if (certificates.Count == 0)
            {
                throw new Exception($"Key subject {keyThumbprint} not found");
            }

            var certificate = certificates[0];

            ValidateCertificate(certificate);

            builder.AddSigningCredential(certificate);
        }

        static void AddCertificateFromFile(
            this IIdentityServerBuilder builder,
            string keyFilePath,
            string keyFilePassword
        )//TODO: System.Security.SecureString
        {
            if (!File.Exists(keyFilePath))
            {
                throw new Exception($"Key file {keyFilePath} not found");
            }

            var certificate = new X509Certificate2(keyFilePath, keyFilePassword, X509KeyStorageFlags.MachineKeySet);

            ValidateCertificate(certificate);

            builder.AddSigningCredential(certificate);
        }

        static void ValidateCertificate(X509Certificate2 certificate)
        {
            var accountName = System.Security.Principal.WindowsIdentity.GetCurrent()?.Name;
            Log.Debug($"Accessing key as {accountName}");

            var privateKeyType = certificate.PrivateKey.GetType();//IMPORTANT: will throw if access not granted
            Log.Debug($"Key Type: {privateKeyType}");

            var date = DateTime.Parse(certificate.GetExpirationDateString());
            Log.Debug($"Expiration Date: {date}");
            if (date < DateTime.Now)
            {
                throw new ArgumentException("Invalid certificate", $"Expiration Date: {date}");
            }
        }
    }
}
