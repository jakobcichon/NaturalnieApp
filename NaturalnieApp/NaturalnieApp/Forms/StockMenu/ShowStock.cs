using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;
using System.Management;
using NaturalnieApp.PdfToExcel;
using System.IO;
using ElzabCommands;
using static NaturalnieApp.Program;

namespace NaturalnieApp.Forms
{

    public partial class ShowStock : Form
    {
        #region Object fields
        //Set the instance fields
        private DatabaseCommands databaseCommands { get; set; }

        //Backgroundworker
        private BackgroundWorker backgroundWorker1 { get; set; }
        private backgroundWorkerTasks ActualTaskType { get; set; }

        //Global variables
        private List<string> ManufacturersList { get; set; }

        //Auto complete string collections
        private AutoCompleteStringCollection ManufacturerListCollection { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.AddToStockDataSourceColumnNames ColumnNames;

        //Data schema for exported invenotry list
        private DataSourceRelated.InventoryExportColumnNames InventoryColumnNames;
        #endregion

        #region Class constructor
        public ShowStock(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Background worker
            InitializeBackgroundWorker();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize globar variables
            this.ManufacturersList = new List<string>();

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.ElzabNumber = "Numer w kasie";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.AddDate = "Data dodania";
            this.ColumnNames.ExpirenceDate = "Data ważności";
            this.ColumnNames.NumberOfPieces = "Ilość";
            this.DataSoruce = new DataTable();

            InitializeAdvancedDataGridView();

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
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        returnList.Add(productManufacturerList);
                        e.Result = returnList;
                    }
                    break;
                case backgroundWorkerTasks.Update:
                    if (this.databaseCommands.ConnectionStatus)
                    {
                        List<string> productManufacturerList = this.databaseCommands.GetManufacturersNameList();
                        returnList.Add(productManufacturerList);
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
                            FillWithInitialDataFromObject((List<string>)returnList[0]);
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get product name list and product suppliers
                            //check if Database reachable 
                            List<List<string>> returnList = new List<List<string>>();
                            returnList = (List<List<string>>)e.Result;
                            FillWithInitialDataFromObject((List<string>)returnList[0]);
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

        //Metchod use to find and select string in ComboBox
        private void FindTextInComboBoxAndSelect(ref ComboBox obj, string textToFind)
        {
            //Find search tex index
            int index = obj.FindStringExact(textToFind);
            obj.SelectedIndex = index;

        }

        private void FillWithInitialDataFromObject(List<string> manufacturerList)
        {
            //Add fetched data to proper combo box
            this.ManufacturerListCollection = new AutoCompleteStringCollection();
            this.ManufacturersList = this.databaseCommands.GetManufacturersNameList();
            this.ManufacturerListCollection.AddRange(this.ManufacturersList.ToArray());
            this.cbManufacturers.AutoCompleteCustomSource = this.ManufacturerListCollection;
            this.cbManufacturers.Items.AddRange(this.ManufacturersList.ToArray());
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
        //Advanced data gid view
        #region Advanced data gid view

        /// <summary>
        /// Method used to initialize advanced data grid view
        /// </summary>
        private void InitializeAdvancedDataGridView()
        {
            //Create data source columns
            DataColumn column = new DataColumn();

            column.ColumnName = this.ColumnNames.No;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ElzabNumber;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfPieces;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.AddDate;
            column.DataType = Type.GetType("System.DateTime");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ExpirenceDate;
            column.DataType = Type.GetType("System.DateTime");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSoruce;

            advancedDataGridView1.AutoResizeColumns();
        }

        private void InitializeInventoryDataTable(ref DataTable dataTable)
        {

            //Initialize daa grid view
            this.InventoryColumnNames.No = "Lp";
            this.InventoryColumnNames.ManufacturerName = "Nazwa producenta";
            this.InventoryColumnNames.ProductName = "Nazwa produktu";
            this.InventoryColumnNames.ProductBarcode = "Kod kreskowy";
            this.InventoryColumnNames.PriceNet = "Cena netto";
            this.InventoryColumnNames.Tax = "VAT";
            this.InventoryColumnNames.Discount = "Rabat dostawcy";
            this.InventoryColumnNames.PriceNetWithDiscount = "Cena netto po rabacie";
            this.InventoryColumnNames.FinalPrice = "Cena brutto";
            this.InventoryColumnNames.ProductQunatity = "Ilość";
            this.InventoryColumnNames.ProductValueNet= "Wartość netto";


            //Create data source columns
            DataColumn column = new DataColumn();

            column.ColumnName = this.InventoryColumnNames.No;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            dataTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.ManufacturerName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            dataTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.ProductBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            dataTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.PriceNet;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.Tax;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.Discount;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.PriceNetWithDiscount;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.FinalPrice;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.ProductQunatity;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = this.InventoryColumnNames.ProductValueNet;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            dataTable.Columns.Add(column);
        }
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void AddToStock_Load(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        private void AddToStock_KeyDown(object sender, KeyEventArgs e)
        {
            Control localControl = (Control)sender;

            if (e.KeyCode == Keys.Enter)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (e.KeyCode == Keys.Escape)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bShow_Click(object sender, EventArgs e)
        {
            if (cbManufacturers.SelectedItem != null)
            {
                //Local variables
                List<Stock> stockList = new List<Stock>();
                Product productEnt = new Product();
                int quantity = 0;

                if (cbManufacturers.SelectedIndex == 0)
                {
                    //Cleardata
                    this.DataSoruce.Rows.Clear();

                    stockList = this.databaseCommands.GetAllStockEnts();

                    foreach (Stock element in stockList)
                    {
                        //Get product entity
                        productEnt = this.databaseCommands.GetProductEntityById(element.ProductId);

                        //Add data to table
                        DataRow rowElement;
                        rowElement = this.DataSoruce.NewRow();

                        //Set row fields
                        rowElement.SetField<string>(this.ColumnNames.No, (this.DataSoruce.Rows.Count + 1).ToString());
                        rowElement.SetField<int>(this.ColumnNames.ElzabNumber, productEnt.ElzabProductId);
                        rowElement.SetField<string>(this.ColumnNames.ProductName, productEnt.ProductName);
                        rowElement.SetField<DateTime>(this.ColumnNames.AddDate, element.ModificationDate);
                        rowElement.SetField<DateTime>(this.ColumnNames.ExpirenceDate, element.ExpirationDate);
                        rowElement.SetField<int>(this.ColumnNames.NumberOfPieces, element.ActualQuantity);

                        quantity += element.ActualQuantity;

                        this.DataSoruce.Rows.Add(rowElement);

                    }

                    //Show number of product and quantity
                    this.tbNumberOfProducts.Text = this.DataSoruce.Rows.Count.ToString();
                    this.tbStockQuantity.Text = quantity.ToString();

                    this.advancedDataGridView1.AutoResizeColumns();
                }
                else
                {

                    //Get from stock list of products of given manufacturer
                    int manufacturerId = this.databaseCommands.GetManufacturerIdByName(cbManufacturers.SelectedItem.ToString());
                    if (manufacturerId > 0)
                    {
                        //Cleardata
                        this.DataSoruce.Rows.Clear();

                        stockList = this.databaseCommands.GetStockEntsWithManufacturerId(manufacturerId);
                        
                        foreach (Stock element in stockList)
                        {
                            //Get product entity
                            productEnt = this.databaseCommands.GetProductEntityById(element.ProductId);

                            //Add data to table
                            DataRow rowElement;
                            rowElement = this.DataSoruce.NewRow();

                            //Set row fields
                            rowElement.SetField<string>(this.ColumnNames.No, (this.DataSoruce.Rows.Count + 1).ToString());
                            rowElement.SetField<int>(this.ColumnNames.ElzabNumber, productEnt.ElzabProductId);
                            rowElement.SetField<string>(this.ColumnNames.ProductName, productEnt.ProductName);
                            rowElement.SetField<DateTime>(this.ColumnNames.AddDate, element.ModificationDate);
                            rowElement.SetField<DateTime>(this.ColumnNames.ExpirenceDate, element.ExpirationDate);
                            rowElement.SetField<int>(this.ColumnNames.NumberOfPieces, element.ActualQuantity);

                            quantity += element.ActualQuantity;

                            this.DataSoruce.Rows.Add(rowElement);

                        }

                        //Show number of product and quantity
                        this.tbNumberOfProducts.Text = this.DataSoruce.Rows.Count.ToString();
                        this.tbStockQuantity.Text = quantity.ToString();

                        this.advancedDataGridView1.AutoResizeColumns();

                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono producenta!");
                    }

                }


            }
            else
            {
                MessageBox.Show("Najpierw należy wybrać porducenta!");
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }

        private void bClose_Click(object sender, EventArgs e)
        {

            this.Parent.Show();
            this.Dispose();
        }


        private void bSaveToFile_Click(object sender, EventArgs e)
        {
            string tempString = ("Stan magazynowy " + DateTime.Now).Replace("/", "_");
            tempString = tempString.Replace(":", "_");
            saveFileDialog1.FileName = tempString;
            saveFileDialog1.Filter = "Plik programu excel | *.xlsb";
            saveFileDialog1.DefaultExt = "xlsb";
            //Open folder dialog browser
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //File string
                string fileString = saveFileDialog1.FileName;

                //Check extension
                string extension = Path.GetExtension(fileString);
                if (extension == "" || extension == ".xlsb")
                {
                    if (extension == "")
                    {
                        extension = ".xlsb";
                        fileString += extension;
                    }

                    List<int> productsIds = new List<int>();
                    foreach (DataRow row in this.DataSoruce.Rows)
                    {
                        int productId = this.databaseCommands.GetProductIdByName(row.Field<string>(this.ColumnNames.ProductName));
                        productsIds.Add(productId);
                    }

                    DataTable dataTable = FetchInventoryDataFromDB(productsIds);

                    //Test purpose
                    ExcelBase.ExportToExcel(dataTable, fileString);
                }
                else
                {
                    MessageBox.Show("Błąd! Dopuszczalne rozszerzenie pliku to .xlsb");
                }


                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }


        }

        private DataTable FetchInventoryDataFromDB(List<int> productsIdsToRead)
        {

            DataTable dataTable = new DataTable();
            InitializeInventoryDataTable(ref dataTable);

            foreach(int id in productsIdsToRead)
            {
                //Fetch data from DB for given product ID
                Product productEntity = this.databaseCommands.GetProductEntityByProductId(id);
                Tax taxEntity = this.databaseCommands.GetTaxByProductName(productEntity.ProductName);
                Manufacturer manufacturerEntity = this.databaseCommands.GetManufacturerByProductName(productEntity.ProductName);
                int productQuantityInStock = this.databaseCommands.GetStockQuantity(productEntity.Id);

                //Create new data row
                DataRow localDataRow;
                localDataRow = dataTable.NewRow();

                //Fill data row with data
                localDataRow.SetField<string>(this.InventoryColumnNames.ManufacturerName, manufacturerEntity.Name);
                localDataRow.SetField<string>(this.InventoryColumnNames.ProductName, productEntity.ProductName);
                localDataRow.SetField<string>(this.InventoryColumnNames.ProductBarcode, productEntity.BarCode);
                localDataRow.SetField<string>(this.InventoryColumnNames.PriceNet, productEntity.PriceNet.ToString());
                localDataRow.SetField<int>(this.InventoryColumnNames.Tax, taxEntity.TaxValue);
                localDataRow.SetField<int>(this.InventoryColumnNames.Discount, productEntity.Discount);
                localDataRow.SetField<string>(this.InventoryColumnNames.PriceNetWithDiscount, productEntity.PriceNetWithDiscount.ToString());
                localDataRow.SetField<string>(this.InventoryColumnNames.FinalPrice, productEntity.FinalPrice.ToString());
                localDataRow.SetField<int>(this.InventoryColumnNames.ProductQunatity, productQuantityInStock);
                float productValue = (productEntity.PriceNetWithDiscount * productQuantityInStock);
                localDataRow.SetField<float>(this.InventoryColumnNames.ProductValueNet, productValue);

                //Add row to datatable
                dataTable.Rows.Add(localDataRow);
            }

            return dataTable;

        }

        #endregion

        private void bGenerateCashRegisterProductList_Click(object sender, EventArgs e)
        {
            //Get all product from DB
            List<string> productNameList = new List<string>();
            List<Product> productsList = new List<Product>();
            if (cbManufacturers.SelectedItem.ToString() == "Wszyscy")
            {
                productNameList = this.databaseCommands.GetProductsNameList();
            }
            else if (cbManufacturers.SelectedItem != null)
            {
                productNameList = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturers.SelectedItem.ToString());
            }


                if (productNameList.Count > 0 && productNameList.Count < 4096)
            {
                foreach (string productName in productNameList)
                {
                    productsList.Add(this.databaseCommands.GetProductEntityByProductName(productName));
                }

                ElzabCommand_ZTOWAR ZapisTowaru = new ElzabCommand_ZTOWAR(GlobalVariables.ElzabCommandPath, 1);
                ElzabCommand_ZDBARKOD ZapisDodatkowychBcod = new ElzabCommand_ZDBARKOD(GlobalVariables.ElzabCommandPath, 1);

                foreach (Product product in productsList)
                {
                    List<string> attributesValues = new List<string>();
                    List<string> attributesValues2 = new List<string>();
                    //nr_tow
                    attributesValues.Add(product.ElzabProductId.ToString());
                    //naz_tow
                    attributesValues.Add(product.ElzabProductName);
                    //ST
                    int taxValue = this.databaseCommands.GetTaxByProductName(product.ProductName).TaxValue;
                    attributesValues.Add(ElzabRelated.TranslateTaxValueToCashRegisterGroup(taxValue));
                    //GR
                    attributesValues.Add("1");
                    //MP
                    attributesValues.Add("2");
                    //JM
                    attributesValues.Add("1");
                    //BL
                    attributesValues.Add("0");
                    //bkod 
                    //cena
                    string formatedString = String.Format("{0:0.00}", product.FinalPrice);
                    formatedString = formatedString.Replace(".", "");
                    attributesValues.Add(formatedString);
                    //OP
                    attributesValues.Add("0");


                    if(product.BarCode != product.BarCodeShort)
                    {
                        attributesValues2.Add(product.ElzabProductId.ToString());
                        attributesValues2.Add(product.BarCodeShort);
                        ZapisDodatkowychBcod.DataToElzab.AddElement(product.ElzabProductId.ToString());
                        ZapisDodatkowychBcod.DataToElzab.ChangeAllElementValues(product.ElzabProductId.ToString(), attributesValues2.ToArray());
                    }


                    ZapisTowaru.DataToElzab.AddElement(product.ElzabProductId.ToString());
                    ZapisTowaru.DataToElzab.ChangeAllElementValues(product.ElzabProductId.ToString(), attributesValues.ToArray());
                }

                ZapisTowaru.ExecuteCommand();
                ZapisDodatkowychBcod.ExecuteCommand();
            }
            else
            {
                MessageBox.Show("Maksymalna ilość towarów do zapisania to 0-4095!");
            }
        }
    }
}
