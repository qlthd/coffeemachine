using CoffeeMachine.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoffeeMachine.Test.UnitTest.Models
{
    public class BadgeUnitTest
    {
        [Fact]
        public void CreateBadge()
        {
            var badge = new Badge {
                Id = 1,
                OwnerFirstName = "John",
                OwnerLastName = "Doe"
               
            };

            Assert.Equal("John", badge.OwnerFirstName);
            Assert.Equal("Doe", badge.OwnerLastName);
          
            Assert.Equal(1, badge.Id);
        }
    }
}
