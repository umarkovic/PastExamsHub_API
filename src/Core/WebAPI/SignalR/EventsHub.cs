using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.AccessTokenValidation;
using PastExamsHub.Base.WebAPI.SignalR;
using PastExamsHub.Base.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PastExamsHub.Core.Application.Common.Interfaces;

namespace PastExamsHub.Core.WebAPI.SignalR
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class EventsHub : Hub<IPushEventHandlers>
    {
        readonly IMediator Mediator;
        private readonly ILogger<EventsHub> Logger;
        private readonly IInMemoryConnectionStorage<string> MemoryConnectionStorage;

        public EventsHub
        (
            ICurrentUserService currentUserService,
            IConnectionStorage connectionStorage,
            IMediator mediator,
            IInMemoryConnectionStorage<string> memoryConnectionStorage,
            ILogger<EventsHub> logger
        )
            : base(currentUserService, connectionStorage)
        {
            Mediator = mediator;
            MemoryConnectionStorage = memoryConnectionStorage;
            Logger = logger;
        }

       

        //https://docs.microsoft.com/en-us/aspnet/signalr/overview/security/hub-authorization
        public override async Task OnConnectedAsync()
        {
            Logger.LogInformation("On connected event fired!------------------");

            try
            {
                await base.OnConnectedAsync();

                //Logic for adding to groups and memory connection storage usage

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured!________________");
                throw;
            }          
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Logger.LogInformation("On disconnected event fired!/////////////////");

            try
            {
                await base.OnDisconnectedAsync(exception);

                //Logic for removing from groups and memory connection storage usage
            }
            catch (Exception ex)
            {               
                Logger.LogError(ex, "Error occured!________________");
                throw;              
            }
        }
    }
}
