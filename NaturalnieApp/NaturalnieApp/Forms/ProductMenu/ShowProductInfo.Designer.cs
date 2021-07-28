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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tpShortBarcode = new System.Windows.Forms.TableLayoutPanel();
            this.tbShortBarcode = new System.Windows.Forms.TextBox();
            this.lShortBarcode = new System.Windows.Forms.Label();
            this.tpFinalPrice = new System.Windows.Forms.TableLayoutPanel();
            this.tbFinalPrice = new System.Windows.Forms.TextBox();
            this.lFinalPrice = new System.Windows.Forms.Label();
            this.tpSupplierCode = new System.Windows.Forms.TableLayoutPanel();
            this.tbSupplierCode = new System.Windows.Forms.TextBox();
            this.lSupplierCode = new System.Windows.Forms.Label();
            this.pProductInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lProductInfo = new System.Windows.Forms.Label();
            this.rtbProductInfo = new System.Windows.Forms.RichTextBox();
            this.tpDiscount = new System.Windows.Forms.TableLayoutPanel();
            this.lDiscount = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tpSupplierName = new System.Windows.Forms.TableLayoutPanel();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.lSupplierName = new System.Windows.Forms.Label();
            this.tpNetPriceWithDiscount = new System.Windows.Forms.TableLayoutPanel();
            this.tbPriceNetWithDiscount = new System.Windows.Forms.TextBox();
            this.lNetPRiceWithDiscount = new System.Windows.Forms.Label();
            this.tPMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tpManufacturerToEdit = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.lManufacturerToEdit = new System.Windows.Forms.Label();
            this.tpPrice = new System.Windows.Forms.TableLayoutPanel();
            this.lPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tpBarcodeToEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.lBarcodeToEdit = new System.Windows.Forms.Label();
            this.tpTax = new System.Windows.Forms.TableLayoutPanel();
            this.lTax = new System.Windows.Forms.Label();
            this.cbTax = new System.Windows.Forms.ComboBox();
            this.tpProductNameToEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lProductNameToEdit = new System.Windows.Forms.Label();
            this.tpElzabProductNumber = new System.Windows.Forms.TableLayoutPanel();
            this.lElzabProductNumber = new System.Windows.Forms.Label();
            this.lElzabProductNumberRange = new System.Windows.Forms.Label();
            this.tbElzabProductNumber = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bDelete = new System.Windows.Forms.Button();
            this.lPriceWithTax = new System.Windows.Forms.Label();
            this.tbPriceWithTax = new System.Windows.Forms.TextBox();
            this.tpPriceWithTax = new System.Windows.Forms.TableLayoutPanel();
            this.lElzabNameLength = new System.Windows.Forms.Label();
            this.tbElzabProductName = new System.Windows.Forms.TextBox();
            this.lElzabProductName = new System.Windows.Forms.Label();
            this.tpElzabProductName = new System.Windows.Forms.TableLayoutPanel();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lName = new System.Windows.Forms.Label();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucSearchBar = new NaturalnieApp.Forms.Common.SearchBarTemplate();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tpShortBarcode.SuspendLayout();
            this.tpFinalPrice.SuspendLayout();
            this.tpSupplierCode.SuspendLayout();
            this.pProductInfo.SuspendLayout();
            this.tpDiscount.SuspendLayout();
            this.tpSupplierName.SuspendLayout();
            this.tpNetPriceWithDiscount.SuspendLayout();
            this.tPMarigin.SuspendLayout();
            this.tpManufacturerToEdit.SuspendLayout();
            this.tpPrice.SuspendLayout();
            this.tpBarcodeToEdit.SuspendLayout();
            this.tpTax.SuspendLayout();
            this.tpProductNameToEdit.SuspendLayout();
            this.tpElzabProductNumber.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            this.tpPriceWithTax.SuspendLayout();
            this.tpElzabProductName.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.tpShortBarcode.Location = new System.Drawing.Point(464, 205);
            this.tpShortBarcode.Name = "tpShortBarcode";
            this.tpShortBarcode.RowCount = 1;
            this.tpShortBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpShortBarcode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpShortBarcode.Size = new System.Drawing.Size(450, 40);
            this.tpShortBarcode.TabIndex = 13;
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
            this.lShortBarcode.Text = "Kod kreskowy dodatkowy";
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
            this.tpFinalPrice.Location = new System.Drawing.Point(10, 425);
            this.tpFinalPrice.Name = "tpFinalPrice";
            this.tpFinalPrice.RowCount = 1;
            this.tpFinalPrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpFinalPrice.Size = new System.Drawing.Size(450, 40);
            this.tpFinalPrice.TabIndex = 9;
            // 
            // tbFinalPrice
            // 
            this.tbFinalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
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
            // tpSupplierCode
            // 
            this.tpSupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierCode.ColumnCount = 2;
            this.tpSupplierCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpSupplierCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierCode.Controls.Add(this.tbSupplierCode, 1, 0);
            this.tpSupplierCode.Controls.Add(this.lSupplierCode, 0, 0);
            this.tpSupplierCode.Location = new System.Drawing.Point(464, 249);
            this.tpSupplierCode.Name = "tpSupplierCode";
            this.tpSupplierCode.RowCount = 1;
            this.tpSupplierCode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierCode.Size = new System.Drawing.Size(450, 40);
            this.tpSupplierCode.TabIndex = 14;
            // 
            // tbSupplierCode
            // 
            this.tbSupplierCode.BackColor = System.Drawing.Color.Goldenrod;
            this.tbSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSupplierCode.Location = new System.Drawing.Point(217, 6);
            this.tbSupplierCode.Margin = new System.Windows.Forms.Padding(5);
            this.tbSupplierCode.Name = "tbSupplierCode";
            this.tbSupplierCode.Size = new System.Drawing.Size(214, 26);
            this.tbSupplierCode.TabIndex = 0;
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
            // pProductInfo
            // 
            this.pProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.pProductInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductInfo.ColumnCount = 1;
            this.pProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pProductInfo.Controls.Add(this.lProductInfo, 0, 0);
            this.pProductInfo.Controls.Add(this.rtbProductInfo, 0, 1);
            this.pProductInfo.Location = new System.Drawing.Point(464, 293);
            this.pProductInfo.Name = "pProductInfo";
            this.pProductInfo.RowCount = 3;
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pProductInfo.Size = new System.Drawing.Size(450, 172);
            this.pProductInfo.TabIndex = 15;
            // 
            // lProductInfo
            // 
            this.lProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.rtbProductInfo.BackColor = System.Drawing.Color.Goldenrod;
            this.rtbProductInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbProductInfo.Location = new System.Drawing.Point(6, 47);
            this.rtbProductInfo.Margin = new System.Windows.Forms.Padding(5);
            this.rtbProductInfo.MaxLength = 1024;
            this.rtbProductInfo.Name = "rtbProductInfo";
            this.rtbProductInfo.Size = new System.Drawing.Size(424, 90);
            this.rtbProductInfo.TabIndex = 0;
            this.rtbProductInfo.Text = "";
            this.rtbProductInfo.Validating += new System.ComponentModel.CancelEventHandler(this.rtbProductInfo_Validating);
            // 
            // tpDiscount
            // 
            this.tpDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpDiscount.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpDiscount.ColumnCount = 2;
            this.tpDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpDiscount.Controls.Add(this.lDiscount, 0, 0);
            this.tpDiscount.Controls.Add(this.tbDiscount, 1, 0);
            this.tpDiscount.Location = new System.Drawing.Point(10, 205);
            this.tpDiscount.Name = "tpDiscount";
            this.tpDiscount.RowCount = 1;
            this.tpDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpDiscount.Size = new System.Drawing.Size(450, 40);
            this.tpDiscount.TabIndex = 4;
            // 
            // lDiscount
            // 
            this.lDiscount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDiscount.Location = new System.Drawing.Point(6, 6);
            this.lDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.lDiscount.Name = "lDiscount";
            this.lDiscount.Size = new System.Drawing.Size(200, 30);
            this.lDiscount.TabIndex = 0;
            this.lDiscount.Text = "Rabat dostawcy";
            this.lDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDiscount
            // 
            this.tbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbDiscount.Location = new System.Drawing.Point(217, 6);
            this.tbDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(213, 26);
            this.tbDiscount.TabIndex = 0;
            this.tbDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.tbDiscount_Validating);
            // 
            // tpSupplierName
            // 
            this.tpSupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierName.ColumnCount = 2;
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierName.Controls.Add(this.cbSupplierName, 0, 0);
            this.tpSupplierName.Controls.Add(this.lSupplierName, 0, 0);
            this.tpSupplierName.Location = new System.Drawing.Point(10, 73);
            this.tpSupplierName.Name = "tpSupplierName";
            this.tpSupplierName.RowCount = 1;
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpSupplierName.Size = new System.Drawing.Size(450, 40);
            this.tpSupplierName.TabIndex = 1;
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.IntegralHeight = false;
            this.cbSupplierName.Location = new System.Drawing.Point(217, 6);
            this.cbSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(214, 28);
            this.cbSupplierName.TabIndex = 0;
            this.cbSupplierName.MouseHover += new System.EventHandler(this.cbSupplierName_MouseHover);
            // 
            // lSupplierName
            // 
            this.lSupplierName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierName.Location = new System.Drawing.Point(6, 6);
            this.lSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.lSupplierName.Name = "lSupplierName";
            this.lSupplierName.Size = new System.Drawing.Size(200, 30);
            this.lSupplierName.TabIndex = 0;
            this.lSupplierName.Text = "Nazwa dostawcy";
            this.lSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpNetPriceWithDiscount
            // 
            this.tpNetPriceWithDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpNetPriceWithDiscount.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpNetPriceWithDiscount.ColumnCount = 2;
            this.tpNetPriceWithDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpNetPriceWithDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpNetPriceWithDiscount.Controls.Add(this.tbPriceNetWithDiscount, 1, 0);
            this.tpNetPriceWithDiscount.Controls.Add(this.lNetPRiceWithDiscount, 0, 0);
            this.tpNetPriceWithDiscount.Location = new System.Drawing.Point(10, 249);
            this.tpNetPriceWithDiscount.Name = "tpNetPriceWithDiscount";
            this.tpNetPriceWithDiscount.RowCount = 1;
            this.tpNetPriceWithDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpNetPriceWithDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpNetPriceWithDiscount.Size = new System.Drawing.Size(450, 40);
            this.tpNetPriceWithDiscount.TabIndex = 5;
            // 
            // tbPriceNetWithDiscount
            // 
            this.tbPriceNetWithDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPriceNetWithDiscount.Location = new System.Drawing.Point(217, 6);
            this.tbPriceNetWithDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.tbPriceNetWithDiscount.Name = "tbPriceNetWithDiscount";
            this.tbPriceNetWithDiscount.ReadOnly = true;
            this.tbPriceNetWithDiscount.Size = new System.Drawing.Size(214, 26);
            this.tbPriceNetWithDiscount.TabIndex = 0;
            // 
            // lNetPRiceWithDiscount
            // 
            this.lNetPRiceWithDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNetPRiceWithDiscount.Location = new System.Drawing.Point(6, 6);
            this.lNetPRiceWithDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.lNetPRiceWithDiscount.Name = "lNetPRiceWithDiscount";
            this.lNetPRiceWithDiscount.Size = new System.Drawing.Size(200, 30);
            this.lNetPRiceWithDiscount.TabIndex = 0;
            this.lNetPRiceWithDiscount.Text = "Cena netto z rabatem";
            this.lNetPRiceWithDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tPMarigin.Location = new System.Drawing.Point(10, 381);
            this.tPMarigin.Name = "tPMarigin";
            this.tPMarigin.RowCount = 1;
            this.tPMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tPMarigin.Size = new System.Drawing.Size(450, 40);
            this.tPMarigin.TabIndex = 8;
            // 
            // tbMarigin
            // 
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(217, 6);
            this.tbMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(214, 26);
            this.tbMarigin.TabIndex = 0;
            this.tbMarigin.Validating += new System.ComponentModel.CancelEventHandler(this.tbMarigin_Validating);
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
            // tpManufacturerToEdit
            // 
            this.tpManufacturerToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpManufacturerToEdit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpManufacturerToEdit.ColumnCount = 2;
            this.tpManufacturerToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpManufacturerToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpManufacturerToEdit.Controls.Add(this.cbManufacturer, 0, 0);
            this.tpManufacturerToEdit.Controls.Add(this.lManufacturerToEdit, 0, 0);
            this.tpManufacturerToEdit.Location = new System.Drawing.Point(10, 29);
            this.tpManufacturerToEdit.Name = "tpManufacturerToEdit";
            this.tpManufacturerToEdit.RowCount = 1;
            this.tpManufacturerToEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpManufacturerToEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpManufacturerToEdit.Size = new System.Drawing.Size(450, 40);
            this.tpManufacturerToEdit.TabIndex = 0;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.IntegralHeight = false;
            this.cbManufacturer.Location = new System.Drawing.Point(217, 6);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(214, 28);
            this.cbManufacturer.TabIndex = 0;
            this.cbManufacturer.SelectionChangeCommitted += new System.EventHandler(this.cbManufacturerToEdit_SelectionChangeCommitted);
            this.cbManufacturer.MouseHover += new System.EventHandler(this.cbManufacturerToEdit_MouseHover);
            this.cbManufacturer.Validating += new System.ComponentModel.CancelEventHandler(this.cbManufacturerToEdit_Validating);
            // 
            // lManufacturerToEdit
            // 
            this.lManufacturerToEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lManufacturerToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturerToEdit.Location = new System.Drawing.Point(6, 6);
            this.lManufacturerToEdit.Margin = new System.Windows.Forms.Padding(5);
            this.lManufacturerToEdit.Name = "lManufacturerToEdit";
            this.lManufacturerToEdit.Size = new System.Drawing.Size(200, 30);
            this.lManufacturerToEdit.TabIndex = 0;
            this.lManufacturerToEdit.Text = "Nazwa producenta";
            this.lManufacturerToEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tpPrice.Location = new System.Drawing.Point(10, 161);
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
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrice.Location = new System.Drawing.Point(217, 6);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(5);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(213, 26);
            this.tbPrice.TabIndex = 0;
            this.tbPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrice_Validating);
            // 
            // tpBarcodeToEdit
            // 
            this.tpBarcodeToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpBarcodeToEdit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpBarcodeToEdit.ColumnCount = 2;
            this.tpBarcodeToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpBarcodeToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpBarcodeToEdit.Controls.Add(this.tbBarcode, 1, 0);
            this.tpBarcodeToEdit.Controls.Add(this.lBarcodeToEdit, 0, 0);
            this.tpBarcodeToEdit.Location = new System.Drawing.Point(10, 117);
            this.tpBarcodeToEdit.Name = "tpBarcodeToEdit";
            this.tpBarcodeToEdit.RowCount = 1;
            this.tpBarcodeToEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpBarcodeToEdit.Size = new System.Drawing.Size(450, 40);
            this.tpBarcodeToEdit.TabIndex = 2;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarcode.Location = new System.Drawing.Point(217, 6);
            this.tbBarcode.Margin = new System.Windows.Forms.Padding(5);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(214, 26);
            this.tbBarcode.TabIndex = 0;
            this.tbBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.tbBarcodeToEdit_Validating);
            // 
            // lBarcodeToEdit
            // 
            this.lBarcodeToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarcodeToEdit.Location = new System.Drawing.Point(6, 6);
            this.lBarcodeToEdit.Margin = new System.Windows.Forms.Padding(5);
            this.lBarcodeToEdit.Name = "lBarcodeToEdit";
            this.lBarcodeToEdit.Size = new System.Drawing.Size(200, 30);
            this.lBarcodeToEdit.TabIndex = 0;
            this.lBarcodeToEdit.Text = "Kod kreskowy główny";
            this.lBarcodeToEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tpTax.Location = new System.Drawing.Point(10, 293);
            this.tpTax.Name = "tpTax";
            this.tpTax.RowCount = 2;
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpTax.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpTax.Size = new System.Drawing.Size(450, 40);
            this.tpTax.TabIndex = 6;
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
            // cbTax
            // 
            this.cbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbTax.FormattingEnabled = true;
            this.cbTax.IntegralHeight = false;
            this.cbTax.Location = new System.Drawing.Point(217, 6);
            this.cbTax.Margin = new System.Windows.Forms.Padding(5);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(214, 28);
            this.cbTax.TabIndex = 0;
            this.cbTax.SelectionChangeCommitted += new System.EventHandler(this.cbTax_SelectionChangeCommitted);
            this.cbTax.Validating += new System.ComponentModel.CancelEventHandler(this.cbTax_Validating);
            // 
            // tpProductNameToEdit
            // 
            this.tpProductNameToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpProductNameToEdit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpProductNameToEdit.ColumnCount = 2;
            this.tpProductNameToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProductNameToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProductNameToEdit.Controls.Add(this.tbProductName, 0, 0);
            this.tpProductNameToEdit.Controls.Add(this.lProductNameToEdit, 0, 0);
            this.tpProductNameToEdit.Location = new System.Drawing.Point(464, 29);
            this.tpProductNameToEdit.Name = "tpProductNameToEdit";
            this.tpProductNameToEdit.RowCount = 1;
            this.tpProductNameToEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpProductNameToEdit.Size = new System.Drawing.Size(450, 84);
            this.tpProductNameToEdit.TabIndex = 10;
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProductName.Location = new System.Drawing.Point(102, 6);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(5);
            this.tbProductName.Multiline = true;
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(329, 70);
            this.tbProductName.TabIndex = 0;
            this.tbProductName.TextChanged += new System.EventHandler(this.tbProductNameToEdit_TextChanged);
            this.tbProductName.Validating += new System.ComponentModel.CancelEventHandler(this.tbProductNameToEdit_Validating);
            // 
            // lProductNameToEdit
            // 
            this.lProductNameToEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lProductNameToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductNameToEdit.Location = new System.Drawing.Point(6, 6);
            this.lProductNameToEdit.Margin = new System.Windows.Forms.Padding(5);
            this.lProductNameToEdit.Name = "lProductNameToEdit";
            this.lProductNameToEdit.Size = new System.Drawing.Size(85, 72);
            this.lProductNameToEdit.TabIndex = 0;
            this.lProductNameToEdit.Text = "Nazwa produktu";
            this.lProductNameToEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpElzabProductNumber
            // 
            this.tpElzabProductNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpElzabProductNumber.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabProductNumber.ColumnCount = 3;
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tpElzabProductNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabProductNumber.Controls.Add(this.lElzabProductNumber, 0, 0);
            this.tpElzabProductNumber.Controls.Add(this.lElzabProductNumberRange, 2, 0);
            this.tpElzabProductNumber.Controls.Add(this.tbElzabProductNumber, 1, 0);
            this.tpElzabProductNumber.Location = new System.Drawing.Point(464, 117);
            this.tpElzabProductNumber.Name = "tpElzabProductNumber";
            this.tpElzabProductNumber.RowCount = 1;
            this.tpElzabProductNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpElzabProductNumber.Size = new System.Drawing.Size(450, 40);
            this.tpElzabProductNumber.TabIndex = 11;
            // 
            // lElzabProductNumber
            // 
            this.lElzabProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductNumber.Location = new System.Drawing.Point(6, 6);
            this.lElzabProductNumber.Margin = new System.Windows.Forms.Padding(5);
            this.lElzabProductNumber.Name = "lElzabProductNumber";
            this.lElzabProductNumber.Size = new System.Drawing.Size(200, 30);
            this.lElzabProductNumber.TabIndex = 0;
            this.lElzabProductNumber.Text = "Nr produktu w kasie Elzab";
            this.lElzabProductNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lElzabProductNumberRange
            // 
            this.lElzabProductNumberRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lElzabProductNumberRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductNumberRange.Location = new System.Drawing.Point(346, 4);
            this.lElzabProductNumberRange.Margin = new System.Windows.Forms.Padding(3);
            this.lElzabProductNumberRange.Name = "lElzabProductNumberRange";
            this.lElzabProductNumberRange.Size = new System.Drawing.Size(100, 34);
            this.lElzabProductNumberRange.TabIndex = 2;
            this.lElzabProductNumberRange.Text = "Wolne: ??";
            this.lElzabProductNumberRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbElzabProductNumber
            // 
            this.tbElzabProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElzabProductNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabProductNumber.Location = new System.Drawing.Point(217, 6);
            this.tbElzabProductNumber.Margin = new System.Windows.Forms.Padding(5);
            this.tbElzabProductNumber.Name = "tbElzabProductNumber";
            this.tbElzabProductNumber.Size = new System.Drawing.Size(120, 26);
            this.tbElzabProductNumber.TabIndex = 0;
            this.tbElzabProductNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabProductNumber_Validating);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(813, 7);
            this.bSave.Margin = new System.Windows.Forms.Padding(5);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(703, 7);
            this.bUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 0;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bDelete);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(926, 70);
            this.pButtonsPanel.TabIndex = 5;
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bDelete.Location = new System.Drawing.Point(593, 7);
            this.bDelete.Margin = new System.Windows.Forms.Padding(5);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(100, 50);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "Usuń";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // lPriceWithTax
            // 
            this.lPriceWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPriceWithTax.Location = new System.Drawing.Point(6, 6);
            this.lPriceWithTax.Margin = new System.Windows.Forms.Padding(5);
            this.lPriceWithTax.Name = "lPriceWithTax";
            this.lPriceWithTax.Size = new System.Drawing.Size(200, 30);
            this.lPriceWithTax.TabIndex = 0;
            this.lPriceWithTax.Text = "Cena brutto";
            this.lPriceWithTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPriceWithTax
            // 
            this.tbPriceWithTax.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbPriceWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPriceWithTax.Location = new System.Drawing.Point(217, 6);
            this.tbPriceWithTax.Margin = new System.Windows.Forms.Padding(5);
            this.tbPriceWithTax.Name = "tbPriceWithTax";
            this.tbPriceWithTax.Size = new System.Drawing.Size(214, 26);
            this.tbPriceWithTax.TabIndex = 0;
            this.tbPriceWithTax.Validating += new System.ComponentModel.CancelEventHandler(this.tbPriceWithTax_Validating);
            // 
            // tpPriceWithTax
            // 
            this.tpPriceWithTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpPriceWithTax.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpPriceWithTax.ColumnCount = 2;
            this.tpPriceWithTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpPriceWithTax.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpPriceWithTax.Controls.Add(this.tbPriceWithTax, 1, 0);
            this.tpPriceWithTax.Controls.Add(this.lPriceWithTax, 0, 0);
            this.tpPriceWithTax.Location = new System.Drawing.Point(10, 337);
            this.tpPriceWithTax.Name = "tpPriceWithTax";
            this.tpPriceWithTax.RowCount = 1;
            this.tpPriceWithTax.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpPriceWithTax.Size = new System.Drawing.Size(450, 40);
            this.tpPriceWithTax.TabIndex = 7;
            // 
            // lElzabNameLength
            // 
            this.lElzabNameLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabNameLength.Location = new System.Drawing.Point(407, 1);
            this.lElzabNameLength.Name = "lElzabNameLength";
            this.lElzabNameLength.Size = new System.Drawing.Size(39, 35);
            this.lElzabNameLength.TabIndex = 3;
            this.lElzabNameLength.Text = "0";
            this.lElzabNameLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbElzabProductName
            // 
            this.tbElzabProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabProductName.Location = new System.Drawing.Point(123, 6);
            this.tbElzabProductName.Margin = new System.Windows.Forms.Padding(5);
            this.tbElzabProductName.Name = "tbElzabProductName";
            this.tbElzabProductName.Size = new System.Drawing.Size(275, 26);
            this.tbElzabProductName.TabIndex = 0;
            this.tbElzabProductName.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabProductName_Validating);
            // 
            // lElzabProductName
            // 
            this.lElzabProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabProductName.Location = new System.Drawing.Point(6, 6);
            this.lElzabProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lElzabProductName.Name = "lElzabProductName";
            this.lElzabProductName.Size = new System.Drawing.Size(106, 30);
            this.lElzabProductName.TabIndex = 0;
            this.lElzabProductName.Text = "Nazwa Elzab";
            this.lElzabProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpElzabProductName
            // 
            this.tpElzabProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpElzabProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabProductName.ColumnCount = 3;
            this.tpElzabProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tpElzabProductName.Controls.Add(this.lElzabProductName, 0, 0);
            this.tpElzabProductName.Controls.Add(this.tbElzabProductName, 1, 0);
            this.tpElzabProductName.Controls.Add(this.lElzabNameLength, 2, 0);
            this.tpElzabProductName.ForeColor = System.Drawing.Color.Black;
            this.tpElzabProductName.Location = new System.Drawing.Point(464, 161);
            this.tpElzabProductName.Name = "tpElzabProductName";
            this.tpElzabProductName.RowCount = 1;
            this.tpElzabProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tpElzabProductName.Size = new System.Drawing.Size(450, 40);
            this.tpElzabProductName.TabIndex = 12;
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Controls.Add(this.tpElzabProductName);
            this.gbProductInfo.Controls.Add(this.tpPriceWithTax);
            this.gbProductInfo.Controls.Add(this.tpElzabProductNumber);
            this.gbProductInfo.Controls.Add(this.tpProductNameToEdit);
            this.gbProductInfo.Controls.Add(this.tpBarcodeToEdit);
            this.gbProductInfo.Controls.Add(this.tpManufacturerToEdit);
            this.gbProductInfo.Controls.Add(this.tpNetPriceWithDiscount);
            this.gbProductInfo.Controls.Add(this.tpDiscount);
            this.gbProductInfo.Controls.Add(this.tpSupplierCode);
            this.gbProductInfo.Controls.Add(this.tpShortBarcode);
            this.gbProductInfo.Controls.Add(this.tpFinalPrice);
            this.gbProductInfo.Controls.Add(this.pProductInfo);
            this.gbProductInfo.Controls.Add(this.tpSupplierName);
            this.gbProductInfo.Controls.Add(this.tPMarigin);
            this.gbProductInfo.Controls.Add(this.tpPrice);
            this.gbProductInfo.Controls.Add(this.tpTax);
            this.gbProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductInfo.ForeColor = System.Drawing.Color.Black;
            this.gbProductInfo.Location = new System.Drawing.Point(0, 136);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(926, 484);
            this.gbProductInfo.TabIndex = 2;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Dane produktu";
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.lName);
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Padding = new System.Windows.Forms.Padding(2);
            this.pHeader.Size = new System.Drawing.Size(926, 30);
            this.pHeader.TabIndex = 7;
            // 
            // lName
            // 
            this.lName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(22, 2);
            this.lName.Margin = new System.Windows.Forms.Padding(3);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(902, 26);
            this.lName.TabIndex = 7;
            this.lName.Text = "lName";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(2, 2);
            this.tbDummyForCtrl.Multiline = true;
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(20, 26);
            this.tbDummyForCtrl.TabIndex = 6;
            this.tbDummyForCtrl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
            // 
            // ucSearchBar
            // 
            this.ucSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.ucSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSearchBar.ForeColor = System.Drawing.Color.Black;
            this.ucSearchBar.IsBussy = false;
            this.ucSearchBar.Location = new System.Drawing.Point(0, 30);
            this.ucSearchBar.MinimumSize = new System.Drawing.Size(920, 106);
            this.ucSearchBar.Name = "ucSearchBar";
            this.ucSearchBar.Size = new System.Drawing.Size(926, 106);
            this.ucSearchBar.TabIndex = 8;
            this.ucSearchBar.NewEntSelected += new NaturalnieApp.Forms.Common.SearchBarTemplate.NewEntSelectedEventHandler(this.ucSearchBar_NewEntSelected);
            this.ucSearchBar.CopyButtonClick += new NaturalnieApp.Forms.Common.SearchBarTemplate.CopyButtonClickEventHandler(this.ucSearchBar_CopyButtonClick);
            this.ucSearchBar.PasteButtonClick += new NaturalnieApp.Forms.Common.SearchBarTemplate.PasteButtonClickEventHandler(this.ucSearchBar_PasteButtonClick);
            this.ucSearchBar.NewEntSelectedByAdditionalRequest += new NaturalnieApp.Forms.Common.SearchBarTemplate.NewEntSelectedByAdditionalRequestEventHandler(this.ucSearchBar_NewEntSelected);
            // 
            // ShowProductInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.gbProductInfo);
            this.Controls.Add(this.ucSearchBar);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(920, 690);
            this.Name = "ShowProductInfo";
            this.Size = new System.Drawing.Size(926, 690);
            this.Load += new System.EventHandler(this.ShowProductInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tpShortBarcode.ResumeLayout(false);
            this.tpShortBarcode.PerformLayout();
            this.tpFinalPrice.ResumeLayout(false);
            this.tpFinalPrice.PerformLayout();
            this.tpSupplierCode.ResumeLayout(false);
            this.tpSupplierCode.PerformLayout();
            this.pProductInfo.ResumeLayout(false);
            this.tpDiscount.ResumeLayout(false);
            this.tpDiscount.PerformLayout();
            this.tpSupplierName.ResumeLayout(false);
            this.tpNetPriceWithDiscount.ResumeLayout(false);
            this.tpNetPriceWithDiscount.PerformLayout();
            this.tPMarigin.ResumeLayout(false);
            this.tPMarigin.PerformLayout();
            this.tpManufacturerToEdit.ResumeLayout(false);
            this.tpPrice.ResumeLayout(false);
            this.tpPrice.PerformLayout();
            this.tpBarcodeToEdit.ResumeLayout(false);
            this.tpBarcodeToEdit.PerformLayout();
            this.tpTax.ResumeLayout(false);
            this.tpProductNameToEdit.ResumeLayout(false);
            this.tpProductNameToEdit.PerformLayout();
            this.tpElzabProductNumber.ResumeLayout(false);
            this.tpElzabProductNumber.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
            this.tpPriceWithTax.ResumeLayout(false);
            this.tpPriceWithTax.PerformLayout();
            this.tpElzabProductName.ResumeLayout(false);
            this.tpElzabProductName.PerformLayout();
            this.gbProductInfo.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.TableLayoutPanel tpElzabProductName;
        private System.Windows.Forms.Label lElzabProductName;
        private System.Windows.Forms.TextBox tbElzabProductName;
        private System.Windows.Forms.Label lElzabNameLength;
        private System.Windows.Forms.TableLayoutPanel tpPriceWithTax;
        private System.Windows.Forms.TextBox tbPriceWithTax;
        private System.Windows.Forms.Label lPriceWithTax;
        private System.Windows.Forms.TableLayoutPanel tpElzabProductNumber;
        private System.Windows.Forms.Label lElzabProductNumber;
        private System.Windows.Forms.Label lElzabProductNumberRange;
        private System.Windows.Forms.TextBox tbElzabProductNumber;
        private System.Windows.Forms.TableLayoutPanel tpProductNameToEdit;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lProductNameToEdit;
        private System.Windows.Forms.TableLayoutPanel tpBarcodeToEdit;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label lBarcodeToEdit;
        private System.Windows.Forms.TableLayoutPanel tpManufacturerToEdit;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Label lManufacturerToEdit;
        private System.Windows.Forms.TableLayoutPanel tpNetPriceWithDiscount;
        private System.Windows.Forms.TextBox tbPriceNetWithDiscount;
        private System.Windows.Forms.Label lNetPRiceWithDiscount;
        private System.Windows.Forms.TableLayoutPanel tpDiscount;
        private System.Windows.Forms.Label lDiscount;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TableLayoutPanel tpSupplierCode;
        private System.Windows.Forms.TextBox tbSupplierCode;
        private System.Windows.Forms.Label lSupplierCode;
        private System.Windows.Forms.TableLayoutPanel tpShortBarcode;
        private System.Windows.Forms.TextBox tbShortBarcode;
        private System.Windows.Forms.Label lShortBarcode;
        private System.Windows.Forms.TableLayoutPanel tpFinalPrice;
        private System.Windows.Forms.TextBox tbFinalPrice;
        private System.Windows.Forms.Label lFinalPrice;
        private System.Windows.Forms.TableLayoutPanel pProductInfo;
        private System.Windows.Forms.Label lProductInfo;
        private System.Windows.Forms.RichTextBox rtbProductInfo;
        private System.Windows.Forms.TableLayoutPanel tpSupplierName;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.Label lSupplierName;
        private System.Windows.Forms.TableLayoutPanel tPMarigin;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.TableLayoutPanel tpPrice;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TableLayoutPanel tpTax;
        private System.Windows.Forms.Label lTax;
        private System.Windows.Forms.ComboBox cbTax;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bDelete;
        private Common.SearchBarTemplate ucSearchBar;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Panel panel1;
    }
}