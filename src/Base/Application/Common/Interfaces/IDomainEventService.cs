using PastExamsHub.Base.Domain.Common;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
