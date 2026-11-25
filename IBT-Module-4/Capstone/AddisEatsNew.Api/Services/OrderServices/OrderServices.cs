using AddisEatsNew.Api.Common;
using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
using AddisEatsNew.Api.Services.RestaurantServices;
namespace AddisEatsNew.Api.Services.OrderServices;


    public class OrderServices : IOrderServices
{
        private static readonly List<Order> _orders = new List<Order>();
    private static int _nextId = 1;

    private readonly IRestaurantService _restaurantService;
    public OrderServices(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }



        public Order? GetById(int id)
        {
            var order = _orders.Where(o => o.Id == id).FirstOrDefault();
        return order;
        }

        public Result<Order> CreateOrder(CreateOrderDTO createDTO)
        {
        var restaurant = _restaurantService.GetById(createDTO.RestaurantId);
        if (restaurant is null)
        {
            return Result<Order>.Fail("RESTAURANT_NOT_FOUND", "The selected restaurant is not avaliable", 404);
        }

        if (!restaurant.IsActive)
        {
            return Result<Order>.Fail("RESTAURANT_NOT_ACRIVE", "The selected another", 409);
        }
        Order o = new Order
           {
               Id = _nextId++,
               RestaurantId = createDTO.RestaurantId,
               MenuItemId = createDTO.MenuItemId,
               CustomerName = createDTO.CustomerName,
               DeliveryAddress = createDTO.DeliveryAddress,
               CustomerPhone = createDTO.CustomerPhone,
               Quantity = createDTO.Quantity,
               TotalAmount = createDTO.TotalAmount,

           };
    _orders.Add(o);
        return Result<Order>.Ok(o);
        }
    }
