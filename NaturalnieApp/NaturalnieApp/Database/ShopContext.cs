using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;


namespace NaturalnieApp.Database
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ShopContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public DbSet<Suppliers> ProductSuppliers { get; set; }

        public ShopContext()
            : base("shop")
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public ShopContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().MapToStoredProcedures();
        }

    }

}
