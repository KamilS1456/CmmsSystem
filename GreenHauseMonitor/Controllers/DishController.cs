using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Controllers
{
    [Route("api/restaurant/{restaurantid}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantid, [FromBody] CreateDishDto dto)
        {
            int dishId = _dishService.Create(restaurantid, dto);
            return Created($"api/restaurant/{restaurantid}/dish/{dishId}", null);
        }
        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantid, [FromRoute] int dishId)
        {
            return Ok(_dishService.GetById(restaurantid, dishId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> Get([FromRoute] int restaurantid)
        {
            return Ok(_dishService.GetAll(restaurantid));
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int restaurantid)
        {
            _dishService.DeleteAll(restaurantid);
            return Ok();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteById([FromRoute] int restaurantid, [FromRoute] int dishId)
        {
            _dishService.DeleteById(restaurantid, dishId);
            return Ok();
        }
    }
}
