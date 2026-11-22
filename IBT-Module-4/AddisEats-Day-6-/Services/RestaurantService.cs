using AddisEats_Day_5_RestaurantService.Models;

namespace AddisEats_Day_5_RestaurantService.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly List<Restaurant> _restaurants = new()
        {
            new Restaurant { Id = 1, Name = "Bole Buna", Area = "Bole", DeliveryFeeEtb = 80, OwnerPhone = "0911000001", CommissionRate = 0.10m },
            new Restaurant { Id = 2, Name = "Bole Kitchen", Area = "Bole", DeliveryFeeEtb = 90, OwnerPhone = "0911000002", CommissionRate = 0.12m },
            new Restaurant { Id = 3, Name = "Habesha Taste", Area = "Bole", DeliveryFeeEtb = 75, OwnerPhone = "0911000003", CommissionRate = 0.10m },
            new Restaurant { Id = 4, Name = "Addis Grill", Area = "Bole", DeliveryFeeEtb = 100, OwnerPhone = "0911000004", CommissionRate = 0.15m },

            new Restaurant { Id = 5, Name = "Kazanchis Cafe", Area = "Kazanchis", DeliveryFeeEtb = 60, OwnerPhone = "0911000005", CommissionRate = 0.10m },
            new Restaurant { Id = 6, Name = "City Lunch", Area = "Kazanchis", DeliveryFeeEtb = 70, OwnerPhone = "0911000006", CommissionRate = 0.12m },

            new Restaurant { Id = 7, Name = "Piassa Traditional", Area = "Piassa", DeliveryFeeEtb = 65, OwnerPhone = "0911000007", CommissionRate = 0.10m },
            new Restaurant { Id = 8, Name = "Abay Restaurant", Area = "Piassa", DeliveryFeeEtb = 80, OwnerPhone = "0911000008", CommissionRate = 0.12m },
            new Restaurant { Id = 9, Name = "Old Addis Cafe", Area = "Piassa", DeliveryFeeEtb = 55, OwnerPhone = "0911000009", CommissionRate = 0.08m },

            new Restaurant { Id = 10, Name = "Megenagna Bites", Area = "Megenagna", DeliveryFeeEtb = 85, OwnerPhone = "0911000010", CommissionRate = 0.10m },
            new Restaurant { Id = 11, Name = "Family Injera", Area = "Megenagna", DeliveryFeeEtb = 95, OwnerPhone = "0911000011", CommissionRate = 0.12m },
            new Restaurant { Id = 12, Name = "Fresh Corner", Area = "Megenagna", DeliveryFeeEtb = 70, OwnerPhone = "0911000012", CommissionRate = 0.10m }
        };

        private readonly List<MenuItem> _menuItems = new()
        {
            new MenuItem { Id = 1, RestaurantId = 1, Name = "Doro Wat", PriceEtb = 350 },
            new MenuItem { Id = 2, RestaurantId = 1, Name = "Shiro", PriceEtb = 180 },
            new MenuItem { Id = 3, RestaurantId = 2, Name = "Special Tibs", PriceEtb = 420 },
            new MenuItem { Id = 4, RestaurantId = 5, Name = "Macchiato", PriceEtb = 90 },
            new MenuItem { Id = 5, RestaurantId = 7, Name = "Firfir", PriceEtb = 220 }
        };

        public List<Restaurant> Search(string? area, int page, int limit)
        {
            var query = _restaurants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(area))
            {
                query = query.Where(r =>
                    r.Area.Equals(area, StringComparison.OrdinalIgnoreCase));
            }

            return query
                .OrderBy(r => r.Id)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
        }

        public Restaurant? GetById(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public List<MenuItem> GetMenu(int restaurantId)
        {
            return _menuItems
                .Where(m => m.RestaurantId == restaurantId)
                .ToList();
        }

        public int Count(string? area)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                return _restaurants.Count;
            }

            return _restaurants.Count(r =>
                r.Area.Equals(area, StringComparison.OrdinalIgnoreCase));
        }
    }
}
