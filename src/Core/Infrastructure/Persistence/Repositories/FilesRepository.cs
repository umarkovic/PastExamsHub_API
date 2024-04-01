using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Infrastructure.Persistence.Repositories
{
    public class FilesRepository : BaseRepository<ICoreDbContext, File>, IFilesRepository
    {

        public FilesRepository(ICoreDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<File> GetQuery()
        {

            //double check
            return base.GetQuery();

        }

    }
}
