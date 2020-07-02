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
                return drink;
            }

            string message = "We are preparing the following drink for you: " + drink.Description;
            if (request.HasMilk)
            {
                drink.AddMilk();
                message += "with milk";
            }
            else
            {
                message += "without milk";
            }

            if (request.HasSugar)
            {
                drink.AddSugar();
                message += "with sugar";
            }
            else
            {
                message += "without sugar";
            }
            if (request.Toppings != Toppings.None)
            {
                drink.AddTopping(request.Toppings);
                message += $"with {request.Toppings.ToString()} topping";
            }
            else
            {
                message += "without topping";
            }

            Console.WriteLine(message);

            return drink;
        }
    }
}
