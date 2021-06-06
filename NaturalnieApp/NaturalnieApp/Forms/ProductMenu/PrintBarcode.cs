using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NaturalnieApp.Database;
using System;
using System.Data;
using NaturalnieApp.Dymo_Printer;


namespace NaturalnieApp.Forms
{

    public partial class PrintBarcode : UserControl
    {
        #region Object fields

        //Data source for advanced data grid view
        DataTable DataSource { get; set; }
        DataSourceRelated.LabelDataSourceColumnNames ColumnNames;

        //List of the product to print
        List<Product> ListOfTheProductToPrint;

        //Printer instance
        Printer DymoPrinter;

        //Barcode reader
        private BarcodeRelated.BarcodeReader BarcodeReader { get; set; }
        private bool BarcodeValidEventGenerated { get; set; }

        #endregion

        #region Class constructor
        public PrintBarcode()
        {
            //Call init component
            InitializeComponent();

            //Initialize daa grid view
            this.ColumnNames.No = "Lp.";
            this.ColumnNames.ProductId = "Numer produktu w kasie Elzab";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.LabelBarcode = "Kod kreskowy";
            this.ColumnNames.LabelFinalPrice = "Cena klienta";
            this.ColumnNames.LabelText = "Tekst etykiety";
            this.ColumnNames.NumberOfCopies = "Liczba kopii";
            this.DataSource = new DataTable();
            InitializeAdvancedDataGridView();

            //List of the product to print
            ListOfTheProductToPrint = new List<Product>();

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;

            //Initialize name of current user control
            this.lName.Text = "Drukuj kod kreskowy";
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
        private void AddToDataGrid(Product product, Manufacturer manufaturer, Tax tax)
        {
            if (product != null && manufaturer != null && tax != null)
            {
                try
                {
                    //Index of existing row
                    int indexOfExistingRow = -1;
                    bool productAlreadyOnTheList = false;

                    //If filter applied, reset it.
                    if (this.DataSource.DefaultView.RowFilter != "") this.advancedDataGridView1.CleanFilter(true);

                    //Check if product already exist on list
                    foreach (DataRow rowElement in this.DataSource.Rows)
                    {
                        if (rowElement.Field<string>(this.ColumnNames.LabelText).Contains(product.ElzabProductName))
                        {
                            indexOfExistingRow = this.DataSource.Rows.IndexOf(rowElement);
                            productAlreadyOnTheList = true;
                            break;
                        }
                    }

                    //Increment number of copies if product already exist on the list
                    if (productAlreadyOnTheList)
                    {
                        this.DataSource.Rows[indexOfExistingRow].SetField(this.ColumnNames.NumberOfCopies,
                            this.DataSource.Rows[indexOfExistingRow].Field<Int32>(this.ColumnNames.NumberOfCopies) + 1);
                    }
                    else
                    {
                        //New data row type
                        DataRow row;
                        row = this.DataSource.NewRow();

                        //Set requred fields
                        row.SetField(this.ColumnNames.No, this.DataSource.Rows.Count + 1);
                        row.SetField(this.ColumnNames.ProductId, product.ElzabProductId);
                        row.SetField(this.ColumnNames.ProductName, product.ProductName);
                        row.SetField(this.ColumnNames.LabelBarcode, product.BarCodeShort);
                        row.SetField(this.ColumnNames.LabelText, product.ElzabProductName);
                        row.SetField(this.ColumnNames.LabelFinalPrice, string.Format("{0:0.00}", product.FinalPrice));
                        row.SetField(this.ColumnNames.NumberOfCopies, 1.ToString());

                        //Assign values to the proper rows
                        this.DataSource.Rows.Add(row);

                        //Add entity to the list
                        this.ListOfTheProductToPrint.Add(product);
                    }

                    //AutoResize Columns
                    advancedDataGridView1.AutoResizeColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }
            else
            {
                MessageBox.Show("Żaden produkt nie został wybrany! Nie mozna było dodać produktu do listy!");
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
            column.DataType = Type.GetType("System.String");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductId;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = true;
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
            column.ColumnName = this.ColumnNames.LabelBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelText;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelFinalPrice;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfCopies;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            this.advancedDataGridView1.DataSource = this.DataSource;

            this.advancedDataGridView1.AutoResizeColumns();
        }
        private void advancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            this.DataSource.DefaultView.RowFilter = e.FilterString;
        }
        private void advancedDataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Remove product from additional list
            int i = 0;
            foreach(DataRow row in this.DataSource.Rows)
            {
                if (row.Field<int>(this.ColumnNames.ProductId) != this.ListOfTheProductToPrint[i].ElzabProductId)
                {
                    this.ListOfTheProductToPrint.RemoveAt(i);
                }
                i++;
            }

            //Renumber no column values if necessary
            UpdateNoColumnValues(this.DataSource, this.ColumnNames.No);
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
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Local variables
            string entityName = "";

            //Get the name of current entity from data grid view
            if (this.DataSource.Columns[e.ColumnIndex].ColumnName == this.ColumnNames.ProductName)
            {
                entityName = this.DataSource.Rows[e.RowIndex].Field<string>(e.ColumnIndex);
                this.SearchBar.SelectEntityByName(entityName);
            }


        }
        private void UpdateNoColumnValues(DataTable dataTable, string noColumnName)
        {
            //Get number of rows in data source
            int numberOfRows = dataTable.Rows.Count;

            //Get value of No column in last row
            int noValueOfLastRow = dataTable.Rows[numberOfRows - 1].Field<int>(noColumnName);

            //Check if equal. If not renumbere all
            if (numberOfRows != noValueOfLastRow)
            {
                for (int i = 1; i <= numberOfRows; i++)
                {
                    dataTable.Rows[i - 1].SetField<int>(noColumnName, i);
                }
            }
        }
        #endregion
        //====================================================================================================
        //Current window events
        #region Current window events
        private void PrintBarcode_Load(object sender, EventArgs e)
        {
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

        public void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {

            if (e.Ready && e.Valid)
            {
                //Get index
                if (!this.SearchBar.SelectBarcodeByAdditionalRequest(e.RecognizedBarcodeValue))
                {
                    MessageBox.Show("Brak kodu '" + e.RecognizedBarcodeValue + "' na liście kodów kreskowych", "Brak kodu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Set variable informing Bar code read corrected
            this.BarcodeValidEventGenerated = true;
        }
        #endregion
        //====================================================================================================
        //Buttons events
        #region Buttons events
        private void bPrint_Click(object sender, EventArgs e)
        {
            if (this.DataSource.Rows.Count == 0)
            {
                MessageBox.Show("Brak wybranch elementów do druku!");
            }
            else
            {
                //Get printer device
                try
                {
                    //Check if Dymo printer instance already created
                    if (this.DymoPrinter == null)
                    {
                        //Printer instance
                        this.DymoPrinter = new Printer(Program.GlobalVariables.LabelPath);
                    }

                    //Check if printer connected
                    this.DymoPrinter.ChangePrinter(Program.GlobalVariables.DymoPrinterName);

                    //Local variables
                    List<Product> localList = new List<Product>();

                    //Local data source
                    DataTable localDataSource;

                    //Check if data source was filtered
                    if (this.DataSource.DefaultView.RowFilter != "")
                    {
                        localDataSource = this.DataSource.Select(this.DataSource.DefaultView.RowFilter).CopyToDataTable();
                    }
                    else localDataSource = this.DataSource.Copy();

                    //Loop through the list of the product to print and create temporary list contains elements multiple by number of copies
                    foreach (DataRow row in localDataSource.Rows)
                    {
                        //Get number of copies from data grid view
                        int productNumber = row.Field<Int32>(this.ColumnNames.ProductId);
                        int numberOfCopies = row.Field<Int32>(this.ColumnNames.NumberOfCopies);

                        Product product = this.ListOfTheProductToPrint.Find(p => p.ElzabProductId == productNumber);

                        for (int i = 1; i <= numberOfCopies; i++)
                        {
                            localList.Add(product);
                        }
                    }

                    //Print lables
                    this.DymoPrinter.PrintPriceCardsFromProductList(localList);

                }
                catch (NoPrinterToSelect)
                {
                    MessageBox.Show("Nie można odnaleźć drukarki firmy Dymo. Podłącz drukarkę i spróbuj ponownie!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

        }
        private void bClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć okno?", "Zamknięcie okna programu", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Parent.Show();
                this.Dispose();
            }
        }
        #endregion
        //====================================================================================================
        //Search bar events
        #region Search bar events
        private void SearchBar_GenericButtonClick(object sender, Common.SearchBarTemplate.GenericButtonClickEventArgs e)
        {
            if(e.SelectedProduct != null)
            {
                AddToDataGrid(e.SelectedProduct, e.SelectedManufacturer, e.SelectedTax);
            }
        }
        private void SearchBar_NewEntSelectedByAdditionalRequest(object sender, Common.SearchBarTemplate.NewEntSelectedEventArgs e)
        {
            if (e.SelectedProduct != null)
            {
                AddToDataGrid(e.SelectedProduct, e.SelectedManufacturer, e.SelectedTax);
            }
        }
        private void ucSearchBar_CopyButtonClick(object sender, Common.SearchBarTemplate.CopyButtonClickEventArgs e)
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
