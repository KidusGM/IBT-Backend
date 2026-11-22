
namespace AddisEats_Day_3_MenuServices.Models;

public class Restaurant
{
  
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Area { get; set; } = string.Empty;

        public string DisplayName => $"{Name} ({Area})";
    }



