using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.ExamPeriods.Command.Create;
using PastExamsHub.Core.Application.ExamPeriods.Command.Delete;
using PastExamsHub.Core.Application.ExamPeriods.Command.Update;
using PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection;
using PastExamsHub.Core.Application.ExamPeriods.Queries.GetSingle;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Application.Exams.Queries.GetLatestExams;
using PastExamsHub.Core.Application.Exams.Queries.GetSingle;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ExamsController : ApiController
    {
        public ExamsController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetExamsQueryResult>> GetCollection([FromQuery] GetExamsQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }



        [HttpPost("upload")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<ActionResult<CreateExamCommandResult>> Create([FromQuery] CreateExamCommand command)
        {
            command.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpGet("LatestExams")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetLatestExamsQueryResult>> GetLatestExams([FromQuery] GetLatestExamsQuery request)
        {
            request.UserUid = CurrentUserService.UserUid;
            var result = await Mediator.Send(request);

            return Ok(result);
        }
        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetExamQueryResult>> GetSingle(string uid, [FromQuery] GetExamQuery request)
        {
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        //[HttpPut("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        //public async Task<ActionResult<UpdateExamPeriodCommandResult>> Update(string uid, UpdateExamPeriodCommand command)
        //{

        //    command.Uid = WebUtility.UrlDecode(uid);
        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}


        //[HttpDelete("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        //public async Task<ActionResult<DeleteExamPeriodCommandResult>> Delete(string uid, DeleteExamPeriodCommand command)
        //{
        //    command.Uid = WebUtility.UrlDecode(uid);

        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}
    }
}

