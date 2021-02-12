using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NaturalnieApp.PdfToExcel;

namespace NaturalnieApp.Forms
{
    static public class Validation
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

        //Method used to choose validation event depending on data column name
        static public void GetValidationMethod(string columnName, string value, IExcel template)
        {
            //Try to match colum name with dictionary
            ColumnsAttributes attribute = template.DataTableSchema_WinForm.FirstOrDefault(e => e.Value == columnName).Key;
            
            switch (attribute)
            {
                case ColumnsAttributes.GeneralNumber:
                    GeneralNumberValidation(value);
                    break;
                case ColumnsAttributes.SupplierName:
                    SupplierNameValidation(value);
                    break;
                case ColumnsAttributes.ManufacturerName:
                    ManufacturerNameValidation(value);
                    break;
                case ColumnsAttributes.ProductName:
                    ProductNameValidation(value);
                    break;
                case ColumnsAttributes.ElzabProductName:
                    ElzabProductNameValidation(value);
                    break;
                case ColumnsAttributes.PriceNet:
                    PriceNetValueValidation(value);
                    break;
                case ColumnsAttributes.Marigin:
                    MariginValueValidation(value);
                    break;
                case ColumnsAttributes.Tax:
                    TaxValueValidation(value);
                    break;
                case ColumnsAttributes.FinalPrice:
                    FinalPriceValueValidation(value);
                    break;
                case ColumnsAttributes.Barcode_EAN13:
                    BarcodeEan13Validation(value);
                    break;
                case ColumnsAttributes.Barcode_EAN8:
                    BarcodeEan8Validation(value);
                    break;
                case ColumnsAttributes.Discount:
                   GeneralNumberValidation(value);
                    break;
                case ColumnsAttributes.PriceNetWithDiscount:
                    PriceNetValueValidation(value);
                    break;
            }

        }

        //Method used to validate of the general description
        static public bool GeneralDescriptionValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Opis może mieć maksymalnie 1024 znaki oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+'&";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/;:–&]+\s)*[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/:;–&]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);
            if (input.Length > 1024) validatingResult = false;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of product name
        static public bool ProductNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa produktu musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+'&";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/;:–&]+\s)*[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/:;–&]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);
            if (input.Length > 255) validatingResult = false;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of supplier name
        static public bool SupplierNameValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+'&";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^([a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/;:–&]+\s)*[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/:;–&]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);
            if (input.Length > 255) validatingResult = false;

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
            string regPattern = @"^([a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/;:–&]+\s)*[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/:;–&]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);
            if (input.Length > 255) validatingResult = false;

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
            string regPattern = @"^([a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/;:–&]+\s)*[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9'_+-.%()/:;–&]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);
            if (input.Length > 34) validatingResult = false;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate of marigin value
        static public bool MariginValueValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Marża jest liczbą całkowitą";

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

        //Method used to validate general number
        static public bool GeneralNumberValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Podana warość musi być liczbą całkowitą!";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]+$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate cash register number
        static public bool ElzabProductNumberValidation(int input, int startNumber, int lastNumber)
        {
            //Local variables
            bool validatingResult;
            string text = "Dla podanego producenta, numer w kasie musi zawierać się między " + startNumber + "-" + lastNumber + "!";

            if ((input < startNumber) || (input > lastNumber)) validatingResult = false;
            else validatingResult = true;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate barcode EAN13
        static public bool BarcodeEan13Validation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Kod kreskowy musi składać się wyłacznie z 13 liczb!";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]{13}$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate barcode EAN8
        static public bool BarcodeEan8Validation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Kod kreskowy musi składać się wyłacznie z 8 liczb!";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]{8}$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate supplier code
        static public bool SupplierCodeValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Kod dostawcy musi składać się wyłacznie z 255 znaków!";

            if (input.Length <= 255) validatingResult = true;
            else validatingResult = false;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate final price
        static public bool FinalPriceValueValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Podana warość musi być liczbą rzeczywistą!";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[0-9]+(\.[0-9]+)?$";

            //Check if input match to define pattern
            validatingResult = ValidateInput(input, regPattern);

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate product info
        static public bool ProductInfoValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Informacje o produkcie może zawierać maksymalnie 1024 znaki!!";

            //Check if input match to define pattern
            if (input.Length <= 1024) validatingResult = true;
            else validatingResult = false;

            if (!validatingResult) throw new ValidatingFailed("Błąd podczas weryfikacji '" + input + "'! " + text);

            return validatingResult;
        }

        //Method used to validate general info field
        static public bool GeneralInfoValidation(string input)
        {
            //Local variables
            bool validatingResult;
            string text = "Informacja może zawierać maksymalnie 1024 znaki!!";

            //Check if input match to define pattern
            if (input.Length <= 1024) validatingResult = true;
            else validatingResult = false;

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
