using AddisEats_Day_5_RestaurantService.Models;

namespace AddisEats_Day_5_RestaurantService.Services
{

    public interface IRestaurantService
    {
        List<Restaurant> Search(string? area, int page, int limit);

        Restaurant? GetById(int id);

        List<MenuItem> GetMenu(int restaurantId);

        int Count(string? area);
    }
}
