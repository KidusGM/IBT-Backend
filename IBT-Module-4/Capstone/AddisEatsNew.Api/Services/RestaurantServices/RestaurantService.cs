
using AddisEatsNew.Api.Models;
using AddisEatsNew.Api.Data;

namespace AddisEatsNew.Api.Services.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly List<Restaurant> allrestaurant = SeedData.restaurants;

        public Restaurant? GetById(int id)
        {
            return allrestaurant.Where(r => r.Id == id).FirstOrDefault();
        }

        public Restaurant? GetByName(string name)
        {
            return allrestaurant.Where(r => r.Name == name).FirstOrDefault();
        }

        public List<Restaurant> GetAll(string? address, int page, int pageSize)
        {
            var restaurant = allrestaurant
                .Where(r => address == null || r.Address == address)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return restaurant;
        }

        public List<Restaurant> GetAllActive()
        {
            var restaurant = allrestaurant
                .Where(r => r.IsActive == true)
               .OrderBy(r=>r.Name)
                .ToList();

            return restaurant;
        }
    }
}
