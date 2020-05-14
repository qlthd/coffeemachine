using CoffeeMachine.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Repositories
{
    public class DrinksRepository : IDrinksRepository
    {
        private readonly CoffeeMachineContext _dbContext;
        public DrinksRepository(CoffeeMachineContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Drink>> GetAll()
        {
            return await _dbContext.DbDrink.ToListAsync();

        }
    }
}
