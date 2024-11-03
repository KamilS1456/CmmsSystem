using Cmms.Entities;
using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Controllers
{
    [Route("api/occurrence")]
    [ApiController]
    //[Authorize]
    public class OccurrenceController : ControllerBase
    {
        private readonly IOccurrenceService _service;

        public OccurrenceController(IOccurrenceService service)
        {
            _service = service;
        }

        [HttpPost]
       // [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateOccurrence([FromBody] OccurrenceDto restaurantDto)
        {
            var id = _service.Create(restaurantDto);
            return Created($"/api/occurrence/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager,User")]

        public ActionResult<List<OccurrenceDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "AtLeast18")]
        public ActionResult<OccurrenceDto> Get([FromRoute] int id)
        {
            var occurrence = _service.GetById(id);
            return Ok(occurrence);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateOccurrenceDto updateOccurrence)
        {
            _service.Update(id, updateOccurrence);
            return NoContent();
        }
    }
}
