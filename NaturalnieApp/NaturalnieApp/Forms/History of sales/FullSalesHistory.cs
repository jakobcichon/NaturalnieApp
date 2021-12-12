using NaturalnieApp.Database;
using NaturalnieApp.PdfToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using static NaturalnieApp.HistorySalesRelated;

namespace NaturalnieApp.Forms
{
    
    public partial class FullSalesHistory : UserControl
    {
        /// <summary>
        /// Class properties
        /// </summary>
        DatabaseCommands databaseCommands { get; set; }

        DataSourceRelated.ProductSalesHistoryColumnNames ColumnNames;

        DataTable DataSource { get; set; }
        BindingSource BindingDataSource { get; set; }
        public BackgroundWorker DbBackgroundWorker { get; private set; }
        public bool UpdateSummarizedResults { get; set; } = false;

        /// <summary>
        /// Class constructor
        /// </summary>
        public FullSalesHistory()
        {
            //Initialize component
            InitializeComponent();

            //Initialize database commands
            databaseCommands = new DatabaseCommands();

            //Initialize name of current user control
            this.lName.Text = "Pełna historia sprzedaży";

            //Initialize data source
            this.DataSource = new DataTable();
            this.ColumnNames = new DataSourceRelated.ProductSalesHistoryColumnNames();
            InitializeDataTableSchema();

            //Initialize data bindings
            this.BindingDataSource = new BindingSource { DataSource = this.DataSource };

            //Initialize DataGridView
            InitializeDataGridView();

            //Initialize backgroundworker
            InitializeBackgroundWorker();

            //Hide progress panel
            HideProgressPanel();
        }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.DbBackgroundWorker = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.DbBackgroundWorker.DoWork += this.DbBackgroundWorker_DoWork;
            // this event will define what the worker will do when finished
            this.DbBackgroundWorker.RunWorkerCompleted += this.DbBackgroundWorker_RunWorkerCompleted;

            //
            this.DbBackgroundWorker.WorkerReportsProgress = true;
            this.DbBackgroundWorker.ProgressChanged += this.DbBackgroundWorker_ProgressChanged;

        }

        private void DbBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress _updateObject = e.UserState as UpdateProgress;

            if (_updateObject != null)
            {
                UpdateProgressPanelValues(_updateObject.progressText, _updateObject.percentageValue);
                return;
            }

            if (e.UserState is decimal)
            {
                string _value = Convert.ToString((decimal)e.UserState);
                UpdateProgressPanelValues(percentages: _value);
                return;
            }

        }

        private void DbBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorkerResultData resultData = e.Result as BackgroundWorkerResultData;

            this.BindingDataSource.DataSource = null;
            this.DataSource = resultData.DataToReturn;
            this.BindingDataSource.DataSource = this.DataSource;

            this.advancedDataGridView1.AutoResizeColumns();

            UpdateSummarizedData(resultData.SummarizedData);

            EnableDataGridView();

            HideProgressPanel();
        }

        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateGetSalesProgress reportProgressMethod = (sender as BackgroundWorker).ReportProgress;
            BackgroundWorkerInputData _inputData = e.Argument as BackgroundWorkerInputData;
            DatabaseCommands _databaseCommands = _inputData.DatabaseCommand;

            UpdateProgress _updateObject = new UpdateProgress() { percentageValue = "0.0", progressText = "Pobieranie informacji o sprzedaży z bazy danych" };

            reportProgressMethod.Invoke(0, _updateObject);

            List<HistorySalesRelated.ProductSalesObject> outList = HistorySalesRelated.GetSales(
                _inputData.EventData.StartDate, _inputData.EventData.EndDate, _inputData.EventData.SelectedManufacturer, _databaseCommands,
                reportProgressMethod);

            SummarizedData _summarizedData = new SummarizedData();

            _updateObject.progressText = "Dodawanie pobranych informacji do widoku danych...";
            _updateObject.percentageValue = "0.0";
            reportProgressMethod.Invoke(0, _updateObject);

            DataTable _dataSource = new DataTable();
            _dataSource = _inputData.DataSource.Clone();
 

            DateTime _endTime = GetDeltaTime((float)2.0);

            int i = 0;
            foreach (ProductSalesObject obj in outList)
            {
                DataRow row = _dataSource.NewRow();
                obj.FillInDataRow(row);
                _dataSource.Rows.Add(row);

                _summarizedData.SummarizedProfit += obj.Profit;
                _summarizedData.NumberOfSales += 1;
                _summarizedData.NumberOfProducts += Convert.ToDecimal(obj.Quantity);
                _summarizedData.SummarizedSale += Convert.ToDecimal(obj.PriceOfSales);
                _summarizedData.SummarizedDiscount += Math.Round(Convert.ToDecimal(obj.PriceOnCashRegister - obj.PriceOfSales),2);

                if (CheckIfCurrentTimeGratherOrEqual(_endTime))
                {
                    decimal _actualProgress = EvaluateProgressInPercentage(i, outList.Count);
                    reportProgressMethod.Invoke(0, _actualProgress);
                    _endTime = GetDeltaTime((float)2.0);
                }

                i++;

            }

            e.Result = new BackgroundWorkerResultData { SummarizedData = _summarizedData, DataToReturn = _dataSource};
        }
        #endregion

        #region General methods
        private void ShowProgressPanel()
        {
            this.pProgressPanel.Visible = true;
        }

        private void HideProgressPanel()
        {
            this.pProgressPanel.Visible = false;
        }

        private void UpdateProgressPanelValues(string text=null, string percentages=null)
        {
            if (percentages != null )this.lPercentageProgress.Text = percentages + " %";
            if (text != null) this.lProgressText.Text = text;
        }

        private void UpdateSummarizedData(SummarizedData summarized)
        {
            this.tbSummarizedProfit.Text = Convert.ToString(summarized.SummarizedProfit);
            this.tbNumberOfSales.Text = Convert.ToString(summarized.NumberOfSales);
            string _numberOfProducts = Convert.ToString(summarized.NumberOfProducts);
            this.tbNumberOfProducts.Text = _numberOfProducts.Split('.')[0];
            this.tbSummarizedSale.Text = Convert.ToString(summarized.SummarizedSale);
            this.tbSummarizedDiscount.Text = Convert.ToString(summarized.SummarizedDiscount);

        }

        private void DisableDataGridView()
        {
            this.advancedDataGridView1.Enabled = false;
        }

        private void EnableDataGridView()
        {
            this.advancedDataGridView1.Enabled = true;
        }

        private void InitializeDataGridView()
        {
            this.advancedDataGridView1.DataSource = this.BindingDataSource;
            this.advancedDataGridView1.AutoResizeColumns();
            this.advancedDataGridView1.SetDoubleBuffered();
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = true;
        }
        void InitializeDataTableSchema()
        {
            //Initialize daa grid view
            this.ColumnNames.No = "Numer";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.Manufacturer = "Producent";
            this.ColumnNames.CashRegisterProductNumber = "Numer produktu w kasie";
            this.ColumnNames.DateAndTimeOfSales = "Data i czas sprzedaży";
            this.ColumnNames.DailyReportNumber = "Numer raportu dobowego";
            this.ColumnNames.ReceiptNumber = "Numer paragonu";
            this.ColumnNames.PositionOnReceipt = "Numer pozycji na paragonie";
            this.ColumnNames.Quantity = "Ilość sprzedaży";
            this.ColumnNames.PriceOfSales = "Sumaryczna kwota sprzedaży";
            this.ColumnNames.PriceOnCashRegister = "Cena produktu przed rabatami";
            this.ColumnNames.PriceNetWithDiscount = "Cena netto (po zniżkach)";
            this.ColumnNames.Discount = "Udzielony rabat %";
            this.ColumnNames.Profit = "Zysk";


            //Create data source columns
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Manufacturer;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.CashRegisterProductNumber;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.DateAndTimeOfSales;
            column.DataType = Type.GetType("System.DateTime");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.DailyReportNumber;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ReceiptNumber;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PositionOnReceipt;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Quantity;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceOfSales;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceOnCashRegister;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceNetWithDiscount;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Discount;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Profit;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();
        }
        #endregion

        #region Advanced data grid
        private void advancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            this.DataSource.DefaultView.RowFilter = e.FilterString;
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
            Zuby.ADGV.AdvancedDataGridView _localSender = sender as Zuby.ADGV.AdvancedDataGridView;
            if (this.UpdateSummarizedResults)
            {
                SummarizedData _summarizedData = GetSummarizedGridViewData((_localSender.DataSource as BindingSource).DataSource as DataTable);
                UpdateSummarizedData(_summarizedData);
                this.UpdateSummarizedResults = false;
            }
        }
        private void advancedDataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView _localSender = sender as Zuby.ADGV.AdvancedDataGridView;

            int i = 1;
            foreach (DataGridViewRow row in _localSender.SelectedRows)
            {

                if (row == e.Row)
                {
                    if (i >= _localSender.SelectedRows.Count) this.UpdateSummarizedResults = true;
                }
                i++;
            }
        }
        #endregion

        private void bUpdate_Click(object sender, System.EventArgs e)
        {

            EnableDataGridView();

        }


        private void dateRelatedSearch1_NewEntSelected(object sender, Common.DateRelatedSearch.NewEntSelectedEventArgs e)
        {
            DisableDataGridView();

            BackgroundWorkerInputData _dataToWorker = new BackgroundWorkerInputData();
            _dataToWorker.DataSource = this.DataSource;
            _dataToWorker.DatabaseCommand = this.databaseCommands;
            _dataToWorker.EventData = e;

            if (this.DbBackgroundWorker.IsBusy == false)
            {
                UpdateProgressPanelValues("Uruchamianie procesów...", "0.00");
                ShowProgressPanel();
                this.DbBackgroundWorker.RunWorkerAsync(_dataToWorker);
            }
            else
            {
                MessageBox.Show("Trwa pobieranie danych z bazy. Poczekaj na zakończenie tego procesu...");
            }


        }

        private void bSaveToFile_Click(object sender, EventArgs e)
        {
            string tempString = ("Sprzedaż " + DateTime.Now).Replace("/", "_");
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

                    //Test purpose
                    ExcelBase.ExportToExcel(this.DataSource, fileString);
                }
                else
                {
                    MessageBox.Show("Błąd! Dopuszczalne rozszerzenie pliku to .xlsb");
                }
            }


        }

        private SummarizedData GetSummarizedGridViewData(DataTable dataToCheck)
        {
            SummarizedData _summarizedData = new SummarizedData();

            int i = 0;
            foreach (DataRow row in dataToCheck.Rows)
            {
                _summarizedData.SummarizedProfit += Convert.ToDecimal(row.Field<Single>(this.ColumnNames.Profit));
                _summarizedData.NumberOfSales += 1;
                _summarizedData.NumberOfProducts += Convert.ToDecimal(row.Field<string>(this.ColumnNames.Quantity));
                _summarizedData.SummarizedSale += Convert.ToDecimal(row.Field<Single>(this.ColumnNames.PriceOfSales));
                _summarizedData.SummarizedDiscount += Convert.ToDecimal(Math.Round(
                    row.Field<Single>(this.ColumnNames.PriceOnCashRegister) - row.Field<Single>(this.ColumnNames.PriceOfSales),
                    2));

                i++;
            }

            return _summarizedData;
        }
    }

    public class BackgroundWorkerInputData
    {
        public Common.DateRelatedSearch.NewEntSelectedEventArgs EventData { get; set; }
        public DataTable DataSource { get; set; }
        public DatabaseCommands DatabaseCommand { get; set; }

    }

    public class SummarizedData
    {

        public decimal SummarizedProfit { get; set; } = (decimal)0.0;
        public int NumberOfSales { get; set; } = 0;
        public decimal NumberOfProducts { get; set; } = 0;
        public decimal SummarizedSale { get; set; } = (decimal)0.0;
        public decimal SummarizedDiscount { get; set; } = (decimal)0.0;
    }

    public class BackgroundWorkerResultData
    {
        public SummarizedData SummarizedData { get; set; }
        public DataTable DataToReturn { get; set; }
    }

    public class UpdateProgress
    {
        public string percentageValue { get; set; } = "0.0";
        public string progressText { get; set; } = "Default text";
    }



}
