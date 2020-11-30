using System;
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



        private void bAddFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Check if selected file is an excel file
                string fileExtension = Path.GetExtension(inputFileDialog.FileName);
                if ((fileExtension == ".xls") || (fileExtension == ".xlsx") || (fileExtension == ".xlsb"))
                {
                    ReadExcel(inputFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("Wybrano plik o błędnym rozszerzeniu. Dostepne rozszerzenia to : '.xls', 'xlsx', 'xlsb'");
                }
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
                dgvExcelData.DataSource = supplierInvoice.ExtractEntities(supplierInvoice, excelData);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Add checkbox to data grid
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dgvExcelData.Columns.Insert(0, chk);
            chk.HeaderText = "Zaznacz";
            chk.Name = "chk";
            bDeselectAll.Visible = true;
            bSelectAll.Visible = true;

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

        private void bSelectAll_Click(object sender, EventArgs e)
        {
            ; 
            
            foreach (DataGridViewRow roow in dgvExcelData.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = roow.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = true;

                if (Convert.ToBoolean(chkchecking.Value) == true)
                {
                    ;
                }
            }
        }

        private void bDeselectAll_Click(object sender, EventArgs e)
        {

        }
    }
}
