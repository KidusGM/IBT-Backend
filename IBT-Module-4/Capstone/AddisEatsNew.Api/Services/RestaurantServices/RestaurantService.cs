
using AddisEatsNew.Api.Data;
using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;

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

        public List<Restaurant> GetAll(RestaurantQuery query)
        {
            var restaurant = allrestaurant
                .Where(r => query.Address == null || r.Address == query.Address)
                 .Where(r => query.Name == null || r.Name == query.Name)
                  .Where(r => query.IsActive == null || r.IsActive == query.IsActive)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
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
