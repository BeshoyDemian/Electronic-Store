using WebApi.DAL;
using WebApi.DAL.Interfaces;
using WebApi.DAL.Models;
using WebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoriesRepository Categories { get; private set; }
        public IProductsRepository Products { get; private set; }
        public ICartItemsRepository CartItems { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public IOrderItemsRepository OrderItems { get; private set; }
        public IFavoritesRepository Favorites { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Orders = new OrdersRepository(_context);
            Favorites = new FavoritesRepository(_context);
            OrderItems = new OrderItemsRepository(_context);
            Categories = new CategoriesRepository(_context);
            Products = new ProductsRepository(_context);
            CartItems = new CartItemsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}