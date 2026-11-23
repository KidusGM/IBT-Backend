using System.ComponentModel.DataAnnotations;

namespace AddisEats_Day_5_RestaurantService.Models;

public class CreateOrderRequest : IValidatableObject
{
    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Customer name must be between 2 and 80 characters.")]
    public string CustomerName { get; set; } = "";

    [Required(ErrorMessage = "Customer mobile number is required.")]
    [EthiopianMobile(ErrorMessage = "Enter a valid Ethiopian mobile number (09, 07, +2519 or +2517).")]
    public string MobileNumber { get; set; } = "";

    [Range(1, 10000, ErrorMessage = "RestaurantId must be between 1 and 10000.")]
    public int RestaurantId { get; set; }

    [Required(ErrorMessage = "Order type is required.")]
    [StringLength(10, ErrorMessage = "Order type cannot exceed 10 characters.")]
    public string OrderType { get; set; } = "Delivery";

    [StringLength(200, ErrorMessage = "Delivery address cannot exceed 200 characters.")]
    public string? DeliveryAddress { get; set; }

    [Required(ErrorMessage = "Order items are required.")]
    [MinLength(1, ErrorMessage = "Add at least one item to the order.")]
    public List<OrderItemRequest> Items { get; set; } = new();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.Equals(OrderType, "Delivery", StringComparison.OrdinalIgnoreCase)
            && string.IsNullOrWhiteSpace(DeliveryAddress))
        {
            yield return new ValidationResult(
                "Delivery address is required for delivery orders.",
                new[] { nameof(OrderType), nameof(DeliveryAddress) });
        }

        if (!string.Equals(OrderType, "Delivery", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(OrderType, "Pickup", StringComparison.OrdinalIgnoreCase))
        {
            yield return new ValidationResult(
                "OrderType must be Delivery or Pickup.",
                new[] { nameof(OrderType) });
        }
    }
}

public class OrderItemRequest
{
    [Range(1, 10000, ErrorMessage = "MenuItemId must be between 1 and 10000.")]
    public int MenuItemId { get; set; }

    [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20.")]
    public int Quantity { get; set; }
}
