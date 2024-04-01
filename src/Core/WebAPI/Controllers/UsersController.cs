using PastExamsHub.Core.Application.Users.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Base.WebAPI.Services;
using PastExamsHub.Core.Application.Common.Users.Queries.GetCollection;
using System.Net;
using System.Threading.Tasks;
using PastExamsHub.Core.Application.Users.Commands.Update;
using Microsoft.AspNetCore.Authorization;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ApiController
    {
        public UsersController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetUsersQueryResult>> GetCollection([FromQuery] GetUsersQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetUserQueryResult>> GetSingle(string uid, [FromQuery] GetUserQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult<UpdateUserCommandResult>> Update(string uid, UpdateUserCommand command)
        {

            command.UserUid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(command);

            return Ok(result);
        }



    }
}

