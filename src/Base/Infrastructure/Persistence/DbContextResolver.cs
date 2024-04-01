using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Throw;

namespace PastExamsHub.Base.Infrastructure.Persistence
{
    public sealed class DbContextResolver<TDbContext> : IDbContextResolver
        where TDbContext : IApplicationDbContext
    {
        private readonly TDbContext _context;

        public DbContextResolver(TDbContext context)
        {
            context.Throw().ThrowIfNull();

            _context = context;
        }

        public DbContext GetContext()
        {
            return _context as DbContext;
        }

    }
}
