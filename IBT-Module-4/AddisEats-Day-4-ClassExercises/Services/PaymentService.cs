namespace AddisEats_Day_4_ClassExercises.Services
{
    public class PaymentService
    {
        private readonly IPaymentProvider _paymentProvider;

        public PaymentService(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        public string MakePayment(decimal amount)
        {
            return _paymentProvider.Pay(amount);
        }
    }
}
