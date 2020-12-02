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



namespace NaturalnieApp.Forms
{
    public enum backgroundWorkerTasks {None, Init, Update};


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
        private string SelectedProductName { get; set; }
        #endregion

        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public ShowProductInfo(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            this.databaseCommands = new DatabaseCommands();
            ActualTaskType = backgroundWorkerTasks.None;
            //this.ProductEntity = new Product();
            //this.SupplierEntity = new Supplier();
        }
        #endregion
        //====================================================================================================
        //User-defined exception
        #region User-defined exception
        public class ValidatingFailed : Exception
        {
            public ValidatingFailed()
            {
            }

            public ValidatingFailed(string message)
                : base(message)
            {
            }

            public ValidatingFailed(string message, Exception inner)
                : base(message, inner)
            {
            }
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
                        List<string> productSupplierList = this.databaseCommands.GetSuppliersNameList();
                        returnList.Add(productNameList);
                        returnList.Add(productManufacturerList);
                        returnList.Add(productSupplierList);
                        e.Result = returnList;
                    }
                    break;
                case backgroundWorkerTasks.Update:
                    if (this.databaseCommands.ConnectionStatus)
                    {
                        List<string> productNameList = this.databaseCommands.GetProductsNameList();
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        List<string> productSupplierList = this.databaseCommands.GetSuppliersNameList();
                        returnList.Add(productNameList);
                        returnList.Add(productManufacturerList);
                        returnList.Add(productSupplierList);
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
                            if (this.SelectedProductName != null)
                            {
                                this.cbProductList.SelectedItem = this.SelectedProductName;
                            }
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
        private void FillWithInitialDataFromObject(List<string> productList, List<string> manufacturerList, List<string> supplierList)
        {
            //Add fetched data to proper combo box
            cbProductList.Items.AddRange(productList.ToArray());
            cbManufacturer.Items.Clear();
            cbManufacturer.Items.Add("Wszyscy");
            cbManufacturer.Items.AddRange(manufacturerList.ToArray());
            cbSupplierName.Items.Clear();
            cbSupplierName.Items.AddRange(supplierList.ToArray());
            cbTax.Items.Clear();
            cbTax.Items.AddRange(this.databaseCommands.GetTaxListRetString().ToArray());
        }

        private void FillWithDataFromObject(Product p, Supplier s, Manufacturer m, Tax t)
        {
            //Initialize calass fields
            this.ProductEntity = p;
            this.SupplierEntity = s;

            //Supplier name
            this.cbSupplierName.Text = s.Name.ToString();

            //Elzab product number
            this.tbElzabProductNumber.Text = p.ElzabProductId.ToString();
            this.tbPrice.Text = p.PriceNet.ToString();
            FindTextInComboBoxAndSelect(ref this.cbTax, t.TaxValue.ToString());
            FindTextInComboBoxAndSelect(ref this.cbSupplierName, s.Name.ToString());
            this.tbMarigin.Text = p.Marigin.ToString();
            this.tbBarCode.Text = p.BarCode.ToString();
            this.rtbProductInfo.Text = p.ProductInfo.ToString();
            this.cbManufacturer.SelectedIndex = this.cbManufacturer.Items.IndexOf(m.Name);
        }

        private bool ValidateAllInputFields()
        {
            //Local variable
            bool validationSuccess = false;
            try
            {
                //Set local variable to true
                validationSuccess = true;

                //Call eachh of validating method
                cbSupplierName_Validating(this.cbSupplierName, EventArgs.Empty);
                cbProductList_Validating(this.cbProductList, EventArgs.Empty);
                tbBarCode_Validating(this.tbBarCode, EventArgs.Empty); ;
                cbManufacturer_Validating(this.cbManufacturer, EventArgs.Empty);
                tbElzabProductNumber_Validating(this.tbElzabProductNumber, EventArgs.Empty);
                tbPrice_Validating(this.tbPrice, EventArgs.Empty);
                cbTax_Validating(this.cbTax, EventArgs.Empty);
                tbMarigin_Validating(this.tbMarigin, EventArgs.Empty);
                rtbProductInfo_Validating(this.rtbProductInfo, EventArgs.Empty);
            }
            catch (ValidatingFailed)
            {
                //If any of exception, return validation failed
                validationSuccess = false;
                MessageBox.Show("Błąd podczas weryfikacji danych wejściowych!");
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
            this.cbProductList.Items.Clear();
            this.tbElzabProductNumber.Text = "";
            this.tbPrice.Text = "";
            this.cbTax.Items.Clear();
            this.tbMarigin.Text = "";
            this.tbBarCode.Text = "";
            this.rtbProductInfo.Text = "";
        }

        //Metchod use to find and select string in ComboBox
        private void FindTextInComboBoxAndSelect(ref ComboBox obj, string textToFind)
        {
            //Find search tex index
            int index = obj.FindString(textToFind);
            obj.SelectedIndex = index;

        }
        //Method used to validate input 
        private bool ValidateInput(string textToValidate, string regExPatter)
        {
            //Local variables
            bool ret;
            Regex reg = new Regex(regExPatter);

            //Check if text to validate match given pattern
            ret = reg.IsMatch(textToValidate);

            return ret;
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
            Product test;
            test = this.databaseCommands.GetProductEntityByProductName("ujędrniajacy krem róża z jagodą  60 ml");
            ;


        }
        private void ShowProductInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                errorProvider1.Clear();
                Control localControl = (Control)sender;
                localControl.Controls.Remove(this.ActiveControl);
            }
        }
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
                //Get Id of given Tax and add it to product
                id = this.databaseCommands.GetTaxIdByValue(int.Parse(this.cbTax.Text.ToString()));
                if (id > 0) this.ProductEntity.TaxId = id;
                else MessageBox.Show(String.Format("Podana wartość podatku ({0}) nie istnieje w bazie danych!", this.cbTax.SelectedValue.ToString()));

                //Get Id of given Supplier and add it to product
                id = this.databaseCommands.GetSupplierIdByName(this.cbSupplierName.Text.ToString());
                if (id > 0) this.ProductEntity.SupplierId = id;
                else MessageBox.Show(String.Format("Podana nazwa dostawcy ({0}) nie istnieje w bazie danych!", this.cbSupplierName.Text.ToString().ToString()));

                //Save current object to database
                this.databaseCommands.EditProduct(this.ProductEntity);
            }

            //Call update event
            bUpdate_Click(sender, e);
        }
        private void bUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //Get current product name if was chosen
            if (this.SelectedProductName != null)
            {
                if (this.cbProductList.SelectedItem != null)
                {
                    this.SelectedProductName = this.cbProductList.SelectedItem.ToString();
                }
                else
                {
                    this.SelectedProductName = null;
                }
            }

            //Clear all data from current form
            ClearAllObjectsData();

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Update;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Update);

        }
        #endregion
        //====================================================================================================
        //Manufacturer events
        #region Manifacturer events
        private void cbManufacturer_SelectionChangedCommited(object sender, EventArgs e)
        {
            if (this.cbManufacturer.SelectedIndex != 0)
            {
                //Fetch filtered information from database
                List<string> filteredProductNames = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturer.SelectedItem.ToString());
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(filteredProductNames.ToArray());

            }
            else
            {
                //Fetch filtered information from database
                List<string> productNames = this.databaseCommands.GetProductsNameList();
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(productNames.ToArray());
            }
        }
        private void cbManufacturer_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[a-zA-Z0-9_]{1,255}$";

            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            //Check if input match to define pattern
            validatingResult = ValidateInput(localSender.Text, regPattern);

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");

            }
            else
            {
                this.ManufacturerEntity.Name = localSender.Text;
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Product list events
        #region Product List
        private void cbProductList_SelectionChangedCommited(object sender, EventArgs e)
        {
            this.ProductEntity = this.databaseCommands.GetProductEntityByProductName(this.cbProductList.SelectedItem.ToString());
            this.SupplierEntity = this.databaseCommands.GetSupplierByProductName(this.cbProductList.SelectedItem.ToString());
            this.ManufacturerEntity = this.databaseCommands.GetManufacturerByProductName(this.cbProductList.SelectedItem.ToString());
            this.TaxEntity = this.databaseCommands.GetTaxByProductName(this.cbProductList.SelectedItem.ToString());
            this.FillWithDataFromObject(this.ProductEntity, this.SupplierEntity, this.ManufacturerEntity, this.TaxEntity);

            //Update calss field
            this.SelectedProductName = this.cbProductList.SelectedItem.ToString();
        }
        private void cbProductList_Validating(object sender, EventArgs e)
        {
        }
        #endregion
        #endregion
        //====================================================================================================
        //Supplier Name events
        #region Supplier Name events
        private void cbSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }
        private void cbSupplierName_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery i nastepujące znaki specjalne: _-+";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[a-zA-Z0-9_]{1,255}$";

            //Cast the sender for an object
            ComboBox localSender = (ComboBox)sender;

            //Check if input match to define pattern
            validatingResult = ValidateInput(localSender.Text, regPattern);

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");

            }
            else
            {
                this.SupplierEntity.Name = localSender.Text;
                errorProvider1.Clear();
            }
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
            //Local variables
            bool validatingResult;
            int value;
            string text = "Numer produktu w kasie Elzab musi być liczbą całkowitą z przedziału 0-4096";

            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            validatingResult = int.TryParse(localSender.Text, out value);
            if (value < 0 || value > 4096) validatingResult = false;

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");
            }
            else
            {
                this.ProductEntity.ElzabProductId = value;
                errorProvider1.Clear();
            }
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
            //Local variables
            bool validatingResult;
            float value;
            string stringValue;
            string text = "Cena musi być liczbą rzeczywistą, w zakresie 0.0-2000.0";

            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Regex pattern
            string regPattern = @"^.*,.*";
            Regex reg = new Regex(regPattern);

            //Check if input match to define pattern
            validatingResult = Single.TryParse(localSender.Text.Replace(".",","), out value);
            if (value < 0 || value > 2000.0) validatingResult = false;

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");
            }
            else
            {
                //Check if value consist comma
                stringValue = value.ToString();
                bool isReal = reg.IsMatch(stringValue);
                if (! isReal )
                {
                    stringValue += ",00";
                    localSender.Text = stringValue;
                }
                else localSender.Text = value.ToString();

                this.ProductEntity.PriceNet = value;
                errorProvider1.Clear();
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
            //Local variables
            bool validatingResult;
            float value;
            string stringValue;
            string text = "Marża musi być liczbą rzeczywistą, w zakresie 0.0-2000.0";

            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Regex pattern
            string regPattern = @"^.*,.*";
            Regex reg = new Regex(regPattern);

            //Check if input match to define pattern
            validatingResult = Single.TryParse(localSender.Text.Replace(".", ","), out value);
            if (value < 0 || value > 2000.0) validatingResult = false;

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");
            }
            else
            {
                //Check if value consist comma
                stringValue = value.ToString();
                bool isReal = reg.IsMatch(stringValue);
                if (!isReal)
                {
                    stringValue += ",00";
                    localSender.Text = stringValue;
                }
                else localSender.Text = value.ToString();

                this.ProductEntity.Marigin = value;
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Marigin events
        #region Tax events
        private void cbTax_SelectionChangeCommited(object sender, EventArgs e)
        {
            this.TaxEntity.TaxValue = int.Parse(this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", ""));
        }
        private void cbTax_Validating(object sender, EventArgs e)
        {
            ;
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
            //Local variables
            bool validatingResult = false;
            string text = "Informacje o produkcie może zawierać maksymalnie 1024 znaki!";

            //Cast the sender for an object
            RichTextBox localSender = (RichTextBox)sender;

            //Check if input match to define pattern
            if (localSender.Text.Length > 0 && localSender.Text.Length <= 1024) validatingResult = true;

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");
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
        private void tbBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
               
            }

        }
        private void tbBarCode_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult;
            string text = "Kod kreskowy musi składać się tylko z cyfr a jego długość musi wynosić 8-13 znaków";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^\d{8,13}$";

            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            validatingResult = ValidateInput(localSender.Text, regPattern);

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);
                if (e == EventArgs.Empty) throw new ValidatingFailed("Błąd podczas weryfikacji " + localSender.Name + "!");

            }
            else
            {
                this.ProductEntity.BarCode = localSender.Text;
                errorProvider1.Clear();
            }
        }
        #endregion

        private void cbTax_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
