
using AddisEats_Day_5_RestaurantService.Models;
using AddisEats_Day_5_RestaurantService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats_Day_5_RestaurantService.Controllers
{
    [ApiController]
    [Route("api/v1/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IActionResult GetRestaurants(
            string? area,
            int page = 1,
            int limit = 5)
        {
            if (page < 1 || limit < 1)
            {
                return BadRequest("Page and limit must be greater than 0.");
            }

            var restaurants = _restaurantService
                .Search(area, page, limit)
                .Select(r => r.ToDto())
                .ToList();

            return Ok(new
            {
                Page = page,
                Limit = limit,
                Total = _restaurantService.Count(area),
                Restaurants = restaurants
            });
        }

        // Exercise 2:
        // Route parameter is restaurantId, but method parameter is id.
        [HttpGet("{restaurantId:int}/menu")]
        public IActionResult GetRestaurantMenu(int id)
        {
            var restaurant = _restaurantService.GetById(id);

            if (restaurant == null)
            {
                return NotFound(new
                {
                    Message = "Restaurant not found."
                });
            }

            var menu = _restaurantService.GetMenu(id);

            return Ok(menu);
        }
    }
}
