using NaturalnieApp.Initialization;

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
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bPrint = new System.Windows.Forms.Button();
            this.tbQuantityOnList = new System.Windows.Forms.TextBox();
            this.lQuantityOnList = new System.Windows.Forms.Label();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
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
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.chbExpDateReq = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbFinalPrice = new System.Windows.Forms.TextBox();
            this.tbActualQuantity = new System.Windows.Forms.TextBox();
            this.lActualQuantity = new System.Windows.Forms.Label();
            this.cbAddWithEveryScanCycle = new System.Windows.Forms.CheckBox();
            this.lAddWithEveryScanCycle = new System.Windows.Forms.Label();
            this.tpMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.bMariginChange = new System.Windows.Forms.Button();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lFinalPrice = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lExpirationDate = new System.Windows.Forms.Label();
            this.dtpDateOfAccept = new System.Windows.Forms.DateTimePicker();
            this.lDateOfAccept = new System.Windows.Forms.Label();
            this.lQuantity = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.tpMarigin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(920, 30);
            this.pHeader.TabIndex = 1;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 6;
            this.tbDummyForCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDummyForCtrl_KeyDown);
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
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 176);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(920, 397);
            this.advancedDataGridView1.TabIndex = 2;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.AdvancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            this.advancedDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellValueChanged);
            this.advancedDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.advancedDataGridView1_UserDeletedRow);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Controls.Add(this.tbQuantityOnList);
            this.pButtonsPanel.Controls.Add(this.lQuantityOnList);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(490, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 33;
            this.bPrint.Text = "Drukuj etykiety";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // tbQuantityOnList
            // 
            this.tbQuantityOnList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbQuantityOnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantityOnList.Location = new System.Drawing.Point(280, 22);
            this.tbQuantityOnList.Margin = new System.Windows.Forms.Padding(5);
            this.tbQuantityOnList.Name = "tbQuantityOnList";
            this.tbQuantityOnList.ReadOnly = true;
            this.tbQuantityOnList.Size = new System.Drawing.Size(123, 26);
            this.tbQuantityOnList.TabIndex = 31;
            // 
            // lQuantityOnList
            // 
            this.lQuantityOnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lQuantityOnList.Location = new System.Drawing.Point(53, 20);
            this.lQuantityOnList.Margin = new System.Windows.Forms.Padding(5);
            this.lQuantityOnList.Name = "lQuantityOnList";
            this.lQuantityOnList.Size = new System.Drawing.Size(228, 30);
            this.lQuantityOnList.TabIndex = 32;
            this.lQuantityOnList.Text = "Ilość produktów na liście";
            this.lQuantityOnList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(596, 10);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 28;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(702, 10);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 26;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(808, 10);
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
            this.gbProductSelection.Size = new System.Drawing.Size(920, 106);
            this.gbProductSelection.TabIndex = 17;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bAdd.Location = new System.Drawing.Point(849, 30);
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
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pBarCode.Controls.Add(this.cbBarcodes, 0, 1);
            this.pBarCode.Controls.Add(this.lBarcode, 0, 0);
            this.pBarCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBarCode.Location = new System.Drawing.Point(673, 30);
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
            this.cbBarcodes.SelectedIndexChanged += new System.EventHandler(this.cbBarcodes_SelectedIndexChanged);
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
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pProductName.Controls.Add(this.cbProductsList, 0, 1);
            this.pProductName.Controls.Add(this.lProductName, 0, 0);
            this.pProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pProductName.Location = new System.Drawing.Point(270, 30);
            this.pProductName.Margin = new System.Windows.Forms.Padding(0);
            this.pProductName.Name = "pProductName";
            this.pProductName.RowCount = 2;
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pProductName.Size = new System.Drawing.Size(400, 70);
            this.pProductName.TabIndex = 15;
            // 
            // cbProductsList
            // 
            this.cbProductsList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProductsList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbProductsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProductsList.DropDownHeight = 200;
            this.cbProductsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbProductsList.FormattingEnabled = true;
            this.cbProductsList.IntegralHeight = false;
            this.cbProductsList.ItemHeight = 20;
            this.cbProductsList.Location = new System.Drawing.Point(4, 35);
            this.cbProductsList.Name = "cbProductsList";
            this.cbProductsList.Size = new System.Drawing.Size(392, 28);
            this.cbProductsList.TabIndex = 2;
            this.cbProductsList.SelectedIndexChanged += new System.EventHandler(this.cbProductsList_SelectedIndexChanged);
            // 
            // lProductName
            // 
            this.lProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductName.Location = new System.Drawing.Point(6, 6);
            this.lProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(388, 20);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 397F));
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
            this.cbManufacturers.SelectedIndexChanged += new System.EventHandler(this.cbManufacturers_SelectedIndexChanged);
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
            // tbQuantity
            // 
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantity.Location = new System.Drawing.Point(75, 7);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(74, 26);
            this.tbQuantity.TabIndex = 2;
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbExpDateReq
            // 
            this.chbExpDateReq.BackColor = System.Drawing.Color.White;
            this.chbExpDateReq.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbExpDateReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExpDateReq.Location = new System.Drawing.Point(760, 4);
            this.chbExpDateReq.Name = "chbExpDateReq";
            this.chbExpDateReq.Size = new System.Drawing.Size(50, 25);
            this.chbExpDateReq.TabIndex = 2;
            this.chbExpDateReq.UseVisualStyleBackColor = false;
            this.chbExpDateReq.CheckedChanged += new System.EventHandler(this.chbExpDateReq_CheckedChanged);
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
            // tbFinalPrice
            // 
            this.tbFinalPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbFinalPrice.Location = new System.Drawing.Point(127, 6);
            this.tbFinalPrice.Margin = new System.Windows.Forms.Padding(5);
            this.tbFinalPrice.Name = "tbFinalPrice";
            this.tbFinalPrice.ReadOnly = true;
            this.tbFinalPrice.Size = new System.Drawing.Size(60, 26);
            this.tbFinalPrice.TabIndex = 27;
            // 
            // tbActualQuantity
            // 
            this.tbActualQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbActualQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbActualQuantity.Location = new System.Drawing.Point(157, 6);
            this.tbActualQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.tbActualQuantity.Name = "tbActualQuantity";
            this.tbActualQuantity.ReadOnly = true;
            this.tbActualQuantity.Size = new System.Drawing.Size(60, 26);
            this.tbActualQuantity.TabIndex = 29;
            // 
            // lActualQuantity
            // 
            this.lActualQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lActualQuantity.Location = new System.Drawing.Point(6, 6);
            this.lActualQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.lActualQuantity.Name = "lActualQuantity";
            this.lActualQuantity.Size = new System.Drawing.Size(140, 30);
            this.lActualQuantity.TabIndex = 30;
            this.lActualQuantity.Text = "Aktualna ilość";
            this.lActualQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAddWithEveryScanCycle
            // 
            this.cbAddWithEveryScanCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.cbAddWithEveryScanCycle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAddWithEveryScanCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAddWithEveryScanCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAddWithEveryScanCycle.Location = new System.Drawing.Point(165, 4);
            this.cbAddWithEveryScanCycle.Name = "cbAddWithEveryScanCycle";
            this.cbAddWithEveryScanCycle.Size = new System.Drawing.Size(50, 27);
            this.cbAddWithEveryScanCycle.TabIndex = 3;
            this.cbAddWithEveryScanCycle.UseVisualStyleBackColor = false;
            // 
            // lAddWithEveryScanCycle
            // 
            this.lAddWithEveryScanCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lAddWithEveryScanCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddWithEveryScanCycle.Location = new System.Drawing.Point(4, 1);
            this.lAddWithEveryScanCycle.Name = "lAddWithEveryScanCycle";
            this.lAddWithEveryScanCycle.Size = new System.Drawing.Size(153, 26);
            this.lAddWithEveryScanCycle.TabIndex = 31;
            this.lAddWithEveryScanCycle.Text = "Dodaj przy odczycie";
            this.lAddWithEveryScanCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpMarigin
            // 
            this.tpMarigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpMarigin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpMarigin.ColumnCount = 3;
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMarigin.Controls.Add(this.bMariginChange, 2, 0);
            this.tpMarigin.Controls.Add(this.lMarigin, 0, 0);
            this.tpMarigin.Controls.Add(this.tbMarigin, 1, 0);
            this.tpMarigin.Location = new System.Drawing.Point(0, 579);
            this.tpMarigin.Name = "tpMarigin";
            this.tpMarigin.RowCount = 1;
            this.tpMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMarigin.Size = new System.Drawing.Size(242, 35);
            this.tpMarigin.TabIndex = 9;
            // 
            // bMariginChange
            // 
            this.bMariginChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bMariginChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bMariginChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bMariginChange.Location = new System.Drawing.Point(138, 4);
            this.bMariginChange.Name = "bMariginChange";
            this.bMariginChange.Size = new System.Drawing.Size(100, 28);
            this.bMariginChange.TabIndex = 34;
            this.bMariginChange.Text = "Zmień";
            this.bMariginChange.UseVisualStyleBackColor = false;
            this.bMariginChange.Click += new System.EventHandler(this.bMariginChange_Click);
            // 
            // lMarigin
            // 
            this.lMarigin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(6, 6);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(56, 26);
            this.lMarigin.TabIndex = 29;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMarigin
            // 
            this.tbMarigin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(73, 6);
            this.tbMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(56, 26);
            this.tbMarigin.TabIndex = 33;
            this.tbMarigin.Validating += new System.ComponentModel.CancelEventHandler(this.tbMarigin_Validating);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbFinalPrice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lFinalPrice, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(246, 579);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 35);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // lFinalPrice
            // 
            this.lFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFinalPrice.Location = new System.Drawing.Point(6, 6);
            this.lFinalPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lFinalPrice.Name = "lFinalPrice";
            this.lFinalPrice.Size = new System.Drawing.Size(101, 30);
            this.lFinalPrice.TabIndex = 31;
            this.lFinalPrice.Text = "Cena klienta";
            this.lFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lActualQuantity, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbActualQuantity, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(445, 579);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(225, 35);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.cbAddWithEveryScanCycle, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lAddWithEveryScanCycle, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(677, 579);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(214, 35);
            this.tableLayoutPanel3.TabIndex = 34;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.chbExpDateReq, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpExpirationDate, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.lExpirationDate, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpDateOfAccept, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lDateOfAccept, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbQuantity, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lQuantity, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 136);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(920, 40);
            this.tableLayoutPanel4.TabIndex = 35;
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpirationDate.Location = new System.Drawing.Point(634, 7);
            this.dtpExpirationDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpExpirationDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpExpirationDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(119, 26);
            this.dtpExpirationDate.TabIndex = 7;
            this.dtpExpirationDate.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lExpirationDate
            // 
            this.lExpirationDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lExpirationDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExpirationDate.Location = new System.Drawing.Point(458, 1);
            this.lExpirationDate.Name = "lExpirationDate";
            this.lExpirationDate.Size = new System.Drawing.Size(169, 40);
            this.lExpirationDate.TabIndex = 6;
            this.lExpirationDate.Text = "Data przyjęcia towaru";
            this.lExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateOfAccept
            // 
            this.dtpDateOfAccept.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.CustomFormat = "dd/MM/yyyy";
            this.dtpDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfAccept.Location = new System.Drawing.Point(332, 7);
            this.dtpDateOfAccept.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpDateOfAccept.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfAccept.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfAccept.Name = "dtpDateOfAccept";
            this.dtpDateOfAccept.Size = new System.Drawing.Size(119, 26);
            this.dtpDateOfAccept.TabIndex = 5;
            this.dtpDateOfAccept.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lDateOfAccept
            // 
            this.lDateOfAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lDateOfAccept.Dock = System.Windows.Forms.DockStyle.Left;
            this.lDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDateOfAccept.Location = new System.Drawing.Point(156, 1);
            this.lDateOfAccept.Name = "lDateOfAccept";
            this.lDateOfAccept.Size = new System.Drawing.Size(169, 40);
            this.lDateOfAccept.TabIndex = 3;
            this.lDateOfAccept.Text = "Data przyjęcia towaru";
            this.lDateOfAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lQuantity
            // 
            this.lQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQuantity.Location = new System.Drawing.Point(4, 1);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(64, 40);
            this.lQuantity.TabIndex = 2;
            this.lQuantity.Text = "Ilość";
            this.lQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(920, 690);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tpMarigin);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddToStock";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.AddToStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddToStock_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            this.pButtonsPanel.PerformLayout();
            this.gbProductSelection.ResumeLayout(false);
            this.pBarCode.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.tpMarigin.ResumeLayout(false);
            this.tpMarigin.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.CheckBox chbExpDateReq;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbFinalPrice;
        private System.Windows.Forms.TextBox tbActualQuantity;
        private System.Windows.Forms.Label lActualQuantity;
        private System.Windows.Forms.CheckBox cbAddWithEveryScanCycle;
        private System.Windows.Forms.Label lAddWithEveryScanCycle;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.TableLayoutPanel tpMarigin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.Button bMariginChange;
        private System.Windows.Forms.Label lFinalPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbQuantityOnList;
        private System.Windows.Forms.Label lQuantityOnList;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label lExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpDateOfAccept;
        private System.Windows.Forms.Label lDateOfAccept;
        private System.Windows.Forms.Label lQuantity;
    }
}