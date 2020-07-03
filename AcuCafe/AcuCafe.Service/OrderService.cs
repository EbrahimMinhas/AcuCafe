using System;
using AcuCafe.Model;
using AcuCafe.Model.Enums;
using AcuCafe.Repository;

namespace AcuCafe.Service
{
    public class OrderService : IOrderService
    {
        private IDrinkRepository _drinkRepository;
        private IDrinkService _drinkService;

        public OrderService(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public Receipt ProcessOrder(Order order)
        {
            try
            {
                if (order == null || order.Orders == null)
                {
                    return null;
                }

                Receipt receipt = new Receipt(order.OrderId);

                foreach (OrderRequestItem orderItem in order.Orders)
                {
                    switch (orderItem.Type)
                    {
                        case ItemType.Beverage:
                            receipt.Drinks.Add(OrderDrink(orderItem));
                            break;
                    }
                }

                return receipt;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
                return null;
            }
        }

        private Drink OrderDrink(OrderRequestItem request)
        {
            Drink orderedDrink = _drinkRepository.GetDrinkByType(request.DrinkType);

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
    }
}
