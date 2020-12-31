﻿using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddToStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bPrint = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.pBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.cbBarcodes = new System.Windows.Forms.ComboBox();
            this.lBarcode = new System.Windows.Forms.Label();
            this.pProductName = new System.Windows.Forms.TableLayoutPanel();
            this.cbProductsList = new System.Windows.Forms.ComboBox();
            this.lProductName = new System.Windows.Forms.Label();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturers = new System.Windows.Forms.ComboBox();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.pQuantity = new System.Windows.Forms.Panel();
            this.mtbQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lQuantity = new System.Windows.Forms.Label();
            this.pSpare1 = new System.Windows.Forms.Panel();
            this.pGap1 = new System.Windows.Forms.Panel();
            this.pDataOfAccept = new System.Windows.Forms.Panel();
            this.dtpDateOfAccept = new System.Windows.Forms.DateTimePicker();
            this.lDateOfAccept = new System.Windows.Forms.Label();
            this.pSpare2 = new System.Windows.Forms.Panel();
            this.pGap2 = new System.Windows.Forms.Panel();
            this.pExpDateReq = new System.Windows.Forms.Panel();
            this.chbExpDateReq = new System.Windows.Forms.CheckBox();
            this.lExpDateReq = new System.Windows.Forms.Label();
            this.pSpare3 = new System.Windows.Forms.Panel();
            this.pGap3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pExpirationDate = new System.Windows.Forms.Panel();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lExpirationDate = new System.Windows.Forms.Label();
            this.pSpare4 = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.pQuantity.SuspendLayout();
            this.pDataOfAccept.SuspendLayout();
            this.pExpDateReq.SuspendLayout();
            this.pExpirationDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1000, 30);
            this.pHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 150);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(700, 350);
            this.advancedDataGridView1.TabIndex = 2;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 500);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(1000, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(782, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 26;
            this.bPrint.Text = "Zapisz";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(888, 10);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "Zamknij";
            this.bClose.UseMnemonic = false;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // gbProductSelection
            // 
            this.gbProductSelection.Controls.Add(this.bAdd);
            this.gbProductSelection.Controls.Add(this.pBarCode);
            this.gbProductSelection.Controls.Add(this.pProductName);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 30);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(1000, 120);
            this.gbProductSelection.TabIndex = 17;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bAdd.Location = new System.Drawing.Point(922, 30);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(70, 70);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Dodaj";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // pBarCode
            // 
            this.pBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pBarCode.ColumnCount = 1;
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 364F));
            this.pBarCode.Controls.Add(this.cbBarcodes, 0, 1);
            this.pBarCode.Controls.Add(this.lBarcode, 0, 0);
            this.pBarCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBarCode.Location = new System.Drawing.Point(740, 30);
            this.pBarCode.Margin = new System.Windows.Forms.Padding(0);
            this.pBarCode.Name = "pBarCode";
            this.pBarCode.RowCount = 2;
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pBarCode.Size = new System.Drawing.Size(175, 70);
            this.pBarCode.TabIndex = 18;
            // 
            // cbBarcodes
            // 
            this.cbBarcodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbBarcodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBarcodes.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbBarcodes.DropDownHeight = 200;
            this.cbBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbBarcodes.FormattingEnabled = true;
            this.cbBarcodes.IntegralHeight = false;
            this.cbBarcodes.ItemHeight = 20;
            this.cbBarcodes.Location = new System.Drawing.Point(4, 35);
            this.cbBarcodes.Name = "cbBarcodes";
            this.cbBarcodes.Size = new System.Drawing.Size(160, 28);
            this.cbBarcodes.TabIndex = 3;
            this.cbBarcodes.Text = "112";
            this.cbBarcodes.SelectionChangeCommitted += new System.EventHandler(this.cbBarcodes_SelectionChangeCommitted);
            // 
            // lBarcode
            // 
            this.lBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lBarcode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarcode.Location = new System.Drawing.Point(6, 6);
            this.lBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.lBarcode.Name = "lBarcode";
            this.lBarcode.Size = new System.Drawing.Size(160, 20);
            this.lBarcode.TabIndex = 0;
            this.lBarcode.Text = "Kod kreskowy";
            this.lBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pProductName
            // 
            this.pProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductName.ColumnCount = 1;
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 551F));
            this.pProductName.Controls.Add(this.cbProductsList, 0, 1);
            this.pProductName.Controls.Add(this.lProductName, 0, 0);
            this.pProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pProductName.Location = new System.Drawing.Point(270, 30);
            this.pProductName.Margin = new System.Windows.Forms.Padding(0);
            this.pProductName.Name = "pProductName";
            this.pProductName.RowCount = 2;
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pProductName.Size = new System.Drawing.Size(462, 70);
            this.pProductName.TabIndex = 15;
            // 
            // cbProductsList
            // 
            this.cbProductsList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProductsList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbProductsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbProductsList.DropDownHeight = 200;
            this.cbProductsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbProductsList.FormattingEnabled = true;
            this.cbProductsList.IntegralHeight = false;
            this.cbProductsList.ItemHeight = 20;
            this.cbProductsList.Location = new System.Drawing.Point(4, 35);
            this.cbProductsList.Name = "cbProductsList";
            this.cbProductsList.Size = new System.Drawing.Size(450, 28);
            this.cbProductsList.TabIndex = 2;
            this.cbProductsList.SelectionChangeCommitted += new System.EventHandler(this.cbProductsList_SelectionChangeCommitted);
            // 
            // lProductName
            // 
            this.lProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lProductName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductName.Location = new System.Drawing.Point(6, 6);
            this.lProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(450, 20);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 341F));
            this.pManufacturer.Controls.Add(this.cbManufacturers, 0, 1);
            this.pManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.pManufacturer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pManufacturer.Location = new System.Drawing.Point(10, 30);
            this.pManufacturer.Margin = new System.Windows.Forms.Padding(0);
            this.pManufacturer.Name = "pManufacturer";
            this.pManufacturer.RowCount = 2;
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pManufacturer.Size = new System.Drawing.Size(252, 70);
            this.pManufacturer.TabIndex = 14;
            // 
            // cbManufacturers
            // 
            this.cbManufacturers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbManufacturers.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbManufacturers.DropDownHeight = 200;
            this.cbManufacturers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturers.FormattingEnabled = true;
            this.cbManufacturers.IntegralHeight = false;
            this.cbManufacturers.ItemHeight = 20;
            this.cbManufacturers.Items.AddRange(new object[] {
            "Wszyscy"});
            this.cbManufacturers.Location = new System.Drawing.Point(4, 35);
            this.cbManufacturers.Name = "cbManufacturers";
            this.cbManufacturers.Size = new System.Drawing.Size(240, 28);
            this.cbManufacturers.TabIndex = 1;
            this.cbManufacturers.SelectionChangeCommitted += new System.EventHandler(this.cbManufacturers_SelectionChangeCommitted);
            // 
            // lManufacturer
            // 
            this.lManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lManufacturer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(6, 6);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(240, 20);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Producent";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pQuantity
            // 
            this.pQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pQuantity.Controls.Add(this.mtbQuantity);
            this.pQuantity.Controls.Add(this.lQuantity);
            this.pQuantity.Controls.Add(this.pSpare1);
            this.pQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.pQuantity.Location = new System.Drawing.Point(700, 150);
            this.pQuantity.Name = "pQuantity";
            this.pQuantity.Size = new System.Drawing.Size(300, 38);
            this.pQuantity.TabIndex = 18;
            // 
            // mtbQuantity
            // 
            this.mtbQuantity.Dock = System.Windows.Forms.DockStyle.Left;
            this.mtbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbQuantity.Location = new System.Drawing.Point(150, 10);
            this.mtbQuantity.Mask = "999";
            this.mtbQuantity.Name = "mtbQuantity";
            this.mtbQuantity.PromptChar = ' ';
            this.mtbQuantity.Size = new System.Drawing.Size(149, 26);
            this.mtbQuantity.TabIndex = 3;
            this.mtbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lQuantity
            // 
            this.lQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lQuantity.Dock = System.Windows.Forms.DockStyle.Left;
            this.lQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQuantity.Location = new System.Drawing.Point(0, 10);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(150, 26);
            this.lQuantity.TabIndex = 1;
            this.lQuantity.Text = "Ilość";
            this.lQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pSpare1
            // 
            this.pSpare1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pSpare1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSpare1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSpare1.Location = new System.Drawing.Point(0, 0);
            this.pSpare1.Name = "pSpare1";
            this.pSpare1.Size = new System.Drawing.Size(298, 10);
            this.pSpare1.TabIndex = 0;
            // 
            // pGap1
            // 
            this.pGap1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGap1.Location = new System.Drawing.Point(700, 188);
            this.pGap1.Name = "pGap1";
            this.pGap1.Size = new System.Drawing.Size(300, 20);
            this.pGap1.TabIndex = 20;
            // 
            // pDataOfAccept
            // 
            this.pDataOfAccept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDataOfAccept.Controls.Add(this.dtpDateOfAccept);
            this.pDataOfAccept.Controls.Add(this.lDateOfAccept);
            this.pDataOfAccept.Controls.Add(this.pSpare2);
            this.pDataOfAccept.Dock = System.Windows.Forms.DockStyle.Top;
            this.pDataOfAccept.Location = new System.Drawing.Point(700, 208);
            this.pDataOfAccept.Name = "pDataOfAccept";
            this.pDataOfAccept.Size = new System.Drawing.Size(300, 38);
            this.pDataOfAccept.TabIndex = 21;
            // 
            // dtpDateOfAccept
            // 
            this.dtpDateOfAccept.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.CustomFormat = "dd/MM/yyyy";
            this.dtpDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfAccept.Location = new System.Drawing.Point(176, 10);
            this.dtpDateOfAccept.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfAccept.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfAccept.Name = "dtpDateOfAccept";
            this.dtpDateOfAccept.Size = new System.Drawing.Size(122, 26);
            this.dtpDateOfAccept.TabIndex = 4;
            this.dtpDateOfAccept.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lDateOfAccept
            // 
            this.lDateOfAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lDateOfAccept.Dock = System.Windows.Forms.DockStyle.Left;
            this.lDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDateOfAccept.Location = new System.Drawing.Point(0, 10);
            this.lDateOfAccept.Name = "lDateOfAccept";
            this.lDateOfAccept.Size = new System.Drawing.Size(174, 26);
            this.lDateOfAccept.TabIndex = 1;
            this.lDateOfAccept.Text = "Data przyjęcia towaru";
            this.lDateOfAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pSpare2
            // 
            this.pSpare2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pSpare2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSpare2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSpare2.Location = new System.Drawing.Point(0, 0);
            this.pSpare2.Name = "pSpare2";
            this.pSpare2.Size = new System.Drawing.Size(298, 10);
            this.pSpare2.TabIndex = 0;
            // 
            // pGap2
            // 
            this.pGap2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGap2.Location = new System.Drawing.Point(700, 246);
            this.pGap2.Name = "pGap2";
            this.pGap2.Size = new System.Drawing.Size(300, 20);
            this.pGap2.TabIndex = 22;
            // 
            // pExpDateReq
            // 
            this.pExpDateReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pExpDateReq.Controls.Add(this.chbExpDateReq);
            this.pExpDateReq.Controls.Add(this.lExpDateReq);
            this.pExpDateReq.Controls.Add(this.pSpare3);
            this.pExpDateReq.Dock = System.Windows.Forms.DockStyle.Top;
            this.pExpDateReq.Location = new System.Drawing.Point(700, 266);
            this.pExpDateReq.Name = "pExpDateReq";
            this.pExpDateReq.Size = new System.Drawing.Size(300, 38);
            this.pExpDateReq.TabIndex = 23;
            // 
            // chbExpDateReq
            // 
            this.chbExpDateReq.BackColor = System.Drawing.Color.White;
            this.chbExpDateReq.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbExpDateReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExpDateReq.Location = new System.Drawing.Point(247, 11);
            this.chbExpDateReq.Name = "chbExpDateReq";
            this.chbExpDateReq.Size = new System.Drawing.Size(50, 25);
            this.chbExpDateReq.TabIndex = 2;
            this.chbExpDateReq.UseVisualStyleBackColor = false;
            this.chbExpDateReq.CheckedChanged += new System.EventHandler(this.chbExpDateReq_CheckedChanged);
            // 
            // lExpDateReq
            // 
            this.lExpDateReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lExpDateReq.Dock = System.Windows.Forms.DockStyle.Left;
            this.lExpDateReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExpDateReq.Location = new System.Drawing.Point(0, 10);
            this.lExpDateReq.Name = "lExpDateReq";
            this.lExpDateReq.Size = new System.Drawing.Size(257, 26);
            this.lExpDateReq.TabIndex = 1;
            this.lExpDateReq.Text = "Data ważności wymagana ?";
            this.lExpDateReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pSpare3
            // 
            this.pSpare3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pSpare3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSpare3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSpare3.Location = new System.Drawing.Point(0, 0);
            this.pSpare3.Name = "pSpare3";
            this.pSpare3.Size = new System.Drawing.Size(298, 10);
            this.pSpare3.TabIndex = 0;
            // 
            // pGap3
            // 
            this.pGap3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGap3.Location = new System.Drawing.Point(700, 304);
            this.pGap3.Name = "pGap3";
            this.pGap3.Size = new System.Drawing.Size(300, 20);
            this.pGap3.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(298, 10);
            this.panel5.TabIndex = 0;
            // 
            // pExpirationDate
            // 
            this.pExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pExpirationDate.Controls.Add(this.dtpExpirationDate);
            this.pExpirationDate.Controls.Add(this.lExpirationDate);
            this.pExpirationDate.Controls.Add(this.pSpare4);
            this.pExpirationDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pExpirationDate.Location = new System.Drawing.Point(700, 324);
            this.pExpirationDate.Name = "pExpirationDate";
            this.pExpirationDate.Size = new System.Drawing.Size(300, 38);
            this.pExpirationDate.TabIndex = 25;
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpirationDate.Location = new System.Drawing.Point(176, 10);
            this.dtpExpirationDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpExpirationDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(122, 26);
            this.dtpExpirationDate.TabIndex = 4;
            this.dtpExpirationDate.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lExpirationDate
            // 
            this.lExpirationDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lExpirationDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExpirationDate.Location = new System.Drawing.Point(0, 10);
            this.lExpirationDate.Name = "lExpirationDate";
            this.lExpirationDate.Size = new System.Drawing.Size(174, 26);
            this.lExpirationDate.TabIndex = 1;
            this.lExpirationDate.Text = "Data przyjęcia towaru";
            this.lExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pSpare4
            // 
            this.pSpare4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pSpare4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSpare4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSpare4.Location = new System.Drawing.Point(0, 0);
            this.pSpare4.Name = "pSpare4";
            this.pSpare4.Size = new System.Drawing.Size(298, 10);
            this.pSpare4.TabIndex = 0;
            // 
            // AddToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.pExpirationDate);
            this.Controls.Add(this.pGap3);
            this.Controls.Add(this.pExpDateReq);
            this.Controls.Add(this.pGap2);
            this.Controls.Add(this.pDataOfAccept);
            this.Controls.Add(this.pGap1);
            this.Controls.Add(this.pQuantity);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddToStock";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.AddToStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddToStock_KeyDown);
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            this.gbProductSelection.ResumeLayout(false);
            this.pBarCode.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.pQuantity.ResumeLayout(false);
            this.pQuantity.PerformLayout();
            this.pDataOfAccept.ResumeLayout(false);
            this.pExpDateReq.ResumeLayout(false);
            this.pExpirationDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pBarCode;
        private System.Windows.Forms.Label lBarcode;
        private System.Windows.Forms.TableLayoutPanel pProductName;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.ComboBox cbManufacturers;
        private System.Windows.Forms.ComboBox cbBarcodes;
        private System.Windows.Forms.ComboBox cbProductsList;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel pQuantity;
        private System.Windows.Forms.MaskedTextBox mtbQuantity;
        private System.Windows.Forms.Label lQuantity;
        private System.Windows.Forms.Panel pSpare1;
        private System.Windows.Forms.Panel pGap1;
        private System.Windows.Forms.Panel pDataOfAccept;
        private System.Windows.Forms.DateTimePicker dtpDateOfAccept;
        private System.Windows.Forms.Label lDateOfAccept;
        private System.Windows.Forms.Panel pSpare2;
        private System.Windows.Forms.Panel pGap2;
        private System.Windows.Forms.Panel pExpDateReq;
        private System.Windows.Forms.CheckBox chbExpDateReq;
        private System.Windows.Forms.Label lExpDateReq;
        private System.Windows.Forms.Panel pSpare3;
        private System.Windows.Forms.Panel pGap3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label lExpirationDate;
        private System.Windows.Forms.Panel pSpare4;
        private System.Windows.Forms.Button bPrint;
    }
}