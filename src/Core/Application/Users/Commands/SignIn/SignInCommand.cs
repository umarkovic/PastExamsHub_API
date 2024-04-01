using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Users.Commands.SignIn
{
    public class SignInCommand : INotification
    {
        [OpenApiExclude]
        public string UserUid { get; set; }
        public string Email { get; set; }
    }
}
