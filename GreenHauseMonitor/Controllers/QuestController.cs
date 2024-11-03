using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Controllers
{

    [Route("api/quest")]
    [ApiController]
    //[Authorize]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService _service;
        public QuestController(IQuestService service)
        {
            _service = service;
        }


        //[HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        //public ActionResult CreateRestaurant([FromBody] CreateQuestDto questDto)
        //{
        //    var id = _service.(questDto);
        //    return Created($"/api/quest/{id}", null);
        //}

        [HttpGet("{id}")]
        public ActionResult<QuestDto> Get([FromRoute] int id)
        {
            var quest = _service.GetById(id);
            return Ok(quest);
        }

        [HttpGet]
        public ActionResult<List<QuestDto>> GetAll()
        {
            var questList = _service.GetAll();
            return Ok(questList);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public ActionResult Update([FromRoute] int id, [FromBody] QuestDto questDto)
        {
            _service.Update(id, questDto);
            return NoContent();
        }
    }
}
