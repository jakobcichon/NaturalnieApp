﻿using System.Collections.Generic;
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
        DataTable DataSoruce;
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
            this.ColumnNames.LabelBarcode = "Kod kreskowy";
            this.ColumnNames.LabelFinalPrice = "Cena klienta";
            this.ColumnNames.LabelText = "Tekst etykiety";
            this.ColumnNames.NumberOfCopies = "Liczba kopii";
            this.DataSoruce = new DataTable();
            InitializeAdvancedDataGridView();

            //List of the product to print
            ListOfTheProductToPrint = new List<Product>();

            //Barcode reader class
            this.BarcodeReader = new BarcodeRelated.BarcodeReader(100);
            this.BarcodeReader.BarcodeValid += BarcodeValidAction;
            this.BarcodeValidEventGenerated = false;
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
            column.ReadOnly = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelText;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.Unique = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.LabelFinalPrice;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.NumberOfCopies;
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            this.DataSoruce.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSoruce;

            advancedDataGridView1.AutoResizeColumns();
        }
        private void AdvancedDataGridView1_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            this.ListOfTheProductToPrint.RemoveAt(e.Row.Index);
            ;
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
        private void PrintBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            this.BarcodeValidEventGenerated = false;
            this.BarcodeReader.CheckIfBarcodeFromReader(e.KeyCode);

            if (e.KeyCode == Keys.Enter && !this.BarcodeValidEventGenerated)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (e.KeyCode == Keys.Escape)
            {

                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }
        }
        private void BarcodeValidAction(object sender, BarcodeRelated.BarcodeReader.BarcodeValidEventArgs e)
        {

            if (e.Ready && e.Valid)
            {
                //Get index
                if (!this.SearchBar.SelectBarcode(e.RecognizedBarcodeValue))
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
            if (this.DataSoruce.Rows.Count == 0)
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

                    //Loop through the list of the product to print and create temporary list contains elements multiple by number of copies
                    foreach (Product element in this.ListOfTheProductToPrint)
                    {
                        //Get number of copies from data grid view
                        int index = this.ListOfTheProductToPrint.IndexOf(element);
                        int numberOfCopies = this.DataSoruce.Rows[index].Field<Int32>(this.ColumnNames.NumberOfCopies);

                        for (int i = 1; i <= numberOfCopies; i++)
                        {
                            localList.Add(element);
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


    }
}
