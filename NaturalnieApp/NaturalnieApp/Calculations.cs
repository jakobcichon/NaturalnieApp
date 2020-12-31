using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Database;

namespace NaturalnieApp
{
    static class Calculations
    {

        //Method used to round final price
        static public double RoundPrice(double price)
        {
            //Local variables
            double finalPrice;

            //Round price to 1 digit place
            finalPrice = Math.Round(price, 1);

            //Extract only integer part
            int integerPart = Convert.ToInt32(Math.Floor(finalPrice));

            //Extract decimal places to integer value
            int decimalToInteger = Convert.ToInt32((finalPrice - Convert.ToDouble(integerPart)) * 10);

            //Set decimal part for hardcoded values
            if (decimalToInteger > 0 && decimalToInteger <= 5) decimalToInteger = 5;
            else if (decimalToInteger > 5 && decimalToInteger <= 9) decimalToInteger = 9;
            else if (decimalToInteger > 9 && decimalToInteger <= 10) decimalToInteger = 10;

            //Set final price
            double ItegerToDecimal = Convert.ToDouble(decimalToInteger) / 10;
            finalPrice = Convert.ToDouble(integerPart) + ItegerToDecimal;

            return finalPrice;
        }

        static public float CalculateFinalPriceFromProduct(Product product, int tax)
        {
            //Local variable
            double finalPrice;

            finalPrice = FinalPrice(product.PriceNet, tax, product.Marigin);

            return float.Parse(finalPrice.ToString());
        }

        //Calculate final price from price net, tax and marigin
        static public double FinalPrice(double priceNet, int tax, double marigin)
        {
            //Local variable
            double finalPrice;

            //Calculate final price
            finalPrice = priceNet * ((tax / 100.0) + 1.0) * ((marigin / 100.0) + 1.0);

            //Round final price
            finalPrice = RoundPrice(finalPrice);

            return finalPrice;
        }

        //Calculate final price from price and marigin
        static public double FinalPrice(double price, int marigin)
        {
            //Local variable
            double finalPrice;

            //Calculate final price
            finalPrice = price  * marigin / 100;

            //Round final price
            finalPrice = RoundPrice(finalPrice);

            return finalPrice;
        }

        //Method used to convert percentage in floating form to decimal one
        static public int PercentageConversion(double value)
        {
            //Local variable
            int retValue = -1;

            if (value < 1)
            {
                retValue = Convert.ToInt32(value * 100.0);
            }
            return retValue;
        }

    }
}
