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
using System.Text.RegularExpressions;
using NaturalnieApp.Database;
using NaturalnieApp.Forms;

namespace NaturalnieApp.Forms
{
    public partial class AddNewProductFromExcel : Form
    {

        #region Object fields
        //Set the instance fields
        DatabaseCommands databaseCommands;
        string ProductColumnName { get; set; }
        string ElzabProductColumnName { get; set; }
        string FinalPriceColumnName { get; set; }
        string MariginColumnName { get; set; }
        string TaxColumnName { get; set; }
        string PriceNetColumnName { get; set; }
        string CheckBoxColumnName { get; set; }
        string SupplierColumnName { get; set; }
        string ManufacturerColumnName { get; set; }
        string LastExcelFilePath { get; set; }
        AddProduct_General SupplierInvoice { get; set; }


        //Variable used to identify last cell clicked on advanced data grid view
        //This is used to start cell modification with singe clik
        private int[] LastCellCliked { get; set;}
        #endregion

        #region Class constructor
        public AddNewProductFromExcel(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            this.SupplierInvoice = new AddProduct_General();
            
            //Get data from excel schema
            this.ProductColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.ProductName).Value;
            this.TaxColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Tax).Value;
            this.PriceNetColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.PriceNet).Value;
            this.SupplierColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.SupplierName).Value;
            this.ManufacturerColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.ManufacturerName).Value;

            //Get additiona data from Wiun Form schema
            this.FinalPriceColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.FinalPrice).Value;
            this.MariginColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Marigin).Value;
            this.CheckBoxColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.CheckBox).Value;
            this.ElzabProductColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.ElzabProductName).Value;

            this.LastExcelFilePath = "";
            this.databaseCommands = new DatabaseCommands();

            //Initialization of last cell clicked variable
            this.LastCellCliked = new[] { 0 , 0 };
        }
        #endregion

        #region General methods
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
                dataFromExcel = this.SupplierInvoice.ExtractEntities(this.SupplierInvoice, excelData);

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

                dataFromExcel = ClearString(dataFromExcel, this.SupplierInvoice);

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

            //Add default marigin value and calculate final price
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
            chk.HeaderText = this.CheckBoxColumnName;
            chk.Name = this.CheckBoxColumnName;
            bDeselectAll.Visible = true;
            bSelectAll.Visible = true;

            advancedDataGridView1.Columns[1].CellTemplate.ValueType = Type.GetType("Int");
            ;
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
                    columnAttribute = template.DataTableSchema_Excel.FirstOrDefault(e => e.Value == columnName).Key;

                    //Some general operation on string, to clear it
                    singleElement = element.Trim();
                    singleElement = Regex.Unescape(singleElement);
                    singleElement = singleElement.Replace("\n", "");
                    singleElement = singleElement.Replace("\t", "");
                    singleElement = singleElement.Replace("*", "");

                    //Sepcific string action depending on column attribute
                    //Percentage
                    if (columnAttribute == ColumnsAttributes.Tax)
                    {
                        //If percentage sing exist, remove it
                        singleElement = singleElement.Replace(" % ", "");

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
                    if (columnAttribute == ColumnsAttributes.PriceNet)
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
        #endregion

        #region Buttons events
        //Event for generate template button
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

        //Event for "selected all" button for advanced data frid view
        private void bSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = true;

            }
        }

        //Event for "deselect all" button for advanced data frid view
        private void bDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = false;
            }
        }

        //Event for "add from file" button
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

            }

        }

        //Event for "update" button
        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (this.LastExcelFilePath.Length > 0) ReadExcel(this.LastExcelFilePath);
            else MessageBox.Show("Nie wybrano pliku wejściowego!");
        }

        //Event for "save" button
        private void bSave_Click(object sender, EventArgs e)
        {

            //1. Get list of all selected cells
            //Get check box column name
            string chckColumnName;
            this.SupplierInvoice.DataTableSchema_WinForm.TryGetValue(ColumnsAttributes.CheckBox, out chckColumnName);

            //Row collection
            List<DataGridViewRow> rowCollectionToAdd = new List<DataGridViewRow>();

            //Loop through all rows and add to the list only rows with check box set to true
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                if (row.Cells[chckColumnName].Value != null)
                {
                    if ((bool)row.Cells[chckColumnName].Value == true)
                    {
                        rowCollectionToAdd.Add(row);
                    }
                }

            }

            //2.Get list of manufacturer, supplier and product name from db
            List<string> manufaturerNameList = this.databaseCommands.GetManufacturersNameList();
            List<string> supplierNameList = this.databaseCommands.GetSuppliersNameList();
            List<string> productNameList = this.databaseCommands.GetProductsNameList();

            ;

            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                //Get only checked rows
                DataGridViewCheckBoxCell chkChecking = row.Cells[this.CheckBoxColumnName] as DataGridViewCheckBoxCell;
                bool chck =  Convert.ToBoolean(chkChecking.Value);

                //If row chcecked and not new row
                if ((!row.IsNewRow) && (chck == true))
                {
                    //Try to validate all fields
                    try
                    {
                        Validation.SupplierNameValidation(row.Cells[this.SupplierColumnName].Value.ToString());
                        Validation.ManufacturerNameValidation(row.Cells[this.ManufacturerColumnName].Value.ToString());
                        Validation.ProductNameValidation(row.Cells[this.ProductColumnName].Value.ToString());
                        Validation.ElzabProductNameValidation(row.Cells[this.ElzabProductColumnName].Value.ToString());
                        Validation.MariginValueValidation(row.Cells[this.MariginColumnName].Value.ToString());
                        Validation.PriceNetValueValidation(row.Cells[this.PriceNetColumnName].Value.ToString());
                        Validation.TaxValueValidation(row.Cells[this.TaxColumnName].Value.ToString());
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
        #endregion

        #region Advanced Data Grid View Events

        //Event for advanced data grid view click
        private void advancedDataGridView1_Click(object sender, EventArgs e)
        {
            //Cast an object to a know type
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;
            DataGridViewSelectedCellCollection cells = localSender.SelectedCells;
            DataGridViewCell cell = cells[0];
            int[] currenCellClik = new[] { cell.RowIndex, cell.ColumnIndex };

            //Check if last clicked cell is the same as previous one
            //If yest, start cell editing
            if (currenCellClik[0] == this.LastCellCliked[0] && currenCellClik[1] == this.LastCellCliked[1])
            {
                localSender.BeginEdit(true);
            }

            //Save current cell selected, as last one
            this.LastCellCliked = currenCellClik;
        }

        //Event for advanced data grid view double click
        private void advancedDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //Cast an object to a know type
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;

            localSender.BeginEdit(true);
        }

        //Event for advanced data grid view cell value changed
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

        //Event for advanced data grid view double click
        private void advancedDataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //Cast to known object type
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;
            DataGridViewSelectedCellCollection cells = localSender.SelectedCells;
            if (cells.Count > 0)
            {
                foreach (DataGridViewCell cell in cells)
                {
                    if (cell.IsInEditMode)
                    {
                        try
                        {
                            //Get name of present cell column
                            string nameOfPresentColumn = localSender.Columns[cell.ColumnIndex].Name;

                            //Try to parse depending of column name
                            Validation.GetValidationMethod(nameOfPresentColumn, e.FormattedValue.ToString(), this.SupplierInvoice);
                        }
                        catch (Validation.ValidatingFailed ex)
                        {
                            //Make an exception for empty cell value. It will be dobule checked before saving to database
                            if (e.FormattedValue.ToString() != "")
                            {
                                e.Cancel = true;
                                localSender.Rows[e.RowIndex].ErrorText = ex.Message;
                            }
                        }
                    }
                }
               
            }

        }
        //Event for advanced data grid view double click
        private void advancedDataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Cast to known object type
            Zuby.ADGV.AdvancedDataGridView localSender = sender as Zuby.ADGV.AdvancedDataGridView;
            DataGridViewSelectedCellCollection cells = localSender.SelectedCells;

            //Clear error text after value validated properly
            if (localSender.Rows[e.RowIndex].ErrorText != null) localSender.Rows[e.RowIndex].ErrorText = null;

        }

        private void advancedDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

    }
}
