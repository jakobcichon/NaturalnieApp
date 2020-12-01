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
        //Set the instance fields
        string ProductColumnName { get; set; }
        string ElzabProductColumnName { get; set; }

        string LastExcelFilePath { get; set; }

        public AddNewProductFromExcel()
        {
            InitializeComponent();
            this.ProductColumnName = "Nazwa towaru";
            this.ElzabProductColumnName = "Nazwa towaru w Elzab";
            this.LastExcelFilePath = "";
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
                    this.LastExcelFilePath = inputFileDialog.FileName;
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
            //Local variables
            DataTable dataFromExcel;

            try
            {
                //Get excel data
                List<DataTable> excelData = ExcelBase.GetAllDataFromExcel(filePath);

                //Get proper template and get ents
                AddProduct_General supplierInvoice = new AddProduct_General();
                dataFromExcel = supplierInvoice.ExtractEntities(supplierInvoice, excelData);

                //Insert column with Elzab name (max 34 signs)
                DataColumn column = new DataColumn(this.ElzabProductColumnName, typeof(String));
                dataFromExcel.Columns.Add(column);
                dataFromExcel.Columns[this.ElzabProductColumnName].SetOrdinal(dataFromExcel.Columns[this.ProductColumnName].Ordinal + 1);

                //Copy product name to the column with name of product in Elzab
                foreach(DataRow row in dataFromExcel.Rows)
                {
                    int indexOfDesireRow = dataFromExcel.Rows.IndexOf(row);
                    string rowValue = row.Field<string>(this.ProductColumnName).Substring(0,34);
                    dataFromExcel.Rows[indexOfDesireRow].SetField(this.ElzabProductColumnName, rowValue);
                }

                //Set data source on grid view
                advancedDataGridView1.DataSource = dataFromExcel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            //Add checkbox to data grid
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            advancedDataGridView1.Columns.Insert(0, chk);
            chk.HeaderText = "Zaznacz";
            chk.Name = "chk";
            bDeselectAll.Visible = true;
            bSelectAll.Visible = true;

            //Autosize columns
            advancedDataGridView1.AutoResizeColumns();

        }

        private void bGenerateTemplate_Click(object sender, EventArgs e)
        {
            //Open folder dialog browser
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get proper template
                AddProduct_General supplierInvoice = new AddProduct_General();
                ExcelBase.CreateExcelFile(supplierInvoice, folderBrowserDialog1.SelectedPath, "template");
            }

        }

        private void bSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = true;

            }
        }

        private void bDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = false;

            }
        }

        private void advancedDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;
            DataGridViewSelectedCellCollection cells = localSender.SelectedCells;

            foreach (DataGridViewCell cell in cells)
            {
                //Get index of desire column
                int indexPrimaryColumn = localSender.Columns[this.ProductColumnName].Index;
                int indexSecondaryColumn = localSender.Columns[this.ElzabProductColumnName].Index;
                if (cell.ColumnIndex == indexPrimaryColumn)
                {
                    if (cell.Value.ToString().Length > 34)
                    {
                        localSender.Rows[cell.RowIndex].Cells[indexSecondaryColumn].Value = cell.Value.ToString().Substring(0, 34);
                    }
                    else
                    {
                        localSender.Rows[cell.RowIndex].Cells[indexSecondaryColumn].Value = cell.Value.ToString();
                    }
                }
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (this.LastExcelFilePath.Length > 0) ReadExcel(this.LastExcelFilePath);
            else MessageBox.Show("Nie wybrano pliku wejściowego!");
        }
    }
}
