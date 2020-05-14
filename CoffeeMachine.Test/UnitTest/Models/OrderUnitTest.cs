using CoffeeMachine.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoffeeMachine.Test.UnitTest.Models
{
    public class OrderUnitTest
    {
        [Fact]
        public void CreateOrder()
        {
            var order = new Order
            {
                Id = 1,
                BadgeId = 1,
                DrinkId = 2,
                WithMug = true,
                SugarAmount = 4,
                OrderTime = new DateTime(2020, 5, 11)
            };

            Assert.Equal(1, order.Id);
            Assert.Equal(1, order.BadgeId);
            Assert.Equal(2, order.DrinkId);
            Assert.True(order.WithMug);
            Assert.Equal(4, order.SugarAmount);
            Assert.Equal(new DateTime(2020, 5, 11), order.OrderTime);
        }
    }
}
