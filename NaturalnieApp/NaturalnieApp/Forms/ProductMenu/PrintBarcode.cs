using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;

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
        List<string> BarcodeList;

        AutoCompleteStringCollection ProductListCollection;
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
            this.BarcodeList = new List<string>();
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
        private void FillWithInitialDataFromObject(List<string> productList, List<string> manufacturerList, List<string> barcodeList)
        {
            //Add fetched data to proper combo box
            this.ProductListCollection = new AutoCompleteStringCollection();
            this.ProductsList = this.databaseCommands.GetProductsNameList();
            this.ProductListCollection.AddRange(this.ProductsList.ToArray());
            this.tbProducts.AutoCompleteCustomSource = this.ProductListCollection;
            ;
            /*
            cbProductList.Items.AddRange(productList.ToArray());
            cbManufacturer.Items.Clear();
            cbManufacturer.Items.Add("Wszyscy");
            cbManufacturer.Items.AddRange(manufacturerList.ToArray());
            cbSupplierName.Items.Clear();
            cbSupplierName.Items.AddRange(supplierList.ToArray());
            cbTax.Items.Clear();
            cbTax.Items.AddRange(this.databaseCommands.GetTaxListRetString().ToArray());
            */
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
    }
}
