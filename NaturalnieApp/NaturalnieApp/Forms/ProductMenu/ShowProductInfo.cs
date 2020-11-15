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
    public enum backgroundWorkerTasks {None, Init, Update}



    public partial class ShowProductInfo : Form
    {
        DatabaseCommands databaseCommands;
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;

        private Product ProductEntity { get; set; }
        private Supplier SupplierEntity { get; set; }

        public ShowProductInfo(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            this.databaseCommands = new DatabaseCommands();
            ActualTaskType = backgroundWorkerTasks.None;
            this.ProductEntity = new Product();
            this.SupplierEntity = new Supplier();


        }

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
                        List<string> productSuppliersList = this.databaseCommands.GetSuppliersNameList();
                        returnList.Add(productNameList);
                        returnList.Add(productSuppliersList);
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
                            FillWithInitialDataFromObject((List<string>)returnList[0], returnList[1]);
                        }
                        break;
                }

                //Enable panel after work done
                if (this.databaseCommands.ConnectionStatus) this.Enabled = true;

            }
        }
        //=============================================================================
        #endregion
        //====================================================================================================
        //General methods
        #region General methods
        private void FillWithInitialDataFromObject(List<string> productList, List<string> supplierList)
        {
                //Add fetched data to proper combo box
                cbProductList.Items.AddRange(productList.ToArray());
                cbManufacturer.Items.Clear();
                cbManufacturer.Items.Add("Wszyscy");
                cbManufacturer.Items.AddRange(supplierList.ToArray());
        }

        private void FillWithDataFromObject(Product p, Supplier s)
        {
            //Supplier name
            this.tbSuppierName.Text = s.Name.ToString() ;

            //Elzab product number
            this.tbElzabProductNumber.Text = p.ElzabProductId.ToString();
            this.tbPrice.Text = p.PriceNet.ToString();
            FindTextInComboBoxAndSelect(ref this.cbTax, p.Tax.ToString());
            this.tbMarigin.Text = p.Marigin.ToString();
            this.tbBarCode.Text = p.BarCode.ToString();
            this.rtbProductInfo.Text = p.ProductInfo.ToString();
        }

        //Method used to clear all object (text box, combo box, etc.)  data
        private void ClearAllObjectsData()
        {
            //Supplier name
            this.tbSuppierName.Text = "";
            this.cbManufacturer.SelectedIndex = 0;

            //Elzab product number
            this.cbProductList.Text = "";
            this.tbElzabProductNumber.Text = "";
            this.tbPrice.Text = "";
            this.cbTax.Text = "";
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
        //Show product info events
        #region Show product info events
        private void ShowProductInfo_Load(object sender, EventArgs e)
        {

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);
        }
        #endregion
        //====================================================================================================
        //Manufacturer events
        #region Manifacturer events

        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
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
        #endregion
        //====================================================================================================
        //Product list events
        #region Product List
        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.ProductEntity, this.SupplierEntity) = this.databaseCommands.GetProductAndSupplierEntityByProductName(this.cbProductList.SelectedItem.ToString());
            this.FillWithDataFromObject(this.ProductEntity, this.SupplierEntity);
        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bSave_Click(object sender, EventArgs e)
        {
            //Save current object to database
            this.databaseCommands.EditProduct(this.ProductEntity);
            this.databaseCommands.EditSupplier(this.SupplierEntity);
        }
        #endregion
        //====================================================================================================
        //Supplier Name events
        #region Supplier Name events
        private void tbSuppierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
            
        }
        private void tbSuppierName_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult;
            string text = "Nazwa dostawcy musi mieć maksymalnie 255 znaków oraz może zawierać jedynie cyfry i litery";

            //Accept only letters an numbers with maximal length of 255 chars
            string regPattern = @"^[a-zA-Z0-9]{0,255}$";

            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            validatingResult = ValidateInput(localSender.Text, regPattern);

            //Validaion of input text
            if (!validatingResult)
            {
                localSender.Focus();
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);

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
                localSender.Focus();
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);

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
                localSender.Focus();
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);

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
                localSender.Focus();
                localSender.Text = "";
                errorProvider1.SetError(localSender, text);

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

                this.ProductEntity.Marigin= value;
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Marigin events
        #region Marigin events
        private void cbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProductEntity.Tax = int.Parse(this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", ""));
        }
        #endregion
        
        
        
    }
}
