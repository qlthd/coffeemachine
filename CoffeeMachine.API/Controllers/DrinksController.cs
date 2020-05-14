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
        
        IDrinksRepository _drinksRepository = null;

        public DrinksController(IDrinksRepository drinksRepository)
        {
           
            this._drinksRepository = drinksRepository;
        }

        /// <summary>
        /// Retrieval of drink list.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            var drinks = new List<Drink>();
            drinks = await _drinksRepository.GetAll();
            return drinks;
        }





    }
}
