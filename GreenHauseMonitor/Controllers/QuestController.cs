using Cmms.Core.Queries.QuestQueries;
using Cmms.Queries.QuestQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cmms.Filters;
using System.Threading;
using System;
using Cmms.Respones.QuestResponse;
using Cmms.Api.Filters;
using Cmms.Requests.Quest;
using Cmms.Core.Commands.QuestCommands;
using Microsoft.AspNetCore.Authorization;

namespace Cmms.Controllers
{

    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize]
    public class QuestController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public QuestController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetQuestListQuery());
            var quests = _mapper.Map<List<QuestResponse>>(response.Payload);
            return Ok(quests);
        }

        [HttpGet]
        [Route(ApiRoutes.Quests.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetQuestById(string id, CancellationToken cancellationToken)
        {
            var query = new GetQuestByIdQuery(Guid.Parse(id));
            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError)
                return HandleErrorResponse(response.ErrorList);

            var questResponse = _mapper.Map<QuestResponse>(response.Payload);
            return Ok(questResponse);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateQuest([FromBody] QuestCreate questCreate)
        {
            var command = _mapper.Map<CreateQuestCommand>(questCreate);
            command.CreatedByUserID = GetUserProfileIdClaimValue(HttpContext);
            var result = await _mediator.Send(command);
            var quest = _mapper.Map<QuestResponse>(result.Payload);
            return CreatedAtAction(nameof(GetQuestById), new { id = result.Payload.Id }, questCreate);
        }

        [HttpPatch]
        [Route(ApiRoutes.Quests.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> Update(string id, [FromBody] QuestUpdate questDto)
        {
            var command = _mapper.Map<UpdateQuestCommand>(questDto);
            command.Id = Guid.Parse(id);
            command.UpdateByUserID = GetUserProfileIdClaimValue(HttpContext);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Quests.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCommand = new DeleteQuestCommand() { Id = Guid.Parse(id), DeletingByUserID = GetUserProfileIdClaimValue(HttpContext) };
            var response = await _mediator.Send(deleteCommand);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }
    }
}
