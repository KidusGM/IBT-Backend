namespace AddisEats_Day_5_RestaurantService.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Area { get; set; } = "";

        public decimal DeliveryFeeEtb { get; set; }

        public string OwnerPhone { get; set; } = "";

        public decimal CommissionRate { get; set; }
    }
}
