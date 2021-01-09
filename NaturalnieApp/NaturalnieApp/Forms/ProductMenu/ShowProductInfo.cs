using System;
using System.CodeDom;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using NaturalnieApp.Database;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Text.RegularExpressions;
using NaturalnieApp.Forms.TestForm;
using System.Drawing;

namespace NaturalnieApp.Forms
{
    public partial class ShowProductInfo : Form
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;

        private Product ProductEntity { get; set; }
        private Supplier SupplierEntity { get; set; }
        private Manufacturer ManufacturerEntity { get; set; }
        private Tax TaxEntity { get; set; }
        private int SelectedProductId { get; set; }

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }

        //Global variables
        private List<string> ProductsList { get; set; }
        private List<string> ManufacturersList { get; set; }
        private List<string> BarcodesList { get; set; }
        private List<string> SupplierList { get; set; }
        private List<string> TaxList { get; set; }

        //Auto complete string collections
        AutoCompleteStringCollection ProductListCollection;
        AutoCompleteStringCollection ManufacturerListCollection;
        AutoCompleteStringCollection BarcodeListCollection;
        AutoCompleteStringCollection SupplierListCollection;
        AutoCompleteStringCollection TaxListCollection;
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public ShowProductInfo(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            this.databaseCommands = commandsObj;
            ActualTaskType = backgroundWorkerTasks.None;

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;

            //Initialize object fields
            this.ProductEntity = new Product();
            this.SupplierEntity = new Supplier();
            this.ManufacturerEntity = new Manufacturer();

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

            try
            {
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
                            List<string> productSupplierList = this.databaseCommands.GetSupplierNameList();
                            List<string> barcodesList = this.databaseCommands.GetBarcodeList();
                            List<string> taxList = this.databaseCommands.GetTaxList();
                            returnList.Add(productNameList);
                            returnList.Add(productManufacturerList);
                            returnList.Add(productSupplierList);
                            returnList.Add(barcodesList);
                            returnList.Add(taxList);
                            e.Result = returnList;
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<string> productNameList = this.databaseCommands.GetProductsNameList();
                            List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                            List<string> productSupplierList = this.databaseCommands.GetSupplierNameList();
                            List<string> barcodesList = this.databaseCommands.GetBarcodeList();
                            List<string> taxList = this.databaseCommands.GetTaxList();
                            returnList.Add(productNameList);
                            returnList.Add(productManufacturerList);
                            returnList.Add(productSupplierList);
                            returnList.Add(barcodesList);
                            returnList.Add(taxList);
                            e.Result = returnList;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            FillWithInitialDataFromObject(returnList[0], returnList[1], returnList[2], returnList[3], returnList[4]);

                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject(returnList[0], returnList[1], returnList[2], returnList[3], returnList[4]);
                            if (this.SelectedProductId >= 0)
                            {
                                this.cbProductList.SelectedItem = this.databaseCommands.GetProductNameById(this.SelectedProductId);
                            }
                            //Call event
                            cbProductList_SelectedIndexChanged(this.cbProductList, EventArgs.Empty);
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
        //Method used to verify if all requred fields are uniqe
        private void VerifyUniqueFields(Product candidateToSave)
        {
            //Get entity from DB and verify wat has changed
            Product orginalEntity = this.databaseCommands.GetProductEntityByProductId(this.ProductEntity.Id);

            bool exist = false;

            if (orginalEntity.BarCodeShort != this.ProductEntity.BarCodeShort)
            {
                //Check if all uniqe fields are unique
                exist = this.databaseCommands.CheckIfBarcodeShortExist(this.ProductEntity.BarCodeShort);
                if (exist) throw new BarcodeRelated.ElementAlreadyExist("Kod kreskowy wewnętrzny '" +
                    this.ProductEntity.BarCodeShort + "' już istnieje w bazie danych");
            }
            if (orginalEntity.ElzabProductName != this.ProductEntity.ElzabProductName)
            {
                //Check if all uniqe fields are unique
                exist = this.databaseCommands.CheckIfElzabProductNameExist(this.ProductEntity.ElzabProductName);
                if (exist) throw new BarcodeRelated.ElementAlreadyExist("Nazwa w kasie Elzab '" +
                    this.ProductEntity.ElzabProductName + "' już istnieje w bazie danych");
            }
            if (orginalEntity.ProductName != this.ProductEntity.ProductName)
            {
                exist = this.databaseCommands.CheckIfProductNameExist(this.ProductEntity.ProductName);
                if (exist) throw new BarcodeRelated.ElementAlreadyExist("Nazwa produktu '" +
                    this.ProductEntity.ProductName + "' już istnieje w bazie danych");
            }
            if (orginalEntity.ElzabProductId != this.ProductEntity.ElzabProductId)
            {
                exist = this.databaseCommands.CheckIfElzabProductIdExist(this.ProductEntity.ElzabProductId);
                if (exist) throw new BarcodeRelated.ElementAlreadyExist("Produkt z numerem kasy Elzab '" +
                    this.ProductEntity.ElzabProductId + "' już istnieje w bazie danych");
            }
            if (orginalEntity.BarCode != this.ProductEntity.BarCode)
            {
                exist = this.databaseCommands.CheckIfBarcodeExist(this.ProductEntity.BarCode);
                if (exist) throw new BarcodeRelated.ElementAlreadyExist("Kod kreskowy produktu '" +
                    this.ProductEntity.BarCode + "' już istnieje w bazie danych");
            }
        }
        private void FillWithDataFromObject(Product p, Supplier s, Manufacturer m, Tax t)
        {
            //Initialize calass fields
            this.ProductEntity = p;
            this.SupplierEntity = s;

            //Supplier name
            this.cbSupplierName.Text = s.Name.ToString();

            FindTextInComboBoxAndSelect(ref this.cbProductList, p.ProductName);
            FindTextInComboBoxAndSelect(ref this.cbBarcodes, p.BarCode);
            FindTextInComboBoxAndSelect(ref this.cbManufacturerToEdit, m.Name);

            //Elzab product number
            this.tbElzabProductNumber.Text = p.ElzabProductId.ToString();
            this.tbPrice.Text = p.PriceNet.ToString();
            FindTextInComboBoxAndSelect(ref this.cbTax, t.TaxValue.ToString());
            FindTextInComboBoxAndSelect(ref this.cbSupplierName, s.Name.ToString());
            this.tbMarigin.Text = p.Marigin.ToString();
            this.rtbProductInfo.Text = p.ProductInfo.ToString();
            this.cbManufacturer.SelectedIndex = this.cbManufacturer.Items.IndexOf(m.Name);
            this.tbElzabProductName.Text = p.ElzabProductName;
            this.tbFinalPrice.Text = string.Format("{0:0.00}", p.FinalPrice.ToString());
            this.tbShortBarcode.Text = p.BarCodeShort;
            this.tbSupplierCode.Text = p.SupplierCode;
            this.tbDiscount.Text = p.Discount.ToString();
            this.tbPriceNetWithDiscount.Text = string.Format("{0:0.00}", p.PriceNetWithDiscount.ToString());
            this.tbBarcodeToEdit.Text = p.BarCode;
            this.tbProductNameToEdit.Text = p.ProductName;
        }
        private void FillWithInitialDataFromObject(List<string> productList, List<string> manufacturerList, List<string> barcodeList, List<string> supplierList, List<string> taxList)
        {
            //Add fetched data to proper combo box
            this.ProductListCollection = new AutoCompleteStringCollection();
            this.ProductsList = this.databaseCommands.GetProductsNameList();
            this.ProductListCollection.Clear();
            this.ProductListCollection.AddRange(this.ProductsList.ToArray());
            this.cbProductList.AutoCompleteCustomSource = this.ProductListCollection;
            this.cbProductList.Items.Clear();
            this.cbProductList.Items.AddRange(this.ProductsList.ToArray());

            //Add fetched data to proper combo box
            this.ManufacturerListCollection = new AutoCompleteStringCollection();
            this.ManufacturersList = this.databaseCommands.GetManufacturersNameList();
            this.ManufacturerListCollection.AddRange(this.ManufacturersList.ToArray());
            this.ManufacturerListCollection.Clear();
            this.cbManufacturer.AutoCompleteCustomSource = this.ManufacturerListCollection;
            this.cbManufacturer.Items.Clear();
            this.cbManufacturer.Items.AddRange(this.ManufacturersList.ToArray());

            //Add fetched data to proper combo box
            this.cbManufacturerToEdit.Items.Clear();
            this.cbManufacturerToEdit.Items.AddRange(manufacturerList.ToArray());

            //Add fetched data to proper combo box
            this.BarcodeListCollection = new AutoCompleteStringCollection();
            this.BarcodesList = this.databaseCommands.GetBarcodeList();
            this.BarcodeListCollection.Clear();
            this.BarcodeListCollection.AddRange(this.BarcodesList.ToArray());
            this.cbBarcodes.AutoCompleteCustomSource = this.BarcodeListCollection;
            this.cbBarcodes.Items.Clear();
            this.cbBarcodes.Items.AddRange(this.BarcodesList.ToArray());

            //Add fetched data to proper combo box
            this.SupplierListCollection = new AutoCompleteStringCollection();
            this.SupplierList = this.databaseCommands.GetSupplierNameList();
            this.SupplierListCollection.Clear();
            this.SupplierListCollection.AddRange(this.SupplierList.ToArray());
            this.cbSupplierName.AutoCompleteCustomSource = this.SupplierListCollection;
            this.cbSupplierName.Items.Clear();
            this.cbSupplierName.Items.AddRange(this.SupplierList.ToArray());

            //Add fetched data to proper combo box
            this.TaxListCollection = new AutoCompleteStringCollection();
            this.TaxList = this.databaseCommands.GetTaxList();
            this.TaxListCollection.Clear();
            this.TaxListCollection.AddRange(this.TaxList.ToArray());
            this.cbTax.AutoCompleteCustomSource = this.TaxListCollection;
            this.cbTax.Items.Clear();
            this.cbTax.Items.AddRange(this.TaxList.ToArray());


        }
        private bool ValidateAllInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {

                if (this.cbSupplierName.SelectedItem != null && this.cbProductList.SelectedItem != null &&
                    this.cbBarcodes.SelectedItem != null && this.cbManufacturer.Text != null &&
                    this.tbElzabProductNumber.Text != "" && this.tbElzabProductName.Text != "" &&
                    this.tbPrice.Text != "" && this.cbTax.SelectedItem != null &&
                    this.tbMarigin.Text != "" && this.tbShortBarcode.Text != "")
                {

                    //Set local variable to true
                    validationSuccess = true;

                    //Call eachh of validating method
                    Validation.SupplierNameValidation(this.cbSupplierName.SelectedItem.ToString());
                    Validation.ProductNameValidation(this.cbProductList.SelectedItem.ToString());

                    if (this.cbBarcodes.Text.Length == 13) Validation.BarcodeEan13Validation(this.cbBarcodes.Text);
                    else if (this.cbBarcodes.Text.Length == 8) Validation.BarcodeEan8Validation(this.cbBarcodes.Text);
                    else if (this.cbBarcodes.Text.Length == 12) Validation.GeneralNumberValidation(this.cbBarcodes.Text);
                    else Validation.BarcodeEan13Validation(this.cbBarcodes.Text);

                    Validation.ManufacturerNameValidation(this.cbManufacturer.Text);

                    int productNumber = Convert.ToInt32(this.tbElzabProductNumber.Text);
                    Validation.ElzabProductNumberValidation(productNumber,
                        this.ManufacturerEntity.FirstNumberInCashRegister,
                        this.ManufacturerEntity.LastNumberInCashRegister);

                    Validation.ElzabProductNameValidation(this.tbElzabProductName.Text);
                    Validation.PriceNetValueValidation(this.tbPrice.Text);
                    Validation.TaxValueValidation(this.cbTax.SelectedItem.ToString());
                    Validation.MariginValueValidation(this.tbMarigin.Text);
                    Validation.BarcodeEan8Validation(this.tbShortBarcode.Text);
                    Validation.SupplierCodeValidation(this.tbSupplierCode.Text);
                    Validation.ProductInfoValidation(this.rtbProductInfo.Text);
                }
                else
                {
                    validationSuccess = false;
                    MessageBox.Show("Nie wszystkie wymagane pola zostały uzupełnione!");
                }

            }
            catch (Exception ex)
            {
                validationSuccess = false;
                MessageBox.Show(ex.Message);
            }

            return validationSuccess;


        }
        //Method used to clear all object (text box, combo box, etc.)  data
        private void ClearAllObjectsData()
        {
            //Supplier name
            this.cbSupplierName.Text = "";
            this.cbManufacturer.Items.Clear();
            this.cbManufacturerToEdit.Items.Clear();

            //Elzab product number
            this.cbProductList.Items.Clear();
            this.tbElzabProductNumber.Text = "";
            this.tbPrice.Text = "";
            this.cbTax.Items.Clear();
            this.tbMarigin.Text = "";
            this.cbBarcodes.Text = "";
            this.rtbProductInfo.Text = "";
            this.tbElzabProductName.Text = "";
            this.tbFinalPrice.Text = "";
            this.tbShortBarcode.Text = "";
            this.tbSupplierCode.Text = "";
            this.cbBarcodes.Items.Clear();
            this.tbDiscount.Text = "";
            this.tbPriceNetWithDiscount.Text = "";
            this.tbBarcodeToEdit.Text = "";
            this.tbProductNameToEdit.Text = "";
        }
        //Metchod use to find and select string in ComboBox
        private void FindTextInComboBoxAndSelect(ref ComboBox obj, string textToFind)
        {
            //Find search tex index
            int index = obj.FindStringExact(textToFind);
            obj.SelectedIndex = index;
            obj.Update();
        }
        //Method used to adjust input string
        private string AdjustInputString(string inputString)
        {
            //Local variable
            string returnString;

            returnString = inputString.Replace("\n", "");
            returnString = returnString.Replace("\r", "");
            if (returnString.Length >= 1)
            {
                if (returnString[returnString.Length - 1] == ' ')
                {
                    returnString = returnString.Remove(returnString.Length - 1, 1);
                }
            }
            return returnString;
        }
        //Method used to update final price value
        private void UpdateFinalPrice()
        {
            //Update Final price
            this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                Convert.ToInt32(this.cbTax.SelectedItem));

            //Show updated value
            this.tbFinalPrice.Text = string.Format("{0:0.00}", this.ProductEntity.FinalPrice.ToString());
        }
        //Method used to update price net with discount
        private void UpdatePriceNetWithDiscount()
        {
            //Update Final price
            this.ProductEntity.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscountFromProduct(this.ProductEntity);

            //Show updated value
            this.tbPriceNetWithDiscount.Text = string.Format("{0:0.00}", this.ProductEntity.PriceNetWithDiscount.ToString());
        }
        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {

            if (e.Ready && e.Valid && !cbDeactivateBarcodeSearching.Checked)
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
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void ShowProductInfo_Load(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void ShowProductInfo_KeyDown(object sender, KeyEventArgs e)
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
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bSave_Click(object sender, EventArgs e)
        {
            //Local variables
            bool validatingSuccess;
            int id = -1;

            //Validate all input before saving
            validatingSuccess = ValidateAllInputFields();

            if (validatingSuccess)
            {
                try
                {
                    //Get Id of given Tax and add it to product
                    id = this.databaseCommands.GetTaxIdByValue(int.Parse(this.cbTax.Text.ToString()));
                    if (id > 0) this.ProductEntity.TaxId = id;
                    else MessageBox.Show(String.Format("Podana wartość podatku ({0}) nie istnieje w bazie danych!", this.cbTax.SelectedValue.ToString()));

                    //Get Id of given Supplier and add it to product
                    id = this.databaseCommands.GetSupplierIdByName(this.cbSupplierName.Text.ToString());
                    if (id > 0) this.ProductEntity.SupplierId = id;
                    else MessageBox.Show(String.Format("Podana nazwa dostawcy ({0}) nie istnieje w bazie danych!", this.cbSupplierName.Text.ToString().ToString()));

                    //Update price net with discount
                    this.ProductEntity.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscountFromProduct(this.ProductEntity);

                    //Update Final price
                    this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                        this.databaseCommands.GetTaxByProductName(this.ProductEntity.ProductName).TaxValue);

                    //Verify unique fields
                    VerifyUniqueFields(this.ProductEntity);

                    //Save current object to database
                    this.databaseCommands.EditProduct(this.ProductEntity);

                    //Add current name as selected name (In case of changing name)
                    this.SelectedProductId = this.ProductEntity.Id;

                    //Show message box
                    MessageBox.Show("Produkt '" + this.ProductEntity.ProductName + "' został zapisany!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Call update event
            bUpdate_Click(sender, e);
        }
        private void bUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //Clear all data from current form
            ClearAllObjectsData();

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Update;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Update);
        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Parent.Show();
            this.Dispose();
        }
        #endregion
        //====================================================================================================
        //Manufacturer events
        #region Manifacturer events
        private void cbManufacturer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;
            if (this.cbManufacturer.SelectedIndex != 0)
            {
                //Fetch filtered information from database
                List<string> filteredProductNames = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturer.SelectedItem.ToString());
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(filteredProductNames.ToArray());
                this.ManufacturerEntity.Name = localSender.SelectedItem.ToString();
            }
            else
            {
                //Fetch filtered information from database
                List<string> productNames = this.databaseCommands.GetProductsNameList();
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(productNames.ToArray());
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            cbManufacturer_SelectionChangeCommitted(sender, e);
            localSender.Select();
            UpdateControl(ref tbDummyForCtrl);
        }
        private void cbManufacturer_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.ManufacturerNameValidation(localSender.Text);
                this.ManufacturerEntity.Name = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbManufacturer_MouseHover(object sender, EventArgs e)
        {
            ComboBox localSender = (ComboBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //ManufacturerToEdit events
        #region Manifacturer to edit events
        private void cbManufacturerToEdit_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.ManufacturerNameValidation(localSender.Text);
                this.ManufacturerEntity.Name = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbManufacturerToEdit_MouseHover(object sender, EventArgs e)
        {
            ComboBox localSender = (ComboBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        private void cbManufacturerToEdit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            if (localSender.SelectedIndex >= 0)
            {
                try
                {
                    //Get ManufacturerToEdit entity
                    this.ManufacturerEntity = this.databaseCommands.GetManufacturerEntityByName(localSender.SelectedItem.ToString());

                    //Enable text box
                    this.lElzabProductNumberRange.Text = this.ManufacturerEntity.FirstNumberInCashRegister.ToString() +
                        " - " + this.ManufacturerEntity.LastNumberInCashRegister.ToString();
                    this.tbElzabProductNumber.Enabled = true;

                    //If epmty assign first free value
                    this.tbElzabProductNumber.Text =
                        this.databaseCommands.CalculateFreeElzabIdForGivenManufacturer(this.ManufacturerEntity.Name).ToString();
                    this.ProductEntity.ElzabProductId = Convert.ToInt32(this.tbElzabProductNumber.Text);

                    //Generate EAN8
                    this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8(this.ManufacturerEntity.Id,
                        Convert.ToInt32(this.tbElzabProductNumber.Text));
                    this.ProductEntity.BarCodeShort = this.tbShortBarcode.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        #endregion
        //====================================================================================================
        //Product list events
        #region Product List
        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            try
            {
                if (this.cbProductList.SelectedItem != null)
                {
                    this.ProductEntity = this.databaseCommands.GetProductEntityByProductName(this.cbProductList.SelectedItem.ToString());
                    this.SupplierEntity = this.databaseCommands.GetSupplierByProductName(this.cbProductList.SelectedItem.ToString());
                    this.ManufacturerEntity = this.databaseCommands.GetManufacturerByProductName(this.cbProductList.SelectedItem.ToString());
                    this.TaxEntity = this.databaseCommands.GetTaxByProductName(this.cbProductList.SelectedItem.ToString());

                    this.FillWithDataFromObject(this.ProductEntity, this.SupplierEntity, this.ManufacturerEntity, this.TaxEntity);

                    //Update calss field
                    this.SelectedProductId = this.databaseCommands.GetProductIdByName(this.cbProductList.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //cbProductList_SelectionChangeCommitted(sender, e);
            localSender.Select();
            UpdateControl(ref tbDummyForCtrl);
        }
        private void cbProductList_MouseHover(object sender, EventArgs e)
        {
            ComboBox localSender = (ComboBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //Product list events
        #region Product Name
        private void tbProductNameToEdit_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            localSender.Text = AdjustInputString(localSender.Text);

            //Check if input match to define pattern
            try
            {
                Validation.ProductNameValidation(localSender.Text);
                this.ProductEntity.ProductName = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbProductNameToEdit_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        private void tbProductNameToEdit_TextChanged(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            if (localSender.Text.Length <= 34)
            {
                if (this.tbElzabProductName.Text == "")
                {
                    this.tbElzabProductName.Text = localSender.Text;
                    this.ProductEntity.ElzabProductName = localSender.Text;
                }
            }
        }
        #endregion
        //====================================================================================================
        //Supplier Name events
        #region Supplier Name events
        private void cbSupplierName_MouseHover(object sender, EventArgs e)
        {
            ComboBox localSender = (ComboBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //ElzabProductNumber events
        #region ElzabProductNumber events
        private void tbElzabProductNumber_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.GeneralNumberValidation(localSender.Text);
                this.ProductEntity.ElzabProductId = Convert.ToInt32(localSender.Text);
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //====================================================================================================
        //ElzabProductName events
        #region ElzabProductName events
        private void tbElzabProductName_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.ElzabProductNameValidation(localSender.Text);
                this.ProductEntity.ElzabProductName = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbElzabProductName_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion        
        //====================================================================================================
        //Price events
        #region Price events
        private void tbPrice_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.PriceNetValueValidation(localSender.Text);
                this.ProductEntity.PriceNet = float.Parse(localSender.Text);
                //Update Final price
                UpdatePriceNetWithDiscount();
                UpdateFinalPrice();
                errorProvider1.Clear();
                localSender.Text = string.Format("{0:00}", localSender.Text);
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        //====================================================================================================
        //Discount event
        #region Discount events
        private void tbDiscount_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                localSender.Text = localSender.Text.Replace(",", ".");
                Validation.GeneralNumberValidation(localSender.Text);
                if (Int32.Parse(localSender.Text) < 0) localSender.Text = "0";
                if (Int32.Parse(localSender.Text) > 100) localSender.Text = "100";

                this.ProductEntity.Discount = Int32.Parse(localSender.Text);
                //Update Final price
                UpdatePriceNetWithDiscount();
                UpdateFinalPrice();
                errorProvider1.Clear();
                localSender.Text = string.Format("{0:00}", localSender.Text);
            }
            catch (Validation.ValidatingFailed ex)
            {
                errorProvider1.SetError(localSender, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        //====================================================================================================
        //Marigin events
        #region Marigin events
        private void tbMarigin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }
        private void tbMarigin_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.MariginValueValidation(localSender.Text);
                this.ProductEntity.Marigin = Int32.Parse(localSender.Text);
                //Update final price
                UpdatePriceNetWithDiscount();
                UpdateFinalPrice();
                errorProvider1.Clear();
                localSender.Text = string.Format("{0:00}", localSender.Text);
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //====================================================================================================
        //Marigin events
        #region Tax events
        private void cbTax_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.TaxEntity.TaxValue = int.Parse(this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", ""));
            //Update final price
            UpdatePriceNetWithDiscount();
            UpdateFinalPrice();

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void cbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            cbTax_SelectionChangeCommitted(sender, e);
            localSender.Select();
            UpdateControl(ref tbDummyForCtrl);
        }
        private void cbTax_Validating(object sender, EventArgs e)
        {
            
        }
        #endregion
        //====================================================================================================
        //ShortBarcode events
        #region ShortBarcode events
        private void tbShortBarcode_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.BarcodeEan8Validation(localSender.Text);
                this.ProductEntity.BarCodeShort = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //====================================================================================================
        //ShortBarcode events
        #region SupplierCode events
        private void tbSupplierCode_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.SupplierCodeValidation(localSender.Text);
                this.ProductEntity.SupplierCode = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        //====================================================================================================
        //ProductInfo events
        #region ProductInfo events
        private void rtbProductInfo_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult = false;
            string text = "Informacje o produkcie może zawierać maksymalnie 1024 znaki!";

            //Cast the sender for an object
            RichTextBox localSender = (RichTextBox)sender;

            //Check if input match to define pattern
            if (localSender.Text.Length >= 0 && localSender.Text.Length <= 1024) validatingResult = true;

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new Validation.ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");
            }
            else
            {
                this.ProductEntity.ProductInfo = localSender.Text;
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Barcode events
        #region Barcode events
        private void cbBarcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast an object
            ComboBox localSender = (ComboBox)sender;

            this.ProductEntity = this.databaseCommands.GetProductEntityByBarcode(this.cbBarcodes.SelectedItem.ToString());
            this.SupplierEntity = this.databaseCommands.GetSupplierByProductName(this.ProductEntity.ProductName);
            this.ManufacturerEntity = this.databaseCommands.GetManufacturerByProductName(this.ProductEntity.ProductName);
            this.TaxEntity = this.databaseCommands.GetTaxByProductName(this.ProductEntity.ProductName);

            this.cbBarcodes.SelectedItem = this.ProductEntity.BarCode;

            this.FillWithDataFromObject(this.ProductEntity, this.SupplierEntity, this.ManufacturerEntity, this.TaxEntity);

            localSender.Select();
            UpdateControl(ref tbDummyForCtrl);
        }
        #endregion
        //====================================================================================================
        //Barcode events
        #region BarcodeToEdit events
        private void tbBarcodeToEdit_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                if (localSender.Text == "") localSender.Text = tbShortBarcode.Text;

                if (localSender.Text.Length == 13) Validation.BarcodeEan13Validation(localSender.Text);
                else if (localSender.Text.Length == 8) Validation.BarcodeEan8Validation(localSender.Text);
                else if (localSender.Text.Length == 12) Validation.GeneralNumberValidation(localSender.Text);
                else Validation.BarcodeEan13Validation(localSender.Text);

                this.ProductEntity.BarCode = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                errorProvider1.SetError(localSender, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
