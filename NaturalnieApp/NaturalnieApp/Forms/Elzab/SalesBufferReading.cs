using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

    public partial class SalesBufferReading : UserControl
    {
        //Declaration of used elzab commands
        ElzabCommand_OPSPROZ4 SaleBufforReading { get; set; }

        DatabaseCommands databaseCommands;
        TextBox StatusBox { get; set; }

        int ProgressTimerSeconds { get; set; }
        int ProgressTimerMinutes { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSoruce { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        public SalesBufferReading(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

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
            /*
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
            */
        }

        private void bSave_Click(object sender, EventArgs e)
        {
           
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
                //Dialog settings
                openFileDialog1.DefaultExt = ".txt";
                openFileDialog1.Title = "Odczyt danych o sprzedaży z pliku";
                openFileDialog1.Filter = "Plik txt (*.txt)|*.txt";
                
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //File information
                    string directoryName = Path.GetDirectoryName(openFileDialog1.FileName);
                    string fileName = Path.GetFileName(openFileDialog1.FileName);

                    this.DataSoruce.Clear();

                    this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
                    this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

                    //ChangeStatus
                    this.StatusBox.Text = "1. Odczyt z pliku danych sprzedaży kasy";
                    this.StatusBox.Update();

                    this.SaleBufforReading.DataFromElzab.SetNewPath(directoryName);
                    this.SaleBufforReading.DataFromElzab.GenerateObjectFromRawData();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
