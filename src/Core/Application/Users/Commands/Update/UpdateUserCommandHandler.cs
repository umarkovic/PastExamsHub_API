using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Base.Domain.Enums;

namespace PastExamsHub.Core.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResult>
    {
        readonly IUsersRepository UserRepository;
        readonly ICoreDbContext DbContext;

        public UpdateUserCommandHandler
        (
            IUsersRepository userRepository,
            ICoreDbContext dbContext
        )
        {
            UserRepository = userRepository;
            DbContext = dbContext;

        }

        public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var destination = await UserRepository.GetByUidAsync(command.UserUid, cancellationToken);

            if (destination == null)
            {
                throw new NotFoundException();
            }

            var source = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender,
                StudyYear = command.StudyYear,
                Index = command.Index

            };

            switch(destination.Role)
            {
                case RoleType.Student:
                    destination.UpdateStudent(source);
                    break;

                case RoleType.Teacher:
                    destination.UpdateLecturer(source);
                    break;
            }

            //UserRepository.Update(destination);
            await DbContext.SaveChangesAsync(cancellationToken);

            return new UpdateUserCommandResult { Uid = destination.Uid};
        }
    }
}
