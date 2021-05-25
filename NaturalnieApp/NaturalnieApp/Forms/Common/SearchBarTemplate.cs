using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Database;

namespace NaturalnieApp.Forms.Common
{
    public partial class SearchBarTemplate : UserControl
    {
        #region Event definition

        //New Ent selected event
        public class NewEntSelectedEventArgs : EventArgs
        {
            public Product SelectedProduct { get; set; }
            public Manufacturer SelectedManufacturer { get; set; }
            public Tax SelectedTax { get; set; }
            public Supplier SelectedSupplier{ get; set; }
        }

        public delegate void NewEntSelectedEventHandler(Object sender, NewEntSelectedEventArgs e);

        protected virtual void OnNewEntSelected(NewEntSelectedEventArgs e)
        {
            NewEntSelectedEventHandler handler = NewEntSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event NewEntSelectedEventHandler NewEntSelected;


        //Copy button pressed event
        public class CopyButtonClickEventArgs : EventArgs
        {
            public Product SelectedProduct { get; set; }
            public Manufacturer SelectedManufacturer { get; set; }
            public Tax SelectedTax { get; set; }
            public Supplier SelectedSupplier { get; set; }
        }

        public delegate void CopyButtonClickEventHandler(Object sender, CopyButtonClickEventArgs e);

        protected virtual void OnCopyButtonClick(CopyButtonClickEventArgs e)
        {
            CopyButtonClickEventHandler handler = CopyButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event CopyButtonClickEventHandler CopyButtonClick;

        //Generic button click event
        public class GenericButtonClickEventArgs : EventArgs
        {
            public Product SelectedProduct { get; set; }
            public Manufacturer SelectedManufacturer { get; set; }
            public Tax SelectedTax { get; set; }
            public Supplier SelectedSupplier { get; set; }
        }

        public delegate void GenericButtonClickEventHandler(Object sender, GenericButtonClickEventArgs e);

        protected virtual void OnGenericButtonClick(GenericButtonClickEventArgs e)
        {
            GenericButtonClickEventHandler handler = GenericButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event GenericButtonClickEventHandler GenericButtonClick;

        //New Ent selected by additional request (by calling SelectEntAdditionalRequest)
        public delegate void NewEntSelectedByAdditionalRequestEventHandler(Object sender, NewEntSelectedEventArgs e);

        protected virtual void OnNewEntSelectedByAdditionalRequest(NewEntSelectedEventArgs e)
        {
            NewEntSelectedByAdditionalRequestEventHandler handler = NewEntSelectedByAdditionalRequest;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event NewEntSelectedByAdditionalRequestEventHandler NewEntSelectedByAdditionalRequest;
        #endregion

        //Properties class
        public class PropertiesClass
        {
            public bool GenButtonExist { get; set; }

            public PropertiesClass()
            {
                this.GenButtonExist = false;
            }
        }

        //Return type
        public class SelectedEnt
        {
            public int ManufacturerId { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string AdditionalBarcode { get; set; }
        }

        #region EntsRelation class
        private class EntsRelations
        {
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
            public void AddEntWithRelations(string productName, int manufacurerId, string barcode, string additionalBarcode)
            {
                //Prepare object to add
                SelectedEnt localEnt = new SelectedEnt();
                localEnt.ProductName = productName;
                localEnt.ManufacturerId = manufacurerId;
                localEnt.Barcode = barcode;
                localEnt.AdditionalBarcode = additionalBarcode;

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
            /// <summary>
            /// Method use to get full ent by barcode
            /// </summary>
            /// <param name="barcodeValue">Barcode value/param>
            /// <returns></returns>
            public SelectedEnt GetFullEntByBarcode(string barcodeValue)
            {
                SelectedEnt retVal = this.EntsList.Find(e => e.Barcode == barcodeValue);
                if(retVal == null) retVal = this.EntsList.Find(e => e.AdditionalBarcode == barcodeValue);
                return retVal;
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
        private Supplier SupplierEntity { get; set; }
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

        //Auiliary variables to  bypass calling selected index chnaged if entity was selected by program
        private bool UpdatingDataSources { get; set; }
        private bool SelectEntByAdditionalRequest { get; set; }

        //Database context
        DatabaseCommands DatabaseCommands;

        //Backgound worker for connection to db
        BackgroundWorker DbBackgroundWorker;

        //Properties
        private PropertiesClass Properties { get; set; }

        //Public fields
        //Show if search bar busy
        public bool IsBussy { get; set; }
        
        public SearchBarTemplate()
        {
            //Call setup method
            Setup();

            //Initialize generic button
            this.Properties.GenButtonExist = true;

            //Adjust appearance of search bar
            AdjustSearchBarAppearance();
        }

        public SearchBarTemplate(bool genButtonExist = true)
        {
            //Call setup method
            Setup();

            //Initialize generic button
            this.Properties.GenButtonExist = genButtonExist;

            //Adjust appearance of search bar
            AdjustSearchBarAppearance();
        }

        //Setup method
        public void Setup()
        {
            //Initialize component
            InitializeComponent();

            //Set double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);

            //Initialize database commands
            this.DatabaseCommands = new DatabaseCommands();

            //Initialize background worker
            InitializeBackgroundWorker();

            //Initialize auxiliary variables
            this.PreviouslySelectedManufacturer = "";
            this.PreviouslySelectedProduct = "";
            this.ActualSelectedEnt = new SelectedEnt();

            //Initialize autocomplete source
            this.cbManufacturers.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbManufacturers.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbProducts.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbBarcodes.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbBarcodes.AutoCompleteMode = AutoCompleteMode.Suggest;

            //Prevent Comboboxes flickering
            DoDoubleBuffered(cbManufacturers.Parent, true);
            DoDoubleBuffered(cbProducts.Parent, true);
            DoDoubleBuffered(cbBarcodes.Parent, true);

            //Initialize all ents relation class
            this.AllEntsRelation = new EntsRelations();

            //Initialize properties
            this.Properties = new PropertiesClass();

            //Test
            EventManager testClass = new EventManager("SelectedIndexChanged", typeof(ComboBox));
            testClass.RegisterObject(this.cbBarcodes);

            //EndTest
        }

        //Mathod used to adjusted search bar appearance
        public void AdjustSearchBarAppearance()
        {
            if(this.Properties.GenButtonExist)
            {
                this.bGenericButton.Visible = true;
                this.bGenericButton.Enabled = true;
                this.pManufacturer.Size = new Size(220,this.pBarCode.Size.Height);
                this.pBarCode.Size = new Size(175, this.pBarCode.Size.Height);

                this.pProductName.Location = new Point(this.pManufacturer.Location.X + this.pManufacturer.Size.Width + 5
                    , this.pProductName.Location.Y);
                this.pBarCode.Location = new Point(this.pProductName.Location.X + this.pProductName.Size.Width + 5
                    , this.pBarCode.Location.Y);
            }
            else
            {
                this.bGenericButton.Visible = false;
                this.bGenericButton.Enabled = false;
                this.pManufacturer.Size = new Size(220 + 25, this.pBarCode.Size.Height);
                this.pBarCode.Size = new Size(175 + 25, this.pBarCode.Size.Height);

                this.pProductName.Location = new Point(this.pManufacturer.Location.X + this.pManufacturer.Size.Width + 5
                    , this.pProductName.Location.Y);
                this.pBarCode.Location = new Point(this.pProductName.Location.X + this.pProductName.Size.Width + 5
                    , this.pBarCode.Location.Y);
            }
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
            this.DbBackgroundWorker.DoWork += this.DbBackgroundWorker_DoWork;
            // this event will define what the worker will do when finished
            this.DbBackgroundWorker.RunWorkerCompleted += this.DbBackgroundWorker_RunWorkerCompleted;
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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

                    this.AllEntsRelation.AddEntWithRelations(product.ProductName, product.ManufacturerId, product.BarCode, product.BarCodeShort);         
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

                //Update current selected entity
                if (this.PreviouslySelectedProduct == "")
                {
                    //Get actual entity
                    this.ActualSelectedEnt = this.AllEntsRelation.GetFullEnt(this.cbProducts.SelectedItem.ToString());
                    this.PreviouslySelectedProduct = this.ActualSelectedEnt.ProductName;
                }
                else
                {
                    //Get actual entity
                    this.ActualSelectedEnt = this.AllEntsRelation.GetFullEnt(this.PreviouslySelectedProduct);

                }

                //Select entity on the other combo boxes
                this.SelectEntity(this.ActualSelectedEnt);

                //Hide loading bar
                HideLoadingBar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region General methods
        //General methods
        public static void DoDoubleBuffered(Control formControl, bool setting)
        {
            Type conType = formControl.GetType();
            PropertyInfo pi = conType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(formControl, setting, null);
        }
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
            BlockDelegates();

            if (entityToSelect != null)
            {
                //Get manufacturer name
                string manufacturerName = this.FullManufacturersDict.Where(e => e.Value == entityToSelect.ManufacturerId)
                    .Select(e => e.Key).FirstOrDefault();

                //Set flag to bypass events action
                this.UpdatingDataSources = true;

                if (this.cbManufacturers.SelectedItem == null || manufacturerName != this.cbManufacturers.SelectedItem.ToString())
                    this.cbManufacturers.SelectedItem = manufacturerName;
                if (this.cbProducts.SelectedItem == null || entityToSelect.ProductName != this.cbProducts.SelectedItem.ToString())
                    this.cbProducts.SelectedItem = entityToSelect.ProductName;
                if (this.cbBarcodes.SelectedItem == null || entityToSelect.Barcode != this.cbBarcodes.SelectedItem.ToString())
                    this.cbBarcodes.SelectedItem = entityToSelect.Barcode;

                //Select entity
                FullProductInfo fullProductInfo = this.DatabaseCommands.GetFullProductInfoByName(entityToSelect.ProductName);
                if(fullProductInfo != null)
                {
                    this.ProductEntity = fullProductInfo.ProductEnt;
                    this.ManufacturerEntity = fullProductInfo.ManufacturerEnt;
                    this.TaxEntity = fullProductInfo.TaxEnt;
                    this.SupplierEntity = fullProductInfo.SupplierEnt;

                    //Reset flag to bypass events action
                    this.UpdatingDataSources = false;

                    //Fire an event
                    NewEntSelectedEventArgs args = new NewEntSelectedEventArgs();
                    args.SelectedProduct = this.ProductEntity;
                    args.SelectedManufacturer = this.ManufacturerEntity;
                    args.SelectedTax = this.TaxEntity;
                    args.SelectedSupplier = this.SupplierEntity;
                    if (this.SelectEntByAdditionalRequest) OnNewEntSelectedByAdditionalRequest(args);
                    else OnNewEntSelected(args);
                }
                else
                {
                    entityToSelect = null;
                }


            }

            UnblockDelegates();

            if (entityToSelect == null)
            {

                //Set flag to bypass events action
                this.UpdatingDataSources = true;

                this.cbProducts.SelectedItem = null;
                this.cbBarcodes.SelectedItem = null;

                this.ManufacturerEntity = null;
                this.cbManufacturers.SelectedIndex = 0;
                this.ProductEntity = null;
                this.TaxEntity = null;
                this.SupplierEntity = null;

                //Reset flag to bypass events action
                this.UpdatingDataSources = false;
            }

            //Update control
            this.UpdateControl(ref this.tbDummyForCtrl);

        }

        //Update control
        private void UpdateControl(ref TextBox dummyForControl)
        {
            this.Focus();
            dummyForControl.Select();
        }

        //Method used to update comboboxes datasources 
        private void UpdateDataSources(Dictionary<string, int> manufacturersData = null,
            Dictionary<string, int> productsData = null,
            Dictionary<string, int> barcodesData = null)
        {
            List<string> dataToList;

            //Set flag to bypass events action
            this.UpdatingDataSources = true;

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
                if(this.ActualSelectedEnt.ProductName != null) this.cbProducts.SelectedItem = this.ActualSelectedEnt.ProductName;
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

            //Reset flag to bypass events action
            this.UpdatingDataSources = false;

            //Update control
            this.UpdateControl(ref this.tbDummyForCtrl);
        }
        //=============================================================================
        #endregion

        //Public methods
        public void UpdateCurrentEntity()
        {
            //Show loading bar
            ShowLoadingBar();

            //Write down currently selected enityt
            this.PreviouslySelectedProduct = this.ActualSelectedEnt.ProductName;

            //Update
            if(!this.DbBackgroundWorker.IsBusy) this.DbBackgroundWorker.RunWorkerAsync();
        }

        public void ShowGenericButton()
        {
            this.Properties.GenButtonExist = true;
            AdjustSearchBarAppearance();
        }

        public void HideGenericButton()
        {
            this.Properties.GenButtonExist = false;
            AdjustSearchBarAppearance();
        }

        /// <summary>
        /// Method used to select given barcode and call OnNewEntSelectedByAdditionalRequest
        /// instead of OnNewEntSelected.
        /// </summary>
        /// <param name="barcodeValue">Barcode value to select</param>
        /// <returns>True - if barcode was found, else false</returns>
        public bool SelectBarcodeByAdditionalRequest(string barcodeValue)
        {
            //Local variable
            bool retVal;

            this.SelectEntByAdditionalRequest = true;
            retVal = SelectBarcode(barcodeValue);
            this.SelectEntByAdditionalRequest = false;

            return retVal;
        }
        public bool SelectBarcode(string barcodeValue)
        {
            //Get actual entity
            SelectedEnt entToSelect = this.AllEntsRelation.GetFullEntByBarcode(barcodeValue);

            if (entToSelect != null)
            {
                //Set found entity as actual one
                this.ActualSelectedEnt = entToSelect;

                //Get manufacturer id
                int manufacturerId = entToSelect.ManufacturerId;

                //Filter dictionaries
                this.ProductsToDisplayDict = this.FullProductsDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);
                this.BarcodesToDisplayDict = this.FullBarcodesDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);

                //Reset dicts
                this.UpdateDataSources(productsData: this.ProductsToDisplayDict, barcodesData: this.BarcodesToDisplayDict);

                //Select entity on the other combo boxes
                this.SelectEntity(this.ActualSelectedEnt);

                return true;
            }
            else return false;
        }
        public bool SelectEntityByName(string entityName)
        {
            //Get actual entity
            SelectedEnt entToSelect = this.AllEntsRelation.GetFullEnt(entityName);

            if (entToSelect != null)
            {
                //Set found entity as actual one
                this.ActualSelectedEnt = entToSelect;

                //Get manufacturer id
                int manufacturerId = entToSelect.ManufacturerId;

                //Filter dictionaries
                this.ProductsToDisplayDict = this.FullProductsDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);
                this.BarcodesToDisplayDict = this.FullBarcodesDict.Where(el => el.Value == manufacturerId).ToDictionary(i => i.Key, i => i.Value);

                //Reset dicts
                this.UpdateDataSources(productsData: this.ProductsToDisplayDict, barcodesData: this.BarcodesToDisplayDict);

                //Select entity on the other combo boxes
                this.SelectEntity(this.ActualSelectedEnt);

                return true;
            }
            else return false;
        }

        //Private methods
        //Test!!!
        private void BlockDelegates()
        {
            this.cbBarcodes.SelectedIndexChanged -= cbBarcodes_SelectedIndexChanged;
            this.cbManufacturers.SelectedIndexChanged -= cbManufacturers_SelectedIndexChanged;
        }

        private void UnblockDelegates()
        {
            this.cbBarcodes.SelectedIndexChanged += cbBarcodes_SelectedIndexChanged;
            this.cbManufacturers.SelectedIndexChanged += cbManufacturers_SelectedIndexChanged;
        }

        //End test !!
        private void ShowLoadingBar()
        {
            this.cbManufacturers.Enabled = false;
            this.cbProducts.Enabled = false;
            this.cbBarcodes.Enabled = false;
            if (this.Properties.GenButtonExist) this.bGenericButton.Enabled = false;
            this.pbLoadingBar.BringToFront();
            this.tpLoadingBar.Show();
            this.IsBussy = true;
        }
        private void HideLoadingBar()
        {
            this.tpLoadingBar.Hide();
            this.cbManufacturers.Enabled = true;
            this.cbProducts.Enabled = true;
            this.cbBarcodes.Enabled = true;
            if (this.Properties.GenButtonExist) this.bGenericButton.Enabled = true;
            this.IsBussy = false;
        }
        private void SearchBarTemplate_Load(object sender, EventArgs e)
        {
            if(!this.DesignMode)
            {
                //Show loading bar
                ShowLoadingBar();

                //Run backgorundworker
                if(!this.DbBackgroundWorker.IsBusy) this.DbBackgroundWorker.RunWorkerAsync();
            }
        }
        private void cbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            //Check if data source exist
            if (localSender.DataSource != null && !this.UpdatingDataSources)
            {
                string selectedItem = localSender.SelectedItem.ToString();

                //Check auxiliary variables
                if (this.PreviouslySelectedManufacturer != selectedItem)
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

                    //Get actual entity
                    this.ActualSelectedEnt = this.AllEntsRelation.GetFullEnt(this.cbProducts.SelectedItem.ToString());
                    this.SelectEntity(null);
                }
            }
           
        }
        private void cbManufacturers_TextChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;
            if (localSender.DroppedDown)
            {
                localSender.DroppedDown = false;
            }
        }
        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            if (!this.UpdatingDataSources)
            {
                string selectedItem = localSender.SelectedItem.ToString();

                //Get actual entity
                this.ActualSelectedEnt = this.AllEntsRelation.GetFullEnt(selectedItem);

                //Select entity on the other combo boxes
                this.SelectEntity(this.ActualSelectedEnt);
            }
        }
        private void cbProducts_TextChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;
            if (localSender.DroppedDown)
            {
                localSender.DroppedDown = false;
            }
        }
        private void cbBarcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;

            if (!this.UpdatingDataSources)
            {
                string selectedItem = localSender.SelectedItem.ToString();

                //Get actual entity
                this.ActualSelectedEnt = this.AllEntsRelation.GetFullEntByBarcode(selectedItem);

                //Select entity on the other combo boxes
                this.SelectEntity(this.ActualSelectedEnt);
            }
        }
        private void cbBarcodes_TextChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;
            if (localSender.DroppedDown)
            {
                localSender.DroppedDown = false;
            }
        }
        private void tbDummyForCtrl_Enter(object sender, EventArgs e)
        {
            this.cbProducts.SelectionStart = 1;
            this.cbProducts.SelectionLength = 0;
            this.cbProducts.Update();
        }
        private void bGenericButton_Click(object sender, EventArgs e)
        {
            if(this.ProductEntity != null && this.ManufacturerEntity != null && this.TaxEntity != null)
            {
                //Fire an event
                GenericButtonClickEventArgs args = new GenericButtonClickEventArgs();
                args.SelectedProduct = this.ProductEntity;
                args.SelectedManufacturer = this.ManufacturerEntity;
                args.SelectedTax = this.TaxEntity;
                OnGenericButtonClick(args);
            }
        }
        private void bCopy_Click(object sender, EventArgs e)
        {
            if (this.ProductEntity != null)
            {
                CopyButtonClickEventArgs args = new CopyButtonClickEventArgs
                {
                    SelectedManufacturer = this.ManufacturerEntity,
                    SelectedProduct = this.ProductEntity,
                    SelectedSupplier = this.SupplierEntity,
                    SelectedTax = this.TaxEntity
                };

                this.OnCopyButtonClick(args);
            }
        }
    }

    class EventManager
    {
        string EventName { get; set; }
        Type SupervisedType { get; set; }
        List<object> RegisteredObjectsList { get; set; } 

        public EventManager(string eventName, Type supervisedType)
        {
            this.EventName = eventName;
            this.SupervisedType = supervisedType;
            this.RegisteredObjectsList = new List<object>();

        }

        public void RegisterObject(object objectToRegister)
        {
            //Check object type
            this.CheckObjectType(objectToRegister);

            //Add object to the list
            this.RegisteredObjectsList.Add(objectToRegister);

            GetDelegateInvocationList(objectToRegister, this.EventName);

        }

        private static void GetDelegateInvocationList(object objectToWorkOn, string eventName)
        {
            // Fetch the MethodInfo array using reflection API
            EventInfo searchEvent = objectToWorkOn.GetType().GetRuntimeEvent(eventName);
            Type eventType = searchEvent.EventHandlerType;
            FieldInfo fieldInfo = objectToWorkOn.GetType().GetField(("Event_" + eventName).ToUpper(), BindingFlags.NonPublic | BindingFlags.Static);
            object eventKey = fieldInfo.GetValue(objectToWorkOn);
            PropertyInfo propertyInfo = objectToWorkOn.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            EventHandlerList eventHandlerList = propertyInfo.GetValue(objectToWorkOn, new object[] { }) as EventHandlerList;
            var eventHandler = eventHandlerList[eventKey] as Delegate;
            Delegate[] invocationList = eventHandler.GetInvocationList();
            ;
        }


        private void CheckObjectType(object objectToCheck)
        {
            if (objectToCheck == null) throw new ArgumentNullException();
            else if (objectToCheck.GetType() != this.SupervisedType)
            {
                string text = String.Format("Wrong object type! Expected: {0}; Given: {1}", this.SupervisedType.ToString(),
                    objectToCheck.GetType().ToString());
                throw new ArgumentException(text);
            }
        }
    }


}
