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

        private void ShowProductInfo_Load(object sender, EventArgs e)
        {

            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);
            ;
        }

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

        private void tbSuppierName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int value;
            bool success = int.TryParse(tbSuppierName.Text, out value);
            if (!success)
            {
                //errorProvider1.SetError(tbSuppierName, "Numer w kasie Elzab musi być wartością numeryczną");
            }
        }

        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.ProductEntity, this.SupplierEntity) = this.databaseCommands.GetProductAndSupplierEntityByProductName(this.cbProductList.SelectedItem.ToString());
            this.FillWithDataFromObject(this.ProductEntity, this.SupplierEntity);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            this.databaseCommands.EditProduct(this.ProductEntity);
            ;
        }

        private void tbSuppierName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProductEntity.Tax = int.Parse(this.cbTax.GetItemText(this.cbTax.SelectedItem).ToString().Replace("%", ""));
            ;
        }
    }
}
