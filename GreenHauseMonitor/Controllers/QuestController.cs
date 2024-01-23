using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Controllers
{

    [Route("api/quest")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService _service;
        public QuestController(IQuestService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public ActionResult<QuestDto> Get([FromRoute] int id)
        {
            var setting = _service.GetQuestById(id);
            return Ok(setting);
        }

    }
}
