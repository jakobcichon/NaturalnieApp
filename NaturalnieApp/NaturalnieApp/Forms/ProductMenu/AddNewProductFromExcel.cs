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
using System.Diagnostics;

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
        string BarcodeColumnName { get; set; }
        string SupplierCodeColumnName { get; set; }
        string DiscountColumnName { get; set; }
        string PriceNetWithDiscountColumnName { get; set; }
        string QuantityColumnName { get; set; }
        string IndexColumnName { get; set; }
        DataTable DataFromExcel { get; set; }
        string LastExcelFilePath { get; set; }
        AddProduct_General SupplierInvoice { get; set; }


        //Variable used to identify last cell clicked on advanced data grid view
        //This is used to start cell modification with singe clik
        private int[] LastCellCliked { get; set; }
        #endregion

        #region Class constructor
        public AddNewProductFromExcel(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            this.DataFromExcel = new DataTable();

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
            this.BarcodeColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Barcode_EAN13).Value;
            this.SupplierCodeColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.SupplierCode).Value;
            this.DiscountColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Discount).Value;
            this.QuantityColumnName = this.SupplierInvoice.DataTableSchema_Excel.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Quantity).Value;

            //Get additiona data from Wiun Form schema
            this.FinalPriceColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.FinalPrice).Value;
            this.MariginColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.Marigin).Value;
            this.CheckBoxColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.CheckBox).Value;
            this.ElzabProductColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.ElzabProductName).Value;
            this.IndexColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.IndexColumnName).Value;
            this.PriceNetWithDiscountColumnName = this.SupplierInvoice.DataTableSchema_WinForm.FirstOrDefault(
                e => e.Key == ColumnsAttributes.PriceNetWithDiscount).Value;

            this.LastExcelFilePath = "";
            this.databaseCommands = commandsObj;

            //Initialization of last cell clicked variable
            this.LastCellCliked = new[] { 0, 0 };

            //Initialize advanced data grid view
            InitializeAdvancedDataGridView();
        }
        #endregion

        #region General methods
        private void InitializeAdvancedDataGridView()
        {

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
                dataFromExcel = this.SupplierInvoice.ExtractEntities(this.SupplierInvoice, excelData);

                //Add additional columns
                if (dataFromExcel.Columns.IndexOf(this.ElzabProductColumnName) == -1)
                {
                    //Insert column with Elzab name (max 34 signs)
                    DataColumn column = new DataColumn(this.ElzabProductColumnName, typeof(String));
                    dataFromExcel.Columns.Add(column);
                    dataFromExcel.Columns[this.ElzabProductColumnName].SetOrdinal(dataFromExcel.Columns[this.ProductColumnName].Ordinal + 1);
                }

                //Copy product name to the column with name of product in Elzab
                foreach (DataRow row in dataFromExcel.Rows)
                {

                    int indexOfDesireRow = dataFromExcel.Rows.IndexOf(row);
                    string rowValue = row.Field<string>(this.ElzabProductColumnName);
                    if (rowValue == "")
                    {
                        if (row.Field<string>(this.ProductColumnName).Count() <= 34) rowValue = row.Field<string>(this.ProductColumnName);
                        else rowValue = row.Field<string>(this.ProductColumnName).Substring(0, 34);
                        dataFromExcel.Rows[indexOfDesireRow].SetField(this.ElzabProductColumnName, rowValue);
                    }

                    //If Discount empty or out of bordes, set to 0
                    string discountStringValue = row.Field<string>(this.DiscountColumnName);
                    int discountValue = 0;
                    try
                    {
                        discountValue = Int32.Parse(discountStringValue);
                    }
                    catch (FormatException)
                    {
                        discountValue = 0;
                    }

                    if (discountValue < 0) discountValue = 0;
                    else if (discountValue > 100) discountValue = 100;

                    row.SetField<int>(this.DiscountColumnName, discountValue);

                    //If quantity epmty or not digit, set to 0
                    string quantityRawValue = row.Field<string>(this.QuantityColumnName);
                    int quantityValidatedValue = 0;
                    try
                    {
                        quantityValidatedValue = Int32.Parse(quantityRawValue);
                    }
                    catch (FormatException)
                    {
                        quantityValidatedValue = 0;
                    }

                    row.SetField<int>(this.QuantityColumnName, quantityValidatedValue);

                }

                dataFromExcel = ClearString(dataFromExcel, this.SupplierInvoice);
                this.DataFromExcel = dataFromExcel.Copy();
                dataFromExcel.Dispose();

                //Set data source on grid view
                this.advancedDataGridView1.DataSource = this.DataFromExcel;

                //Add mrigin and final price column to the grid
                string HeaderText = this.MariginColumnName;
                string Name = this.MariginColumnName;
                this.advancedDataGridView1.Columns.Add(Name, HeaderText);

                HeaderText = this.FinalPriceColumnName;
                Name = this.FinalPriceColumnName;
                this.advancedDataGridView1.Columns.Add(Name, HeaderText);

                HeaderText = this.PriceNetWithDiscountColumnName;
                Name = this.PriceNetWithDiscountColumnName;
                this.advancedDataGridView1.Columns.Add(Name, HeaderText);

                //Add default marigin value and calculate final price
                foreach (DataGridViewRow row in this.advancedDataGridView1.Rows)
                {
                    //Get all necessary indexes
                    int indexOfCurrentRow = this.advancedDataGridView1.Rows.IndexOf(row);
                    int indexOfMariginColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.MariginColumnName].ColumnIndex;
                    int indexOfFinalPriceColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.FinalPriceColumnName].ColumnIndex;
                    int indexOfTaxColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.TaxColumnName].ColumnIndex;
                    int indexOfPriceNetColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.PriceNetColumnName].ColumnIndex;
                    int indexOfDiscountColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.DiscountColumnName].ColumnIndex;
                    int indexOfPriceNetWithDiscountColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.PriceNetWithDiscountColumnName].ColumnIndex;

                    //Set amrigin to the default value
                    this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value = this.tbMarigin.Text;

                    //Calculate Final price with discount
                    float priceNet = Convert.ToSingle(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfPriceNetColumn].Value);
                    int discount = Convert.ToInt32(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfDiscountColumn].Value);
                    this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfPriceNetWithDiscountColumn].Value = Calculations.CalculatePriceNetWithDiscount(priceNet, discount);

                    //Calculate final price
                    double price = Convert.ToDouble(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfPriceNetWithDiscountColumn].Value);
                    int tax = Convert.ToInt32(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfTaxColumn].Value);
                    int marigin = Convert.ToInt32(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value);
                    double finalPrice = Calculations.FinalPrice(price, tax, marigin);

                    this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfFinalPriceColumn].Value = finalPrice.ToString();
                }

                //Add checkbox to data grid
                if(advancedDataGridView1.Columns[this.CheckBoxColumnName] == null)
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    advancedDataGridView1.Columns.Insert(0, chk);
                    chk.HeaderText = this.CheckBoxColumnName;
                    chk.Name = this.CheckBoxColumnName;
                    bDeselectAll.Visible = true;
                    bSelectAll.Visible = true;

                    advancedDataGridView1.Columns[1].CellTemplate.ValueType = Type.GetType("Int");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            advancedDataGridView1.Update();
            //Autosize columns
            advancedDataGridView1.AutoResizeColumns();
        }

        private void UpdateControl(ref TextBox dummyForControl)
        {
            //this.Select();
            this.Focus();
            dummyForControl.Select();
        }
        private void tbDummyForCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Tab)
            {
                TextBox localSender = (TextBox)sender;
                localSender.Text = "";
            }
        }

        /// <summary>
        /// Mathod used for short Barcodes, without manufacturer prefix.
        /// </summary>
        /// <param name="manufacturerName"></param>
        /// <param name="shortBarcode"></param>
        /// <returns></returns>
        private string GetBarcodePrefixAndCreateFullBarcode(string manufacturerName, string shortBarcode)
        {
            //LocalVaribales
            string barcodeCheckedVal = "";

            //If Barcode EAN13 has less than 13 chars, but not empty, check if can contact with manufacturer EAN prefix
            string barcode = shortBarcode;
            if (barcode.Count() > 0 && barcode.Count() < 13)
            {
                //Get EAN prefix from DB
                string rowManufacturerNameValue = manufacturerName;
                bool manufacturerNameExist = this.databaseCommands.CheckIfManufacturerNameExist(rowManufacturerNameValue);
                if (manufacturerNameExist)
                {
                    //Get prefix value
                    string prefix = this.databaseCommands.GetManufacturerEanPrefixByName(rowManufacturerNameValue);

                    if (prefix != null)
                    {
                        //Try to add manufacturer EAN prefix to the given barcode and check if it has 13 chars
                        string tempBarcode = prefix + barcode;
                        if (tempBarcode.Count() == 13) barcodeCheckedVal = tempBarcode;
                    }
                    else barcodeCheckedVal = shortBarcode;
                }
                else barcodeCheckedVal = shortBarcode;
            }
            else barcodeCheckedVal = shortBarcode;

            return barcodeCheckedVal;
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
                    singleElement = singleElement.Replace("  ", " ");
                    singleElement = singleElement.Replace("*", "");
                    singleElement = singleElement.Replace('"'.ToString(), "'");

                    //Sepcific string action depending on column attribute
                    //Percentage
                    if (columnAttribute == ColumnsAttributes.Tax)
                    {
                        //If percentage sing exist, remove it
                        singleElement = singleElement.Replace("%", "");

                        //Try parse to real value, and convert for decimal value
                        double temp = Convert.ToDouble(singleElement);
                        if (temp < 1.0)
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
            saveFileDialog1.Title = "Wybierz miejsce docelowe formatki";
            saveFileDialog1.DefaultExt = ".xlsb";
            saveFileDialog1.FileName = "template_" + DateTime.Now.ToString("MM/dd/yyyy HH/mm");

            //Open folder dialog browser
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                string fileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);


                //Get proper template
                AddProduct_General supplierInvoice = new AddProduct_General();
                ExcelBase.CreateExcelFile(supplierInvoice, fileDirectory, fileName);
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }

        //Event for "selected all" button for advanced data frid view
        private void bSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                    chkchecking.Value = true;
                }
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }

        //Event for "deselect all" button for advanced data frid view
        private void bDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                chkchecking.Value = false;
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);
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
                    advancedDataGridView1.DataSource = null;
                    advancedDataGridView1.Columns.Clear();

                    this.LastExcelFilePath = inputFileDialog.FileName;
                    ReadExcel(inputFileDialog.FileName);

                    List<string> multipleEntriesList = GetListOfMultipleEntries(this.DataFromExcel);

                    if(multipleEntriesList.Count > 0)
                    {
                        DialogResult result = MessageBox.Show(string.Format("Uwaga, znaleziono powielone elementy! Czy chcesz zobaczyć pełną listę ({0} wiersz/wierszy do wyświetlenia!", 
                            multipleEntriesList.Count()), "Powielone wpisy w komórkach o wartościach unikatowych.", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            string toDisplay = "";
                            foreach(string element in multipleEntriesList)
                            {
                                toDisplay += element;
                            }
                            MessageBox.Show(toDisplay);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wybrano plik o błędnym rozszerzeniu. Dostepne rozszerzenia to : '.xls', 'xlsx', 'xlsb'");
                }

            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }

        //Event for "update" button
        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (this.LastExcelFilePath.Length > 0) ReadExcel(this.LastExcelFilePath);
            else MessageBox.Show("Nie wybrano pliku wejściowego!");


            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }

        //Event for "save" button
        private void bSave_Click(object sender, EventArgs e)
        {
            //Local variables
            bool validated = false;
            string barcodeCheckedVal = "";

            //1. Get list of all selected cells
            //Get check box column name
            string chckColumnName;
            this.SupplierInvoice.DataTableSchema_WinForm.TryGetValue(ColumnsAttributes.CheckBox, out chckColumnName);

            //Row collection
            List<DataGridViewRow> rowCollectionToAdd = new List<DataGridViewRow>();
            List<DataGridViewRow> rowCollectionToRemoveFromList = new List<DataGridViewRow>();
            List<DataGridViewRow> rowCollectionToAddQuantityToStockList = new List<DataGridViewRow>();

            //Loop through all rows and add to the list only rows with check box set to true
            foreach (DataGridViewRow row in this.advancedDataGridView1.Rows)
            {
                if (row.Cells[chckColumnName].Value != null)
                {
                    if ((bool)row.Cells[chckColumnName].Value == true)
                    {
                        rowCollectionToAdd.Add(row);
                    }
                }

            }

            if(rowCollectionToAdd.Count == 0)
            {
                MessageBox.Show("Nie zaznaczo produktów do dodania. Zaznacz produkty i spróbuj ponownie!");
            }
            else
            {
                //2. Validate all selected rows
                foreach (DataGridViewRow row in rowCollectionToAdd)
                {
                    //Get only checked rows
                    DataGridViewCheckBoxCell chkChecking = row.Cells[this.CheckBoxColumnName] as DataGridViewCheckBoxCell;
                    bool chck = Convert.ToBoolean(chkChecking.Value);

                    //If row chcecked and not new row
                    if ((!row.IsNewRow) && (chck == true))
                    {
                        //Try to validate all fields
                        try
                        {
                            //Validate every entry 
                            Validation.SupplierNameValidation(row.Cells[this.SupplierColumnName].Value.ToString());
                            Validation.ManufacturerNameValidation(row.Cells[this.ManufacturerColumnName].Value.ToString());

                            if (row.Cells[this.BarcodeColumnName].Value.ToString() != "")
                            {

                                //Check if given code is full barcode or oly product code without manufacturer prefix
                                barcodeCheckedVal = GetBarcodePrefixAndCreateFullBarcode(row.Cells[this.ManufacturerColumnName].Value.ToString(),
                                    row.Cells[this.BarcodeColumnName].Value.ToString());
                                if (barcodeCheckedVal == "") barcodeCheckedVal = row.Cells[this.BarcodeColumnName].Value.ToString();
                            }
                            else
                            {
                                barcodeCheckedVal = row.Cells[this.BarcodeColumnName].Value.ToString();
                            }

                            //Validate every entry 
                            Validation.SupplierNameValidation(row.Cells[this.SupplierColumnName].Value.ToString());
                            Validation.ManufacturerNameValidation(row.Cells[this.ManufacturerColumnName].Value.ToString());
                            Validation.ProductNameValidation(row.Cells[this.ProductColumnName].Value.ToString());
                            Validation.ElzabProductNameValidation(row.Cells[this.ElzabProductColumnName].Value.ToString());
                            Validation.MariginValueValidation(row.Cells[this.MariginColumnName].Value.ToString());
                            Validation.PriceNetValueValidation(row.Cells[this.PriceNetColumnName].Value.ToString());
                            Validation.TaxValueValidation(row.Cells[this.TaxColumnName].Value.ToString());
                            Validation.GeneralNumberValidation(row.Cells[this.DiscountColumnName].Value.ToString());

                            //Action depending of barcode type
                            if (barcodeCheckedVal != "" && barcodeCheckedVal.Length != 8 && barcodeCheckedVal.Length != 12) Validation.BarcodeEan13Validation(barcodeCheckedVal);
                            if (barcodeCheckedVal.Length == 8) Validation.BarcodeEan8Validation(barcodeCheckedVal);
                            if (barcodeCheckedVal.Length == 12) Validation.GeneralNumberValidation(barcodeCheckedVal);
                            row.Cells[this.BarcodeColumnName].Value = barcodeCheckedVal;

                            //Set validated bit
                            validated = true;
                        }
                        catch (Validation.ValidatingFailed ex)
                        {
                            //Show message and exit
                            MessageBox.Show(ex.Message + " Numer Lp: " + row.Cells[this.IndexColumnName].Value.ToString());
                            validated = false;
                            break;
                        }
                        catch (Exception ex)
                        {
                            //Show message and exit
                            MessageBox.Show(ex.Message);
                            validated = false;
                            break;
                        }

                    }

                }
            }
            //If validated property, go to the next steps
            if (validated)
            {
                //Local variable used to show if all data was saved successfully
                int savedSuccessfully = -1;

                //Declare list contains names of manufacturer for which maximum number of products was already achieved
                List<string> manufacturersWithExNumberOfProduct = new List<string>();

                //Set variables for user interaction
                bool continueWithoutAskingProductNameExist = false;
                bool continueWithoutAskingSupplierCodeExist = false;
                bool continueWithoutAskingElzabProductNameExist = false;
                bool continueWithoutAskingBarcodeExist = false;

                //Loop through all rows and add it to DB if possible
                foreach (DataGridViewRow row in rowCollectionToAdd)
                {

                    //***********************************************************************************************************
                    #region 4. Check if supplier and manufaturer already exist in database
                    //Variables used to  pass if manufacturer and supplier exist

                    //Set local variable
                    string rowSupplierNameValue = row.Cells[this.SupplierColumnName].Value.ToString();
                    string rowManufacturerNameValue = row.Cells[this.ManufacturerColumnName].Value.ToString();

                    //Get from database if already exist
                    bool supplierNameExist = this.databaseCommands.CheckIfSupplierNameExist(rowSupplierNameValue);
                    bool manufacturerNameExist = this.databaseCommands.CheckIfManufacturerNameExist(rowManufacturerNameValue);

                    if (!supplierNameExist)
                    {
                        DialogResult dialogResult = MessageBox.Show("Dostawca o nazwie '" + rowSupplierNameValue +
                            "' nie istnieje w bazie danych. Czy chesz dodać?", "Brak pozycji w bazie"
                            , MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                Supplier supplier = new Supplier();
                                Validation.SupplierNameValidation(rowSupplierNameValue);
                                supplier.Name = rowSupplierNameValue;
                                this.databaseCommands.AddSupplier(supplier);
                                supplierNameExist = this.databaseCommands.CheckIfSupplierNameExist(rowSupplierNameValue);
                                MessageBox.Show("Dostawca '" + rowSupplierNameValue + "' został dodany do bazy danych!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (dialogResult == DialogResult.No) MessageBox.Show("Anulowano zapis do bazy danych!");
                        else MessageBox.Show("Bład! Anulowano zapis do bazy danych!");
                    }
                    //Check if manufacterer exist in DB
                    if (!manufacturerNameExist)
                    {
                        DialogResult dialogResult = MessageBox.Show("Producent o nazwie '" + rowManufacturerNameValue +
                            "' nie istnieje w bazie danych. Czy chesz dodać?", "Brak pozycji w bazie"
                            , MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                Manufacturer manufacturer = new Manufacturer();
                                Validation.ManufacturerNameValidation(rowManufacturerNameValue);
                                manufacturer.Name = rowManufacturerNameValue;
                                this.databaseCommands.AddManufacturer(manufacturer);
                                manufacturerNameExist = this.databaseCommands.CheckIfManufacturerNameExist(rowManufacturerNameValue);
                                MessageBox.Show("Producent '" + rowManufacturerNameValue + "' został dodany do bazy danych!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (dialogResult == DialogResult.No) MessageBox.Show("Anulowano zapis do bazy danych!");
                        else MessageBox.Show("Bład! Anulowano zapis do bazy danych!");
                    }
                    #endregion

                    //***********************************************************************************************************
                    #region 5. Check if product name, barcode and supplier code does not exist in DB

                    if (supplierNameExist && manufacturerNameExist)
                    {
                        //Set local variable
                        string rowProductNameValue = row.Cells[this.ProductColumnName].Value.ToString();
                        string rowElzabProductNameValue = row.Cells[this.ElzabProductColumnName].Value.ToString();
                        float rowPriceNetValue = float.Parse(row.Cells[this.PriceNetColumnName].Value.ToString());
                        int rowTaxValue = Convert.ToInt32(row.Cells[this.TaxColumnName].Value.ToString());
                        int rowMariginValue = Int32.Parse(row.Cells[this.MariginColumnName].Value.ToString());
                        string rowBarcodeValue = row.Cells[this.BarcodeColumnName].Value.ToString();
                        string rowSupplierCodeValue = row.Cells[this.SupplierCodeColumnName].Value.ToString();
                        int rowDiscountValue = Convert.ToInt32(row.Cells[this.DiscountColumnName].Value);
                        int rowQuantityValue = Convert.ToInt32(row.Cells[this.QuantityColumnName].Value);
                        float rowPriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscount(rowPriceNetValue, rowDiscountValue);

                        //If product name, barcode and supplier are unique, add it to DB
                        try
                        {
                            bool barcodeExist;
                            //Get from database if already exist
                            bool productNameExist = this.databaseCommands.CheckIfProductNameExist(rowProductNameValue);
                            bool elzabProductNameExist = this.databaseCommands.CheckIfElzabProductNameExist(rowElzabProductNameValue);
                            if (rowBarcodeValue == "") barcodeExist = false;
                            else barcodeExist = this.databaseCommands.CheckIfBarcodeExist(rowBarcodeValue);
                            bool supplierCodeExist = this.databaseCommands.CheckIfSupplierNameExist(rowSupplierCodeValue);
                            int elzabProductFirstFreeId = this.databaseCommands.CalculateFreeElzabId();
                            bool productForManufacturerExhausted = manufacturersWithExNumberOfProduct.Any(m => m == rowManufacturerNameValue);

                            if (!productNameExist && !barcodeExist && !supplierCodeExist && !elzabProductNameExist)
                            {
                                if (elzabProductFirstFreeId > 0)
                                {
                                    //Write all data to the Product object
                                    Product product = new Product();
                                    product.SupplierId = this.databaseCommands.GetSupplierIdByName(rowSupplierNameValue);
                                    product.ElzabProductId = elzabProductFirstFreeId;
                                    product.ManufacturerId = this.databaseCommands.GetManufacturerIdByName(rowManufacturerNameValue);
                                    product.ProductName = rowProductNameValue;
                                    product.ElzabProductName = rowElzabProductNameValue;
                                    product.PriceNet = rowPriceNetValue;
                                    product.TaxId = this.databaseCommands.GetTaxIdByValue(rowTaxValue);
                                    product.Marigin = rowMariginValue;
                                    product.BarCodeShort = BarcodeRelated.GenerateEan8(product.ManufacturerId, elzabProductFirstFreeId);
                                    product.Discount = rowDiscountValue;
                                    product.PriceNetWithDiscount = rowPriceNetWithDiscount;
                                    if (rowBarcodeValue == "") product.BarCode = product.BarCodeShort;
                                    else product.BarCode = rowBarcodeValue;
                                    product.ProductInfo = "Brak";
                                    product.FinalPrice = (float)Calculations.FinalPrice(Convert.ToDouble(rowPriceNetWithDiscount), rowTaxValue, Convert.ToDouble(rowMariginValue));
                                    if (rowSupplierCodeValue == "") product.SupplierCode = product.BarCode;
                                    else product.SupplierCode = rowSupplierCodeValue;

                                    //Add new object to the DB
                                    this.databaseCommands.AddNewProduct(product);

                                    //Add row to the collection of added rows, to remove it later
                                    rowCollectionToRemoveFromList.Add(row);

                                    //Add to the collection to add to stock
                                    if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                    //Set auxiliary bit
                                    if (savedSuccessfully == -1) savedSuccessfully = 1;
                                }
                                else if (!productForManufacturerExhausted)
                                {
                                    int numberOfProductPerManufacuturer = this.databaseCommands.GetManufacturerEntityByName(rowManufacturerNameValue)
                                                                          .MaxNumberOfProducts;
                                    DialogResult dialogResult = MessageBox.Show("Nie można określić numery produktu dla kasy Elzab! Dla producenta '"
                                        + rowManufacturerNameValue
                                        + "' zdefiniowano już " + numberOfProductPerManufacuturer + " produktów!"
                                        , "Liczba dostępnych numerów produtków Elzab została osiągnięta!");
                                    manufacturersWithExNumberOfProduct.Add(rowManufacturerNameValue);
                                    savedSuccessfully = 0;
                                }
                            }
                            else if (cbAllowOverrideProduct.Checked)
                            {
                                if (productNameExist)
                                {
                                    //Check if manufaturer match the one from file
                                    Product product = new Product();
                                    Manufacturer manufacturer = new Manufacturer();

                                    product = this.databaseCommands.GetProductEntityByProductName(rowProductNameValue);
                                    manufacturer = this.databaseCommands.GetManufacturerByProductName(product.ProductName);

                                    if (manufacturer.Name != rowManufacturerNameValue)
                                    {
                                        MessageBox.Show(string.Format("Nie można nadpisać produktu \"{0}\" (Lp = {1}), gdyż nazwa producenta jest inna! " +
                                            "Nazwa producenta z pliku: {2}; nazwa producenta w bazie danych: {3}", product.ProductName,
                                            row.Cells[this.IndexColumnName].Value.ToString(), rowManufacturerNameValue, manufacturer.Name));
                                    }
                                    else
                                    {
                                        product.SupplierId = this.databaseCommands.GetSupplierIdByName(rowSupplierNameValue);
                                        product.ElzabProductName = rowElzabProductNameValue;
                                        product.PriceNet = rowPriceNetValue;
                                        product.TaxId = this.databaseCommands.GetTaxIdByValue(rowTaxValue);
                                        product.Marigin = rowMariginValue;
                                        product.BarCodeShort = BarcodeRelated.GenerateEan8(product.ManufacturerId, product.ElzabProductId);
                                        product.Discount = rowDiscountValue;
                                        product.PriceNetWithDiscount = rowPriceNetWithDiscount;
                                        if (rowBarcodeValue != "") product.BarCode = rowBarcodeValue;
                                        product.FinalPrice = (float)Calculations.FinalPrice(Convert.ToDouble(rowPriceNetWithDiscount), rowTaxValue, Convert.ToDouble(rowMariginValue));
                                        if (rowSupplierCodeValue != "") product.SupplierCode = rowSupplierCodeValue;

                                        //Add new object to the DB
                                        this.databaseCommands.EditProduct(product);

                                        //Add row to the collection of added rows, to remove it later
                                        rowCollectionToRemoveFromList.Add(row);

                                        //Add to the collection to add to stock
                                        if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                        //Set auxiliary bit
                                        if (savedSuccessfully == -1) savedSuccessfully = 1;
                                    }
                                }
                                else if (barcodeExist)
                                {
                                    //Check if manufaturer match the one from file
                                    Product product = new Product();
                                    Manufacturer manufacturer = new Manufacturer();

                                    product = this.databaseCommands.GetProductEntityByBarcode(rowBarcodeValue);
                                    manufacturer = this.databaseCommands.GetManufacturerByProductName(product.ProductName);

                                    if (manufacturer.Name != rowManufacturerNameValue)
                                    {
                                        MessageBox.Show(string.Format("Nie można nadpisać produktu o kodzie kreskowym \"{0}\" (Lp = {1}), gdyż nazwa producenta jest inna! " +
                                            "Nazwa producenta z pliku: {2}; nazwa producenta w bazie danych: {3}", product.BarCode,
                                            row.Cells[this.IndexColumnName].Value.ToString(), rowManufacturerNameValue, manufacturer.Name));
                                    }
                                    else
                                    {
                                        product.SupplierId = this.databaseCommands.GetSupplierIdByName(rowSupplierNameValue);
                                        product.ElzabProductName = rowElzabProductNameValue;
                                        product.PriceNet = rowPriceNetValue;
                                        product.TaxId = this.databaseCommands.GetTaxIdByValue(rowTaxValue);
                                        product.Marigin = rowMariginValue;
                                        product.BarCodeShort = BarcodeRelated.GenerateEan8(product.ManufacturerId, product.ElzabProductId);
                                        product.Discount = rowDiscountValue;
                                        product.PriceNetWithDiscount = rowPriceNetWithDiscount;
                                        product.ProductName = rowProductNameValue;
                                        product.FinalPrice = (float)Calculations.FinalPrice(Convert.ToDouble(rowPriceNetWithDiscount), rowTaxValue, Convert.ToDouble(rowMariginValue));
                                        if (rowSupplierCodeValue != "") product.SupplierCode = rowSupplierCodeValue;

                                        //Add new object to the DB
                                        this.databaseCommands.EditProduct(product);

                                        //Add row to the collection of added rows, to remove it later
                                        rowCollectionToRemoveFromList.Add(row);

                                        //Add to the collection to add to stock
                                        if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                        //Set auxiliary bit
                                        if (savedSuccessfully == -1) savedSuccessfully = 1;
                                    }
                                }
                            }
                            else
                            {
                                if (productNameExist)
                                {

                                    //If qunatity value exist, add it to the stock
                                    //Add to the collection to add to stock
                                    if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                    if (rowCollectionToAdd.Count > 1 && !continueWithoutAskingProductNameExist)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Produkt o nazwie '" + rowProductNameValue +
                                            "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                            , "Pozycja istnieje w bazie danych!"
                                            , MessageBoxButtons.YesNoCancel);
                                        if (dialogResult == DialogResult.Yes) break;
                                        else if (dialogResult == DialogResult.Cancel) continueWithoutAskingProductNameExist = true;
                                    }
                                    //else MessageBox.Show("Produkt o nazwie '" + rowProductNameValue + "' już istnieje w bazie danych!");
                                }
                                else if (barcodeExist)
                                {
                                    //If qunatity value exist, add it to the stock
                                    //Add to the collection to add to stock
                                    if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                    if (rowCollectionToAdd.Count > 1 && !continueWithoutAskingBarcodeExist)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Kod kreskowy : '" + rowBarcodeValue +
                                            "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                            , "Pozycja istnieje w bazie danych!"
                                            , MessageBoxButtons.YesNoCancel);
                                        if (dialogResult == DialogResult.Yes) break;
                                        else if (dialogResult == DialogResult.Cancel) continueWithoutAskingBarcodeExist = true;
                                    }
                                    //else MessageBox.Show("Kod kreskowy : '" + rowBarcodeValue + "' już istnieje w bazie danych!");
                                }
                                else if (supplierCodeExist)
                                {
                                    //If qunatity value exist, add it to the stock
                                    //Add to the collection to add to stock
                                    if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                    if (rowCollectionToAdd.Count > 1 && !continueWithoutAskingSupplierCodeExist)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue +
                                            "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                            , "Pozycja istnieje w bazie danych!"
                                            , MessageBoxButtons.YesNoCancel);
                                        if (dialogResult == DialogResult.Yes) break;
                                        else if (dialogResult == DialogResult.Cancel) continueWithoutAskingSupplierCodeExist = true;
                                    }
                                    //else MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue + "' już istnieje w bazie danych!");
                                }
                                else if (elzabProductNameExist)
                                {
                                    //If qunatity value exist, add it to the stock
                                    //Add to the collection to add to stock
                                    if (rowQuantityValue > 0) rowCollectionToAddQuantityToStockList.Add(row);

                                    if (rowCollectionToAdd.Count > 1 && !continueWithoutAskingElzabProductNameExist)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Nazwa produktu '" + rowProductNameValue +
                                            "'dla kasy Elzab już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                            , "Pozycja istnieje w bazie danych!"
                                            , MessageBoxButtons.YesNoCancel);
                                        if (dialogResult == DialogResult.Yes) break;
                                        else if (dialogResult == DialogResult.Cancel) continueWithoutAskingElzabProductNameExist = true;
                                    }
                                    //else MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue + "' już istnieje w bazie danych!");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Debug.Fail(ex.ToString());
                            //Set auxiliary bit
                            savedSuccessfully = 0;
                        }
                    }
                    #endregion
                }

                //Show result message box
                if (savedSuccessfully == -1) MessageBox.Show("Produkt/produkty NIE zostały dodane do bazy danych!");
                else if (savedSuccessfully == 0 && rowCollectionToAdd.Count == 1) MessageBox.Show("Produkty NIE zostały dodane do bazy danych!");
                else if (savedSuccessfully == 0 && rowCollectionToAdd.Count > 1) MessageBox.Show("Przynajmniej jeden produkt NIE został dodane do bazy danych!");
                else if (savedSuccessfully == 1 && rowCollectionToAdd.Count == 1) MessageBox.Show("Produkt został pomyślnie dodane do bazy danych!");
                else if (savedSuccessfully == 1 && rowCollectionToAdd.Count > 1) MessageBox.Show("Wszystkie produkt został pomyślnie dodane do bazy danych!");
                else MessageBox.Show("Nieznany stan dodawania produktu do bazy danych!!");

            }

            //Add to stock from list
            if (rowCollectionToAddQuantityToStockList.Count > 0)
            {
                try
                {
                    foreach (DataGridViewRow element in rowCollectionToAddQuantityToStockList)
                    {

                        Stock stockPiece = new Stock();
                        //Add product to local stock variable
                        string productName = element.Cells[this.ProductColumnName].Value.ToString();
                        string productBarcode = element.Cells[this.BarcodeColumnName].Value.ToString();
                        stockPiece.ProductId = this.databaseCommands.GetProductIdByName(productName);

                        //If did not found product by name, try by barcode
                        if (stockPiece.ProductId == 0 && productBarcode != "")
                        {
                            stockPiece.ProductId = this.databaseCommands.GetProductIdByBarcode(productBarcode);
                        }

                        if(stockPiece.ProductId != 0)
                        {
                            bool productalreadyExistInStock = this.databaseCommands.CheckIfProductExistInStock(stockPiece);
                            if (productalreadyExistInStock)
                            {
                                Stock pieceFromStock = this.databaseCommands.GetStockEntityByUserStock(stockPiece);
                                int quantityInStock = this.databaseCommands.GetStockQuantity(stockPiece.ProductId);
                                pieceFromStock.ActualQuantity = quantityInStock + Int32.Parse(element.Cells[this.QuantityColumnName].Value.ToString());
                                pieceFromStock.LastQuantity = quantityInStock;
                                pieceFromStock.ModificationDate = DateTime.Now;
                                this.databaseCommands.EditInStock(pieceFromStock);

                            }
                            else
                            {
                                stockPiece.ActualQuantity = Int32.Parse(element.Cells[this.QuantityColumnName].Value.ToString());
                                stockPiece.LastQuantity = 0;
                                stockPiece.ModificationDate = DateTime.Now;
                                this.databaseCommands.AddToStock(stockPiece);
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Nie można dodać do magazynu produktu o nazwia {0} i kodzie kreskowym {1}, " +
                                "gdyż nie znaleziono takiego produktu w bacie danych!", productName, productBarcode));
                        }

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            if (rowCollectionToRemoveFromList.Count > 0)
            {
                foreach (DataGridViewRow row in rowCollectionToRemoveFromList)
                {
                    advancedDataGridView1.Rows.Remove(row);
                }
                advancedDataGridView1.Update();
            }

        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Parent.Show();
            this.Dispose();
        }
        #endregion

        #region Current window events
        private void AddNewProductFromExcel_KeyDown(object sender, KeyEventArgs e)
        {
            Control localControl = (Control)sender;

            if (e.KeyCode == Keys.Enter)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (e.KeyCode == Keys.Escape)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }
        }

        private void AddNewProductFromExcel_Load(object sender, EventArgs e)
        {

            this.tbMarigin.Text = 30.ToString();

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        #endregion

        #region Advanced Data Grid View Events
        //Event for advanced data grid view click
        private void advancedDataGridView1_Click(object sender, EventArgs e)
        {
            //Cast an object to a know type
            Zuby.ADGV.AdvancedDataGridView localSender = (Zuby.ADGV.AdvancedDataGridView)sender;
            if (localSender.DataSource != null)
            {
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

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
                int indexOfDiscount = localSender.Columns[this.DiscountColumnName].Index;
                int indexOfPriceNetWithDiscount = localSender.Columns[this.PriceNetWithDiscountColumnName].Index;

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

                //If discount changed, recalculate net price with discount
                if (cell.ColumnIndex == indexOfDiscount)
                {

                    float price = Convert.ToSingle(localSender.Rows[cell.RowIndex].Cells[indexOfPriceNet].Value);
                    int tax = Convert.ToInt32(localSender.Rows[cell.RowIndex].Cells[indexOfTax].Value);
                    int marigin = Convert.ToInt32(localSender.Rows[cell.RowIndex].Cells[indexOfMarigin].Value);
                    int discount = Convert.ToInt32(localSender.Rows[cell.RowIndex].Cells[indexOfDiscount].Value);
                    localSender.Rows[cell.RowIndex].Cells[indexOfPriceNetWithDiscount].Value = Calculations.CalculatePriceNetWithDiscount(price, discount).ToString();
                    localSender.Rows[cell.RowIndex].Cells[indexOfFinalPrice].Value = Calculations.FinalPrice(price, tax, marigin).ToString();
                }

                //If marigin has changed, recalculate final price
                if (cell.ColumnIndex == indexOfMarigin)
                {
                    double price = Convert.ToDouble(localSender.Rows[cell.RowIndex].Cells[indexOfPriceNetWithDiscount].Value);
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
        private void tbMarigin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Int32.Parse(tbMarigin.Text);
                if (Int32.Parse(tbMarigin.Text) < 0 || Int32.Parse(tbMarigin.Text) > 100) tbMarigin.Text = 30.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbMarigin.Text = 30.ToString();
            }
        }

        private void bChangeTaxAndPrice_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> productNamesList = new List<string>();
                productNamesList = this.databaseCommands.GetProductsNameListByManufacturer("Flos");
                this.databaseCommands.UpdateAllPriceNetWithDiscountValues(productNamesList);
                this.databaseCommands.UpdateAllFinalPrices(productNamesList);
                MessageBox.Show(string.Format("Koniec! Zmieniono {0} pozycji!", productNamesList.Count()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Method used to check if in given data table rows with multiple entries exist
        //It will return list of mulpiple entris contains Lp. Double entry Name
        private List<string> GetListOfMultipleEntries(DataTable data)
        {
            List<string> retList = new List<string>();
            List<string> listOfTheColumnsToCheckForMultipleEntries = new List<string> 
            { this.ProductColumnName, this.ElzabProductColumnName, this.BarcodeColumnName };

            List<DataRow> listOfDuplicates = new List<DataRow>();


            try
            {
                //Loop throught all data rows and find multile entires.
                foreach(string columName in listOfTheColumnsToCheckForMultipleEntries)
                {
                   foreach(DataRow row in data.Rows)
                   {
                        string currentValue = row.Field<string>(columName);
                        for (int i = data.Rows.IndexOf(row) +1;i<data.Rows.Count; i++)
                        {
                            string orgValue = data.Rows[i].Field<string>(columName);
                            
                            if (currentValue == orgValue)
                            {
                                //Check if row already on the list
                                if (!listOfDuplicates.Contains(row)) listOfDuplicates.Add(row);
                                if (!listOfDuplicates.Contains(data.Rows[i])) listOfDuplicates.Add(data.Rows[i]);
                            }
                        }
                    }

                    string lpList = "";
                    string cellValue = "";
                    //Build string list to return
                    foreach (DataRow row in listOfDuplicates)
                    {
                        List<DataRow> tempSameEntriesDataRows = listOfDuplicates.Where(e => e.Field<string>(columName) == row.Field<string>(columName)).ToList();

                        if (cellValue == "") cellValue = row.Field<string>(columName);
                        lpList += row.Field<string>(this.IndexColumnName).ToString() + ", ";

                        //If last element fom multiple etris of one element list, add it to the main list
                        if (row == tempSameEntriesDataRows.Last())
                        {
                            lpList = lpList.Remove(lpList.Length - 2, 2);

                            string textToDisplay = string.Format("Kolumna \"{0}\". Wartość komórki: \"{1}\"; Lp: \"{2}\".\n",
                                columName, cellValue, lpList);

                            retList.Add(textToDisplay);
                            lpList = "";
                            cellValue = "";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retList;
        }
    }
}
