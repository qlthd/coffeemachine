using CoffeeMachine.Data.Models;
using CoffeeMachine.Data.Repositories;
using CoffeeMachine.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
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
          
            var mockRepo = new Mock<IOrdersRepository>();
   
           

            var controller = new OrdersController(mockRepo.Object);
            
            
            var order = _fakeData.GetNewFakeOrder();

            var response = await controller.Add(order) as ObjectResult;

            // Check if created response
            Assert.Equal(201, response.StatusCode);
            
        }

    }
}
