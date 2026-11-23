namespace AddisEats_Day_5_RestaurantService.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string MobileNumber { get; set; } = "";
    public int RestaurantId { get; set; }
    public string OrderType { get; set; } = "";
    public string? DeliveryAddress { get; set; }
    public List<OrderLine> Items { get; set; } = new();
    public decimal SubtotalEtb { get; set; }
    public decimal DeliveryFeeEtb { get; set; }
    public decimal TotalEtb { get; set; }
}

public class OrderLine
{
    public int MenuItemId { get; set; }
    public string MenuItemName { get; set; } = "";
    public decimal UnitPriceEtb { get; set; }
    public int Quantity { get; set; }
    public decimal LineTotalEtb { get; set; }
}
