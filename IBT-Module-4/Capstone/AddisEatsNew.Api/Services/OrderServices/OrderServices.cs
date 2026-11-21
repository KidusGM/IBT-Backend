using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
namespace AddisEatsNew.Api.Services.OrderServices;


    public class OrderServices : IOrderServices
{
        private static readonly List<Order> _orders = new List<Order>();
    private static int _nextId = 1;



        public Order? GetById(int id)
        {
            var order = _orders.Where(o => o.Id == id).FirstOrDefault();
        return order;
        }

        public Order CreateOrder(CreateOrderDTO createDTO)
        {
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
        return o;
        }
    }
