using System;
using System.Collections.Generic;

namespace AcuCafe.Model
{
    public class Receipt
    {
        public Receipt()
        {
            drinks = new List<Drink>();
        }

        public List<Drink> drinks { get; set; }


    }
}
