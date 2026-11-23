using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AddisEats_Day_5_RestaurantService.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class EthiopianMobileAttribute : ValidationAttribute
{
    private static readonly Regex MobilePattern =
        new(@"^(09|07)\d{8}$|^\+251(9|7)\d{8}$", RegexOptions.Compiled);

    public override bool IsValid(object? value)
    {
        if (value is not string phone || string.IsNullOrWhiteSpace(phone))
            return false;

        return MobilePattern.IsMatch(phone);
    }
}
