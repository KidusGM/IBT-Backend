using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.MicrosoftExtensions;
using System.Text.RegularExpressions;

namespace AddisEatsNew.Api.Validation
{
    public class EthiopianMobileAttribute  : ValidationAttribute
    {
        private static readonly Regex Pattern = 
            new(@"^09\d{8}$|^07\d{8}$", RegexOptions.Compiled);

        public EthiopianMobileAttribute()
        {
            ErrorMessage = "Enter a vaild Ethiopian Mobile number";
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)

        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string phone || !Pattern.IsMatch(phone))

            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        
        }
    }

}
