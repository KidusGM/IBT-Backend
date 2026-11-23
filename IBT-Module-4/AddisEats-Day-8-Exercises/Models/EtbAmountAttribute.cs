using System.ComponentModel.DataAnnotations;

namespace AddisEats_Day_5_RestaurantService.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class EtbAmountAttribute : ValidationAttribute
{
    public EtbAmountAttribute()
    {
        ErrorMessage = "Amount must be greater than zero and have no more than two decimal places.";
    }

    public override bool IsValid(object? value)
    {
        if (value is not decimal amount)
            return false;

        return amount > 0 && decimal.Round(amount, 2) == amount;
    }
}
