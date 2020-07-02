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
        public void TestProcessOrder()
        {
            //act
            Receipt result = _service.ProcessOrder(_order);

            //assert
            Assert.IsTrue(result != null);
        }

        #endregion
    }
}
