﻿using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Data.Entity;
using static NaturalnieApp.Program;

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
            this.CheckConnection(false);
        }

        //====================================================================================================
        //Method used to check if given element exist in database
        //Product name and barcode or supplier code are obligatory
        //Method will return existing entity. If nothing from perspectiv of given keys exist in DB, it will return null.
        //====================================================================================================
        public Product CheckIfProductExist(string productName, string barCode = "", string supplierCode = "")
        {
            Product entity = new Product();
            int step = 0;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                //Check if product name already exist. If not, continue checking
                if (productName != "")
                {
                    //Create query to database
                    var queryProductName = from p in contextDB.Products
                                           where p.ProductName == productName
                                           select p;

                    entity = queryProductName.FirstOrDefault();
                    if ((entity == null) && (barCode != "")) step = 1;
                    else if ((entity == null) && (supplierCode != "")) step = 2;
                }
                //Next check bar code
                if (barCode != "" && step == 1)
                {
                    //Create query to database
                    var queryBarCode = from p in contextDB.Products
                                       where p.BarCode == barCode
                                       select p;

                    entity = queryBarCode.FirstOrDefault();
                    if ((entity == null) && (barCode != "")) step = 2;

                }
                //Next check supplier code
                if (supplierCode != "" && step == 2)
                {
                    //Create query to database
                    var querySupplierCode = from p in contextDB.Products
                                       where p.SupplierCode == supplierCode
                                       select p;

                    entity = querySupplierCode.FirstOrDefault();
                }
            }
            
            return entity;
        }

        //====================================================================================================
        // Method used to update all product final prices
        //====================================================================================================
        public void UpdateAllFinalPrices(List<string> productNames)
        {
            try
            {
                foreach (string element in productNames)
                {
                    using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
                    {
                        var query = from p in contextDB.Products
                                    where p.ProductName == element
                                    select p;
                        Product product = query.FirstOrDefault();
                        Tax tax = GetTaxByProductName(product.ProductName);
                        product.FinalPrice = Calculations.CalculateFinalPriceFromProduct(product, tax.TaxValue);

                        EditProduct(product);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //====================================================================================================
        // Method used to update all product marigins values
        //====================================================================================================
        public void UpdateAllMariginValues(List<string> productNames, int newMarigin)
        {
            try
            {
                foreach (string element in productNames)
                {
                    using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
                    {
                        var query = from p in contextDB.Products
                                    where p.ProductName == element
                                    select p;
                        Product product = query.FirstOrDefault();
                        product.Marigin = newMarigin;
                        EditProduct(product);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        //====================================================================================================
        // Method used to update all product discount values
        //====================================================================================================
        public void UpdateAllDiscountValues(List<string> productNames, int newDiscount)
        {
            try
            {
                foreach (string element in productNames)
                {
                    using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
                    {
                        var query = from p in contextDB.Products
                                    where p.ProductName == element
                                    select p;
                        Product product = query.FirstOrDefault();
                        product.Discount = newDiscount;
                        EditProduct(product);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        //====================================================================================================
        // Method used to recalculate all PriceNetWithDiscount based on discount value nad PriceNet
        //====================================================================================================
        public void UpdateAllPriceNetWithDiscountValues(List<string> productNames)
        {
            try
            {
                foreach (string element in productNames)
                {
                    using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
                    {
                        var query = from p in contextDB.Products
                                    where p.ProductName == element
                                    select p;
                        Product product = query.FirstOrDefault();
                        product.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscountFromProduct(product);

                        EditProduct(product);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        ///====================================================================================================
        ///<summary> Method used calculate Product number in Elzab
        ///Formula was specified as ManufacturerId * 100 (taken first empty value)
        ///That means, DB can consist maximum 100 product of one manufaturer
        ///Method will return first empty number from calculaten area
        ///</summary>
        public int CalculateFreeElzabIdForGivenManufacturer(string manufacturerName)
        {
            Manufacturer manufaturer;
            List<int> elzabProductIdList = new List<int>();


            //Return value
            int retVal = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m;

                //Get manufaturer ID
                manufaturer = query.FirstOrDefault();

                if (manufaturer != null)
                {

                    //Local settings
                    int numberOfProductPerManufacturer = manufaturer.MaxNumberOfProducts;

                    //Calculate first Id for given manufacturer area
                    int firstElementId = manufaturer.FirstNumberInCashRegister;
                    int lastPossibleId = manufaturer.LastNumberInCashRegister;

                    var query2 = from p in contextDB.Products
                                 where p.ElzabProductId >= firstElementId && p.ElzabProductId < lastPossibleId
                                 select p.ElzabProductId;

                    elzabProductIdList = query2.ToList();


                    //Sort the list
                    elzabProductIdList.Sort();

                    if (elzabProductIdList.Count() > 0)
                    {
                        //Check if there are no gaps in received list and write available Id or return -1
                        if (elzabProductIdList.Count() == 1)
                        {
                            retVal = elzabProductIdList.Last() + 1;
                            if (retVal > lastPossibleId) retVal = -1;
                        }
                        else
                        {
                            //Check if any gap in actual sequence of IDs
                            for (int i = 0; i < elzabProductIdList.Count(); i++)
                            {
                                //Recalculate theoretical value of product at given index. If not match use it
                                int theoVal = firstElementId + i;

                                //Check value and if not match, assign theoretical one
                                if (elzabProductIdList[i] != theoVal)
                                {
                                    retVal = theoVal;
                                    break;
                                }
                            }

                            //If no gap, assign first free value
                            if((retVal == -1) && (elzabProductIdList.Count() < numberOfProductPerManufacturer))
                            {
                                retVal = elzabProductIdList.Last() + 1;
                            }
                        }
                    }
                    else if (elzabProductIdList.Count() == 0)
                    {
                        retVal = firstElementId;
                    }
                }

            }
            return retVal;
        }

        //====================================================================================================
        //Method used to retrieve from DB product name list
        //====================================================================================================
        public List<string> GetProductsNameList()
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var product in contextDB.Products)
                {
                    productList.Add(product.ProductName);
                }
            }
            return productList;
        }

        //====================================================================================================
        //Method used to check if in DB specified Product name exist
        //====================================================================================================
        public bool CheckIfProductNameExist(string productName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to retrieve from DB product name list, fitered by a specific manufacturer
        //====================================================================================================
        public List<string> GetProductsNameListByManufacturer(string manufacturerName)
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
        //Method used to retrieve from DB barcode list, fitered by a specific manufacturer
        //====================================================================================================
        public List<string> GetBarcodesListByManufacturer(string manufacturerName)
        {
            List<string> productList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
                    productList.Add(products.BarCode);
                }

            }
            return productList;
        }

        //====================================================================================================
        //Method used to retrieve from DB Manufacturer name list
        //====================================================================================================
        public List<string> GetManufacturersNameList()
        {
            List<string> manufacturersList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var Manufacturer in contextDB.Manufacturers)
                {
                    manufacturersList.Add(Manufacturer.Name);
                }
            }

            return manufacturersList;
        }

        //====================================================================================================
        //Method used to retrieve from DB Supplier name list
        //====================================================================================================
        public List<string> GetSupplierNameList()
        {
            List<string> supplierList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var Supplier in contextDB.Suppliers)
                {
                    supplierList.Add(Supplier.Name);
                }
            }

            return supplierList;
        }

        //====================================================================================================
        //Method used to check  if in DB specified Manufacturer Name exist
        //====================================================================================================
        public bool CheckIfManufacturerNameExist(string manufacturerName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to retrieve from DB Tax entity
        //====================================================================================================
        public Tax GetTaxEntityByValue(int value)
        {
            Tax localTax = new Tax();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from t in contextDB.Tax
                            where t.TaxValue == value
                            select t;

                localTax = query.SingleOrDefault();
            }
            return localTax;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax list
        //====================================================================================================
        public List<string> GetTaxList()
        {
            List<string> taxList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var tax in contextDB.Tax)
                {
                    taxList.Add(tax.TaxValue.ToString()) ;
                }
            }
            return taxList;
        }

        //====================================================================================================
        //Method used to retrieve from DB barcode list
        //====================================================================================================
        public List<string> GetBarcodeList()
        {
            List<string> barcodeList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var product in contextDB.Products)
                {
                    if (product.BarCode == "")
                    {
                        barcodeList.Add(product.BarCodeShort);
                    }
                    else 
                    {
                        barcodeList.Add(product.BarCode);
                    }

                }
            }
            return barcodeList;
        }

        //====================================================================================================
        //Method used to check if in DB specified Barcode exist
        //====================================================================================================
        public bool CheckIfBarcodeExist(string barcode)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.BarCode == barcode
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to check if in DB specified Barcode shirt exist
        //====================================================================================================
        public bool CheckIfBarcodeShortExist(string barcode)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.BarCodeShort == barcode
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to retrieve from DB supplier code list
        //====================================================================================================
        public List<string> GetSupplierCodeList()
        {
            List<string> supplierCodeList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var product in contextDB.Products)
                {
                    supplierCodeList.Add(product.SupplierCode);
                }
            }
            return supplierCodeList;
        }

        //====================================================================================================
        //Method used to check if in DB specified supplier Code exist
        //====================================================================================================
        public bool CheckIfSupplierCodeExist(string supplierCode)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.SupplierCode == supplierCode
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to check if in DB specified Supplier name exist
        //====================================================================================================
        public bool CheckIfSupplierNameExist(string supplierName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Suppliers
                            where s.Name == supplierName
                            select s;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to check if in DB specified Elzab product ID already exist
        //====================================================================================================
        public bool CheckIfElzabProductIdExist(int elzabProductId)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ElzabProductId == elzabProductId
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to check if in DB specified Elzab product ID already exist
        //====================================================================================================
        public bool CheckIfElzabProductNameExist(string elzabProductName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ElzabProductName == elzabProductName
                            select p;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }

            return result;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax list
        //====================================================================================================
        public List<string> GetTaxListRetString()
        {
            List<string> taxList = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName
                            select p.Id;

                productId = query.SingleOrDefault();
            }

            return productId;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product Name using product Id
        //====================================================================================================
        public string GetProductNameById(int id)
        {
            string productName;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.Id == id
                            select p.ProductName;

                productName = query.SingleOrDefault();
            }

            return productName;
        }

        //====================================================================================================
        //Method used to retrieve from DB Supplier value using Supplier name
        //====================================================================================================
        public int GetSupplierIdByName(string supplierName)
        {
            int supplierId = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m.Id;

                manufacturerId = query.SingleOrDefault();
            }

            return manufacturerId;
        }

        //====================================================================================================
        //Method used to retrieve from DB manufacturer EAN barcode prefix, if exist
        //====================================================================================================
        public string GetManufacturerEanPrefixByName(string manufacturerName)
        {
            string eanPrefix = "";

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m.BarcodeEanPrefix;

                eanPrefix = query.SingleOrDefault();
            }
            return eanPrefix;
        }

        //====================================================================================================
        //Method used to retrieve from DB tax value using tax name
        //====================================================================================================
        public int GetTaxIdByValue(int taxValue)
        {
            int taxId = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from t in contextDB.Tax
                           where t.TaxValue == taxValue
                           select t.Id;

                taxId = query.SingleOrDefault();
            }

            return taxId;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity taking product Id
        //====================================================================================================
        public Product GetProductEntityById(int productId)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.Id == productId
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
            }

        //====================================================================================================
        //Method used to retrieve from DB Product entity
        //====================================================================================================
        public Product GetProductEntityByProductName(string productName)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity by elzab Id
        //====================================================================================================
        public Product GetProductEntityByElzabId(int Id)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ElzabProductId == Id
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity
        //====================================================================================================
        public Product GetProductEntityByProductId(int productId)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.Id == productId
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity by Barcode value
        //====================================================================================================
        public Product GetProductEntityByBarcode(string barcode)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.BarCode == barcode
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used to retrieve from DB eAN13 barcode from internal EAN8 code
        //====================================================================================================
        public string GetEAN13FromShortBarcode(string shortBarcode)
        {
            string localProduct;
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.BarCodeShort == shortBarcode
                            select p.BarCode;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used recalculate all short barcodes from DB
        //====================================================================================================
        public void RecalculateAllShortBarcodes()
        {
            Product localProduct;
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            select p;

                foreach (Product element in query)
                {
                    localProduct = element;
                    localProduct.BarCodeShort = BarcodeRelated.GenerateEan8(element.ManufacturerId, element.ElzabProductId);
                    EditProduct(localProduct);
                }
            }
        }

        //====================================================================================================
        //Method used to retrieve from DB Manufacturer entity
        //====================================================================================================
        public Manufacturer GetManufacturerEntityByName(string manufacturerName)
        {
            Manufacturer localManufacturer = new Manufacturer();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m;

                localManufacturer = query.SingleOrDefault();
            }
            return localManufacturer;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product entity
        //====================================================================================================

        public Manufacturer GetManufacturerByProductName(string productName)
        {
            Manufacturer localManufacturer = new Manufacturer();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
        //Method used to retrieve from DB Manufacturer entity
        //====================================================================================================

        public Manufacturer GetManufacturerByBarcode(string barcode)
        {
            Manufacturer localManufacturer = new Manufacturer();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            join m in contextDB.Manufacturers
                            on p.ManufacturerId equals m.Id
                            where p.BarCode == barcode
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
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
        //Method used to retrieve from DB quantity of given product in stock
        //====================================================================================================
        public int GetProductQuantityInStock(string productName)
        {
            int localQuantity = 0;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            join p in contextDB.Products
                            on s.ProductId equals p.Id
                            where p.ProductName == productName
                            select new
                            {
                                s
                            };
                foreach (var element in query)
                {
                    localQuantity += element.s.ActualQuantity;
                }
            }
            return localQuantity;
        }

        //====================================================================================================
        //Method used to add new product
        //====================================================================================================
        public void AddNewProduct(Product product)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Suppliers.Add(supplier);
                int retVal = contextDB.SaveChanges();

            }
        }

        //====================================================================================================
        //Method used to add new manufacturer
        //====================================================================================================
        public void AddManufacturer(Manufacturer manufacturer)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Manufacturers.Add(manufacturer);
                int retVal = contextDB.SaveChanges();

            }
        }

        //====================================================================================================
        //Method used to get stock entity from user prepared stock entity
        //====================================================================================================
        public Stock GetStockEntityByUserStock(Stock stockProduct)
        {
            Stock localStock = new Stock();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            where s.ProductId == stockProduct.ProductId &&
                            s.ExpirationDate == stockProduct.ExpirationDate &&
                            s.BarcodeWithDate == stockProduct.BarcodeWithDate
                            select s;

                localStock = query.FirstOrDefault();
            }
            return localStock;
        }

        //====================================================================================================
        //Method used to get stock entity from product ID
        //====================================================================================================
        public int GetStockQuantity(int productId)
        {
            int quantity = 0;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            where s.ProductId == productId
                            select s;

                foreach (Stock element in query)
                {
                    quantity += element.ActualQuantity;
                }

            }
            return quantity;
        }


        //====================================================================================================
        //Method used to get stock entity from with given manufacturer ID
        //====================================================================================================
        public List<Stock> GetStockEntsWithManufacturerId(int manufacturerId)
        {

            List<Stock> localStock = new List<Stock>();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            join p in contextDB.Products on s.ProductId equals p.Id
                            join m in contextDB.Manufacturers on p.ManufacturerId equals m.Id
                            where m.Id == manufacturerId
                            select new
                            {
                                s
                            };

                foreach (var element in query)
                {
                    localStock.Add(element.s);
                }

            }
            return localStock;
        }

        //====================================================================================================
        //Method used to get all stock entity
        //====================================================================================================
        public List<Stock> GetAllStockEnts()
        {

            List<Stock> localStock = new List<Stock>();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            select new
                            {
                                s
                            };

                foreach (var element in query)
                {
                    localStock.Add(element.s);
                }

            }
            return localStock;
        }


        //====================================================================================================
        //Method used to check if specified product already exist in stock
        //====================================================================================================
        public bool CheckIfProductExistInStock(Stock stockProduct)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            where s.ProductId == stockProduct.ProductId &&
                            s.ExpirationDate == stockProduct.ExpirationDate &&
                            s.BarcodeWithDate == stockProduct.BarcodeWithDate
                            select s;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }
            return result;
        }

        //====================================================================================================
        //Method used to add to stock
        //====================================================================================================
        public void AddToStock(Stock stockPiece)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Stock.Add(stockPiece);
                int retVal = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to edit product product in stock
        //====================================================================================================
        public void EditInStock(Stock stockProduct)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Stock.Add(stockProduct);
                contextDB.Entry(stockProduct).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to edit product
        //====================================================================================================
        public void EditProduct(Product product)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
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

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                try
                {
                    contextDB.Database.Connection.Open();
                    contextDB.Database.Connection.Close();
                    state = true;
                }
                catch (Exception ex)
                {
                    if (showMessage) MessageBox.Show(ex.Message);
                    state = false;
                }
            }
            this.ConnectionStatus = state;
        }


    }


}
