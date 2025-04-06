using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProductApiEfApp.Models;

namespace ProductApiEfApp.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=products.db");
        }
    }
}
