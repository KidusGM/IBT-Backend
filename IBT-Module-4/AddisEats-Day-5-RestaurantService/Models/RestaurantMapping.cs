namespace AddisEats_Day_5_RestaurantService.Models
{

    public static class RestaurantMapping
    {
        public static RestaurantDto ToDto(this Restaurant restaurant)
        {
            return new RestaurantDto(
                restaurant.Id,
                restaurant.Name,
                restaurant.Area,
                restaurant.DeliveryFeeEtb
            );
        }
    }
}
