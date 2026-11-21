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

        // [HttpGet("{id:int:range(1,10)}")]
        // [HttpGet("{id:string:alpha(1)}")]

        [HttpGet("{id:int:min(1)}")]
        public IActionResult GetRestaurantById(int id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);



        }



        [HttpGet("byName/{name}")]
        public IActionResult GetRestaurantByName(string name)
        {
            var restaurant = _restaurantService.GetByName(name);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);



        }


        //[HttpGet()]
        //public IActionResult GetAllestaurants([FromQuery] RestaurantQuery query)
        //{
        //    var restaurants = _restaurantService.GetAll(query);
        //    var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();
        //    return Ok(restaurantDTOs);



        //}

        [HttpGet()]
        public IActionResult GetAllestaurants([FromQuery] RestaurantQuery query)
        {
            var restaurants = _restaurantService.GetAll(query);
            
            return Ok(restaurants);



        }

        [HttpGet("active")]
        public IActionResult GetAllActiveestaurants()
        {
            var restaurants = _restaurantService.GetAllActive();
            var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();
            return Ok(restaurantDTOs);



        }
    }
}
