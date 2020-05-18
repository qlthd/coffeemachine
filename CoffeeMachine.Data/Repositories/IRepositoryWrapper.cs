using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Data.Repositories
{
    public interface IRepositoryWrapper
    {
        IOrdersRepository Orders { get; }
        IDrinksRepository Drinks { get; }
        IBadgesRepository Badges { get; }
        void Save();
    }
}
