using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Authority.Infrastructure.Persistence.DesignTime
{
    public class AuthorityDbContextFactory : DbContextFactory<AuthorityDbContext>
    {
        protected override AuthorityDbContext CreateNewInstance(DbContextOptions<AuthorityDbContext> options)
        {
            return new AuthorityDbContext(options);
        }
    }
}
