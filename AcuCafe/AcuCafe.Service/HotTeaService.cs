using System;
using AcuCafe.Model;
using AcuCafe.Model.Enums;

namespace AcuCafe.Service
{
    public class HotTeaService : IDrinkService
    {
        public Drink PrepareDrink(Drink drink, OrderRequestItem request)
        {

            if(drink == null)
            {
                drink.Status = Status.Failed;
                return drink;
            }

            drink.Note = "We are preparing the following drink for you: " + drink.Description;
            if (request.HasMilk)
            {
                drink.AddMilk();
                drink.Note += "with milk";
            }
            else
            {
                drink.Note += "without milk";
            }

            if (request.HasSugar)
            {
                drink.AddSugar();
                drink.Note += "with sugar";
            }
            else
            {
                drink.Note += "without sugar";
            }

            Console.WriteLine(drink.Note);

            drink.Status = Status.Complete;
            return drink;
        }
    }
}
