using AddisEats_Day_3_MenuServices.Interfaces;

namespace AddisEats_Day_3_MenuServices.Services
{
    public class TenPercentDiscountPolicy : IDiscountPolicy
    {

        public decimal Apply(decimal amount)
        {
            return amount * 0.90m;
        }
    }
}



