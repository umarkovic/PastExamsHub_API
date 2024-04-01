using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Application.Exams.Queries.GetLatestExams;
using PastExamsHub.Core.Application.Statistics.Queries.GetStatistics;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class StatisticsController : ApiController
    {
        public StatisticsController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetStatisticsQueryResult>> GetStatistics([FromQuery] GetStatisticsQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }       
    }
}

