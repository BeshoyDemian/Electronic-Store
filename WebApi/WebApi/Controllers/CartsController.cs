using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.DAL.Consts;
using WebApi.DAL.Interfaces;
using WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<IEnumerable<CartItem>> GetAll()
        {
            return await _unitOfWork.CartItems.GetAllAsync(new[] { "Product" });
        }
        
        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public ActionResult<CartItem> GetById(int id)
        {
            var CartItem = _unitOfWork.CartItems.GetById(id);
            return CartItem;
        }
        // PUT: api/CartItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem CartItem)
        {
            CartItem.Id = id;

            _unitOfWork.CartItems.Put(CartItem);

           
                _unitOfWork.Complete();
           
            return NoContent();
        }

        // POST: api/CartItems
        [HttpPost]
        public IActionResult AddCartItem(CartItem Cart)
        {
            var newCartItem = new CartItem()
            {
                ProductId = Cart.Product.Id,
                //Product = Cart.Product,
                Price = Cart.Product.Price,
                productName = Cart.Product.Name,
                qty = 1,
            };

            _unitOfWork.CartItems.Add(newCartItem);
            _unitOfWork.Complete();
            return CreatedAtAction("GetById", new { id = newCartItem.Id }, newCartItem);
        }
        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItem>> DeleteCartItem(int id)
        {
            var CartItementity = await _unitOfWork.CartItems.FindAsync(b => b.Id == id);
            if (CartItementity == null)
            {
                return NotFound();
            }
            _unitOfWork.CartItems.Delete(CartItementity);
            _unitOfWork.Complete();
            return CartItementity;
        }



        // GET: api/CartItems/GetByName
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.CartItems.Find(b => b.productName == "New CartItem", new[] { "Product" }));
        }
        //// GET: api/CartItems/GetAllWithCategorys
        //[HttpGet("GetAllWithCategorys")]
        //public IActionResult GetAllWithCategorys()
        //{
        //    return Ok(_unitOfWork.CartItems.FindAll(b => b.productName.Contains("New CartItem"), new[] { "Product" }));
        //}




        // GET: api/CartItems/GetItemsFiltered
        [HttpGet("GetItemsFiltered")]
        public IActionResult GeItemsFiltered(int PriceFrom , int PriceTo)
        {if(PriceFrom ==0 && PriceTo == 0)
            {
                return Ok(_unitOfWork.CartItems.GetAll());
            }
            return Ok(_unitOfWork.CartItems.FindAll(b => b.Price<=PriceTo && b.Price>=PriceFrom, new[] { "Product" }));
        }
        // GET: api/CartItems/GetOrdered
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.CartItems.FindAll(b => b.productName.Contains("New CartItem"), null, null, b => b.Id, OrderBy.Descending));
        }



    }
}