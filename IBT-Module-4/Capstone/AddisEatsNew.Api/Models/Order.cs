namespace AddisEatsNew.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int MenuItemId { get; set; }
        //  public Restaurant? Restaurant { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        // public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
