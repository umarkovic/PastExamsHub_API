using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Application.Common.Interfaces
{
    public interface IAuthorityDbContext : IApplicationDbContext
    {
    }
}
