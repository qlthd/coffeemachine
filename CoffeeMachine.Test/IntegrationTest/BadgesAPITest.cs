using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using CoffeeMachine.API;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System;
using CoffeeMachine.Data.Models;
using System.Text;
using FluentAssertions;

namespace CoffeeMachine.Test.IntegrationTest
{
    public class BadgesAPITest
    {
        private readonly TestContext _testContext;

        public BadgesAPITest()
        {
            _testContext = new TestContext();
        }



        [Theory]
        [InlineData("GET")]
        public async Task TestGetAllBadgesAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method),"/badges");

            var response = await _testContext.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           
            var badges = JsonConvert.DeserializeObject<Badge[]>(await response.Content.ReadAsStringAsync());
           
            Assert.Equal(2, badges.Length);
            Assert.Equal(1, badges[0].Id);
            Assert.Equal(2, badges[1].Id);
            Assert.Equal("John", badges[0].OwnerFirstName);
            Assert.Equal("Doe", badges[0].OwnerLastName);
            Assert.Equal("Jane", badges[1].OwnerFirstName);
            Assert.Equal("Doe", badges[1].OwnerLastName);
            
        }

        [Theory]
        [InlineData("GET")]
        public async Task TestGetAllOrdersByBadgeAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/badges/1/orders");

            var response = await _testContext.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var orders = JsonConvert.DeserializeObject<Order[]>(await response.Content.ReadAsStringAsync());

            Assert.Equal(2, orders.Length);
            Assert.Equal(1, orders[0].Id);
            Assert.Equal(2, orders[1].Id);

            Assert.Equal(1, orders[0].DrinkId);
            Assert.Equal(2, orders[1].DrinkId);

            Assert.Equal(1, orders[0].BadgeId);
            Assert.Equal(1, orders[1].BadgeId);

            Assert.True(orders[0].WithMug);
            Assert.True(orders[1].WithMug);

            Assert.Equal(3, orders[0].SugarAmount);
            Assert.Equal(2, orders[1].SugarAmount);
        }

       








    }
}
