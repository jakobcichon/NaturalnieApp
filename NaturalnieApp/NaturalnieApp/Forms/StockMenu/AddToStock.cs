using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;
using System.Diagnostics;

namespace NaturalnieApp.Forms
{

    public partial class AddToStock : Form
    {
        #region Object fields
        //Set the instance fields
        private DatabaseCommands databaseCommands { get; set; }

        //Backgroundworker
        private BackgroundWorker backgroundWorker1 { get; set; }
        private backgroundWorkerTasks ActualTaskType { get; set; }

        //Global variables
        private List<string> ProductsList { get; set; }
        private List<string> ManufacturersList { get; set; }
        private List<string> BarcodesList { get; set; }
        private string SelectedProductName { get; set; }

        private Product ProductEntity { get; set; }
        private Tax TaxEntity { get; set; }
        private Stock StockEntity { get; set; }

        //Marigin related
        private int LastValidValueOfMarigin { get; set; }
        private int MariginValueToChangeTo { get; set; }

        //Auto complete string collections
        private AutoCompleteStringCollection ProductListCollection { get; set; }
        private AutoCompleteStringCollection ManufacturerListCollection { get; set; }
        private AutoCompleteStringCollection BarcodeListCollection { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.AddToStockDataSourceColumnNames ColumnNames;

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }
        #endregion

        #region Class constructor
        public AddToStock(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Background worker
            InitializeBackgroundWorker();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize globar variables
            this.ProductsList = new List<string>();
            this.ManufacturersList = new List<string>();
            this.BarcodesList = new List<string>();

            //Check current date
            this.dtpDateOfAccept.Value = DateTime.Now;
            this.dtpExpirationDate.Value = DateTime.Now.AddMonths(3);
            this.pExpirationDate.Hide();

            //Number of products
            this.tbQuantity.Text = "1";

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.AddDate = "Data dodania";
            this.ColumnNames.NumberOfPieces = "Liczba produktów";
            this.ColumnNames.ExpirenceDate = "Data ważności";
            this.DataSoruce = new DataTable();

            InitializeAdvancedDataGridView();

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;


            //Marigin modification
            this.LastValidValueOfMarigin = 30;
            this.MariginValueToChangeTo = this.LastValidValueOfMarigin;
            this.tbMarigin.Text = this.LastValidValueOfMarigin.ToString();
        }
        #endregion

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.backgroundWorker1 = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // this event will define what the worker will do when finished
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        // This event handler is where the actual, potentially time-consuming work is done.
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Local vaiable
            backgroundWorkerTasks taskType;
            taskType = this.ActualTaskType;
            List<List<string>> returnList = new List<List<string>>();

            //check if Database reachable 
            this.databaseCommands.CheckConnection(true);

            //Do action depending of task type
            switch (taskType)
            {
                case backgroundWorkerTasks.Init:
                    if (this.databaseCommands.ConnectionStatus)
                    {
                        List<string> productNameList = this.databaseCommands.GetProductsNameList();
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        List<string> barcodeList = this.databaseCommands.GetBarcodeList();
                        returnList.Add(productNameList);
                        returnList.Add(productManufacturerList);
                        returnList.Add(barcodeList);
                        e.Result = returnList;
                    }
                    break;
                case backgroundWorkerTasks.Update:
                    if (this.databaseCommands.ConnectionStatus)
                    {
                        List<string> productNameList = this.databaseCommands.GetProductsNameList();
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        List<string> barcodeList = this.databaseCommands.GetBarcodeList();
                        returnList.Add(productNameList);
                        returnList.Add(productManufacturerList);
                        returnList.Add(barcodeList);
                        e.Result = returnList;
                    }
                    break;
            }
        }

        // This event handler is where the actual, potentially time-consuming work is done.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Local vaiable
            backgroundWorkerTasks taskType;
            taskType = this.ActualTaskType;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                //Do action depending of task type
                switch (taskType)
                {
                    case backgroundWorkerTasks.Init:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject((List<string>)returnList[0], returnList[1], returnList[2]);
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject((List<string>)returnList[0], returnList[1], returnList[2]);
                            if (this.SelectedProductName != null)
                            {
                                this.cbProductsList.SelectedItem = this.SelectedProductName;
                            }
                        }
                        break;
                }

                //Enable panel after work done
                if (this.databaseCommands.ConnectionStatus) this.Enabled = true;


                this.Focus();
                this.Activate();
            }
        }
        //=============================================================================
        #endregion
        //====================================================================================================
        //General methods
        #region General methods
        //Metchod use to find and select string in ComboBox
        private void FindTextInComboBoxAndSelect(ref ComboBox obj, string textToFind)
        {
            //Find search tex index
            int index = obj.FindStringExact(textToFind);
            obj.SelectedIndex = index;
            ;

        }
        private void FillWithInitialDataFromObject(List<string> productList, List<string> manufacturerList, List<string> barcodeList)
        {
            //Add fetched data to proper combo box
            this.ProductListCollection = new AutoCompleteStringCollection();
            this.ProductsList = this.databaseCommands.GetProductsNameList();
            this.ProductListCollection.Clear();
            this.ProductListCollection.AddRange(this.ProductsList.ToArray());
            this.cbProductsList.AutoCompleteCustomSource = this.ProductListCollection;
            this.cbProductsList.Items.Clear();
            this.cbProductsList.Items.AddRange(this.ProductsList.ToArray());

            //Add fetched data to proper combo box
            this.ManufacturerListCollection = new AutoCompleteStringCollection();
            this.ManufacturersList = this.databaseCommands.GetManufacturersNameList();
            this.ManufacturerListCollection.Clear();
            this.ManufacturerListCollection.AddRange(this.ManufacturersList.ToArray());
            this.cbManufacturers.AutoCompleteCustomSource = this.ManufacturerListCollection;
            this.cbManufacturers.Items.Clear();
            this.cbManufacturers.Items.AddRange(this.ManufacturersList.ToArray());

            //Add fetched data to proper combo box
            this.BarcodeListCollection = new AutoCompleteStringCollection();
            this.BarcodesList = this.databaseCommands.GetBarcodeList();
            this.BarcodeListCollection.Clear();
            this.BarcodeListCollection.AddRange(this.BarcodesList.ToArray());
            this.cbBarcodes.AutoCompleteCustomSource = this.BarcodeListCollection;
            this.cbBarcodes.Items.Clear();
            this.cbBarcodes.Items.AddRange(this.BarcodesList.ToArray());

        }
        //Methos used to update control
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

        //Method used to clear all object (text box, combo box, etc.)  data
        private void ClearAllObjectsData()
        {
            //Supplier name
            this.cbManufacturers.Items.Clear();

            //Elzab product number
            this.cbProductsList.Items.Clear();
            this.cbBarcodes.Items.Clear();
            this.tbFinalPrice.Text = "";
            this.tbMarigin.Text = "";
            this.tbActualQuantity.Text = "";
        }
        private void FillWithDataFromObject(Product p, Tax t)
        {
            FindTextInComboBoxAndSelect(ref this.cbProductsList, p.ProductName);
            FindTextInComboBoxAndSelect(ref this.cbBarcodes, p.BarCode);

            //Elzab product number
            this.tbMarigin.Text = p.Marigin.ToString();
            this.tbFinalPrice.Text = string.Format("{0:0.00}", p.FinalPrice.ToString());
        }

        //Method used to update final price value
        private void UpdateFinalPrice()
        {
            //Update Final price
            this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                Convert.ToInt32(this.TaxEntity.TaxValue));

            //Show updated value
            this.tbFinalPrice.Text = string.Format("{0:0.00}", this.ProductEntity.FinalPrice.ToString());
        }
        #endregion
        //====================================================================================================
        //Advanced data gid view
        #region Advanced data gid view

        /// <summary>
        /// Method used to initialize advanced data grid view
        /// </summary>
        private void InitializeAdvancedDataGridView()
        {
            //Create data source columns
            DataColumn column = new DataColumn();

            column.ColumnName = this.ColumnNames.No;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.AddDate;
            column.DataType = Type.GetType("System.DateTime");
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfPieces;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ExpirenceDate;
            column.DataType = Type.GetType("System.DateTime");
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSoruce;

            advancedDataGridView1.AutoResizeColumns();
        }
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void AddToStock_Load(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);

            this.dtpDateOfAccept.Value = DateTime.Now;
            this.dtpExpirationDate.Value = DateTime.Now.AddMonths(3);

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        private void AddToStock_KeyDown(object sender, KeyEventArgs e)
        {
            Control localControl = (Control)sender;

            this.BarcodeValidEventGenerated = false;
            this.BarcodeReader.CheckIfBarcodeFromReader(e.KeyCode);

            if (e.KeyCode == Keys.Enter && !this.BarcodeValidEventGenerated)
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
        /*
        private void AddToStock_Paint(object sender, PaintEventArgs e)
        {
            this.SelectNextControl(this, true, true, true, true);
        }
        */
        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {
            if (e.Ready && e.Valid)
            {
                string barcodeToSearch;
                //If short barcode try to get full barcode
                if (e.RecognizedBarcodeValue.Length == 8)
                {
                    barcodeToSearch = this.databaseCommands.GetEAN13FromShortBarcode(e.RecognizedBarcodeValue);
                    if (barcodeToSearch == "" || barcodeToSearch == null) barcodeToSearch = e.RecognizedBarcodeValue;
                }
                else barcodeToSearch = e.RecognizedBarcodeValue;

                //Get index
                int index = this.cbBarcodes.Items.IndexOf(barcodeToSearch);
                if (index >= 0)
                {
                    this.cbBarcodes.SelectedIndex = index;
                    this.cbBarcodes_SelectedIndexChanged(this.cbBarcodes, EventArgs.Empty);
                }
                else MessageBox.Show("Brak kodu '" + e.RecognizedBarcodeValue + "' na liście kodów kreskowych");
            }

            //Set variable informing Bar code read corrected
            this.BarcodeValidEventGenerated = true;
        }
        #endregion
        //====================================================================================================
        //Manufacturer  events
        #region Manufacturer  events
        private void cbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbManufacturers.SelectedIndex != 0)
                {

                    //Fetch filtered information from database
                    List<string> filteredProductNames = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturers.SelectedItem.ToString());
                    cbProductsList.Items.Clear();
                    cbProductsList.Items.AddRange(filteredProductNames.ToArray());
                }
                else
                {
                    //Fetch filtered information from database
                    List<string> productNames = this.databaseCommands.GetProductsNameList();
                    cbProductsList.Items.Clear();
                    cbProductsList.Items.AddRange(productNames.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateControl(ref tbDummyForCtrl);
        }
        #endregion
        //====================================================================================================
        //Product List events
        #region Product List events
        private void cbProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            //Local variables
            string manufacturerName;
            string barcode;


            //Get selected entity
            try
            {
                manufacturerName = this.databaseCommands.GetManufacturerByProductName(localSender.SelectedItem.ToString()).Name;
                barcode = this.databaseCommands.GetProductEntityByProductName(localSender.SelectedItem.ToString()).BarCode;


                this.ProductEntity = this.databaseCommands.GetProductEntityByProductName(this.cbProductsList.SelectedItem.ToString());
                this.TaxEntity = this.databaseCommands.GetTaxByProductName(this.ProductEntity.ProductName);
                this.FillWithDataFromObject(this.ProductEntity, this.TaxEntity);
                UpdateFinalPrice();

                tbFinalPrice.Text = this.ProductEntity.FinalPrice.ToString();
                tbActualQuantity.Text = this.databaseCommands.GetStockQuantity(
                        this.databaseCommands.GetProductIdByName(this.ProductEntity.ProductName)).ToString();

                FindTextInComboBoxAndSelect(ref cbManufacturers, manufacturerName);
                FindTextInComboBoxAndSelect(ref cbBarcodes, barcode);

                //Update calss field
                this.SelectedProductName = localSender.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //====================================================================================================
        //MArigin events
        #region Marigin events
        private void tbMarigin_Validating(object sender, CancelEventArgs e)
        {
            //Cast an object
            TextBox localSender = (TextBox)sender;

            try
            {
                if (this.cbProductsList.SelectedItem != null)
                {
                    int value;
                    //Try parse input value
                    value = Int32.Parse(localSender.Text);
                    if (value > 0 && value <= 100)
                    {
                        this.LastValidValueOfMarigin = this.MariginValueToChangeTo;
                        this.MariginValueToChangeTo = value;
                        this.ProductEntity.Marigin = this.MariginValueToChangeTo;
                        UpdateFinalPrice();
                    }
                    else localSender.Text = this.LastValidValueOfMarigin.ToString();
                }
                else
                {
                    MessageBox.Show("Nie wybrano produktu do zmiany marży!");
                }
            }
            catch (FormatException ex)
            {
                localSender.Text = this.LastValidValueOfMarigin.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bMariginChange_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.cbProductsList.SelectedItem != null)
                {
                    //Get current selected entity
                    Product entity = this.databaseCommands.GetProductEntityByProductName(this.cbProductsList.SelectedItem.ToString());

                    //Check if marigin value has changed
                    if (entity.Marigin != this.MariginValueToChangeTo)
                    {
                        //Change Marigin in DB
                        entity.Marigin = this.MariginValueToChangeTo;
                        entity.FinalPrice = this.ProductEntity.FinalPrice;
                        this.databaseCommands.EditProduct(entity);
                        MessageBox.Show("Udało się zmodyfikować wartość marży!:)");

                        //Update view
                        this.ActualTaskType = backgroundWorkerTasks.Update;
                        this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Update);

                        bUpdate_Click(sender, EventArgs.Empty);
                    }
                    else
                    {
                        //Show message box
                        MessageBox.Show("Wprowadzona marża jest taka sama jak wprowadzoan w bazie danych. Nie dokonano modyfikacji");
                    }
                }
                else
                {
                    MessageBox.Show("Nie wybrano produktu do zmiany marży!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateControl(ref tbDummyForCtrl);

        }
        #endregion
        //====================================================================================================
        //Product List events
        #region Barcode events
        private void cbBarcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            //Local variables
            string manufacturerName;
            string productName;

            //Get selected entity
            try
            {
                productName = this.databaseCommands.GetProductEntityByBarcode(localSender.SelectedItem.ToString()).ProductName;
                manufacturerName = this.databaseCommands.GetManufacturerByProductName(productName).Name;
                FindTextInComboBoxAndSelect(ref cbManufacturers, manufacturerName);
                FindTextInComboBoxAndSelect(ref cbProductsList, productName);

                this.ProductEntity = this.databaseCommands.GetProductEntityByProductName(this.cbProductsList.SelectedItem.ToString());
                this.TaxEntity = this.databaseCommands.GetTaxByProductName(this.ProductEntity.ProductName);
                this.FillWithDataFromObject(this.ProductEntity, this.TaxEntity);
                UpdateFinalPrice();

                tbFinalPrice.Text = this.ProductEntity.FinalPrice.ToString(); 
                tbActualQuantity.Text = this.databaseCommands.GetStockQuantity(
                        this.databaseCommands.GetProductIdByName(this.ProductEntity.ProductName)).ToString();

                if (cbAddWithEveryScanCycle.Checked)
                {
                    bAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateControl(ref tbDummyForCtrl);
        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bAdd_Click(object sender, EventArgs e)
        {
            //Local variables
            Product entity;

            if (cbBarcodes.SelectedItem != null && cbProductsList.SelectedItem != null)
            {
                try
                {
                    //Get product entity from DB
                    entity = this.databaseCommands.GetProductEntityByProductName(cbProductsList.SelectedItem.ToString());

                    //Index of existing row
                    int indexOfExistingRow = -1;
                    bool productAlreadyOnTheList = false;

                    //Check if product already exist on list
                    foreach (DataRow rowElement in this.DataSoruce.Rows)
                    {
                        string productName = rowElement.Field<string>(this.ColumnNames.ProductName);
                        if (productName.Contains(entity.ProductName))
                        {
                            indexOfExistingRow = this.DataSoruce.Rows.IndexOf(rowElement);
                            productAlreadyOnTheList = true;
                            break;
                        }
                    }

                    //Increment number of copies if product already exist on the list
                    if (productAlreadyOnTheList)
                    {
                        this.DataSoruce.Rows[indexOfExistingRow].SetField(this.ColumnNames.NumberOfPieces,
                            this.DataSoruce.Rows[indexOfExistingRow].Field<Int32>(this.ColumnNames.NumberOfPieces) + 1);
                    }
                    else
                    {
                        //New data row type
                        DataRow row;
                        row = this.DataSoruce.NewRow();

                        //Set requred fields
                        row.SetField(this.ColumnNames.ProductName, entity.ProductName);
                        row.SetField(this.ColumnNames.AddDate, this.dtpDateOfAccept.Value.Date);
                        row.SetField(this.ColumnNames.NumberOfPieces, Convert.ToInt32(this.tbQuantity.Text));
                        if (this.chbExpDateReq.Checked) row.SetField(this.ColumnNames.ExpirenceDate, this.dtpExpirationDate.Value.Date);
                        else row.SetField(this.ColumnNames.ExpirenceDate, DateTime.MinValue);

                        //Assign values to the proper rows
                        this.DataSoruce.Rows.Add(row);

                    }

                    //AutoResize Columns
                    advancedDataGridView1.AutoResizeColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Żaden produkt nie został wybrany! Nie mozna było dodać produktu do listy!");
            }

            //Select next control
            UpdateControl(ref tbDummyForCtrl);
        }

        private void bClose_Click(object sender, EventArgs e)
        {

            this.Parent.Show();
            this.Dispose();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            //Local variables
            Stock stockPiece = new Stock();

            if (this.DataSoruce.Rows.Count == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {

                //Local list of the element to remove from data grid view
                List<DataRow> rowsToRemove = new List<DataRow>();

                //Loop throught all elements and add it to DB
                foreach (DataRow element in this.DataSoruce.Rows)
                {
                    try
                    {
                        //Add product to local stock variable
                        stockPiece.ProductId = this.databaseCommands.GetProductIdByName(element.Field<string>(this.ColumnNames.ProductName));
                        stockPiece.ActualQuantity = element.Field<int>(this.ColumnNames.NumberOfPieces);
                        stockPiece.ModificationDate = element.Field<DateTime>(this.ColumnNames.AddDate).Date;
                        DateTime expirenceDate = element.Field<DateTime>(this.ColumnNames.ExpirenceDate);

                        //Need to implement for product with date
                        stockPiece.BarcodeWithDate = null;

                        if (element.Field<DateTime>(this.ColumnNames.ExpirenceDate) != DateTime.MinValue)
                        {
                            stockPiece.ExpirationDate = element.Field<DateTime>(this.ColumnNames.ExpirenceDate).Date;
                        }

                        //Check if product already exist in stock. If no add it. If yes, increment quantity
                        bool checkResult = this.databaseCommands.CheckIfProductExistInStock(stockPiece);
                        if (checkResult)
                        {
                            Stock localStock = this.databaseCommands.GetStockEntityByUserStock(stockPiece);
                            int localQuantity = stockPiece.ActualQuantity;
                            localStock.ActualQuantity += localQuantity;
                            this.databaseCommands.EditInStock(localStock);
                        }
                        else
                        {
                            this.databaseCommands.AddToStock(stockPiece);
                        }

                        //Add row to the remove list
                        rowsToRemove.Add(element);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                                    
                }

                //Show message
                if (rowsToRemove.Count == this.DataSoruce.Rows.Count) MessageBox.Show("Wszystkie produkty zostały dodane do bazy danych!");
                else if (rowsToRemove.Count > 0) MessageBox.Show("Nie wszystkie produkty zostały dodane do bazy danych");

                //Remove added rows from data source
                foreach (DataRow element in rowsToRemove)
                {
                    this.DataSoruce.Rows.Remove(element);
                }

                UpdateControl(ref tbDummyForCtrl);

                bUpdate_Click(sender, EventArgs.Empty);
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            //Get current product name if was chosen
            if (this.SelectedProductName != null)
            {
                if (this.cbProductsList.SelectedItem != null)
                {
                    this.SelectedProductName = this.cbProductsList.SelectedItem.ToString();
                }
                else
                {
                    this.SelectedProductName = null;
                }
            }

            cbAddWithEveryScanCycle.Checked = false;

            //Clear all data from current form
            ClearAllObjectsData();

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Update;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Update);
        }
        private void chbExpDateReq_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox localSender = (CheckBox)sender;
            if (localSender.Checked) this.pExpirationDate.Show();
            else this.pExpirationDate.Hide();

            UpdateControl(ref tbDummyForCtrl);
        }


        #endregion


    }
}
