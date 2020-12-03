using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NaturalnieApp.PdfToExcel
{
    public class AddProduct_General: ExcelBase, IExcel
    {
        //Properties for reading from excel
        public Properties _Properties { get; set; }
        public string StartString { get; }
        public string EndString { get;  }
        public int NumberOfColumns { get; }
        public string[] PrimaryKeys { get; }

        public Dictionary<ColumnsAttributes, string> DataTableSchema { get; }

        public AddProduct_General()
        {
            this._Properties = new Properties();
            this._Properties.StartStringDefineColumnNames = true;
            this._Properties.LastEntity = Properties.LastEntityMark.RowWithLastNumericValueInFirstColumn;
            this._Properties.NumberOfRowByEntity = 2;
            this.StartString = "Lp";
            this.EndString = "Forma płatności";
            this.NumberOfColumns = 9;
            this.PrimaryKeys = new string[2] { "Kod kreskowy", "Kod dostawcy" };


            //Barcode and supplier code can be used alternately, but use one of it is mandatory
            this.DataTableSchema = new Dictionary<ColumnsAttributes, string>
            {
                {ColumnsAttributes.GeneralNumber,  "Lp."},
                {ColumnsAttributes.GeneralText, "Dostawca" },
                {ColumnsAttributes.GeneralText, "Producent" },
                {ColumnsAttributes.GeneralText, "Nazwa towaru"},
                {ColumnsAttributes.GeneralNumber, "Kod kreskowy" },
                {ColumnsAttributes.GeneralNumber, "Kod dostawcy" },
                {ColumnsAttributes.GeneralNumber,"Cena netto" },
                {ColumnsAttributes.Percentage, "VAT" }

            };

        }
    }
}
