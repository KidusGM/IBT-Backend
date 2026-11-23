using System.ComponentModel.DataAnnotations;

namespace AddisEatsNew.Api.Validation
{
    public class ETBAmountAttribute  : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not decimal amount || amount <= 0m)
            {
                return new ValidationResult("Amount Must be greater than zero.");
            }

            if (decimal.Round(amount, 2) != amount)
            {
                return new ValidationResult("Amount cannot have more than two decimals places.");
            }
            return ValidationResult.Success;
        }
    }
}
