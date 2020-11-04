using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
namespace NaturalnieApp.Database
{
    public class DatabaseCommands
    {
        string connectionString = "server=DESKTOP-L2L4V68;port=3306;database=shop;uid=admin;password=admin";


        //Method used to retrieve from DB product name lsit
        public List<string> GetProductsNameList()
        {
            List<string> productsList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(connection, false))
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

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(connection, false))
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
    }


}
