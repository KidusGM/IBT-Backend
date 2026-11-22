using AddisEats_Day_3_MenuServices.Modeles;
using AddisEats_Day_3_MenuServices.Models;

namespace AddisEats_Day_3_MenuServices.Services;

public class ModelDemoService
{
    public object RestaurantDemo()
    {
        var restaurant = new Restaurant
        {
            Id = 1,
            Name = "Addis Eats",
            Area = "Bole"
        };

        restaurant.Name = "Addis Eats Kitchen";

        return new
        {
            restaurant.Id,
            restaurant.Name,
            restaurant.DisplayName
        };
    }

    public object CustomerDemo()
    {
        var record1 = new Customer("Sara", "0911000000");
        var record2 = new Customer("Sara", "0911000000");

        var class1 = new CustomerClass("Sara", "0911000000");
        var class2 = new CustomerClass("Sara", "0911000000");

        return new
        {
            RecordEquality = record1 == record2,
            ClassEquality = class1 == class2,
            Explanation =
                "Records compare values by default. Classes compare references by default."
        };
    }
}






