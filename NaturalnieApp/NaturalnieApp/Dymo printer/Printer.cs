using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NaturalnieApp.Database;
using DymoSDK.Implementations;
using DymoSDK.Interfaces;
using System.Management;
using System.Printing;

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

    public class InvalidNumberOfElements : Exception
    {
        public InvalidNumberOfElements() : base() { }
        public InvalidNumberOfElements(string message) : base(message) { }
        public InvalidNumberOfElements(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidNumberOfElements(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class NoPrinterToSelect : Exception
    {
        public NoPrinterToSelect() : base() { }
        public NoPrinterToSelect(string message) : base(message) { }
        public NoPrinterToSelect(string message, System.Exception inner) : base(message, inner) { }
        protected NoPrinterToSelect(System.Runtime.Serialization.SerializationInfo info,
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

            this.LabelPath = labelPath;

            //Assign label path
            ChangeLabelFilePath(labelPath);

            //Get label to print
            this.LabelToPrint = new DymoLabel();
            this.LabelToPrint.LoadLabelFromFilePath(labelPath);
        }
        #endregion

        /// <summary>
        /// Method used to print price card (product name, barcode and final price) from Product object
        /// </summary>
        /// <param name="productToPrint"></param>
        public void PrintPriceCardFromProduct(Product productToPrint)
        {
            //Change upper lable objects
            this.LabelToPrint = ChangeLabelObjectsValues(this.LabelToPrint, productToPrint, true);

            //Change lower lable objects
            this.LabelToPrint = ChangeLabelObjectsValues(this.LabelToPrint, productToPrint, false);

            //Print label
            DymoPrinter.Instance.PrintLabel(this.LabelToPrint, this.SelectedPrinter.Name, barcodeGraphsQuality: true);
        }

        /// <summary>
        /// Method used to print price card (product name, barcode and final price) from Product list.
        /// </summary>
        /// <param name="listOfProductToPrint"></param>
        public void PrintPriceCardsFromProductList(List<Product> listOfProductToPrint)
        {
            //Get number of elements in list
            int numberOfElements = listOfProductToPrint.Count();
            int k = 0;
            List<DymoLabel> listOfTheLabelToPrint = new List<DymoLabel>();

            if (numberOfElements > 0)
            {

                //Loop through all lable objects
                for (int i = 0; i <= numberOfElements - 1; i += 2)
                {
                    int j = i + 1;

                    if (j > numberOfElements - 1)
                    {
                        DymoLabel temp = new DymoLabel();
                        temp.LoadLabelFromFilePath(this.LabelPath);
                        listOfTheLabelToPrint.Add(temp);

                        //Change upper lable objects
                        listOfTheLabelToPrint[k] = ChangeLabelObjectsValues(listOfTheLabelToPrint[k], listOfProductToPrint[i], true);

                        //Change lower lable objects
                        //listOfTheLabelToPrint[k] = ChangeLabelObjectsValues(listOfTheLabelToPrint[k], listOfProductToPrint[i], false);
                    }
                    else
                    {
                        DymoLabel temp = new DymoLabel();
                        temp.LoadLabelFromFilePath(this.LabelPath);
                        listOfTheLabelToPrint.Add(temp);

                        //Change upper lable objects
                        listOfTheLabelToPrint[k] = ChangeLabelObjectsValues(listOfTheLabelToPrint[k], listOfProductToPrint[i], true);

                        //Change lower lable objects
                        listOfTheLabelToPrint[k] = ChangeLabelObjectsValues(listOfTheLabelToPrint[k], listOfProductToPrint[j], false);
                    }

                    k++;
                }
            }
            else throw new InvalidNumberOfElements("Method required at least one element to print!");

            //Print label
            DymoPrinter.Instance.PrintLabel(listOfTheLabelToPrint, this.SelectedPrinter.Name, barcodeGraphsQuality: true);
        }

        /// <summary>
        /// Method used to change Barcode, text line 1 and 2, and price value of given label object.
        /// </summary>
        /// <param name="label,"> Dymo label object</param>
        /// <param name="productToPrint"> Product to print</param>
        /// <param name="upperLower"> If true, change upper label. If False chage lower label</param>
        /// <returns> Updated DymoLabe object</returns>
        private DymoLabel ChangeLabelObjectsValues(DymoLabel label, Product productToPrint, bool upperLower)
        {
            //Local variables
            string sufix;
            DymoLabel retLabel = new DymoLabel();

            //Get label object
            List<ILabelObject> labelObjectsList = label.GetLabelObjects().ToList();

            //Assign sufix value
            if (upperLower) sufix = "_up";
            else sufix = "_down";

            foreach (ILabelObject element in labelObjectsList)
            {
                //Change product name on label
                if (element.Name == "textLine1" + sufix)
                {
                    if (productToPrint.ElzabProductName.Count() > 17)
                    {
                        label.UpdateLabelObject(element, productToPrint.ElzabProductName.Substring(0, 17).ToUpper() + "-");
                    }
                    else
                    {
                        label.UpdateLabelObject(element, productToPrint.ElzabProductName.ToUpper());
                    }

                }
                //Change product name on label
                if (element.Name == "textLine2" + sufix)
                {
                    if (productToPrint.ElzabProductName.Count() > 17)
                    {
                        label.UpdateLabelObject(element, productToPrint.ElzabProductName.Substring(17, (productToPrint.ElzabProductName.Count() - 17)).ToUpper());
                    }
                    else
                    {
                        label.UpdateLabelObject(element, "");
                    }

                }
                //Change barcode value
                else if (element.Name == "barcode" + sufix)
                {
                    label.UpdateLabelObject(element, productToPrint.BarCodeShort.Substring(0, 7).ToUpper());
                }
                //Change price
                else if (element.Name == "price" + sufix)
                {
                    label.UpdateLabelObject(element, (string.Format("{0:0.00}", productToPrint.FinalPrice) + " PLN").ToUpper());
                }
            }

            retLabel = label;

            return retLabel;
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
        }

        public void GetPrinters()
        {
            //Get printer list
            this.PrinterDevices = DymoPrinter.Instance.GetPrinters().ToList();
            if (this.PrinterDevices.Count > 0 && this.PrinterDevices[0].IsConnected) this.SelectedPrinter = this.PrinterDevices[0];
            else throw new NoPrinterToSelect("No available Dymo printer to select! Connect printer and try again!");
        }

        public void ChangePrinter(string printerName)
        {
            //Local variable
            string printerToSelect = "";

            //Get printer list
            this.PrinterDevices = DymoPrinter.Instance.GetPrinters().ToList();
            foreach (IPrinter printer in this.PrinterDevices)
            {
                if (printer.Name == printerName)
                {
                    this.SelectedPrinter = printer;
                    printerToSelect = printer.Name;
                    break;
                }
            }
            if (printerToSelect == "") throw new NoPrinterToSelect("No available printer with given name!");
        }

    }

    public static class PrinterMethods
    {

        public static List<string> GetPrintersNameList()
        {
            //Local list
            List<string> localList = new List<string>();

            localList.AddRange(DymoPrinter.Instance.GetPrinters().Select(p => p.Name));

            return localList;
        }
    }
}
