using PastExamsHub.Base.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.WebAPI.SignalR
{
    public class Hub<TClient> : Microsoft.AspNetCore.SignalR.Hub<TClient> 
        where TClient : class
    {
        protected readonly ICurrentUserService CurrentUserService;
        protected readonly IConnectionStorage ConnectionStorage;

        public Hub
        (
            ICurrentUserService currentUserService,
            IConnectionStorage connectionStorage
        )
        {
            CurrentUserService = currentUserService;
            ConnectionStorage = connectionStorage;
        }

        public string UserUid => Context.User.Identity.Name;

        public override async Task OnConnectedAsync()
        {
            ConnectionStorage.Add(UserUid, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ConnectionStorage.Remove(UserUid, Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
