using PastExamsHub.Base.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Behaviours
{
    //TODO: watch performance
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage?view=aspnetcore-3.1
    //https://github.com/aspnet/SignalR/wiki/Diagnostics-Guide
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        //private readonly IIdentityService _identityService;

        public LoggingBehaviour(
            ILogger<TRequest> logger, 
            ICurrentUserService currentUserService)
            //IIdentityService identityService
        {
            _logger = logger;
            _currentUserService = currentUserService;
            //_identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserUid ?? string.Empty;
            string userName = string.Empty;

            /*
            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }
            */

            //TODO: calling assembly name
            _logger.LogInformation(
                "Request: {Name} {@UserId} {@Request}",//{@UserName}
                requestName, 
                userId, 
                //userName, 
                request
            );
        }
    }
}
