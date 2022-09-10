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
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdersRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}