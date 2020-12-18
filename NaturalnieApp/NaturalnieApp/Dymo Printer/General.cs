using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NaturalnieApp.Database;
//using DYMO.DLS.SDK.DLS7SDK;
using DYMO.Label.Framework;

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
        ILabel LabelToPrint { get; set; }

        #endregion

        #region Class constructor
        public Printer(string labelPath)
        {

            //Assign label path
            ChangeLabelFilePath(labelPath);

            //Get label to print
            this.LabelToPrint = Framework.Open(this.LabelPath);
        }
        #endregion

        /// <summary>
        /// Method used to print price card (product name, barcode and final price) from Product object
        /// </summary>
        /// <param name="listOfProductToPrint"></param>
        public void PrintPriceCardFromProduct(Product productToPrint)
        {
            //Change product name on label
            AddressObject productName = (AddressObject) this.LabelToPrint.GetObjectByName("description_up");
            productName.Text = productToPrint.ElzabProductName;

            //Change barcode value
            BarcodeObject bacode = (BarcodeObject)this.LabelToPrint.GetObjectByName("barcode_up");
            bacode.BarcodeText = productToPrint.BarCode;

            //Change price

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
            this.LabelToPrint = Framework.Open(this.LabelPath);
        }
    }
}
