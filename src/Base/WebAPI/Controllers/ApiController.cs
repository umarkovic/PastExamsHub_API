using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PastExamsHub.Base.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly ICurrentUserService CurrentUserService;

        public ApiController
        (
            IMediator mediator, 
            ICurrentUserService currentUserService
        )
        {
            Mediator = mediator;
            CurrentUserService = currentUserService;
        }
    }
}
