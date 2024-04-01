using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Infrastructure.Persistence.Repositories
{
    public class CoursesRepository : BaseRepository<ICoreDbContext, Course>, ICoursesRepository
    {

        public CoursesRepository(ICoreDbContext dbContext) : base(dbContext)
        {
        }


      
        public override IQueryable<Course> GetQuery()
        {

            //double check
            return base.GetQuery()
                .Include(x => x.Lecturer)
                .Include(x => x.CreatedBy);

        }

        public int GetCoursesCount()
        {
            return base.GetQuery().Count();
        }
    }
}
