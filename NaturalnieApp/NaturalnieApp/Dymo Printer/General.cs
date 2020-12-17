using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYMO.DLS.SDK.DLS7SDK;

namespace NaturalnieApp.Dymo_Printer
{
    public class Printer
    {
        #region Object fields
        //Instance fields
        string LabelPath { get; set; }

        //Dymo SDK
        DymoHighLevelSDK DymoSDK;

        #endregion

        #region Class constructor
        public Printer(string labelPath)
        {
            //Assign label path
            this.LabelPath = labelPath;

            //Initialize DymoSDK
            this.DymoSDK = new DymoHighLevelSDK();
        }
        #endregion

        static public void Test()
        {

            DymoHighLevelSDK test = new DymoHighLevelSDK();
            test.DymoAddin.Open(pathToFile);
            test.DymoAddin.GetDymoPrinters();

            test.DymoAddin.Print(2,false);
            ;
        }

        static public void ChangeLabelFilePath(string label)
        {
            File
        }


        ///Method used to check if Dymo pronter connected

    }
}
