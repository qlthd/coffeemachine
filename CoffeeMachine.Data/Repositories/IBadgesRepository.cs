using CoffeeMachine.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Repositories
{
    public interface IBadgesRepository
    {
        public Task<List<Badge>> GetAll();
        public Task<Badge> GetById(int id);

       
    }
}