using CoffeeMachine.API.Controllers;
using CoffeeMachine.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.UnitTest.Controllers
{
    public class DrinksUnitTest
    {
        public FakeData _fakeData = new FakeData();


        [Fact]
        public async Task TestGetDrinksAsync()
        {
            var mockRepo = new Mock<IDrinksRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(_fakeData.GetFakeDrinks());

            var controller = new DrinksController(mockRepo.Object);

            var drinks = await controller.GetDrinks();
            Assert.Equal(2, drinks.Count());


        }
    }
}
