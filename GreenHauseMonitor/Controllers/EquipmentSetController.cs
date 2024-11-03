using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Controllers
{
    [Route("api/equipmentset")]
    [ApiController]
    //[Authorize]
    public class EquipmentSetController : ControllerBase
    {
        private readonly IEquipmentSetService _service;

        public EquipmentSetController(IEquipmentSetService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] EquipmentSetDto equipmentSetDto)
        {
            var id = _service.Create(equipmentSetDto);
            return Created($"/api/equipmentset/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager,User")]

        public ActionResult<List<EquipmentSetDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "AtLeast18")]
        public ActionResult<EquipmentSetDto> Get([FromRoute] int id)
        {
            var equipmentSet = _service.GetById(id);
            return Ok(equipmentSet);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateEquipmentSetDto updateEquipmentSet)
        {
            _service.Update(id, updateEquipmentSet);
            return NoContent();
        }
    }
}
