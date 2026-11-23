namespace AddisEats_Day_5_RestaurantService.Models;

public static class ErrorCatalogue
{
    public static readonly Error RestaurantNotFound = new("ORD-001", "Restaurant was not found.");
    public static readonly Error MenuItemNotFound = new("ORD-002", "Menu item was not found for this restaurant.");
    public static readonly Error InvalidQuantity = new("ORD-003", "Quantity must be between 1 and 20.");
    public static readonly Error EmptyOrder = new("ORD-004", "Order must contain at least one item.");
    public static readonly Error InvalidMobile = new("ORD-005", "Enter a valid Ethiopian mobile number.");
    public static readonly Error DeliveryAddressRequired = new("ORD-006", "Delivery address is required for delivery orders.");
    public static readonly Error InvalidOrderType = new("ORD-007", "OrderType must be Delivery or Pickup.");
    public static readonly Error InvalidAmount = new("ORD-008", "Amount must be greater than zero and have no more than two decimal places.");
}
