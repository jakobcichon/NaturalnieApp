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
                            join m in contextDB.Manufacturers
                            on p.ManufacturerId equals m.Id
                            where m.Name == manufacturerName
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
        //Method used to retrieve from DB Manufacturer name list
        //====================================================================================================
        public List<string> GetManufacturersNameList()
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var Manufacturer in contextDB.Manufacturers)
                {
                    productList.Add(Manufacturer.Name);
                }
            }

            return productList;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax list
        //====================================================================================================
        public List<int> GetTaxList()
        {
            List<int> taxList = new List<int>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var tax in contextDB.Tax)
                {
                    taxList.Add(tax.TaxValue);
                }
            }
            return taxList;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax list
        //====================================================================================================
        public List<string> GetTaxListRetString()
        {
            List<string> taxList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var tax in contextDB.Tax)
                {
                    taxList.Add(tax.TaxValue.ToString());
                }
            }
            return taxList;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product value using Product name
        //====================================================================================================
        public int GetProductIdByName(string productName)
        {
            int productId = -1;

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName
                            select p.Id;

                productId = query.SingleOrDefault();
            }

            return productId;
        }

        //====================================================================================================
        //Method used to retrieve from DB Supplier value using Supplier name
        //====================================================================================================
        public int GetSupplierIdByName(string supplierName)
        {
            int supplierId = -1;

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from s in contextDB.Suppliers
                            where s.Name == supplierName
                            select s.Id;

                supplierId = query.SingleOrDefault();
            }

            return supplierId;
        }

        //====================================================================================================
        //Method used to retrieve from DB Manufacturer value using Manufacturer name
        //====================================================================================================
        public int GetManufacturerIdByName(string manufacturerName)
        {
            int manufacturerId = -1;

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m.Id;

                manufacturerId = query.SingleOrDefault();
            }

            return manufacturerId;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax value using tax name
        //====================================================================================================
        public int GetTaxIdByValue(int taxValue)
        {
            int taxId = -1;

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from t in contextDB.Tax
                           where t.TaxValue == taxValue
                           select t.Id;

                taxId = query.SingleOrDefault();
            }

            return taxId;
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
        //Method used to retrieve from DB Product entity
        //====================================================================================================

        public Manufacturer GetManufacturerByProductName(string productName)
        {
            Manufacturer localManufacturer = new Manufacturer();
            using (ShopContext contextDB = new ShopContext())
            {
                var query = from p in contextDB.Products
                            join m in contextDB.Manufacturers
                            on p.ManufacturerId equals m.Id
                            where p.ProductName == productName
                            select new
                            {
                                m
                            };

                foreach (var element in query)
                {
                    localManufacturer = element.m;
                }

            }
            return localManufacturer;
        }
        //====================================================================================================
        //Method used to retrieve from DB Product entity
        //====================================================================================================
        public Tax GetTaxByProductName(string productName)
        {
            Tax localTax = new Tax();
            using (ShopContext contextDB = new ShopContext())
            {
                var query = from p in contextDB.Products
                            join t in contextDB.Tax
                            on p.TaxId equals t.Id
                            where p.ProductName == productName
                            select new
                            {
                                t
                            };

                foreach (var element in query)
                {
                    localTax = element.t;
                }

            }
            return localTax;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product and supplier entity
        //====================================================================================================
        public Supplier GetSupplierByProductName(string productName)
        {
            Supplier localSupplier = new Supplier();

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from p in contextDB.Products
                             join s in contextDB.Suppliers
                             on p.SupplierId equals s.Id
                             where p.ProductName == productName
                             select new
                             {
                                 s
                             };

                foreach (var element in query)
                {
                    localSupplier = element.s;
                }
                //localProduct = query.SingleOrDefault();
            }
            return localSupplier;
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
                int retVal = contextDB.SaveChanges();
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
        //Method used to edit table
        //====================================================================================================

        public void EditManufacturer(Manufacturer manufacturer)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Manufacturers.Add(manufacturer);
                contextDB.Entry(manufacturer).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();
            }
        }
        //====================================================================================================
        //Method used to edit table
        //====================================================================================================

        public void EditTax(Tax Tax)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Tax.Add(Tax);
                contextDB.Entry(Tax).State = EntityState.Modified;
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
