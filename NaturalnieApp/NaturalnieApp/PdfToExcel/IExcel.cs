﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.PdfToExcel
{
    public interface IExcel
    {
        //Starting from this string, data will be considered as the product entity data
        string StartString { get; }
        //Until this string, data will be considered as the product entity data
        string EndString { get; }
        //

    }
}