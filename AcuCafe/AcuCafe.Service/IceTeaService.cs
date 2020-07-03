using System;
using AcuCafe.Model;
using AcuCafe.Model.Enums;

namespace AcuCafe.Service
{
    public class IceTeaService : IDrinkService
    {
        public Drink PrepareDrink(Drink drink, OrderRequestItem request)
        {

            if (drink == null)
            {
                drink.Status = Status.Failed;
                return drink;
            }

            drink.Note = "We are preparing the following drink for you: " + drink.Description;
            if (request.HasMilk)
            {
                //When we get here we are setting the status to failed so that the drink isnt totalled
                // in the receipt and the barista is just informed
                Console.WriteLine("Ice Tea cannot be made with milk");
                drink.Status = Status.Failed;
                return drink;
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
