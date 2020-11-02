using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System.Threading.Tasks;


namespace NaturalnieApp.Database
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductElement> Product { get; set; }

        public DbSet<ProductSuppliers> ProductSuppliers { get; set; }

        public ShopContext()
            : base("shop")
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }

    }

}
