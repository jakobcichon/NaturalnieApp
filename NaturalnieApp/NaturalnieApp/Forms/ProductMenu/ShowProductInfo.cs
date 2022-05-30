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
    public partial class ShowProductInfo : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;

        private Product ProductEntity { get; set; }
        private Supplier SupplierEntity { get; set; }
        private Manufacturer ManufacturerEntity { get; set; }
        private Tax TaxEntity { get; set; }
        private float PriceWithTax { get; set; }
        private int SelectedProductId { get; set; }
        private List<int> ElzabUsedIds { get; set; }

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public ShowProductInfo(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            this.databaseCommands = commandsObj;

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;

            //Initialize object fields
            this.ProductEntity = new Product();
            this.SupplierEntity = new Supplier();
            this.ManufacturerEntity = new Manufacturer();
            this.TaxEntity = new Tax();

            //Initialize name of current user control
            this.lName.Text = "Znajdź produkt";

            //Search bar settings
            this.ucSearchBar.HideGenericButton();

            //Fetch data to fill out combo boxes
            FillWithInitialDataFromObject();
        }
        #endregion
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
            if ((orginalEntity.ElzabProductId != this.ProductEntity.ElzabProductId) && (this.ProductEntity.ElzabProductId != null))
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

            //Elzab product number
            FindTextInComboBoxAndSelect(ref this.cbTax, t.TaxValue.ToString());
            FindTextInComboBoxAndSelect(ref this.cbSupplierName, s.Name.ToString());
            FindTextInComboBoxAndSelect(ref this.cbManufacturer, m.Name.ToString());

            this.tbElzabProductNumber.Text = p.ElzabProductId.ToString();
            this.tbPrice.Text = String.Format("{0:0.00}", p.PriceNet);
            this.tbMarigin.Text = p.Marigin.ToString();
            this.rtbProductInfo.Text = p.ProductInfo.ToString();
            this.tbElzabProductName.Text = p.ElzabProductName;
            this.tbFinalPrice.Text = String.Format("{0:0.00}", p.FinalPrice);
            this.tbShortBarcode.Text = p.BarCodeShort;
            this.tbSupplierCode.Text = p.SupplierCode;
            this.tbDiscount.Text = p.Discount.ToString();
            this.tbPriceNetWithDiscount.Text = String.Format("{0:0.00}", p.PriceNetWithDiscount);
            this.tbBarcode.Text = p.BarCode;
            this.tbProductName.Text = p.ProductName;
            this.lElzabProductNumberRange.Text = "Wolne: " + (Program.GlobalVariables.CashRegisterLastPossibleId -
                Program.GlobalVariables.CashRegisterFirstPossibleId - this.databaseCommands.GetNumberOfFreeElzabIds()).ToString();
            this.lElzabNameLength.Text = this.tbElzabProductName.Text.Length.ToString();

            //Calculate price with tax
            this.PriceWithTax = Calculations.CalculatePriceWithTaxFromPriceNetAndTax(p.PriceNetWithDiscount, t.TaxValue);
            this.tbPriceWithTax.Text = String.Format("{0:0.00}", this.PriceWithTax);
        }
        private void FillWithInitialDataFromObject()
        {
            string[] sorted;

            try
            {
                //Add fetched data to proper combo box
                this.cbManufacturer.Items.Clear();
                sorted = this.databaseCommands.GetManufacturersNameList().ToArray();
                Array.Sort(sorted);
                this.cbManufacturer.Items.AddRange(sorted);

                //Add fetched data to proper combo box
                this.cbSupplierName.Items.Clear();
                sorted = this.databaseCommands.GetSupplierNameList().ToArray();
                Array.Sort(sorted);
                this.cbSupplierName.Items.AddRange(sorted);

                //Add fetched data to proper combo box
                this.cbTax.Items.Clear();
                sorted = this.databaseCommands.GetTaxList().ToArray();
                Array.Sort(sorted);
                this.cbTax.Items.AddRange(sorted);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private bool ValidateAllInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {

                if (this.cbSupplierName.SelectedItem != null && this.tbProductName.Text != "" &&
                    this.tbBarcode.Text != "" && this.cbManufacturer.Text != null &&
                    this.tbElzabProductName.Text != "" &&
                    this.tbPrice.Text != "" && this.cbTax.SelectedItem != null &&
                    this.tbMarigin.Text != "" && this.tbShortBarcode.Text != "")
                {

                    //Set local variable to true
                    validationSuccess = true;

                    //Call eachh of validating method
                    Validation.SupplierNameValidation(this.cbSupplierName.SelectedItem.ToString());
                    Validation.ProductNameValidation(this.tbProductName.Text);

                    if (this.tbBarcode.Text.Length == 13) Validation.BarcodeEan13Validation(this.tbBarcode.Text);
                    else if (this.tbBarcode.Text.Length == 8) Validation.BarcodeEan8Validation(this.tbBarcode.Text);
                    else if (this.tbBarcode.Text.Length == 12) Validation.GeneralNumberValidation(this.tbBarcode.Text);
                    else Validation.BarcodeEan13Validation(this.tbBarcode.Text);

                    Validation.ManufacturerNameValidation(this.cbManufacturer.Text);

                    Validation.GeneralNumberValidation(this.tbElzabProductNumber.Text);

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

            //Elzab product number
            this.tbElzabProductNumber.Text = "";
            this.tbPrice.Text = "";
            this.cbTax.Items.Clear();
            this.tbMarigin.Text = "";
            this.rtbProductInfo.Text = "";
            this.tbElzabProductName.Text = "";
            this.tbFinalPrice.Text = "";
            this.tbShortBarcode.Text = "";
            this.tbSupplierCode.Text = "";
            this.tbDiscount.Text = "";
            this.tbPriceNetWithDiscount.Text = "";
            this.tbBarcode.Text = "";
            this.tbProductName.Text = "";
            this.tbPriceWithTax.Text = "";
            this.lElzabProductNumberRange.Text = "Wolne: ";
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
            this.tbFinalPrice.Text = String.Format("{0:0.00}", this.ProductEntity.FinalPrice.ToString());
        }
        //Method used to update price net with discount
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
        //Method used to price net with discount and price net from price with tax
        private void UpdatePriceNetWithDiscount()
        {
            //Update Final price
            this.ProductEntity.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscountFromProduct(this.ProductEntity);

            //Show updated value
            this.tbPriceNetWithDiscount.Text = String.Format("{0:0.00}", this.ProductEntity.PriceNetWithDiscount.ToString());
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
        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {

            if (e.Ready && e.Valid)
            {
                //Get index
                if (!this.ucSearchBar.SelectBarcodeByAdditionalRequest(e.RecognizedBarcodeValue))
                {
                    MessageBox.Show("Brak kodu '" + e.RecognizedBarcodeValue + "' na liście kodów kreskowych", "Brak kodu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void ShowProductInfo_Load(object sender, EventArgs e)
        {
            //Enable text box
            this.lElzabProductNumberRange.Text = "Wolne: " + (Program.GlobalVariables.CashRegisterLastPossibleId -
                Program.GlobalVariables.CashRegisterFirstPossibleId - this.databaseCommands.GetNumberOfFreeElzabIds()).ToString();

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
                    //Get Id of given Tax and add it to product
                    id = this.databaseCommands.GetTaxIdByValue(int.Parse(this.cbTax.Text.ToString()));
                    if (id > 0) this.ProductEntity.TaxId = id;
                    else MessageBox.Show(String.Format("Podana wartość podatku ({0}) nie istnieje w bazie danych!", this.cbTax.SelectedValue.ToString()));

                    //Get Id of given Supplier and add it to product
                    id = this.databaseCommands.GetSupplierIdByName(this.cbSupplierName.Text.ToString());
                    if (id > 0) this.ProductEntity.SupplierId = id;
                    else MessageBox.Show(String.Format("Podana nazwa dostawcy ({0}) nie istnieje w bazie danych!", this.cbSupplierName.Text.ToString().ToString()));

                    UpdatePriceNetWithDiscount();
                    UpdateFinalPrice();

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

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Clear all data from current form
            ClearAllObjectsData();

            //Fill combo boxes with initial data
            FillWithInitialDataFromObject();

            //Update search bar entity
            this.ucSearchBar.UpdateCurrentEntity();

            //Disable panel and wait until data from db will be fetched
            this.Enabled = true;

        }
        private void bDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć produkt z bazy danych?", "Usunięcie produktu"
                , MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //Check if any stock entry exist for given product
                    bool exitInStock = this.databaseCommands.CheckIfAnyStockEntryForGivenProduct(this.ProductEntity);
                    if(exitInStock)
                    {
                        result = MessageBox.Show(string.Format("Uwaga! Wybrany produkt ma przypisane stany magazynowe. " +
                            "Czy chcesz kontynułować i usunąć również stany magazynowe dla {0}?", this.ProductEntity.ProductName)
                            , "Produkt do usunięcia posiada stany magazynowe", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                            bool deletedSuccessfully = this.databaseCommands.DeleteFromStock(this.ProductEntity);
                            if(deletedSuccessfully)
                            {
                                this.databaseCommands.DeleteProduct(this.ProductEntity);
                                this.SelectedProductId = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Anulowano");
                        }
                    }
                    else
                    {
                        this.databaseCommands.DeleteProduct(this.ProductEntity);
                        this.SelectedProductId = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Anulowano");
            }

            //Call update event
            bUpdate_Click(sender, e);
        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Parent.Show();
            this.Dispose();
        }
        #endregion
        //====================================================================================================
        //ManufacturerToEdit events
        #region Manufacturer to edit events
        private void cbManufacturerToEdit_Validating(object sender, EventArgs e)
        {

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
                    this.ProductEntity.ManufacturerId = this.ManufacturerEntity.Id;

                    //Enable text box
                    this.lElzabProductNumberRange.Text = "Wolne: " + (Program.GlobalVariables.CashRegisterLastPossibleId -
                        Program.GlobalVariables.CashRegisterFirstPossibleId - this.databaseCommands.GetNumberOfFreeElzabIds()).ToString();
                    this.tbElzabProductNumber.Enabled = true;

                    //If epmty assign first free value
                    this.tbElzabProductNumber.Text =
                        this.databaseCommands.CalculateFreeElzabId().ToString();
                    this.ProductEntity.ElzabProductId = Convert.ToInt32(this.tbElzabProductNumber.Text);

                    //Generate EAN8
                    this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8();
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
        private void cbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            if (localSender.SelectedIndex >= 0)
            {
                try
                {
                    //Get ManufacturerToEdit entity
                    this.SupplierEntity = this.databaseCommands.GetSupplierEntityByName(localSender.SelectedItem.ToString());
                    this.ProductEntity.SupplierId = this.SupplierEntity.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                //Get first free Id and check if given number match
                int? elzabFirstFreeId = this.databaseCommands.CalculateFreeElzabId();
                if(elzabFirstFreeId > 0)
                {
                    Validation.GeneralNumberValidation(localSender.Text);

                    if (localSender.Text == "")
                    {
                        this.ProductEntity.ElzabProductId = null;
                    }
                    else
                    {
                        this.ProductEntity.ElzabProductId = Convert.ToInt32(localSender.Text);
                    }

                    errorProvider1.Clear();

                    //Generate EAN8
                    this.tbShortBarcode.Text = BarcodeRelated.GenerateEan8();
                    this.ProductEntity.BarCodeShort = this.tbShortBarcode.Text;
                }
                else
                {
                    MessageBox.Show(String.Format("Nie można dodać więcej produktów dla \"{0}\"! Zdefiniowany limit dla producenta został osiągnięty."
                    , this.ManufacturerEntity.Name));
                }

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
                localSender.Text = localSender.Text.Replace(",", ".");
                Validation.PriceNetValueValidation(localSender.Text);
                this.ProductEntity.PriceNet = float.Parse(localSender.Text);

                //Update Final price
                UpdatePricesStartingFromPriceNet();

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

                //Update prices
                UpdatePricesStartingFromPriceNet();

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

            //Update prices
            UpdatePricesStartingFromPriceNet();

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
        //====================================================================================================
        //Search bar events
        #region Search bar events
        private void ucSearchBar_NewEntSelected(object sender, Common.SearchBarTemplate.NewEntSelectedEventArgs e)
        {
            if (this.Enabled == false) this.Enabled = true;

            FillWithDataFromObject(e.SelectedProduct, e.SelectedSupplier, e.SelectedManufacturer, e.SelectedTax);
        }
        private void ucSearchBar_CopyButtonClick(object sender, Common.SearchBarTemplate.CopyButtonClickEventArgs e)
        {
            CopiedProduct p = CopiedProduct.GetInstance();
            p.SetEnts(e.SelectedProduct, e.SelectedManufacturer, e.SelectedSupplier, e.SelectedTax);
        }

        private void ucSearchBar_PasteButtonClick(object sender, EventArgs e)
        {
            CopiedProduct p = CopiedProduct.GetInstance();
            (sender as Common.SearchBarTemplate).SelectEntityByName(p.GetEnts().productEntity.ProductName);
        }


        #endregion

        private void bGenerateElzabId_Click(object sender, EventArgs e)
        {
            List<int> usedElzabProductNumbers = this.databaseCommands.GetAllElzabProductIds();
            var number =  ElzabRelated.FindFirstAvailableElzabId(usedElzabProductNumbers);
            if (number < 0 )
            {
                tbElzabProductNumber.Text = string.Empty;
                this.ProductEntity.ElzabProductId = null;
                return;
            }

            tbElzabProductNumber.Text = number.ToString();
            this.ProductEntity.ElzabProductId = number;
        }
    }
}
