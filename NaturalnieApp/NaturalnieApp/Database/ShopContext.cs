using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;


namespace NaturalnieApp.Database
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Tax> Tax { get; set; }

        public ShopContext()
            : base("shop")
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public ShopContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }
    }

}
