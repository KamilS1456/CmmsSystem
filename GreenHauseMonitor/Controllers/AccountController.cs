using Cmms.Models;
using Cmms.Models.Respones;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            LoginRespone token = _service.Login(dto);
            return Ok(token);
        }

        [HttpPost("refreshToken")]
        public ActionResult RefreshToken ([FromBody] RefreshTokenModel model)
        {
            LoginRespone token = _service.RefreshToken(model);
            return Ok(token);
        }

        [HttpDelete("login")]
        [Authorize(Roles = "Admin")]
        public ActionResult Login([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
