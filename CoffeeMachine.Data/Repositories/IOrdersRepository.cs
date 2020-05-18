using CoffeeMachine.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Data.Repositories
{
    public interface IOrdersRepository
    {
        public Task Create(Order order);
        public Task<Order> GetById(int id);

    }
}