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

namespace NaturalnieApp.Forms
{
    public partial class ManufacturersList : UserControl
    {

        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;
        BackgroundWorker backgroundWorker1;
        backgroundWorkerTasks ActualTaskType;
        private Manufacturer ManufacturerEntity { get; set; }

        //Data source
        DataTable DataSource { get; set; }
        BindingSource BindingDataSource { get; set; }
        DataSourceRelated.ManufacturersColumnNames ColumnNames;

        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public ManufacturersList()
        {
            InitializeComponent();
            InitializeBackgroundWorker();

            ActualTaskType = backgroundWorkerTasks.None;

            this.databaseCommands = new DatabaseCommands();

            this.DataSource = new DataTable();
            this.BindingDataSource = new BindingSource { DataSource = this.DataSource };

            //Initialize object fields
            this.ManufacturerEntity = new Manufacturer();

            InitializeDataGridView();
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
            DataTable returnDataTable = new DataTable();
            returnDataTable = this.DataSource;

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
                            List<Manufacturer> productManufacturerList = this.databaseCommands.GetAllManufacturersEnts();

                            //Convert to data row
                            foreach(Manufacturer manufacturer in productManufacturerList)
                            {
                                DataRow dataRow = returnDataTable.NewRow();
                                dataRow.SetField<int>(this.ColumnNames.Id, manufacturer.Id);
                                dataRow.SetField<string>(this.ColumnNames.Name, manufacturer.Name);
                                dataRow.SetField<string>(this.ColumnNames.BarcodePrefix, manufacturer.BarcodeEanPrefix);
                                dataRow.SetField<string>(this.ColumnNames.Info, manufacturer.Info);
                                returnDataTable.Rows.Add(dataRow);
                            }

                           e.Result = returnDataTable;
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            List<Manufacturer> productManufacturerList = this.databaseCommands.GetAllManufacturersEnts();

                            //Convert to data row
                            foreach (Manufacturer manufacturer in productManufacturerList)
                            {
                                DataRow dataRow = this.DataSource.NewRow();
                                dataRow.SetField<int>(this.ColumnNames.Id, manufacturer.Id);
                                dataRow.SetField<string>(this.ColumnNames.Name, manufacturer.Name);
                                dataRow.SetField<string>(this.ColumnNames.BarcodePrefix, manufacturer.BarcodeEanPrefix);
                                dataRow.SetField<string>(this.ColumnNames.Info, manufacturer.Info);
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
                            this.DataSource = (e.Result as DataTable);
                        }
                        break;
                    case backgroundWorkerTasks.Update:
                        if (this.databaseCommands.ConnectionStatus)
                        {
                            //Get return data from DB
                            this.DataSource = (e.Result as DataTable);
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
        private void UpdateControl(ref TextBox dummyForControl)
        {
            //this.Select();
            this.Focus();
            dummyForControl.Select();
        }
        private void InitializeDataGridView()
        {
            //Initialize daa grid view
            this.ColumnNames.Id = "Numer w bazie danych";
            this.ColumnNames.Name = "Nazwa";
            this.ColumnNames.BarcodePrefix = "Prefix kodu kreskowego";
            this.ColumnNames.Info = "Informacje";

            //Create data source columns
            DataColumn column = new DataColumn();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Id;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Name;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.BarcodePrefix;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Info;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            this.advancedDataGridView1.DataSource = this.BindingDataSource;

            this.advancedDataGridView1.AutoResizeColumns();
            this.advancedDataGridView1.SetDoubleBuffered();
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
    }
}
