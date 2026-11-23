using AddisEats_Day_5_RestaurantService.Models;

namespace AddisEats_Day_5_RestaurantService.Services;

public class OrderService : IOrderService
{
    private readonly IRestaurantService _restaurantService;
    private static int _nextOrderId = 1000;

    public OrderService(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public Result<Order> Place(CreateOrderRequest request)
    {
        var restaurant = _restaurantService.GetById(request.RestaurantId);
        if (restaurant is null)
            return Result<Order>.Failure(ErrorCatalogue.RestaurantNotFound);

        if (request.Items is null || request.Items.Count == 0)
            return Result<Order>.Failure(ErrorCatalogue.EmptyOrder);

        var order = new Order
        {
            Id = Interlocked.Increment(ref _nextOrderId),
            CustomerName = request.CustomerName,
            MobileNumber = NormalizeMobile(request.MobileNumber),
            RestaurantId = restaurant.Id,
            OrderType = request.OrderType,
            DeliveryAddress = request.DeliveryAddress
        };

        foreach (var requestedItem in request.Items)
        {
            if (requestedItem.Quantity < 1 || requestedItem.Quantity > 20)
                return Result<Order>.Failure(ErrorCatalogue.InvalidQuantity);

            var menuItem = _restaurantService.GetMenu(restaurant.Id)
                .FirstOrDefault(m => m.Id == requestedItem.MenuItemId);

            if (menuItem is null)
                return Result<Order>.Failure(ErrorCatalogue.MenuItemNotFound);

            if (menuItem.PriceEtb <= 0 || decimal.Round(menuItem.PriceEtb, 2) != menuItem.PriceEtb)
                return Result<Order>.Failure(ErrorCatalogue.InvalidAmount);

            order.Items.Add(new OrderLine
            {
                MenuItemId = menuItem.Id,
                MenuItemName = menuItem.Name,
                UnitPriceEtb = menuItem.PriceEtb,
                Quantity = requestedItem.Quantity,
                LineTotalEtb = menuItem.PriceEtb * requestedItem.Quantity
            });
        }

        order.SubtotalEtb = order.Items.Sum(i => i.LineTotalEtb);
        order.DeliveryFeeEtb = string.Equals(request.OrderType, "Delivery", StringComparison.OrdinalIgnoreCase)
            ? restaurant.DeliveryFeeEtb : 0m;

        // The total is calculated from server-owned menu prices and delivery fee.
        order.TotalEtb = order.SubtotalEtb + order.DeliveryFeeEtb;

        return Result<Order>.Success(order);
    }

    private static string NormalizeMobile(string phone)
    {
        if (phone.StartsWith("+251", StringComparison.Ordinal))
            return "0" + phone[4..];

        return phone;
    }
}
