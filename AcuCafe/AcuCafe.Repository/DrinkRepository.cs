﻿using System.Collections.Generic;
using AcuCafe.Model;
using AcuCafe.Model.Enums;

namespace AcuCafe.Repository
{
    public class DrinkRepository : IDrinkRepository
    {

        // This would ideally be the data access layer where the drink data is retrieved from the database
        private readonly Dictionary<DrinkType, Drink> DrinkMenu = new Dictionary<DrinkType, Drink>
        {
            {DrinkType.Expresso, new Drink{ Type = DrinkType.Expresso, Description="An expresso", Price= 2.0} },
            {DrinkType.IceTea, new Drink{ Type = DrinkType.IceTea, Description="An Ice Tea drink", Price = 2.0} },
             {DrinkType.HotTea, new Drink{ Type = DrinkType.HotTea, Description="As Hot Tea drink", Price = 2.0} }
        };

        public Drink GetDrinkByType(DrinkType type)
        {
            return DrinkMenu[type];
        }
    }
}
