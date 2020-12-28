using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;

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

        AutoCompleteStringCollection ProductListCollection;
        AutoCompleteStringCollection ManufacturerListCollection;
        AutoCompleteStringCollection BarcodeListCollection;
        #endregion

        #region Class constructor
        public PrintBarcode(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = new DatabaseCommands();

            //Background worker
            InitializeBackgroundWorker();
            this.databaseCommands = new DatabaseCommands();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize globar variables
            this.ProductsList = new List<string>();
            this.ManufacturersList = new List<string>();
            this.BarcodesList = new List<string>();

            //Initialize daa grid view
            InitializeAdvancedDataGridView();
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
            int index = obj.FindString(textToFind);
            obj.SelectedIndex = index;

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
            //Add checkbox to data grid
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            advancedDataGridView1.Columns.Insert(0, chk);
            chk.HeaderText = "Zaznacz";
            chk.Name = "CheckBox";

            //Add numering column to the data grid
            string HeaderText = "Lp.";
            string Name = "NumeringColumn";
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            //Add barcode column to the data grid
            HeaderText = "Kod kreskowy";
            Name = "Barcode";
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            //Add label text to the data grid
            HeaderText = "Tekst etykiety";
            Name = "LabelText";
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            //Add final price to the data grid
            HeaderText = "Cena klienta";
            Name = "FinalPrice";
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            //Add number of copies to the data grid
            HeaderText = "Liczba kopii";
            Name = "NumberOfCopies";
            advancedDataGridView1.Columns.Add(Name, HeaderText);

            advancedDataGridView1.AutoResizeColumns();
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
        }
        private void PrintBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Control localControl = (Control)sender;
                localControl.Controls.Remove(this.ActiveControl);
            }
        }
        #endregion

        //====================================================================================================
        //Manufacturer  events
        #region Manufacturer  events
        private void cbManufacturers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cbManufacturers.SelectedIndex != 0)
                {

                    cbProductsList.SelectedItem = null;
                    cbProductsList.Text = null;
                    cbBarcodes.SelectedItem = null;
                    cbBarcodes.Text = null;

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

                    cbProductsList.SelectedItem = null;
                    cbProductsList.Text = null;
                    cbBarcodes.SelectedItem = null;
                    cbBarcodes.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //====================================================================================================
        //Product List events
        #region Product List events
        private void cbProductsList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            //Local variables
            string manufacturerName = "";
            string barcode = "";

            //Get selected entity
            try
            {
                manufacturerName = this.databaseCommands.GetManufacturerByProductName(localSender.SelectedItem.ToString()).Name;
                barcode = this.databaseCommands.GetProductEntityByProductName(localSender.SelectedItem.ToString()).BarCode;
                FindTextInComboBoxAndSelect(ref cbManufacturers, manufacturerName);
                FindTextInComboBoxAndSelect(ref cbBarcodes, barcode);

                this.ActiveControl = this.bAdd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //====================================================================================================
        //Product List events
        #region Barcode events
        private void cbBarcodes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            //Local variables
            string manufacturerName = "";
            string productName = "";

            //Get selected entity
            try
            {
                productName = this.databaseCommands.GetProductEntityByBarcode(localSender.SelectedItem.ToString()).ProductName;
                manufacturerName = this.databaseCommands.GetManufacturerByProductName(productName).Name;
                FindTextInComboBoxAndSelect(ref cbManufacturers, manufacturerName);
                FindTextInComboBoxAndSelect(ref cbProductsList, productName);

                this.ActiveControl = this.bAdd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void bAdd_Click(object sender, EventArgs e)
        {
            //Local variables
            Product entity;
            DataTable data = new DataTable();
            DataGridViewRow row = new DataGridViewRow();
            

            if (cbBarcodes.SelectedItem != null && cbProductsList.SelectedItem != null)
            {
                try
                {
                    //Get product entity from DB
                    entity = this.databaseCommands.GetProductEntityByProductName(cbProductsList.SelectedItem.ToString());

                    //Assign values to the proper rows
                    advancedDataGridView1.Rows.Insert()
                    advancedDataGridView1.Rows[advancedDataGridView1.Rows.Count - 1].Cells[1].Value = advancedDataGridView1.Rows.Count;
                    advancedDataGridView1.Update();

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
        }
    }
}
