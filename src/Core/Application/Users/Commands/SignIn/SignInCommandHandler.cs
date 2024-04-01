
using MediatR;
using Microsoft.Extensions.Configuration;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Users.Commands.SignIn
{
    public class SignInCommandHandler : INotificationHandler<SignInCommand> 
    {
        readonly IMediator Mediator;
        readonly IUsersRepository UsersRepository;
        readonly ICurrentUserService CurrentUserService;
        readonly ICoreDbContext DbContext;
        public SignInCommandHandler
        (
            IMediator mediator,

            IUsersRepository usersRepository,
            ICurrentUserService currentUserService,
            ICoreDbContext dbContext,
            IConfiguration configuration
        )
        {
            Mediator = mediator;
            CurrentUserService = currentUserService;
            UsersRepository = usersRepository;
            DbContext = dbContext;



        }


        public async Task Handle(SignInCommand command, CancellationToken cancellationToken)
        {
            //Handler for users login 
            var currentUser = CurrentUserService.ApplicationUser;
            var user = await UsersRepository.GetByEmailAsync(command.Email, cancellationToken);

            if(user == null)
            {
                    user = new User
                    {
                        Uid = CurrentUserService.UserUid,
                        Email = CurrentUserService.ApplicationUser.Email,
                        FirstName = CurrentUserService.ApplicationUser.FirstName,
                        LastName = CurrentUserService.ApplicationUser.LastName,
                        FullName = CurrentUserService.ApplicationUser.FirstName + " " + CurrentUserService.ApplicationUser.LastName,
                        Role = CurrentUserService.ApplicationUser.Role

                    };

                    UsersRepository.Insert(user);
                    await DbContext.SaveChangesAsync(cancellationToken);
                
            }

        }

    }
}
