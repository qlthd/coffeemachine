using CoffeeMachine.Data.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.IntegrationTest
{
    public class OrdersAPITest
    {
        private readonly TestContext _testContext;

        public OrdersAPITest()
        {
            _testContext = new TestContext();
        }

        [Theory]
        [InlineData("GET")]
        public async Task TestGetOrderByIdAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/orders/1");

            var response = await _testContext.Client.SendAsync(request);
            
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<Order>(stringResponse);
            Assert.Equal(1, order.Id);
            Assert.Equal(1, order.DrinkId);
            Assert.True(order.WithMug);
            Assert.Equal(3, order.SugarAmount);
            Assert.Equal(DateTime.ParseExact("10/05/2020 13:45:00", "dd/MM/yyyy HH:mm:ss",null), order.OrderTime);
        }



        [Fact]
        public async Task TestPostOrderAsync()
        {
           
            var response = await _testContext.Client.PostAsync("/orders"
                        , new StringContent(
                        JsonConvert.SerializeObject(new Order()
                        {
                           
                            BadgeId = 1,
                            DrinkId = 1,
                            WithMug = false,
                            SugarAmount = 1,
                            OrderTime = DateTime.Now
                        }),
                    Encoding.UTF8,
                    "application/json"));

                response.EnsureSuccessStatusCode();
                
                response.StatusCode.Should().Be(HttpStatusCode.Created);
            
        }
    }
}
