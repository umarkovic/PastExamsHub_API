using System.Threading.Tasks;
using IdentityServer4.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Identity;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Authority.Application.Authentication.Commands.SignIn;
using PastExamsHub.Authority.Application.Authentication.Commands.SignOut;
using System;
using FluentValidation.Results;
using System.Collections.Generic;
using FluentValidation;
using PastExamsHub.Authority.Application.Authentication.Commands.SignUp;

namespace PastExamsHub.Authority.WebAPI.Controllers
{
    [Authorize]
    public class AuthenticationController : ApiController
    {
        public AuthenticationController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
        : base(mediator, currentUserService) 
        { 
        }

        [HttpPost(nameof(SignIn))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SignIn(SignInCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost(nameof(SignOut))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<SignOutCommandResult>> SignOut(SignOutCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost(nameof(SignUp))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SignUp(SignUpCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
