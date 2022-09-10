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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync(new[] { "Category" });
        }
        
        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var Product = _unitOfWork.Products.GetById(id);
            return Product;
        }
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product Product)
        {
            Product.Id = id;

            _unitOfWork.Products.Put(Product);

           
                _unitOfWork.Complete();
           
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult AddProduct(Product Productentity)
        {
            _unitOfWork.Products.Add(Productentity);
            _unitOfWork.Complete();
            return CreatedAtAction("GetById", new { id = Productentity.Id }, Productentity);
        }
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var Productentity = await _unitOfWork.Products.FindAsync(b => b.Id == id);
            if (Productentity == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Delete(Productentity);
            _unitOfWork.Complete();
            return Productentity;
        }



        // GET: api/Products/GetByName
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Products.Find(b => b.Name == "New Product", new[] { "Category" }));
        }
        // GET: api/Products/GetAllWithCategorys
        [HttpGet("GetAllWithCategorys")]
        public IActionResult GetAllWithCategorys()
        {
            return Ok(_unitOfWork.Products.FindAll(b => b.Name.Contains("New Product"), new[] { "Category" }));
        }
        // GET: api/Products/GetProductsFiltered
        [HttpGet("GetProductsFiltered")]
        public IActionResult GetProductsFiltered(int PriceFrom, int PriceTo)
        {
            if (PriceFrom == 0 && PriceTo == 0)
            {
                return Ok(_unitOfWork.Products.GetAll());
            }
            else if(PriceTo == 0)
            {
                return Ok(_unitOfWork.Products.FindAll(b => b.Price >= PriceFrom, new[] { "Category" }));
            }
            else if(PriceFrom == 0)
            {
                return Ok(_unitOfWork.Products.FindAll(b => b.Price <= PriceTo , new[] { "Category" }));

            }

            return Ok(_unitOfWork.Products.FindAll(b => b.Price <= PriceTo && b.Price >= PriceFrom, new[] { "Category" }));
        }
        // GET: api/Products/GetOrdered
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Products.FindAll(b => b.Name.Contains("New Product"), null, null, b => b.Id, OrderBy.Descending));
        }



    }
}