using System;
using AcuCafe.Model;

namespace AcuCafe.Service
{
    public class IceTeaService : IDrinkService
    {
        public Drink PrepareDrink(Drink drink, OrderRequestItem request)
        {

            if (drink == null)
            {
                return drink;
            }


            string message = "We are preparing the following drink for you: " + drink.Description;
            if (request.HasMilk)
            {
                Console.WriteLine("Ice Tea cannot be made with milk");
                return null;
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

            Console.WriteLine(message);

            return drink;
        }
    }
}
