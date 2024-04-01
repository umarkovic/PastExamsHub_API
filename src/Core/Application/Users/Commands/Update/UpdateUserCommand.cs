using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PastExamsHub.Core.Application.Users.Commands.Update
{
    //REVIEW: Create and Update can use the same base class?
    public class UpdateUserCommand : IRequest<UpdateUserCommandResult>
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Index { get; set; }
        public int? StudyYear { get; set; }
        public GenderType Gender { get; set; }

    }
}
