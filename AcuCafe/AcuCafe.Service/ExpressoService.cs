using System;
using AcuCafe.Model;
using AcuCafe.Model.Enums;

namespace AcuCafe.Service
{
    public class ExpressoService : IDrinkService
    {
        // By having a service for each drink this gives us the flexibility in customizing how specific drinks are prepared
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
            if (request.Toppings != Toppings.None)
            {
                drink.AddTopping(request.Toppings);
                drink.Note += $"with {request.Toppings.ToString()} topping";
            }
            else
            {
                drink.Note += "without topping";
            }

            Console.WriteLine(drink.Note);
            drink.Status = Status.Complete;
            return drink;
        }
    }
}
