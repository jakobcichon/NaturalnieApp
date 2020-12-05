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
using System.Text.RegularExpressions;
using NaturalnieApp.Database;

namespace NaturalnieApp.Forms
{
    public partial class AddNewProductFromExcel : Form
    {
        //Set the instance fields
        DatabaseCommands databaseCommands;
        string ProductColumnName { get; set; }
        string ElzabProductColumnName { get; set; }
        string FinalPriceColumnName { get; set; }
        string MariginColumnName { get; set; }
        string TaxColumnName { get; set; }
        string PriceNetColumnName { get; set; }
        string LastExcelFilePath { get; set; }
        

        public AddNewProductFromExcel(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            this.ProductColumnName = "Nazwa towaru";
            this.ElzabProductColumnName = "Nazwa towaru w Elzab";
            this.FinalPriceColumnName = "Cena klienta";
            this.MariginColumnName = "Marża";
            this.TaxColumnName = "VAT";
            this.PriceNetColumnName = "Cena netto";
            this.LastExcelFilePath = "";
            this.databaseCommands = new DatabaseCommands();
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
            DataTable dataFromExcel = new DataTable();

            try
            {
                //Get excel data
                List<DataTable> excelData = ExcelBase.GetAllDataFromExcel(filePath);

                //Get proper template and get ents
                AddProduct_General supplierInvoice = new AddProduct_General();
                dataFromExcel = supplierInvoice.ExtractEntities(supplierInvoice, excelData);

                //Add additional columns

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

                dataFromExcel = ClearString(dataFromExcel, supplierInvoice);

                //Set data source on grid view
                advancedDataGridView1.DataSource = dataFromExcel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Add mrigin and final price column to the grid
            string HeaderText = this.MariginColumnName;
            string Name = this.MariginColumnName;
            advancedDataGridView1.Columns.Add(Name, HeaderText);
            HeaderText = this.FinalPriceColumnName;
            Name = this.FinalPriceColumnName;
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            //Add default marigin value and calculate  final price
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                //Get all necessary indexes
                int indexOfCurrentRow = advancedDataGridView1.Rows.IndexOf(row);
                int indexOfMariginColumn = advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.MariginColumnName].ColumnIndex;
                int indexOfFinalPriceColumn = advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.FinalPriceColumnName].ColumnIndex;
                int indexOfTaxColumn = advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.TaxColumnName].ColumnIndex;
                int indexOfPriceNetColumn = advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.PriceNetColumnName].ColumnIndex;

                //Set amrigin to the default value
                advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value = "20";

                //Calculate final price
                double price = Convert.ToDouble(advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfPriceNetColumn].Value);
                int tax = Convert.ToInt32(advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfTaxColumn].Value);
                int marigin = Convert.ToInt32(advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value);
                double finalPrice = Calculations.FinalPrice(price, tax, marigin);

                advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfFinalPriceColumn].Value = finalPrice.ToString();

            }

            //Add checkbox to data grid
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            advancedDataGridView1.Columns.Insert(0, chk);
            chk.HeaderText = "Zaznacz";
            chk.Name = "Zaznacz";
            bDeselectAll.Visible = true;
            bSelectAll.Visible = true;

            //Autosize columns
            advancedDataGridView1.AutoResizeColumns();

            dataFromExcel.Dispose();
        }

        //Method used to clear string from all escape characters, white spaces etc.
        private DataTable ClearString(DataTable inputData, IExcel template)
        {
            //Local variable
            DataTable localDataTable = inputData;
            string singleElement = "";
            int rowIndex;
            int fieldIndex;

            foreach (DataRow row in localDataTable.Rows)
            {
                foreach (string element in row.ItemArray)
                {
                    //Get row and field indexes
                    rowIndex = localDataTable.Rows.IndexOf(row);
                    fieldIndex = localDataTable.Rows[rowIndex].ItemArray.ToList().IndexOf(element);

                    //Get column name
                    string columnName = localDataTable.Columns[fieldIndex].ColumnName;

                    //Get column attribute
                    ColumnsAttributes columnAttribute;
                    template.DataTableSchema.TryGetValue(columnName, out columnAttribute);

                    //Some general operation on string, to clear it
                    singleElement = element.Trim();
                    singleElement = Regex.Unescape(singleElement);
                    singleElement = singleElement.Replace("\n", "");
                    singleElement = singleElement.Replace("\t", "");
                    singleElement = singleElement.Replace("*", "");

                    //Sepcific string action depending on column attribute
                    //Percentage
                    if (columnAttribute == ColumnsAttributes.Percentage)
                    {
                        //If percentage sing exist, remove it
                        singleElement = singleElement.Replace("%", "");

                        //Try parse to real value, and convert for decimal value
                        double temp = Convert.ToDouble(singleElement);
                        if ( temp < 1.0)
                        {
                            temp *= 100;
                        }

                        //Convert value back
                        singleElement = Convert.ToInt32(temp).ToString();
                    }
                    //Price
                    if (columnAttribute == ColumnsAttributes.Price)
                    {
                        //If percentage sing exist, remove it
                        singleElement = singleElement.Replace(",", ".");
                    }

                    //Repleace with cleared value
                    localDataTable.Rows[rowIndex].SetField(fieldIndex, singleElement);
                }
            }

            return localDataTable;

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

        private void advancedDataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            ;
        }

        private void advancedDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Cast to known object type
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;
            DataGridViewSelectedCellCollection cells = localSender.SelectedCells;

            foreach (DataGridViewCell cell in cells)
            {
                //Get index of desire column
                int indexPrimaryColumn = localSender.Columns[this.ProductColumnName].Index;
                int indexSecondaryColumn = localSender.Columns[this.ElzabProductColumnName].Index;
                int indexOfMarigin = localSender.Columns[this.MariginColumnName].Index;
                int indexOfFinalPrice = localSender.Columns[this.FinalPriceColumnName].Index;
                int indexOfTax = localSender.Columns[this.TaxColumnName].Index;
                int indexOfPriceNet = localSender.Columns[this.PriceNetColumnName].Index;

                //If product name has changed, change also Elzab product name
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

                //If marigin has changed, recalculate final price
                if (cell.ColumnIndex == indexOfMarigin)
                {
                    double price = Convert.ToDouble(localSender.Rows[cell.RowIndex].Cells[indexOfPriceNet].Value);
                    int tax = Convert.ToInt32(localSender.Rows[cell.RowIndex].Cells[indexOfTax].Value);
                    int marigin = Convert.ToInt32(localSender.Rows[cell.RowIndex].Cells[indexOfMarigin].Value);
                    localSender.Rows[cell.RowIndex].Cells[indexOfFinalPrice].Value = Calculations.FinalPrice(price, tax, marigin).ToString();
                }
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (this.LastExcelFilePath.Length > 0) ReadExcel(this.LastExcelFilePath);
            else MessageBox.Show("Nie wybrano pliku wejściowego!");
        }

        private void bSave_Click(object sender, EventArgs e)
        {

            Product test = this.databaseCommands.CheckIfProductExist("22", "", "1");
            ;

            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    try
                    {
                        Validation.ElzabProductNameValidation(row.Cells[this.ElzabProductColumnName].Value.ToString());
                    }
                    catch (Validation.ValidatingFailed ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            
        }
    }
}
