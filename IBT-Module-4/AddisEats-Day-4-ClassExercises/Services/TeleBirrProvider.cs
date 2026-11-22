namespace AddisEats_Day_4_ClassExercises.Services
{
    public class TeleBirrProvider : IPaymentProvider
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} ETB using TeleBirr.";
        }
    }
}
