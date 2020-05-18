using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMachine.Data;
using CoffeeMachine.Data.Models;
using CoffeeMachine.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public OrdersController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        /// <summary>
        /// Retrieval of an order thanks to its id.
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>An order</returns>
        /// 
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _repoWrapper.Orders.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }


        /// <summary>
        /// Inserting a new drink order.
        /// </summary>
        /// <param name="order">Order to add</param>
        /// <returns>The GetOrder Action</returns>
        /// 
        [HttpPost]
        public async Task<ActionResult> Add(Order order)
        {
            
            if (this.ModelState.IsValid)
            {
                await _repoWrapper.Orders.Create(order);
                
            }
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        

        


    }
}