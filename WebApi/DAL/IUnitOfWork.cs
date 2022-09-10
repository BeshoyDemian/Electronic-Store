using WebApi.DAL.Interfaces;
using WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        IFavoritesRepository Favorites { get; }
        ICartItemsRepository CartItems { get; }
        ICategoriesRepository Categories { get; }
        IOrdersRepository Orders { get; }
        IOrderItemsRepository OrderItems { get; }
        int Complete();
    }
}