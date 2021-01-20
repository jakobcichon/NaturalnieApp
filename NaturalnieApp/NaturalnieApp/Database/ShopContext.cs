using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;


namespace NaturalnieApp.Database
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductChangelog> ProductsChangelog { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockHistory> StockHistory { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Tax> Tax { get; set; }

        public ShopContext()
            : base("shop")
        {

        }

        public ShopContext(string connectionString)
            : base(connectionString)
        {

        }
        // Constructor to use on a DbConnection that is already opened
        public ShopContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

    }

}
