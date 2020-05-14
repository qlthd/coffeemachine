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
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this._ordersRepository = ordersRepository;
        }


        /// <summary>
        /// Inserting a new drink order.
        /// </summary>
        /// <param name="order">Order to add</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult> Add(Order order)
        {
            
            if (this.ModelState.IsValid)
            {
                await _ordersRepository.Create(order);
                
            }
            return CreatedAtAction(nameof(Order), new { id = order.Id }, order);
        }

        


    }
}