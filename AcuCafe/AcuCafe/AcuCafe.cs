using System;
using AcuCafe.Model;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static Drink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            Drink drink = new Drink();
            if (type == "Expresso")
            {
                drink = new Expresso();
            }
            else if (type == "HotTea")
                drink = new Tea();
            else if (type == "IceTea")
                drink = new IceTea();

            try
            {
                drink.HasMilk = hasMilk;
                drink.HasSugar = hasSugar;
                //drink.Prepare(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine("We are unable to prepare your drink.");
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            } 

            return drink;
        }
    }


    public class Expresso : Drink
    {
        public new string Description
        {
            get { return "Expresso"; }
        }

        public new double Cost()
        {
            double cost = 1.8;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }

    public class Tea : Drink
    {
        public new string Description
        {
            get { return "Hot tea"; }
        }

        public new double Cost()
        {
            double cost = 1;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }

    public class IceTea : Drink
    {
        public new string Description
        {
            get { return "Ice tea"; }
        }

        public new double Cost()
        {
            double cost = 1.5;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }
}