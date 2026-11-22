namespace AddisEats_Day_5_RestaurantService.Models
{
    public record RestaurantDto(
        int Id,
        string Name,
        string Area,
        decimal DeliveryFeeEtb);
}
