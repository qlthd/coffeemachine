using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CoffeeMachine.Data.Models;

namespace CoffeeMachine.Data
{
    public class CoffeeMachineContext : DbContext
    {
      
        public CoffeeMachineContext(DbContextOptions options) : base(options)
        {

        }

       
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding database with example data
            modelBuilder.Entity<Badge>().HasData(
                new Badge
                {
                    Id = 1,
                    OwnerFirstName = "John",
                    OwnerLastName = "Doe"
                    

                },
                new Badge
                {
                    Id = 2,
                    OwnerFirstName = "Jane",
                    OwnerLastName = "Doe"
                   

                }
            );
           
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Name = "Coffee"},
                new Drink { Id = 2, Name = "Tea" },
                new Drink { Id = 3, Name = "Chocolate" }

            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, BadgeId = 1, DrinkId = 1 , WithMug = true, SugarAmount = 3, OrderTime = DateTime.ParseExact("10/05/2020 13:45:00", "dd/MM/yyyy HH:mm:ss",null) },
                new Order { Id = 2, BadgeId = 1, DrinkId = 2, WithMug = true, SugarAmount = 2, OrderTime = DateTime.ParseExact("10/05/2020 17:22:13", "dd/MM/yyyy HH:mm:ss", null) },
                new Order { Id = 3, BadgeId = 2, DrinkId = 2, WithMug = false, SugarAmount = 0, OrderTime = DateTime.ParseExact("10/05/2020 14:11:29", "dd/MM/yyyy HH:mm:ss", null) },
                new Order { Id = 4, BadgeId = 2, DrinkId = 3, WithMug = false, SugarAmount = 1, OrderTime = DateTime.ParseExact("10/05/2020 15:27:52", "dd/MM/yyyy HH:mm:ss", null) }
            );
        }

        public DbSet<Badge> DbBadge { get; set; }
        public DbSet<Drink> DbDrink { get; set; }
        public DbSet<Order> DbOrder { get; set; }




    }
}
