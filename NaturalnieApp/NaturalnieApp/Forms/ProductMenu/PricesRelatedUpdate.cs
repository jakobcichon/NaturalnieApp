﻿using System;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using NaturalnieApp.PdfToExcel;
using SautinSoft;
using System.Text.RegularExpressions;
using NaturalnieApp.Database;
using NaturalnieApp.Forms;
using System.Diagnostics;

namespace NaturalnieApp.Forms
{
    public partial class PricesRelatedUpdate : UserControl
    {

        #region Object fields
        //Set the instance fields
        DatabaseCommands databaseCommands;

        //Data source for advanced data grid view
        DataTable DataSource, DataSourceAfterChanges;
        DataSourceRelated.PricesUpdateDataSourceColumnNames ColumnNames;

        //Class field helps for last excel file path
        string LastExcelFilePath { get; set; }
        #endregion

        #region Class constructor
        public PricesRelatedUpdate(ref DatabaseCommands commandsObj)
        {
            InitializeComponent();

            //Initialize database comands
            this.databaseCommands = commandsObj;

            //Initialize daa grid view
            this.ColumnNames.No = "Lp";
            this.ColumnNames.ManufacturerName = "Producent";
            this.ColumnNames.ProductName = "Nazwa produktu";
            this.ColumnNames.ProductBarcode = "Kod kreskowy";
            this.ColumnNames.PriceNet = "Cena netto";
            this.ColumnNames.Tax = "VAT";
            this.ColumnNames.Discount = "Rabat dostawcy";
            this.DataSource = new DataTable();
            this.DataSourceAfterChanges = new DataTable();
            InitializeAdvancedDataGridView();
        }
        #endregion

        #region General methods
        private void InitializeAdvancedDataGridView()
        {
            //Create data source columns
            DataColumn column = new DataColumn();

            column.ColumnName = this.ColumnNames.No;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ManufacturerName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductName;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.ProductBarcode;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceNet;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Tax;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Discount;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSource.Columns.Add(column);
            column.Dispose();

            advancedDataGridView1.DataSource = this.DataSource;
            advancedDataGridView1.AutoResizeColumns();

            //Data grid view 2
            column = new DataColumn();
            column.ColumnName = this.ColumnNames.PriceNet;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSourceAfterChanges.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Tax;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSourceAfterChanges.Columns.Add(column);
            column.Dispose();

            column = new DataColumn();
            column.ColumnName = this.ColumnNames.Discount;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = true;
            this.DataSourceAfterChanges.Columns.Add(column);
            column.Dispose();

            advancedDataGridView2.DataSource = this.DataSourceAfterChanges;
            advancedDataGridView2.AutoResizeColumns();

        }
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
        private void ReadExcel(string filePath)
        {
            //Local variables
            DataTable dataFromExcel = null;
            List<Product> listOfTheProductBeforehanges = new List<Product>();
            List<Product> listOfTheProductAfterChanges = new List<Product>();
            try
            {
                //Get excel data
                List<DataTable> excelData = ExcelBase.GetAllDataFromExcel(filePath, true);
                int previousMaufacturerId = 0;
                Manufacturer currentManufacturer = new Manufacturer();
                

                //Get proper template and get ents                
                dataFromExcel = ExcelBase.ExtractEntities(this.DataSource, excelData);

                if (dataFromExcel != null)
                {
                    //Comapre data with database
                    (listOfTheProductBeforehanges, listOfTheProductAfterChanges) = FindProductsWithChanges(dataFromExcel);
                    foreach(Product product in listOfTheProductBeforehanges)
                    {
                        //Get manufacturer name
                        if (previousMaufacturerId != product.ManufacturerId)
                            currentManufacturer = this.databaseCommands.GetManufacturerByProductName(product.ProductName);

                        DataRow newRow = this.DataSource.NewRow();
                        newRow.SetField<string>(this.ColumnNames.ManufacturerName, currentManufacturer.Name);
                        newRow.SetField<string>(this.ColumnNames.ProductName, product.ProductName);
                        newRow.SetField<string>(this.ColumnNames.ProductBarcode, product.BarCode);
                        newRow.SetField<string>(this.ColumnNames.PriceNet, product.PriceNet.ToString());
                        string taxValueString = this.databaseCommands.GetTaxEntityById(product.TaxId).TaxValue.ToString();
                        newRow.SetField<string>(this.ColumnNames.Tax, taxValueString);
                        newRow.SetField<string>(this.ColumnNames.Discount, product.Discount.ToString());

                        this.DataSource.Rows.Add(newRow);

                    }

                    foreach (Product product in listOfTheProductAfterChanges)
                    {
                        DataRow newRow = this.DataSourceAfterChanges.NewRow();
                        newRow.SetField<string>(this.ColumnNames.PriceNet, product.PriceNet.ToString());
                        string taxValueString = this.databaseCommands.GetTaxEntityById(product.TaxId).TaxValue.ToString();
                        newRow.SetField<string>(this.ColumnNames.Tax, taxValueString);
                        newRow.SetField<string>(this.ColumnNames.Discount, product.Discount.ToString());

                        this.DataSourceAfterChanges.Rows.Add(newRow);

                    }

                    if (this.DataSource.Rows.Count == 0) MessageBox.Show("Nie znaleziono różnic!");
                }
                else MessageBox.Show("Nie udało się pobrać danych z pliku!");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }
        private (List<Product> productBeforeChanges, List<Product> productAfterChanges) FindProductsWithChanges(DataTable inputTable)
        {
            //Local variables
            List<Product> productAfterChanges = new List<Product>();
            List<Product> productBeforeChanges = new List<Product>();
            int manufacturerId = 0;

            foreach (DataRow row in inputTable.Rows)
            {
                Product currentProduct = new Product();

                string manufacturerName = row.Field<string>(this.ColumnNames.ManufacturerName);

                manufacturerId = this.databaseCommands.GetManufacturerIdByName(manufacturerName);

                //Try to get product entity by name or by barcode
                currentProduct = this.databaseCommands.GetProductEntityByProductNameAndManufacturer(row.Field<string>(this.ColumnNames.ProductName), manufacturerId);
                if(currentProduct == null) currentProduct = this.databaseCommands.GetProductEntityByBarcode(row.Field<string>(this.ColumnNames.ProductBarcode));

                if (currentProduct != null)
                {
                    //Get product data from DB
                    //Get price net
                    float priceNetFromFile;
                    string priceNetFromFileRaw = row.Field<string>(this.ColumnNames.PriceNet);
                    if (priceNetFromFileRaw != "" && priceNetFromFileRaw != null)
                    {
                        double priceNetFromFileRawConv = Math.Round(Double.Parse(priceNetFromFileRaw), 2);
                        priceNetFromFile = Single.Parse(priceNetFromFileRawConv.ToString());
                    }
                    else priceNetFromFile = currentProduct.PriceNet;

                    //Get tax value
                    int taxValueFromFile;
                    string taxFromFileRaw = row.Field<string>(this.ColumnNames.Tax);
                    if (taxFromFileRaw != "" && taxFromFileRaw != null) taxValueFromFile = Int32.Parse(taxFromFileRaw);
                    else taxValueFromFile = this.databaseCommands.GetTaxByProductName(currentProduct.ProductName).TaxValue;

                    //Get discount value
                    int discountValueFromFile;
                    string discountFromFileRaw = row.Field<string>(this.ColumnNames.Discount);
                    if (discountFromFileRaw != "" && discountFromFileRaw != null) discountValueFromFile = Int32.Parse(discountFromFileRaw);
                    else discountValueFromFile = currentProduct.Discount;

                    //Validate before comaparsion
                    Validation.PriceNetValueValidation(priceNetFromFile.ToString());
                    Validation.TaxValueValidation(taxValueFromFile.ToString());
                    Validation.GeneralNumberValidation(discountValueFromFile.ToString());

                    //Get value of given Tax from db
                    Tax taxEntity = this.databaseCommands.GetTaxByProductName(currentProduct.ProductName);

                    //COmapre results
                    if(currentProduct.PriceNet != priceNetFromFile || taxEntity.TaxValue != taxValueFromFile
                        || currentProduct.Discount != discountValueFromFile)
                    {
                        //Add to the list before changes
                        Product oldProductr = currentProduct.DeepCopy();
                        productBeforeChanges.Add(oldProductr);

                        //Change product accordingly data from file
                        currentProduct.PriceNet = priceNetFromFile;
                        taxEntity.TaxValue = taxValueFromFile;
                        currentProduct.TaxId = this.databaseCommands.GetTaxIdByValue(taxEntity.TaxValue);
                        currentProduct.Discount = discountValueFromFile;

                        //Recalculate all prices
                        currentProduct.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscount(currentProduct.PriceNet, currentProduct.Discount);
                        currentProduct.FinalPrice = Calculations.CalculateFinalPriceFromProduct(currentProduct, taxEntity.TaxValue);

                        //Add product to the list after changes
                        productAfterChanges.Add(currentProduct);
                    }
                }
            }

            return (productBeforeChanges, productAfterChanges);
        }
        #endregion

        #region Data Grid View
        private void advancedDataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (advancedDataGridView1.FirstDisplayedScrollingColumnIndex >= 0)
            {
                advancedDataGridView2.FirstDisplayedScrollingColumnIndex = advancedDataGridView1.FirstDisplayedScrollingColumnIndex;
            }

            if (advancedDataGridView1.FirstDisplayedScrollingRowIndex >= 0)
            {
                advancedDataGridView2.FirstDisplayedScrollingRowIndex = advancedDataGridView1.FirstDisplayedScrollingRowIndex;
            }

        }
        private void advancedDataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Get data grid view row

            advancedDataGridView2.Rows.Remove(advancedDataGridView2.Rows[e.RowIndex]);
        }
        #endregion

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
        private void bGenerateTemplate_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Wybierz miejsce docelowe formatki";
            saveFileDialog1.DefaultExt = ".xlsb";
            saveFileDialog1.FileName = "aktualizacja_template_" + DateTime.Now.ToString("MM/dd/yyyy HH/mm");

            //Open folder dialog browser
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                string fileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);

                List<string> columnNamesList = new List<string>();
                //Get columns name list
                foreach(DataColumn column in this.DataSource.Columns)
                {
                    columnNamesList.Add(column.ColumnName);
                }

                //Get proper template
                ExcelBase.CreateExcelFile(columnNamesList, fileDirectory, fileName);
            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);
        }
        private void bAddFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Check if selected file is an excel file
                string fileExtension = Path.GetExtension(inputFileDialog.FileName);
                if ((fileExtension == ".xls") || (fileExtension == ".xlsx") || (fileExtension == ".xlsb"))
                {
                    this.DataSource.Rows.Clear();
                    this.DataSourceAfterChanges.Rows.Clear();

                    this.LastExcelFilePath = inputFileDialog.FileName;
                    ReadExcel(inputFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("Wybrano plik o błędnym rozszerzeniu. Dostepne rozszerzenia to : '.xls', 'xlsx', 'xlsb'");
                }

            }

            //Update control
            UpdateControl(ref tbDummyForCtrl);

        }
        private void bSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zapisać zmiany w bazie danych?", 
                "Zmiana danych produktów", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int numberModifiedEntities = 0;

                try
                {
                    //Save changes in database
                    foreach (DataRow row in this.DataSource.Rows)
                    {
                        //Get row from second datasource
                        int rowIndex = this.DataSource.Rows.IndexOf(row);
                        DataRow rowAfterChanges = this.DataSourceAfterChanges.Rows[rowIndex];

                        //Get product name
                        string productName = row.Field<string>(this.ColumnNames.ProductName);
                        Product productEnity = this.databaseCommands.GetProductEntityByProductName(productName);

                        productEnity.PriceNet = Single.Parse(rowAfterChanges.Field<string>(this.ColumnNames.PriceNet));
                        int taxValue = Int32.Parse(rowAfterChanges.Field<string>(this.ColumnNames.Tax));
                        int taxId = this.databaseCommands.GetTaxIdByValue(taxValue);
                        productEnity.TaxId = taxId;
                        productEnity.Discount = Int32.Parse(rowAfterChanges.Field<string>(this.ColumnNames.Discount));

                        productEnity.PriceNetWithDiscount = Calculations.CalculatePriceNetWithDiscount(productEnity.PriceNet, productEnity.Discount);
                        productEnity.FinalPrice = Calculations.CalculateFinalPriceFromProduct(productEnity, taxValue);

                        this.databaseCommands.EditProduct(productEnity);

                        numberModifiedEntities++;

                    }

                    MessageBox.Show(string.Format("Pomyślnie zapisano wszystkie dane (zmieniono {0} pozycji)", numberModifiedEntities));

                    this.DataSource.Rows.Clear();
                    this.DataSourceAfterChanges.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Anulowano!");
            }

        }
        #endregion

        #region Current window events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((keyData == Keys.Enter))
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
        #endregion


    }
}
