using Cmms.Core.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cmms.Controllers
{
    [Route("api/equipment")]
    [ApiController]
   // [Authorize]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> CreateEquipment([FromBody] EquipmentDto equipmentDto)
        {
            var id = _service.Create(equipmentDto);
            return Created($"/api/equipment/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager,User")]

        public async Task<ActionResult<List<EquipmentDto>>> GetAll()
        {
            var allEquipment = _service.GetAll();
            return Ok(allEquipment);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "AtLeast18")]
        public async Task<ActionResult<EquipmentDto>> Get([FromRoute] int id)
        {
            var equipment =  _service.GetById(id);
            return Ok(equipment);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateEquipmentDto updateEquipment)
        {
            _service.Update(id, updateEquipment);
            return NoContent();
        }
    }
}
