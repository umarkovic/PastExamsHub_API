using MediatR;
using Microsoft.Extensions.Logging;
using PastExamsHub.Base.Application.Common.Interfaces;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        //private readonly IIdentityService _identityService;

        public PerformanceBehaviour(
            ILogger<TRequest> logger, 
            ICurrentUserService currentUserService)
            //IIdentityService identityService
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
            //_identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserUid ?? string.Empty;
                var userName = string.Empty;

                /*
                if (!string.IsNullOrEmpty(userId))
                {
                    userName = await _identityService.GetUserNameAsync(userId);
                }
                */

                //TODO: calling assembly name
                _logger.LogWarning(
                    "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}", //{@UserName}                                                                                                                                  
                    requestName, 
                    elapsedMilliseconds, 
                    userId, 
                    //userName, 
                    request
                );
            }

            return response;
        }
    }
}
