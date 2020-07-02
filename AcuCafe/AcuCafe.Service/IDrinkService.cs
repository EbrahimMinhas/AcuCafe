using AcuCafe.Model;

namespace AcuCafe.Service
{
    public interface IDrinkService
    {
        Drink PrepareDrink(Drink drink, OrderRequestItem request);
    }
}
