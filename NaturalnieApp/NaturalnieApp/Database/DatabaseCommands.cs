using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Data.Entity;

namespace NaturalnieApp.Database
{
    public class DatabaseCommands
    {
        //====================================================================================================
        //Class fields
        //====================================================================================================
        public bool ConnectionStatus { get; set; }

        //====================================================================================================
        //Class constructor
        //====================================================================================================
        public DatabaseCommands()
        {
            this.ConnectionStatus = false;
        }

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
        //Method used to retrieve from DB Product and supplier entity
        //====================================================================================================
        public (Product product, Supplier supplier) GetProductAndSupplierEntityByProductName(string productName)
        {
            Product localProduct = new Product();
            Supplier localSupplier = new Supplier();

            using (ShopContext contextDB = new ShopContext())
            {
                var query = (from p in contextDB.Products
                             join s in contextDB.Suppliers
                             on p.SupplierId equals s.Id
                             where p.ProductName == productName
                             select new
                             {
                                 p,
                                 s
                             });

                foreach (var element in query)
                {
                    localProduct  = element.p;
                    localSupplier = element.s;
                    ;
                }
                //localProduct = query.SingleOrDefault();
            }
            return (localProduct, localSupplier);
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
        //Method used to edit product
        //====================================================================================================
        public void EditProduct(Product product)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Products.Add(product);
                contextDB.Entry(product).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();
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
                int retVal = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to edit product
        //====================================================================================================
        public void EditSupplier(Supplier supplier)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Suppliers.Add(supplier);
                contextDB.Entry(supplier).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();
            }
        }
        //====================================================================================================
        //Method used to check if database connnection exist.
        //====================================================================================================
        public void CheckConnection(bool showMessage)
        {

            bool state = false;

            using (ShopContext contextDB = new ShopContext())
            {
                try
                {
                    contextDB.Database.Connection.Open();
                    contextDB.Database.Connection.Close();
                    state = true;
                }
                catch (Exception ex)
                {
                    if (showMessage) MessageBox.Show(ex.ToString());
                    state = false;
                }
            }
            this.ConnectionStatus = state;
        }


    }


}
