using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Teachers.Commands.Update;
using PastExamsHub.Core.Application.Teachers.Queries.GetCollection;
using PastExamsHub.Core.Application.Teachers.Queries.GetSingle;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TeachersController : ApiController
    {
        public TeachersController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetTeachersQueryResult>> GetCollection([FromQuery] GetTeachersQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetTeacherQueryResult>> GetSingle(string uid, [FromQuery] GetTeacherQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult<UpdateTeacherCommandResult>> Update(string uid, UpdateTeacherCommand command)
        {

            command.UserUid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(command);

            return Ok(result);
        }



    }
}
