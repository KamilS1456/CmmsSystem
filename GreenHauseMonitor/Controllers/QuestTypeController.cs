using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cmms.Filters;
using System.Threading;

using System;

using Cmms.Api.Filters;
using Cmms.Queries.QuestTypeQueries;
using Cmms.Core.Queries.QuestTypeQueries;
using Cmms.Respones.QuestTypeResponse;
using Cmms.Requests.QuestType;
using Cmms.Core.Commands.QuestTypeCommand;


namespace Cmms.Controllers
{

    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class QuestTypeController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public QuestTypeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetQuestTypeListQuery());
            var questTypes = _mapper.Map<List<QuestTypeResponse>>(response.Payload);
            return Ok(questTypes);
        }

        [HttpGet]
        [Route(ApiRoutes.QuestTypes.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetQuestTypeById(string id, CancellationToken cancellationToken)
        {
            var query = new GetQuestTypeByIdQuery(Guid.Parse(id));
            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError)
                return HandleErrorResponse(response.ErrorList);

            var QuestTypeResponse = _mapper.Map<QuestTypeResponse>(response.Payload);
            return Ok(QuestTypeResponse);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateQuestType([FromBody] QuestTypeCreate questTypeCreate)
        {
            var command = _mapper.Map<CreateQuestTypeCommand>(questTypeCreate);
            command.CreatedByUserID = GetUserProfileIdClaimValue(HttpContext);
            var result = await _mediator.Send(command);
            var questType = _mapper.Map<QuestTypeResponse>(result.Payload);
            return CreatedAtAction(nameof(GetQuestTypeById), new { id = result.Payload.Id }, questTypeCreate);
        }

        [HttpPatch]
        [Route(ApiRoutes.QuestTypes.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> Update(string id, [FromBody] QuestTypeUpdate QuestTypeDto)
        {
            var command = _mapper.Map<UpdateQuestTypeCommand>(QuestTypeDto);
            command.Id = Guid.Parse(id);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }


        [HttpDelete]
        [Route(ApiRoutes.QuestTypes.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCommand = new DeleteQuestTypeCommand() { Id = Guid.Parse(id) };
            var response = await _mediator.Send(deleteCommand);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();

        }

        
    }
}
