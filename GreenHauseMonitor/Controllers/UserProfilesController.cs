
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Respones.UserProfileResponse;
using System.Threading;
using System;
using Cmms.Core.Queries.UserProfilesQueries;
using System.Linq;
using Cmms.Requests.UserProfileRequests;
using Cmms.Respones.Common;

namespace Cmms.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllUserProfilesQuery());
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }

        
        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id, CancellationToken cancellationToken)
        {
            var query = new GetUserProfileByIdQuery { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query, cancellationToken);

            if (response is null) {
                return NotFound();
            }
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            
            //if (response.IsError)
            //    return HandleErrorResponse(response.Errors);

            //var userProfile = UserProfileResponse.FromUserProfileDto(response.Payload);
            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate userProfile)
        {
            var command = _mapper.Map<CreateUserProfileCommand>(userProfile);
            var result = await _mediator.Send(command);
            var userProfileResponse = _mapper.Map<UserProfileResponse>(result);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = result.UserProfileId}, userProfile);
        }


        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] UserProfileUpdate basicInfo)
        {
            var command = _mapper.Map<UpdateUserProfileCommand>(basicInfo);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)] 
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var deleteCommand = new DeleteUserProfileCommand() {UserProfileId = Guid.Parse(id) };
            await _mediator.Send(deleteCommand);

            return NoContent();
        }


    }
}
