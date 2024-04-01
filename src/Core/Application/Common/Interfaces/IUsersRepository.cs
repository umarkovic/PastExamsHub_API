using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Core.Domain.Entities;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
        int GetStudentsCount();
        int GetTeachersCount();
    }
}
