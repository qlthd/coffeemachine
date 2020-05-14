using CoffeeMachine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine.Test.UnitTest
{
    public class FakeData
    {
        public List<Badge> GetFakeBadges()
        {
            var badges = new List<Badge>();
            badges.Add(
                new Badge
                {
                    Id = 1,
                    OwnerFirstName = "John",
                    OwnerLastName = "Doe"

                }
            );
            badges.Add(
                new Badge
                {
                    Id = 2,
                    OwnerFirstName = "Jane",
                    OwnerLastName = "Dore"
                   

                }
            );
            return badges;
        }

        public List<Badge> GetFakeBadgesWithFakeOrder()
        {
            var badges = GetFakeBadges();
            
            badges[0].Orders = GetFakeOrders();

            return badges;
        }

        public List<Order> GetFakeOrders()
        {
            var orders = new List<Order>();
            orders.Add(
                new Order
                {
                    Id = 1,
                    BadgeId = 1,
                    DrinkId = 1,
                    WithMug = false,
                    SugarAmount = 1,
                    OrderTime = DateTime.Now
                });
            orders.Add(
                new Order
                {
                    Id = 2,
                    BadgeId = 1,
                    DrinkId = 2,
                    WithMug = true,
                    SugarAmount = 4,
                    OrderTime = DateTime.Now
                });
            return orders;
        }

        public Order GetNewFakeOrder()
        {
            return
                new Order
                {
                    Id = 3,
                    BadgeId = 2,
                    DrinkId = 1,
                    WithMug = false,
                    SugarAmount = 4,
                    OrderTime = DateTime.Now
                };
           
           
        }

        public List<Drink> GetFakeDrinks()
        {
            var drinks = new List<Drink>();
            drinks.Add(new Drink
            {
                Id = 1,
                Name = "Coffee"
                

            });
            drinks.Add(new Drink
            {
                Id = 2,
                Name = "Tea"
               

            });
            return drinks;
        }
    }
}
