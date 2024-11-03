using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult CreateEquipment([FromBody] EquipmentDto equipmentDto)
        {
            var id = _service.Create(equipmentDto);
            return Created($"/api/equipment/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager,User")]

        public ActionResult<List<EquipmentDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "AtLeast18")]
        public ActionResult<EquipmentDto> Get([FromRoute] int id)
        {
            var equipment = _service.GetById(id);
            return Ok(equipment);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateEquipmentDto updateEquipment)
        {
            _service.Update(id, updateEquipment);
            return NoContent();
        }
    }
}
