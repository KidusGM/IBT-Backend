using AddisEatsNew.Api.Models;
//using Microsoft.AspNetCore.Mvc;
namespace AddisEatsNew.Api.Services.MenuItemServices;

public class MenuItemServices  : IMenuItemServices
{

    private readonly List<MenuItem> _menuitems = new()

    {
         new MenuItem { Id = 1, Name = "Burger", Category = "Food", Price = 10.5m },
      new MenuItem { Id = 2, Name = "Piza", Category = "Food", Price = 13.5m },
        new MenuItem { Id = 3, Name = "Chekolte-Cake", Category = "Dessert", Price = 16.5m },
        new MenuItem { Id = 4, Name = "Grilled-Chicken", Category = "Main Dish", Price = 20.5m },
         new MenuItem { Id = 5, Name = "Stake", Category = "Main Dish", Price = 26.5m },
          new MenuItem { Id = 6, Name = "French-Fries", Category = "Side Dish", Price = 7.5m },

           };
        //public MenuItemServices()
        //{
        //    _menuitems = new List<MenuItem>();
        //    {
        //        new MenuItem { Id = 1, Name = "Burger", Category = "Food", Price = 10.5m },
        //    new MenuItem { Id = 2, Name = "Piza", Category = "Food", Price = 13.5m },
        //     new MenuItem { Id = 3, Name = "Chekolte-Cake", Category = "Dessert", Price = 16.5m },

        //     };
        //}

    public List<MenuItem> GetAll(string? category)

    {
        var items = _menuitems
           .Where(x => category == null || x.Category == category).ToList();
    return items;
    }

    public MenuItem GetById(int id) {

        return _menuitems.Where(m => m.Id == id).FirstOrDefault();
    }
}
