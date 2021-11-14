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
        ElzabCommand_KTOWAR ProductRemoving { get; set; }
        ElzabCommand_ODBARKOD AdditionBarcodesReading { get; set; }
        ElzabCommand_ZDBARKOD AdditionBarcodesWriting { get; set; }
        ElzabCommand_OPSPROZ4 SaleBufforReading { get; set; }

        DatabaseCommands databaseCommands;
        TextBox StatusBox { get; set; }

        //Data source for advanced data grid view
        private Dictionary<string, DataTable> DataSource { get; set; }
        private DataTable ReferenceTable { get; set; }
        private DataSourceRelated.CashRegisterProductColumnNames ColumnNames;

        //Data Grid View List
        private List<Zuby.ADGV.AdvancedDataGridView> DataGridViewsList { get; set; }

        //Readonly fields with backgroundworker steps description
        #region Readonly fields with backgroundworker steps description
        private List<string> BwStepsDescription
        {
            get
            {
                return new List<string>() 
                {
                    "0. Błąd:(",
                    "1.Generowanie listy produktów do odczytu",
                    "2.Odczyt produktów z kasy",
                    "3.Parsowanie odczytanych produktów",
                    "4.Odczyt dodatkowych kodów z kasy",
                    "5.Parsowanie odczytanych produktów",
                    "6.Pobieranie z bazy danych informacji o wszystkich produktach",
                    "7.Porównywanie informacji z bazy danych i kasy fiskalnej",
                    "8. Sprawdzanie listy towarów do usunięcia w kasie Elzab",
                    "9.Przygotowanie danych do wyświetlenia",
                    "10. Oczekiwanie na akcję użytkownika"
                };
            }
        }
        #endregion

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

        #region Class constructor
        public ElzabSynchronization(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            //Initialization of Elzab commands instances
            this.AllProductsReading = new ElzabCommand_OTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);
            //Initialization of Elzab commands instances
            this.AdditionBarcodesReading = new ElzabCommand_ODBARKOD(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);
            //Initialization of Elzab commands instances
            this.ProductWriting = new ElzabCommand_ZTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);
            //Initialization of Elzab commands instances
            this.ProductRemoving = new ElzabCommand_KTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);
            //Initialization of Elzab commands instances
            this.AdditionBarcodesWriting = new ElzabCommand_ZDBARKOD(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId,
                Program.GlobalVariables.ElzabPortCom.PortName, Program.GlobalVariables.ElzabPortCom.BaudRate);
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
            this.DataSource = new Dictionary<string, DataTable>();
            this.ReferenceTable = new DataTable();
            InitializeReferenceTable();

            //Grid view
            this.DataGridViewsList = new List<Zuby.ADGV.AdvancedDataGridView>();

            //Tab control
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeBackgroundWorker();
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
                UserPrompt,
                Empty
            }
            public MessageType TypeOfMessage { get; set; }
            public string Text { get; set; }
            public double ProgressBarTime { get; set; }
            
        }
        class BwElzabCommunicationRunWorkCompleted
        {
            DataTable Data { get; set; }
        }
        #endregion

        //====================================================================================================
        //Advanced data gid view
        #region Advanced data gid view

        /// <summary>
        /// Method used to initialize advanced data grid view
        /// </summary>
        private void InitializeReferenceTable()
        {
            //Create data source columns
            DataColumn column = new DataColumn();

            column.ColumnName = this.ColumnNames.ProductNumber;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            column.Unique = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Tax;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.FinalPrice;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Barcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.AdditionaBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.ReferenceTable.Columns.Add(column);
            column.Dispose();

            this.ReferenceTable.DefaultView.Sort = this.ColumnNames.ProductNumber + " asc";
        }

        private void ClearAllDataSources()
        {
            this.DataGridViewsList.Clear();
            this.tcDataComparasionResults.TabPages.Clear();
            this.DataSource.Clear();
        }

        #endregion


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
            //Local variables
            BwElzabCommunicationProgressUpdate communicationProgressUpdate = new BwElzabCommunicationProgressUpdate();
            DataTable localDataTable = null;
            DataTable productToRemoveDataTable = null;

            try
            {
                //ChangeStatus
                communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(1);
                communicationProgressUpdate.ProgressBarTime = 1.0;
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

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
                communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(2);
                communicationProgressUpdate.ProgressBarTime = 120.0;
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                this.AllProductsReading.Config.ChangeCashRegisterConnectionData
                    (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
                CommandExecutionStatus status = this.AllProductsReading.ExecuteCommand();


                if (status.ErrorNumber == 0 && status.ErrorText != null)
                {
                    communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                    communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(3);
                    communicationProgressUpdate.ProgressBarTime = 1.0;
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    List<Product> allProductFromElzab = ElzabRelated.ParseElzabProductDataToDbObject(this.databaseCommands, this.AllProductsReading.DataFromElzab);

                    communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                    communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(4);
                    communicationProgressUpdate.ProgressBarTime = 1.0;
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                    this.AdditionBarcodesReading.Config.ChangeCashRegisterConnectionData
                        (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
                    status = this.AdditionBarcodesReading.ExecuteCommand();
                    if (status.ErrorNumber == 0 && status.ErrorText != null)
                    {
                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                        communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(5);
                        communicationProgressUpdate.ProgressBarTime = 1.0;
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                        List<Product> allAdditionaBarcodesFromElzab = ElzabRelated.ParseElzabAddBarcodesToDbObject(this.databaseCommands, this.AdditionBarcodesReading.DataFromElzab);

                        //Compare db product data with Elzab data
                        //Get all products from DB

                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                        communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(6);
                        communicationProgressUpdate.ProgressBarTime = 1.0;
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                        List<Product> dbProductList = this.databaseCommands.GetAllProductsEnts();

                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                        communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(7);
                        communicationProgressUpdate.ProgressBarTime = 1.0;
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                        List<Product> diffProductList = ElzabRelated.ComapreDbProductDataWithElzab(allProductFromElzab, dbProductList);

                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                        communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(8);
                        communicationProgressUpdate.ProgressBarTime = 1.0;
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                        //Find if any of the current Elzab product should be romeved
                        List<Product> toRemoveProductList = ElzabRelated.GetElzabProductListToDelete(allProductFromElzab, dbProductList);

                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                        communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(9);
                        communicationProgressUpdate.ProgressBarTime = 1.0;
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                        //Show differences on the list
                        foreach (Product productEnt in diffProductList)
                        {
                            if (localDataTable == null)
                            {
                                localDataTable = (e.Argument as DataTable).Copy();
                                localDataTable.TableName = "Tabela różnic";
                            }

                            //Add data to table
                            DataRow rowElement;
                            rowElement = localDataTable.NewRow();

                            //Set row fields
                            rowElement.SetField<int>(this.ColumnNames.ProductNumber, productEnt.ElzabProductId);
                            rowElement.SetField<string>(this.ColumnNames.ProductName, productEnt.ElzabProductName);
                            int taxValue = this.databaseCommands.GetTaxByProductName(productEnt.ProductName).TaxValue;
                            rowElement.SetField<int>(this.ColumnNames.Tax, taxValue);
                            rowElement.SetField<float>(this.ColumnNames.FinalPrice, productEnt.FinalPrice);
                            rowElement.SetField<string>(this.ColumnNames.Barcode, productEnt.BarCode);
                            rowElement.SetField<string>(this.ColumnNames.AdditionaBarcode, productEnt.BarCodeShort);
                            localDataTable.Rows.Add(rowElement);
                        }

                        //Show product to remove on the list
                        foreach (Product productEnt in toRemoveProductList)
                        {
                            if (productToRemoveDataTable == null)
                            {
                                productToRemoveDataTable = (e.Argument as DataTable).Copy();
                                productToRemoveDataTable.TableName = "Tabela produktów do usunięcia z kasy";
                            }

                            //Add data to table
                            DataRow rowElement;
                            rowElement = productToRemoveDataTable.NewRow();

                            //Set row fields
                            rowElement.SetField<int>(this.ColumnNames.ProductNumber, productEnt.ElzabProductId);
                            rowElement.SetField<string>(this.ColumnNames.ProductName, productEnt.ElzabProductName);
                            int taxValue = this.databaseCommands.GetTaxByElzabProductName(productEnt.ProductName).TaxValue;
                            rowElement.SetField<int>(this.ColumnNames.Tax, taxValue);
                            rowElement.SetField<float>(this.ColumnNames.FinalPrice, productEnt.FinalPrice);
                            rowElement.SetField<string>(this.ColumnNames.Barcode, productEnt.BarCode);
                            rowElement.SetField<string>(this.ColumnNames.AdditionaBarcode, productEnt.BarCodeShort);
                            productToRemoveDataTable.Rows.Add(rowElement);
                        }

                        if (diffProductList.Count() == 0 && toRemoveProductList.Count() == 0)
                        {
                            communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.UserPrompt;
                            communicationProgressUpdate.Text = "Nie znaleziono żadnych różnic między bazą danych a kasą fiskalną:).";
                            (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                        }
                        else
                        {
                            communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Update;
                            communicationProgressUpdate.Text = this.BwStepsDescription.ElementAt(10); ;
                            (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);

                            communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.UserPrompt;
                            communicationProgressUpdate.Text = string.Format("Znaleziono {0} różnic.", 
                                diffProductList.Count() + toRemoveProductList.Count());
                            (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                            System.Threading.Thread.Sleep(100);

                        }

                    }
                    else
                    {
                        communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Error;
                        communicationProgressUpdate.Text = string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}" +
                            "|Błąd komunikacji",
                        status.ErrorNumber, status.ErrorText);
                        (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                    }

                }
                else
                {
                    communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Error;
                    communicationProgressUpdate.Text = string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}" +
                        "|Błąd komunikacji",
                        status.ErrorNumber, status.ErrorText);
                    (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                }


                //Pass the local datatable
                e.Result = new Dictionary<string, DataTable> { { "differences", localDataTable },
                    { "toRemove", productToRemoveDataTable } };
            }
            catch (Exception ex)
            {
                communicationProgressUpdate.TypeOfMessage = BwElzabCommunicationProgressUpdate.MessageType.Error;
                communicationProgressUpdate.Text = ex.Message + ex.InnerException;
                (sender as BackgroundWorker).ReportProgress(0, communicationProgressUpdate);
                e.Result = new Dictionary<string, DataTable> { { "differences", localDataTable },
                    { "toRemove", productToRemoveDataTable } };
            }
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
                    this.StatusBox.Text = this.BwStepsDescription.ElementAt(0);
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
            Dictionary<string, DataTable> localDataTable = (e.Result as Dictionary<string, DataTable>);

            if(localDataTable["differences"] != null)
            {
                this.DataSource.Add("differences", localDataTable["differences"]);
            }
            else
            {
                this.DataSource.Add("differences", null);
            }

            if (localDataTable["toRemove"] != null)
            {
                this.DataSource.Add("toRemove", localDataTable["toRemove"]);
            }
            else
            {
                this.DataSource.Add("toRemove", null);
            }

            this.AddDataGridToTabPage();
            this.bReadingFromCashRegister.Enabled = true;
        }
        #endregion

        private void AddDataGridToTabPage()
        {
            foreach (KeyValuePair<string, DataTable> dataSource in this.DataSource)
            {
                //Add new data grid to the collection
                this.DataGridViewsList.Add(new Zuby.ADGV.AdvancedDataGridView());
                this.DataGridViewsList.Last().SetDoubleBuffered();

                //Attach data source
                this.DataGridViewsList.Last().DataSource = dataSource.Value;

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
                this.tcDataComparasionResults.TabPages.Add(new TabPage(dataSource.Value.TableName));
                int index = this.tcDataComparasionResults.TabPages.Count - 1;
                this.tcDataComparasionResults.TabPages[index].Controls.Add(this.DataGridViewsList.Last());
            }
        }

        private void bReadingFromCashRegister_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            this.ClearAllDataSources();
            this.BwElzabCommunication.RunWorkerAsync(this.ReferenceTable);

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.DataSource["differences"] != null && this.DataSource["differences"].Rows.Count > 0) |
                    (this.DataSource["toRemove"] != null && this.DataSource["toRemove"].Rows.Count > 0))
                {
                    bool operationResult = false;
                    CommandExecutionStatus status;

                    DialogResult result = MessageBox.Show("Czy na pewno chcesz nadpisać produkty w kasie Elzab?",
                        "zmiana produtów", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        List<int> productToRemove = new List<int>();
                        if (this.DataSource["toRemove"] != null)
                        {
                            foreach (DataRow element in this.DataSource["toRemove"].Rows)
                            {
                                productToRemove.Add(element.Field<int>(this.ColumnNames.ProductNumber));
                            }

                            this.ProductRemoving.DataToElzab = ElzabRelated.ParseDbObjectToElzabProductRemoveData(this.databaseCommands,
                                productToRemove,
                                this.ProductRemoving.DataToElzab);

                            //Remove old product data first, if necessary
                            operationResult = false;
                            this.ProductRemoving.Config.ChangeCashRegisterConnectionData
                                (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
                            status = this.ProductRemoving.ExecuteCommand();
                        }
                        else
                        {
                            operationResult = true;
                            status = CommandExecutionStatus.GenerateOkStatus();
                        }

                        if (status.ErrorNumber == 0 && status.ErrorText != null)
                        {
                            operationResult = true;

                        }
                        else
                        {
                            MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}",
                            status.ErrorNumber, status.ErrorText),
                            "Błąd komunikacji z kasą Elzab!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (this.DataSource["differences"] != null)
                        {
                            List<Product> productsToSave = new List<Product>();
                            foreach (DataRow element in this.DataSource["differences"].Rows)
                            {
                                productsToSave.Add(this.databaseCommands.GetProductEntityByElzabId(element.Field<int>(this.ColumnNames.ProductNumber)));
                            }

                            this.ProductWriting.DataToElzab = ElzabRelated.ParseDbObjectToElzabProductData(this.databaseCommands, productsToSave, this.ProductWriting.DataToElzab);
                            this.AdditionBarcodesWriting.DataToElzab = ElzabRelated.ParseDbObjectToElzabAddBarcodes(this.databaseCommands, productsToSave, this.AdditionBarcodesWriting.DataToElzab);


                            // Write new data
                            if (operationResult)
                            {
                                operationResult = false;
                                //Write product data
                                operationResult = false;
                                this.ProductWriting.Config.ChangeCashRegisterConnectionData
                                    (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
                                status = this.ProductWriting.ExecuteCommand();
                                if (status.ErrorNumber == 0 && status.ErrorText != null)
                                {
                                    operationResult = true;
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}",
                                    status.ErrorNumber, status.ErrorText),
                                    "Błąd komunikacji z kasą Elzab!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            //Write additiona barcodes
                            if (operationResult)
                            {
                                operationResult = false;
                                this.AdditionBarcodesWriting.Config.ChangeCashRegisterConnectionData
                                    (GlobalVariables.ElzabPortCom.PortName, GlobalVariables.ElzabPortCom.BaudRate);
                                status = this.AdditionBarcodesWriting.ExecuteCommand();
                                if (status.ErrorNumber == 0 && status.ErrorText != null)
                                {
                                    operationResult = true;
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Nie udało się skomunikować z kasą Elzab. Kod błędu: {0}, Opis błędu : {1}",
                                    status.ErrorNumber, status.ErrorText),
                                    "Błąd komunikacji z kasą Elzab!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        if (operationResult) MessageBox.Show("Zapisano!");

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
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
