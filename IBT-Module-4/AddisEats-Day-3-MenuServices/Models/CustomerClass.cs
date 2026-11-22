
namespace AddisEats_Day_3_MenuServices.Modeles;

public class CustomerClass
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public CustomerClass(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}
