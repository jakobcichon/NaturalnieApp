using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddNewProduct
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
            this.components = new System.ComponentModel.Container();
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.cbTax = new System.Windows.Forms.ComboBox();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.tpProductName = new System.Windows.Forms.TableLayoutPanel();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lProductName = new System.Windows.Forms.Label();
            this.tpSupplierName = new System.Windows.Forms.TableLayoutPanel();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.lSupplierName = new System.Windows.Forms.Label();
            this.tpManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.tpSupplierCode = new System.Windows.Forms.TableLayoutPanel();
            this.tbSupplierCode = new System.Windows.Forms.TextBox();
            this.lSupplierCode = new System.Windows.Forms.Label();
            this.tpShortBarcode = new System.Windows.Forms.TableLayoutPanel();
            this.tbShortBarcode = new System.Windows.Forms.TextBox();
            this.lShortBarcode = new System.Windows.Forms.Label();
            this.tpFinalPrice = new System.Windows.Forms.TableLayoutPanel();
            this.tbFinalPrice = new System.Windows.Forms.TextBox();
            this.lFinalPrice = new System.Windows.Forms.Label();
            this.tpElzabProductName = new System.Windows.Forms.TableLayoutPanel();
            this.tbElzabProductName = new System.Windows.Forms.TextBox();
            this.lElzabProductName = new System.Windows.Forms.Label();
            this.pProductInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lProductInfo = new System.Windows.Forms.Label();
            this.rtbProductInfo = new System.Windows.Forms.RichTextBox();
            this.tpBarcode = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.lBarcode = new System.Windows.Forms.Label();
            this.tpElzabProductNumber = new System.Windows.Forms.TableLayoutPanel();
            this.tbElzabProductNumber = new System.Windows.Forms.TextBox();
            this.lElzabProductNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lElzabProductNumberRange = new System.Windows.Forms.Label();
            this.tPMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tpPrice = new System.Windows.Forms.TableLayoutPanel();
            this.lPrice = new System.Windows.Forms.Label();
            this.tpTax = new System.Windows.Forms.TableLayoutPanel();
            this.lTax = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bClose = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.tpProductName.SuspendLayout();
            this.tpSupplierName.SuspendLayout();
            this.tpManufacturer.SuspendLayout();
            this.tpSupplierCode.SuspendLayout();
            this.tpShortBarcode.SuspendLayout();
            this.tpFinalPrice.SuspendLayout();
            this.tpElzabProductName.SuspendLayout();
            this.pProductInfo.SuspendLayout();
            this.tpBarcode.SuspendLayout();
            this.tpElzabProductNumber.SuspendLayout();
            this.tPMarigin.SuspendLayout();
            this.tpPrice.SuspendLayout();
            this.tpTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.panel1.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(782, 508);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(676, 508);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 2;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrice.Location = new System.Drawing.Point(217, 6);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(5);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(213, 26);
            this.tbPrice.TabIndex = 0;
            this.tbPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPrice_KeyDown);
            this.tbPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrice_Validating);
            // 
            // tbMarigin
            // 
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(217, 6);
            this.tbMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(214, 26);
            this.tbMarigin.TabIndex = 0;
            this.tbMarigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMarigin_KeyDown);
            this.tbMarigin.Validating += new System.ComponentModel.CancelEventHandler(this.tbMarigin_Validating);
            // 
            // cbTax
            // 
            this.cbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbTax.FormattingEnabled = true;
            this.cbTax.IntegralHeight = false;
            this.cbTax.Items.AddRange(new object[] {
            "0",
            "5",
            "8",
            "23"});
            this.cbTax.Location = new System.Drawing.Point(217, 6);
            this.cbTax.Margin = new System.Windows.Forms.Padding(5);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(214, 28);
            this.cbTax.TabIndex = 0;
            this.cbTax.SelectionChangeCommitted += new System.EventHandler(this.cbTax_SelectionChangeCommited);
            this.cbTax.Validating += new System.ComponentModel.CancelEventHandler(this.cbTax_Validating);
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Controls.Add(this.tpProductName);
            this.gbProductInfo.Controls.Add(this.tpSupplierName);
            this.gbProductInfo.Controls.Add(this.tpManufacturer);
            this.gbProductInfo.Controls.Add(this.tpSupplierCode);
            this.gbProductInfo.Controls.Add(this.tpShortBarcode);
            this.gbProductInfo.Controls.Add(this.tpFinalPrice);
            this.gbProductInfo.Controls.Add(this.tpElzabProductName);
            this.gbProductInfo.Controls.Add(this.pProductInfo);
            this.gbProductInfo.Controls.Add(this.tpBarcode);
            this.gbProductInfo.Controls.Add(this.tpElzabProductNumber);
            this.gbProductInfo.Controls.Add(this.tPMarigin);
            this.gbProductInfo.Controls.Add(this.tpPrice);
            this.gbProductInfo.Controls.Add(this.tpTax);
            this.gbProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductInfo.Location = new System.Drawing.Point(0, 30);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(1000, 472);
            this.gbProductInfo.TabIndex = 1;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Dane produktu";
            // 
            // tpProductName
            // 
            this.tpProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpProductName.ColumnCount = 2;
            this.tpProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProductName.Controls.Add(this.tbProductName, 0, 0);
            this.tpProductName.Controls.Add(this.lProductName, 0, 0);
            this.tpProductName.Location = new System.Drawing.Point(40, 70);
            this.tpProductName.Name = "tpProductName";
            this.tpProductName.RowCount = 1;
            this.tpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpProductName.Size = new System.Drawing.Size(450, 80);
            this.tpProductName.TabIndex = 12;
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProductName.Location = new System.Drawing.Point(102, 6);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(5);
            this.tbProductName.Multiline = true;
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(329, 70);
            this.tbProductName.TabIndex = 1;
            this.tbProductName.TextChanged += new System.EventHandler(this.tbProductName_TextChanged);
            this.tbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProductName_KeyDown);
            this.tbProductName.MouseHover += new System.EventHandler(this.tbProductName_MouseHover);
            this.tbProductName.Validating += new System.ComponentModel.CancelEventHandler(this.tbProductName_Validating);
            // 
            // lProductName
            // 
            this.lProductName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductName.Location = new System.Drawing.Point(6, 6);
            this.lProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(85, 71);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpSupplierName
            // 
            this.tpSupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierName.ColumnCount = 2;
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierName.Controls.Add(this.cbSupplierName, 0, 0);
            this.tpSupplierName.Controls.Add(this.lSupplierName, 0, 0);
            this.tpSupplierName.Location = new System.Drawing.Point(510, 25);
            this.tpSupplierName.Name = "tpSupplierName";
            this.tpSupplierName.RowCount = 1;
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierName.Size = new System.Drawing.Size(450, 40);
            this.tpSupplierName.TabIndex = 11;
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.IntegralHeight = false;
            this.cbSupplierName.Items.AddRange(new object[] {
            "0",
            "5",
            "8",
            "23"});
            this.cbSupplierName.Location = new System.Drawing.Point(97, 6);
            this.cbSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(350, 28);
            this.cbSupplierName.TabIndex = 1;
            this.cbSupplierName.Validating += new System.ComponentModel.CancelEventHandler(this.cbSupplierName_Validating);
            // 
            // lSupplierName
            // 
            this.lSupplierName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierName.Location = new System.Drawing.Point(6, 6);
            this.lSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.lSupplierName.Name = "lSupplierName";
            this.lSupplierName.Size = new System.Drawing.Size(80, 30);
            this.lSupplierName.TabIndex = 0;
            this.lSupplierName.Text = "Dostawca";
            this.lSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpManufacturer
            // 
            this.tpManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpManufacturer.ColumnCount = 2;
            this.tpManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tpManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpManufacturer.Controls.Add(this.cbManufacturer, 0, 0);
            this.tpManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.tpManufacturer.Location = new System.Drawing.Point(40, 25);
            this.tpManufacturer.Name = "tpManufacturer";
            this.tpManufacturer.RowCount = 1;
            this.tpManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpManufacturer.Size = new System.Drawing.Size(450, 40);
            this.tpManufacturer.TabIndex = 10;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.IntegralHeight = false;
            this.cbManufacturer.Items.AddRange(new object[] {
            "Wszyscy"});
            this.cbManufacturer.Location = new System.Drawing.Point(102, 6);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(345, 28);
            this.cbManufacturer.TabIndex = 2;
            this.cbManufacturer.SelectionChangeCommitted += new System.EventHandler(this.cbManufacturer_SelectionChangeCommitted);
            this.cbManufacturer.Validating += new System.ComponentModel.CancelEventHandler(this.cbManufacturer_Validating);
            // 
            // lManufacturer
            // 
            this.lManufacturer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(6, 6);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(85, 30);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Producent";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpSupplierCode
            // 
            this.tpSupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierCode.ColumnCount = 2;
            this.tpSupplierCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpSupplierCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierCode.Controls.Add(this.tbSupplierCode, 1, 0);
            this.tpSupplierCode.Controls.Add(this.lSupplierCode, 0, 0);
            this.tpSupplierCode.Location = new System.Drawing.Point(510, 115);
            this.tpSupplierCode.Name = "tpSupplierCode";
            this.tpSupplierCode.RowCount = 1;
            this.tpSupplierCode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierCode.Size = new System.Drawing.Size(450, 40);
            this.tpSupplierCode.TabIndex = 8;
            // 
            // tbSupplierCode
            // 
            this.tbSupplierCode.BackColor = System.Drawing.SystemColors.Info;
            this.tbSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSupplierCode.Location = new System.Drawing.Point(217, 6);
            this.tbSupplierCode.Margin = new System.Windows.Forms.Padding(5);
            this.tbSupplierCode.Name = "tbSupplierCode";
            this.tbSupplierCode.Size = new System.Drawing.Size(214, 26);
            this.tbSupplierCode.TabIndex = 0;
            this.tbSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSupplierCode_KeyDown);
            this.tbSupplierCode.Validating += new System.ComponentModel.CancelEventHandler(this.tbSupplierCode_Validating);
            // 
            // lSupplierCode
            // 
            this.lSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierCode.Location = new System.Drawing.Point(6, 6);
            this.lSupplierCode.Margin = new System.Windows.Forms.Padding(5);
            this.lSupplierCode.Name = "lSupplierCode";
            this.lSupplierCode.Size = new System.Drawing.Size(200, 30);
            this.lSupplierCode.TabIndex = 1;
            this.lSupplierCode.Text = "Kod dostawcy";
            this.lSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpShortBarcode
            // 
            this.tpShortBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpShortBarcode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpShortBarcode.ColumnCount = 2;
            this.tpShortBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpShortBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpShortBarcode.Controls.Add(this.tbShortBarcode, 1, 0);
            this.tpShortBarcode.Controls.Add(this.lShortBarcode, 0, 0);
            this.tpShortBarcode.Location = new System.Drawing.Point(510, 70);
            this.tpShortBarcode.Name = "tpShortBarcode";
            this.tpShortBarcode.RowCount = 1;
            this.tpShortBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpShortBarcode.Size = new System.Drawing.Size(450, 40);
            this.tpShortBarcode.TabIndex = 7;
            // 
            // tbShortBarcode
            // 
            this.tbShortBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbShortBarcode.Location = new System.Drawing.Point(217, 6);
            this.tbShortBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.tbShortBarcode.Name = "tbShortBarcode";
            this.tbShortBarcode.ReadOnly = true;
            this.tbShortBarcode.Size = new System.Drawing.Size(214, 26);
            this.tbShortBarcode.TabIndex = 0;
            this.tbShortBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbShortBarcode_KeyDown);
            this.tbShortBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.tbShortBarcode_Validating);
            // 
            // lShortBarcode
            // 
            this.lShortBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lShortBarcode.Location = new System.Drawing.Point(6, 6);
            this.lShortBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.lShortBarcode.Name = "lShortBarcode";
            this.lShortBarcode.Size = new System.Drawing.Size(200, 30);
            this.lShortBarcode.TabIndex = 1;
            this.lShortBarcode.Text = "Kod kreskowy EAN8";
            this.lShortBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpFinalPrice
            // 
            this.tpFinalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpFinalPrice.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpFinalPrice.ColumnCount = 2;
            this.tpFinalPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpFinalPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpFinalPrice.Controls.Add(this.tbFinalPrice, 1, 0);
            this.tpFinalPrice.Controls.Add(this.lFinalPrice, 0, 0);
            this.tpFinalPrice.Location = new System.Drawing.Point(40, 425);
            this.tpFinalPrice.Name = "tpFinalPrice";
            this.tpFinalPrice.RowCount = 1;
            this.tpFinalPrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpFinalPrice.Size = new System.Drawing.Size(450, 40);
            this.tpFinalPrice.TabIndex = 6;
            // 
            // tbFinalPrice
            // 
            this.tbFinalPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbFinalPrice.Location = new System.Drawing.Point(217, 6);
            this.tbFinalPrice.Margin = new System.Windows.Forms.Padding(5);
            this.tbFinalPrice.Name = "tbFinalPrice";
            this.tbFinalPrice.ReadOnly = true;
            this.tbFinalPrice.Size = new System.Drawing.Size(214, 26);
            this.tbFinalPrice.TabIndex = 0;
            // 
            // lFinalPrice
            // 
            this.lFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFinalPrice.Location = new System.Drawing.Point(6, 6);
            this.lFinalPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lFinalPrice.Name = "lFinalPrice";
            this.lFinalPrice.Size = new System.Drawing.Size(200, 30);
            this.lFinalPrice.TabIndex = 0;
            this.lFinalPrice.Text = "Cena klienta";
            this.lFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpElzabProductName
            // 
            this.tpElzabProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpElzabProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabProductName.ColumnCount = 2;
            this.tpElzabProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpElzabProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabProductName.Controls.Add(this.tbElzabProductName, 0, 0);
            this.tpElzabProductName.Controls.Add(this.lElzabProductName, 0, 0);
            this.tpElzabProductName.Location = new System.Drawing.Point(40, 245);
            this.tpElzabProductName.Name = "tpElzabProductName";
            this.tpElzabProductName.RowCount = 1;
            this.tpElzabProductName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpElzabProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpElzabProductName.Size = new System.Drawing.Size(450, 40);
            this.tpElzabProductName.TabIndex = 2;
            // 
            // tbElzabProductName
            // 
            this.tbElzabProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabProductName.Location = new System.Drawing.Point(217, 6);
            this.tbElzabProductName.Margin = new System.Windows.Forms.Padding(5);
            this.tbElzabProductName.Name = "tbElzabProductName";
            this.tbElzabProductName.Size = new System.Drawing.Size(213, 26);
            this.tbElzabProductName.TabIndex = 0;
            this.tbElzabProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbElzabProductName_KeyDown);
            this.tbElzabProductName.MouseHover += new System.EventHandler(this.tbElzabProductName_MouseHover);
            this.tbElzabProductName.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabProductName_Validating);
            // 
            // lElzabProductName
            // 
            this.lElzabProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lElzabProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductName.Location = new System.Drawing.Point(6, 6);
            this.lElzabProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lElzabProductName.Name = "lElzabProductName";
            this.lElzabProductName.Size = new System.Drawing.Size(200, 30);
            this.lElzabProductName.TabIndex = 0;
            this.lElzabProductName.Text = "Nazwa w kasie Elzab";
            this.lElzabProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pProductInfo
            // 
            this.pProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.pProductInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductInfo.ColumnCount = 1;
            this.pProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pProductInfo.Controls.Add(this.lProductInfo, 0, 0);
            this.pProductInfo.Controls.Add(this.rtbProductInfo, 0, 1);
            this.pProductInfo.Location = new System.Drawing.Point(510, 160);
            this.pProductInfo.Name = "pProductInfo";
            this.pProductInfo.RowCount = 3;
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pProductInfo.Size = new System.Drawing.Size(450, 220);
            this.pProductInfo.TabIndex = 9;
            // 
            // lProductInfo
            // 
            this.lProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductInfo.Location = new System.Drawing.Point(4, 4);
            this.lProductInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lProductInfo.Name = "lProductInfo";
            this.lProductInfo.Size = new System.Drawing.Size(442, 34);
            this.lProductInfo.TabIndex = 0;
            this.lProductInfo.Text = "Informacje o produkcie";
            this.lProductInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbProductInfo
            // 
            this.rtbProductInfo.BackColor = System.Drawing.SystemColors.Info;
            this.rtbProductInfo.Location = new System.Drawing.Point(6, 47);
            this.rtbProductInfo.Margin = new System.Windows.Forms.Padding(5);
            this.rtbProductInfo.MaxLength = 1024;
            this.rtbProductInfo.Name = "rtbProductInfo";
            this.rtbProductInfo.Size = new System.Drawing.Size(425, 144);
            this.rtbProductInfo.TabIndex = 0;
            this.rtbProductInfo.Text = "";
            this.rtbProductInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbProductInfo_KeyDown);
            this.rtbProductInfo.Validating += new System.ComponentModel.CancelEventHandler(this.rtbProductInfo_Validating);
            // 
            // tpBarcode
            // 
            this.tpBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpBarcode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpBarcode.ColumnCount = 2;
            this.tpBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpBarcode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpBarcode.Controls.Add(this.tbBarcode, 0, 0);
            this.tpBarcode.Controls.Add(this.lBarcode, 0, 0);
            this.tpBarcode.Location = new System.Drawing.Point(40, 155);
            this.tpBarcode.Name = "tpBarcode";
            this.tpBarcode.RowCount = 1;
            this.tpBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpBarcode.Size = new System.Drawing.Size(450, 40);
            this.tpBarcode.TabIndex = 0;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarcode.Location = new System.Drawing.Point(217, 6);
            this.tbBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(214, 26);
            this.tbBarcode.TabIndex = 1;
            this.tbBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyDown);
            this.tbBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.tbBarcode_Validating);
            // 
            // lBarcode
            // 
            this.lBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarcode.Location = new System.Drawing.Point(6, 6);
            this.lBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.lBarcode.Name = "lBarcode";
            this.lBarcode.Size = new System.Drawing.Size(200, 30);
            this.lBarcode.TabIndex = 0;
            this.lBarcode.Text = "Kod kreskowy";
            this.lBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpElzabProductNumber
            // 
            this.tpElzabProductNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpElzabProductNumber.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabProductNumber.ColumnCount = 3;
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabProductNumber.Controls.Add(this.tbElzabProductNumber, 0, 0);
            this.tpElzabProductNumber.Controls.Add(this.lElzabProductNumber, 0, 0);
            this.tpElzabProductNumber.Controls.Add(this.label1, 0, 1);
            this.tpElzabProductNumber.Controls.Add(this.lElzabProductNumberRange, 2, 0);
            this.tpElzabProductNumber.Location = new System.Drawing.Point(40, 200);
            this.tpElzabProductNumber.Name = "tpElzabProductNumber";
            this.tpElzabProductNumber.RowCount = 2;
            this.tpElzabProductNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpElzabProductNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpElzabProductNumber.Size = new System.Drawing.Size(450, 40);
            this.tpElzabProductNumber.TabIndex = 1;
            // 
            // tbElzabProductNumber
            // 
            this.tbElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabProductNumber.Location = new System.Drawing.Point(217, 6);
            this.tbElzabProductNumber.Margin = new System.Windows.Forms.Padding(5);
            this.tbElzabProductNumber.Name = "tbElzabProductNumber";
            this.tbElzabProductNumber.Size = new System.Drawing.Size(100, 26);
            this.tbElzabProductNumber.TabIndex = 0;
            this.tbElzabProductNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbElzabProductNumber_KeyDown);
            this.tbElzabProductNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabProductNumber_Validating);
            // 
            // lElzabProductNumber
            // 
            this.lElzabProductNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductNumber.Location = new System.Drawing.Point(6, 6);
            this.lElzabProductNumber.Margin = new System.Windows.Forms.Padding(5);
            this.lElzabProductNumber.Name = "lElzabProductNumber";
            this.lElzabProductNumber.Size = new System.Drawing.Size(200, 30);
            this.lElzabProductNumber.TabIndex = 0;
            this.lElzabProductNumber.Text = "Nr produktu w kasie Elzab";
            this.lElzabProductNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // lElzabProductNumberRange
            // 
            this.lElzabProductNumberRange.Dock = System.Windows.Forms.DockStyle.Left;
            this.lElzabProductNumberRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductNumberRange.Location = new System.Drawing.Point(346, 1);
            this.lElzabProductNumberRange.Name = "lElzabProductNumberRange";
            this.lElzabProductNumberRange.Size = new System.Drawing.Size(101, 40);
            this.lElzabProductNumberRange.TabIndex = 2;
            this.lElzabProductNumberRange.Text = "0-0";
            this.lElzabProductNumberRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPMarigin
            // 
            this.tPMarigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tPMarigin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tPMarigin.ColumnCount = 2;
            this.tPMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tPMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tPMarigin.Controls.Add(this.tbMarigin, 1, 0);
            this.tPMarigin.Controls.Add(this.lMarigin, 0, 0);
            this.tPMarigin.Location = new System.Drawing.Point(40, 380);
            this.tPMarigin.Name = "tPMarigin";
            this.tPMarigin.RowCount = 1;
            this.tPMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tPMarigin.Size = new System.Drawing.Size(450, 40);
            this.tPMarigin.TabIndex = 5;
            // 
            // lMarigin
            // 
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(6, 6);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(200, 30);
            this.lMarigin.TabIndex = 0;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpPrice
            // 
            this.tpPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpPrice.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpPrice.ColumnCount = 2;
            this.tpPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpPrice.Controls.Add(this.lPrice, 0, 0);
            this.tpPrice.Controls.Add(this.tbPrice, 1, 0);
            this.tpPrice.Location = new System.Drawing.Point(40, 290);
            this.tpPrice.Name = "tpPrice";
            this.tpPrice.RowCount = 1;
            this.tpPrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpPrice.Size = new System.Drawing.Size(450, 40);
            this.tpPrice.TabIndex = 3;
            // 
            // lPrice
            // 
            this.lPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrice.Location = new System.Drawing.Point(6, 6);
            this.lPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(200, 30);
            this.lPrice.TabIndex = 0;
            this.lPrice.Text = "Cena netto";
            this.lPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpTax
            // 
            this.tpTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpTax.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpTax.ColumnCount = 2;
            this.tpTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpTax.Controls.Add(this.lTax, 0, 0);
            this.tpTax.Controls.Add(this.cbTax, 1, 0);
            this.tpTax.Location = new System.Drawing.Point(40, 335);
            this.tpTax.Name = "tpTax";
            this.tpTax.RowCount = 2;
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpTax.Size = new System.Drawing.Size(450, 40);
            this.tpTax.TabIndex = 4;
            // 
            // lTax
            // 
            this.lTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTax.Location = new System.Drawing.Point(6, 6);
            this.lTax.Margin = new System.Windows.Forms.Padding(5);
            this.lTax.Name = "lTax";
            this.lTax.Size = new System.Drawing.Size(200, 30);
            this.lTax.TabIndex = 0;
            this.lTax.Text = "Podatek";
            this.lTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(888, 508);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 4;
            this.bClose.Text = "Zamknij";
            this.bClose.UseMnemonic = false;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 500);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(1000, 70);
            this.pButtonsPanel.TabIndex = 5;
            // 
            // AddNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.gbProductInfo);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddNewProduct";
            this.Text = "Submenu_ElzabInfo";
            this.Load += new System.EventHandler(this.AddNewProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddNewProduct_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.gbProductInfo.ResumeLayout(false);
            this.tpProductName.ResumeLayout(false);
            this.tpProductName.PerformLayout();
            this.tpSupplierName.ResumeLayout(false);
            this.tpManufacturer.ResumeLayout(false);
            this.tpSupplierCode.ResumeLayout(false);
            this.tpSupplierCode.PerformLayout();
            this.tpShortBarcode.ResumeLayout(false);
            this.tpShortBarcode.PerformLayout();
            this.tpFinalPrice.ResumeLayout(false);
            this.tpFinalPrice.PerformLayout();
            this.tpElzabProductName.ResumeLayout(false);
            this.tpElzabProductName.PerformLayout();
            this.pProductInfo.ResumeLayout(false);
            this.tpBarcode.ResumeLayout(false);
            this.tpBarcode.PerformLayout();
            this.tpElzabProductNumber.ResumeLayout(false);
            this.tpElzabProductNumber.PerformLayout();
            this.tPMarigin.ResumeLayout(false);
            this.tPMarigin.PerformLayout();
            this.tpPrice.ResumeLayout(false);
            this.tpPrice.PerformLayout();
            this.tpTax.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.ComboBox cbTax;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.TableLayoutPanel tpBarcode;
        private System.Windows.Forms.TableLayoutPanel tPMarigin;
        private System.Windows.Forms.TableLayoutPanel tpPrice;
        private System.Windows.Forms.TableLayoutPanel tpTax;
        private System.Windows.Forms.Label lBarcode;
        private System.Windows.Forms.TableLayoutPanel pProductInfo;
        private System.Windows.Forms.Label lProductInfo;
        private System.Windows.Forms.RichTextBox rtbProductInfo;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.Label lTax;
        private System.Windows.Forms.TableLayoutPanel tpElzabProductName;
        private System.Windows.Forms.TextBox tbElzabProductName;
        private System.Windows.Forms.Label lElzabProductName;
        private System.Windows.Forms.TableLayoutPanel tpElzabProductNumber;
        private System.Windows.Forms.TextBox tbElzabProductNumber;
        private System.Windows.Forms.Label lElzabProductNumber;
        private System.Windows.Forms.TableLayoutPanel tpFinalPrice;
        private System.Windows.Forms.TextBox tbFinalPrice;
        private System.Windows.Forms.Label lFinalPrice;
        private System.Windows.Forms.TableLayoutPanel tpSupplierCode;
        private System.Windows.Forms.TextBox tbSupplierCode;
        private System.Windows.Forms.Label lSupplierCode;
        private System.Windows.Forms.TableLayoutPanel tpShortBarcode;
        private System.Windows.Forms.TextBox tbShortBarcode;
        private System.Windows.Forms.Label lShortBarcode;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.TableLayoutPanel tpSupplierName;
        private System.Windows.Forms.Label lSupplierName;
        private System.Windows.Forms.TableLayoutPanel tpManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.TableLayoutPanel tpProductName;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lElzabProductNumberRange;
    }
}