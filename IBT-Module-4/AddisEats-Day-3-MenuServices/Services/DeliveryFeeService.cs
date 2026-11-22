
namespace AddisEats_Day_3_MenuServices.Services;

public class DeliveryFeeService
{
    public decimal DeliveryFee(string area, bool isVip = false)
    {
        if (isVip)
        {
            return 0m;
        }

        return area.Trim().ToLowerInvariant() switch
        {
            "bole" => 80m,
            "kazanchis" => 60m,
            "piassa" => 70m,
            "megenagna" => 90m,
            _ => 100m
        };
    }
}
