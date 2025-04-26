using AutoMapper;
using Cmms.Api.Filters;
using Cmms.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Cmms.Queries.EquipmentSetQueries;
using Cmms.Core.Queries.EquipmentSetQueries;
using Cmms.Respones.EquipmentSetResponse;
using Cmms.Requests.EquipmentSet;
using Cmms.Core.Commands.EquipmentSetCommands;

namespace Cmms.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize]
    public class EquipmentSetController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EquipmentSetController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetEquipmentSetListQuery());
            var EquipmentSets = _mapper.Map<List<EquipmentSetResponse>>(response.Payload);
            return Ok(EquipmentSets);
        }
        
        [HttpGet]
        [Route(ApiRoutes.EquipmentSets.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetEquipmentSetById(string id, CancellationToken cancellationToken)
        {
            var query = new GetEquipmentSetByIdQuery(Guid.Parse(id));
            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError)
                return HandleErrorResponse(response.ErrorList);

            var equipmentSetResponse = _mapper.Map<EquipmentSetResponse>(response.Payload);
            return Ok(equipmentSetResponse);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateEquipmentSet([FromBody] EquipmentSetCreate EquipmentSetCreate)
        {
            var command = _mapper.Map<CreateEquipmentSetCommand>(EquipmentSetCreate);
            command.CreatedByUserID = GetUserProfileIdClaimValue(HttpContext);
            var result = await _mediator.Send(command);
            var EquipmentSet = _mapper.Map<EquipmentSetResponse>(result.Payload);
            return CreatedAtAction(nameof(GetEquipmentSetById), new { id = result.Payload.Id }, EquipmentSetCreate);
        }

        [HttpPatch]
        [Route(ApiRoutes.EquipmentSets.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> Update(string id, [FromBody] EquipmentSetUpdate EquipmentSetDto)
        {
            var command = _mapper.Map<UpdateEquipmentSetCommand>(EquipmentSetDto);
            command.Id = Guid.Parse(id);
            command.UpdateByUserID = GetUserProfileIdClaimValue(HttpContext);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.EquipmentSets.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCommand = new DeleteEquipmentSetCommand() { Id = Guid.Parse(id), DeletingByUserID = GetUserProfileIdClaimValue(HttpContext) };
            var response = await _mediator.Send(deleteCommand);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }
    }
}
