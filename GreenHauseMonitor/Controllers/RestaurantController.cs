using Cmms.Models;
using Cmms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cmms.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto restaurantDto)
        {
            var id = _service.Create(restaurantDto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User")]

        public ActionResult<PagedResult<RestaurantDto>> GetAll([FromQuery] RestaurantQuery restaurantQuery)
        {
            return Ok(_service.GetAll(restaurantQuery));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AtLeast18")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _service.GetById(id);
            return Ok(restaurant);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        //[AllowAnonymous] aby działął bez autoryzacji
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateRestaurantDto updateRestaurant)
        {
            _service.Update(id, updateRestaurant);
            return NoContent();
        }
    }
}
