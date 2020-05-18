using CoffeeMachine.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Repositories
{
    public class BadgesRepository : IBadgesRepository
    {
        private readonly CoffeeMachineContext _dbContext;

        private bool BadgeExist(int id) =>
        _dbContext.DbBadge.Any(b => b.Id == id);

        public BadgesRepository(CoffeeMachineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Badge>> GetAll()
        {
            return await _dbContext.DbBadge.Include( b => b.Orders).ToListAsync();
            
        }

        public async Task<Badge> GetById(int id)
        {
            return await _dbContext.DbBadge.
                Where(b => b.Id == id).Include(o => o.Orders).FirstOrDefaultAsync();

        }

      

       
    }
}
