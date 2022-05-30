using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;
using System.Diagnostics;
using NaturalnieApp.Forms.Common;
using System.Text.RegularExpressions;

namespace NaturalnieApp.Forms
{

    public partial class AddToStock : UserControl
    {
        #region Object fields
        //Set the instance fields
        private DatabaseCommands databaseCommands { get; set; }

        //Global variables
        private Product ProductEntity { get; set; }
        private Tax TaxEntity { get; set; }

        //Marigin related
        private int LastValidValueOfMarigin { get; set; }
        private int MariginValueToChangeTo { get; set; }

        //Data source for advanced data grid view
        private DataTable DataSource { get; set; }
        private DataSourceRelated.AddToStockDataSourceColumnNames ColumnNames;

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }
        private bool SelectedFromBarcode { get; set; }

        //Printer instance
        Printer DymoPrinter;
        #endregion

        #region Class constructor
        public AddToStock(ref DatabaseCommands commandsObj)
        {
            //Call init component
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Check current date
            this.dtpDateOfAccept.Value = DateTime.Now;
            this.dtpExpirationDate.Value = DateTime.Now.AddMonths(3);

            //Initialize name of current user control
            this.lName.Text = "Dodaj do magazynu";

            //Number of products
            this.tbQuantity.Text = "1";

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.PriceNet = "Cena netto";
            this.ColumnNames.FinalPrice = "Cena klienta";
            this.ColumnNames.Tax = "VAT";
            this.ColumnNames.AddDate = "Data dodania";
            this.ColumnNames.NumberOfPieces = "Liczba produktów";
            this.ColumnNames.ExpirenceDate = "Data ważności";
            this.DataSource = new DataTable();

            InitializeAdvancedDataGridView();

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;
            this.SelectedFromBarcode = false;

            //Marigin modification
            this.LastValidValueOfMarigin = 30;
            this.MariginValueToChangeTo = this.LastValidValueOfMarigin;
            this.tbMarigin.Text = this.LastValidValueOfMarigin.ToString();


        }
        #endregion
        //====================================================================================================
        //General methods
        #region General methods
        //Methos used to update control
        private void UpdateControl(ref TextBox dummyForControl)
        {
            //this.Select();
            this.Focus();
            dummyForControl.Select();
        }
        private void tbDummyForCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Tab)
            {
                TextBox localSender = (TextBox)sender;
                localSender.Text = "";
            }
        }

        //Method used to clear all object (text box, combo box, etc.)  data
        private void ClearAllObjectsData()
        {
            this.tbFinalPrice.Text = "";
            this.tbMarigin.Text = "";
            this.tbActualQuantity.Text = "";
        }
        private void FillWithDataFromObject(Product p, Tax t)
        {
            //Elzab product number
            this.tbMarigin.Text = p.Marigin.ToString();
            this.tbFinalPrice.Text = string.Format("{0:0.00}", p.FinalPrice.ToString());

            //GEt actual guantity in stock
            this.tbActualQuantity.Text = this.databaseCommands.GetStockQuantity(p.Id).ToString();

            //Update quantity on list
            UpdateQuantityOnList();
        }

        //Method used to update final price value
        private void UpdateFinalPrice()
        {
            //Update Final price
            this.ProductEntity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(this.ProductEntity,
                Convert.ToInt32(this.TaxEntity.TaxValue));

            //Show updated value
            this.tbFinalPrice.Text = string.Format("{0:0.00}", this.ProductEntity.FinalPrice.ToString());
        }

        //Method used to update stock quantity
        private void UpdateQuantityOnList()
        {
            int quantity = 0;

            if (this.DataSource.Rows.Count > 0)
            {

                foreach (DataRow element in this.DataSource.Rows)
                {
                    //Get quantity for each row
                    quantity += element.Field<int>(this.ColumnNames.NumberOfPieces);
                }
            }

            this.tbQuantityOnList.Text = quantity.ToString();
        }

        private void AddProductToTheList(Product product, Tax tax)
        {
            //Local variables
            Product entity = product;
            Tax taxEntity = tax;

            //Index of existing row
            int indexOfExistingRow = -1;
            bool productAlreadyOnTheList = false;

            //Check if product already exist on list
            foreach (DataRow rowElement in this.DataSource.Rows)
            {
                string productName = rowElement.Field<string>(this.ColumnNames.ProductName);
                if (productName.Contains(entity.ProductName))
                {
                    indexOfExistingRow = this.DataSource.Rows.IndexOf(rowElement);
                    productAlreadyOnTheList = true;
                    break;
                }
            }

            //Increment number of copies if product already exist on the list
            if (productAlreadyOnTheList)
            {
                this.DataSource.Rows[indexOfExistingRow].SetField(this.ColumnNames.NumberOfPieces,
                    this.DataSource.Rows[indexOfExistingRow].Field<Int32>(this.ColumnNames.NumberOfPieces) + Int32.Parse(this.tbQuantity.Text));
            }
            else
            {
                //New data row type
                DataRow row;
                row = this.DataSource.NewRow();

                //Set requred fields
                row.SetField(this.ColumnNames.ProductName, entity.ProductName);
                row.SetField(this.ColumnNames.PriceNet, entity.PriceNet);
                row.SetField(this.ColumnNames.Tax, taxEntity.TaxValue);
                row.SetField(this.ColumnNames.FinalPrice, entity.FinalPrice);
                row.SetField(this.ColumnNames.AddDate, this.dtpDateOfAccept.Value.Date);
                row.SetField(this.ColumnNames.NumberOfPieces, Convert.ToInt32(this.tbQuantity.Text));
                if (this.chbExpDateReq.Checked) row.SetField(this.ColumnNames.ExpirenceDate, this.dtpExpirationDate.Value.Date);
                else row.SetField(this.ColumnNames.ExpirenceDate, DateTime.MinValue);

                //Assign values to the proper rows
                this.DataSource.Rows.Add(row);
            }
        }
        #endregion
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

            column.ColumnName = this.ColumnNames.No;
            column.DataType = Type.GetType("System.Int32");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceNet;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Tax;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.FinalPrice;
            column.DataType = Type.GetType("System.Single");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfPieces;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.AddDate;
            column.DataType = Type.GetType("System.DateTime");
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ExpirenceDate;
            column.DataType = Type.GetType("System.DateTime");
            this.DataSource.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSource;

            advancedDataGridView1.AutoResizeColumns();
        }
        private void advancedDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Update quantity on list
            UpdateQuantityOnList();
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
            //Update quantity on list
            UpdateQuantityOnList();

            //Renumber no column values if necessary
            UpdateNoColumnValues(this.DataSource, this.ColumnNames.No);
        }
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Local variables
            string entityName = "";

            //Get the name of current entity from data grid view
            if (this.DataSource.Columns[e.ColumnIndex].ColumnName == this.ColumnNames.ProductName)
            {
                entityName = this.DataSource.Rows[e.RowIndex].Field<string>(e.ColumnIndex);
                this.ucSearchBar.SelectEntityByName(entityName);
            }


        }
        private void advancedDataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Select last cell from view
            this.advancedDataGridView1.CurrentCell = this.advancedDataGridView1.Rows[e.RowIndex].Cells[this.ColumnNames.ProductName];

            //Renumber no column values if necessary
            UpdateNoColumnValues(this.DataSource, this.ColumnNames.No);
        }
        private void UpdateNoColumnValues(DataTable dataTable, string noColumnName)
        {
            //Get number of rows in data source
            int numberOfRows = dataTable.Rows.Count;

            //Get value of No column in last row
            int noValueOfLastRow = dataTable.Rows[numberOfRows - 1].Field<int>(noColumnName);

            //Check if equal. If not renumbere all
            if(numberOfRows != noValueOfLastRow)
            {
                for(int i=1; i<=numberOfRows;i++)
                {
                    dataTable.Rows[i - 1].SetField<int>(noColumnName, i);
                }
            }
        }
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void AddToStock_Load(object sender, EventArgs e)
        {

            this.dtpDateOfAccept.Value = DateTime.Now;
            this.dtpExpirationDate.Value = DateTime.Now.AddMonths(3);

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.BarcodeValidEventGenerated = false;
            this.BarcodeReader.CheckIfBarcodeFromReader(keyData);

            if ((keyData == Keys.Enter) && (!this.BarcodeValidEventGenerated))
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (keyData == Keys.Escape)
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {
            if (e.Ready && e.Valid)
            {
                string barcodeToSearch;
                //If short barcode try to get full barcode
                if (e.RecognizedBarcodeValue.Length == 8)
                {
                    barcodeToSearch = this.databaseCommands.GetEAN13FromShortBarcode(e.RecognizedBarcodeValue);
                    if (barcodeToSearch == "" || barcodeToSearch == null) barcodeToSearch = e.RecognizedBarcodeValue;
                }
                else barcodeToSearch = e.RecognizedBarcodeValue;

                if (this.cbAddWithEveryScanCycle.Checked)
                {
                    this.SelectedFromBarcode = true;
                }
                //Get index
                if (!this.ucSearchBar.SelectBarcode(barcodeToSearch))
                {
                    MessageBox.Show("Brak kodu '" + e.RecognizedBarcodeValue + "' na liście kodów kreskowych", "Brak kodu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.SelectedFromBarcode = false;
                }
            }

            //Set variable informing Bar code read corrected
            this.BarcodeValidEventGenerated = true;
        }
        #endregion     
        //====================================================================================================
        //MArigin events
        #region Marigin events
        private void tbMarigin_Validating(object sender, CancelEventArgs e)
        {
            //Cast an object
            TextBox localSender = (TextBox)sender;

            try
            {
                if (this.ProductEntity != null)
                {
                    int value;
                    //Try parse input value
                    value = Int32.Parse(localSender.Text);
                    if (value > 0 && value <= 100)
                    {
                        this.LastValidValueOfMarigin = this.MariginValueToChangeTo;
                        this.MariginValueToChangeTo = value;
                        this.ProductEntity.Marigin = this.MariginValueToChangeTo;
                        UpdateFinalPrice();
                    }
                    else localSender.Text = this.LastValidValueOfMarigin.ToString();
                }
                else
                {
                    MessageBox.Show("Nie wybrano produktu do zmiany marży!");
                }
            }
            catch (FormatException ex)
            {
                localSender.Text = this.LastValidValueOfMarigin.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bMariginChange_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.ProductEntity != null)
                {
                    //Get current selected entity
                    Product entity = this.databaseCommands.GetProductEntityByProductName(this.ProductEntity.ProductName);

                    //Check if marigin value has changed
                    if (entity.Marigin != this.MariginValueToChangeTo)
                    {
                        //Change Marigin in DB
                        entity.Marigin = this.MariginValueToChangeTo;
                        entity.FinalPrice = this.ProductEntity.FinalPrice;
                        this.databaseCommands.EditProduct(entity);
                        MessageBox.Show("Udało się zmodyfikować wartość marży!:)");

                        bUpdate_Click(sender, EventArgs.Empty);
                    }
                    else
                    {
                        //Show message box
                        MessageBox.Show("Wprowadzona marża jest taka sama jak wprowadzoan w bazie danych. Nie dokonano modyfikacji");
                    }
                }
                else
                {
                    MessageBox.Show("Nie wybrano produktu do zmiany marży!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateControl(ref tbDummyForCtrl);

        }
        #endregion
        //====================================================================================================
        //Quantity events
        #region Quantity events
        private void tbQuantity_Validating(object sender, CancelEventArgs e)
        {
            //Cast an object
            TextBox localSender = (TextBox)sender;

            try
            {
                int value = Int32.Parse(localSender.Text);
            }
            catch (FormatException)
            {
                localSender.Text = "1";
            }
        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć okno?", "Zamknięcie okna programu", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Parent.Show();
                this.Dispose();
            }
        }
        private void bSave_Click(object sender, EventArgs e)
        {
            //Local variables
            Stock stockPiece = new Stock();

            if (this.DataSource.Rows.Count == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {

                //Local list of the element to remove from data grid view
                List<DataRow> rowsToRemove = new List<DataRow>();

                //Loop throught all elements and add it to DB
                foreach (DataRow element in this.DataSource.Rows)
                {
                    try
                    {
                        //Add product to local stock variable
                        stockPiece.ProductId = this.databaseCommands.GetProductIdByName(element.Field<string>(this.ColumnNames.ProductName));
                        stockPiece.ActualQuantity = element.Field<int>(this.ColumnNames.NumberOfPieces);
                        stockPiece.LastQuantity = stockPiece.ActualQuantity;
                        stockPiece.ModificationDate = element.Field<DateTime>(this.ColumnNames.AddDate).Date;
                        DateTime expirenceDate = element.Field<DateTime>(this.ColumnNames.ExpirenceDate);

                        //Need to implement for product with date
                        stockPiece.BarcodeWithDate = null;

                        if (element.Field<DateTime>(this.ColumnNames.ExpirenceDate) != DateTime.MinValue)
                        {
                            stockPiece.ExpirationDate = element.Field<DateTime>(this.ColumnNames.ExpirenceDate).Date;
                        }

                        //Check if product already exist in stock. If no add it. If yes, increment quantity
                        bool checkResult = this.databaseCommands.CheckIfProductExistInStock(stockPiece);
                        if (checkResult)
                        {
                            Stock localStock = this.databaseCommands.GetStockEntityByUserStock(stockPiece);
                            int localQuantity = localStock.ActualQuantity;
                            localStock.LastQuantity = localStock.ActualQuantity;
                            localStock.ActualQuantity += stockPiece.ActualQuantity;
                            this.databaseCommands.EditInStock(localStock);

                            // Assigne elzab product id, if was removed from cash register
                            if (localStock.LastQuantity <= 0 && localStock.ActualQuantity > 0)
                            {
                                try
                                {
                                    this.databaseCommands.AssigneNewElzabProductId(stockPiece.ProductId);
                                }
                                catch (ElzabRelated.NoMoreCashRegisterIdsAvailable ex)
                                {
                                    MessageBox.Show("Brak miejsca na kasie fiskalnej dla nowych produktóW.");
                                }
                            }
                        }
                        else
                        {
                            stockPiece.LastQuantity = 0;
                            try
                            {
                                this.databaseCommands.AssigneNewElzabProductId(stockPiece.ProductId);
                            }
                            catch (ElzabRelated.NoMoreCashRegisterIdsAvailable ex)
                            {
                                MessageBox.Show("Brak miejsca na kasie fiskalnej dla nowych produktóW.");
                            }
                            this.databaseCommands.AddToStock(stockPiece);
                        }



                        //Add row to the remove list
                        rowsToRemove.Add(element);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                //Show message
                if (rowsToRemove.Count == this.DataSource.Rows.Count) MessageBox.Show("Wszystkie produkty zostały dodane do bazy danych!");
                else if (rowsToRemove.Count > 0) MessageBox.Show("Nie wszystkie produkty zostały dodane do bazy danych");


                DialogResult decision = MessageBox.Show("Czy chcesz od razu wydrukować etykiety?", "Drukować?", MessageBoxButtons.YesNoCancel);

                if (decision == DialogResult.Yes)
                {
                    bPrint_Click(sender, e);

                    //Remove added rows from data source
                    foreach (DataRow element in rowsToRemove)
                    {
                        this.DataSource.Rows.Remove(element);
                    }

                }
                else if (decision == DialogResult.No)
                {
                    //Remove added rows from data source
                    foreach (DataRow element in rowsToRemove)
                    {
                        this.DataSource.Rows.Remove(element);
                    }
                }

                UpdateControl(ref tbDummyForCtrl);

                bUpdate_Click(sender, EventArgs.Empty);
            }
        }
        private void bUpdate_Click(object sender, EventArgs e)
        {
            this.ucSearchBar.UpdateCurrentEntity();

            cbAddWithEveryScanCycle.Checked = false;

            //Clear all data from current form
            ClearAllObjectsData();

        }
        private void chbExpDateReq_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox localSender = (CheckBox)sender;
            //if (localSender.Checked) this.pExpirationDate.Show();
            //else this.pExpirationDate.Hide();

            UpdateControl(ref tbDummyForCtrl);
        }
        private void bPrint_Click(object sender, EventArgs e)
        {
            DataRow[] rowsToPrint = this.DataSource.Select(this.DataSource.DefaultView.RowFilter);

            PrinterRelated.PrintFromRowsByProductName(this.DymoPrinter, rowsToPrint, this.DataSource.Columns[ColumnNames.ProductName].Ordinal,
                this.DataSource.Columns[ColumnNames.NumberOfPieces].Ordinal, this.databaseCommands);

            this.DymoPrinter = null;

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        #endregion
        //====================================================================================================
        //Search bar events
        #region Search bar events
        private void ucSearchBar_NewEntSelected(object sender, SearchBarTemplate.NewEntSelectedEventArgs e)
        {
            //Set local variables
            this.ProductEntity = e.SelectedProduct;
            this.TaxEntity = e.SelectedTax;

            if(this.SelectedFromBarcode)
            {
                try
                {
                    //Add product to the list
                    this.AddProductToTheList(this.ProductEntity, this.TaxEntity);

                    //AutoResize Columns
                    advancedDataGridView1.AutoResizeColumns();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            //Fill with received data
            FillWithDataFromObject(this.ProductEntity, this.TaxEntity);

            this.SelectedFromBarcode = false;

        }
        private void ucSearchBar_GenericButtonClick(object sender, SearchBarTemplate.GenericButtonClickEventArgs e)
        {
            try
            {
                //Add product to the list
                this.AddProductToTheList(e.SelectedProduct, e.SelectedTax);

                //AutoResize Columns
                advancedDataGridView1.AutoResizeColumns();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //Update quantity on list
            UpdateQuantityOnList();

            //Select next control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void ucSearchBar_CopyButtonClick(object sender, SearchBarTemplate.CopyButtonClickEventArgs e)
        {
            CopiedProduct p = CopiedProduct.GetInstance();
            p.SetEnts(e.SelectedProduct, e.SelectedManufacturer, e.SelectedSupplier, e.SelectedTax);
        }
        private void ucSearchBar_PasteButtonClick(object sender, EventArgs e)
        {
            CopiedProduct p = CopiedProduct.GetInstance();
            (sender as Common.SearchBarTemplate).SelectEntityByName(p.GetEnts().productEntity.ProductName);
        }
        #endregion
    }
}
