using System.Collections.Generic;
using System.Linq;

namespace AcuCafe.Model
{
    public class Receipt
    {
        public Receipt(int orderId)
        {
            Drinks = new List<Drink>();
            OrderId = orderId;
        }

        public int OrderId { get; set; }

        public List<Drink> Drinks { get; set; }

        public new double TotalPayment
        {
            get
            {
                //calculate total of drinks that were completed
                if(Drinks != null)
                {
                    return Drinks.Sum(x =>x.Status == Enums.Status.Complete ? x.Price : 0);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
