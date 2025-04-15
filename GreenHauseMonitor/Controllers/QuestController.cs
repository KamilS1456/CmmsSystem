using Cmms.Domain.Entities;
using Cmms.Core.Models;
using Cmms.Core.Queries.QuestQueries;
using Cmms.Queries.QuestQueries;
using Cmms.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cmms.Controllers
{

    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    //[Authorize]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService _service;
        private readonly IMediator _mediator;
        public QuestController(IQuestService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Quests.GetById)]
        public async Task<Quest> GetById([FromRoute] int id)
        {
            //var quest = _service.GetById(id);
            return await _mediator.Send(new GetQuestByIdQuery(id));
        }

        [HttpGet]
        public async Task<List<Quest>> GetAll()
        {
           return await _mediator.Send(new GetQuestListQuery());
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
