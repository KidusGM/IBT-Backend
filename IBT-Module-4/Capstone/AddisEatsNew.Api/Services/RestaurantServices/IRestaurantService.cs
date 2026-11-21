using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;

namespace AddisEatsNew.Api.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        Restaurant? GetById(int id);
        Restaurant? GetByName(string name);

        //PaginatedResultDTO GetAll(RestaurantQuery query);
        PaginatedResultDTO GetAll(RestaurantQuery query);
        List<Restaurant> GetAllActive();


    }
}