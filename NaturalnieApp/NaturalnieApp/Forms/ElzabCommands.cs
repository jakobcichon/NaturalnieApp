using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElzabCommands;
using ElzabDriver;
using NaturalnieApp.Database;
using static NaturalnieApp.Program;

namespace NaturalnieApp.Forms
{

    public partial class ElzabCommands : UserControl
    {
        //Declaration of used elzab commands
        ElzabCommand_OTOWAR AllProductsReading { get; set; }
        ElzabCommand_ZTOWAR ProductWriting { get; set; }
        ElzabCommand_ODBARKOD AdditionBarcodesReading { get; set; }
        ElzabCommand_ZDBARKOD AdditionBarcodesWriting { get; set; }

        DatabaseCommands databaseCommands;
        TextBox StatusBox { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        public ElzabCommands(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            //Initialization of Elzab commands instances
            this.AllProductsReading = new ElzabCommand_OTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);
            //Initialization of Elzab commands instances
            this.AdditionBarcodesReading = new ElzabCommand_ODBARKOD(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);
            //Initialization of Elzab commands instances
            this.ProductWriting = new ElzabCommand_ZTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);
            //Initialization of Elzab commands instances
            this.AdditionBarcodesWriting = new ElzabCommand_ZDBARKOD(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);

            //Status box
            this.StatusBox = this.tbStatus;

            this.databaseCommands = commandsObj;

            //Initialize daa grid view
            this.ColumnNames.ProductName = "Nazwa";
            this.ColumnNames.ProductNumber = "Numer w kasie";
            this.ColumnNames.Tax = "Stawka VAT";
            this.ColumnNames.FinalPrice = "Cena";
            this.ColumnNames.Barcode = "Kod kreskowy";
            this.ColumnNames.AdditionaBarcode = "Dodatkowy kod kreskowy";
            this.DataSoruce = new DataTable();

            InitializeAdvancedDataGridView();
        }
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

            column.ColumnName = this.ColumnNames.ProductNumber;
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
            column.ColumnName = this.ColumnNames.Tax;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.FinalPrice;
            column.DataType = Type.GetType("System.Float");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Barcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.AdditionaBarcode;
            column.DataType = Type.GetType("System.String");
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
            this.InventoryColumnNames.ProductValueNet = "Wartość netto";


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

        private void bReadingFromCashRegister_Click(object sender, EventArgs e)
        {
            try
            {

                //ChangeStatus
                this.StatusBox.Text = "Generowanie listy produktów";
                //Generate all product numbers
                List<int> productToReadList = GenerateProductNumbers(1, 4095);
                int i = 0;
                foreach(int element in productToReadList)
                {
                    this.AllProductsReading.DataToElzab.AddElement(element.ToString());
                }

                //ChangeStatus
                this.StatusBox.Text = "Odczyt produktów z kasy";
                CommandExecutionStatus status = this.AllProductsReading.ExecuteCommand();


                if (status.ErrorNumber == 0)
                {
                    this.StatusBox.Text = "Parsowanie odczytanych produktów";
                    List<Product> allProductFromElzab = ElzabRelated.ParseElzabProductDataToDbObject(this.databaseCommands, this.AllProductsReading.DataFromElzab);

                    this.StatusBox.Text = "Odczyt dodatkowych kodów z kasy";
                    status = this.AdditionBarcodesReading.ExecuteCommand();
                    if (status.ErrorNumber == 0)
                    {
                        this.StatusBox.Text = "Parsowanie odczytanych produktów";
                        List<Product> allAdditionaBarcodesFromElzab = ElzabRelated.ParseElzabAddBarcodesToDbObject(this.databaseCommands, this.AllProductsReading.DataFromElzab);

                        //Compare db product data with Elzab data
                        //Get all products from DB
                        this.StatusBox.Text = "Pobieranie nazw wszystkich produktów z bazy danych";
                        List<string> nameList = this.databaseCommands.GetProductsNameList();
                        this.StatusBox.Text = "Pobieranie z bazy danych informacji o wszystkich produktach";
                        List<Product> dbProductList = new List<Product>();
                        foreach (string productName in nameList)
                        {
                            dbProductList.Add(this.databaseCommands.GetProductEntityByProductName(productName));
                        }

                        this.StatusBox.Text = "Porównywanie informacji z bazy danych i kasy fiskalnej";
                        List<Product> diffProductList = ElzabRelated.ComapreDbProductDataWithElzab(allProductFromElzab, dbProductList);
                        MessageBox.Show("Udało się wykonać polecenie");

                        //Show on the list
                        //Add data to table
                        DataRow rowElement;
                        rowElement = this.DataSoruce.NewRow();

                        foreach (Product productEnt in diffProductList)
                        {
                            //Set row fields
                            rowElement.SetField<string>(this.ColumnNames.ProductNumber, productEnt.ElzabProductName);
                            rowElement.SetField<int>(this.ColumnNames.ProductName, productEnt.ElzabProductId);
                            rowElement.SetField<int>(this.ColumnNames.Tax, ElzabRelated.TranslateTaxValueToCashRegisterGroup(productEnt.TaxId));
                            rowElement.SetField<float>(this.ColumnNames.FinalPrice, element.ModificationDate);
                            rowElement.SetField<string>(this.ColumnNames.Barcode, element.ExpirationDate);
                            rowElement.SetField<string>(this.ColumnNames.AdditionaBarcode, element.ActualQuantity);
                            this.DataSoruce.Rows.Add(rowElement);
                        }


                    }
                    else
                    {
                        MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}",
                        status.ErrorNumber, status.ErrorText),
                        "Błąd komunikacji z kasą Elzab!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}", 
                        status.ErrorNumber, status.ErrorText), 
                        "Błąd komunikacji z kasą Elzab!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<int> GenerateProductNumbers(int startIndex, int count)
        {

            if (startIndex >= 0 && count >= 1)
            {
                //Local variable
                List<int> retList = new List<int>();
                int endIndex = startIndex + count;

                for (int i = startIndex; i <= endIndex - 1; i++)
                {
                    retList.Add(i);
                }


                return retList;
            }
            else
            {
                MessageBox.Show("Błąd metody " + this.GetType().FullName + "." + startIndex + " :: " + count);
                return null;
            }
        }

    }
}
