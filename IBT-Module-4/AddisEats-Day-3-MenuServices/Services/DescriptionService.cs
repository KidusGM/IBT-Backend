namespace AddisEats_Day_3_MenuServices.Services;

public class DescriptionService
{
    public string Describe(int value)
    {
        return $"Describe(int) chosen: {value}";
    }

    public string Describe(string value)
    {
        return $"Describe(string) chosen: {value}";
    }

    public string Describe(decimal value)
    {
        return $"Describe(decimal) chosen: {value:N2}";
    }
}
