using System.Collections.Generic;
using AcuCafe.Model.Enums;

namespace AcuCafe.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderRequestItem> Orders { get; set; }
    }

    public class OrderRequestItem
    {
        public ItemType Type { get; set; }
        public DrinkType DrinkType { get; set; }
        public bool HasMilk { get; set; }
        public bool HasSugar { get; set; }
        public Toppings Toppings { get; set; }
    }
}
