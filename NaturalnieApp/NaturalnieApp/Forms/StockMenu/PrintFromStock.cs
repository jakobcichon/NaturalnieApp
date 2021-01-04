using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;


namespace NaturalnieApp.Forms
{

    public partial class PrintFromStock : Form
    {
        #region Object fields
        //Set the instance fields
        private DatabaseCommands databaseCommands { get; set; }

        //Backgroundworker
        private BackgroundWorker backgroundWorker1 { get; set; }
        private backgroundWorkerTasks ActualTaskType { get; set; }

        //Global variables
        private List<string> ManufacturersList { get; set; }

        //Auto complete string collections
        private AutoCompleteStringCollection ManufacturerListCollection { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.LabelDataSourceColumnNames ColumnNames;

        //Printer instance
        Printer DymoPrinter;
        bool CancelPrinting;


        #endregion

        #region Class constructor
        public PrintFromStock(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Background worker
            InitializeBackgroundWorker();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize globar variables
            this.ManufacturersList = new List<string>();

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.ProductId = "Id produktu";
            this.ColumnNames.LabelBarcode = "Kod kreskowy";
            this.ColumnNames.LabelFinalPrice = "Cena klienta";
            this.ColumnNames.LabelText = "Tekst etykiety";
            this.ColumnNames.NumberOfCopies = "Liczba kopii";
            this.DataSoruce = new DataTable();

            InitializeAdvancedDataGridView();

            //List of the product to print
            this.CancelPrinting = false;

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
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        returnList.Add(productManufacturerList);
                        e.Result = returnList;
                    }
                    break;
                case backgroundWorkerTasks.Update:
                    if (this.databaseCommands.ConnectionStatus)
                    {
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        returnList.Add(productManufacturerList);
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
                            FillWithInitialDataFromObject((List<string>)returnList[0]);
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject((List<string>)returnList[0]);
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
            int index = obj.FindString(textToFind);
            obj.SelectedIndex = index;

        }

        private void FillWithInitialDataFromObject(List<string> manufacturerList)
        {
            //Add fetched data to proper combo box
            this.ManufacturerListCollection = new AutoCompleteStringCollection();
            this.ManufacturersList = this.databaseCommands.GetManufacturersNameList();
            this.ManufacturerListCollection.AddRange(this.ManufacturersList.ToArray());
            this.cbManufacturers.AutoCompleteCustomSource = this.ManufacturerListCollection;
            this.cbManufacturers.Items.AddRange(this.ManufacturersList.ToArray());
        }

        private List<Product> GetListOfTheProductToPrintFromDataTable(DataTable data)
        {
            //Local variables
            List<Product> localList = new List<Product>();

            foreach (DataRow element in data.Rows)
            {
                //Get product entity
                int id = element.Field<int>(this.ColumnNames.ProductId);
                Product productEnt = this.databaseCommands.GetProductEntityById(id);
                localList.Add(productEnt);
            }

            return localList;

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
            column.ColumnName = this.ColumnNames.ProductId;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
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

        }
        private void AddToStock_KeyDown(object sender, KeyEventArgs e)
        {
            Control localControl = (Control)sender;

            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this, true, true, true, true);

            }
            else if (e.KeyCode == Keys.Escape)
            {
                localControl.SelectNextControl(this, true, true, true, true);
            }

        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bShow_Click(object sender, EventArgs e)
        {
            if (cbManufacturers.SelectedItem != null)
            {
                //Local variables
                List<Stock> stockList = new List<Stock>();
                Product productEnt = new Product();

                if(cbManufacturers.SelectedIndex == 0)
                {

                }
                else
                {
                    //Get from stock list of products of given manufacturer
                    int manufacturerId = this.databaseCommands.GetManufacturerIdByName(cbManufacturers.SelectedItem.ToString());
                    if (manufacturerId > 0)
                    {
                        //Cleardata
                        this.DataSoruce.Rows.Clear();

                        stockList = this.databaseCommands.GetStockEntsWithManufacturerId(manufacturerId);
                        
                        foreach (Stock element in stockList)
                        {
                            //Get product entity
                            productEnt = this.databaseCommands.GetProductEntityById(element.ProductId);

                            //Add data to table
                            DataRow rowElement;
                            rowElement = this.DataSoruce.NewRow();

                            //Set row fields
                            rowElement.SetField<string>(this.ColumnNames.No, (this.DataSoruce.Rows.Count + 1).ToString());
                            rowElement.SetField<int>(this.ColumnNames.ProductId, productEnt.Id);
                            rowElement.SetField<string>(this.ColumnNames.LabelBarcode, productEnt.BarCodeShort);
                            rowElement.SetField<string>(this.ColumnNames.LabelText, productEnt.ElzabProductName);
                            rowElement.SetField<string>(this.ColumnNames.LabelFinalPrice, string.Format("{0:0.00}", productEnt.FinalPrice));
                            rowElement.SetField<int>(this.ColumnNames.NumberOfCopies, element.ActualQuantity);

                            this.DataSoruce.Rows.Add(rowElement);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono producenta!");
                    }

                }


            }
            else
            {
                MessageBox.Show("Najpierw należy wybrać porducenta!");
            }
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

                    localList = GetListOfTheProductToPrintFromDataTable(this.DataSoruce);

                    List<Product> printingList = new List<Product>();

                    //Split it into 5
                    foreach (Product element in localList)
                    {

                        printingList.Add(element);
                        int indexOfElement = localList.IndexOf(element);

                        if ((printingList.Count == 10) || (indexOfElement == localList.Count-1))
                        {
                            //Print lables
                            this.DymoPrinter.PrintPriceCardsFromProductList(printingList);
                            printingList.Clear();
                        }
                        
                    }

                }
                catch (NoPrinterToSelect)
                {
                    MessageBox.Show("Nie można odnaleźć drukarki firmy Dymo. Podłącz drukarkę i spróbuj ponownie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Select next control
            this.SelectNextControl(this, true, true, true, true);

        }

        private void bClose_Click(object sender, EventArgs e)
        {

            this.Parent.Show();
            this.Dispose();
        }

        #endregion
 
    }
}
