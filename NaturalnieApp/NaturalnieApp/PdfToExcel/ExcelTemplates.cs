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

        public Dictionary<ColumnsAttributes, string> DataTableSchema_Excel { get; }
        public Dictionary<ColumnsAttributes, string> DataTableSchema_WinForm { get; }

        public AddProduct_General()
        {
            this._Properties = new Properties();
            this._Properties.StartStringDefineColumnNames = true;
            this._Properties.LastEntity = Properties.LastEntityMark.RowWithLastNumericValueInFirstColumn;
            this._Properties.NumberOfRowByEntity = 2;



            //Barcode and supplier code can be used alternately, but use one of it is mandatory
            this.DataTableSchema_Excel = new Dictionary<ColumnsAttributes, string>
            {
                {ColumnsAttributes.IndexColumnName, "Lp."},
                {ColumnsAttributes.SupplierName, "Dostawca"},
                {ColumnsAttributes.ManufacturerName, "Producent"},
                {ColumnsAttributes.ProductName, "Nazwa towaru"},
                {ColumnsAttributes.ElzabProductName, "Nazwa towaru Elzab"},
                {ColumnsAttributes.Barcode_EAN13, "Kod kreskowy"},
                {ColumnsAttributes.SupplierCode, "Kod dostawcy"},
                {ColumnsAttributes.PriceNet, "Cena netto"},
                {ColumnsAttributes.Tax, "VAT"},
                {ColumnsAttributes.Discount, "Rabat dostawcy"}
            };

            //Count number of columns
            this.NumberOfColumns = this.DataTableSchema_Excel.Count();

            this.DataTableSchema_WinForm = new Dictionary<ColumnsAttributes, string>
            {
                {ColumnsAttributes.IndexColumnName, "Lp."},
                {ColumnsAttributes.SupplierName, "Dostawca"},
                {ColumnsAttributes.ManufacturerName, "Producent"},
                {ColumnsAttributes.ProductName, "Nazwa towaru"},
                {ColumnsAttributes.ElzabProductName, "Nazwa towaru Elzab"},
                {ColumnsAttributes.Barcode_EAN13, "Kod kreskowy"},
                {ColumnsAttributes.SupplierCode, "Kod dostawcy"},
                {ColumnsAttributes.PriceNet, "Cena netto"},
                {ColumnsAttributes.FinalPrice, "Cena klienta" },
                {ColumnsAttributes.Tax, "VAT"},
                {ColumnsAttributes.Marigin, "Marża"},
                {ColumnsAttributes.CheckBox, "Zaznacz"},
                {ColumnsAttributes.Discount, "Rabat dostawcy"},
                {ColumnsAttributes.PriceNetWithDiscount, "Cena netto ze zniżką"}
            };

        }
    }
}
