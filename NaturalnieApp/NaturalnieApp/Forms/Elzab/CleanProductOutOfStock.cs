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
using System.Data;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace NaturalnieApp.Forms
{
    public partial class CleanProductsOutOfStock : UserControl
    {

        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;

        //Data source
        DataTable DataSource { get; set; }
        DataTable OrginalDataFromDB { get; set; }
        BindingSource BindingDataSource { get; set; }
        DataSourceRelated.CleanProductOutOfStockColumnNames ColumnNames;

        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public CleanProductsOutOfStock()
        {
            InitializeComponent();

            //Initalize backgroundworker
            InitializeBackgroundWorker();
            ActualTaskType = backgroundWorkerTasks.None;

            //Initialize database
            this.databaseCommands = new DatabaseCommands();

            //Initialize data source
            this.DataSource = new DataTable();
            this.OrginalDataFromDB = this.DataSource.Clone();
            this.ColumnNames = new DataSourceRelated.CleanProductOutOfStockColumnNames();
            InitializeDataTableSchema();

            //Initialize data bindings
            this.BindingDataSource = new BindingSource { DataSource = this.DataSource };

            //Initialize DataGridView
            InitializeDataGridView();

            //Initialize name of current user control
            this.lName.Text = "Usuwanie z kasy fiskalnej produktów bez stanów magazynowych";
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
            taskType = (backgroundWorkerTasks)e.Argument;
            DataTable returnDataTable = this.DataSource.Clone();

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
                            List<(Product, Stock, Manufacturer)> product_stock = this.databaseCommands.GetAllElzabProductNumbersToClean();

                            //Convert to data row
                            foreach ((Product, Stock, Manufacturer) joined in product_stock)
                            {
                                DataRow dataRow = returnDataTable.NewRow();
                                dataRow.SetField<int>(this.ColumnNames.Id, joined.Item1.Id);
                                dataRow.SetField<string>(this.ColumnNames.Manufacturer, joined.Item3.Name);
                                dataRow.SetField<string>(this.ColumnNames.ProductName, joined.Item1.ProductName);
                                dataRow.SetField<int?>(this.ColumnNames.ActualElzabNumber, joined.Item1.ElzabProductId);
                                dataRow.SetField<int>(this.ColumnNames.ActualStockQuantity, joined.Item2.ActualQuantity);
                                returnDataTable.Rows.Add(dataRow);
                            }

                            e.Result = returnDataTable;
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<(Product, Stock, Manufacturer)> product_stock = this.databaseCommands.GetAllElzabProductNumbersToClean();

                            foreach ((Product, Stock, Manufacturer) joined in product_stock)
                            {
                                DataRow dataRow = returnDataTable.NewRow();

                                dataRow.SetField<int>(this.ColumnNames.Id, joined.Item1.Id);
                                dataRow.SetField<string>(this.ColumnNames.Manufacturer, joined.Item3.Name);
                                dataRow.SetField<string>(this.ColumnNames.ProductName, joined.Item1.ProductName);
                                dataRow.SetField<int?>(this.ColumnNames.ActualElzabNumber, joined.Item1.ElzabProductId);
                                dataRow.SetField<int>(this.ColumnNames.ActualStockQuantity, joined.Item2.ActualQuantity);
                                returnDataTable.Rows.Add(dataRow);
                            }

                            e.Result = returnDataTable;
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
                            //Get return data from DB
                            this.DataSource.Clear();
                            foreach (DataRow row in (e.Result as DataTable).Rows) this.DataSource.ImportRow(row);
                            this.OrginalDataFromDB = this.DataSource.Copy();
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get return data from DB
                            this.DataSource.Clear();
                            foreach (DataRow row in (e.Result as DataTable).Rows) this.DataSource.ImportRow(row);
                            this.OrginalDataFromDB = this.DataSource.Copy();
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
        private void InitializeDataGridView()
        {
            this.advancedDataGridView1.DataSource = this.BindingDataSource;
            this.advancedDataGridView1.AutoResizeColumns();
            this.advancedDataGridView1.SetDoubleBuffered();
        }
        void InitializeDataTableSchema()
        {
            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.Id = "Numer w bazie danych";
            this.ColumnNames.Manufacturer = "Producent";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.ActualElzabNumber = "Aktualny numer w kasie elzab";
            this.ColumnNames.ActualStockQuantity = "Aktualny ilość w magazynie";

            //Create data source columns
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.No;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.Unique = true;
            column.AllowDBNull = false;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Id;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.Unique = true;
            column.AllowDBNull = true;
            column.AutoIncrement = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Manufacturer;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.Unique = false;
            column.AllowDBNull = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.Unique = true;
            column.AllowDBNull = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ActualElzabNumber;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.AllowDBNull = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ActualStockQuantity;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.AllowDBNull = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

        }

        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void CleanProductsOutOfStock_Load(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Call background worker
            this.ActualTaskType = backgroundWorkerTasks.Init;
            this.backgroundWorker1.RunWorkerAsync(backgroundWorkerTasks.Init);
        }
        #endregion
        private void advancedDataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Renumber no column values if necessary
            UpdateNoColumnValues(this.DataSource, this.ColumnNames.No);
        }

        private void AdvancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = advancedDataGridView1;
            DataTable dataTable = (fdgv.DataSource as BindingSource).DataSource as DataTable;

            if (fdgv.FilterString.Length > 0)
            {
                dataTable.DefaultView.RowFilter = fdgv.FilterString;
            }
            //Clear Filter
            else
            {
                dataTable.DefaultView.RowFilter = "";
            }

        }
        private void AdvancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = advancedDataGridView1;
            DataTable dataTable = (fdgv.DataSource as BindingSource).DataSource as DataTable;

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

        private void UpdateNoColumnValues(DataTable dataTable, string noColumnName)
        {
            //Get number of rows in data source
            int numberOfRows = dataTable.Rows.Count;

            //Get value of No column in last row
            int noValueOfLastRow = dataTable.Rows[numberOfRows - 1].Field<int>(noColumnName);

            //Check if equal. If not renumbere all
            if (numberOfRows != noValueOfLastRow)
            {
                for (int i = 1; i <= numberOfRows; i++)
                {
                    dataTable.Rows[i - 1].SetField<int>(noColumnName, i);
                }
            }
        }

        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bRemoveFromCashRegister_Click(object sender, EventArgs e)
        {
            List<Product> productList = new List<Product>();

            foreach (DataRow element in this.DataSource.Rows)
            {
                int productId = element.Field<int>(this.ColumnNames.Id);
                Product product = this.databaseCommands.GetProductEntityById(productId);

                productList.Add(product);
            }

            this.databaseCommands.CleanAllElzabProductNumberOutOfStock(productList);
            this.bUpdate_Click(sender, e);
        }
        private void bUpdate_Click(object sender, EventArgs e)
        {
            //Disable panel and wait until data from db will be fetched
            this.Enabled = false;

            //Clear filters and sorting string
            this.advancedDataGridView1.CleanFilterAndSort();

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

    }
}
