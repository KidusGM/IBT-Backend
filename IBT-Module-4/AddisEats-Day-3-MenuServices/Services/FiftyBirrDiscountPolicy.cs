using AddisEats_Day_3_MenuServices.Interfaces;

namespace AddisEats_Day_3_MenuServices.Services
{
    public class FiftyBirrDiscountPolicy : IDiscountPolicy
    {
        public decimal Apply(decimal amount)
        {
            return Math.Max(0m, amount - 50m);
        }
    }
}
