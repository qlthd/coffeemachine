using CoffeeMachine.Controllers;
using CoffeeMachine.Data.Repositories;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.UnitTest
{
    public class BadgesControllerUnitTest
    {
        public FakeData _fakeData = new FakeData();


        [Fact]
        public async Task TestGetBadgesAsync()
        {
            var mockRepo = new Mock<IBadgesRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(_fakeData.GetFakeBadges());
            
            var controller = new BadgesController(mockRepo.Object);

            var badges = await controller.GetBadges();
            Assert.Equal(2, badges.Count());

            
        }


        [Fact]
        public async Task TestGetOrdersByBadgeIdAsync()
        {
            int testBadgeId = 1;
            var fakeBadgesWithOrders = _fakeData.GetFakeBadgesWithFakeOrder().FirstOrDefault(
                    b => b.Id == testBadgeId);
  
            var mockBadgeRepo = new Mock<IBadgesRepository>();
            mockBadgeRepo.Setup(repo => repo.GetById(testBadgeId))
                .ReturnsAsync(fakeBadgesWithOrders);
           
            var controller = new BadgesController(mockBadgeRepo.Object);


            var result = await controller.GetOrdersByBadge(testBadgeId);


          
            Assert.Equal(2, result.Count);
            Assert.Equal(fakeBadgesWithOrders.Orders, result);
        }
        

    }
}
