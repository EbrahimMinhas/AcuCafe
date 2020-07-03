using System.Collections.Generic;
using AcuCafe.Service;
using AcuCafe.Model;
using AcuCafe.Model.Enums;
using AcuCafe.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcuCafe.UnitTests
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService _service;
        private Order _order;

        [TestInitialize]
        public void Initialize()
        {
            _service = new OrderService(new DrinkRepository());

            _order = new Order
            {
                OrderId = 1,
                Orders = new List<OrderRequestItem> {
                    new OrderRequestItem
                    {
                        Type = ItemType.Beverage,
                        DrinkType = DrinkType.Expresso,
                        HasMilk = false,
                        HasSugar = true
                    }
                }
            };
        }

        #region ProcessOrder

        [TestMethod]
        public void TestProcessOrderExpressoWithToppings()
        {
            //arrange 
            _order = new Order
            {
                OrderId = 1,
                Orders = new List<OrderRequestItem> {
                    new OrderRequestItem
                    {
                        Type = ItemType.Beverage,
                        DrinkType = DrinkType.Expresso,
                        HasMilk = false,
                        HasSugar = true,
                        Toppings = Toppings.Chocolate
                    }
                }
            };

            //act
            Receipt result = _service.ProcessOrder(_order);

            //assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Drinks.Exists(x => x.HasTopping));
            Assert.IsTrue(result.Drinks.Exists(x => x.Status == Status.Complete));
        }

        [TestMethod]
        public void TestProcessOrderWithIceTea()
        {
            //arrange 
            _order = new Order
            {
                OrderId = 1,
                Orders = new List<OrderRequestItem> {
                    new OrderRequestItem
                    {
                        Type = ItemType.Beverage,
                        DrinkType = DrinkType.IceTea,
                        HasMilk = false,
                        HasSugar = true
                    }
                }
            };

            //act
            Receipt result = _service.ProcessOrder(_order);

            //assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Drinks.Exists(x => x.Status == Status.Complete));
        }

        [TestMethod]
        public void TestProcessOrderWithIceTeaWithMilk()
        {
            //arrange 
            _order = new Order
            {
                OrderId = 1,
                Orders = new List<OrderRequestItem> {
                    new OrderRequestItem
                    {
                        Type = ItemType.Beverage,
                        DrinkType = DrinkType.IceTea,
                        HasMilk = true,
                        HasSugar = true
                    }
                }
            };

            //act
            Receipt result = _service.ProcessOrder(_order);

            //assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Drinks.Exists(x => x.Status == Status.Failed));
        }

        [TestMethod]
        public void TestProcessOrderWithHotTea()
        {
            //arrange 
            _order = new Order
            {
                OrderId = 1,
                Orders = new List<OrderRequestItem> {
                    new OrderRequestItem
                    {
                        Type = ItemType.Beverage,
                        DrinkType = DrinkType.HotTea,
                        HasMilk = false,
                        HasSugar = true
                    }
                }
            };

            //act
            Receipt result = _service.ProcessOrder(_order);

            //assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Drinks.Exists(x => x.Status == Status.Complete));
        }



        #endregion
    }
}
