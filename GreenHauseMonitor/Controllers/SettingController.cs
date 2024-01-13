using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cmms.Controllers
{
    [Route("api/setting")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _service;
        public SettingController(ISettingService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SettingDto>> GetAll()
        {
            var settingList= _service.GetAll();
            return Ok(settingList);
        }

        [HttpGet("{id}")]
        public ActionResult<SettingDto> Get([FromRoute] int id)
        {
           var setting = _service.GetSettingById(id);
           return Ok(setting);
        }

    }
}
