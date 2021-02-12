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
    public partial class AddManufacturer : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;

        private Supplier SupplierEntity { get; set; }
        private Manufacturer ManufacturerEntity { get; set; }

        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public AddManufacturer(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            this.databaseCommands = commandsObj;
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize object fields
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
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
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
        private bool ValidateAllManufacturerInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {

                if (this.tbManufacturerName.Text != "" && this.tbBarcodePrefix.Text != "" && this.tbMaxNumberOfProducts.Text != ""
                    && this.tbFirstNumberInCashRegister.Text != "" && this.tbLastNumberInCashRegister.Text != "")
                {

                    //Set local variable to true
                    validationSuccess = true;

                    Validation.ManufacturerNameValidation(this.tbManufacturerName.Text);
                    Validation.GeneralNumberValidation(this.tbBarcodePrefix.Text);
                    Validation.GeneralNumberValidation(this.tbMaxNumberOfProducts.Text);
                    Validation.GeneralNumberValidation(this.tbFirstNumberInCashRegister.Text);
                    Validation.GeneralNumberValidation(this.tbLastNumberInCashRegister.Text);
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
        private bool ValidateAllSupplierInputFields()
        {
            //Local variable
            bool validationSuccess;
            try
            {

                if (this.tbSupplierName.Text != "")
                {

                    //Set local variable to true
                    validationSuccess = true;

                    Validation.SupplierNameValidation(this.tbSupplierName.Text);
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
            this.tbManufacturerName.Text = "";
            this.tbBarcodePrefix.Text = "";
            this.tbMaxNumberOfProducts.Text = "";
            this.tbFirstNumberInCashRegister.Text = "";
            this.tbLastNumberInCashRegister.Text = "";
            this.rtbManufacturerInfo.Text = "";
            this.tbSupplierName.Text = "";
            this.rtbSupplierInfo.Text = "";
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
        private void AddManufacturer_Load(object sender, EventArgs e)
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

            if ((keyData == Keys.Enter))
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
        private void bSaveManufacturer_Click(object sender, EventArgs e)
        {
            //Local variables
            bool validatingSuccess;

            //Validate all input before saving
            validatingSuccess = ValidateAllManufacturerInputFields();

            if (validatingSuccess)
            {
                try
                {

                    if (tbManufacturerName.Text != "")
                    {
                        //Save current object to database
                        this.databaseCommands.AddManufacturer(this.ManufacturerEntity);

                        //Show message box
                        MessageBox.Show("Producent '" + this.ManufacturerEntity.Name + "' został zapisany!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Call update event
            bUpdate_Click(sender, e);
        }
        private void bSaveSupplier_Click(object sender, EventArgs e)
        {
            //Local variables
            bool validatingSuccess;

            //Validate all input before saving
            validatingSuccess = ValidateAllSupplierInputFields();

            if (validatingSuccess)
            {
                try
                {
                    if (tbSupplierName.Text != "")
                    {
                        //Save current object to database
                        this.databaseCommands.AddSupplier(this.SupplierEntity);

                        //Show message box
                        MessageBox.Show("Dostawca '" + this.SupplierEntity.Name + "' został zapisany!");
                    }
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
        //Manufacturer name events
        #region Manifacturer name events
        private void tbManufacturerName_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

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
        private void tbManufacturerName_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //Manufacturer name events
        #region Barcode prefix events
        private void tbBarcodePrefix_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                if(localSender.Text != "")
                {
                    Validation.GeneralNumberValidation(localSender.Text);
                    this.ManufacturerEntity.BarcodeEanPrefix = localSender.Text;
                    errorProvider1.Clear();
                }
                else
                {
                    this.ManufacturerEntity.BarcodeEanPrefix = "";
                }

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
        private void tbBarcodePrefix_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //Maximal number of products events
        #region Maximal number of products events
        private void tbMaxNumberOfProducts_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.GeneralNumberValidation(localSender.Text);
                this.ManufacturerEntity.MaxNumberOfProducts = Convert.ToInt32(localSender.Text);
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
        private void tbMaxNumberOfProducts_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //First number in cash register events
        #region First number in cash register events
        private void tbFirstNumberInCashRegister_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

            //Check if input match to define pattern
            try
            {
                Validation.GeneralNumberValidation(localSender.Text);
                this.ManufacturerEntity.FirstNumberInCashRegister = Convert.ToInt32(localSender.Text);
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
        private void tbFirstNumberInCashRegister_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion
        //====================================================================================================
        //ProductInfo events
        #region Manufacturer Info events
        private void rtbManufacturerInfo_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult = false;
            string text = "Informacja o producencie może zawierać maksymalnie 1024 znaki!";

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
                this.ManufacturerEntity.Info = localSender.Text;
                errorProvider1.Clear();
            }
        }
        #endregion
        //====================================================================================================
        //Manufacturer name events
        #region Supplier name events
        private void tbSupplierName_Validating(object sender, EventArgs e)
        {
            //Cast the sender for an object
            TextBox localSender = (TextBox)sender;

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
        private void tbSupplierName_MouseHover(object sender, EventArgs e)
        {
            TextBox localSender = (TextBox)sender;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(localSender, localSender.Text);
        }
        #endregion

        //====================================================================================================
        //ProductInfo events
        #region Manufacturer Info events
        private void rtbSupplierInfo_Validating(object sender, EventArgs e)
        {
            //Local variables
            bool validatingResult = false;
            string text = "Informacja o dostawcy może zawierać maksymalnie 1024 znaki!";

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
                this.SupplierEntity.Info = localSender.Text;
                errorProvider1.Clear();
            }
        }
        #endregion
    }
}
