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
                    if (this.BarcodeToReturn.Length == 8 || this.BarcodeToReturn.Length == 13)
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

        }

        /// <summary>
        /// Structure used to describe column names for adding to stock data source
        /// </summary>
        public struct AddToStockDataSourceColumnNames
        {
            public string No { get; set; }
            public string ProductName { get; set; }
            public string ElzabNumber { get; set; }
            public string AddDate { get; set; }
            public string ExpirenceDate { get; set; }
            public string NumberOfPieces { get; set; }

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
            public string FinalPrice { get; set; }
            public string ProductQunatity { get; set; }
            public string ProductValue { get; set; }
        }
    }


}
