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
        public struct Properties
        {
            bool FilterByManufacturer;
        }

        //DB events Args
        public class CompleteProductDataFromDatabase
        {
            //Dictionary for products list <key = manufacturerId, value = product name>
            public Dictionary<string, int> ProductsList { get; set; }
            //Dictionary for manufacturers list <key = manufacturerId, value = manufacturer name>
            public Dictionary<string, int> ManufacturersList { get; set; }
            //Dictionary for barcodes list <key = manufacturerId, value = barcode>
            public Dictionary<string, int> BarcodesList { get; set; }
        }

        //Private fields        
        private Manufacturer ManufacturerEntity { get; set; }
        private Product ProductEntity { get; set; }
        private Tax TaxEntity { get; set; }

        private Dictionary<string, int> FullManufacturersList { get; set; }
        private Dictionary<string, int> FullProductsList { get; set; }
        private Dictionary<string, int> FullBarcodesList { get; set; }

        //Dictionary for product list <key = manufacturerId, value = product name>
        Dictionary<string, int> FilteredProductsList { get; set; }
        Dictionary<string, int> FilteredBarcodeList { get; set; }

        //Database context
        DatabaseCommands DatabaseCommands;

        //Backgound worker for connection to db
        BackgroundWorker DbBackgroundWorker;

        public SearchBarTemplate(ref DatabaseCommands database)
        {
            //Initialize component
            InitializeComponent();

            //Initialize database commands
            this.DatabaseCommands = database;

            //Initialize background worker
            InitializeBackgroundWorker();

            //Initialize data binding source
            this.cbManufacturer.DataSource = this.FullManufacturersList;
            this.cbProductList.DataSource = this.FullProductsList;
            this.cbBarcodes.DataSource = this.FullBarcodesList;
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
                productData.ManufacturersList = new Dictionary<string, int>();
                productData.ProductsList = new Dictionary<string, int>();
                productData.BarcodesList = new Dictionary<string, int>();

                //Get list of product and manufacurers ents
                List<Product> productsList = this.DatabaseCommands.GetAllProductsEnts();
                List<Manufacturer> manufacturersList = this.DatabaseCommands.GetAllManufacturersEnts();

                //Assigne product data from DB to dictionares
                foreach (Product product in productsList)
                {
                    productData.ProductsList.Add(product.ProductName, product.ManufacturerId);
                    productData.BarcodesList.Add(product.BarCode, product.ManufacturerId);
                }

                //Assigne manufacturer data from DB to dictionares
                foreach (Manufacturer manufacturer in manufacturersList)
                {
                    productData.ManufacturersList.Add(manufacturer.Name, manufacturer.Id);
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
                CompleteProductDataFromDatabase localData = (CompleteProductDataFromDatabase)e.Result;

                this.FullManufacturersList = localData.ManufacturersList;
                this.FullManufacturersList.Add("Wszyscy",0);

                this.FullProductsList = localData.ProductsList;

                this.FullBarcodesList = localData.BarcodesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        //=============================================================================
        #endregion


        //Public methods
        public void UpdateCurrentEntity()
        {
            ;
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

        private void SearchBarTemplate_Load(object sender, EventArgs e)
        {
            this.DbBackgroundWorker.RunWorkerAsync();
            ;
        }
    }

}
