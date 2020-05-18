using CoffeeMachine.Data.Models;
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
    public class DrinksAPITest
    {
        private readonly TestContext _testContext;

        public DrinksAPITest()
        {
            _testContext = new TestContext();
        }

        [Theory]
        [InlineData("GET")]
        public async Task TestGetAllDrinksAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/drinks");

            var response = await _testContext.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var drinks = JsonConvert.DeserializeObject<Drink[]>(await response.Content.ReadAsStringAsync());

            Assert.Equal(3, drinks.Length);
            Assert.Equal(1, drinks[0].Id);
            Assert.Equal(2, drinks[1].Id);
            Assert.Equal(3, drinks[2].Id);
            Assert.Equal("Coffee", drinks[0].Name);
            Assert.Equal("Tea", drinks[1].Name);
            Assert.Equal("Chocolate", drinks[2].Name);


        }
    }
}
