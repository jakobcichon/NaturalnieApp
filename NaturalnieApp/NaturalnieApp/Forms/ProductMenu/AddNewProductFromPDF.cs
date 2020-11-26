using System;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using Aspose.Pdf;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NaturalnieApp.PdfToExcel;
using SautinSoft;

namespace NaturalnieApp.Forms
{
    public partial class AddNewProductFromPDF : Form
    {
        // Required for AnyCPU implementation.

        public AddNewProductFromPDF()
        {
            InitializeComponent();

            // Initialize PDFNet before using any PDFTron related
            // classes and methods (some exceptions can be found in API)

        }

        void SaveToPDF(string pdfPath, string outPath)
        {
            /*
            //Get file name
            string fileName = Path.GetFileNameWithoutExtension(pdfPath);

            PdfFocus pdfConverter = new PdfFocus();
            pdfConverter.OpenPdf(pdfPath);
            pdfConverter.ToExcel(Path.Combine(outPath, fileName + ".xls"));
            ;
            */


            //Get file name
            string fileName = Path.GetFileNameWithoutExtension(pdfPath);
            // Load PDF document
            Document pdfDocument = new Document(pdfPath);
            // Initialize ExcelSaveOptions
            ExcelSaveOptions options = new ExcelSaveOptions();
            // Set output format
            options.Format = ExcelSaveOptions.ExcelFormat.XLSX;
            // Save output file
            pdfDocument.Save(Path.Combine(outPath, fileName + ".xlsx"), options);
            ;
        }


        private void bBrowsePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog outputFilePathDialog = new FolderBrowserDialog();
                if (outputFilePathDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    
                    this.tbPdfPath.Text = inputFileDialog.FileName;
                    //SaveToPDF(this.tbPdfPath.Text, outputFilePathDialog.SelectedPath);

                    //Combine path for excel file name
                    string fileName = Path.GetFileNameWithoutExtension(inputFileDialog.FileName);
                    ReadExcel(Path.Combine(outputFilePathDialog.SelectedPath, fileName + ".xlsx"));
                    ;
                }


            }

        }

            //Method used to read data from excel from the specified path
        //Method return List of data table, where one list element contains one sheet data from excel file
        private void ReadExcel(string filePath)
        {
            try
            {
                //Get excel data
                List<DataTable> excelData = ExcelBase.GetAllDataFromExcel(filePath);

                //Get proper template and get ents
                EWAX_Supplier supplierInvoice = new EWAX_Supplier();
                supplierInvoice.ExtractEntities(supplierInvoice, excelData);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            ;
        }

        
     
    }
}
