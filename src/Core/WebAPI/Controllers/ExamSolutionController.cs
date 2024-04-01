using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Courses.Commands.Delete;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Application.Exams.Queries.GetSingle;
using PastExamsHub.Core.Application.ExamSoultions.Commands.Create;
using PastExamsHub.Core.Application.ExamSoultions.Commands.Delete;
using PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection;
using PastExamsHub.Core.Application.ExamSoultions.Queries.GetSingle;
using PastExamsHub.Core.Application.Grades.Commands.Create;
using System.Net;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ExamSolutionController : ApiController
    {
        public ExamSolutionController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetExamSolutionsQueryResult>> GetCollection([FromQuery] GetExamSolutionsQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetExamSolutionQueryResult>> GetSingle(string uid, [FromQuery] GetExamSolutionQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }



        [HttpPost("upload")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<ActionResult<CreateExamSolutionCommandResult>> Create([FromQuery] CreateExamSolutionCommand command)
        {
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpPost("Grade")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<ActionResult<CreateGradeCommandResult>> Grade ([FromQuery] CreateGradeCommand command)
        {
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<DeleteExamSolutionCommandResult>> Delete(string uid, DeleteExamSolutionCommand command)
        {
            command.Uid = WebUtility.UrlDecode(uid);
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }


    }
}
