using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
namespace NaturalnieApp.Database
{
    public class DatabaseCommands
    {
        //====================================================================================================
        //Method used to retrieve from DB product name list
        //====================================================================================================
        public List<string> GetProductsNameList()
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var product in contextDB.Products)
                {
                    productList.Add(product.ProductName);
                }
            }

            return productList;
        }

        //====================================================================================================
        //Method used to retrieve from DB product name list, fitered by a specific manufacturer
        //====================================================================================================
        public List<string> GetProductsNameListByManufacturer(string manufacturerName)
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                //Create query to database
                var query = from p in contextDB.Products
                            where p.Manufacturer == manufacturerName
                            select p;

                //Add product names to the list
                foreach (var products in query)
                {
                    productList.Add(products.ProductName);
                }

            }
            return productList;
        }

        //====================================================================================================
        //Method used to retrieve from DB supplier name list
        //====================================================================================================
        public List<string> GetSuppliersNameList()
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var supplier in contextDB.Suppliers)
                {
                    productList.Add(supplier.Name);
                }
            }

            return productList;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity
        //====================================================================================================
        public Product GetProductEntityByProductName(string productName)
        {
            Product localProduct = new Product();

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName
                            select p;

                localProduct = query.SingleOrDefault();
            }

            return localProduct;
        }

        //====================================================================================================
        //Method used to add new product
        //====================================================================================================
        public void AddNewProduct(Product product)
        { 
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Products.Add(product);
                int test = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to add new supplier
        //====================================================================================================
        public void AddSupplier(Supplier supplier)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Suppliers.Add(supplier);
                int test = contextDB.SaveChanges();
            }
        }


    }


}
