using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaturalnieApp
{
    /// <summary>
    /// Static class consist Barcode-related methods
    /// </summary>
    public static class BarcodeRelated
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
        #endregion
    }
}
