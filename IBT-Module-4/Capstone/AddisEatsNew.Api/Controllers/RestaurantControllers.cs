using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Mappers;
using AddisEatsNew.Api.Models;
using AddisEatsNew.Api.Services.MenuItemServices;
using AddisEatsNew.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;
namespace AddisEatsNew.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestaurantControllers : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantControllers(IRestaurantService restaurantService)

        {
            _restaurantService = restaurantService;
        }


        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);



        }


        [HttpGet()]
        public IActionResult GetAllestaurants([FromQuery] string? address, [FromQuery] int page=1, [FromQuery] int pageSize=3)
        {
            var restaurants = _restaurantService.GetAll(address, page, pageSize);
            var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();
            return Ok(restaurantDTOs);



        }
    }
}
