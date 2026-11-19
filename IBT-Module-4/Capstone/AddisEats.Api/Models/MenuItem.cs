namespace AddisEats.Api.Models
{
    public class MenuItem
    {
        // Constructor
        public MenuItem(int id, string name, string category, decimal price)
        {
           Id = id;
           Name = name;
          Category = category;
          Price = price;
        }

      //  public MenuItem();




        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public decimal PriceWithVAT => Price * 1.2m;
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {

    //        MenuItem item1 = new MenuItem()
    //        {
    //            Id = 1,
    //            Name = "Burger",
    //            Category = "Food",
    //            Price = 5.99m
    //        };
    //       // MenuItem item1 = new MenuItem(1, "Burger", "Food", 5.99m);
    //       // MenuItem item2 = new MenuItem(2, "Piza", "Food", 8.99m);

    //        Console.WriteLine($"Item 1: {item1:Name}, Category: {item1:Category}, Price: {item1:Price}");
    //       // Console.WriteLine($"Item 2: {item2:Name}, Category: {item2:Category}, Price: {item2:Price}");
    //    }
    //}
}