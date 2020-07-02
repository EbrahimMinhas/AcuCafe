using AcuCafe.Model;
using AcuCafe.Model.Enums;
namespace AcuCafe.Repository
{
    public interface IDrinkRepository
    {
        Drink GetDrinkByType(DrinkType type);
    }
}
