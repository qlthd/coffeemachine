﻿using CoffeeMachine.Data.Models;
using CoffeeMachine.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Data
{
    public class OrdersRepository : IOrdersRepository { 
        private readonly CoffeeMachineContext _dbContext; 
        public OrdersRepository(CoffeeMachineContext dbContext){ 
            _dbContext = dbContext; 
        } 
        
        public async Task Create(Order order) { 
            await _dbContext.DbOrder.AddAsync(order); 
            _dbContext.SaveChanges(); 
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.DbOrder.
                Where(o => o.Id == id).FirstOrDefaultAsync();

        }
    }
}
