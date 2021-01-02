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
    public partial class AddNewProduct : Form
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
                            List<string> productSupplierList = this.databaseCommands.GetSuppliersNameList();
                            returnList.Add(productManufacturerList);
                            returnList.Add(productSupplierList);
                            e.Result = returnList;
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                            List<string> productSupplierList = this.databaseCommands.GetSuppliersNameList();
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
                this.Activate();
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
            cbManufacturer.Items.AddRange(manufacturerList.ToArray());
            cbSupplierName.Items.Clear();
            cbSupplierName.Items.AddRange(supplierList.ToArray());
            cbTax.Items.Clear();
            cbTax.Items.AddRange(this.databaseCommands.GetTaxListRetString().ToArray());
        }

        private bool ValidateAllInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {
                //Set local variable to true
                validationSuccess = true;

                //Call eachh of validating method
                cbSupplierName_Validating(this.cbSupplierName, EventArgs.Empty);
                tbProductName_Validating(this.tbProductName, (CancelEventArgs) CancelEventArgs.Empty);
                this.tbBarcode_Validating(this.tbBarcode, (CancelEventArgs) CancelEventArgs.Empty);
                cbManufacturer_Validating(this.cbManufacturer, EventArgs.Empty);
                tbElzabProductNumber_Validating(this.tbElzabProductNumber, EventArgs.Empty);
                tbElzabProductName_Validating(this.tbElzabProductName, EventArgs.Empty);
                tbPrice_Validating(this.tbPrice, EventArgs.Empty);
                cbTax_Validating(this.cbTax, EventArgs.Empty);
                tbMarigin_Validating(this.tbMarigin, EventArgs.Empty);
                tbShortBarcode_Validating(this.tbShortBarcode, EventArgs.Empty);
                tbSupplierCode_Validating(this.tbSupplierCode, EventArgs.Empty);
                rtbProductInfo_Validating(this.rtbProductInfo, EventArgs.Empty);
            }
            catch (Validation.ValidatingFailed)
            {
                //If any of exception, return validation failed
                validationSuccess = false;
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
        }
        private void AddNewProduct_KeyDown(object sender, KeyEventArgs e)
        {
            Control localControl = (Control)sender;

            this.BarcodeValidEventGenerated = false;
            this.BarcodeReader.CheckIfBarcodeFromReader(e.KeyCode);

            if (e.KeyCode == Keys.Escape)
            {
                errorProvider1.Clear();
                this.SelectNextControl(pHeader, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Enter && !this.BarcodeValidEventGenerated)
            {
                localControl.SelectNextControl(this, true, true, true, true);

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

                    //Update Final price
                    this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                        this.databaseCommands.GetTaxByProductName(this.ProductEntity.ProductName).TaxValue);

                    //Save current object to database
                    this.databaseCommands.EditProduct(this.ProductEntity);

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
                MessageBox.Show(ex.Message);
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
        private void cbManufacturer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            if (localSender.SelectedIndex >= 0)
            {
                try
                {
                    //Get manufacturer entity
                    this.ManufacturerEntity = this.databaseCommands.GetManufacturerEntityByName(localSender.SelectedItem.ToString());

                    //Enable text box
                    this.lElzabProductNumberRange.Text = this.ManufacturerEntity.FirstNumberInCashRegister.ToString() +
                        " - " + this.ManufacturerEntity.LastNumberInCashRegister.ToString();
                    this.tbElzabProductNumber.Enabled = true;

                    //If epmty assign first free value
                    this.tbElzabProductNumber.Text =
                        this.databaseCommands.CalculateFreeElzabIdForGivenManufacturer(this.ManufacturerEntity.Name).ToString();

                    //Generate EAN8
                    this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8(this.ManufacturerEntity.Id,
                        Convert.ToInt32(this.tbElzabProductNumber.Text));

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
        private void tbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SelectNextControl((Control)sender, true, true, true, true);
            }

        }
        private void tbProductName_Validating(object sender, CancelEventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

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
                MessageBox.Show(ex.Message);
                e.Cancel = true ;
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
            if (localSender.Text.Length <= 34) this.tbElzabProductName.Text = localSender.Text;
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
                MessageBox.Show(ex.Message);
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
        #endregion
        //====================================================================================================
        //ElzabProductNumber events
        #region ElzabProductNumber events
        private void tbElzabProductNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }
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
        //ElzabProductName events
        #region ElzabProductName events
        private void tbElzabProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }
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
        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }
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
                this.ProductEntity.Marigin = float.Parse(localSender.Text);
                //Update final price
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
        private void cbTax_SelectionChangeCommited(object sender, EventArgs e)
        {
            this.TaxEntity = this.databaseCommands.GetTaxEntityByValue(int.Parse(
                this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", "")));
            //Update final price
            UpdateFinalPrice();
        }
        private void cbTax_Validating(object sender, EventArgs e)
        {
            
        }
        #endregion
        //====================================================================================================
        //ShortBarcode events
        #region ShortBarcode events
        private void tbShortBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);

            }

        }
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
                MessageBox.Show(ex.Message);
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
        private void tbSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);

            }

        }
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
                MessageBox.Show(ex.Message);
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
        private void rtbProductInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }
        private void rtbProductInfo_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.GeneralDescriptionValidation(localSender.Text);
                this.ProductEntity.SupplierCode = localSender.Text;
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
        #endregion
        //====================================================================================================
        //Barcode events
        #region Barcode events
        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
               
            }
        }

        private void tbBarcode_Validating(object sender, CancelEventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.BarcodeEan13Validation(localSender.Text);
                this.ProductEntity.BarCode = localSender.Text;
                errorProvider1.Clear();
            }
            catch (Validation.ValidatingFailed ex)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, ex.Message);
                MessageBox.Show(ex.Message);
                if (localSender.Text == "") e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
