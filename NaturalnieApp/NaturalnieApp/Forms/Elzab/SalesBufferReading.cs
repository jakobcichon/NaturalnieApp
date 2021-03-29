using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private List<DataTable> DataSource { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        //Data Grid View List
        private List<Zuby.ADGV.AdvancedDataGridView> DataGridViewsList {get; set;}

        //Backgound worker for connection to db
        BackgroundWorker ProgressBarBackgroundWorker;

        //Static variables
        static int NORMAL_SALE_INDEX = 1;

        //Advanced data grid view events
        private void AdvancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = (Zuby.ADGV.AdvancedDataGridView)sender;
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
        }
        private void AdvancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            Zuby.ADGV.AdvancedDataGridView fdgv = (Zuby.ADGV.AdvancedDataGridView)sender;
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

        public SalesBufferReading(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            //Initialize backround worker
            InitializeBackgroundWorker();

            //Initialization of Elzab commands instances
            this.SaleBufforReading = new ElzabCommand_OPSPROZ4(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);

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
            this.DataSource = new List<DataTable>();

            //Grid view
            this.DataGridViewsList = new List<Zuby.ADGV.AdvancedDataGridView>();

            //Tab control
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            StopTimer();
        }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.ProgressBarBackgroundWorker = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.ProgressBarBackgroundWorker.DoWork += DbBackgroundWorker_DoWork;
            // this event will define what the worker will do when finished
            this.ProgressBarBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DbBackgroundWorker_RunWorkerCompleted);
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try { 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void bReadingFromCashRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear pages
                this.tcDataFromFile.TabPages.Clear();
                this.DataGridViewsList.Clear();
                this.DataSource.Clear();

                //Reset to default path
                this.SaleBufforReading.DataFromElzab.RestoreDefaultPath();

                //Disable page control
                this.tcDataFromFile.Enabled = false;

                this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
                this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

                //ChangeStatus
                this.StatusBox.Text = "1. Odczyt bufora sprzedaży z kasy";
                this.StatusBox.Update();
                CommandExecutionStatus status = this.SaleBufforReading.ExecuteCommand();

                if ((status.ErrorNumber != 0) || (status.ErrorText == null))
                {

                    //ChangeStatus
                    this.StatusBox.Text = "0. Błąd:(";
                    this.StatusBox.Update();

                    MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}",
                        status.ErrorNumber, status.ErrorText),
                        "Błąd komunikacji z kasą Elzab!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //ChangeStatus
                    this.StatusBox.Text = "2. Odczytywanie typów sprzedaży";
                    this.StatusBox.Update();

                    //Get list of element type
                    List<int> elementsTypeList = this.SaleBufforReading.DataFromElzab.GetListOfElementTypes();
                    List<Sales> listOfElementsToAdd = new List<Sales>();
                    foreach (int type in elementsTypeList)
                    {
                        //Get list of all elements of given type
                        List<AttributeValueObject> elementsList = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                        listOfElementsToAdd.AddRange(ElzabRelated.ParseElzabBufferToDbObject(elementsList));
                    }

                    //ChangeStatus
                    this.StatusBox.Text = "3. Sprawdzanie unikalności elementów sprzedaży";
                    this.StatusBox.Update();

                    //List of unique idetifiers
                    List<string> uniqueIdetifiers = listOfElementsToAdd.Select(u => u.EntryUniqueIdentifier).ToList();

                    //Check what exist in DB
                    List<string> uniqueIdetifiersNotInDb = this.databaseCommands.CheckIfUniqueIdExist(uniqueIdetifiers);

                    //Get only those object that are not exist in db
                    List<Sales> modifiedListOfElementsToAdd = new List<Sales>();
                    foreach (string element in uniqueIdetifiersNotInDb)
                    {
                        modifiedListOfElementsToAdd.Add(listOfElementsToAdd.Where(w => w.EntryUniqueIdentifier == element).
                            Select(l => l).FirstOrDefault());
                    }


                    //ChangeStatus
                    this.StatusBox.Text = string.Format("5. Dodawanie do bazy danych unikalnych elementów sprzedaży ({0} pozycji)"
                        , modifiedListOfElementsToAdd.Count());
                    this.StatusBox.Update();

                    //Add to DB
                    this.databaseCommands.AddToSales(modifiedListOfElementsToAdd);

                    //Create pages
                    foreach (int type in elementsTypeList)
                    {
                        //Get attributes names for given type
                        List<string> attributesNamesOfType = this.SaleBufforReading.DataFromElzab.GetAttributesNamesOfType(type);
                        List<string> columNames = new List<string>();
                        foreach (string attibuteName in attributesNamesOfType)
                        {
                            columNames.Add(this.SaleBufforReading.GetTranslationForGivenAttributeName(attibuteName));
                        }

                        //Variables for page creation
                        string pageName = this.SaleBufforReading.GetTheNameOfGivenElementType(type);
                        int pageIndex = -1;

                        //Add page
                        this.tcDataFromFile.TabPages.Add(pageName);

                        pageIndex = this.tcDataFromFile.TabPages.Count - 1;

                        AddDataGridToTabPage(this.tcDataFromFile.TabPages[pageIndex], columNames);

                    }

                    this.tcDataFromFile.Update();

                    //ChangeStatus
                    this.StatusBox.Text = "5. Ładowanie danych";
                    this.StatusBox.Update();

                    foreach (int type in elementsTypeList)
                    {
                        //Add data to data source
                        List<AttributeValueObject> dataToAdd = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                        AddDataFromElzabToDataSource(dataToAdd, elementsTypeList.IndexOf(type));
                    }


                    //ChangeStatus
                    this.StatusBox.Text = "6. Aktualizacja stanów magazynowych";
                    this.StatusBox.Update();

                    //Update sales table
                    UpdateSalesQuantityInStock(this.SaleBufforReading.DataFromElzab, NORMAL_SALE_INDEX);


                    //ChangeStatus
                    this.StatusBox.Text = "6. Zakończono!:)";
                    this.StatusBox.Update();

                    this.tcDataFromFile.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //ChangeStatus
                this.StatusBox.Text = "0. Błąd:(";
                this.StatusBox.Update();
            }

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
                    //Clear pages
                    this.tcDataFromFile.TabPages.Clear();
                    this.DataGridViewsList.Clear();
                    this.DataSource.Clear();

                    //Disable page control
                    this.tcDataFromFile.Enabled = false;

                    //File information
                    string directoryName = Path.GetDirectoryName(openFileDialog1.FileName);
                    string fileName = Path.GetFileName(openFileDialog1.FileName);

                    this.DataSource.Clear();

                    this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
                    this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

                    //ChangeStatus
                    this.StatusBox.Text = "1. Odczyt z pliku danych sprzedaży kasy";
                    this.StatusBox.Update();

                    this.SaleBufforReading.DataFromElzab.SetNewPath(directoryName);
                    this.SaleBufforReading.DataFromElzab.GenerateObjectFromRawData();

                    //ChangeStatus
                    this.StatusBox.Text = "2. Odczytywanie typów sprzedaży";
                    this.StatusBox.Update();

                    //Get list of element type
                    List<int> elementsTypeList = this.SaleBufforReading.DataFromElzab.GetListOfElementTypes();
                    List<Sales> listOfElementsToAdd = new List<Sales>();
                    foreach (int type in elementsTypeList)
                    {
                        //Get list of all elements of given type
                        List<AttributeValueObject> elementsList = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                        listOfElementsToAdd.AddRange(ElzabRelated.ParseElzabBufferToDbObject(elementsList));
                    }

                    //ChangeStatus
                    this.StatusBox.Text = "3. Sprawdzanie unikalności elementów sprzedaży";
                    this.StatusBox.Update();

                    //List of unique idetifiers
                    List<string> uniqueIdetifiers = listOfElementsToAdd.Select(u => u.EntryUniqueIdentifier).ToList();

                    //Check what exist in DB
                    List<string> uniqueIdetifiersNotInDb = this.databaseCommands.CheckIfUniqueIdExist(uniqueIdetifiers);

                    //Get only those object that are not exist in db
                    List<Sales> modifiedListOfElementsToAdd = new List<Sales>();
                    foreach(string element in uniqueIdetifiersNotInDb)
                    {
                        modifiedListOfElementsToAdd.Add(listOfElementsToAdd.Where(w => w.EntryUniqueIdentifier == element).
                            Select(l => l).FirstOrDefault());
                    }


                    //ChangeStatus
                    this.StatusBox.Text = string.Format("5. Dodawanie do bazy danych unikalnych elementów sprzedaży ({0} pozycji)"
                        , modifiedListOfElementsToAdd.Count());
                    this.StatusBox.Update();

                    //Add to DB
                    this.databaseCommands.AddToSales(modifiedListOfElementsToAdd);

                    //Create pages
                    foreach (int type in elementsTypeList)
                    {
                        //Get attributes names for given type
                        List<string> attributesNamesOfType = this.SaleBufforReading.DataFromElzab.GetAttributesNamesOfType(type);
                        List<string> columNames = new List<string>();
                        foreach (string attibuteName in attributesNamesOfType)
                        {
                            columNames.Add(this.SaleBufforReading.GetTranslationForGivenAttributeName(attibuteName));
                        }
                        
                        //Variables for page creation
                        string pageName = this.SaleBufforReading.GetTheNameOfGivenElementType(type);
                        int pageIndex = -1;
                        
                        //Add page
                        this.tcDataFromFile.TabPages.Add(pageName);
                        
                        pageIndex = this.tcDataFromFile.TabPages.Count - 1;

                        AddDataGridToTabPage(this.tcDataFromFile.TabPages[pageIndex], columNames);

                    }

                    this.tcDataFromFile.Update();

                    //ChangeStatus
                    this.StatusBox.Text = "5. Ładowanie danych";
                    this.StatusBox.Update();

                    foreach (int type in elementsTypeList)
                    {
                        //Add data to data source
                        List<AttributeValueObject> dataToAdd = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                        AddDataFromElzabToDataSource(dataToAdd, elementsTypeList.IndexOf(type));
                    }


                    //ChangeStatus
                    this.StatusBox.Text = "6. Aktualizacja stanów magazynowych";
                    this.StatusBox.Update();

                    //Update sales table
                    UpdateSalesQuantityInStock(this.SaleBufforReading.DataFromElzab, NORMAL_SALE_INDEX);


                    //ChangeStatus
                    this.StatusBox.Text = "6. Zakończono!:)";
                    this.StatusBox.Update();

                    this.tcDataFromFile.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //ChangeStatus
                this.StatusBox.Text = "0. Błąd:(";
                this.StatusBox.Update();

                MessageBox.Show(ex.Message);

            }
        }

        private void AddDataGridToTabPage(TabPage page, List<string> columnNames)
        {
            //Local variables
            bool gridViewAlreadyExist = false;

            //Prevent to add grid view to the tab if already exist
            foreach (Control control in page.Controls)
            {
                if (control.GetType() == typeof(Zuby.ADGV.AdvancedDataGridView)) gridViewAlreadyExist = true;

            }

            if(!gridViewAlreadyExist)
            {
                //Add data table to the source first
                this.DataSource.Add(new DataTable());

                foreach (string name in columnNames)
                {
                    //Skip if first attribute name
                    if (columnNames.IndexOf(name) == 0) continue;

                    //Create data source columns
                    DataColumn column = new DataColumn();

                    column.ColumnName = name;
                    column.DataType = Type.GetType("System.String");
                    column.ReadOnly = true;
                    this.DataSource.Last().Columns.Add(column);
                    column.Dispose();
                }

                //Sort
                this.DataSource.Last().DefaultView.Sort = this.DataSource.Last().Columns[0].ColumnName + " asc";

                //Add new data grid to the collection
                this.DataGridViewsList.Add(new Zuby.ADGV.AdvancedDataGridView());
                this.DataGridViewsList.Last().SetDoubleBuffered();

                //Attach data source
                this.DataGridViewsList.Last().DataSource = this.DataSource.Last();

                //Make it look nice
                this.DataGridViewsList.Last().Dock = DockStyle.Fill;
                this.DataGridViewsList.Last().ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.DataGridViewsList.Last().AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                this.DataGridViewsList.Last().AutoResizeColumns();

                //Add events
                this.DataGridViewsList.Last().FilterStringChanged += AdvancedDataGridView1_FilterStringChanged;
                this.DataGridViewsList.Last().SortStringChanged += AdvancedDataGridView1_SortStringChanged;

                //Add grid view to the tab page
                page.Controls.Add(this.DataGridViewsList.Last());
            }
        }

        private void AddDataFromElzabToDataSource(List<AttributeValueObject> dataToAdd, int index)
        {

            foreach (AttributeValueObject data in dataToAdd)
            {
                //Exclude first attribute (which is element type
                List<string> dataMod = data.AttributeValue.Skip(1).ToList();

                //Create new row
                DataRow newRow = this.DataSource[index].NewRow();
                foreach(string attributeValue in dataMod)
                {
                    newRow.SetField<string>(dataMod.IndexOf(attributeValue), attributeValue);
                }

                //Add row to data source
                this.DataSource[index].Rows.Add(newRow);
            }
            
        }


        /// <summary>
        /// Method used to Update Sales quantity in Stock table.
        /// It will update only entrys which alredy were added to the Sales table in DB
        /// </summary>
        /// <param name="dataFromElzab">Data from Elzab</param>
        /// <param name="elementType">Element type</param>
        public void UpdateSalesQuantityInStock(ElzabFileObject dataFromElzab, int elementType)
        {
            //Get index of normal sale element type
            int elementTypeIndex = dataFromElzab.GetElementTypeIndex(elementType);
            List<string> listOfElementNotDetermined = new List<string>();
            List<string> listOfElementDeleted = new List<string>();
            List<string> listOfElementAdded = new List<string>();
            List<string> listOfElementAlreadyUpdatedInDb= new List<string>();

            //Loop through all elements and check if unique Id exist in DB
            foreach (AttributeValueObject element in dataFromElzab.Element.ElementsList[elementTypeIndex])
            {
                //Check if product exist
                bool idExist = this.databaseCommands.CheckIfUniqueIdExist(element.UniqueIdentifier);

                if(idExist)
                {
                    //Get product id from cash register
                    int currentElementIndex = dataFromElzab.Element.ElementsList[elementTypeIndex].IndexOf(element);
                    int cashRegisterProductNumber = Convert.ToInt32(dataFromElzab.Element.GetAttributeValue(currentElementIndex, "nr_tow", elementType));

                    //Get date and time of sale
                    string saleDate = dataFromElzab.Element.GetAttributeValue(currentElementIndex, "data", elementType);
                    string saleTime = dataFromElzab.Element.GetAttributeValue(currentElementIndex, "czas", elementType);
                    string barcode = dataFromElzab.Element.GetAttributeValue(currentElementIndex, "bkod", elementType);
                    string saleDateAndTime = saleDate + " " + saleTime;
                    DateTime saleDateAndTimeConverted = DateTime.ParseExact(saleDateAndTime, "yy.MM.dd HH:mm", CultureInfo.InvariantCulture);

                    //Check product changelog to see if Ezlab product number has been change
                    int productNumber = ElzabRelated.CheckIfProductNumberHasChanged(ref this.databaseCommands, cashRegisterProductNumber, barcode, saleDateAndTimeConverted);

                    //If could not determine add to the list
                    if (productNumber == -1) listOfElementNotDetermined.Add(element.ConvertValuesToString());
                    else if (productNumber == -2) listOfElementDeleted.Add(element.ConvertValuesToString());
                    else
                    {
                        //Check if sales was not updated with given sales unique ID
                        if (!this.databaseCommands.CheckIfSalesUniqueIdExistInStockHistory(element.UniqueIdentifier))
                        {
                            //Get quantity
                            string stringQuantity = dataFromElzab.Element.GetAttributeValue(currentElementIndex, "il_sp", elementType);
                            int quantity = -1 * Convert.ToInt32(Single.Parse(stringQuantity));

                            //Get DB productID
                            int dbProductId = this.databaseCommands.GetProductIdByElzabProductNumber(productNumber);

                            //Udpate stock value in DB
                            this.databaseCommands.UpdateProductQuantityInStock(quantity, dbProductId,
                                stockOperationType: StockOperationType.AutomaticUpdate, salesUniqueIdForAutomaticUpdate: element.UniqueIdentifier);

                            //Add to the report list
                            listOfElementAdded.Add(element.ConvertValuesToString());

                        }
                        else listOfElementAlreadyUpdatedInDb.Add(element.ConvertValuesToString());
                        
                    }
                        
                }
            }

            DialogResult result = MessageBox.Show(string.Format("Raport dodania pozycji sprzedaży do bazy danych:" +
                "\n Liczba produktów których nie można było odnaleźć w bazie danych: {0}" +
                "\n Liczba produktów których nie odaleziono w bazie danych z uwagi na usunięty produkt: {1}" +
                "\n Liczba produktów, których stany magazynowe zostały zaktualizowane: {2}" +
                "\n Liczba produktów pominięty (produkt o identycznym numerze Id został już użyty do aktualizacji stanów):{3}" +
                "\n Czy chcesz zapisać raport szczegółowy?",
                listOfElementNotDetermined.Count(), listOfElementDeleted.Count(), listOfElementAdded.Count(),
                listOfElementAlreadyUpdatedInDb.Count()),
                "Raport", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = folderBrowserDialog.SelectedPath + @"\dump.txt";
                    string deliminer = "\n";
                    for (int i = 0; i < 30; i++) deliminer += "*";
                    deliminer += "\n";


                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: false);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> 
                    { "Liczba produktów których nie można było odnaleźć w bazie danych" }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, listOfElementNotDetermined, append: true);

                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> 
                    { "Liczba produktów których nie odaleziono w bazie danych z uwagi na usunięty produkt" }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, listOfElementDeleted, append: true);

                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów, których stany magazynowe zostały zaktualizowane" }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, listOfElementAdded, append: true);

                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów pominięty (produkt o identycznym numerze Id został już użyty do aktualizacji stanów)" }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                    FileWriteRelated.WriteToTextFile(fullPath, listOfElementAlreadyUpdatedInDb, append: true);
                }
            }


        }
    }
}
