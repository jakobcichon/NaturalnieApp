using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.PdfToExcel
{
    public class EWAX_Supplier: ExcelBase, IExcel
    {
        //Properties for reading from excel
        public Properties _Properties { get; set; }

        public string StartString { get; }

        public string EndString { get;  }

        public EWAX_Supplier()
        {
            this.StartString = "Lp";
            this.EndString = "Forma płatności";
        }
    }
}
