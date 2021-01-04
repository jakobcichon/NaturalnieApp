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
        string IndexColumnName { get; set; }
        DataTable DataFromExcel { get; set; }
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

            this.LastExcelFilePath = "";
            this.databaseCommands = commandsObj;

            //Initialization of last cell clicked variable
            this.LastCellCliked = new[] { 0 , 0 };

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

                //Add default marigin value and calculate final price
                foreach (DataGridViewRow row in this.advancedDataGridView1.Rows)
                {
                    //Get all necessary indexes
                    int indexOfCurrentRow = this.advancedDataGridView1.Rows.IndexOf(row);
                    int indexOfMariginColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.MariginColumnName].ColumnIndex;
                    int indexOfFinalPriceColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.FinalPriceColumnName].ColumnIndex;
                    int indexOfTaxColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.TaxColumnName].ColumnIndex;
                    int indexOfPriceNetColumn = this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[this.PriceNetColumnName].ColumnIndex;

                    //Set amrigin to the default value
                    this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value = "29";

                    //Calculate final price
                    double price = Convert.ToDouble(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfPriceNetColumn].Value);
                    int tax = Convert.ToInt32(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfTaxColumn].Value);
                    int marigin = Convert.ToInt32(this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfMariginColumn].Value);
                    double finalPrice = Calculations.FinalPrice(price, tax, marigin);

                    this.advancedDataGridView1.Rows[indexOfCurrentRow].Cells[indexOfFinalPriceColumn].Value = finalPrice.ToString();

                }

                /*
                 * Export to excel TESTES!!!!!!!!!!!!!!!!!!!!
                List<string> test = new List<string>();
                foreach (DataColumn element in this.DataFromExcel.Columns)
                {
                    test.Add(element.ColumnName);
                }
                //Test purpose
                ExcelBase.ExportToExcel(this.DataFromExcel, @"D:\test.xlsb", test.ToArray()) ;
                */

                //Add checkbox to data grid
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                advancedDataGridView1.Columns.Insert(0, chk);
                chk.HeaderText = this.CheckBoxColumnName;
                chk.Name = this.CheckBoxColumnName;
                bDeselectAll.Visible = true;
                bSelectAll.Visible = true;

                advancedDataGridView1.Columns[1].CellTemplate.ValueType = Type.GetType("Int");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            advancedDataGridView1.Update();
            //Autosize columns
            advancedDataGridView1.AutoResizeColumns();
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

                    //Sepcific string action depending on column attribute
                    //Percentage
                    if (columnAttribute == ColumnsAttributes.Tax)
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
                if (!row.IsNewRow)
                {
                    DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                    chkchecking.Value = true;
                }
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

            //2. Validate all selected rows
            foreach (DataGridViewRow row in rowCollectionToAdd)
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
                        //Validate every entry 
                        Validation.SupplierNameValidation(row.Cells[this.SupplierColumnName].Value.ToString());
                        Validation.ManufacturerNameValidation(row.Cells[this.ManufacturerColumnName].Value.ToString());

                        //Check if given code is full barcode or oly product code without manufacturer prefix
                        barcodeCheckedVal = GetBarcodePrefixAndCreateFullBarcode(row.Cells[this.ManufacturerColumnName].Value.ToString(),
                            row.Cells[this.BarcodeColumnName].Value.ToString());

                        //Validate every entry 
                        Validation.SupplierNameValidation(row.Cells[this.SupplierColumnName].Value.ToString());
                        Validation.ManufacturerNameValidation(row.Cells[this.ManufacturerColumnName].Value.ToString());
                        Validation.ProductNameValidation(row.Cells[this.ProductColumnName].Value.ToString());
                        Validation.ElzabProductNameValidation(row.Cells[this.ElzabProductColumnName].Value.ToString());
                        Validation.MariginValueValidation(row.Cells[this.MariginColumnName].Value.ToString());
                        Validation.PriceNetValueValidation(row.Cells[this.PriceNetColumnName].Value.ToString());
                        Validation.TaxValueValidation(row.Cells[this.TaxColumnName].Value.ToString());
                        Validation.BarcodeEan13Validation(barcodeCheckedVal);
                        row.Cells[this.BarcodeColumnName].Value = barcodeCheckedVal;

                        //Set validated bit
                        validated = true;
                    }
                    catch (Validation.ValidatingFailed ex)
                    {
                        //Show message and exit
                        MessageBox.Show(ex.Message + " Numer Lp: " + row.Cells[this.IndexColumnName].Value.ToString()) ;
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

            //If validated property, go to the next steps
            if (validated)
            {
                //Local variable used to show if all data was saved successfully
                int savedSuccessfully = -1;

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
                                MessageBox.Show("Dostawca '" + rowSupplierNameValue +"' został dodany do bazy danych!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (dialogResult == DialogResult.No) MessageBox.Show("Anulowano zapis do bazy danych!");
                        else MessageBox.Show("Bład! Anulowano zapis do bazy danych!");
                    }
                    //Check if amnufacterer exist in DB
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
                        float rowMariginValue = float.Parse(row.Cells[this.MariginColumnName].Value.ToString());
                        string rowBarcodeValue = row.Cells[this.BarcodeColumnName].Value.ToString();
                        string rowSupplierCodeValue = row.Cells[this.SupplierCodeColumnName].Value.ToString();

                        //If product name, barcode and supplier are unique, add it to DB
                        try
                        {
                            //Get from database if already exist
                            bool productNameExist = this.databaseCommands.CheckIfProductNameExist(rowProductNameValue);
                            bool elzabProductNameExist = this.databaseCommands.CheckIfElzabProductNameExist(rowElzabProductNameValue);
                            bool barcodeExist = this.databaseCommands.CheckIfBarcodeExist(rowBarcodeValue);
                            bool supplierCodeExist = this.databaseCommands.CheckIfSupplierNameExist(rowSupplierCodeValue);
                            int elzabProductFirstFreeId = this.databaseCommands.CalculateFreeElzabIdForGivenManufacturer(rowManufacturerNameValue);

                            if (!productNameExist && !barcodeExist && !supplierCodeExist && !elzabProductNameExist && elzabProductFirstFreeId > 0)
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
                                product.BarCode = rowBarcodeValue;
                                product.BarCodeShort = BarcodeRelated.GenerateEan8(product.ManufacturerId, elzabProductFirstFreeId);
                                product.ProductInfo = "Brak";
                                product.FinalPrice = (float) Calculations.FinalPrice(Convert.ToDouble(rowPriceNetValue), rowTaxValue, Convert.ToDouble(rowMariginValue));
                                if (rowSupplierCodeValue == "") product.SupplierCode = product.BarCode;
                                else product.SupplierCode = rowSupplierCodeValue;

                                //Add new object to the DB
                                this.databaseCommands.AddNewProduct(product);

                                //Add row to the collection of added rows, to remo it later
                                rowCollectionToRemoveFromList.Add(row);

                                //Set auxiliary bit
                                if (savedSuccessfully == -1) savedSuccessfully = 1;

                            }
                            else if (productNameExist)
                            {
                                if (rowCollectionToAdd.Count > 1)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Produkt o nazwie '" + rowProductNameValue +
                                        "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                        , "Pozycja istnieje w bazie danych!"
                                        , MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes) break;
                                }
                                else MessageBox.Show("Produkt o nazwie '" + rowProductNameValue + "' już istnieje w bazie danych!");
                            }
                            else if (barcodeExist)
                            {
                                if (rowCollectionToAdd.Count > 1)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Kod kreskowy : '" + rowBarcodeValue +
                                        "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                        , "Pozycja istnieje w bazie danych!"
                                        , MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes) break;
                                }
                                else MessageBox.Show("Kod kreskowy : '" + rowBarcodeValue + "' już istnieje w bazie danych!");
                            }
                            else if (supplierCodeExist)
                            {
                                if (rowCollectionToAdd.Count > 1)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue +
                                        "' już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                        , "Pozycja istnieje w bazie danych!"
                                        , MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes) break;
                                }
                                else MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue + "' już istnieje w bazie danych!");
                            }
                            else if (elzabProductNameExist)
                            {
                                if (rowCollectionToAdd.Count > 1)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Nazwa produktu '" + rowProductNameValue +
                                        "'dla kasy Elzab już istnieje w bazie danych. Czy chesz przerwać dodawanie kolejnych produktów?"
                                        , "Pozycja istnieje w bazie danych!"
                                        , MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes) break;
                                }
                                else MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue + "' już istnieje w bazie danych!");
                            }
                            else if (elzabProductFirstFreeId <= 0)
                            {
                                if (rowCollectionToAdd.Count > 1)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Nie można określić numery produktu dla kasy Elzab! Dla producenta '"
                                        + rowManufacturerNameValue
                                        + "' zdefiniowano już 99 produktów!"
                                        , "Liczba dostępnych numerów produtków Elzab została osiągnięta!");
                                }
                                else MessageBox.Show("Numer dostawy : '" + rowSupplierCodeValue + "' już istnieje w bazie danych!");
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
