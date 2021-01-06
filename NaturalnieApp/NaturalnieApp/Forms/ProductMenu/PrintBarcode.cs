using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;


namespace NaturalnieApp.Forms
{

    public partial class PrintBarcode : Form
    {
        #region Object fields
        //Set the instance fields
        DatabaseCommands databaseCommands;

        //Backgroundworker
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;

        //Global variables
        List<string> ProductsList;
        List<string> ManufacturersList;
        List<string> BarcodesList;

        //Auto complete string collections
        AutoCompleteStringCollection ProductListCollection;
        AutoCompleteStringCollection ManufacturerListCollection;
        AutoCompleteStringCollection BarcodeListCollection;

        //Data source for advanced data grid view
        DataTable DataSoruce;
        DataSourceRelated.LabelDataSourceColumnNames ColumnNames;

        //List of the product to print
        List<Product> ListOfTheProductToPrint;

        //Printer instance
        Printer DymoPrinter;

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }

        #endregion

        #region Class constructor
        public PrintBarcode(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Background worker
            InitializeBackgroundWorker();
            this.databaseCommands = new DatabaseCommands();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize globar variables
            this.ProductsList = new List<string>();
            this.ManufacturersList = new List<string>();
            this.BarcodesList = new List<string>();

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.LabelBarcode = "Kod kreskowy";
            this.ColumnNames.LabelFinalPrice = "Cena klienta";
            this.ColumnNames.LabelText = "Tekst etykiety";
            this.ColumnNames.NumberOfCopies = "Liczba kopii";
            this.DataSoruce = new DataTable();
            InitializeAdvancedDataGridView();

            //List of the product to print
            ListOfTheProductToPrint = new List<Product>();

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;
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

        private void FillWithInitialDataFromObject(List<string> productList, List<string> manufacturerList, List<string> barcodeList)
        {
            //Add fetched data to proper combo box
            this.ProductListCollection = new AutoCompleteStringCollection();
            this.ProductsList = this.databaseCommands.GetProductsNameList();
            this.ProductListCollection.AddRange(this.ProductsList.ToArray());
            this.cbProductsList.AutoCompleteCustomSource = this.ProductListCollection;
            this.cbProductsList.Items.AddRange(this.ProductsList.ToArray());

            //Add fetched data to proper combo box
            this.ManufacturerListCollection = new AutoCompleteStringCollection();
            this.ManufacturersList = this.databaseCommands.GetManufacturersNameList();
            this.ManufacturerListCollection.AddRange(this.ManufacturersList.ToArray());
            this.cbManufacturers.AutoCompleteCustomSource = this.ManufacturerListCollection;
            this.cbManufacturers.Items.AddRange(this.ManufacturersList.ToArray());

            //Add fetched data to proper combo box
            this.BarcodeListCollection = new AutoCompleteStringCollection();
            this.BarcodesList = this.databaseCommands.GetBarcodeList();
            this.BarcodeListCollection.AddRange(this.BarcodesList.ToArray());
            this.cbBarcodes.AutoCompleteCustomSource = this.BarcodeListCollection;
            this.cbBarcodes.Items.AddRange(this.BarcodesList.ToArray());

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
            column.ColumnName = this.ColumnNames.LabelBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelText;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelFinalPrice;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfCopies;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSoruce;

            advancedDataGridView1.AutoResizeColumns();
        }
        private void AdvancedDataGridView1_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            this.ListOfTheProductToPrint.RemoveAt(e.Row.Index);
            ;
        }
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void PrintBarcode_Load(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void PrintBarcode_KeyDown(object sender, KeyEventArgs e)
        {
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
                    List<string> filteredBarcodes = this.databaseCommands.GetBarcodesListByManufacturer(cbManufacturers.SelectedItem.ToString());
                    cbBarcodes.Items.Clear();
                    cbBarcodes.Items.AddRange(filteredBarcodes.ToArray());

                }
                else
                {
                    //Fetch filtered information from database
                    List<string> productNames = this.databaseCommands.GetProductsNameList();
                    cbProductsList.Items.Clear();
                    cbProductsList.Items.AddRange(productNames.ToArray());
                    List<string> filteredBarcodes = this.databaseCommands.GetBarcodesListByManufacturer(cbManufacturers.SelectedItem.ToString());
                    cbBarcodes.Items.Clear();
                    cbBarcodes.Items.AddRange(filteredBarcodes.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Update control
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
                FindTextInComboBoxAndSelect(ref cbManufacturers, manufacturerName);
                FindTextInComboBoxAndSelect(ref cbBarcodes, barcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Update control
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //Update control
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
                        if (rowElement.Field<string>(this.ColumnNames.LabelText).Contains(entity.ElzabProductName))
                        {
                            indexOfExistingRow = this.DataSoruce.Rows.IndexOf(rowElement);
                            productAlreadyOnTheList = true;
                            break;
                        }
                    }

                    //Increment number of copies if product already exist on the list
                    if(productAlreadyOnTheList)
                    {
                        this.DataSoruce.Rows[indexOfExistingRow].SetField(this.ColumnNames.NumberOfCopies,
                            this.DataSoruce.Rows[indexOfExistingRow].Field<Int32>(this.ColumnNames.NumberOfCopies) + 1);
                    }
                    else
                    {
                        //New data row type
                        DataRow row;
                        row = this.DataSoruce.NewRow();

                        //Set requred fields
                        row.SetField(this.ColumnNames.No, this.DataSoruce.Rows.Count + 1);
                        row.SetField(this.ColumnNames.LabelBarcode, entity.BarCodeShort);
                        row.SetField(this.ColumnNames.LabelText, entity.ElzabProductName);
                        row.SetField(this.ColumnNames.LabelFinalPrice, string.Format("{0:0.00}", entity.FinalPrice));
                        row.SetField(this.ColumnNames.NumberOfCopies, 1.ToString());

                        //Assign values to the proper rows
                        this.DataSoruce.Rows.Add(row);

                        //Add entity to the list
                        this.ListOfTheProductToPrint.Add(entity);
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

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        private void bPrint_Click(object sender, EventArgs e)
        {
            if (this.DataSoruce.Rows.Count == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {
                //Get printer device
                try
                {
                    //Check if Dymo printer instance already created
                    if (this.DymoPrinter == null)
                    {
                        //Printer instance
                        this.DymoPrinter = new Printer(Program.GlobalVariables.LabelPath);
                    }

                    //Check if printer connected
                    this.DymoPrinter.GetPrinters();

                    //Local variables
                    List<Product> localList = new List<Product>();

                    //Loop through the list of the product to print and create temporary list contains elements multiple by number of copies
                    foreach (Product element in this.ListOfTheProductToPrint)
                    {
                        //Get number of copies from data grid view
                        int index = this.ListOfTheProductToPrint.IndexOf(element);
                        int numberOfCopies = this.DataSoruce.Rows[index].Field<Int32>(this.ColumnNames.NumberOfCopies);

                        for (int i = 1; i <= numberOfCopies; i++)
                        {
                            localList.Add(element);
                        }
                    }

                    //Print lables
                    this.DymoPrinter.PrintPriceCardsFromProductList(localList);

                }
                catch (NoPrinterToSelect)
                {
                    MessageBox.Show("Nie można odnaleźć drukarki firmy Dymo. Podłącz drukarkę i spróbuj ponownie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

        }
        private void bClose_Click(object sender, EventArgs e)
        {

            this.Parent.Show();
            this.Dispose();
            ;
        }

        #endregion


    }
}
