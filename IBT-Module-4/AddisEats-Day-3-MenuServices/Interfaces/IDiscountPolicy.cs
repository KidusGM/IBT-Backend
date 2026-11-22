namespace AddisEats_Day_3_MenuServices.Interfaces
{
    public interface IDiscountPolicy
    {
        decimal Apply(decimal amount);
    }
}
