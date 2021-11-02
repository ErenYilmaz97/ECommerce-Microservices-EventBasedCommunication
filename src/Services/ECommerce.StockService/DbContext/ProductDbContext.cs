using ECommerce.StockService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.StockService
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
