using CoffeeMachine.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoffeeMachine.Test.UnitTest.Models
{
    public class DrinkUnitTest
    {
        [Fact]
        public void CreateDrink()
        {
            var drink = new Drink
            {
                Id = 1,
                Name = "Coffee"
               
            };

            
            Assert.Equal(1, drink.Id);
            Assert.Equal("Coffee", drink.Name);
           
        }

    }
}
