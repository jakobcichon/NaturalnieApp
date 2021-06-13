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
    public partial class ManufacturersList : UserControl
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
        DataSourceRelated.ManufacturersColumnNames ColumnNames;

        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public ManufacturersList()
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
            this.ColumnNames = new DataSourceRelated.ManufacturersColumnNames();
            InitializeDataTableSchema();

            //Initialize data bindings
            this.BindingDataSource = new BindingSource { DataSource = this.DataSource };

            //Initialize DataGridView
            InitializeDataGridView();

            //Initialize name of current user control
            this.lName.Text = "Lista producentów";
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
                            List<Manufacturer> productManufacturerList = this.databaseCommands.GetAllManufacturersEnts();

                            //Convert to data row
                            foreach (Manufacturer manufacturer in productManufacturerList)
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
            this.ColumnNames.Id = "Numer w bazie danych";
            this.ColumnNames.Name = "Nazwa";
            this.ColumnNames.BarcodePrefix = "Prefix kodu kreskowego";
            this.ColumnNames.Info = "Informacje";

            //Create data source columns
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Id;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.Unique = true;
            column.AllowDBNull = false;
            column.AutoIncrement = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Name;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.Unique = true;
            column.AllowDBNull = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.BarcodePrefix;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.AllowDBNull = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Info;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.AllowDBNull = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

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
        }
        #endregion
        private void advancedDataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Cast the sender
            Zuby.ADGV.AdvancedDataGridView localSender = sender as Zuby.ADGV.AdvancedDataGridView;

            //Get column, row and cell
            DataGridViewColumn column = localSender.Columns[e.ColumnIndex];
            DataColumn dataSourceColumn = ((localSender.DataSource as BindingSource).DataSource as DataTable).Columns[e.ColumnIndex];
            DataGridViewRow row = localSender.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            //Validate if in edit mode
            if (cell.IsInEditMode)
            {
                //If data empty, check if cell can be empty
                if (e.FormattedValue.ToString() == "" || e.FormattedValue == null)
                {
                    if (!dataSourceColumn.AllowDBNull)
                    {
                        e.Cancel = true;
                        row.ErrorText = String.Format("Wartość kolumny '{0}' nie może być pusta!", column.Name);
                        return;
                    }
                    else return;
                }

                //Get validation method and validate
                Func<string, bool> func = this.ColumnNames.GetValidationMethod(column.Name);
                if (func != null)
                {
                    try
                    {
                        func.Invoke(e.FormattedValue.ToString());
                    }
                    catch (Validation.ValidatingFailed ex)
                    {
                        e.Cancel = true;
                        row.ErrorText = ex.Message;
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("Nie można określić metody weryfikacji danych wprowadzonych w kolumnie '{0}'"
                        , column.Name));
                }
            }
        }
        private void advancedDataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Cast the sender
            Zuby.ADGV.AdvancedDataGridView localSender = sender as Zuby.ADGV.AdvancedDataGridView;

            //Get row
            DataGridViewRow row = localSender.Rows[e.RowIndex];
            row.ErrorText = "";
        }
        private void advancedDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Cast the sender
            Zuby.ADGV.AdvancedDataGridView localSender = sender as Zuby.ADGV.AdvancedDataGridView;

            //Get row
            DataGridViewRow row = localSender.Rows[e.RowIndex];
            e.Cancel = true;
            row.ErrorText = e.Exception.Message;

        }

        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bSave_Click(object sender, EventArgs e)
        {
            DataTable edited = this.OrginalDataFromDB.Clone();
            DataTable added = this.OrginalDataFromDB.Clone();
            DataTable deleted = this.OrginalDataFromDB.Clone();

            try
            {
                //Get all differences
                GetTableDiff(this.ColumnNames.Id, this.OrginalDataFromDB, this.DataSource, ref edited, ref added, ref deleted);

                if (edited.Rows.Count > 0 || added.Rows.Count > 0 || deleted.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(string.Format("Uwaga! Znaleziono następujące różnice:\n" +
                        "Zmodifikowano: {0}\n" +
                        "Usunięto: {1}\n" +
                        "Dodano: {2}\n" +
                        "Czy chcesz kontynuować?", edited.Rows.Count.ToString(), deleted.Rows.Count.ToString(), added.Rows.Count.ToString()),
                        "Modyfikacja producentów", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        SaveManufacturerTableChangestoDB(edited, added, deleted);
                        MessageBox.Show("Zapisano!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace);
            }

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

        /// <summary>
        /// Compare a source and target datatables and return the row that are different, added, and removed
        /// </summary>
        /// <param name="dtOld">DataTable to compare</param>
        /// <param name="dtNew">DataTable to compare to dtOld</param>
        /// <param name="dtDifferences">DataTable that would give you the difference</param>
        /// <param name="dtAdded">DataTable that would give you the rows added going from dtOld to dtNew</param>
        /// <param name="dtRemoved">DataTable that would give you the rows removed going from dtOld to dtNew</param>
        public static void GetTableDiff(string mainIndexName, DataTable dtOld, DataTable dtNew, ref DataTable dtDifferences, ref DataTable dtAdded, ref DataTable dtRemoved)
        {

            //Temporary variables
            bool matched;

            dtAdded = dtOld.Clone();
            dtAdded.Clear();
            dtRemoved = dtOld.Clone();
            dtRemoved.Clear();

            //Get index of ID
            int idColumnIndex = dtOld.Columns.IndexOf(mainIndexName);

            //Throw an exception if no column named "Id" found
            if (idColumnIndex < 0) throw new MissingMemberException(
                string.Format("Column named '{0}' does not exist in the {1} table", mainIndexName, dtOld.TableName));

            //Loop throught the rows and find deleted or differences
            foreach (DataRow oldRow in dtOld.Rows)
            {
                matched = false;

                //Find deleted
                foreach (DataRow newRow in dtNew.Rows)
                {
                    if (newRow.ItemArray[idColumnIndex].ToString() == oldRow.ItemArray[idColumnIndex].ToString())
                    {
                        //Check if not modiefied
                        if(!oldRow.ItemArray.SequenceEqual(newRow.ItemArray))
                        {
                            dtDifferences.Rows.Add(newRow.ItemArray);
                        }

                        matched = true;
                        break;
                    }
                }

                if(!matched) dtRemoved.Rows.Add(oldRow.ItemArray);
            }

            //Loop throught the rows and find added new
            foreach (DataRow newRow in dtNew.Rows)
            {
                matched = false;

                //Find deleted
                foreach (DataRow oldRow in dtOld.Rows)
                {
                    if (newRow.ItemArray[idColumnIndex].ToString() == oldRow.ItemArray[idColumnIndex].ToString())
                    {
                        matched = true;
                        break;
                    }
                }

                if (!matched) dtAdded.Rows.Add(newRow.ItemArray);
            }

        }

        
        void SaveManufacturerTableChangestoDB(DataTable dtDifferences, DataTable dtAdded, DataTable dtRemoved)
        {
            //Remove first
            foreach(DataRow row in dtRemoved.Rows)
            {
                string manufacturerName = row.Field<string>(this.ColumnNames.Name);

                //Get Manufacturer product count
                List<string> productsList = this.databaseCommands.GetProductsNameListByManufacturer(manufacturerName);

                //Make sure if allowed to remove related products
                if(productsList.Count() > 0)
                {
                    string message = string.Format("Uwaga! W bazie danych istnieją produkty związane z producentem {0}. " +
                        "Czy chcesz kontynuować i usunąć produkty oraz stany magazynowe? Dane zostaną usunięte nieodwracalnie!\n" +
                        "Yes - produkty zostaną usunięte dla tego producenta.\n" +
                        "No - produkty NIE zostaną usunięte dla tego producenta i program będzie kontynuował.\n" +
                        "Cancel - produkty NIE zostaną usunięte dla tego producenta i program NIE będzie kontynuował.\n", manufacturerName);
                    string title = "Potwierdzenie usunięcie produktów";

                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel);

                    //TODO!!!!!!!!
                    MessageBox.Show("Kuba nie dokończył tego zadania;) Nie usunięto niczego! ;)");
                }
                else
                {
                    this.databaseCommands.DeleteManufacturer(row[this.ColumnNames.Name].ToString());
                }

            }

            //Modifie existing
            foreach (DataRow row in dtDifferences.Rows)
            {
                //Get original entity
                Manufacturer localEntity = this.databaseCommands.GetManufacturerEntityById(Convert.ToInt32(row[this.ColumnNames.Id]));

                //Override with new values
                localEntity.Name = row.Field<string>(this.ColumnNames.Name);
                localEntity.Info = row.Field<string>(this.ColumnNames.Info);
                localEntity.BarcodeEanPrefix = row.Field<string>(this.ColumnNames.BarcodePrefix);

                this.databaseCommands.EditManufacturer(localEntity);
            }

            //Add new
            foreach (DataRow row in dtAdded.Rows)
            {
                //Local entity
                Manufacturer localEntity = new Manufacturer();
                
                //Write values
                localEntity.Name = row.Field<string>(this.ColumnNames.Name);
                localEntity.Info = row.Field<string>(this.ColumnNames.Info);
                localEntity.BarcodeEanPrefix = row.Field<string>(this.ColumnNames.BarcodePrefix);

                this.databaseCommands.AddManufacturer(localEntity);
            }

        }

    }
}
