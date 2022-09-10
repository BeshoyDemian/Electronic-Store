using WebApi.DAL.Interfaces;
using WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        IEnumerable<Product> IProductsRepository.GetProductsWithCategories(int pageIndex, int pageSize)
        {
            return _context.Products
              .Include(c => c.Category)
              .OrderBy(c => c.Name)
              .Skip((pageIndex - 1) * pageSize)
              .Take(pageSize)
              .ToList();
        }

        IEnumerable<Product> IProductsRepository.GetTopSellingProducts(int count)
        {
            return _context.Products.OrderByDescending(c => c.Price).Take(count).ToList();
            throw new NotImplementedException();
        }
    }
}