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
using NaturalnieApp.Forms;



namespace NaturalnieApp.Forms
{
    public partial class AddNewProduct : UserControl
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
        private float PriceWithTax { get; set; }
        private string BarcodeToCheck { get; set; }

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public AddNewProduct(ref DatabaseCommands commandsObj)
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
            this.TaxEntity = new Tax();
            ClearProductEntity();
            ClearTaxEntity();

            //Disable Elzab product number. Manifacturer must be selected first
            tbElzabProductNumber.Enabled = false;

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
                            List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                            List<string> productSupplierList = this.databaseCommands.GetSupplierNameList();
                            returnList.Add(productManufacturerList);
                            returnList.Add(productSupplierList);
                            e.Result = returnList;
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                            List<string> productSupplierList = this.databaseCommands.GetSupplierNameList();
                            returnList.Add(productManufacturerList);
                            returnList.Add(productSupplierList);
                            e.Result = returnList;
                        }
                        break;
                    case backgroundWorkerTasks.CheckIfExist:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Check if barcode exist in db
                            bool barcodeExist = this.databaseCommands.CheckIfBarcodeExist(this.BarcodeToCheck);
                            List<string> auxiliaryList = new List<string> { barcodeExist.ToString() };
                            returnList.Add(auxiliaryList);
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
                            FillWithInitialDataFromObject((List<string>)returnList[0], returnList[1]);
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject((List<string>)returnList[0], returnList[1]);
                        }
                        break;
                    case backgroundWorkerTasks.CheckIfExist:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            //If barcode does not exist in DB, add it to field
                            if (returnList[0][0].ToLower() == "false") this.tbBarcode.Text = this.BarcodeToCheck;
                        }
                        break;
                }

                //Enable panel after work done
                if (this.databaseCommands.ConnectionStatus) this.Enabled = true;

                this.Focus();
            }
        }
        //=============================================================================
        #endregion
        //====================================================================================================
        //General methods
        #region General methods

        private void FillWithInitialDataFromObject(List<string> manufacturerList, List<string> supplierList)
        {
            cbManufacturer.Items.Clear();
            string[] sorted = manufacturerList.ToArray();
            Array.Sort(sorted);
            cbManufacturer.Items.AddRange(sorted);
            cbSupplierName.Items.Clear();
            sorted = supplierList.ToArray();
            Array.Sort(sorted);
            cbSupplierName.Items.AddRange(sorted);
            cbTax.Items.Clear();
            cbTax.Items.AddRange(this.databaseCommands.GetTaxListRetString().ToArray());
        }
        private bool ValidateAllInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {

                if(this.cbSupplierName.SelectedItem != null && this.tbProductName.Text != "" &&
                    this.tbBarcode.Text != "" && this.cbManufacturer.Text !=  null &&
                    this.tbElzabProductNumber.Text != "" && this.tbElzabProductName.Text != "" &&
                    this.tbPrice.Text != "" && this.cbTax.SelectedItem != null &&
                    this.tbMarigin.Text != "" && this.tbShortBarcode.Text != "" &&
                    this.tbDiscount.Text != "" && this.tbPriceNetWithDiscount.Text != "")
                {

                    //Set local variable to true
                    validationSuccess = true;

                    //Call eachh of validating method
                    Validation.SupplierNameValidation(this.cbSupplierName.SelectedItem.ToString());
                    Validation.ProductNameValidation(this.tbProductName.Text);

                    if(this.tbBarcode.Text.Length == 13) Validation.BarcodeEan13Validation(this.tbBarcode.Text);
                    else if (this.tbBarcode.Text.Length == 8) Validation.BarcodeEan8Validation(this.tbBarcode.Text);
                    else if (this.tbBarcode.Text.Length == 12) Validation.GeneralNumberValidation(this.tbBarcode.Text);
                    else Validation.BarcodeEan13Validation(this.tbBarcode.Text);

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
                    Validation.GeneralNumberValidation(this.tbDiscount.Text);
                    Validation.PriceNetValueValidation(this.tbPriceNetWithDiscount.Text);
                }
                else
                {
                    validationSuccess = false;
                    MessageBox.Show("Nie wszystkie wymagane pola zostały uzupełnione!");
                }

            }
            catch (Validation.ValidatingFailed ex)
            {
                //If any of exception, return validation failed
                validationSuccess = false;
                MessageBox.Show(ex.Message);
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
            this.cbSupplierName.Items.Clear();
            this.cbManufacturer.Items.Clear();

            //Elzab product number
            this.tbProductName.Text = "";
            this.tbElzabProductNumber.Text = "";
            this.tbPrice.Text = "";
            this.cbTax.Items.Clear();
            this.tbMarigin.Text = "";
            this.tbBarcode.Text = "";
            this.rtbProductInfo.Text = "";
            this.tbElzabProductName.Text = "";
            this.tbFinalPrice.Text = "";
            this.tbShortBarcode.Text = "";
            this.tbSupplierCode.Text = "";
            this.tbDiscount.Text = "";
            this.tbPriceNetWithDiscount.Text = "";
            this.tbPriceWithTax.Text = "";
            this.lElzabProductNumberRange.Text = "0-0";
            this.lElzabNameLength.Text = "0";
        }
        //Metchod use to find and select string in ComboBox
        private void FindTextInComboBoxAndSelect(ref ComboBox obj, string textToFind)
        {
            //Find search tex index
            int index = obj.FindStringExact(textToFind);
            obj.SelectedIndex = index;
            obj.Update();
        }
        //Method used to update final price value
        private void UpdateFinalPrice()
        {
            //Update Final price
            this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                Convert.ToInt32(this.cbTax.SelectedItem));

            //Show updated value
            this.tbFinalPrice.Text = String.Format("{0:0.00}", this.ProductEntity.FinalPrice.ToString());
        }
        //Method used to update price net with discount
        private void UpdatePriceNetWithDiscount()
        {
            //Update Final price
            this.ProductEntity.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscountFromProduct(this.ProductEntity);

            //Show updated value
            this.tbPriceNetWithDiscount.Text = String.Format("{0:0.00}", this.ProductEntity.PriceNetWithDiscount.ToString());
        }
        private void UpdatePriceWithTax()
        {
            //Update price with tax
            this.PriceWithTax = Calculations.CalculatePriceWithTaxFromPriceNetAndTax(this.ProductEntity.PriceNetWithDiscount, this.TaxEntity.TaxValue);

        }
        //Method used to update price net with discount
        private void UpdateNetPricesFromPriceWithTax()
        {
            //Update price net with discount
            this.ProductEntity.PriceNetWithDiscount = Calculations.CalculatePriceNetFromPriceWithTaxAndTax(
                this.PriceWithTax, this.TaxEntity.TaxValue);

            //Update price net without discount
            this.ProductEntity.PriceNet = Calculations.CalculatePriceNetFromPriceNetWithDiscount(
                this.ProductEntity.PriceNetWithDiscount, this.ProductEntity.Discount);
        }
        //Method used to update and display all prices
        private void UpdatePricesStartingFromPriceNet()
        {
            UpdatePriceNetWithDiscount();
            UpdateFinalPrice();
            UpdatePriceWithTax();
            RefreshAllPricesRelatedFields();
        }
        //Method used to update and display all prices
        private void UpdatePricesStartingFromPriceWithTax()
        {
            UpdateNetPricesFromPriceWithTax();
            UpdateFinalPrice();
            UpdatePriceWithTax();
            RefreshAllPricesRelatedFields();
        }
        //Method used to refres data in field related to the price
        private void RefreshAllPricesRelatedFields()
        {
            //Elzab product number
            this.tbPrice.Text = String.Format("{0:0.00}", this.ProductEntity.PriceNet);
            FindTextInComboBoxAndSelect(ref this.cbTax, this.TaxEntity.TaxValue.ToString());
            this.tbMarigin.Text = this.ProductEntity.Marigin.ToString();
            this.tbFinalPrice.Text = String.Format("{0:0.00}", this.ProductEntity.FinalPrice);
            this.tbDiscount.Text = this.ProductEntity.Discount.ToString();
            this.tbPriceNetWithDiscount.Text = String.Format("{0:0.00}", this.ProductEntity.PriceNetWithDiscount);
            this.tbPriceWithTax.Text = String.Format("{0:0.00}", this.PriceWithTax);
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

        //Method used to clear given entity
        private void ClearProductEntity()
        {
            this.ProductEntity.BarCode = "";
            this.ProductEntity.BarCodeShort = "";
            this.ProductEntity.Discount = 0;
            this.ProductEntity.ElzabProductId = 0;
            this.ProductEntity.ElzabProductName = "";
            this.ProductEntity.FinalPrice = 0;
            this.ProductEntity.Id = 0;
            this.ProductEntity.ManufacturerId = 0;
            this.ProductEntity.Marigin = 0;
            this.ProductEntity.PriceNet = 0;
            this.ProductEntity.PriceNetWithDiscount = 0;
            this.ProductEntity.ProductInfo = "";
            this.ProductEntity.ProductName = "";
            this.ProductEntity.SupplierCode = "";
            this.ProductEntity.SupplierId = 0;
            this.ProductEntity.TaxId = 0;

            this.PriceWithTax = 0;
        }
        //Method used to clear given entity
        private void ClearTaxEntity()
        {
            this.TaxEntity.TaxValue = 0;
            this.TaxEntity.Id = 0;
        }

        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {

            if (e.Ready && e.Valid)
            {
                this.BarcodeToCheck = e.RecognizedBarcodeValue;
                //Call background worker
                this.ActualTaskType = backgroundWorkerTasks.CheckIfExist;
                this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.CheckIfExist);
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
        private void AddNewProduct_Load(object sender, EventArgs e)
        {

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.BarcodeValidEventGenerated = false;
            this.BarcodeReader.CheckIfBarcodeFromReader(keyData);

            if ((keyData == Keys.Enter) && (!this.BarcodeValidEventGenerated))
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (keyData == Keys.Escape)
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);
                errorProvider1.Clear();
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
                    //Check if all uniqe fields are unique
                    bool exist = this.databaseCommands.CheckIfElzabProductNameExist(this.ProductEntity.ElzabProductName);
                    if (exist) throw new BarcodeRelated.ElementAlreadyExist("Nazwa w kasie Elzab '" +
                        this.ProductEntity.ElzabProductName + "' już istnieje w bazie danych");

                    exist = this.databaseCommands.CheckIfProductNameExist(this.ProductEntity.ProductName);
                    if (exist) throw new BarcodeRelated.ElementAlreadyExist("Nazwa produktu '" +
                        this.ProductEntity.ProductName + "' już istnieje w bazie danych");

                    exist = this.databaseCommands.CheckIfElzabProductIdExist(this.ProductEntity.ElzabProductId);
                    if (exist) throw new BarcodeRelated.ElementAlreadyExist("Produkt z numerem kasy Elzab '" +
                        this.ProductEntity.ElzabProductId + "' już istnieje w bazie danych");

                    exist = this.databaseCommands.CheckIfBarcodeExist(this.ProductEntity.BarCode);
                    if (exist) throw new BarcodeRelated.ElementAlreadyExist("Kod kreskowy produktu '" +
                        this.ProductEntity.BarCode + "' już istnieje w bazie danych");

                    exist = this.databaseCommands.CheckIfBarcodeShortExist(this.ProductEntity.BarCodeShort);
                    if (exist) throw new BarcodeRelated.ElementAlreadyExist("Kod kreskowy wewnętrzny '" +
                        this.ProductEntity.BarCodeShort + "' już istnieje w bazie danych");


                    //Get Id of given Tax and add it to product
                    id = this.databaseCommands.GetTaxIdByValue(int.Parse(this.cbTax.Text.ToString()));
                    if (id > 0) this.ProductEntity.TaxId = id;
                    else MessageBox.Show(String.Format("Podana wartość podatku ({0}) nie istnieje w bazie danych!", this.cbTax.SelectedValue.ToString()));

                    //Get Id of given Supplier and add it to product
                    id = this.databaseCommands.GetSupplierIdByName(this.cbSupplierName.Text.ToString());
                    if (id > 0) this.ProductEntity.SupplierId = id;
                    else MessageBox.Show(String.Format("Podana nazwa dostawcy ({0}) nie istnieje w bazie danych!", this.cbSupplierName.Text.ToString().ToString()));

                    //Get Id of given Manufacturer and add it to product
                    id = this.databaseCommands.GetManufacturerIdByName(this.cbManufacturer.Text.ToString());
                    if (id > 0) this.ProductEntity.ManufacturerId = id;
                    else MessageBox.Show(String.Format("Podana nazwa dostawcy ({0}) nie istnieje w bazie danych!", this.cbManufacturer.Text.ToString().ToString()));

                    //Update Final price
                    UpdatePriceNetWithDiscount();
                    UpdateFinalPrice();

                    //If supplier field or info field empty, fill it
                    if (tbSupplierCode.Text == "") this.ProductEntity.SupplierCode = this.ProductEntity.BarCode;
                    if (rtbProductInfo.Text == "") this.ProductEntity.ProductInfo = "Brak";

                    //Save current object to database
                    this.databaseCommands.AddNewProduct(this.ProductEntity);

                    //Show message box
                    MessageBox.Show("Produkt '" + this.ProductEntity.ProductName + "' został zapisany!");

                    //Call update event
                    bUpdate_Click(sender, e);

                    ClearProductEntity();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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

            //Update control
            UpdateControl(ref tbDummyForCtrl);
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
        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            
            if (localSender.SelectedIndex >= 0)
            {
                try
                {
                    //If epmty assign first free value
                    int elzabFirstFreeId = this.databaseCommands.CalculateFreeElzabIdForGivenManufacturer(this.ManufacturerEntity.Name);
                    if (elzabFirstFreeId > 0)
                    {
                        //Get manufacturer entity
                        this.ManufacturerEntity = this.databaseCommands.GetManufacturerEntityByName(localSender.SelectedItem.ToString());

                        //Enable text box
                        int lastNumberForGivenManufacturer = this.ManufacturerEntity.LastNumberInCashRegister - 1;
                        this.lElzabProductNumberRange.Text = this.ManufacturerEntity.FirstNumberInCashRegister.ToString() +
                            " - " + lastNumberForGivenManufacturer.ToString();
                        this.tbElzabProductNumber.Enabled = true;

                        //Generate EAN8
                        this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8(this.ManufacturerEntity.Id,
                            Convert.ToInt32(this.tbElzabProductNumber.Text));
                        this.ProductEntity.BarCodeShort = this.tbShortBarcode.Text;

                        this.tbElzabProductNumber.Text = elzabFirstFreeId.ToString();
                        this.ProductEntity.ElzabProductId = elzabFirstFreeId;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Nie można dodać więcej produktów dla \"{0}\"! Zdefiniowany limit dla producenta został osiągnięty."
                            , localSender.SelectedItem.ToString()));
                        localSender.SelectedIndex = -1;
                    }



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
        #region Product Name
        private void tbProductName_Validating(object sender, EventArgs e)
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
        private void tbProductName_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        private void tbProductName_TextChanged(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            if (localSender.Text.Length <= 34)
            {
                    this.tbElzabProductName.Text = localSender.Text;
                    this.ProductEntity.ElzabProductName = localSender.Text;
            }
            else
            {
                this.tbElzabProductName.Text = localSender.Text.Substring(0,34);
                this.ProductEntity.ElzabProductName = localSender.Text.Substring(0, 34);
            }
        }
        #endregion
        //====================================================================================================
        //Supplier Name events
        #region Supplier Name events
        private void cbSupplierName_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.SupplierNameValidation(localSender.Text);
                this.SupplierEntity.Name = localSender.Text;
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
        private void cbSupplierName_MouseHover(object sender, EventArgs e)
        {
            ComboBox localSender = (ComboBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        private void cbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ComboBox localSender = (ComboBox)sender;
                this.ProductEntity.SupplierId = this.databaseCommands.GetSupplierIdByName(localSender.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                int productNumber = Convert.ToInt32(localSender.Text);
                Validation.ElzabProductNumberValidation(productNumber,
                    this.ManufacturerEntity.FirstNumberInCashRegister,
                    this.ManufacturerEntity.LastNumberInCashRegister);
                this.ProductEntity.ElzabProductId = Convert.ToInt32(localSender.Text);
                errorProvider1.Clear();

                //Generate EAN8
                this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8(this.ManufacturerEntity.Id,
                    Convert.ToInt32(this.tbElzabProductNumber.Text));
                this.ProductEntity.BarCodeShort = this.tbShortBarcode.Text;
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
        //====================================================================================================
        //ElzabProductName events
        #region ElzabProductName events
        private void tbElzabProductName_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            localSender.Text = AdjustInputString(localSender.Text);

            //Check if input match to define pattern
            try
            {
                Validation.ElzabProductNameValidation(localSender.Text);
                this.ProductEntity.ElzabProductName = localSender.Text;
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
        private void tbElzabProductName_TextChanged(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;

            if (localSender.Text.Length > 34)
            {
                localSender.Text = localSender.Text.Substring(0, 34);
                localSender.SelectionStart = 34;
                localSender.SelectionLength = 0;
            }

            lElzabNameLength.Text = localSender.Text.Length.ToString();

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
                localSender.Text = localSender.Text.Replace(",", ".");
                Validation.PriceNetValueValidation(localSender.Text);
                this.ProductEntity.PriceNet = float.Parse(localSender.Text);

                //Update Final price
                UpdatePricesStartingFromPriceNet();

                errorProvider1.Clear();
                localSender.Text = String.Format("{0:00}", localSender.Text);
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

                //Update prices
                UpdatePricesStartingFromPriceNet();

                errorProvider1.Clear();
                localSender.Text = String.Format("{0:00}", localSender.Text);
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
        //====================================================================================================
        //Marigin events
        #region Marigin events
        private void tbMarigin_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.MariginValueValidation(localSender.Text);
                this.ProductEntity.Marigin = Int32.Parse(localSender.Text);

                //Update prices
                UpdatePricesStartingFromPriceNet();

                errorProvider1.Clear();
                localSender.Text = String.Format("{0:00}", localSender.Text);
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
        //====================================================================================================
        //Marigin events
        #region Tax events
        private void cbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.TaxEntity = this.databaseCommands.GetTaxEntityByValue(int.Parse(
                this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", "")));

                //Update prices
                UpdatePricesStartingFromPriceNet();

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            if (localSender.TextLength > 0)
            {
                //Check if input match to define pattern
                try
                {
                    Validation.SupplierCodeValidation(localSender.Text);
                    this.ProductEntity.SupplierCode = localSender.Text;
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
        }
        #endregion
        //====================================================================================================
        //ProductInfo events
        #region ProductInfo events
        private void rtbProductInfo_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            RichTextBox localSender = (RichTextBox)sender;

            if (localSender.TextLength >= 1)
            {
                //Check if input match to define pattern
                try
                {
                    Validation.GeneralDescriptionValidation(localSender.Text);
                    this.ProductEntity.SupplierCode = localSender.Text;
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

        }
        #endregion
        //====================================================================================================
        //Barcode events
        #region Barcode events
        private void tbBarcode_Validating(object sender, EventArgs e)
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
        //====================================================================================================
        //Price with tax events
        #region Price with tax events
        private void tbPriceWithTax_Validating(object sender, CancelEventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                localSender.Text = localSender.Text.Replace(",", ".");
                Validation.PriceNetValueValidation(localSender.Text);

                if (this.cbTax.SelectedIndex != -1)
                {
                    this.PriceWithTax = Single.Parse(localSender.Text);

                    //Update Final price
                    UpdatePricesStartingFromPriceWithTax();

                    localSender.Text = string.Format("{0:00}", localSender.Text);
                }
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
    }
}
