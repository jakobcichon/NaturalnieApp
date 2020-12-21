using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NaturalnieApp.Database;
using DymoSDK.Implementations;
using DymoSDK.Interfaces;

namespace NaturalnieApp.Dymo_Printer
{
    
    #region Class specific exception
    [Serializable()]
    public class InvalidPath : Exception
    {
        public InvalidPath() : base() { }
        public InvalidPath(string message) : base(message) { }
        public InvalidPath(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidPath(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class InvalidExtension : Exception
    {
        public InvalidExtension() : base() { }
        public InvalidExtension(string message) : base(message) { }
        public InvalidExtension(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidExtension(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    #endregion

    public class Printer
    {
        #region Object fields
        //Instance fields
        string LabelPath { get; set; }

        //Label to print
        DymoLabel LabelToPrint { get; set; }
        List<IPrinter> PrinterDevices { get; set; }
        IPrinter SelectedPrinter { get; set; }
        #endregion

        #region Class constructor
        public Printer(string labelPath)
        {
            //Assign label path
            ChangeLabelFilePath(labelPath);

            //Get label to print
            this.LabelToPrint = new DymoLabel();
            this.LabelToPrint.LoadLabelFromFilePath(labelPath);
            
            //Get printer list
            this.PrinterDevices = DymoPrinter.Instance.GetPrinters().ToList();
            if (this.PrinterDevices.Count > 0) this.SelectedPrinter = this.PrinterDevices[0];

        }
        #endregion

        /// <summary>
        /// Method used to print price card (product name, barcode and final price) from Product object
        /// </summary>
        /// <param name="listOfProductToPrint"></param>
        public void PrintPriceCardFromProduct(Product productToPrint)
        {
            //Check type of label paper


            //Get label object
            List<ILabelObject> labelObjects = this.LabelToPrint.GetLabelObjects().ToList();

            foreach (ILabelObject element in labelObjects)
            {
                //Change product name on label
                if (element.Name == "textLine1_up" || element.Name == "textLine1_down")
                {
                    if (productToPrint.ElzabProductName.Count() > 17)
                    {
                        this.LabelToPrint.UpdateLabelObject(element, productToPrint.ElzabProductName.Substring(0,17).ToUpper() + "-");
                    }
                    
                }
                //Change product name on label
                if (element.Name == "textLine2_up" || element.Name == "textLine2_down")
                {
                    if (productToPrint.ElzabProductName.Count() > 17)
                    {
                        this.LabelToPrint.UpdateLabelObject(element, productToPrint.ElzabProductName.Substring(17, (productToPrint.ElzabProductName.Count()-18)).ToUpper());
                    }

                }
                //Change barcode value
                else if (element.Name == "barcode_up" || element.Name == "barcode_down")
                {
                    this.LabelToPrint.UpdateLabelObject(element, productToPrint.BarCodeShort.Substring(0,7));
                    ;
                }
                //Change price
                else if (element.Name == "price_up" || element.Name == "price_down")
                {
                    this.LabelToPrint.UpdateLabelObject(element, (productToPrint.FinalPrice.ToString() + " pln").ToUpper());
                }

            }

            //Print label
            DymoPrinter.Instance.PrintLabel(this.LabelToPrint, this.SelectedPrinter.Name, barcodeGraphsQuality: true) ;
            ;
        }

        /// <summary>
        /// Method used to verify if given file exist and if it contain .label excention.
        /// </summary>
        /// <param name="label"></param>
        public void ChangeLabelFilePath(string label)
        {
            //Local variable
            string extension;
            string fileName;
            string path;
            bool fileExist;

            //Get file name and path
            fileName = Path.GetFileNameWithoutExtension(label);
            path = Path.GetDirectoryName(label);

            //Check if file exist
            fileExist = File.Exists(label);
            if (!fileExist) throw new InvalidPath(
                string.Format("Ścieżka lub plik nie istnieje! Nazwa pliku : '{0}'. Ścieżka: '{1}'.", fileName, path));

            //Get file extension
            extension = Path.GetExtension(label);
            if (extension != ".label") throw new InvalidExtension(
                string.Format("Plik musi posiadać rozszerzenie '.label'. Rozszerzenie podanego pliku : '{0}'.", extension));

            //Write verified path to the object
            this.LabelPath = label;

            //Get label to print
            //this.LabelToPrint = Framework.Open(this.LabelPath);
        }
    }
}
