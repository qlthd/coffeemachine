using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CoffeeMachineContext _repoContext;
        private IOrdersRepository _orders;
        private IDrinksRepository _drinks;
        private IBadgesRepository _badges;

        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrdersRepository(_repoContext);
                }

                return _orders;
            }
        }

        public IDrinksRepository Drinks
        {
            get
            {
                if (_drinks == null)
                {
                    _drinks = new DrinksRepository(_repoContext);
                }

                return _drinks;
            }
        }

        public IBadgesRepository Badges
        {
            get
            {
                if (_badges == null)
                {
                    _badges = new BadgesRepository(_repoContext);
                }

                return _badges;
            }
        }

        public RepositoryWrapper(CoffeeMachineContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
