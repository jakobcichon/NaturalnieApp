using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;
using static NaturalnieApp.Program;
using System.Diagnostics;
using System.Reflection;

namespace NaturalnieApp.Database
{

    //====================================================================================================
    //DB Backup class
    //====================================================================================================
    public static class DatabaseBackup
    {
        //Mehtod used to make DB backup
        static public bool MakeBackup(string userName, string password, string dbName, string pathForBackup)
        {

            try
            {
                string directoryForBackup = CreateBackupDirectory(pathForBackup);

                //Generate subdirectory name and check if exist
                string date = DateTime.Now.Date.ToString("MM/dd/yyyy");
                string time = DateTime.Now.TimeOfDay.Hours.ToString("00") + "." +
                    DateTime.Now.TimeOfDay.Minutes.ToString("00");

                string fullPath = Path.Combine(directoryForBackup, dbName + "_" + date + "_"  + time);

                string outFileFullPath = "\"" + fullPath + ".sql\"";

                //Generate command called in Windows command prompt
                string command = string.Format("mysqldump.exe -u{0} -p{1} {2} > " + outFileFullPath, userName, password, dbName);
                var processStartInfo = new ProcessStartInfo();
                processStartInfo.WorkingDirectory = pathForBackup;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.FileName = "cmd.exe";
                processStartInfo.Arguments = "/C " + command;
                Process proc = Process.Start(processStartInfo);
                proc.WaitForExit();

                //Check if file exist
                bool exist = File.Exists(fullPath + ".sql");
                if (!exist) return false;
                else return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }



        }

        //Method used to create directory for db backup
        //Created directory consist date and time
        static private string CreateBackupDirectory(string pathToCreateIn)
        {
            //Local variable
            string retVal = "";
            bool subFolderCreated = false;
            string subDirName = "";

            try
            {
                //Check if file exist
                bool exist = Directory.Exists(pathToCreateIn);
                if (!exist) Directory.CreateDirectory(pathToCreateIn);

                //Generate subdirectory name and check if exist
                string date = DateTime.Now.Date.ToString("MM/dd/yyyy");
                string time = DateTime.Now.TimeOfDay.Hours.ToString("00") + "." +
                    DateTime.Now.TimeOfDay.Minutes.ToString("00");
                subDirName = Path.Combine(pathToCreateIn, date + "_" + time);

                //Check if backup directory exist
                bool dirExist = Directory.Exists(subDirName);
                if (!dirExist)
                {
                    subFolderCreated = Directory.CreateDirectory(subDirName).Exists;
                }
                else
                {
                    //Try to create another name
                    for (int i = 1; i <= 10; i++)
                    {
                        string candidateDirName = subDirName;
                        candidateDirName += " (" + i + ")";
                        dirExist = Directory.Exists(candidateDirName);
                        if (!dirExist)
                        {
                            Directory.CreateDirectory(candidateDirName);
                            subDirName = candidateDirName;
                            subFolderCreated = true;
                            retVal = subDirName;
                            break;
                        }
                    }
                }
                if (subFolderCreated)
                {
                    retVal = subDirName;
                }
                else
                {
                    MessageBox.Show("Nie udało się utworzyć podfolderu!");
                    retVal = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(string.Format("Kopia zapasowa pliku {0} nie została wykonana!", Path.GetFileName(subDirName)));
                retVal = "";
            }

            return retVal;
        }

        //Method used to initialize mysqldump
        static public void Initialize()
        {
            bool fileExist = CheckIfMySqlDumpExist(GlobalVariables.DbBackupPath);
            if (!fileExist) MoveMySqlDump(GlobalVariables.LibraryPath, GlobalVariables.DbBackupPath);
            
        }

        //Method used to move mysqldump exe file to given location from libs location
        static private void MoveMySqlDump(string sourcePath, string destinationPath)
        {
            //Check if directory exist. If not create one
            bool directoryExist = Directory.Exists(destinationPath);
            if (!directoryExist) Directory.CreateDirectory(destinationPath);

            //Copy mysqldump
            string fullSourcePath = Path.Combine(sourcePath, "mysqldump.exe");
            string fullDestinationPath = Path.Combine(destinationPath, "mysqldump.exe");
            File.Copy(fullSourcePath, fullDestinationPath);
        }

        //Method used to check if mysqldump exe file exist under given path.
        static private bool CheckIfMySqlDumpExist(string mySqlDumpPath)
        {
            string fullPath = Path.Combine(mySqlDumpPath, "mysqldump.exe");
            return File.Exists(fullPath);
        }
    }

    public class FullProductInfo
    {
        public Product ProductEnt { get; set; }
        public Manufacturer ManufacturerEnt { get; set; }
        public Tax TaxEnt { get; set; }
        public Supplier SupplierEnt { get; set; }

        public FullProductInfo()
        {
            this.ProductEnt = new Product();
            this.ManufacturerEnt = new Manufacturer();
            this.TaxEnt = new Tax();
            this.SupplierEnt = new Supplier();
        }

    }

    public class DatabaseCommands
    {
        //====================================================================================================
        //Class fields
        //====================================================================================================
        public bool ConnectionStatus { get; set; }

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
                                 where p.ElzabProductId >= firstElementId && p.ElzabProductId <= lastPossibleId
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
                        else if (elzabProductIdList.Count() == numberOfProductPerManufacturer)
                        {
                            retVal = -1;
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
                            if ((retVal == -1) && (elzabProductIdList.Count() < numberOfProductPerManufacturer))
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

        ///====================================================================================================
        ///<summary> Method used calculate Product number in Elzab
        ///Method will return first empty number from calculaten area
        ///</summary>
        public int CalculateFreeElzabId(int firtElzabNumbertoSearch = 300, int lastNumberToSearch = 4095)
        {
            List<int> elzabProductIdList = new List<int>();

            //Return value
            int retVal = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {

                //Calculate first Id for given manufacturer area
                int firstElementId = firtElzabNumbertoSearch;
                int lastPossibleId = lastNumberToSearch;

                var query2 = from p in contextDB.Products
                             where p.ElzabProductId >= firstElementId && p.ElzabProductId <= lastPossibleId
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
                    else if (elzabProductIdList.Count() == lastPossibleId)
                    {
                        retVal = -1;
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
                        if ((retVal == -1) && (elzabProductIdList.Count() < lastPossibleId))
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
            return retVal;
        }

        ///====================================================================================================
        ///<summary> Method used get number of free elzab Ids
        ///Method will return number of empty Ids
        ///</summary>
        public int GetNumberOfFreeElzabIds(int firtElzabNumbertoSearch = 300, int lastNumberToSearch = 4095)
        {
            //Return value
            int retVal = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = (from p in contextDB.Products
                             select p.ElzabProductId).Count();

                retVal = query;
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
        //Method used to retrieve from DB Tax entity by ID
        //====================================================================================================
        public Tax GetTaxEntityById(int Id)
        {
            Tax localTax = new Tax();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from t in contextDB.Tax
                            where t.Id == Id
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
        //Method used to retrieve from DB Product value using Product barcode
        //====================================================================================================
        public int GetProductIdByBarcode(string barcode)
        {
            int productId = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.BarCode == barcode
                            select p.Id;

                productId = query.SingleOrDefault();
            }

            return productId;
        }

        //====================================================================================================
        //Method used to retrieve from DB Product Id value using Elzab product number
        //====================================================================================================
        public int GetProductIdByElzabProductNumber(int elzabProductNumber)
        {
            int productId = -1;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ElzabProductId == elzabProductNumber
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
        //Method used to retrieve from DB all Manufacturers Ids
        //====================================================================================================
        public List<int> GetAllManufacturersId()
        {
            List<int> manufacturesrList = new List<int>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var manufacturer in contextDB.Manufacturers)
                {
                    manufacturesrList.Add(manufacturer.Id);
                }
            }
            return manufacturesrList;
        }

        //====================================================================================================
        //Method used to retrieve from DB all Products ents
        //====================================================================================================
        public List<Product> GetAllProductsEnts()
        {
            List<Product> productsList = new List<Product>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var product in contextDB.Products)
                {
                    productsList.Add(product);
                }
            }
            return productsList;
        }

        //====================================================================================================
        //Method used to retrieve from DB all Manufacturers ents
        //====================================================================================================
        public List<Manufacturer> GetAllManufacturersEnts()
        {
            List<Manufacturer> manufacturersList = new List<Manufacturer>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (var manufacturer in contextDB.Manufacturers)
                {
                    manufacturersList.Add(manufacturer);
                }
            }
            return manufacturersList;
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
        //Method used to retrieve from DB Product entity
        //====================================================================================================
        public Product GetProductEntityByProductNameAndManufacturer(string productName, int manufacturerId)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.ProductName == productName &&
                            p.ManufacturerId == manufacturerId
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
        //Method used to retrieve from DB Product entity by supplier code
        //====================================================================================================
        public Product GetProductEntityBySupplierCode(string supplierCode)
        {
            Product localProduct = new Product();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from p in contextDB.Products
                            where p.SupplierCode == supplierCode
                            select p;

                localProduct = query.SingleOrDefault();
            }
            return localProduct;
        }

        //====================================================================================================
        //Method used to get full product info (including Tax, Manufacturer and Product table data)
        //====================================================================================================
        public FullProductInfo GetFullProductInfoByName(string productName)
        {
            FullProductInfo localProduct = new FullProductInfo();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                //Create query to database
                var query = from p in contextDB.Products
                            join m in contextDB.Manufacturers on p.ManufacturerId equals m.Id
                            join t in contextDB.Tax on p.TaxId equals t.Id
                            join s in contextDB.Suppliers on p.SupplierId equals s.Id
                            where p.ProductName == productName
                            select new
                            {
                                p,
                                m,
                                t,
                                s
                            };

                if (query.FirstOrDefault() != null)
                {
                    localProduct.ProductEnt = query.FirstOrDefault().p;
                    localProduct.ManufacturerEnt = query.FirstOrDefault().m;
                    localProduct.TaxEnt = query.FirstOrDefault().t;
                    localProduct.SupplierEnt = query.FirstOrDefault().s;
                }
                else localProduct = null;


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
        //Method used to retrieve from DB Supplier entity
        //====================================================================================================
        public Supplier GetSupplierEntityByName(string supplierName)
        {
            Supplier localSupplier = new Supplier();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Suppliers
                            where m.Name == supplierName
                            select m;

                localSupplier = query.SingleOrDefault();
            }
            return localSupplier;
        }

        //====================================================================================================
        //Method used to retrieve from DB Manufacturer entity by ID
        //====================================================================================================
        public Manufacturer GetManufacturerEntityById(int manufacturerId)
        {
            Manufacturer localManufacturer = new Manufacturer();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from m in contextDB.Manufacturers
                            where m.Id == manufacturerId
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
        //Method used to add new product
        //====================================================================================================
        public void AddNewProduct(Product product)
        {
            //Local variables
            Product localProduct;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Products.Add(product);
                int test = contextDB.SaveChanges();

                localProduct = this.GetProductEntityByBarcode(product.BarCode);
            }

            if(localProduct == null) AddProductToChangelog(product, ProductOperationType.AddNew);
            else AddProductToChangelog(localProduct, ProductOperationType.AddNew);
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
        //Method used to edit product
        //====================================================================================================
        public void EditProduct(Product product)
        {
            //Local variables
            Product localProduct;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Products.Add(product);
                contextDB.Entry(product).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();

                localProduct = this.GetProductEntityByBarcode(product.BarCode);
            }

            if (localProduct == null) AddProductToChangelog(product, ProductOperationType.Update);
            else AddProductToChangelog(localProduct, ProductOperationType.Update);
        }

        //====================================================================================================
        //Method used to delete product
        //====================================================================================================
        public bool DeleteProduct(Product product)
        {
            //Local variables
            Product localProduct;

            bool retVal = false;
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                localProduct = this.GetProductEntityByBarcode(product.BarCode);

                Product productToDelete = new Product { Id = product.Id };
                contextDB.Entry(productToDelete).State = EntityState.Deleted;
                int retValInt = contextDB.SaveChanges();
                if (retValInt > 0) retVal = true;
            }

            if (localProduct == null) AddProductToChangelog(product, ProductOperationType.Delete);
            else AddProductToChangelog(localProduct, ProductOperationType.Delete);

            return retVal;
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


        // **********************************************************************************************************
        #region Stock table related
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
        //Method used to get stock entity history from with given manufacturer ID and date frame
        //====================================================================================================
        public List<StockHistory> GetStockHistoryEntsWithManufacturerIdAndDate(int manufacturerId, DateTime startDate, DateTime endDate)
        {

            List<StockHistory> localStock = new List<StockHistory>();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.StockHistory
                            join p in contextDB.Products on s.ProductId equals p.Id
                            join m in contextDB.Manufacturers on p.ManufacturerId equals m.Id
                            where m.Id == manufacturerId && s.DateAndTime >= startDate && s.DateAndTime <= endDate
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
        //Method used to check if specified product already exist in stock
        //====================================================================================================
        public bool CheckIfAnyStockEntryForGivenProduct(Product product)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            where s.ProductId == product.Id
                            select s;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }
            return result;
        }

        //====================================================================================================
        //Method used to add to stock
        //====================================================================================================
        public void AddToStock(Stock stockPiece, StockOperationType operationType = StockOperationType.AddNew, string salesUniqueIdForAutomaticUpdate = null)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Stock.Add(stockPiece);
                int retVal = contextDB.SaveChanges();
            }

            //Add item to stock history
            AddToStockHistory(stockPiece, operationType, salesUniqueIdForAutomaticUpdate);
        }

        //====================================================================================================
        //Method used to add to stock
        //====================================================================================================
        public void AddToStockHistory(Stock stockPiece, StockOperationType operationType, string salesUniqueIdForAutomaticUpdate = null)
        {
            //Local variable
            StockHistory stockHistory = new StockHistory();
            stockHistory.ProductId = stockPiece.ProductId;
            stockHistory.Quantity = stockPiece.ActualQuantity - stockPiece.LastQuantity;
            stockHistory.DateAndTime = DateTime.Now;
            stockHistory.OperationType = operationType.ToString();
            stockHistory.SalesIdForAutomaticUpdate = salesUniqueIdForAutomaticUpdate;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {

                contextDB.StockHistory.Add(stockHistory);
                int retVal = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to edit product product in stock
        //====================================================================================================
        public void EditInStock(Stock stockPiece, StockOperationType stockOperationType = StockOperationType.Update, 
            string salesUniqueIdForAutomaticUpdate = null)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {

                contextDB.Stock.Add(stockPiece);
                contextDB.Entry(stockPiece).State = EntityState.Modified;
                int retVal = contextDB.SaveChanges();
            }

            //Add item to stock history
            AddToStockHistory(stockPiece, stockOperationType, salesUniqueIdForAutomaticUpdate);
        }

        //====================================================================================================
        //Method used to delete product in stock
        //====================================================================================================
        public bool DeleteFromStock(Product product)
        {
            bool retVal = false;
            List<Stock> stockEntriesToDelete = new List<Stock>();
            List<Stock> stockEntriesDeleted = new List<Stock>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                //Get Entries for given product ID
                var query = from s in contextDB.Stock
                            where s.ProductId == product.Id
                            select s;
                foreach (Stock stock in query)
                {
                    stockEntriesToDelete.Add(stock);
                }
            }

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (Stock stockPiece in stockEntriesToDelete)
                {
                    Stock stockToDelete = new Stock { Id = stockPiece.Id };
                    contextDB.Entry(stockToDelete).State = EntityState.Deleted;
                    int retValInt = contextDB.SaveChanges();
                    if (retValInt > 0) retVal = true;
                    stockEntriesDeleted.Add(stockPiece);
                }
            }

            //Add item to stock history
            foreach (Stock stockPiece in stockEntriesDeleted)
            {
                AddToStockHistory(stockPiece, StockOperationType.Delete);
            }

            return retVal;

        }

        //====================================================================================================
        //Method used to check if quantity was already updated by specified sales unique id
        //====================================================================================================
        public bool CheckIfSalesUniqueIdExistInStockHistory(string salesUniqueId)
        {
            bool result = false;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from sh in contextDB.StockHistory
                            where sh.SalesIdForAutomaticUpdate == salesUniqueId
                            select sh;

                if (query.FirstOrDefault() != null) result = true;
                else result = false;

            }
            return result;
        }

        //====================================================================================================
        //Method used to update quantity in stock for given product ID
        //====================================================================================================
        public bool UpdateProductQuantityInStock(int quantityToUpdate, int productId, string salesUniqueIdForAutomaticUpdate = null,
            DateTime? expirationDate = null, StockOperationType stockOperationType = StockOperationType.Update)
        {
            bool result = false;
            if (expirationDate == null) expirationDate = DateTime.MinValue;
            Stock localStock;

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Stock
                            where s.ProductId == productId && s.ExpirationDate == expirationDate
                            select s;

                localStock = query.FirstOrDefault();
            }


            if (localStock != null)
            {
                localStock.LastQuantity = localStock.ActualQuantity;
                localStock.ActualQuantity += quantityToUpdate;
                localStock.ModificationDate = DateTime.Now;
                //Check if product exist in stock
                this.EditInStock(localStock, stockOperationType, salesUniqueIdForAutomaticUpdate);
                result = true;
            }
            else
            {
                localStock = new Stock();
                localStock.ProductId = productId;
                localStock.ActualQuantity = quantityToUpdate;
                localStock.LastQuantity = 0;
                localStock.ModificationDate = DateTime.Now;
                localStock.ExpirationDate = (DateTime) expirationDate;
                localStock.BarcodeWithDate = null;
                this.AddToStock(localStock, StockOperationType.AutomaticAddedNew, salesUniqueIdForAutomaticUpdate);
                result = true;
            }

            return result;
        }
        #endregion




        // **********************************************************************************************************
        #region Sale table related
        //====================================================================================================
        //Method used to add to sales table
        //====================================================================================================
        public void AddToSales(Sales salePiece)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.Sales.Add(salePiece);
                int retVal = contextDB.SaveChanges();
            }

        }

        //====================================================================================================
        //Method used to add to sales table from list
        //====================================================================================================
        public void AddToSales(List<Sales> salePieceList)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {

                contextDB.Sales.AddRange(salePieceList);
                int retVal = contextDB.SaveChanges();
            }

        }

        //====================================================================================================
        //Method used to check if unique identifier already exist in DB
        //====================================================================================================
        public bool CheckIfUniqueIdExist(string uniqueId)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Sales
                            where s.EntryUniqueIdentifier == uniqueId
                            select s;

                if (query.Count() == 1) return true;
                else return false;
            }

        }
        /// <summary>
        /// Method used to check if unique identifier already exist in DB. It will return elements fro given
        /// list which not exist in DB
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns>List of elements which not exist in DB</returns>
        public List<string> CheckIfUniqueIdExist(List<string> uniqueId)
        {
            List<string> listOfElementsNtExistingInDb = new List<string>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                foreach (string element in uniqueId)
                {
                    var query = from s in contextDB.Sales
                                where s.EntryUniqueIdentifier == element
                                select s.EntryUniqueIdentifier;

                    string dbRetVal = query.FirstOrDefault();
                    if (dbRetVal == null) listOfElementsNtExistingInDb.Add(element);
                }


                return listOfElementsNtExistingInDb;
            }

        }

        //====================================================================================================
        //Method used to retrieve from DB Sales entity by Id
        //====================================================================================================
        public Sales GetSalesEntityById(int salesId)
        {
            Sales localSale = new Sales();
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from s in contextDB.Sales
                            where s.Id == salesId
                            select s;

                localSale = query.SingleOrDefault();
            }
            return localSale;
        }
        #endregion



        // **********************************************************************************************************
        #region Product_Changelog table related
        //====================================================================================================
        //Method used to add new product
        //====================================================================================================
        public void AddProductToChangelog(Product product, ProductOperationType operationType)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                ProductChangelog productChangelog = FillProductChangelogFromProduct(product, operationType);
                contextDB.ProductsChangelog.Add(productChangelog);
                int test = contextDB.SaveChanges();
            }
        }

        //====================================================================================================
        //Method used to fill product with changelog
        //====================================================================================================
        public ProductChangelog FillProductChangelogFromProduct(Product product, ProductOperationType operationType)
        {
            ProductChangelog productChangelog = new ProductChangelog();

            productChangelog.ProductId = product.Id;
            productChangelog.SupplierId = product.SupplierId;
            productChangelog.ElzabProductId = product.ElzabProductId;
            productChangelog.ManufacturerId = product.ManufacturerId;
            productChangelog.ProductName = product.ProductName;
            productChangelog.ElzabProductName = product.ElzabProductName;
            productChangelog.PriceNet = product.PriceNet;
            productChangelog.Discount = product.Discount;
            productChangelog.PriceNetWithDiscount = product.PriceNetWithDiscount;
            productChangelog.TaxId = product.TaxId;
            productChangelog.Marigin = product.Marigin;
            productChangelog.FinalPrice = product.FinalPrice;
            productChangelog.BarCode = product.BarCode;
            productChangelog.BarCodeShort = product.BarCodeShort;
            productChangelog.SupplierCode = product.SupplierCode;
            productChangelog.ProductInfo = product.ProductInfo;
            productChangelog.DateAndTime = DateTime.Now;
            productChangelog.OperationType = operationType.ToString();

            return productChangelog;
        }

        /// <summary>
        /// Method used to get ents from product changelog table by ElzabProductId
        /// </summary>
        /// <param name="elzabProductId">Elzab product Id</param>
        /// <returns>List of the product changelog ordered descending by date (0 - newest, n - oldest)</returns>
        public ProductChangelog GetLastChangelogValueForGivenElzabProductIdLimitedByDate(int elzabProductId, DateTime olderDate,
            DateTime newerDate, bool ascendingOrder = true)
        {
            ProductChangelog localProductChangelog = new ProductChangelog();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                if (ascendingOrder)
                {
                    var query = from pc in contextDB.ProductsChangelog
                                where pc.ElzabProductId == elzabProductId
                                && pc.DateAndTime >= olderDate
                                && pc.DateAndTime <= newerDate
                                orderby pc.DateAndTime ascending
                                select pc;

                    localProductChangelog = query.FirstOrDefault();
                }
                else
                {
                    var query = from pc in contextDB.ProductsChangelog
                                where pc.ElzabProductId == elzabProductId
                                && pc.DateAndTime >= olderDate
                                && pc.DateAndTime <= newerDate
                                orderby pc.DateAndTime descending
                                select pc;

                    localProductChangelog = query.FirstOrDefault();
                }

            }
            return localProductChangelog;
        }

        /// <summary>
        /// Method used to check if product with given number was deleted
        /// </summary>
        /// <param name="dbProductId"></param>
        /// <returns></returns>
        public bool CheckIfProductWasDeleted(int dbProductId)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {

                var query = from pc in contextDB.ProductsChangelog
                            where pc.ProductId == dbProductId
                            && pc.OperationType == Database.ProductOperationType.Delete.ToString()
                            select pc;

                if (query.FirstOrDefault() != null) return true;
                else return false;
            }
        }

        //====================================================================================================
        //Method used to get ents from product changelog table by ProductId
        //====================================================================================================
        public List<ProductChangelog> GetProductChangelogByProductId(int productId)
        {
            List<ProductChangelog> localProductChangelog = new List<ProductChangelog>();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from pc in contextDB.ProductsChangelog
                            where pc.ProductId == productId
                            orderby pc.DateAndTime descending
                            select pc;

                localProductChangelog.AddRange(query);
            }
            return localProductChangelog;
        }

        public class ProductChangelogInfo
        {
            public bool ElzabNumberHasChanged { get; set; }
            public int NewElzabNumber { get; set; }
            public int ProductId { get; set; }
        }
        #endregion


        // **********************************************************************************************************
        #region Elzab_Communication table related
        /// <summary>
        /// Method used to add ElzabCommunication table element
        /// </summary>
        /// <param name="elzabCommunicationEntity">Elzab communication entity</param>
        public void AddToElzabCommunication(ElzabCommunication elzabCommunicationEntity)
        {
            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                contextDB.ElzabCommunication.Add(elzabCommunicationEntity);
                int test = contextDB.SaveChanges();
            }
        }

        /// <summary>
        /// Method used to get last Elzab success ended communication, for given command name (e.g. OTOWAR).
        /// It's internally sort list of all entrys and return newest
        /// </summary>
        /// <param name="commandName">Elzab command name (e.g. OTOWAR)</param>
        /// <returns>ElzabCommunication table entity</returns>
        public ElzabCommunication GetLastSuccessCommunicationForGivenCommandName(string commandName)
        {
            //Local variable
            ElzabCommunication localElzabCommunication = new ElzabCommunication();

            using (ShopContext contextDB = new ShopContext(GlobalVariables.ConnectionString))
            {
                var query = from ec in contextDB.ElzabCommunication
                            where ec.ElzabCommandName == commandName &&
                            ec.StatusOfCommunication == ElzabCommunication.CommunicationStatus.FinishSuccess
                            orderby ec.DateOfCommunication descending
                            select ec;

                localElzabCommunication = query.FirstOrDefault();
            }

            return localElzabCommunication;
        }
        #endregion
    }
}
