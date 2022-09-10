using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.DAL.Interfaces;
using WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Orders.GetById(id));
        }

        // GET: api/Orders/
        [HttpGet]
        public  IEnumerable<Order> GetAll()
        {
             return _unitOfWork.Orders.GetAll();
          
        }
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order Order)
        {
            Order.Id = id;

            _unitOfWork.Orders.Put(Order);


            _unitOfWork.Complete();

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult AddOrder(Order Orderentity)
        {
            _unitOfWork.Orders.Add(Orderentity);
            foreach(OrderItem  Item in Orderentity.OrderItems)
            {
                _unitOfWork.OrderItems.Add(Item);
            }
            _unitOfWork.Complete();
            return CreatedAtAction("GetById", new { id = Orderentity.Id }, Orderentity);
        }
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var Orderentity = await _unitOfWork.Orders.FindAsync(b => b.Id == id);
            if (Orderentity == null)
            {
                return NotFound();
            }
            _unitOfWork.Orders.Delete(Orderentity);
            _unitOfWork.Complete();
            return Orderentity;
        }

    }
}