using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturalnieApp
{
    static class Calculations
    {

        //Method used to round final price
        static public double RoundPrice(double price)
        {
            //Local variables
            double finalPrice;

            finalPrice = Math.Round(price, 1);

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
