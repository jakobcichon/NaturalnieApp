﻿using System;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NaturalnieApp.PdfToExcel;
using SautinSoft;

namespace NaturalnieApp.Forms
{
    public partial class AddNewProductFromExcel : Form
    {
        // Required for AnyCPU implementation.

        public AddNewProductFromExcel()
        {
            InitializeComponent();

            // Initialize PDFNet before using any PDFTron related
            // classes and methods (some exceptions can be found in API)

        }



        private void bBrowsePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Combine path for excel file name
                string fileName = Path.GetFileNameWithoutExtension(inputFileDialog.FileName);
                ReadExcel(inputFileDialog.FileName);
                ;
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

        private void bGenerateTemplate_Click(object sender, EventArgs e)
        {
            //Open folder dialog browser
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get proper template
                EWAX_Supplier supplierInvoice = new EWAX_Supplier();
                ExcelBase.CreateExcelFile(supplierInvoice, folderBrowserDialog1.SelectedPath, "template");
            }

        }
    }
}
