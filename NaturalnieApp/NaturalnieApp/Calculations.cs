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
            finalPrice = Math.Round(price, 2);

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

            finalPrice = FinalPrice(product.PriceNetWithDiscount, tax, product.Marigin);

            return float.Parse(finalPrice.ToString());
        }

        //Calculate PRiceNetWithDiscount from product entity
        static public float CalculatePriceNetWithDiscountFromProduct(Product product)
        {
            double priceNetWithDiscount;

            if (product.Discount == 0) return product.PriceNet;
            else
            {
                priceNetWithDiscount = CalculatePriceNetWithDiscount(product.PriceNet, product.Discount);
            }

            return float.Parse(priceNetWithDiscount.ToString());
        }

        //Calculate PriceNetWithDiscount from product entity
        static public float CalculatePriceNetWithDiscount(float priceNet, int discount)
        {
            double priceNetWithDiscount;

            if (discount == 0) return priceNet;
            else
            {
                priceNetWithDiscount = priceNet - (priceNet * discount / 100);
                priceNetWithDiscount = Math.Round(priceNetWithDiscount, 2);
            }

            return float.Parse(priceNetWithDiscount.ToString());
        }

        //Calculate PriceNetWithDiscount from product entity
        static public float CalculatePriceNetFromPriceNetWithDiscount(float priceNetWithDiscount, int discount)
        {
            double priceNet;

            if (discount == 0) return priceNetWithDiscount;
            else
            {
                float discountFloat = (Single.Parse(discount.ToString()) / 100);
                priceNet = priceNetWithDiscount / (1- discountFloat);
                priceNet = Math.Round(priceNet, 2);
            }

            return float.Parse(priceNet.ToString());
        }

        //Calculate PriceWithTax from price net and tax
        static public float CalculatePriceWithTaxFromPriceNetAndTax(float priceNet, int tax)
        {
            double priceWithTax;

            if (tax == 0) return priceNet;
            else
            {
                float taxFloat = (Single.Parse(tax.ToString()) / 100);
                priceWithTax = priceNet * (1 + taxFloat);
                priceWithTax = Math.Round(priceWithTax, 2);
            }

            return float.Parse(priceWithTax.ToString());
        }

        //Calculate Price net from price with tax and tax
        static public float CalculatePriceNetFromPriceWithTaxAndTax(float priceWithTax, int tax)
        {
            double priceNet;

            if (tax == 0) return priceWithTax;
            else
            {
                float taxFloat = (Single.Parse(tax.ToString()) / 100);
                priceNet = priceWithTax / (1 + taxFloat);
                priceNet = Math.Round(priceNet, 2);
            }

            return float.Parse(priceNet.ToString());
        }

        //Calculate Price net from price with tax and tax and discount
        static public float CalculatePriceNetWithDiscountFromPriceWithTaxAndTax(float priceWithTax, int tax, int discount)
        {
            double priceNet;

            if (tax == 0) return priceWithTax;
            else
            {
                float taxFloat = (Single.Parse(tax.ToString()) / 100);
                priceNet = priceWithTax / (1 + taxFloat);
                priceNet = Math.Round(priceNet, 2);
                priceNet = CalculatePriceNetWithDiscount(Single.Parse(priceNet.ToString()), discount);
            }

            return float.Parse(priceNet.ToString());
        }

        //Calculate final price from price net, tax and marigin
        static public double FinalPrice(double priceNet, int tax, double marigin)
        {
            //Local variable
            double finalPrice;
            double markup;

            markup = 1 / (100 - marigin) * 100;

            //Calculate final price
            finalPrice = priceNet * ((tax / 100.0) + 1.0) * (markup);

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
