using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaturalnieApp.Forms
{
    static class Validation
    {

        //====================================================================================================
        //User-defined exception
        #region User-defined exception
        public class ValidatingFailed : Exception
        {
            public ValidatingFailed()
            {
            }

            public ValidatingFailed(string message)
                : base(message)
            {
            }

            public ValidatingFailed(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
        #endregion

        //Method used to validate of product name
        static public bool ProductNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-Z0-9]+\s)*[a-zA-Z0-9]+${1,255}";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of supplier name
        static public bool SupplierNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-Z0-9]+\s)*[a-zA-Z0-9]+${1,255}";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of manufacturer name
        static public bool ManufacturerNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa producenta musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-Z0-9]+\s)*[a-zA-Z0-9]+${1,255}";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of product name in elzab
        static public bool ElzabProductNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy dla kasy Elzab musi mieć maksymalnie 34 znaki oraz może zawierać jedynie cyfry, litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-Z0-9]+\s)*[a-zA-Z0-9]+${1,34}";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of marigin value
        static public bool MariginValueValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Marża jest wartością rzeczywistą, w której miejsce dziesiętne oddzielone jest znakiem '.' (kropka).";


            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of price net value
        static public bool PriceNetValueValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Cena netto może zawierać jedynie cyfry. Miejsce dziesiętne odzielone jest znakiem '.' (kropka).";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]+(\.[0-9]+)?$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of Tax
        static public bool TaxValueValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Vat może zawierać tylko nasepujace wartosci: 0, 5, 8, 23 %.";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^((0)?|(5)?|(8)?|(23))?$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }
        //Method used to validate input 
        static private bool ValidateInput(string textToValidate, string regExPatter)
        {
            //Local variables
            bool ret;
            Regex reg = new Regex(regExPatter);

            //Check if text to validate match given pattern
            ret = reg.IsMatch(textToValidate);

            return ret;
        }
    }
}
