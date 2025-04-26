using AutoMapper;
using Cmms.Api.Filters;
using Cmms.Core.Commands.IdentityCommands;
using Cmms.DtoModels;
using Cmms.Filters;
using Cmms.Requests.Identity;
using Cmms.Respones.IdentityResponse;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cmms.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IdentityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Registration)]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] UserRegistration registration, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<RegisterIdentityCommand>(registration);
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.ErrorList);

            return Ok(_mapper.Map<IdentityUserProfile>(result.Payload));
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Login)]
        [ValidateModel]
        public async Task<IActionResult> Login(Login login, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(login);
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.ErrorList);

            return Ok(_mapper.Map<IdentityUserProfile>(result.Payload));
        }

        [HttpDelete]
        [Route(ApiRoutes.Identity.IdentityById)]
        [ValidateGuid("identityUserId")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount(string identityUserId, CancellationToken token)
        {
            var identityUserGuid = Guid.Parse(identityUserId);
            var requestorGuid = GetIdentityIdClaimValue(HttpContext);
            var command = new RemoveAccountCommand
            {
                IdentityUserIdToDelete = identityUserGuid,
                UserProfileIdRequestingDelete = requestorGuid
            };
            var result = await _mediator.Send(command, token);

            if (result.IsError) return HandleErrorResponse(result.ErrorList);

            return NoContent();
        }
    }
}