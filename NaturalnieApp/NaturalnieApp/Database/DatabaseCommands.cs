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
        //Method used to check if given element exist in database
        //Product name and barcode or supplier code are obligatory
        //Method will return existing entity. If nothing from perspectiv of given keys exist in DB, it will return null.
        //====================================================================================================
        public Product CheckIfProductExist(string productName, string barCode = "", string supplierCode = "")
        {
            Product entity = new Product();
            int step = 0;

            using (ShopContext contextDB = new ShopContext())
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
        //Method used calculate Product number in Elzab
        //Formula was specified as ManufacturerId * 100 (taken first empty value)
        //That means, DB can consist maximum 100 product of one manufaturer
        //Method will return first empty number from calculaten area
        //====================================================================================================
        public int CalculateFreeElzabIdForGivenManufacturer(string manufacturerName)
        {
            Manufacturer manufaturer;
            List<int> elzabProductIdList;
            int retVal = -1;

            using (ShopContext contextDB = new ShopContext())
            {
                var query = from m in contextDB.Manufacturers
                            where m.Name == manufacturerName
                            select m;

                //Get manufaturer ID
                manufaturer = query.FirstOrDefault();

                if (manufaturer != null)
                {
                    var query2 = from p in contextDB.Products
                                 where p.ElzabProductId >= 1 && p.ElzabProductId < 99
                                 select p.ElzabProductId;

                    elzabProductIdList = query2.ToList();

                    //Calculate first Id for given manufacturer area
                    int firstElementId = manufaturer.Id * 100;
                    int lastPossibleId = firstElementId + 99;

                    //Sort the list
                    elzabProductIdList.Sort();

                    //Check if there are no gaps in received list and write available Id or return -1
                    if ((elzabProductIdList.Count == elzabProductIdList.Last()))
                    {
                        retVal = elzabProductIdList.Last() + 1;
                        if (retVal > lastPossibleId) retVal = -1;
                    }
                    else
                    {
                        //Calculate first free ElzabID for this manufaturer area
                        for (int i = 1; i <= 99; i++)
                        {
                            if (elzabProductIdList[i - 1] != i)
                            {
                                retVal = i;
                                break;
                            }
                        }

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
        //Method used to check if in DB specified Product name exist
        //====================================================================================================
        public bool CheckIfProductNameExist(string productName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext())
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
            List<string> manufacturersList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var Manufacturer in contextDB.Manufacturers)
                {
                    manufacturersList.Add(Manufacturer.Name);
                }
            }

            return manufacturersList;
        }

        //====================================================================================================
        //Method used to check  if in DB specified Manufacturer Name exist
        //====================================================================================================
        public bool CheckIfManufacturerNameExist(string manufacturerName)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext())
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
        //Method used to retrieve from DB barcode list
        //====================================================================================================
        public List<string> GetBarcodeList()
        {
            List<string> barcodeList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
            {
                foreach (var product in contextDB.Products)
                {
                    barcodeList.Add(product.BarCode);
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

            using (ShopContext contextDB = new ShopContext())
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
        //Method used to retrieve from DB supplier code list
        //====================================================================================================
        public List<string> GetSupplierCodeList()
        {
            List<string> supplierCodeList = new List<string>();

            using (ShopContext contextDB = new ShopContext())
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

            using (ShopContext contextDB = new ShopContext())
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

            using (ShopContext contextDB = new ShopContext())
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

            using (ShopContext contextDB = new ShopContext())
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
        //Method used to retrieve from DB manufacturer EAN barcode prefix, if exist
        //====================================================================================================
        public string GetManufacturerEanPrefixByName(string manufacturerName)
        {
            string eanPrefix = "";

            using (ShopContext contextDB = new ShopContext())
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
        //Method used to add new manufacturer
        //====================================================================================================
        public void AddManufacturer(Manufacturer manufacturer)
        {
            using (ShopContext contextDB = new ShopContext())
            {
                contextDB.Manufacturers.Add(manufacturer);
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
