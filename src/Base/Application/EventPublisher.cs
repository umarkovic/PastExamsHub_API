using MediatR;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application
{
    public abstract class EventPublisher
    {
        internal readonly IMediator Mediator;

        internal EventPublisher(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
