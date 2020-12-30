using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Timers;
using System.Windows.Forms;

namespace NaturalnieApp
{
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
        #endregion

        /// <summary>
        /// Method used to create EAN8 code from EAN13.
        /// </summary>
        /// <param name="inputBarcode"></param>
        /// <returns>Valid EAN8 code</returns>
        #region Barcode methods
        public static string GenerateEan8FromEan13(string inputBarcode)
        {
            //Local variables
            string retVal = "";
            string stringValue;
            int numberOfDigits;

            //Check if given sring contains only digits
            Regex regEx = new Regex(@"^[0-9]*$");
            bool onlyDigits = regEx.IsMatch(inputBarcode);

            //Check if length has 13 digits
            numberOfDigits = inputBarcode.Count();

            //Substring 7 last digits from original barcode series
            if (onlyDigits && (numberOfDigits == 13))
            {
                //Substring 7 digits from orginal barcode sries
                stringValue = inputBarcode.Substring(5, 7);

                //Calculate checksum digit and add it to new code
                retVal = CalcucateChekcSumOfBarcode(stringValue);
            }
            else throw new WrongBarcodeSeries(string.Format("Nie można wygenerować EAN8 dla '{0}'. " +
                "Dopuszczalny jest jedynie kod EAN13, który zawiera 13 znaków",
                inputBarcode));

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
                checksumValue %= 10;
                checksumValue = 10 - checksumValue;

                retVal = (codeToCalculateFrom + checksumValue.ToString());

            }
            else throw new WrongBarcodeSeries(string.Format("Nie można wyliczyć cyfry kontrolnej dla '{0}'. " +
                "Dopuszczalne są jednynie kody EAN8 oraz EAN13, dla których liczba cyfr bez cyfry kontrolenj to odpowiednio 7 i 12 znaków.",
                codeToCalculateFrom));

            return retVal;
        }

        public class BarcodeReader
        {
            //Object fields
            System.Timers.Timer timer { get; set; }
            public string BarcodeToReturn { get; set; }
            string TemporaryBarcodeValue { get; set; }
            public bool Ready { get; set; }
            public bool Valid { get; set; }


            //Register an event
            public event BarcodeValidEventHandler BarcodeValid;

            public class BarcodeValidEventArgs : EventArgs
            {
                public bool Ready { get; set; }
                public bool Valid{ get; set; }
                public string RecognizedBarcodeValue { get; set; }
                public bool OutEventHandled { get; set; }
            }

            public delegate bool BarcodeValidEventHandler(object sender, BarcodeValidEventArgs e);

            //Declaration of event handler
            protected virtual bool OnBarcodeValid(BarcodeValidEventArgs e)
            {
                BarcodeValidEventHandler handler = BarcodeValid;
                handler?.Invoke(this, e);
                return e.OutEventHandled = false;
            }


            public BarcodeReader(double barcodeReaderCharInterval)
            {
                //Initialize timer
                this.timer = new System.Timers.Timer(barcodeReaderCharInterval);
                this.timer.Elapsed += OnTimedEvent;
                this.timer.Enabled = true;

                this.TemporaryBarcodeValue = "";
                this.Ready = true;
            }
                   
            public bool CheckIfBarcodeFromReader(Keys key)
            {
                //Local variables
                bool retVal = false;

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
                    if (this.BarcodeToReturn.Length == 8 || this.BarcodeToReturn.Length == 13) this.Valid = true;
                    else this.Valid = false;
                    retVal = CallBarcodeValidEvent(this.Ready, this.Valid, this.BarcodeToReturn);
                }

                return retVal;
            }

            private void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                this.timer.Stop();
                this.Ready = true;
                this.Valid = false;
            }

            private bool CallBarcodeValidEvent(bool ready, bool valid, string barcode)
            {
                BarcodeValidEventArgs e = new BarcodeValidEventArgs
                {
                    Ready = ready,
                    Valid = valid,
                    RecognizedBarcodeValue = barcode
                };
                return OnBarcodeValid(e);
            }
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

        }

        /// <summary>
        /// Structure used to describe column names for adding to stock data source
        /// </summary>
        public struct AddToStockDataSourceColumnNames
        {
            public string No { get; set; }
            public string ProductName { get; set; }
            public string AddDate { get; set; }
            public string ExpirenceDate { get; set; }
            public string NumberOfPieces { get; set; }

        }

    }
}
