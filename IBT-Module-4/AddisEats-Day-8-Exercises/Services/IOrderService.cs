using AddisEats_Day_5_RestaurantService.Models;

namespace AddisEats_Day_5_RestaurantService.Services;

public interface IOrderService
{
    Result<Order> Place(CreateOrderRequest request);
}
