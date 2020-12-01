﻿using System;
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

        public List<string> DataTableSchema { get; }

        public AddProduct_General()
        {
            this._Properties = new Properties();
            this._Properties.StartStringDefineColumnNames = true;
            this._Properties.LastEntity = Properties.LastEntityMark.RowWithLastNumericValueInFirstColumn;
            this._Properties.NumberOfRowByEntity = 2;
            this.StartString = "Lp";
            this.EndString = "Forma płatności";
            this.NumberOfColumns = 9;

            this.DataTableSchema = new List<string>
            {
                "Lp.", "Dostawca", "Producent", "Nazwa towaru", "Kod kreskowy",  "Cena netto", "VAT"

            };

        }
    }
}
