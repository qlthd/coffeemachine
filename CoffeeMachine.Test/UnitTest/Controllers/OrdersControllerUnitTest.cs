using CoffeeMachine.Data.Models;
using CoffeeMachine.Data.Repositories;
using CoffeeMachine.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.UnitTest.Controllers
{
    public class OrdersControllerUnitTest
    {
        public FakeData _fakeData = new FakeData();


        [Fact]
        public async Task TestPostOrderAsync()
        {
          
            var mockRepo = new Mock<IRepositoryWrapper>();
            
            var order = _fakeData.GetNewFakeOrder();
            mockRepo.Setup(repo => repo.Orders.GetById(1))
                .ReturnsAsync(_fakeData.GetFakeOrders().FirstOrDefault());

            var controller = new OrdersController(mockRepo.Object);
            
            
            

            var response = await controller.Add(order) as ObjectResult;

            // Check if created response
            Assert.Equal(201, response.StatusCode);
            
        }

        [Fact]
        public async Task TestGetOrderByIdAsync()
        {
            int testOrderId = 1;
            var mockOrderRepo = new Mock<IRepositoryWrapper>();
            mockOrderRepo.Setup(repo => repo.Orders.GetById(testOrderId))
                .ReturnsAsync(_fakeData.GetFakeOrders().FirstOrDefault());


            var controller = new OrdersController(mockOrderRepo.Object);


            var result = await controller.GetOrder(testOrderId);


            Assert.Equal(1,result.Value.BadgeId);
            Assert.Equal(1,result.Value.DrinkId);
            Assert.Equal(1, result.Value.SugarAmount);
            Assert.False(result.Value.WithMug);
           
        }

    }
}
