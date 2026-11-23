using System.ComponentModel.DataAnnotations;

namespace AddisEats_Day_5_RestaurantService.Models;

public class AmountValidationRequest
{
    [EtbAmount]
    public decimal AmountEtb { get; set; }
}
