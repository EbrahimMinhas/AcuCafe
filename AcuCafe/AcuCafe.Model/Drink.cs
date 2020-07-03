using AcuCafe.Model.Enums;

namespace AcuCafe.Model
{
    public class Drink
    {
        public Drink()
        {
            Status = Status.Pending;
        }

        public const double MilkCost = 0.5;
        public const double SugarCost = 0.5;
        public const double ToppingCost = 0.5;

        public DrinkType Type { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }
        public bool HasTopping { get; set; }
        public Toppings Topping { get; set; }

        public Status Status { get; set; }
        public string Note { get; set; }

        public void AddMilk()
        {
            HasMilk = true;
            Price += MilkCost;
        }

        public void AddSugar()
        {
            HasSugar = true;
            Price += SugarCost;
        }

        public void AddTopping(Toppings type)
        {
            Topping = type;
            HasTopping = type != Toppings.None;
            Price += ToppingCost;
        }
    }
}
