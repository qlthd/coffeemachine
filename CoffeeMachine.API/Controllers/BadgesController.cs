using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeMachine.Data.Models;
using Microsoft.AspNetCore.Http;
using CoffeeMachine.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoffeeMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadgesController : ControllerBase
    {
        IBadgesRepository _badgesRepository = null;
        
        public BadgesController(IBadgesRepository badgesRepository)
        {
            this._badgesRepository = badgesRepository;
            
        }

        /// <summary>
        /// Retrieval of badge list.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<Badge>> GetBadges()
        {
            var badges = new List<Badge>();

            badges = await _badgesRepository.GetAll();


            return badges;
        }

        /// <summary>
        /// Retrieval of a badge thanks to its id.
        /// </summary>
        /// <returns>badge</returns>
        /// 
        [HttpGet("{id}")]
        public async Task<ActionResult<Badge>> GetBadge(int id)
        {
            var badge = await _badgesRepository.GetById(id);

            if (badge == null)
            {
                return NotFound();
            }

            return badge;
        }



        /// <summary>
        /// Retrieval of orders assigned to a badge.
        /// </summary>
        /// <param name="id">Badge id</param>
        /// <returns></returns>
        /// 
        [HttpGet, Route("{id}/orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<Order>> GetOrdersByBadge(int id)
        {
            var badge = new Badge();
            var orders = new List<Order>();

            badge = await _badgesRepository.GetById(id);

            return badge.Orders;
        }

        





    }
}
