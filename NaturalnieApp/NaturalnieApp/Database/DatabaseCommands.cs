using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
namespace NaturalnieApp.Database
{
    public class DatabaseCommands
    {
        //string connectionString = "server=DESKTOP-L2L4V68;port=3306;database=shop;uid=admin;password=admin";
        string connectionString = "server=DESKTOP-ACAAKBG;port=3306;database=shop;uid=admin;password=admin";
        MySqlConnection mySqlConnection { get; set; }


        public DatabaseCommands()
        {
            this.mySqlConnection = new MySqlConnection(this.connectionString);
        }
        

        //Method used to retrieve from DB product name lsit
        public List<string> GetProductsNameList()
        {
            List<string> productsList = new List<string>();

            using (this.mySqlConnection)
            {
                this.mySqlConnection.Open();
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(this.mySqlConnection, false))
                {
                    foreach (var product in contextDB.Product)
                    {
                        productsList.Add(product.ProductName);
                    }
                }
            }

            return productsList;
        }

        //Method used to retrieve from DB Product entity
        public Product GetProductEntityByProductName(string productName)
        {
            Product localProduct = new Product();

            using (this.mySqlConnection)
            {
                this.mySqlConnection.Open();
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(this.mySqlConnection, false))
                {
                    var query = from p in contextDB.Product
                                where p.ProductName == productName
                                select p;

                    localProduct = query.SingleOrDefault();
                    ;
                }
            }

            return localProduct;
        }

        //Method used to add new product
        public void AddNewProduct(Product product)
        {
            using (this.mySqlConnection)
            {
                this.mySqlConnection.Open();
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(this.mySqlConnection, false))
                {

                    contextDB.Product.Add(product);
                    int test = contextDB.SaveChanges();
                    ;
                }
            }
        }

        public void AddNewProduct2(Product product)
        {
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext())
                {

                    contextDB.Product.Add(product);
                    
                    int test = contextDB.SaveChanges();
                    ;
                }
     
        }
    }


}
