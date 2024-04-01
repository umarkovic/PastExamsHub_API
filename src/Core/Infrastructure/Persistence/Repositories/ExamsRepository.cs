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
    public class ExamsRepository : BaseRepository<ICoreDbContext, Exam>, IExamsRepository
    {

        public ExamsRepository(ICoreDbContext dbContext) : base(dbContext)
        {
        }



        public override IQueryable<Exam> GetQuery()
        {

            //double check
            return base.GetQuery()
                .Include(x => x.Course).ThenInclude(x=>x.Lecturer)
                .Include(x=>x.File)
                .Include(x => x.CreatedBy)
                .Include(x=>x.Period);

        }

        public int GetExamsCount()
        {
            return base.GetQuery().Count();
        }
    }
}
