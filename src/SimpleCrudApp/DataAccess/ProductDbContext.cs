﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Models;

namespace SimpleCrudApp.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        {

        }
        public DbSet<ProductModel> Product { get; set; }
    }
}
