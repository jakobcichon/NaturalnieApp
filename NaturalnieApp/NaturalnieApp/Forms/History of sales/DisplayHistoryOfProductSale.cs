using NaturalnieApp.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;


namespace NaturalnieApp.Forms
{
  
    public partial class DisplayHistoryOfProductSale : UserControl
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
        public DisplayHistoryOfProductSale()
       {
            //Initialize component
            InitializeComponent();

            //Initialize database commands
            databaseCommands = new DatabaseCommands();

            //Initialize name of current user control
            this.lName.Text = "Historia sprzedaży";

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
            this.ColumnNames.DateAndTimeOfSales = "Data i czas sprzedaży";
            this.ColumnNames.DailyReportNumber = "Numer raportu dobowego";
            this.ColumnNames.ReceiptNumber = "Numer paragonu";
            this.ColumnNames.PositionOnReceipt = "Numer pozycji na paragonie";
            this.ColumnNames.Quantity = "Ilość sprzedaży";
            this.ColumnNames.PriceOfSales = "Kwota sprzedaży";


            //Create data source columns
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
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

        private ProductChangelog GetSalesEntityIfNotActual(int cashRegisterProdNumber, string dateOfSales, string timeOfSales)
        {
            //Get date and time suitable for comparision
            string date = ElzabRelated.ConvertElzabDateFormat(dateOfSales);
            DateTime dateAndTime = DateTime.Parse(date + " " + timeOfSales);

            //Get last valid synchrnization fro given time
            ElzabCommunication lastValidSynchronization = this.databaseCommands.GetLastSynchroFromTheGivenDate(dateAndTime);

            //Get changelog, starting from last synchronization date
            ProductChangelog changelog = this.databaseCommands.GetLastChangelogValueForGivenElzabProductIdLimitedByDate(cashRegisterProdNumber,
                System.DateTime.MinValue, lastValidSynchronization.DateOfCommunication);

            if (changelog != null)
            {
                if (changelog.OperationType == "Update")
                {
                    return changelog;
                }
                else return null;
            }
            else return null;
        }

        private void searchBarTemplate1_GenericButtonClick(object sender, Common.SearchBarTemplate.GenericButtonClickEventArgs e)
        {
            this.DataSource.Rows.Clear();

            Dictionary<Sales, ProductChangelog> old = new Dictionary<Sales, ProductChangelog>();
            Dictionary<Sales, Product> actual = new Dictionary<Sales, Product>();

            List<ProductSalesObject> outList = new List<ProductSalesObject>();

            int productNumberFromDb = e.SelectedProduct.ElzabProductId;

            //Get full list of given product sale
            List<Sales> sales = this.databaseCommands.GetSalesEntitiesByCashRegisterId(productNumberFromDb);

            //Foreach product check changelog
            foreach(Sales sale in sales)
            {
                ProductChangelog entity = GetSalesEntityIfNotActual(productNumberFromDb, sale.Attribute9, sale.Attribute10);
                if (entity != null) old.Add(sale, entity);
                else actual.Add(sale, e.SelectedProduct);
            }
            
            foreach(KeyValuePair<Sales, ProductChangelog> element in old)
            {
                outList.Add(new ProductSalesObject(element.Key, element.Value));
            }

            foreach (KeyValuePair<Sales, Product> element in actual)
            {
                outList.Add(new ProductSalesObject(element.Key, element.Value));
            }

            foreach(ProductSalesObject obj in outList)
            {
                DataRow row = this.DataSource.NewRow();
                obj.FillInDataRow(row);
                this.DataSource.Rows.Add(row);
            }

            this.advancedDataGridView1.AutoResizeColumns();
        }
    }


    public class ProductSalesObject
    {
        string ProductName { get; set; }
        DateTime DateAndTimeOfSales { get; set; }
        string DailyReportNumber { get; set; }
        string ReceiptNumber { get; set; }
        string PositionOnReceipt { get; set; }
        string Quantity { get; set; }
        float PriceOfSales { get; set; }


        /// <summary>
        /// Class constructors
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="productChangelog"></param>
        public ProductSalesObject(Sales sale, ProductChangelog productChangelog)
        {
            this.ProductName = productChangelog.ProductName;

            DateTime dateAndTime = DateTime.Parse(ElzabRelated.ConvertElzabDateFormat(sale.Attribute9) + " " + sale.Attribute10);
            this.DateAndTimeOfSales = dateAndTime;

            this.DailyReportNumber = sale.Attribute2;
            this.ReceiptNumber = sale.Attribute3;
            this.PositionOnReceipt = sale.Attribute4;
            this.Quantity = sale.Attribute7;
            this.PriceOfSales = ElzabRelated.ConvertFromElzabPriceToFloat(sale.Attribute8);
        }

        public ProductSalesObject(Sales sale, Product product)
        {
            this.ProductName = product.ProductName;

            DateTime dateAndTime = DateTime.Parse(ElzabRelated.ConvertElzabDateFormat(sale.Attribute9) + " " + sale.Attribute10);
            this.DateAndTimeOfSales = dateAndTime;

            this.DailyReportNumber = sale.Attribute2;
            this.ReceiptNumber = sale.Attribute3;
            this.PositionOnReceipt = sale.Attribute4;
            this.Quantity = sale.Attribute7;
            this.PriceOfSales = ElzabRelated.ConvertFromElzabPriceToFloat(sale.Attribute8);
        }

        public void FillInDataRow(DataRow row)
        {
            row[0] = this.ProductName;
            row[1] = this.DateAndTimeOfSales;
            row[2] = this.DailyReportNumber;
            row[3] = this.ReceiptNumber;
            row[4] = this.PositionOnReceipt;
            row[5] = this.Quantity;
            row[6] = this.PriceOfSales;
        }

    }
}
