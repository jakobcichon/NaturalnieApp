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

    public partial class ElzabSynchronization : UserControl
    {
        //Declaration of used elzab commands
        ElzabCommand_OTOWAR AllProductsReading { get; set; }
        ElzabCommand_ZTOWAR ProductWriting { get; set; }
        ElzabCommand_ODBARKOD AdditionBarcodesReading { get; set; }
        ElzabCommand_ZDBARKOD AdditionBarcodesWriting { get; set; }
        ElzabCommand_OPSPROZ4 SaleBufforReading { get; set; }

        DatabaseCommands databaseCommands;
        TextBox StatusBox { get; set; }

        int ProgressTimerSeconds { get; set; }
        int ProgressTimerMinutes { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        public ElzabSynchronization(ref DatabaseCommands commandsObj)
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
            //Initialization of Elzab commands instances
            this.SaleBufforReading = new ElzabCommand_OPSPROZ4(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);

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

            StartTimer();
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
            column.DataType = Type.GetType("System.Single");
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

            this.DataSoruce.DefaultView.Sort = this.ColumnNames.ProductNumber + " asc";
            advancedDataGridView1.DataSource = this.DataSoruce;

            advancedDataGridView1.AutoResizeColumns();
        }

        #endregion

        private void bReadingFromCashRegister_Click(object sender, EventArgs e)
        {
            try
            {
                this.DataSoruce.Clear();

                //ChangeStatus
                this.StatusBox.Text = "1.Generowanie listy produktów";
                //Generate all product numbers
                List<int> productToReadList = GenerateProductNumbers(1, 4095);
                this.AllProductsReading.DataToElzab.Element.RemoveAllElements();
                this.AllProductsReading.DataFromElzab.Element.RemoveAllElements();
                this.AdditionBarcodesReading.DataFromElzab.Element.RemoveAllElements();

                foreach (int element in productToReadList)
                {
                    this.AllProductsReading.DataToElzab.AddElement(element.ToString());
                }

                //ChangeStatus
                this.StatusBox.Text = "2.Odczyt produktów z kasy";
                this.StatusBox.Update();
                CommandExecutionStatus status = this.AllProductsReading.ExecuteCommand();


                if (status.ErrorNumber == 0 && status.ErrorText != null)
                {
                    this.StatusBox.Text = "3.Parsowanie odczytanych produktów";
                    this.StatusBox.Update();
                    List<Product> allProductFromElzab = ElzabRelated.ParseElzabProductDataToDbObject(this.databaseCommands, this.AllProductsReading.DataFromElzab);

                    this.StatusBox.Text = "4.Odczyt dodatkowych kodów z kasy";
                    this.StatusBox.Update();
                    status = this.AdditionBarcodesReading.ExecuteCommand();
                    if (status.ErrorNumber == 0 && status.ErrorText != null)
                    {
                        this.StatusBox.Text = "5.Parsowanie odczytanych produktów";
                        this.StatusBox.Update();
                        List<Product> allAdditionaBarcodesFromElzab = ElzabRelated.ParseElzabAddBarcodesToDbObject(this.databaseCommands, this.AdditionBarcodesReading.DataFromElzab);

                        //Compare db product data with Elzab data
                        //Get all products from DB
                        this.StatusBox.Text = "6.Pobieranie nazw wszystkich produktów z bazy danych";
                        this.StatusBox.Update();

                        this.StatusBox.Text = "7.Pobieranie z bazy danych informacji o wszystkich produktach";
                        this.StatusBox.Update();
                        List<Product> dbProductList = this.databaseCommands.GetAllProductsEnts();

                        this.StatusBox.Text = "8.Porównywanie informacji z bazy danych i kasy fiskalnej";
                        this.StatusBox.Update();
                        List<Product> diffProductList = ElzabRelated.ComapreDbProductDataWithElzab(allProductFromElzab, dbProductList);

                        this.StatusBox.Text = "9.Przygotowanie danych do wyświetlenia";
                        this.StatusBox.Update();
                        //Show on the list
                        foreach (Product productEnt in diffProductList)
                        {
                            //Add data to table
                            DataRow rowElement;
                            rowElement = this.DataSoruce.NewRow();

                            //Set row fields
                            rowElement.SetField<int>(this.ColumnNames.ProductNumber, productEnt.ElzabProductId);
                            rowElement.SetField<string>(this.ColumnNames.ProductName, productEnt.ElzabProductName);
                            int taxValue = this.databaseCommands.GetTaxByProductName(productEnt.ProductName).TaxValue;
                            rowElement.SetField<int>(this.ColumnNames.Tax, taxValue);
                            rowElement.SetField<float>(this.ColumnNames.FinalPrice, productEnt.FinalPrice);
                            rowElement.SetField<string>(this.ColumnNames.Barcode, productEnt.BarCode);
                            rowElement.SetField<string>(this.ColumnNames.AdditionaBarcode, productEnt.BarCodeShort);
                            this.DataSoruce.Rows.Add(rowElement);
                        }

                        if (diffProductList.Count == 0)
                        {
                            MessageBox.Show("Nie znaleziono żadnych różnic między bazą danych a kasą fiskalną:).");
                        }
                        else
                        {
                            this.StatusBox.Text = "9.Oczekiwanie na akcję użytkownika";
                            this.StatusBox.Update();
                            MessageBox.Show(string.Format("Znaleziono {0} różnic.", diffProductList.Count()));

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

        private void bSave_Click(object sender, EventArgs e)
        {
            if (this.DataSoruce.Rows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Czy na pewno chcesz nadpisać produkty w kasie Elzab?",
                    "zmiana produtów", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<Product> productsToSave = new List<Product>();
                    foreach (DataRow element in this.DataSoruce.Rows)
                    {
                        productsToSave.Add(this.databaseCommands.GetProductEntityByElzabId(element.Field<int>(this.ColumnNames.ProductNumber)));
                    }

                    this.ProductWriting.DataToElzab = ElzabRelated.ParseDbObjectToElzabProductData(this.databaseCommands, productsToSave, this.ProductWriting.DataToElzab);
                    this.AdditionBarcodesWriting.DataToElzab = ElzabRelated.ParseDbObjectToElzabAddBarcodes(this.databaseCommands, productsToSave, this.AdditionBarcodesWriting.DataToElzab);

                    CommandExecutionStatus status = this.ProductWriting.ExecuteCommand();
                    if (status.ErrorNumber == 0 && status.ErrorText != null)
                    {
                        status = this.AdditionBarcodesWriting.ExecuteCommand();
                        if (status.ErrorNumber == 0 && status.ErrorText != null)
                        {
                            MessageBox.Show("Zapisano!");
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
                else
                {
                    MessageBox.Show("Anulowano..");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano produktów do zapisu!");
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

        //Progres time related
        #region Progress time related
        private void tProgressTime_Tick(object sender, EventArgs e)
        {
            //Increment seconds
            this.ProgressTimerSeconds += 1;

            //If minutes equals 99, stop timer
            if (this.ProgressTimerMinutes >= 99 && this.ProgressTimerSeconds >= 60)
            {
                StopTimer();
            }
            //If match 60, increment minutes
            else if (this.ProgressTimerSeconds >= 60)
            {
                this.ProgressTimerMinutes += 1;
                this.ProgressTimerSeconds = 0;
            }

            UpdateTimeDisplay();

        }

        private void StopTimer()
        {
            this.ProgressTimerSeconds = 0;
            this.ProgressTimerMinutes = 0;
            this.tProgressTime.Stop();
            UpdateTimeDisplay();
        }

        private void StartTimer()
        {
            this.ProgressTimerSeconds = 0;
            this.ProgressTimerMinutes = 0;
            this.tProgressTime.Start();
        }

        private void UpdateTimeDisplay()
        {
            this.tbElapsedTime.Text = (this.ProgressTimerMinutes.ToString("00") + ":" + this.ProgressTimerSeconds.ToString("00"));
        }
        #endregion

        private void bReadingFromSaleBuffor_Click(object sender, EventArgs e)
        {
            try
            {
                this.DataSoruce.Clear();

                this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
                this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

                //ChangeStatus
                this.StatusBox.Text = "1. Odczyt bufora sprzedaży z kasy";
                this.StatusBox.Update();
                CommandExecutionStatus status = this.SaleBufforReading.ExecuteCommand();
                
                //Get list of element type
                List<int> elementsTypeList = this.SaleBufforReading.DataFromElzab.GetListOfElementTypes();
                List<Sales> listOfElementsToAdd = new List<Sales>();
                foreach (int type in elementsTypeList)
                {
                    //Get list of all elements of given type
                    List<AttributeValueObject> elementsList = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                    listOfElementsToAdd.AddRange(ElzabRelated.ParseElzabBufferToDbObject(elementsList));
                }
                this.databaseCommands.AddToSales(listOfElementsToAdd);
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
