using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface ICoursesRepository : IBaseRepository<Course>
    {
        int GetCoursesCount();
    }
}
