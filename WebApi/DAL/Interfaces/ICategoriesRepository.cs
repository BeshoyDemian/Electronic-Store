﻿using WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Category>
    {
        //Category Get(int id);

    }
}