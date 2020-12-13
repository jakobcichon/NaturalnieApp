using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYMO.Label.Framework;
using DYMO.Common;
using System.IO;

namespace NaturalnieApp.Dymo_Printer
{
    static public class General
    {
        static public void Test()
        {
            string pathToFile = @"F:\Projekty\02. NaturalnieApp\NaturalnieApp\NaturalnieApp\NaturalnieApp\Dymo Printer\barcode.label";
            var label = Label.Open(pathToFile);
            ;
            
            label.Print("DYMO LabelWriter 450");
            ;
        }
    }
}
