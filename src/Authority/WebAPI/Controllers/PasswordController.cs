using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Authority.Application.Password.Command.ForgotPassword;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;

namespace PastExamsHub.Authority.WebAPI.Controllers
{
    [Authorize]
    public class PasswordController : ApiController
    {
        public PasswordController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
        : base(mediator, currentUserService) 
        { 
        }

        [HttpPost(nameof(Forgot))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Forgot(ForgotPasswordCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost(nameof(Reset))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Reset(ResetPasswordCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
