using System;
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
        //Return type
        public class SelectedEnt
        {
            public int ManufacturerId { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
        }

        #region EntsRelation class
        private class EntsRelations
        {
            private int ManufacturerId { get; set; }
            private string ProductName { get; set; }
            private string Barcode { get; set; }
            private List<SelectedEnt> EntsList {get; set;}

            #region Class exceptions
            public class ListsCountNotEqualEception : Exception
            {
                public ListsCountNotEqualEception()
                {
                }

                public ListsCountNotEqualEception(string message)
                    : base(message)
                {
                }

                public ListsCountNotEqualEception(string message, Exception inner)
                    : base(message, inner)
                {
                }
            }
            #endregion

            public EntsRelations()
            {
                //Initialize ents list
                this.EntsList = new List<SelectedEnt>();
            }

            /// <summary>
            /// Use this constructor to initialize Ents list. 
            /// Input list must have equal count number. Otherwise exception will be thrown.
            /// </summary>
            /// <param name="productsList">List of the product name</param>
            /// <param name="manufacturersIdList">List of the manufacturers Ids</param>
            /// <param name="barcodesList">List of the barcodes</param>
            public EntsRelations(List<string> productsList, List<int> manufacturersIdList, List<string> barcodesList)
            {
                //Check if lists count is equal
                int productsListCount = productsList.Count();
                int manufacturerListCount = manufacturersIdList.Count();
                int barcodesListCount = barcodesList.Count();
                if((productsListCount == manufacturerListCount) && (productsListCount == barcodesListCount))
                {
                    //Increment value
                    int i = 0;

                    //Loop trought all elements to add it to the object
                    foreach(string product in productsList)
                    {
                        SelectedEnt localEnt = new SelectedEnt();
                        localEnt.ProductName = product;
                        localEnt.ManufacturerId = manufacturersIdList[i];
                        localEnt.Barcode = barcodesList[i];
                        this.EntsList.Add(localEnt);
                        i++;
                    }

                }
                else
                {
                    if (productsListCount != manufacturerListCount) throw new ListsCountNotEqualEception(
                        String.Format("Lista nazw produktów ({0}) i lista producentów ({1}) nie są równe!", productsListCount, manufacturerListCount));
                    else if (productsListCount != barcodesListCount) throw new ListsCountNotEqualEception(
                        String.Format("Lista nazw produktów ({0}) i lista kodów kreskowych ({1}) nie są równe!", productsListCount, barcodesListCount));

                }

            }

            /// <summary>
            /// Method used to add single end to ents list.
            /// </summary>
            /// <param name="productName">Product name</param>
            /// <param name="manufacurerId">Manufacturer Id</param>
            /// <param name="barcode">Barcode</param>
            public void AddEntWithRelations(string productName, int manufacurerId, string barcode)
            {
                //Prepare object to add
                SelectedEnt localEnt = new SelectedEnt();
                localEnt.ProductName = productName;
                localEnt.ManufacturerId = manufacurerId;
                localEnt.Barcode = barcode;

                //Add object
                this.EntsList.Add(localEnt);
            }

            /// <summary>
            /// Method use to get full ent by product name
            /// </summary>
            /// <param name="productName">Product name/param>
            /// <returns></returns>
            public SelectedEnt GetFullEnt(string productName)
            {
                return this.EntsList.Find(e => e.ProductName == productName);
            }
        }
        #endregion

        //DB events Args
        public class CompleteProductDataFromDatabase
        {
            //Dictionary for products list <key = manufacturerId, value = product name>
            public Dictionary<string, int> ProductsDict { get; set; }
            //Dictionary for manufacturers list <key = manufacturerId, value = manufacturer name>
            public Dictionary<string, int> ManufacturersDict { get; set; }
            //Dictionary for barcodes list <key = manufacturerId, value = barcode>
            public Dictionary<string, int> BarcodesDict { get; set; }

            //List of the tuples
            public List<(string products, int manufacturersId, string barcodes)> EntsRelaction { get; set; }


        }

        //Private fields        
        private Manufacturer ManufacturerEntity { get; set; }
        private Product ProductEntity { get; set; }
        private Tax TaxEntity { get; set; }
        private SelectedEnt ActualSelectedEnt { get; set; }
        private EntsRelations AllEntsRelation { get; set; }

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

        //Auiliary variables to  bypass calling selected index chnaged if entity was selected by program
        private bool SelectedByProgram { get; set; }
        private bool UpdatingDataSources { get; set; }

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

            //Initialize all ents relation class
            this.AllEntsRelation = new EntsRelations();

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

                    this.AllEntsRelation.AddEntWithRelations(product.ProductName, product.ManufacturerId, product.BarCode);         
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

        //Method used to select entity
        private void SelectEntity(SelectedEnt entityToSelect)
        {
            if (entityToSelect != null)
            {
                //Get manufacturer name
                string manufacturerName = this.FullManufacturersDict.Where(e => e.Value == entityToSelect.ManufacturerId)
                    .Select(e => e.Key).FirstOrDefault();

                if (manufacturerName != this.cbManufacturers.SelectedItem.ToString())
                    this.cbManufacturers.SelectedItem = manufacturerName;
                if (entityToSelect.ProductName != this.cbProducts.SelectedItem.ToString())
                    this.cbProducts.SelectedItem = entityToSelect.ProductName;
                if (entityToSelect.Barcode != this.cbBarcodes.SelectedItem.ToString())
                    this.cbBarcodes.SelectedItem = entityToSelect.Barcode;

                this.SelectedByProgram = true;
            }

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
            this.cbManufacturers.Enabled = false;
            this.cbProducts.Enabled = false;
            this.cbBarcodes.Enabled = false;
            this.pbLoadingBar.BringToFront();
            this.pLoadingBar.Show();
        }

        private void HideLoadingBar()
        {
            this.pLoadingBar.Hide();
            this.cbManufacturers.Enabled = true;
            this.cbProducts.Enabled = true;
            this.cbBarcodes.Enabled = true;
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
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            this.ActualSelectedEnt = this.AllEntsRelation.GetFullEnt(localSender.Text);

            this.cbProducts.SelectedItem = this.ActualSelectedEnt.ProductName;

            //Select entity on the other combo boxes
            this.SelectEntity(this.ActualSelectedEnt);

        }

        private void cbBarcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
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
