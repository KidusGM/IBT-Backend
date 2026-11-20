using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;

namespace AddisEatsNew.Api.Mappers
{
    public  static class RestaurantMapper
    {
        public static RestaurantDTO ToDTO(this Restaurant restaurant)
        {
            return new RestaurantDTO(
                restaurant.Id,
                restaurant.Name,
                restaurant.Address,
                restaurant.Phone,
                restaurant.IsActive

                );
        }
    }
}
