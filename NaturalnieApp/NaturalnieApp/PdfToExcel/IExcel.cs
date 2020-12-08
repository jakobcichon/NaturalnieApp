using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NaturalnieApp.PdfToExcel
{
    public interface IExcel
    {
        //Starting from this string, data will be considered as the product entity data
        string StartString { get; }
        //Until this string, data will be considered as the product entity data
        string EndString { get; }
        //Number of expected columns in excel
        int NumberOfColumns { get; }

        //Properties
        Properties _Properties { get; set; }

        Dictionary<ColumnsAttributes, string> DataTableSchema_Excel { get; }
        Dictionary<ColumnsAttributes, string> DataTableSchema_WinForm { get; }
    }
}
