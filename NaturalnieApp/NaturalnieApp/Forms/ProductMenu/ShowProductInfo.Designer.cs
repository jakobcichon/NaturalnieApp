using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class ShowProductInfo
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
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lPrice = new System.Windows.Forms.Label();
            this.lQuantity = new System.Windows.Forms.Label();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.lTax = new System.Windows.Forms.Label();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.cbTax = new System.Windows.Forms.ComboBox();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.pProductName = new System.Windows.Forms.TableLayoutPanel();
            this.cbProductList = new System.Windows.Forms.ComboBox();
            this.lProductName = new System.Windows.Forms.Label();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lProductInfo = new System.Windows.Forms.Label();
            this.rtbProductInfo = new System.Windows.Forms.RichTextBox();
            this.tpBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.lBarCode = new System.Windows.Forms.Label();
            this.tpSupplierName = new System.Windows.Forms.TableLayoutPanel();
            this.tbSuppierName = new System.Windows.Forms.TextBox();
            this.lSupplierName = new System.Windows.Forms.Label();
            this.tpElzabProductNumber = new System.Windows.Forms.TableLayoutPanel();
            this.tbElzabProductNumber = new System.Windows.Forms.TextBox();
            this.lElzabProductNumber = new System.Windows.Forms.Label();
            this.tPMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.tpPrice = new System.Windows.Forms.TableLayoutPanel();
            this.tpTax = new System.Windows.Forms.TableLayoutPanel();
            this.pHeader.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpBarCode.SuspendLayout();
            this.tpSupplierName.SuspendLayout();
            this.tpElzabProductNumber.SuspendLayout();
            this.tPMarigin.SuspendLayout();
            this.tpPrice.SuspendLayout();
            this.tpTax.SuspendLayout();
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
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(888, 508);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(782, 508);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrice.Location = new System.Drawing.Point(223, 4);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(213, 26);
            this.tbPrice.TabIndex = 9;
            // 
            // lPrice
            // 
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrice.Location = new System.Drawing.Point(4, 4);
            this.lPrice.Margin = new System.Windows.Forms.Padding(3);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(212, 37);
            this.lPrice.TabIndex = 3;
            this.lPrice.Text = "Cena netto";
            this.lPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lQuantity
            // 
            this.lQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lQuantity.Location = new System.Drawing.Point(354, -27);
            this.lQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(244, 24);
            this.lQuantity.TabIndex = 2;
            this.lQuantity.Text = "Ilość";
            this.lQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lManufacturer
            // 
            this.lManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lManufacturer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(2, 2);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(1);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(274, 28);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Producent";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTax
            // 
            this.lTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTax.Location = new System.Drawing.Point(4, 4);
            this.lTax.Margin = new System.Windows.Forms.Padding(3);
            this.lTax.Name = "lTax";
            this.lTax.Size = new System.Drawing.Size(212, 33);
            this.lTax.TabIndex = 4;
            this.lTax.Text = "Stawka VAT";
            this.lTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lMarigin
            // 
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(4, 4);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(3);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(212, 34);
            this.lMarigin.TabIndex = 5;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMarigin
            // 
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(223, 4);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(213, 26);
            this.tbMarigin.TabIndex = 10;
            // 
            // cbTax
            // 
            this.cbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbTax.FormattingEnabled = true;
            this.cbTax.IntegralHeight = false;
            this.cbTax.Items.AddRange(new object[] {
            "0%",
            "23%",
            "5%",
            "8%"});
            this.cbTax.Location = new System.Drawing.Point(223, 4);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(213, 28);
            this.cbTax.TabIndex = 11;
            // 
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pManufacturer.Controls.Add(this.cbManufacturer, 0, 1);
            this.pManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.pManufacturer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pManufacturer.Location = new System.Drawing.Point(9, 33);
            this.pManufacturer.Margin = new System.Windows.Forms.Padding(0);
            this.pManufacturer.Name = "pManufacturer";
            this.pManufacturer.RowCount = 2;
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pManufacturer.Size = new System.Drawing.Size(278, 73);
            this.pManufacturer.TabIndex = 14;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.IntegralHeight = false;
            this.cbManufacturer.Location = new System.Drawing.Point(2, 33);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(1);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(274, 28);
            this.cbManufacturer.TabIndex = 17;
            // 
            // gbProductSelection
            // 
            this.gbProductSelection.Controls.Add(this.pProductName);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 30);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(1000, 122);
            this.gbProductSelection.TabIndex = 16;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // pProductName
            // 
            this.pProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductName.ColumnCount = 1;
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pProductName.Controls.Add(this.cbProductList, 0, 1);
            this.pProductName.Controls.Add(this.lProductName, 0, 0);
            this.pProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pProductName.Location = new System.Drawing.Point(309, 33);
            this.pProductName.Margin = new System.Windows.Forms.Padding(0);
            this.pProductName.Name = "pProductName";
            this.pProductName.RowCount = 2;
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pProductName.Size = new System.Drawing.Size(278, 73);
            this.pProductName.TabIndex = 15;
            // 
            // cbProductList
            // 
            this.cbProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbProductList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbProductList.FormattingEnabled = true;
            this.cbProductList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbProductList.IntegralHeight = false;
            this.cbProductList.Location = new System.Drawing.Point(2, 33);
            this.cbProductList.Margin = new System.Windows.Forms.Padding(1);
            this.cbProductList.Name = "cbProductList";
            this.cbProductList.Size = new System.Drawing.Size(274, 28);
            this.cbProductList.TabIndex = 17;
            // 
            // lProductName
            // 
            this.lProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductName.Location = new System.Drawing.Point(2, 2);
            this.lProductName.Margin = new System.Windows.Forms.Padding(1);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(274, 28);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Controls.Add(this.tableLayoutPanel1);
            this.gbProductInfo.Controls.Add(this.tpBarCode);
            this.gbProductInfo.Controls.Add(this.tpSupplierName);
            this.gbProductInfo.Controls.Add(this.tpElzabProductNumber);
            this.gbProductInfo.Controls.Add(this.tPMarigin);
            this.gbProductInfo.Controls.Add(this.tpPrice);
            this.gbProductInfo.Controls.Add(this.tpTax);
            this.gbProductInfo.Controls.Add(this.lQuantity);
            this.gbProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductInfo.Location = new System.Drawing.Point(0, 152);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(1000, 350);
            this.gbProductInfo.TabIndex = 17;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Informacje o produkcie";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lProductInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbProductInfo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(455, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 179);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // lProductInfo
            // 
            this.lProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductInfo.Location = new System.Drawing.Point(4, 4);
            this.lProductInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lProductInfo.Name = "lProductInfo";
            this.lProductInfo.Size = new System.Drawing.Size(522, 33);
            this.lProductInfo.TabIndex = 7;
            this.lProductInfo.Text = "Informacje o produkcie";
            this.lProductInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbProductInfo
            // 
            this.rtbProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbProductInfo.Location = new System.Drawing.Point(4, 44);
            this.rtbProductInfo.Name = "rtbProductInfo";
            this.rtbProductInfo.Size = new System.Drawing.Size(522, 128);
            this.rtbProductInfo.TabIndex = 8;
            this.rtbProductInfo.Text = "";
            // 
            // tpBarCode
            // 
            this.tpBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tpBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpBarCode.ColumnCount = 2;
            this.tpBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBarCode.Controls.Add(this.tbBarCode, 0, 0);
            this.tpBarCode.Controls.Add(this.lBarCode, 0, 0);
            this.tpBarCode.Location = new System.Drawing.Point(9, 256);
            this.tpBarCode.Name = "tpBarCode";
            this.tpBarCode.RowCount = 2;
            this.tpBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpBarCode.Size = new System.Drawing.Size(440, 40);
            this.tpBarCode.TabIndex = 16;
            // 
            // tbBarCode
            // 
            this.tbBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarCode.Location = new System.Drawing.Point(223, 4);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(213, 26);
            this.tbBarCode.TabIndex = 12;
            // 
            // lBarCode
            // 
            this.lBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarCode.Location = new System.Drawing.Point(4, 4);
            this.lBarCode.Margin = new System.Windows.Forms.Padding(3);
            this.lBarCode.Name = "lBarCode";
            this.lBarCode.Size = new System.Drawing.Size(212, 33);
            this.lBarCode.TabIndex = 7;
            this.lBarCode.Text = "Kod kreskowy";
            this.lBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpSupplierName
            // 
            this.tpSupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tpSupplierName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierName.ColumnCount = 2;
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpSupplierName.Controls.Add(this.tbSuppierName, 0, 0);
            this.tpSupplierName.Controls.Add(this.lSupplierName, 0, 0);
            this.tpSupplierName.Location = new System.Drawing.Point(9, 25);
            this.tpSupplierName.Name = "tpSupplierName";
            this.tpSupplierName.RowCount = 1;
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpSupplierName.Size = new System.Drawing.Size(440, 40);
            this.tpSupplierName.TabIndex = 16;
            // 
            // tbSuppierName
            // 
            this.tbSuppierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSuppierName.Location = new System.Drawing.Point(223, 4);
            this.tbSuppierName.Name = "tbSuppierName";
            this.tbSuppierName.Size = new System.Drawing.Size(213, 26);
            this.tbSuppierName.TabIndex = 11;
            // 
            // lSupplierName
            // 
            this.lSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierName.Location = new System.Drawing.Point(4, 4);
            this.lSupplierName.Margin = new System.Windows.Forms.Padding(3);
            this.lSupplierName.Name = "lSupplierName";
            this.lSupplierName.Size = new System.Drawing.Size(212, 33);
            this.lSupplierName.TabIndex = 6;
            this.lSupplierName.Text = "Nazwa dostawcy";
            this.lSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpElzabProductNumber
            // 
            this.tpElzabProductNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tpElzabProductNumber.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabProductNumber.ColumnCount = 2;
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpElzabProductNumber.Controls.Add(this.tbElzabProductNumber, 0, 0);
            this.tpElzabProductNumber.Controls.Add(this.lElzabProductNumber, 0, 0);
            this.tpElzabProductNumber.Location = new System.Drawing.Point(9, 71);
            this.tpElzabProductNumber.Name = "tpElzabProductNumber";
            this.tpElzabProductNumber.RowCount = 1;
            this.tpElzabProductNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpElzabProductNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpElzabProductNumber.Size = new System.Drawing.Size(440, 40);
            this.tpElzabProductNumber.TabIndex = 16;
            // 
            // tbElzabProductNumber
            // 
            this.tbElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabProductNumber.Location = new System.Drawing.Point(223, 4);
            this.tbElzabProductNumber.Name = "tbElzabProductNumber";
            this.tbElzabProductNumber.Size = new System.Drawing.Size(213, 26);
            this.tbElzabProductNumber.TabIndex = 10;
            // 
            // lElzabProductNumber
            // 
            this.lElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductNumber.Location = new System.Drawing.Point(4, 4);
            this.lElzabProductNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lElzabProductNumber.Name = "lElzabProductNumber";
            this.lElzabProductNumber.Size = new System.Drawing.Size(212, 33);
            this.lElzabProductNumber.TabIndex = 5;
            this.lElzabProductNumber.Text = "Nr produktu w kasie Elzab";
            this.lElzabProductNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPMarigin
            // 
            this.tPMarigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tPMarigin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tPMarigin.ColumnCount = 2;
            this.tPMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPMarigin.Controls.Add(this.lMarigin, 0, 0);
            this.tPMarigin.Controls.Add(this.tbMarigin, 1, 0);
            this.tPMarigin.Location = new System.Drawing.Point(9, 210);
            this.tPMarigin.Name = "tPMarigin";
            this.tPMarigin.RowCount = 1;
            this.tPMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tPMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tPMarigin.Size = new System.Drawing.Size(440, 40);
            this.tPMarigin.TabIndex = 16;
            // 
            // tpPrice
            // 
            this.tpPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tpPrice.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpPrice.ColumnCount = 2;
            this.tpPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpPrice.Controls.Add(this.lPrice, 0, 0);
            this.tpPrice.Controls.Add(this.tbPrice, 1, 0);
            this.tpPrice.Location = new System.Drawing.Point(9, 117);
            this.tpPrice.Name = "tpPrice";
            this.tpPrice.RowCount = 1;
            this.tpPrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tpPrice.Size = new System.Drawing.Size(440, 40);
            this.tpPrice.TabIndex = 15;
            // 
            // tpTax
            // 
            this.tpTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.tpTax.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpTax.ColumnCount = 2;
            this.tpTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpTax.Controls.Add(this.lTax, 0, 0);
            this.tpTax.Controls.Add(this.cbTax, 1, 0);
            this.tpTax.Location = new System.Drawing.Point(9, 164);
            this.tpTax.Name = "tpTax";
            this.tpTax.RowCount = 2;
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpTax.Size = new System.Drawing.Size(440, 40);
            this.tpTax.TabIndex = 14;
            // 
            // ShowProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(170)))), ((int)(((byte)(186)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.gbProductInfo);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowProductInfo";
            this.Text = "Submenu_ElzabInfo";
            this.Load += new System.EventHandler(this.ShowProductInfo_Load);
            this.pHeader.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.gbProductSelection.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.gbProductInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpBarCode.ResumeLayout(false);
            this.tpBarCode.PerformLayout();
            this.tpSupplierName.ResumeLayout(false);
            this.tpSupplierName.PerformLayout();
            this.tpElzabProductNumber.ResumeLayout(false);
            this.tpElzabProductNumber.PerformLayout();
            this.tPMarigin.ResumeLayout(false);
            this.tPMarigin.PerformLayout();
            this.tpPrice.ResumeLayout(false);
            this.tpPrice.PerformLayout();
            this.tpTax.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.Label lQuantity;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lTax;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.ComboBox cbTax;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.TableLayoutPanel pProductName;
        private System.Windows.Forms.ComboBox cbProductList;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.TableLayoutPanel tpBarCode;
        private System.Windows.Forms.TableLayoutPanel tpSupplierName;
        private System.Windows.Forms.TableLayoutPanel tpElzabProductNumber;
        private System.Windows.Forms.TableLayoutPanel tPMarigin;
        private System.Windows.Forms.TableLayoutPanel tpPrice;
        private System.Windows.Forms.TableLayoutPanel tpTax;
        private System.Windows.Forms.Label lBarCode;
        private System.Windows.Forms.TextBox tbSuppierName;
        private System.Windows.Forms.Label lSupplierName;
        private System.Windows.Forms.TextBox tbElzabProductNumber;
        private System.Windows.Forms.Label lElzabProductNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lProductInfo;
        private System.Windows.Forms.RichTextBox rtbProductInfo;
        private System.Windows.Forms.TextBox tbBarCode;
    }
}