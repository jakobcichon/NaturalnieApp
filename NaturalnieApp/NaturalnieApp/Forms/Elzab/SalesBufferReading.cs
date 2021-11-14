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

        #region Sales read dump data
        private class SalesReadDumpData
        {
            public List<string> ListOfElementNotDetermined { get; set; }
            public List<string> ListOfElementDeleted { get; set; }
            public List<string> ListOfElementAdded { get; set; }
            public List<string> ListOfElementAlreadyUpdatedInDb { get; set; }

            public SalesReadDumpData()
            {
                this.ListOfElementNotDetermined = new List<string>();
                this.ListOfElementDeleted = new List<string>();
                this.ListOfElementAdded = new List<string>();
                this.ListOfElementAlreadyUpdatedInDb = new List<string>();
            }

            /// <summary>
            /// Method used to save to file summary data from read sales buffer
            /// </summary>
            public void SaveToFile()
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = folderBrowserDialog.SelectedPath + @"\dump.txt";
                    try
                    {

                        string deliminer = "\n";
                        for (int i = 0; i < 30; i++) deliminer += "*";
                        deliminer += "\n";

                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: false);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Podsumowanie raportu:" }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        string text = string.Format("Raport dodania pozycji sprzedaży do bazy danych:" +
                                "\n\tLiczba produktów których nie można było odnaleźć w bazie danych: {0}" +
                                "\n\tLiczba produktów których nie odaleziono w bazie danych z uwagi na usunięty produkt: {1}" +
                                "\n\tLiczba produktów, których stany magazynowe zostały zaktualizowane: {2}" +
                                "\n\tLiczba produktów pominięty (produkt o identycznym numerze Id został już użyty do aktualizacji stanów): {3}",
                                this.ListOfElementNotDetermined.Count(), this.ListOfElementDeleted.Count(), this.ListOfElementAdded.Count(),
                                this.ListOfElementAlreadyUpdatedInDb.Count());
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { text }, append: true);

                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów których nie można było odnaleźć w bazie danych" }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, this.ListOfElementNotDetermined, append: true);

                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów których nie odaleziono w bazie danych z uwagi na usunięty produkt" }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, this.ListOfElementDeleted, append: true);

                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów, których stany magazynowe zostały zaktualizowane" }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, this.ListOfElementAdded, append: true);

                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string>
                    { "Liczba produktów pominięty (produkt o identycznym numerze Id został już użyty do aktualizacji stanów)" }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, new List<string> { deliminer }, append: true);
                        FileWriteRelated.WriteToTextFile(fullPath, this.ListOfElementAlreadyUpdatedInDb, append: true);

                        MessageBox.Show(string.Format("Pomyślnie zapisano dane do pliku: {0}!", fullPath));
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Błąd!. Nie udało się zapisać danych do pliku: {0}!", fullPath), "Błąd zapisu", 
                            MessageBoxButtons.OK ,MessageBoxIcon.Error);
                    }
                   
                }

            }

            /// <summary>
            /// Method used to clear all summary data
            /// </summary>
            public void ClearAllData()
            {
                this.ListOfElementAdded.Clear();
                this.ListOfElementAlreadyUpdatedInDb.Clear();
                this.ListOfElementDeleted.Clear();
                this.ListOfElementNotDetermined.Clear();
            }
        }
        #endregion class

        //Declaration of used elzab commands
        ElzabCommand_OPSPROZ4 SaleBufforReading { get; set; }

        DatabaseCommands databaseCommands;
        TextBox StatusBox { get; set; }

        SalesReadDumpData ReadSalesSummaryData {get; set;}

        //Readonly fields with backgroundworker steps description
        #region Readonly fields with backgroundworker steps description
        private List<string> BwStepsDescription
        {
            get
            {
                return new List<string>()
                {
                    "0. Błąd:(",
                    "1. Odczytywanie danych z kasy fiskalnej",
                    "2. Pobieranie wartości sprzedaży oraz ich typów",
                    "3. Sprawdzanie unikalności elementów sprzedaży",
                    "4. Dodawanie do bazy danych unikalnych elementów sprzedaży ({0} pozycji)",
                    "5. Generowanie danych do wyświetlenia",
                    "6. Aktualizacja stanów magazynowych",
                    "7. Zakończono!:)"
                };
            }
        }
        private List<string> BwStepsDescriptionFromFile
        {
            get
            {
                return new List<string>()
                {
                    "0. Błąd:(",
                    "1. Pobieranie danych z podanego pliku",
                    "2. Pobieranie wartości sprzedaży oraz ich typów",
                    "3. Sprawdzanie unikalności elementów sprzedaży",
                    "4. Dodawanie do bazy danych unikalnych elementów sprzedaży ({0} pozycji)",
                    "5. Generowanie danych do wyświetlenia",
                    "6. Aktualizacja stanów magazynowych",
                    "7. Zakończono!:)"
                };
            }
        }
        #endregion
        //Backgroundworker for elzab communication
        #region Backgroundworker return classes
        BackgroundWorker BwElzabCommunication { get; set; }
        class BwElzabCommunicationProgressUpdate
        {
            public enum MessageType
            {
                Update,
                Error,
                UserPrompt
            }
            public MessageType TypeOfMessage { get; set; }
            public string Text { get; set; }
            public double ProgressBarTime { get; set; }

            public void GenerateMessage(string text, double progressBarTime = 2.0, MessageType messageType = MessageType.Update)
            {
                this.TypeOfMessage = messageType;
                this.Text = text;
                this.ProgressBarTime = progressBarTime;
            }

        }
        #endregion

        //Data source for advanced data grid view
        private List<DataTable> DataSource { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        //Data Grid View List
        private List<Zuby.ADGV.AdvancedDataGridView> DataGridViewsList {get; set;}

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

            //Initialize data grid view
            this.ColumnNames.ProductName = "Nazwa";
            this.ColumnNames.ProductNumber = "Numer w kasie";
            this.ColumnNames.Tax = "Stawka VAT";
            this.ColumnNames.FinalPrice = "Cena";
            this.ColumnNames.Barcode = "Kod kreskowy";
            this.ColumnNames.AdditionaBarcode = "Dodatkowy kod kreskowy";
            this.DataSource = new List<DataTable>();

            //Grid view
            this.DataGridViewsList = new List<Zuby.ADGV.AdvancedDataGridView>();

            this.ReadSalesSummaryData = new SalesReadDumpData();

            //Tab control
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.BwElzabCommunication = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.BwElzabCommunication.DoWork += this.BwElzabCommunication_DoWork;
            // this event will define what the worker will do when finished
            this.BwElzabCommunication.RunWorkerCompleted += this.BwElzabCommunication_RunWorkerCompleted;

            //Enable progress change update and assigne event
            this.BwElzabCommunication.WorkerReportsProgress = true;
            this.BwElzabCommunication.ProgressChanged += BwElzabCommunication_ProgressChanged;

        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void BwElzabCommunication_DoWork(object sender, DoWorkEventArgs e)
        {
            if(e.Argument.GetType() == typeof(Button)) ReadSalesBufferFromCashRegister(sender);
            else if (e.Argument.GetType() == typeof(OpenFileDialog)) ReadSalesBufferFromFile(sender, e.Argument as OpenFileDialog);
        }
        private void BwElzabCommunication_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Cast an object
            BwElzabCommunicationProgressUpdate update = e.UserState as BwElzabCommunicationProgressUpdate;

            switch (update.TypeOfMessage)
            {
                case BwElzabCommunicationProgressUpdate.MessageType.Error:
                    this.progressBarTemplate1.Reset();
                    string[] splittedText = update.Text.Split('|');
                    if (splittedText.Count() > 1) MessageBox.Show(splittedText[0], splittedText[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(splittedText[0], "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.StatusBox.Text = "Błąd... :(";
                    break;
                case BwElzabCommunicationProgressUpdate.MessageType.Update:
                    this.StatusBox.Text = update.Text;
                    this.progressBarTemplate1.StatusBarSettings(durationTime: update.ProgressBarTime);
                    this.progressBarTemplate1.StartByTimer();
                    break;
                case BwElzabCommunicationProgressUpdate.MessageType.UserPrompt:
                    this.progressBarTemplate1.Reset();
                    MessageBox.Show(update.Text);
                    break;
            }
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void BwElzabCommunication_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddDataGridToTabPage();

            //Unlock buttons
            UnlockButtons();
        }
        #endregion

        #region Buttons events
        private void bSave_Click(object sender, EventArgs e)
        {

        }
        private void bReadingSaleBufforFromCashRegister_Click(object sender, EventArgs e)
        {
            if (!BwElzabCommunication.IsBusy)
            {
                //Clear data
                ClearAllDataSources();

                //Lock buttons
                LockButtons();

                //Run work
                BwElzabCommunication.RunWorkerAsync(sender);
            }
        }
        private void bReadingSaleBufforFromFile_Click(object sender, EventArgs e)
        {
            //Dialog settings
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.Title = "Odczyt danych o sprzedaży z pliku";
            openFileDialog1.Filter = "Plik txt (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (!BwElzabCommunication.IsBusy)
                {
                    //Clear data
                    ClearAllDataSources();

                    //Lock buttons
                    LockButtons();

                    //Run work
                    BwElzabCommunication.RunWorkerAsync(openFileDialog1);
                }
            }
        }
        private void bSaveSummaryData_Click(object sender, EventArgs e)
        {
            this.ReadSalesSummaryData.SaveToFile();
        }
        #endregion

        #region Private methods
        private void LockButtons()
        {
            this.bReadingSaleBufforFromCashRegister.Enabled = false;
            this.bReadingSaleBufforFromFile.Enabled = false;
            this.bSaveSummaryData.Enabled = false;
        }
        private void UnlockButtons()
        {
            this.bReadingSaleBufforFromCashRegister.Enabled = true;
            this.bReadingSaleBufforFromFile.Enabled = true;
            this.bSaveSummaryData.Enabled = true;
        }
        private void ClearAllDataSources()
        {
            this.DataGridViewsList.Clear();
            this.tcDataFromFile.TabPages.Clear();
            this.DataSource.Clear();
            this.ReadSalesSummaryData.ClearAllData();
        }
        private void ReadSalesBufferFromCashRegister(object sender)
        {
            //Local variables
            BwElzabCommunicationProgressUpdate communicationProgressUpdate = new BwElzabCommunicationProgressUpdate();

            try
            {
                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(1), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Get data from Cash register
                CommandExecutionStatus status = GetSaleDataFromCashRegister();

                if ((status.ErrorNumber != 0) || (status.ErrorText == null))
                {
                    string text = string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}" +
                        "|Błąd komunikacji",
                        status.ErrorNumber, status.ErrorText);
                    communicationProgressUpdate.GenerateMessage(text, 2.0, 
                        BwElzabCommunicationProgressUpdate.MessageType.Error);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                }
                else
                {
                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(2), 2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    //Action - Get element type and values list
                    List<int> elementsTypeList;
                    List<Sales> listOfElementsToAdd;
                    (elementsTypeList, listOfElementsToAdd) = GetElementsAndTypesFromSaleBuffer();

                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(3), 2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    //Action - Get list of unique entries
                    List<Sales> modifiedListOfElementsToAdd;
                    modifiedListOfElementsToAdd = GetListOfUniqueEntries(listOfElementsToAdd);

                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(string.Format(this.BwStepsDescription.ElementAt(4),
                        modifiedListOfElementsToAdd.Count()),
                        2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    //Action - Add data to DB
                    this.databaseCommands.AddToSales(modifiedListOfElementsToAdd);

                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(5), 2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    //Action - Creat data sources for given data
                    GenerateDataSourcesAdFillWithData(elementsTypeList);

                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(6), 2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    //Action - Update sales table
                    UpdateSalesQuantityInStock(this.SaleBufforReading.DataFromElzab, NORMAL_SALE_INDEX);

                    //ChangeStatus
                    communicationProgressUpdate.GenerateMessage(this.BwStepsDescription.ElementAt(7), 2.0);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                }

            }
            catch (Exception ex)
            {
                communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Error;
                communicationProgressUpdate.Text = ex.Message + ex.InnerException;
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
            }
        }
        private void ReadSalesBufferFromFile(object sender, OpenFileDialog openFileDialog)
        {
            //Local variables
            BwElzabCommunicationProgressUpdate communicationProgressUpdate = new BwElzabCommunicationProgressUpdate();

            try
            {
                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(1), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Generate data from file
                GetSaleDataFromFile(openFileDialog);

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(2), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Get element type and values list
                List<int> elementsTypeList;
                List<Sales> listOfElementsToAdd;
                (elementsTypeList, listOfElementsToAdd) = GetElementsAndTypesFromSaleBuffer();

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(3), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Get list of unique entries
                List<Sales> modifiedListOfElementsToAdd;
                modifiedListOfElementsToAdd = GetListOfUniqueEntries(listOfElementsToAdd);

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(string.Format(this.BwStepsDescriptionFromFile.ElementAt(4), 
                    modifiedListOfElementsToAdd.Count()),
                    2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Add data to DB
                this.databaseCommands.AddToSales(modifiedListOfElementsToAdd);

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(5), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Creat data sources for given data
                GenerateDataSourcesAdFillWithData(elementsTypeList);

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(6), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                //Action - Update sales table
                UpdateSalesQuantityInStock(this.SaleBufforReading.DataFromElzab, NORMAL_SALE_INDEX);

                //ChangeStatus
                communicationProgressUpdate.GenerateMessage(this.BwStepsDescriptionFromFile.ElementAt(7), 2.0);
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

            }
            catch (Exception ex)
            {
                communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Error;
                communicationProgressUpdate.Text = ex.Message + ex.InnerException;
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
            }
        }
        private void GenerateDataSourcesAdFillWithData(List<int> elementsTypeList)
        {
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
                string tableName = this.SaleBufforReading.GetTheNameOfGivenElementType(type);

                //Add data to data source
                List<AttributeValueObject> dataToAdd = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);

                AddDataFromElzabToDataSource(dataToAdd, tableName, columNames);
            }
        }
        private void AddDataGridToTabPage()
        {
            foreach(DataTable dataSource in this.DataSource)
            {
                //Add new data grid to the collection
                this.DataGridViewsList.Add(new Zuby.ADGV.AdvancedDataGridView());
                this.DataGridViewsList.Last().SetDoubleBuffered();

                //Attach data source
                this.DataGridViewsList.Last().DataSource = dataSource;

                //Make it look nice
                this.DataGridViewsList.Last().Dock = DockStyle.Fill;
                this.DataGridViewsList.Last().ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.DataGridViewsList.Last().AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.DataGridViewsList.Last().AllowUserToAddRows = false;

                this.DataGridViewsList.Last().AutoResizeColumns();

                //Add events
                this.DataGridViewsList.Last().FilterStringChanged += AdvancedDataGridView1_FilterStringChanged;
                this.DataGridViewsList.Last().SortStringChanged += AdvancedDataGridView1_SortStringChanged;

                //Add grid view to the tab page
                this.tcDataFromFile.TabPages.Add(new TabPage(dataSource.TableName));
                int index = this.tcDataFromFile.TabPages.Count - 1;
                this.tcDataFromFile.TabPages[index].Controls.Add(this.DataGridViewsList.Last());
            }
        }
        private void AddDataFromElzabToDataSource(List<AttributeValueObject> dataToAdd, string tableName, List<string> columnNames)
        {
            //If table with given name does not exist, create one
            if(!this.DataSource.Exists(t => t.TableName == tableName))
            {
                //Add data table to the source first
                this.DataSource.Add(new DataTable());
                this.DataSource.Last().TableName = tableName;

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
            }

            //Get index of given DataTable name
            int index = this.DataSource.IndexOf(this.DataSource.Find(t => t.TableName == tableName));

            foreach (AttributeValueObject data in dataToAdd)
            {
                //Exclude first attribute (which is element type)
                List<string> dataMod = data.AttributeValue.Skip(1).ToList();

                //Create new row
                DataRow newRow = this.DataSource[index].NewRow();

                int i = 0;
                foreach (string attributeValue in dataMod)
                {
                    newRow.SetField<string>(i, attributeValue);
                    i++;
                }

                //Add row to data source
                this.DataSource[index].Rows.Add(newRow);
            }

        }
        private void GetSaleDataFromFile(OpenFileDialog openFileDialog)
        {
            //Try cast the sender
            string fileFullPath = openFileDialog.FileName;

            //File information
            string directoryName = Path.GetDirectoryName(fileFullPath);
            string fileName = Path.GetFileName(fileFullPath);

            //Clear old data
            this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
            this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

            //Set path to the file
            this.SaleBufforReading.DataFromElzab.SetNewPath(directoryName);

            //Generate object data from file
            this.SaleBufforReading.DataFromElzab.GenerateObjectFromRawData();
        }
        private CommandExecutionStatus GetSaleDataFromCashRegister()
        {
            this.SaleBufforReading.Config.ChangeCashRegisterConnectionData
                (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
            //Reset to default path
            this.SaleBufforReading.DataFromElzab.RestoreDefaultPath();

            //Clear object data
            this.SaleBufforReading.DataToElzab.Element.RemoveAllElements();
            this.SaleBufforReading.DataFromElzab.Element.RemoveAllElements();

            //Execute command
            CommandExecutionStatus status = this.SaleBufforReading.ExecuteCommand();

            return status;
        }
        private List<Sales> GetListOfUniqueEntries(List<Sales> listOfElementsToAdd)
        {
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

            return modifiedListOfElementsToAdd;
        }
        private (List<int> elementsTypeList, List<Sales> listOfElementsToAdd) GetElementsAndTypesFromSaleBuffer()
        {
            //Get list of element type
            List<int> elementsTypeList = this.SaleBufforReading.DataFromElzab.GetListOfElementTypes();
            List<Sales> listOfElementsToAdd = new List<Sales>();
            foreach (int type in elementsTypeList)
            {
                //Get list of all elements of given type
                List<AttributeValueObject> elementsList = this.SaleBufforReading.DataFromElzab.GetElementsOfTypeAllValues(type);
                listOfElementsToAdd.AddRange(ElzabRelated.ParseElzabBufferToDbObject(elementsList));
            }

            return (elementsTypeList, listOfElementsToAdd);
        }
        #endregion

        #region Public methods
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
            List<string> listOfElementAlreadyUpdatedInDb = new List<string>();

            //Loop through all elements and check if unique Id exist in DB
            foreach (AttributeValueObject element in dataFromElzab.Element.ElementsList[elementTypeIndex])
            {
                //Check if product exist
                bool idExist = this.databaseCommands.CheckIfUniqueIdExist(element.UniqueIdentifier);

                if (idExist)
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

            //Write data to the summary class
            this.ReadSalesSummaryData.ListOfElementAdded = listOfElementAdded;
            this.ReadSalesSummaryData.ListOfElementAlreadyUpdatedInDb = listOfElementAlreadyUpdatedInDb;
            this.ReadSalesSummaryData.ListOfElementDeleted = listOfElementDeleted;
            this.ReadSalesSummaryData.ListOfElementNotDetermined = listOfElementNotDetermined;


        }
        #endregion

    }
}
