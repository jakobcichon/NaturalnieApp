using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Timers;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Printing;
using NaturalnieApp.Database;
using ElzabDriver;
using NaturalnieApp.Dymo_Printer;

namespace NaturalnieApp
{
    public enum backgroundWorkerTasks { None, Init, Update, CheckIfExist };

    /// <summary>
    /// Static class consist Barcode-related methods
    /// </summary>
    public class BarcodeRelated
    {
        //====================================================================================================
        //User-defined exception
        #region User-defined exception
        public class WrongBarcodeSeries : Exception
        {
            public WrongBarcodeSeries()
            {
            }

            public WrongBarcodeSeries(string message)
                : base(message)
            {
            }

            public WrongBarcodeSeries(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class ElementAlreadyExist : Exception
        {
            public ElementAlreadyExist()
            {
            }

            public ElementAlreadyExist(string message)
                : base(message)
            {
            }

            public ElementAlreadyExist(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
        #endregion

        /// <summary>
        /// Method used to create EAN8. First 2 digits are the manufacturer id from DB.
        /// Last 5 digits of EAN8 are product ID from cash register.
        /// For date included it will be cleriefied later.
        /// </summary>
        /// <param name="manufacturerId">Manufacturer ID sotred in DB</param>
        /// <param name="productId">PRoduct ID in cash register, taked from DB</param>
        /// <returns>Valid EAN8 code</returns>
        #region Barcode methods
        public static string GenerateEan8(int manufacturerId, int productId)
        {
            //Local variables
            string retVal = "";
            string stringValue = "";

            if (manufacturerId >= 1 && manufacturerId <= 99)
            {
                if (productId >= 1 && productId <= 99999)
                {
                    stringValue = string.Format("{0,2}", manufacturerId.ToString()) + string.Format("{0,5}", productId.ToString());
                    stringValue = stringValue.Replace(" ", "0");
                    if (stringValue.Length == 7)
                    {
                        //Calculate checksum digit and add it to new code
                        retVal = CalcucateChekcSumOfBarcode(stringValue);
                    }
                    else MessageBox.Show("Błąd! Wygenerowany kod EAN8 nie ma 7 znaków!");
                }
                else MessageBox.Show("Błąd! Identyfikator produkty jest spoza zakresu 1-99999!");
            }
            else MessageBox.Show("Błąd! Identyfikator producenta jest spoza zakresu 1-99!");

            return retVal;
        }

        /// <summary>
        /// Method used to calculate EAN-13 or EAN-8 checksum charakter
        /// It will take 12 digits input for EAN-13 and 7 digits for EAN-8
        /// </summary>
        /// <param name="codeToCalculateFrom"></param>
        /// <returns> It will return given inputCode + calculated checksum.
        /// If wrong iput code, than WrongBarcodeSeries exception will be thrown.
        /// </returns>
        public static string CalcucateChekcSumOfBarcode(string codeToCalculateFrom)
        {
            //Local variables
            string retVal = "";
            int numberOfDigits;
            string stringValue;
            int intValue = 0;

            //Check if given sring contains only digits
            Regex regEx = new Regex(@"^[0-9]*$");
            bool onlyDigits = regEx.IsMatch(codeToCalculateFrom);
            int checksumValue = 0;
            int checksumDigit = 0;
            bool multiple = true;

            //Check if length has 7 or 12 digits
            numberOfDigits = codeToCalculateFrom.Count();

            //Do calculation
            if (onlyDigits && (numberOfDigits == 7 || numberOfDigits == 12))
            {
                for (int i = numberOfDigits - 1; i >= 0; i--)
                {
                    if (multiple)
                    {

                        stringValue = codeToCalculateFrom[i].ToString();
                        intValue = Convert.ToInt32(stringValue);
                        checksumValue += (intValue * 3);
                        multiple = false;
                    }
                    else
                    {
                        stringValue = codeToCalculateFrom[i].ToString();
                        intValue = Convert.ToInt32(stringValue);
                        checksumValue += intValue;
                        multiple = true;
                    }

                }

                //Made modulo annd check what is the checksum number
                checksumDigit = 10 - (checksumValue % 10);
                if (checksumDigit == 10) checksumDigit = 0;

                retVal = (codeToCalculateFrom + checksumDigit.ToString());

            }
            else throw new WrongBarcodeSeries(string.Format("Nie można wyliczyć cyfry kontrolnej dla '{0}'. " +
                "Dopuszczalne są jednynie kody EAN8 oraz EAN13, dla których liczba cyfr bez cyfry kontrolenj to odpowiednio 7 i 12 znaków.",
                codeToCalculateFrom));

            return retVal;
        }

        #endregion
        /// <summary>
        /// Class used to handle information received from Bar code reader
        /// </summary>
        #region Barcode reader
        public class BarcodeReader
        {
            //Object fields
            System.Timers.Timer timer { get; set; }
            public string BarcodeToReturn { get; set; }
            string TemporaryBarcodeValue { get; set; }
            public bool Ready { get; set; }
            public bool Valid { get; set; }
            private List<string> debugList { get; set; }

            //Register an event
            public event BarcodeValidEventHandler BarcodeValid;

            public class BarcodeValidEventArgs : EventArgs
            {
                public bool Ready { get; set; }
                public bool Valid{ get; set; }
                public string RecognizedBarcodeValue { get; set; }
            }

            //Declare new event handler
            public delegate void BarcodeValidEventHandler(object sender, BarcodeValidEventArgs e);

            //Declaration of event handler
            protected virtual void OnBarcodeValid(BarcodeValidEventArgs e)
            {
                BarcodeValidEventHandler handler = BarcodeValid;
                handler?.Invoke(this, e);
            }

            /// <summary>
            /// CLass constructor
            /// </summary>
            /// <param name="barcodeReaderCharInterval"></param>
            public BarcodeReader(double barcodeReaderCharInterval)
            {
                //Initialize timer
                this.timer = new System.Timers.Timer(barcodeReaderCharInterval);
                this.timer.Elapsed += OnTimedEvent;
                this.timer.Enabled = true;

                this.TemporaryBarcodeValue = "";
                this.debugList = new List<string>();
                this.debugList.Add("");
                this.Ready = true;
            }
            
            /// <summary>
            /// Method used to recognize if valid Barcode value.
            /// It should be placed in object KEyDown event.
            /// </summary>
            /// <param name="key"></param>
            public void CheckIfBarcodeFromReader(Keys key)
            {

                //Make initialization after first call
                if (this.Ready == true)
                {
                    this.timer.Start();
                    this.Ready = false;
                    this.BarcodeToReturn = "";
                    this.Valid = false;
                }

                //Recognize only digits
                if (key == Keys.D0 || key == Keys.D1 || key == Keys.D2 || key == Keys.D3 || key == Keys.D4 ||
                    key == Keys.D5 || key == Keys.D6 || key == Keys.D7 || key == Keys.D8 || key == Keys.D9)
                {
                    //Reset timer
                    this.timer.Stop();
                    this.timer.Start();

                    switch (key)
                    {
                        case Keys.D0:
                            this.TemporaryBarcodeValue += "0";
                            break;
                        case Keys.D1:
                            this.TemporaryBarcodeValue += "1";
                            break;
                        case Keys.D2:
                            this.TemporaryBarcodeValue += "2";
                            break;
                        case Keys.D3:
                            this.TemporaryBarcodeValue += "3";
                            break;
                        case Keys.D4:
                            this.TemporaryBarcodeValue += "4";
                            break;
                        case Keys.D5:
                            this.TemporaryBarcodeValue += "5";
                            break;
                        case Keys.D6:
                            this.TemporaryBarcodeValue += "6";
                            break;
                        case Keys.D7:
                            this.TemporaryBarcodeValue += "7";
                            break;
                        case Keys.D8:
                            this.TemporaryBarcodeValue += "8";
                            break;
                        case Keys.D9:
                            this.TemporaryBarcodeValue += "9";
                            break;
                    }

                }
                else if (key == Keys.Enter)
                {
                    this.timer.Stop();
                    this.Ready = true;
                    this.BarcodeToReturn = this.TemporaryBarcodeValue;
                    this.TemporaryBarcodeValue = "";
                    if (this.BarcodeToReturn.Length == 8 || this.BarcodeToReturn.Length == 12 || this.BarcodeToReturn.Length == 13)
                    {
                        this.Valid = true;
                        CallBarcodeValidEvent(this.Ready, this.Valid, this.BarcodeToReturn);
                    }
                    else this.Valid = false;
                }

                this.debugList[debugList.Count - 1] += key;
            }

            private void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                this.timer.Stop();
                this.Ready = true;
                this.Valid = false;
                this.TemporaryBarcodeValue = "";
                if (this.debugList.Count >= 100) this.debugList.Clear();
            }

            private void CallBarcodeValidEvent(bool ready, bool valid, string barcode)
            {
                BarcodeValidEventArgs e = new BarcodeValidEventArgs
                {
                    Ready = ready,
                    Valid = valid,
                    RecognizedBarcodeValue = barcode
                };
                OnBarcodeValid(e);
            }
        }
        #endregion

        #region Get Printer status
        public static PrintJobStatus GetPrinterStatus(string printerName)
        {
            PrintJobStatus retValue = PrintJobStatus.None;

            try
            {
                var queue = new LocalPrintServer().GetPrintQueue(printerName);
                var queueStatus = queue.QueueStatus;
                var jobStatus = queue.GetPrintJobInfoCollection().FirstOrDefault().JobStatus;
                retValue = jobStatus;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retValue;

        }
        #endregion
    }
    /// <summary>
    /// Static class consist Data source related objects
    /// </summary>
    public static class DataSourceRelated
    {
        /// <summary>
        /// Structure used to describe column names for prices (price net, tax, etc.) update
        /// </summary>
        public struct PricesUpdateDataSourceColumnNames
        {
            public string No { get; set; }

            public string ManufacturerName { get; set; }
            public string ProductName { get; set; }
            public string ProductBarcode { get; set; }
            public string PriceNet { get; set; }
            public string Tax { get; set; }
            public string Discount { get; set; }

        }

        /// <summary>
        /// Structure used to describe column names for label data source
        /// </summary>
        public struct LabelDataSourceColumnNames
        {
            public string No { get; set; }
            public string LabelText { get; set; }
            public string LabelBarcode { get; set; }
            public string LabelFinalPrice { get; set; }
            public string NumberOfCopies { get; set; }
            public string ProductId { get; set; }
            public string ModificationDate { get; set; }

        }

        /// <summary>
        /// Structure used to describe column names for adding to stock data source
        /// </summary>
        public struct AddToStockDataSourceColumnNames
        {
            public string No { get; set; }
            public string ProductName { get; set; }
            public string ElzabNumber { get; set; }
            public string PriceNet { get; set; }
            public string FinalPrice { get; set; }
            public string Tax { get; set; }
            public string AddDate { get; set; }
            public string ExpirenceDate { get; set; }
            public string NumberOfPieces { get; set; }

        }

        /// <summary>
        /// Structure used to describe column names for cash register product fields
        /// </summary>
        public struct CashRegisterProductColumnNames
        {
            public string ProductNumber { get; set; }
            public string ProductName { get; set; }
            public string Tax { get; set; }
            public string FinalPrice{ get; set; }
            public string Barcode { get; set; }
            public string AdditionaBarcode { get; set; }
        }

        /// <summary>
        /// Structure used to describe column names for inventory data export
        /// </summary>
        public struct InventoryExportColumnNames
        {
            public string No { get; set; }
            public string ManufacturerName { get; set; }
            public string ProductName { get; set; }
            public string ProductBarcode { get; set; }
            public string PriceNet { get; set; }
            public string Tax { get; set; }
            public string Discount { get; set; }
            public string PriceNetWithDiscount { get; set; }
            public string FinalPrice { get; set; }
            public string ProductQunatity { get; set; }
            public string ProductValueNet { get; set; }
        }
    }

    static public class ElzabRelated
    {
        /// <summary>
        /// Method used convert numeric tax value cash register group
        /// </summary>
        /// <param name="taxValue"></param>
        /// <returns>Can retrun 1-7</returns>
        static public string TranslateTaxValueToCashRegisterGroup(int taxValue)
        {
            if (taxValue == 0) return "4";
            else if (taxValue == 5) return "3";
            else if (taxValue == 8) return "2";
            else if (taxValue == 23) return "1";
            else return "";
        }

        /// <summary>
        /// Method used convert cash register tax group to tax value
        /// </summary>
        /// <param name="taxGroup"></param>
        /// <returns>Can retrun 0,5,8,23</returns>
        static public string TranslateCashRegisterGroupToTaxValue(int taxGroup)
        {
            if (taxGroup == 4) return "0";
            else if (taxGroup == 3) return "5";
            else if (taxGroup == 2) return "8";
            else if (taxGroup == 1) return "23";
            else return "";
        }

        //Method used to parse from elzab data to database product object
        static public List<Product> ParseElzabProductDataToDbObject(DatabaseCommands db, ElzabFileObject dataFromElzab)
        {
            int elementType = 0;

            //Return list
            List<Product> retList = new List<Product>();
            foreach (AttributeValueObject element in dataFromElzab.Element.ElementsList[elementType])
            {
                try
                {
                    //Local product
                    Product product = new Product();
                    product.ElzabProductName = dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "naz_tow");
                    product.ElzabProductId = Int32.Parse(dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "nr_tow"));
                    string price = dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "cena");
                    product.FinalPrice = ElzabRelated.ConvertFromElzabPriceToFloat(price);
                    product.BarCode = dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "bkod");
                    string taxValue = ElzabRelated.TranslateCashRegisterGroupToTaxValue(
                        Int32.Parse(dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "ST")));
                    product.TaxId = db.GetTaxIdByValue(Int32.Parse(taxValue));

                    //AddProduct to the list
                    retList.Add(product);
                }
                catch(Exception ex)
                {
                    Product test = retList.Last();
                    MessageBox.Show(ex.Message);
                }

            }

            return retList;
        }

        //Method used to parse from elzab additiona barcodes to database product object
        static public List<Product> ParseElzabAddBarcodesToDbObject(DatabaseCommands db, ElzabFileObject dataFromElzab)
        {
            int elementType = 0;

            //Return list
            List<Product> retList = new List<Product>();
            foreach (AttributeValueObject element in dataFromElzab.Element.ElementsList[elementType])
            {
                try
                {
                    //Local product
                    Product product = new Product();
                    product.ElzabProductId = Int32.Parse(dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "nr_tow"));
                    product.BarCodeShort = dataFromElzab.Element.GetAttributeValue(dataFromElzab.Element.ElementsList[elementType].IndexOf(element), "bkodd");
                    
                    //AddProduct to the list
                    retList.Add(product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            return retList;
        }


        //Method used to parse from Elzab buffer to Db object
        static public List<Sales> ParseElzabBufferToDbObject(List<AttributeValueObject> elementsList)
        {
            //Local variables 
            List<Sales> listOfElementsToAdd = new List<Sales>();

            if (elementsList.Count > 0)
            {
                foreach (AttributeValueObject element in elementsList)
                {
                    if (element.AttributeValue.Count > 0)
                    {
                        int attribute = 0;
                        Sales salePeiece = new Sales();
                        foreach (System.Reflection.PropertyInfo prop in typeof(Sales).GetProperties())
                        {
                            if (prop.Name == "Id") continue;
                            else if (prop.Name == "ElementType")
                            {
                                int value = Int32.Parse(element.AttributeValue[0]);
                                prop.SetValue(salePeiece, value);
                                continue;
                            }
                            else if (prop.Name == "TimeOfAdded")
                            {
                                DateTime value = DateTime.Now;
                                prop.SetValue(salePeiece, value);
                                continue;
                            }
                            else if (prop.Name == "EntryUniqueIdentifier")
                            {
                                prop.SetValue(salePeiece, element.UniqueIdentifier);
                                continue;
                            }
                            else
                            {
                                prop.SetValue(salePeiece, element.AttributeValue[attribute]);
                            }

                            attribute++;
                            if (attribute >= element.AttributeValue.Count()) break;
                        }

                        //Add to the list
                        listOfElementsToAdd.Add(salePeiece);
                    }

                }
            }

            return listOfElementsToAdd;
        }

        //Method used to parse from database product object to elzab data
        static public ElzabFileObject ParseDbObjectToElzabProductData(DatabaseCommands db, List<Product> dataToElzab, ElzabFileObject elzabTemplate)
        {
            //Return list
            ElzabFileObject retData = elzabTemplate;
            retData.Element.RemoveAllElements();

            foreach (Product product in dataToElzab)
            {
                try
                {
                    List<string> attributesValues = new List<string>();
                    //nr_tow
                    attributesValues.Add(product.ElzabProductId.ToString());
                    //naz_tow
                    attributesValues.Add(product.ElzabProductName);
                    //ST
                    int taxValue = db.GetTaxByProductName(product.ProductName).TaxValue;
                    attributesValues.Add(ElzabRelated.TranslateTaxValueToCashRegisterGroup(taxValue));
                    //GR
                    attributesValues.Add("1");
                    //MP
                    attributesValues.Add("2");
                    //JM
                    attributesValues.Add("1");
                    //BL
                    attributesValues.Add("0");
                    //bkod
                    attributesValues.Add(product.BarCode);
                    //cena
                    string formatedString = String.Format("{0:0.00}", product.FinalPrice);
                    formatedString = formatedString.Replace(".", "");
                    attributesValues.Add(formatedString);
                    //OP
                    attributesValues.Add("0");

                    //Add data to elzab object
                    retData.AddElement(product.ElzabProductId.ToString());
                    retData.ChangeAllElementValues(product.ElzabProductId.ToString(), attributesValues.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            return retData;
        }

        //Method used to parse from database product object to elzab additional barcodes data
        static public ElzabFileObject ParseDbObjectToElzabAddBarcodes(DatabaseCommands db, List<Product> dataToElzab, ElzabFileObject elzabTemplate)
        {
            //Return list
            ElzabFileObject retData = elzabTemplate;
            retData.Element.RemoveAllElements();

            foreach (Product product in dataToElzab)
            {
                try
                {
                    List<string> attributesValues = new List<string>();
                    if (product.BarCode != product.BarCodeShort)
                    {
                        attributesValues.Add(product.ElzabProductId.ToString());
                        attributesValues.Add(product.BarCodeShort);
                        retData.AddElement(product.ElzabProductId.ToString());
                        retData.ChangeAllElementValues(product.ElzabProductId.ToString(), attributesValues.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            return retData;
        }


        //Method used to compare product data from DB with data from elzab
        static public List<Product> ComapreDbProductDataWithElzab(List<Product> dataFromElzab, List<Product> dataFromDb)
        {
            //Return list of differences
            List<Product> retList = new List<Product>();

            foreach (Product element in dataFromDb)
            {
                //Find product with given id in cash register
                Product product = dataFromElzab.Find(p => p.ElzabProductId == element.ElzabProductId);
                if( product == null)
                {
                    retList.Add(element);
                }
                else
                {
                    //If barcode is short, Elzab will return leadings zeros. That it was conversion must be done
                    string elzabBarcodeString, dbBarcodeString;

                    if ((element.BarCode != product.BarCode))
                    {
                        Int64 dbBarcode, elzabBarcode;
                        dbBarcode = Int64.Parse(element.BarCode);
                        elzabBarcode = Int64.Parse(product.BarCode);
                        elzabBarcodeString = elzabBarcode.ToString();
                        dbBarcodeString = dbBarcode.ToString();
                    }
                    else
                    {
                        elzabBarcodeString = product.BarCode;
                        dbBarcodeString = element.BarCode;
                    }
                    //Convert without polish sings
                    string localProductNameFromDb = EncodingConversionRelated.StringConverterCodepage(CleanInput(element.ElzabProductName)).ToUpper().Replace("-", "");
                    string localProductNameFromElzab = EncodingConversionRelated.StringConverterCodepage(CleanInput(product.ElzabProductName));
                    if ((elzabBarcodeString != dbBarcodeString) || (localProductNameFromDb != localProductNameFromElzab) ||
                        (element.TaxId != product.TaxId) || (element.FinalPrice != product.FinalPrice))
                    {

                        retList.Add(element);

                    }
                }
            }

            return retList;
        }
        //Method used to convert from elzab price reprezentation to floating one
        public static float ConvertFromElzabPriceToFloat(string elzabPrice)
        {
            float retVal;
            string localPrice;
            if (elzabPrice.Length == 1)
            {
                localPrice = "00" + elzabPrice;
                ;
            }
            else if (elzabPrice.Length == 2)
            {
                localPrice = "0" + elzabPrice;
                ;
            }
            else localPrice = elzabPrice;

            string formatedString = localPrice.Insert(localPrice.Length - 2, ".");
            retVal = float.Parse(formatedString);

            return retVal;

        }
        //Method used to convert from float to elzab price representation
        public static string ConvertFromFloatToElzabPrice(float price)
        {
            string formatedString = String.Format("{0:0.00}", price);
            formatedString = formatedString.Replace(".", "");
            return formatedString;
        }

        //Method used to clean string from any of special character
        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        //Method used to convert from com port number (ex. 1) to name (ex.COM1)
        static public string ComPortNameFromNumber(int comPortNumber)
        {
            string comPortName = "COM" + comPortNumber.ToString();
            return comPortName;
        }

        //Method used to convert from name (ex.COM1) to com port number (ex. 1) 
        static public int ComPortNumberFromName(string comPortName)
        {
            //Local variables
            Regex reg = new Regex(@"^\d+$");
            int retVal = -1;
            string tempString = "";
            string searchingValue = "COM";

            try
            {
                //Check if only digits
                bool matchOnlyDigits = reg.IsMatch(comPortName);
                if (matchOnlyDigits) retVal = Int32.Parse(comPortName);
                else
                {
                    //Check if "COM" word exist in given string
                    Match comNameExist = Regex.Match(comPortName, searchingValue);
                    
                    if (comNameExist.Success)
                    {
                        //Get index of searching word
                        for (int i = comNameExist.Index + searchingValue.Length; i < comPortName.Length; i++)
                        {
                            //Check every digit starting from COM word and add int to temporary string
                            if (Regex.IsMatch(comPortName[i].ToString(), @"^\d$")) tempString += comPortName[i].ToString();
                            else break;
                        }
                    }
                    if (tempString.Length > 0) retVal = Int32.Parse(tempString);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return retVal;
        }
    }

    public class WinFormRelated
    {
        static public void FilterProductByManufacturer(string manufacturerName, ref ComboBox ProductComboBox)
        {
            //Get from DB product list for given manufacturer
        }
    }

    static public class EncodingConversionRelated
    {
        public static string StringConverterCodepage(string sText, string sCodepageIn = "ISO-8859-8", string sCodepageOut = "UTF-8")
        {
            string sResultado = string.Empty;
            try
            {
                byte[] tempBytes;
                tempBytes = Encoding.GetEncoding(sCodepageIn).GetBytes(sText);
                sResultado = Encoding.GetEncoding(sCodepageOut).GetString(tempBytes);
            }
            catch (Exception)
            {
                sResultado = "";
            }
            return sResultado;
        }
        public static string ConvertFromUTF32ToAnsi(string sText)
        {
            string sResult = string.Empty;
            try
            {
                byte[] tempBytes;
                tempBytes = Encoding.UTF32.GetBytes(sText);
                tempBytes = Encoding.Convert(Encoding.UTF32, Encoding.Default, tempBytes);
                sResult = Encoding.Default.GetString(tempBytes);
            }
            catch (Exception)
            {
                sResult= "";
            }
            return sResult;
        }
    }

    static public class PrinterRelated
    {
        static public void PrintFromRowsByProductName(Printer printerInstance, DataRow[] rowsToPrint, int productNameColumnNumber,
        int numberOfCopiesColumnName, DatabaseCommands databaseCommands)
        {
            if (rowsToPrint.Length == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {
                //Get printer device
                try
                {
                    //Check if Dymo printer instance already created
                    if (printerInstance == null)
                    {
                        //Printer instance
                        printerInstance = new Printer(Program.GlobalVariables.LabelPath);
                    }

                    //Check if printer connected
                    printerInstance.ChangePrinter(Program.GlobalVariables.DymoPrinterName);

                    //Local variables
                    List<Product> localList = new List<Product>();

                    localList = GetListOfTheProductToPrintFromDataRowsByProductName(rowsToPrint, productNameColumnNumber, numberOfCopiesColumnName, databaseCommands);

                    List<Product> printingList = new List<Product>();

                    DialogResult decision = DialogResult.Yes;
                    if (localList.Count() > 100)
                    {
                        decision = MessageBox.Show(string.Format("Uwaga! Wybrano {0} etykiet do druku. Czy na pewno chcesz kontynułować?",
                            localList.Count())
                            , "Duża liczba etykiet do druku.", MessageBoxButtons.YesNo);
                    }

                    if (decision == DialogResult.Yes)
                    {
                        int i = 0;

                        //Split it into 5
                        foreach (Product element in localList)
                        {

                            printingList.Add(element);

                            if ((printingList.Count == 2) || (i == localList.Count - 1))
                            {
                                //Print lables
                                printerInstance.PrintPriceCardsFromProductList(printingList);
                                printingList.Clear();
                            }

                            i++;

                        }
                    }
                    else MessageBox.Show("Anulowano!");

                }
                catch (NoPrinterToSelect)
                {
                    MessageBox.Show("Nie można odnaleźć drukarki firmy Dymo. Podłącz drukarkę i spróbuj ponownie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            printerInstance = null;
        }

        static public void PrintFromRowsByProductId(Printer printerInstance, DataRow[] rowsToPrint, int productIdColumnNumber,
        int numberOfCopiesColumnName, DatabaseCommands databaseCommands)
        {

            if (rowsToPrint.Length == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {
                //Get printer device
                try
                {
                    //Check if Dymo printer instance already created
                    if (printerInstance == null)
                    {
                        //Printer instance
                        printerInstance = new Printer(Program.GlobalVariables.LabelPath);
                    }

                    //Check if printer connected
                    printerInstance.ChangePrinter(Program.GlobalVariables.DymoPrinterName);

                    //Local variables
                    List<Product> localList = new List<Product>();

                    localList = GetListOfTheProductToPrintFromDataRows(rowsToPrint, productIdColumnNumber, numberOfCopiesColumnName, databaseCommands);

                    List<Product> printingList = new List<Product>();

                    DialogResult decision = DialogResult.Yes;
                    if (localList.Count() > 100)
                    {
                        decision = MessageBox.Show(string.Format("Uwaga! Wybrano {0} etykiet do druku. Czy na pewno chcesz kontynułować?",
                            localList.Count())
                            , "Duża liczba etykiet do druku.", MessageBoxButtons.YesNo);
                    }

                    if (decision == DialogResult.Yes)
                    {
                        int i = 0;

                        //Split it into 5
                        foreach (Product element in localList)
                        {

                            printingList.Add(element);

                            if ((printingList.Count == 2) || (i == localList.Count - 1))
                            {
                                //Print lables
                                printerInstance.PrintPriceCardsFromProductList(printingList);
                                printingList.Clear();
                            }

                            i++;

                        }
                    }
                    else MessageBox.Show("Anulowano!");

                }
                catch (NoPrinterToSelect)
                {
                    MessageBox.Show("Nie można odnaleźć drukarki firmy Dymo. Podłącz drukarkę i spróbuj ponownie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            printerInstance = null;
        }

        private static List<Product> GetListOfTheProductToPrintFromDataRowsByProductName(DataRow[] data, int productNameColumnNumber,
            int numberOfCopiesColumnName, DatabaseCommands databaseCommands)
        {
            //Local variables
            List<Product> localList = new List<Product>();

            foreach (DataRow element in data)
            {
                //Get product entity
                Product productEnt = databaseCommands.GetProductEntityByProductName(element.Field<string>(productNameColumnNumber));
                int numberOfCopies = element.Field<int>(numberOfCopiesColumnName);
                for (int i = 1; i <= numberOfCopies; i++)
                {
                    localList.Add(productEnt);
                }

            }

            return localList;

        }

        private static List<Product> GetListOfTheProductToPrintFromDataRows(DataRow[] data, int productIdColumnNumber,
            int numberOfCopiesColumnName, DatabaseCommands databaseCommands)
        {
            //Local variables
            List<Product> localList = new List<Product>();

            foreach (DataRow element in data)
            {
                //Get product entity
                Product productEnt = databaseCommands.GetProductEntityById(element.Field<int>(productIdColumnNumber));
                int numberOfCopies = element.Field<int>(numberOfCopiesColumnName);
                for (int i = 1; i <= numberOfCopies; i++)
                {
                    localList.Add(productEnt);
                }

            }

            return localList;

        }
    }

}
