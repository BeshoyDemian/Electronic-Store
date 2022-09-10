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
    public class FavoritesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoritesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Favorites/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Favorites.GetById(id));
        }

        // GET: api/Favorites/
        [HttpGet]
        public  IEnumerable<Favorite> GetAll()
        {
             return _unitOfWork.Favorites.GetAll();
          
        }
        // PUT: api/Favorites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite(int id, Favorite Favorite)
        {
            Favorite.Id = id;

            _unitOfWork.Favorites.Put(Favorite);


            _unitOfWork.Complete();

            return NoContent();
        }

        // POST: api/Favorites
        [HttpPost]
        public IActionResult AddFavorite(Favorite favoriteEntity)
        {
            favoriteEntity.UserId = 1;
            _unitOfWork.Favorites.Add(favoriteEntity);
            _unitOfWork.Complete();
            return CreatedAtAction("GetById", new { id = favoriteEntity.Id }, favoriteEntity);
        }
        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Favorite>> DeleteFavorite(int id)
        {
            var Favoriteentity = await _unitOfWork.Favorites.FindAsync(b => b.ProductId == id && b.UserId ==1);
            if (Favoriteentity == null)
            {
                return NotFound();
            }
            _unitOfWork.Favorites.Delete(Favoriteentity);
            _unitOfWork.Complete();
            return Favoriteentity;
        }

    }
}