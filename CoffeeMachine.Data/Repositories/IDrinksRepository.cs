using CoffeeMachine.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Repositories
{
    public interface IDrinksRepository
    {
        public Task<List<Drink>> GetAll();

    }
}