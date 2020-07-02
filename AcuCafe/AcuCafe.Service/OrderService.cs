using System;
using AcuCafe.Model;
using AcuCafe.Model.Enums;
using AcuCafe.Repository;

namespace AcuCafe.Service
{
    public class OrderService : IOrderService
    {
        private IDrinkService _drinkService;

        public Receipt ProcessOrder(Order order)
        {
            if (order == null || order.Orders == null)
            {
                return null;
            }

            Receipt receipt = new Receipt();

            foreach(OrderRequestItem orderItem in order.Orders)
            {
                switch (orderItem.Type)
                {
                    case ItemType.Beverage:
                        receipt.drinks.Add(OrderDrink(orderItem));
                        break;
                }
            }

            return receipt;
        }

        private Drink OrderDrink(OrderRequestItem request)
        {
            try
            {
                Drink orderedDrink = new DrinkRepository().GetDrinkByType(request.DrinkType);

                switch (orderedDrink.Type)
                {
                    case DrinkType.Expresso:
                        _drinkService = new ExpressoService();
                        break;
                    case DrinkType.IceTea:
                        _drinkService = new IceTeaService();
                        break;
                    case DrinkType.HotTea:
                        _drinkService = new HotTeaService();
                        break;
                    default:
                        Console.WriteLine("Unrecognized drink request");
                        return null;
                }

                return _drinkService.PrepareDrink(orderedDrink, request);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
