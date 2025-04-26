using AutoMapper;
using Cmms.Api.Filters;
using Cmms.Core.Commands.EquipmentCommands;
using Cmms.Core.Queries.EquipmentQueries;
using Cmms.Filters;
using Cmms.Queries.EquipmentQueries;
using Cmms.Requests.Equipment;
using Cmms.Respones.EquipmentResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cmms.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize]
    public class EquipmentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EquipmentController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetEquipmentListQuery());
            var Equipments = _mapper.Map<List<EquipmentResponse>>(response.Payload);
            return Ok(Equipments);
        }

        [HttpGet]
        [Route(ApiRoutes.Equipments.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetEquipmentById(string id, CancellationToken cancellationToken)
        {
            var query = new GetEquipmentByIdQuery(Guid.Parse(id));
            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError)
                return HandleErrorResponse(response.ErrorList);

            var equipmentResponse = _mapper.Map<EquipmentResponse>(response.Payload);
            return Ok(equipmentResponse);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentCreate EquipmentCreate)
        {
            var command = _mapper.Map<CreateEquipmentCommand>(EquipmentCreate);
            command.CreatedByUserID = GetUserProfileIdClaimValue(HttpContext);
            var result = await _mediator.Send(command);
            var Equipment = _mapper.Map<EquipmentResponse>(result.Payload);
            return CreatedAtAction(nameof(GetEquipmentById), new { id = result.Payload.Id }, EquipmentCreate);
        }

        [HttpPatch]
        [Route(ApiRoutes.Equipments.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> Update(string id, [FromBody] EquipmentUpdate EquipmentDto)
        {
            var command = _mapper.Map<UpdateEquipmentCommand>(EquipmentDto);
            command.Id = Guid.Parse(id);
            command.UpdateByUserID = GetUserProfileIdClaimValue(HttpContext);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Equipments.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCommand = new DeleteEquipmentCommand() { Id = Guid.Parse(id), DeletingByUserID = GetUserProfileIdClaimValue(HttpContext) };
            var response = await _mediator.Send(deleteCommand);

            return response.IsError ? HandleErrorResponse(response.ErrorList) : NoContent();
        }
    }
}
