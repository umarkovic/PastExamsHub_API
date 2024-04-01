using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Courses.Commands.Create;
using PastExamsHub.Core.Application.Courses.Commands.Delete;
using PastExamsHub.Core.Application.Courses.Commands.Update;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using PastExamsHub.Core.Application.Courses.Queries.GetSingle;
using PastExamsHub.Core.Application.ExamPeriods.Command.Delete;
using PastExamsHub.Core.Application.Users.Commands.Update;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CoursesController : ApiController
    {
       
        public CoursesController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetCoursesQueryResult>> GetCollection([FromQuery] GetCoursesQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetCourseQueryResult>> GetSingle(string uid, [FromQuery] GetCourseQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Create(CreateCourseCommand command)
        {
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult<UpdateCourseCommandResult>> Update(string uid, UpdateCourseCommand command)
        {
            command.UserUid = CurrentUserService.UserUid;
            command.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<DeleteCourseCommandResult>> Delete(string uid, DeleteCourseCommand command)
        {
            command.Uid = WebUtility.UrlDecode(uid);
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }


    }
}
