using AddisEats_Day_3_MenuServices.Interfaces;

namespace AddisEats_Day_3_MenuServices.Services
{
    public class DiscountService
    {

        public decimal ApplyDiscount(
        decimal amount,
        IDiscountPolicy policy)
        {
            return policy.Apply(amount);
        }
    }
}
