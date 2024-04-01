using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //TODO: use Repository & UnitOfWork if we want to avoid dependency on Microsoft.EntityFrameworkCore
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task Migrate();
    }
}
