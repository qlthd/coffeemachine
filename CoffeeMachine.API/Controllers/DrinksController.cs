using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeMachine.Data.Models;
using CoffeeMachine.Data.Repositories;

namespace CoffeeMachine.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ControllerBase
    {
        
        IRepositoryWrapper _repoWrapper = null;

        public DrinksController(IRepositoryWrapper repoWrapper)
        {
           
            this._repoWrapper = repoWrapper;
        }

        /// <summary>
        /// Retrieval of drink list.
        /// </summary>
        /// <returns> An IEnumerable of Drinks</returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            var drinks = new List<Drink>();
            drinks = await _repoWrapper.Drinks.GetAll();
            return drinks;
        }





    }
}
