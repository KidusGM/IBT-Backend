namespace AddisEats_Day_5_RestaurantService.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; } = "";

        [EtbAmount]
        public decimal PriceEtb { get; set; }
    }
}
