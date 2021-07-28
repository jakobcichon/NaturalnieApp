using NaturalnieApp.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;


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
        }

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
            this.ColumnNames.No = "Numer";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.Manufacturer = "Producent";
            this.ColumnNames.CashRegisterProductNumber = "Numer produktu w kasie";
            this.ColumnNames.DateAndTimeOfSales = "Data i czas sprzedaży";
            this.ColumnNames.DailyReportNumber = "Numer raportu dobowego";
            this.ColumnNames.ReceiptNumber = "Numer paragonu";
            this.ColumnNames.PositionOnReceipt = "Numer pozycji na paragonie";
            this.ColumnNames.Quantity = "Ilość sprzedaży";
            this.ColumnNames.PriceOfSales = "Kwota sprzedaży";


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
        #endregion

        private void bUpdate_Click(object sender, System.EventArgs e)
        {



        }

       
        private void dateRelatedSearch1_NewEntSelected(object sender, Common.DateRelatedSearch.NewEntSelectedEventArgs e)
        {
            this.DataSource.Rows.Clear();
            List<HistorySalesRelated.ProductSalesObject> outList = HistorySalesRelated.GetSales(e.StartDate, e.EndDate, this.databaseCommands);

            foreach (HistorySalesRelated.ProductSalesObject obj in outList)
            {
                DataRow row = this.DataSource.NewRow();
                obj.FillInDataRow(row);
                this.DataSource.Rows.Add(row);
            }

            this.advancedDataGridView1.AutoResizeColumns();
        }
    }

}
