﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Database;

namespace NaturalnieApp.Forms.Common
{
    public partial class SearchBarTemplate : UserControl
    {
        //DB events Args
        public class CompleteProductDataFromDatabase
        {
            //Dictionary for products list <key = manufacturerId, value = product name>
            public Dictionary<string, int> ProductsDict { get; set; }
            //Dictionary for manufacturers list <key = manufacturerId, value = manufacturer name>
            public Dictionary<string, int> ManufacturersDict { get; set; }
            //Dictionary for barcodes list <key = manufacturerId, value = barcode>
            public Dictionary<string, int> BarcodesDict { get; set; }
        }

        //Private fields        
        private Manufacturer ManufacturerEntity { get; set; }
        private Product ProductEntity { get; set; }
        private Tax TaxEntity { get; set; }

        private Dictionary<string, int> FullManufacturersDict { get; set; }
        private Dictionary<string, int> FullProductsDict { get; set; }
        private Dictionary<string, int> FullBarcodesDict { get; set; }

        //Dictionary for product list <key = manufacturerId, value = product name>
        private Dictionary<string, int> ManufacturersToDisplayDict { get; set; }
        private Dictionary<string, int> ProductsToDisplayDict { get; set; }
        private Dictionary<string, int> BarcodesToDisplayDict { get; set; }

        //Add auxiliary variables to check if selected new index of combo box
        private string PreviouslySelectedManufacturer { get; set; }
        private string PreviouslySelectedProduct { get; set; }
        private string PreviouslySelectedBarcode { get; set; }

        //Database context
        DatabaseCommands DatabaseCommands;

        //Backgound worker for connection to db
        BackgroundWorker DbBackgroundWorker;

        public SearchBarTemplate()
        {
            //Initialize component
            InitializeComponent();

            //Initialize database commands
            this.DatabaseCommands = new DatabaseCommands();

            //Initialize background worker
            InitializeBackgroundWorker();

            //Initialize auxiliary variables
            this.PreviouslySelectedManufacturer = "";
            this.PreviouslySelectedProduct = "";
            this.PreviouslySelectedBarcode = "";

        }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.DbBackgroundWorker = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.DbBackgroundWorker.DoWork += DbBackgroundWorker_DoWork;
            // this event will define what the worker will do when finished
            this.DbBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DbBackgroundWorker_RunWorkerCompleted);
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        void DbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { 

            try
            {
                CompleteProductDataFromDatabase productData = new CompleteProductDataFromDatabase();
                productData.ManufacturersDict = new Dictionary<string, int>();
                productData.ProductsDict = new Dictionary<string, int>();
                productData.BarcodesDict = new Dictionary<string, int>();

                //Get list of product and manufacurers ents
                List<Product> productsList = this.DatabaseCommands.GetAllProductsEnts();
                List<Manufacturer> manufacturersList = this.DatabaseCommands.GetAllManufacturersEnts();

                //Assigne product data from DB to dictionares
                foreach (Product product in productsList)
                {
                    productData.ProductsDict.Add(product.ProductName, product.ManufacturerId);
                    productData.BarcodesDict.Add(product.BarCode, product.ManufacturerId);
                }

                //Assigne manufacturer data from DB to dictionares
                foreach (Manufacturer manufacturer in manufacturersList)
                {
                    productData.ManufacturersDict.Add(manufacturer.Name, manufacturer.Id);
                }

                e.Result = productData;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //Get all data from DB
                CompleteProductDataFromDatabase localData = (CompleteProductDataFromDatabase)e.Result;

                //Initialize with fetched data
                this.FullManufacturersDict = localData.ManufacturersDict;
                this.FullManufacturersDict.Add("Wszyscy",0);
                this.ManufacturersToDisplayDict = this.FullManufacturersDict;

                this.FullProductsDict = localData.ProductsDict;
                this.ProductsToDisplayDict = this.FullProductsDict;

                this.FullBarcodesDict = localData.BarcodesDict;
                this.BarcodesToDisplayDict = this.FullBarcodesDict;

                //Update data sources
                UpdateDataSources(this.ManufacturersToDisplayDict, this.ProductsToDisplayDict, this.BarcodesToDisplayDict);

                //Hide loading bar
                HideLoadingBar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //General methods
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((keyData == Keys.Enter))
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (keyData == Keys.Escape)
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Update control
        private void UpdateControl(ref TextBox dummyForControl)
        {
            //this.Select();
            this.Focus();
            dummyForControl.Select();
        }

        //Method used to update comboboxes datasources 
        private void UpdateDataSources(Dictionary<string, int> manufacturersData = null,
            Dictionary<string, int> productsData = null,
            Dictionary<string, int> barcodesData = null)
        {
            List<string> dataToList;

            //Update manufacturers list
            if (manufacturersData != null)
            {
                //Copy datasource to local variable first
                this.cbManufacturers.DataSource = null;
                dataToList = manufacturersData.Keys.ToList();
                dataToList.Remove("Wszyscy");
                dataToList.Sort();
                dataToList.Insert(0, "Wszyscy");
                this.cbManufacturers.DataSource = dataToList;
            }

            //Update products list
            if (productsData != null)
            {
                //Copy datasource to local variable first
                this.cbProducts.DataSource = null;
                dataToList = productsData.Keys.ToList();
                dataToList.Sort();
                this.cbProducts.DataSource = dataToList;
            }

            //Update barcodes list
            if (barcodesData != null)
            {
                //Copy datasource to local variable first
                this.cbBarcodes.DataSource = null;
                dataToList = barcodesData.Keys.ToList();
                dataToList.Sort();
                this.cbBarcodes.DataSource = dataToList;
            }
        }
        //=============================================================================
        #endregion


        //Public methods
        public void UpdateCurrentEntity()
        {
            //Show loading bar
            ShowLoadingBar();
            this.DbBackgroundWorker.RunWorkerAsync();
        }

        public void SelectBarcode(string barcodeValue)
        {
            ;
        }
        public void SelectManufacturer(string ManufacturerName)
        {
            ;
        }
        public void SelectProduct(string ProductName)
        {
            ;
        }

        //Private methods
        private void GetEntityByBarcode()
        {
            ;
        }

        private void ShowLoadingBar()
        {
            this.Enabled = false;
            this.pbLoadingBar.BringToFront();
            this.pLoadingBar.Show();
        }

        private void HideLoadingBar()
        {
            this.pLoadingBar.Hide();
            this.Enabled = true;
        }
        private void SearchBarTemplate_Load(object sender, EventArgs e)
        {
            //Show loading bar
            ShowLoadingBar();

            this.DbBackgroundWorker.RunWorkerAsync();

        }

        private void cbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            //Check if data source exist
            if (localSender.DataSource != null)
            {
                string selectedItem = localSender.SelectedItem.ToString();

                //Check auxiliary variables
                if (this.PreviouslySelectedManufacturer != localSender.SelectedItem.ToString())
                {

                    //If selected index has changed, filter barcodes and product names
                    if (selectedItem == "Wszyscy")
                    {
                        UpdateDataSources(this.FullManufacturersDict, this.FullProductsDict, this.FullBarcodesDict);
                    }
                    else
                    {
                        //Get manufacturer id
                        int manufacturerId;
                        this.FullManufacturersDict.TryGetValue(selectedItem, out manufacturerId);

                        //Filter dictionaries
                        this.ProductsToDisplayDict = this.FullProductsDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);
                        this.BarcodesToDisplayDict = this.FullBarcodesDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);

                        //Update data sources
                        UpdateDataSources(productsData: this.ProductsToDisplayDict, barcodesData: this.BarcodesToDisplayDict);

                    }

                    //Assgine new value to the auxiliary variable
                    this.PreviouslySelectedManufacturer = selectedItem;
                }
            }
           
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBarcodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbProducts_Leave(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            localSender.SelectionStart = 1;
            localSender.SelectionLength = 0;
            string temp = localSender.SelectedText;
            ;
        }

        private void tbDummyForCtrl_Enter(object sender, EventArgs e)
        {
            this.cbProducts.SelectionStart = 1;
            this.cbProducts.SelectionLength = 0;
            this.cbProducts.Update();
        }
    }

}
