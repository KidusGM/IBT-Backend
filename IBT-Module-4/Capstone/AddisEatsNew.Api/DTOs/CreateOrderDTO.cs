
namespace AddisEatsNew.Api.DTOs
{
    public record CreateOrderDTO
    (
        int RestaurantId,
            int MenuItemId,
            string CustomerName,
            string DeliveryAddress,
             string CustomerPhone,
            int Quantity,
            decimal TotalAmount

    );
}
