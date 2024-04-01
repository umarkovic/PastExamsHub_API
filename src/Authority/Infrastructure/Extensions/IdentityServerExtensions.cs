using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace PastExamsHub.Authority.Infrastructure.Extensions
{
    internal static class IdentityServerExtensions
    {
        //TODO: test appsettings support
        // https://stackoverflow.com/questions/57246219/how-to-configure-key-settings-for-identityserver-in-appsettings-json-for-aspnet
        //TODO: implement key rolover
        // http://docs.identityserver.io/en/latest/topics/crypto.html#signing-key-rollover
        // https://brockallen.com/2019/08/09/identityserver-and-signing-key-rotation/
        public static IIdentityServerBuilder AddSigninCredential(
            this IIdentityServerBuilder builder,
            Application.Options.IdentityServer configuration
        )
        {
            var keyType = configuration?.KeyType ?? Application.Options.IdentityServerConfigurationType.Developer;

            Log.Debug($"Using IdentityServer {keyType} configuration");

            switch (keyType)
            {
                case Application.Options.IdentityServerConfigurationType.Developer:
                    Log.Debug("Using temporary key");
                    builder.AddDeveloperSigningCredential();
                    break;

                case Application.Options.IdentityServerConfigurationType.KeyFile:
                    Log.Debug($"Using key file {configuration?.KeyFilePath}");
                    builder.AddCertificateFromFile(configuration?.KeyFilePath, configuration?.KeyFilePassword);
                    break;

                case Application.Options.IdentityServerConfigurationType.KeyStore:
                    Log.Debug($"Using key thumbprint {configuration?.KeyStoreThumbprint}");
                    builder.AddCertificateFromStore(configuration?.KeyStoreThumbprint);
                    break;
                
                case Application.Options.IdentityServerConfigurationType.ECDSA:
                    Log.Debug($"Using ECDSA {configuration?.PrivateKeyId}");
                    builder.AddCertificateFromECDSA(configuration?.PrivateKeyData, configuration?.PrivateKeyId);
                    break;
            }

            return builder;
        }

        //https://www.scottbrady91.com/identity-server/using-ecdsa-in-identityserver4
        static void AddCertificateFromECDSA(
            this IIdentityServerBuilder builder,
            string privateKeyData,
            string privateKeyId

        )
        {
            if (privateKeyData == null)
            {
                Log.Debug("Using temporary key");
                builder.AddDeveloperSigningCredential();
                return;
            }

            var pemBytes = Convert.FromBase64String(privateKeyData);

            var ecdsa = ECDsa.Create();
            ecdsa.ImportECPrivateKey(pemBytes, out _);
            var securityKey = new ECDsaSecurityKey(ecdsa) { KeyId = privateKeyId };

            builder.AddSigningCredential(securityKey, ECDsaSigningAlgorithm.ES256);
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
            
            var certificate = new X509Certificate2(keyFilePath, keyFilePassword, X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.EphemeralKeySet);
            ValidateCertificate(certificate);

            builder.AddSigningCredential(certificate);
        }

        static void ValidateCertificate(X509Certificate2 certificate)
        {
            //TODO: windows only - find a mulitplatform equivalent
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
