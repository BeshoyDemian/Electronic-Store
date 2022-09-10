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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Categories/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Categories.GetById(id));
        }

        // GET: api/Categories/
        [HttpGet]
        public  IEnumerable<Category> GetAll()
        {
             return _unitOfWork.Categories.GetAll();
          
        }
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category Category)
        {
            Category.Id = id;

            _unitOfWork.Categories.Put(Category);


            _unitOfWork.Complete();

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult AddCategory(Category Categoryentity)
        {
            _unitOfWork.Categories.Add(Categoryentity);
            _unitOfWork.Complete();
            return CreatedAtAction("GetById", new { id = Categoryentity.Id }, Categoryentity);
        }
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var Categoryentity = await _unitOfWork.Categories.FindAsync(b => b.Id == id);
            if (Categoryentity == null)
            {
                return NotFound();
            }
            _unitOfWork.Categories.Delete(Categoryentity);
            _unitOfWork.Complete();
            return Categoryentity;
        }

    }
}