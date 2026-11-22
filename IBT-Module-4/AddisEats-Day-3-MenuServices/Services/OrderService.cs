using AddisEats_Day_3_MenuServices.Modeles;

namespace AddisEats_Day_3_MenuServices.Services
{
    public class OrderService
    {

        private readonly List<Order> _orders = new()
    {
        new Order
        {
            Id = 1,
            CustomerName = "Mimi",
            Area = "Bole",
            Amount = 650m,
            CreatedAt = DateTime.Today.AddDays(-1)
        },
        new Order
        {
            Id = 2,
            CustomerName = "Abel",
            Area = "Kazanchis",
            Amount = 400m,
            CreatedAt = DateTime.Today.AddDays(-3)
        },
        new Order
        {
            Id = 3,
            CustomerName = "Sara",
            Area = "Kazanchis",
            Amount = 750m,
            CreatedAt = DateTime.Today
        },
        new Order
        {
            Id = 4,
            CustomerName = "Dawit",
            Area = "Bole",
            Amount = 520m,
            CreatedAt = DateTime.Today.AddDays(-2)
        }
    };

        public List<Order> GetBoleOrdersOver500()
        {
            return _orders
                .Where(o => o.Area == "Bole" && o.Amount > 500m)
                .ToList();
        }

        public List<string> GetCustomerNames()
        {
            return _orders
                .Select(o => o.CustomerName)
                .OrderBy(name => name)
                .ToList();
        }

        public decimal GetKazanchisRevenue()
        {
            return _orders
                .Where(o => o.Area == "Kazanchis")
                .Sum(o => o.Amount);
        }

        public List<Order> GetPage(int pageNumber, int pageSize)
        {
            return _orders
                .OrderByDescending(o => o.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }

}




