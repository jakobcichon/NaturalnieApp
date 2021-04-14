using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;
using System.Management;


namespace NaturalnieApp.Forms
{

    public partial class PrintFromStock : Form
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
        private DataSourceRelated.LabelDataSourceColumnNames ColumnNames;

        //Printer instance
        Printer DymoPrinter;
        #endregion

        #region Class constructor
        public PrintFromStock(ref DatabaseCommands commandsObj)
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
            this.ColumnNames.ProductId = "Id produktu";
            this.ColumnNames.LabelBarcode = "Kod kreskowy";
            this.ColumnNames.LabelFinalPrice = "Cena klienta";
            this.ColumnNames.LabelText = "Tekst etykiety";
            this.ColumnNames.NumberOfCopies = "Liczba kopii";
            this.ColumnNames.ModificationDate = "Data modyfikacji";
            this.DataSoruce = new DataTable();

            InitializeAdvancedDataGridView();

            //Set custom format for data time picker
            this.dpDateTo.CustomFormat = "dd/MM/yy HH:mm:ss";
            this.dpFromDate.CustomFormat = "dd/MM/yy HH:mm:ss";

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
        //Method used to update stock quantity
        private void UpdateQuantityOnList()
        {
            int quantity = 0;

            //Get rows to print
            DataRow[] rowsToPrint = this.DataSoruce.Select(this.DataSoruce.DefaultView.RowFilter);

            if (rowsToPrint.Length > 0)
            {

                foreach (DataRow element in rowsToPrint)
                {
                    //Get quantity for each row
                    quantity += element.Field<int>(this.ColumnNames.NumberOfCopies);
                }
            }

            this.tbNumberOfLabels.Text = quantity.ToString();
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
            column.ColumnName = this.ColumnNames.ProductId;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelText;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelFinalPrice;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfCopies;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ModificationDate;
            column.DataType = Type.GetType("System.DateTime");
            column.ReadOnly = false;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSoruce;
            this.DataSoruce.DefaultView.Sort = this.ColumnNames.ProductId + " asc";
            advancedDataGridView1.AutoResizeColumns();
        }
        private void AdvancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = advancedDataGridView1;
            DataTable dataTable = (DataTable)fdgv.DataSource;

            if (fdgv.FilterString.Length > 0)
            {
                dataTable.DefaultView.RowFilter = fdgv.FilterString;
            }
            //Clear Filter
            else
            {
                dataTable.DefaultView.RowFilter = "";
            }
            
            UpdateQuantityOnList();

        }
        private void AdvancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = advancedDataGridView1;
            DataTable dataTable = (DataTable)fdgv.DataSource;

            if (fdgv.SortString.Length > 0)
            {
                dataTable.DefaultView.Sort = fdgv.SortString;
            }
            //Clear Filter
            else
            {
                dataTable.DefaultView.Sort = dataTable.Columns[0].ColumnName + " asc";
            }

        }
        private void advancedDataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateQuantityOnList();
        }
        private void advancedDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateQuantityOnList();
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

            //Set date and time to default value
            DateTime s = DateTime.Now;
            this.dpFromDate.Value = new DateTime(s.Year, s.Month, s.Day, 0, 0, 0);
            this.dpDateTo.Value = new DateTime(s.Year, s.Month, s.AddDays(1).Day, 0, 0, 0);
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
                if (this.dpDateTo.Value < this.dpFromDate.Value) MessageBox.Show("Data początkowa nie może być większa od daty końcowej!");

                //Local variables
                List<Stock> stockList = new List<Stock>();
                List<StockHistory> stockHistoryList = new List<StockHistory>();
                List<int> manufacturersIdList = new List<int>();
                Product productEnt = new Product();

                if (cbManufacturers.SelectedIndex == 0)
                {
                    manufacturersIdList = this.databaseCommands.GetAllManufacturersId();
                }
                else
                {
                    //Get from stock list of products of given manufacturer
                    manufacturersIdList.Add(this.databaseCommands.GetManufacturerIdByName(cbManufacturers.SelectedItem.ToString()));
                }

                //Cleardata
                this.DataSoruce.Rows.Clear();

                foreach (int manufacturerId in manufacturersIdList)
                {
                    if (manufacturerId > 0)
                    {
                        if (!chFromStockHistoryOnly.Checked)
                        {
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
                                rowElement.SetField<int>(this.ColumnNames.ProductId, productEnt.Id);
                                rowElement.SetField<string>(this.ColumnNames.LabelBarcode, productEnt.BarCodeShort);
                                rowElement.SetField<string>(this.ColumnNames.LabelText, productEnt.ElzabProductName);
                                rowElement.SetField<string>(this.ColumnNames.LabelFinalPrice, string.Format("{0:0.00}", productEnt.FinalPrice));
                                rowElement.SetField<int>(this.ColumnNames.NumberOfCopies, element.ActualQuantity);
                                rowElement.SetField<DateTime>(this.ColumnNames.ModificationDate, element.ModificationDate);

                                this.DataSoruce.Rows.Add(rowElement);
                            }
                        }
                        else
                        {
                            stockHistoryList = this.databaseCommands.GetStockHistoryEntsWithManufacturerIdAndDate(manufacturerId, dpFromDate.Value, dpDateTo.Value);

                            foreach (StockHistory element in stockHistoryList)
                            {
                                //Get product entity
                                productEnt = this.databaseCommands.GetProductEntityById(element.ProductId);

                                //Add data to table
                                DataRow rowElement;
                                rowElement = this.DataSoruce.NewRow();

                                //Set row fields
                                rowElement.SetField<string>(this.ColumnNames.No, (this.DataSoruce.Rows.Count + 1).ToString());
                                rowElement.SetField<int>(this.ColumnNames.ProductId, productEnt.Id);
                                rowElement.SetField<string>(this.ColumnNames.LabelBarcode, productEnt.BarCodeShort);
                                rowElement.SetField<string>(this.ColumnNames.LabelText, productEnt.ElzabProductName);
                                rowElement.SetField<string>(this.ColumnNames.LabelFinalPrice, string.Format("{0:0.00}", productEnt.FinalPrice));
                                rowElement.SetField<int>(this.ColumnNames.NumberOfCopies, element.Quantity);
                                rowElement.SetField<DateTime>(this.ColumnNames.ModificationDate, element.DateAndTime);

                                this.DataSoruce.Rows.Add(rowElement);

                            }
                        }
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

            UpdateQuantityOnList();

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            DataRow[] rowsToPrint = this.DataSoruce.Select(this.DataSoruce.DefaultView.RowFilter);

            PrinterRelated.PrintFromRowsByProductId(this.DymoPrinter, rowsToPrint, this.DataSoruce.Columns[ColumnNames.ProductId].Ordinal,
                this.DataSoruce.Columns[ColumnNames.NumberOfCopies].Ordinal, this.databaseCommands);

            this.DymoPrinter = null;

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć okno?", "Zamknięcie okna programu", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Parent.Show();
                this.Dispose();
            }
        }


        #endregion

        private void chFromStockHistoryOnly_CheckedChanged(object sender, EventArgs e)
        {
            //Local variables
            CheckBox localSender = (CheckBox)sender;

            //Add date if date from and to are equal
            if (this.dpDateTo.Value == this.dpFromDate.Value)
            {
                this.dpDateTo.Value = this.dpDateTo.Value.AddDays(1);
            }

            //Show date picker
            if (localSender.Checked)
            {
                tpDateTo.Visible = true;
                tpFromDate.Visible = true;
            }
            else
            {
                tpDateTo.Visible = false;
                tpFromDate.Visible = false;
                //Set date and time to default value
                DateTime s = DateTime.Now;
                this.dpFromDate.Value = new DateTime(s.Year, s.Month, s.Day, 0, 0, 0);
                this.dpDateTo.Value = new DateTime(s.Year, s.Month, s.AddDays(1).Day, 0, 0, 0);
            }

        }
    }
}
