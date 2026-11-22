namespace AddisEats_Day_3_MenuServices.Services;

    public class AmountValidationService
    {

    public void ValidateAmount(decimal amount)
    {
        if (amount <= 0m)
        {
            throw new ArgumentException(
                "Amount must be greater than zero.",
                nameof(amount));
        }
    }
}

