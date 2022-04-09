using System.ComponentModel;
namespace NaturalnieApp.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pMenu = new System.Windows.Forms.Panel();
            this.pHistoryOfSales = new System.Windows.Forms.Panel();
            this.bFullSalesHistory = new System.Windows.Forms.Button();
            this.bHistoryOfProductSale = new System.Windows.Forms.Button();
            this.bHistoryOfSales = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pStockSubMenu = new System.Windows.Forms.Panel();
            this.bShowStock = new System.Windows.Forms.Button();
            this.bPRintFromStock = new System.Windows.Forms.Button();
            this.bAddToStock = new System.Windows.Forms.Button();
            this.bStock = new System.Windows.Forms.Button();
            this.pProductSubMenu = new System.Windows.Forms.Panel();
            this.bPriceRelatedUpdate = new System.Windows.Forms.Button();
            this.bPrintBarcode = new System.Windows.Forms.Button();
            this.AddProductFromPdf = new System.Windows.Forms.Button();
            this.bNewProduct = new System.Windows.Forms.Button();
            this.bManufacturersList = new System.Windows.Forms.Button();
            this.bSupplierList = new System.Windows.Forms.Button();
            this.bShowProductInfo = new System.Windows.Forms.Button();
            this.bProductMenu = new System.Windows.Forms.Button();
            this.pCashRegisterSubMenu = new System.Windows.Forms.Panel();
            this.bCleanProductOutOfStock = new System.Windows.Forms.Button();
            this.bSalesBufforReading = new System.Windows.Forms.Button();
            this.bElzabSynchronization = new System.Windows.Forms.Button();
            this.bCashRegister = new System.Windows.Forms.Button();
            this.pMainMenuSubMenu = new System.Windows.Forms.Panel();
            this.bPlayground = new System.Windows.Forms.Button();
            this.bGeneralSettings = new System.Windows.Forms.Button();
            this.bMainMenu = new System.Windows.Forms.Button();
            this.pLogo = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pStatusBar = new System.Windows.Forms.Panel();
            this.pWindowButtons = new System.Windows.Forms.Panel();
            this.bMinimize = new System.Windows.Forms.Button();
            this.bMaximize = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.pMenuDeliminer = new System.Windows.Forms.Panel();
            this.pContainer = new System.Windows.Forms.Panel();
            this.pBottomLine = new System.Windows.Forms.Panel();
            this.pVersion = new System.Windows.Forms.Panel();
            this.lVersion = new System.Windows.Forms.Label();
            this.timer1sTick = new System.Windows.Forms.Timer(this.components);
            this.pMenu.SuspendLayout();
            this.pHistoryOfSales.SuspendLayout();
            this.pStockSubMenu.SuspendLayout();
            this.pProductSubMenu.SuspendLayout();
            this.pCashRegisterSubMenu.SuspendLayout();
            this.pMainMenuSubMenu.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pWindowButtons.SuspendLayout();
            this.pContainer.SuspendLayout();
            this.pBottomLine.SuspendLayout();
            this.pVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenu
            // 
            this.pMenu.AutoScroll = true;
            this.pMenu.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.pMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pMenu.Controls.Add(this.pHistoryOfSales);
            this.pMenu.Controls.Add(this.bHistoryOfSales);
            this.pMenu.Controls.Add(this.panel1);
            this.pMenu.Controls.Add(this.pStockSubMenu);
            this.pMenu.Controls.Add(this.bStock);
            this.pMenu.Controls.Add(this.pProductSubMenu);
            this.pMenu.Controls.Add(this.bProductMenu);
            this.pMenu.Controls.Add(this.pCashRegisterSubMenu);
            this.pMenu.Controls.Add(this.bCashRegister);
            this.pMenu.Controls.Add(this.pMainMenuSubMenu);
            this.pMenu.Controls.Add(this.bMainMenu);
            this.pMenu.Controls.Add(this.pLogo);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenu.Location = new System.Drawing.Point(1, 31);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(300, 698);
            this.pMenu.TabIndex = 0;
            // 
            // pHistoryOfSales
            // 
            this.pHistoryOfSales.AutoSize = true;
            this.pHistoryOfSales.BackColor = System.Drawing.Color.DimGray;
            this.pHistoryOfSales.Controls.Add(this.bFullSalesHistory);
            this.pHistoryOfSales.Controls.Add(this.bHistoryOfProductSale);
            this.pHistoryOfSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHistoryOfSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pHistoryOfSales.Location = new System.Drawing.Point(0, 814);
            this.pHistoryOfSales.Name = "pHistoryOfSales";
            this.pHistoryOfSales.Size = new System.Drawing.Size(283, 60);
            this.pHistoryOfSales.TabIndex = 12;
            // 
            // bFullSalesHistory
            // 
            this.bFullSalesHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bFullSalesHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.bFullSalesHistory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bFullSalesHistory.FlatAppearance.BorderSize = 0;
            this.bFullSalesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFullSalesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFullSalesHistory.ForeColor = System.Drawing.Color.White;
            this.bFullSalesHistory.Location = new System.Drawing.Point(0, 30);
            this.bFullSalesHistory.Name = "bFullSalesHistory";
            this.bFullSalesHistory.Size = new System.Drawing.Size(283, 30);
            this.bFullSalesHistory.TabIndex = 9;
            this.bFullSalesHistory.Text = "Pełna historia sprzedaży";
            this.bFullSalesHistory.UseVisualStyleBackColor = false;
            this.bFullSalesHistory.Click += new System.EventHandler(this.bFullSalesHistory_Click);
            // 
            // bHistoryOfProductSale
            // 
            this.bHistoryOfProductSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bHistoryOfProductSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.bHistoryOfProductSale.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bHistoryOfProductSale.FlatAppearance.BorderSize = 0;
            this.bHistoryOfProductSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHistoryOfProductSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHistoryOfProductSale.ForeColor = System.Drawing.Color.White;
            this.bHistoryOfProductSale.Location = new System.Drawing.Point(0, 0);
            this.bHistoryOfProductSale.Name = "bHistoryOfProductSale";
            this.bHistoryOfProductSale.Size = new System.Drawing.Size(283, 30);
            this.bHistoryOfProductSale.TabIndex = 8;
            this.bHistoryOfProductSale.Text = "Historia sprzedaży produktu";
            this.bHistoryOfProductSale.UseVisualStyleBackColor = false;
            this.bHistoryOfProductSale.Click += new System.EventHandler(this.bDisplayHistory_Click);
            // 
            // bHistoryOfSales
            // 
            this.bHistoryOfSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.bHistoryOfSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.bHistoryOfSales.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bHistoryOfSales.FlatAppearance.BorderSize = 0;
            this.bHistoryOfSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHistoryOfSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHistoryOfSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bHistoryOfSales.Location = new System.Drawing.Point(0, 764);
            this.bHistoryOfSales.Name = "bHistoryOfSales";
            this.bHistoryOfSales.Size = new System.Drawing.Size(283, 50);
            this.bHistoryOfSales.TabIndex = 10;
            this.bHistoryOfSales.Text = "Historia sprzedaży";
            this.bHistoryOfSales.UseVisualStyleBackColor = false;
            this.bHistoryOfSales.Click += new System.EventHandler(this.bHistoryOfSales_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 764);
            this.panel1.MinimumSize = new System.Drawing.Size(300, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 115);
            this.panel1.TabIndex = 8;
            // 
            // pStockSubMenu
            // 
            this.pStockSubMenu.AutoSize = true;
            this.pStockSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pStockSubMenu.Controls.Add(this.bShowStock);
            this.pStockSubMenu.Controls.Add(this.bPRintFromStock);
            this.pStockSubMenu.Controls.Add(this.bAddToStock);
            this.pStockSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pStockSubMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pStockSubMenu.Location = new System.Drawing.Point(0, 674);
            this.pStockSubMenu.Name = "pStockSubMenu";
            this.pStockSubMenu.Size = new System.Drawing.Size(283, 90);
            this.pStockSubMenu.TabIndex = 7;
            // 
            // bShowStock
            // 
            this.bShowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bShowStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bShowStock.FlatAppearance.BorderSize = 0;
            this.bShowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowStock.ForeColor = System.Drawing.Color.White;
            this.bShowStock.Location = new System.Drawing.Point(0, 60);
            this.bShowStock.Name = "bShowStock";
            this.bShowStock.Size = new System.Drawing.Size(283, 30);
            this.bShowStock.TabIndex = 10;
            this.bShowStock.Text = "Stany magazynowe";
            this.bShowStock.UseVisualStyleBackColor = false;
            this.bShowStock.Click += new System.EventHandler(this.bShowStock_Click);
            // 
            // bPRintFromStock
            // 
            this.bPRintFromStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPRintFromStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPRintFromStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPRintFromStock.FlatAppearance.BorderSize = 0;
            this.bPRintFromStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPRintFromStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPRintFromStock.ForeColor = System.Drawing.Color.White;
            this.bPRintFromStock.Location = new System.Drawing.Point(0, 30);
            this.bPRintFromStock.Name = "bPRintFromStock";
            this.bPRintFromStock.Size = new System.Drawing.Size(283, 30);
            this.bPRintFromStock.TabIndex = 9;
            this.bPRintFromStock.Text = "Drukuj z magazynu";
            this.bPRintFromStock.UseVisualStyleBackColor = false;
            this.bPRintFromStock.Click += new System.EventHandler(this.bPrintFromStock_Click);
            // 
            // bAddToStock
            // 
            this.bAddToStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAddToStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bAddToStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bAddToStock.FlatAppearance.BorderSize = 0;
            this.bAddToStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddToStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddToStock.ForeColor = System.Drawing.Color.White;
            this.bAddToStock.Location = new System.Drawing.Point(0, 0);
            this.bAddToStock.Name = "bAddToStock";
            this.bAddToStock.Size = new System.Drawing.Size(283, 30);
            this.bAddToStock.TabIndex = 8;
            this.bAddToStock.Text = "Dodaj do magazynu";
            this.bAddToStock.UseVisualStyleBackColor = false;
            this.bAddToStock.Click += new System.EventHandler(this.bAddToStock_Click);
            // 
            // bStock
            // 
            this.bStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.bStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bStock.FlatAppearance.BorderSize = 0;
            this.bStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bStock.Location = new System.Drawing.Point(0, 624);
            this.bStock.Name = "bStock";
            this.bStock.Size = new System.Drawing.Size(283, 50);
            this.bStock.TabIndex = 6;
            this.bStock.Text = "Magazyn";
            this.bStock.UseVisualStyleBackColor = false;
            this.bStock.Click += new System.EventHandler(this.bStock_Click);
            // 
            // pProductSubMenu
            // 
            this.pProductSubMenu.AutoSize = true;
            this.pProductSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pProductSubMenu.Controls.Add(this.bPriceRelatedUpdate);
            this.pProductSubMenu.Controls.Add(this.bPrintBarcode);
            this.pProductSubMenu.Controls.Add(this.AddProductFromPdf);
            this.pProductSubMenu.Controls.Add(this.bNewProduct);
            this.pProductSubMenu.Controls.Add(this.bManufacturersList);
            this.pProductSubMenu.Controls.Add(this.bSupplierList);
            this.pProductSubMenu.Controls.Add(this.bShowProductInfo);
            this.pProductSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pProductSubMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pProductSubMenu.Location = new System.Drawing.Point(0, 414);
            this.pProductSubMenu.Name = "pProductSubMenu";
            this.pProductSubMenu.Size = new System.Drawing.Size(283, 210);
            this.pProductSubMenu.TabIndex = 5;
            // 
            // bPriceRelatedUpdate
            // 
            this.bPriceRelatedUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPriceRelatedUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPriceRelatedUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPriceRelatedUpdate.FlatAppearance.BorderSize = 0;
            this.bPriceRelatedUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPriceRelatedUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPriceRelatedUpdate.ForeColor = System.Drawing.Color.White;
            this.bPriceRelatedUpdate.Location = new System.Drawing.Point(0, 180);
            this.bPriceRelatedUpdate.Name = "bPriceRelatedUpdate";
            this.bPriceRelatedUpdate.Size = new System.Drawing.Size(283, 30);
            this.bPriceRelatedUpdate.TabIndex = 10;
            this.bPriceRelatedUpdate.Text = "Aktualizacja (cen, podatku, itd.)";
            this.bPriceRelatedUpdate.UseVisualStyleBackColor = false;
            this.bPriceRelatedUpdate.Click += new System.EventHandler(this.bPriceRelatedUpdate_Click);
            // 
            // bPrintBarcode
            // 
            this.bPrintBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrintBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPrintBarcode.FlatAppearance.BorderSize = 0;
            this.bPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrintBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrintBarcode.ForeColor = System.Drawing.Color.White;
            this.bPrintBarcode.Location = new System.Drawing.Point(0, 150);
            this.bPrintBarcode.Name = "bPrintBarcode";
            this.bPrintBarcode.Size = new System.Drawing.Size(283, 30);
            this.bPrintBarcode.TabIndex = 8;
            this.bPrintBarcode.Text = "Drukuj kod kreskowy";
            this.bPrintBarcode.UseVisualStyleBackColor = false;
            this.bPrintBarcode.Click += new System.EventHandler(this.bPrintBarcode_Click);
            // 
            // AddProductFromPdf
            // 
            this.AddProductFromPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.AddProductFromPdf.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddProductFromPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProductFromPdf.FlatAppearance.BorderSize = 0;
            this.AddProductFromPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductFromPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductFromPdf.ForeColor = System.Drawing.Color.White;
            this.AddProductFromPdf.Location = new System.Drawing.Point(0, 120);
            this.AddProductFromPdf.Name = "AddProductFromPdf";
            this.AddProductFromPdf.Size = new System.Drawing.Size(283, 30);
            this.AddProductFromPdf.TabIndex = 6;
            this.AddProductFromPdf.Text = "Dodaj produkty z pdf";
            this.AddProductFromPdf.UseVisualStyleBackColor = false;
            this.AddProductFromPdf.Click += new System.EventHandler(this.AddProductFromPdf_Click);
            // 
            // bNewProduct
            // 
            this.bNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bNewProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bNewProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.bNewProduct.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bNewProduct.FlatAppearance.BorderSize = 0;
            this.bNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNewProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNewProduct.ForeColor = System.Drawing.Color.White;
            this.bNewProduct.Location = new System.Drawing.Point(0, 90);
            this.bNewProduct.Name = "bNewProduct";
            this.bNewProduct.Size = new System.Drawing.Size(283, 30);
            this.bNewProduct.TabIndex = 4;
            this.bNewProduct.Text = "Dodaj nowy produkt";
            this.bNewProduct.UseVisualStyleBackColor = false;
            this.bNewProduct.Click += new System.EventHandler(this.bNewProduct_Click);
            // 
            // bManufacturersList
            // 
            this.bManufacturersList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bManufacturersList.Dock = System.Windows.Forms.DockStyle.Top;
            this.bManufacturersList.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bManufacturersList.FlatAppearance.BorderSize = 0;
            this.bManufacturersList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bManufacturersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bManufacturersList.ForeColor = System.Drawing.Color.White;
            this.bManufacturersList.Location = new System.Drawing.Point(0, 60);
            this.bManufacturersList.Name = "bManufacturersList";
            this.bManufacturersList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bManufacturersList.Size = new System.Drawing.Size(283, 30);
            this.bManufacturersList.TabIndex = 11;
            this.bManufacturersList.Text = "Lista producentów";
            this.bManufacturersList.UseVisualStyleBackColor = false;
            this.bManufacturersList.Click += new System.EventHandler(this.bManufacturersList_Click);
            // 
            // bSupplierList
            // 
            this.bSupplierList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSupplierList.Dock = System.Windows.Forms.DockStyle.Top;
            this.bSupplierList.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bSupplierList.FlatAppearance.BorderSize = 0;
            this.bSupplierList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSupplierList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSupplierList.ForeColor = System.Drawing.Color.White;
            this.bSupplierList.Location = new System.Drawing.Point(0, 30);
            this.bSupplierList.Name = "bSupplierList";
            this.bSupplierList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bSupplierList.Size = new System.Drawing.Size(283, 30);
            this.bSupplierList.TabIndex = 12;
            this.bSupplierList.Text = "Lista dostawców";
            this.bSupplierList.UseVisualStyleBackColor = false;
            this.bSupplierList.Click += new System.EventHandler(this.bSupplierList_Click);
            // 
            // bShowProductInfo
            // 
            this.bShowProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bShowProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowProductInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bShowProductInfo.FlatAppearance.BorderSize = 0;
            this.bShowProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowProductInfo.ForeColor = System.Drawing.Color.White;
            this.bShowProductInfo.Location = new System.Drawing.Point(0, 0);
            this.bShowProductInfo.Name = "bShowProductInfo";
            this.bShowProductInfo.Size = new System.Drawing.Size(283, 30);
            this.bShowProductInfo.TabIndex = 7;
            this.bShowProductInfo.Text = "Znajdź produkt";
            this.bShowProductInfo.UseVisualStyleBackColor = false;
            this.bShowProductInfo.Click += new System.EventHandler(this.bShowProductInfo_Click);
            // 
            // bProductMenu
            // 
            this.bProductMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.bProductMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.bProductMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bProductMenu.FlatAppearance.BorderSize = 0;
            this.bProductMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bProductMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bProductMenu.Location = new System.Drawing.Point(0, 364);
            this.bProductMenu.Name = "bProductMenu";
            this.bProductMenu.Size = new System.Drawing.Size(283, 50);
            this.bProductMenu.TabIndex = 4;
            this.bProductMenu.Text = "Menu produktu";
            this.bProductMenu.UseVisualStyleBackColor = false;
            this.bProductMenu.Click += new System.EventHandler(this.bProductMenu_Click);
            // 
            // pCashRegisterSubMenu
            // 
            this.pCashRegisterSubMenu.AutoSize = true;
            this.pCashRegisterSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pCashRegisterSubMenu.Controls.Add(this.bCleanProductOutOfStock);
            this.pCashRegisterSubMenu.Controls.Add(this.bSalesBufforReading);
            this.pCashRegisterSubMenu.Controls.Add(this.bElzabSynchronization);
            this.pCashRegisterSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCashRegisterSubMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pCashRegisterSubMenu.Location = new System.Drawing.Point(0, 274);
            this.pCashRegisterSubMenu.Name = "pCashRegisterSubMenu";
            this.pCashRegisterSubMenu.Size = new System.Drawing.Size(283, 90);
            this.pCashRegisterSubMenu.TabIndex = 3;
            // 
            // bCleanProductOutOfStock
            // 
            this.bCleanProductOutOfStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCleanProductOutOfStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bCleanProductOutOfStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCleanProductOutOfStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCleanProductOutOfStock.FlatAppearance.BorderSize = 0;
            this.bCleanProductOutOfStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCleanProductOutOfStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCleanProductOutOfStock.ForeColor = System.Drawing.Color.White;
            this.bCleanProductOutOfStock.Location = new System.Drawing.Point(0, 60);
            this.bCleanProductOutOfStock.Name = "bCleanProductOutOfStock";
            this.bCleanProductOutOfStock.Size = new System.Drawing.Size(283, 30);
            this.bCleanProductOutOfStock.TabIndex = 6;
            this.bCleanProductOutOfStock.Text = "Czyszczenie produktów";
            this.bCleanProductOutOfStock.UseVisualStyleBackColor = false;
            this.bCleanProductOutOfStock.Click += new System.EventHandler(this.bCleanProductOutOfStock_Click);
            // 
            // bSalesBufforReading
            // 
            this.bSalesBufforReading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSalesBufforReading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bSalesBufforReading.Dock = System.Windows.Forms.DockStyle.Top;
            this.bSalesBufforReading.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bSalesBufforReading.FlatAppearance.BorderSize = 0;
            this.bSalesBufforReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSalesBufforReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalesBufforReading.ForeColor = System.Drawing.Color.White;
            this.bSalesBufforReading.Location = new System.Drawing.Point(0, 30);
            this.bSalesBufforReading.Name = "bSalesBufforReading";
            this.bSalesBufforReading.Size = new System.Drawing.Size(283, 30);
            this.bSalesBufforReading.TabIndex = 5;
            this.bSalesBufforReading.Text = "Odczyt pozycji sprzedaży";
            this.bSalesBufforReading.UseVisualStyleBackColor = false;
            this.bSalesBufforReading.Click += new System.EventHandler(this.bSalesBufferReading_Click);
            // 
            // bElzabSynchronization
            // 
            this.bElzabSynchronization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bElzabSynchronization.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bElzabSynchronization.Dock = System.Windows.Forms.DockStyle.Top;
            this.bElzabSynchronization.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bElzabSynchronization.FlatAppearance.BorderSize = 0;
            this.bElzabSynchronization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bElzabSynchronization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bElzabSynchronization.ForeColor = System.Drawing.Color.White;
            this.bElzabSynchronization.Location = new System.Drawing.Point(0, 0);
            this.bElzabSynchronization.Name = "bElzabSynchronization";
            this.bElzabSynchronization.Size = new System.Drawing.Size(283, 30);
            this.bElzabSynchronization.TabIndex = 4;
            this.bElzabSynchronization.Text = "Synchronizacja z kasą";
            this.bElzabSynchronization.UseVisualStyleBackColor = false;
            this.bElzabSynchronization.Click += new System.EventHandler(this.bElzabSynchronization_Click);
            // 
            // bCashRegister
            // 
            this.bCashRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.bCashRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegister.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegister.FlatAppearance.BorderSize = 0;
            this.bCashRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bCashRegister.Location = new System.Drawing.Point(0, 224);
            this.bCashRegister.Name = "bCashRegister";
            this.bCashRegister.Size = new System.Drawing.Size(283, 50);
            this.bCashRegister.TabIndex = 2;
            this.bCashRegister.Text = "Kasa fiskalna";
            this.bCashRegister.UseVisualStyleBackColor = false;
            this.bCashRegister.Click += new System.EventHandler(this.bCashRegister_Click);
            // 
            // pMainMenuSubMenu
            // 
            this.pMainMenuSubMenu.AutoSize = true;
            this.pMainMenuSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pMainMenuSubMenu.Controls.Add(this.bPlayground);
            this.pMainMenuSubMenu.Controls.Add(this.bGeneralSettings);
            this.pMainMenuSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMainMenuSubMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pMainMenuSubMenu.Location = new System.Drawing.Point(0, 164);
            this.pMainMenuSubMenu.Name = "pMainMenuSubMenu";
            this.pMainMenuSubMenu.Size = new System.Drawing.Size(283, 60);
            this.pMainMenuSubMenu.TabIndex = 9;
            // 
            // bPlayground
            // 
            this.bPlayground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPlayground.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPlayground.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPlayground.FlatAppearance.BorderSize = 0;
            this.bPlayground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPlayground.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPlayground.ForeColor = System.Drawing.Color.White;
            this.bPlayground.Location = new System.Drawing.Point(0, 30);
            this.bPlayground.Name = "bPlayground";
            this.bPlayground.Size = new System.Drawing.Size(283, 30);
            this.bPlayground.TabIndex = 5;
            this.bPlayground.Text = "Plac zabaw kuby;)";
            this.bPlayground.UseVisualStyleBackColor = false;
            this.bPlayground.Click += new System.EventHandler(this.bPlayground_Click);
            // 
            // bGeneralSettings
            // 
            this.bGeneralSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.bGeneralSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bGeneralSettings.FlatAppearance.BorderSize = 0;
            this.bGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGeneralSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGeneralSettings.ForeColor = System.Drawing.Color.White;
            this.bGeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.bGeneralSettings.Name = "bGeneralSettings";
            this.bGeneralSettings.Size = new System.Drawing.Size(283, 30);
            this.bGeneralSettings.TabIndex = 6;
            this.bGeneralSettings.Text = "Ustawienia";
            this.bGeneralSettings.UseVisualStyleBackColor = false;
            this.bGeneralSettings.Click += new System.EventHandler(this.bGeneralSettings_Click);
            // 
            // bMainMenu
            // 
            this.bMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.bMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.bMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bMainMenu.FlatAppearance.BorderSize = 0;
            this.bMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bMainMenu.Location = new System.Drawing.Point(0, 114);
            this.bMainMenu.Margin = new System.Windows.Forms.Padding(0);
            this.bMainMenu.Name = "bMainMenu";
            this.bMainMenu.Size = new System.Drawing.Size(283, 50);
            this.bMainMenu.TabIndex = 1;
            this.bMainMenu.Text = "Menu główne";
            this.bMainMenu.UseVisualStyleBackColor = false;
            this.bMainMenu.Click += new System.EventHandler(this.bMainMenu_Click);
            // 
            // pLogo
            // 
            this.pLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pLogo.BackgroundImage")));
            this.pLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pLogo.Location = new System.Drawing.Point(0, 0);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(283, 114);
            this.pLogo.TabIndex = 0;
            this.pLogo.Click += new System.EventHandler(this.pLogo_Click);
            this.pLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pLogo_Click);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pHeader.Controls.Add(this.pStatusBar);
            this.pHeader.Controls.Add(this.pWindowButtons);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(1, 1);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1238, 30);
            this.pHeader.TabIndex = 4;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // pStatusBar
            // 
            this.pStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pStatusBar.Location = new System.Drawing.Point(0, 0);
            this.pStatusBar.Name = "pStatusBar";
            this.pStatusBar.Size = new System.Drawing.Size(1148, 30);
            this.pStatusBar.TabIndex = 9;
            this.pStatusBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pStatusBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pStatusBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // pWindowButtons
            // 
            this.pWindowButtons.Controls.Add(this.bMinimize);
            this.pWindowButtons.Controls.Add(this.bMaximize);
            this.pWindowButtons.Controls.Add(this.bExit);
            this.pWindowButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pWindowButtons.Location = new System.Drawing.Point(1148, 0);
            this.pWindowButtons.Name = "pWindowButtons";
            this.pWindowButtons.Size = new System.Drawing.Size(90, 30);
            this.pWindowButtons.TabIndex = 8;
            // 
            // bMinimize
            // 
            this.bMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bMinimize.BackgroundImage")));
            this.bMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.bMinimize.FlatAppearance.BorderSize = 0;
            this.bMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMinimize.Location = new System.Drawing.Point(0, 0);
            this.bMinimize.Name = "bMinimize";
            this.bMinimize.Size = new System.Drawing.Size(30, 30);
            this.bMinimize.TabIndex = 6;
            this.bMinimize.UseVisualStyleBackColor = true;
            this.bMinimize.Click += new System.EventHandler(this.bMinimize_Click);
            this.bMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.bMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.bMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // bMaximize
            // 
            this.bMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bMaximize.BackgroundImage")));
            this.bMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.bMaximize.FlatAppearance.BorderSize = 0;
            this.bMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMaximize.Location = new System.Drawing.Point(30, 0);
            this.bMaximize.Name = "bMaximize";
            this.bMaximize.Size = new System.Drawing.Size(30, 30);
            this.bMaximize.TabIndex = 5;
            this.bMaximize.UseVisualStyleBackColor = true;
            this.bMaximize.Click += new System.EventHandler(this.bMaximize_Click);
            this.bMaximize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.bMaximize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.bMaximize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // bExit
            // 
            this.bExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bExit.BackgroundImage")));
            this.bExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Location = new System.Drawing.Point(60, 0);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(30, 30);
            this.bExit.TabIndex = 1;
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            this.bExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.bExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.bExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // pMenuDeliminer
            // 
            this.pMenuDeliminer.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pMenuDeliminer.BackColor = System.Drawing.Color.DimGray;
            this.pMenuDeliminer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenuDeliminer.Enabled = false;
            this.pMenuDeliminer.Location = new System.Drawing.Point(301, 31);
            this.pMenuDeliminer.Name = "pMenuDeliminer";
            this.pMenuDeliminer.Size = new System.Drawing.Size(2, 698);
            this.pMenuDeliminer.TabIndex = 6;
            // 
            // pContainer
            // 
            this.pContainer.AutoScroll = true;
            this.pContainer.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.pContainer.AutoScrollMinSize = new System.Drawing.Size(300, 300);
            this.pContainer.AutoSize = true;
            this.pContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pContainer.Controls.Add(this.pBottomLine);
            this.pContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContainer.ForeColor = System.Drawing.Color.White;
            this.pContainer.Location = new System.Drawing.Point(303, 31);
            this.pContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pContainer.MinimumSize = new System.Drawing.Size(300, 300);
            this.pContainer.Name = "pContainer";
            this.pContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pContainer.Size = new System.Drawing.Size(936, 698);
            this.pContainer.TabIndex = 7;
            this.pContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // pBottomLine
            // 
            this.pBottomLine.Controls.Add(this.pVersion);
            this.pBottomLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomLine.Location = new System.Drawing.Point(1, 667);
            this.pBottomLine.Name = "pBottomLine";
            this.pBottomLine.Size = new System.Drawing.Size(934, 30);
            this.pBottomLine.TabIndex = 1;
            // 
            // pVersion
            // 
            this.pVersion.Controls.Add(this.lVersion);
            this.pVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pVersion.Location = new System.Drawing.Point(0, 0);
            this.pVersion.Margin = new System.Windows.Forms.Padding(0);
            this.pVersion.Name = "pVersion";
            this.pVersion.Padding = new System.Windows.Forms.Padding(1);
            this.pVersion.Size = new System.Drawing.Size(80, 30);
            this.pVersion.TabIndex = 0;
            // 
            // lVersion
            // 
            this.lVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lVersion.ForeColor = System.Drawing.Color.Gray;
            this.lVersion.Location = new System.Drawing.Point(1, 1);
            this.lVersion.Margin = new System.Windows.Forms.Padding(1);
            this.lVersion.Name = "lVersion";
            this.lVersion.Padding = new System.Windows.Forms.Padding(1);
            this.lVersion.Size = new System.Drawing.Size(78, 28);
            this.lVersion.TabIndex = 2;
            this.lVersion.Text = "1.0.0.0";
            this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1sTick
            // 
            this.timer1sTick.Interval = 1000;
            this.timer1sTick.Tick += new System.EventHandler(this.timer5sTick_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1240, 730);
            this.Controls.Add(this.pContainer);
            this.Controls.Add(this.pMenuDeliminer);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.pHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(940, 600);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "ElzabCommands";
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.pHistoryOfSales.ResumeLayout(false);
            this.pStockSubMenu.ResumeLayout(false);
            this.pProductSubMenu.ResumeLayout(false);
            this.pCashRegisterSubMenu.ResumeLayout(false);
            this.pMainMenuSubMenu.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pWindowButtons.ResumeLayout(false);
            this.pContainer.ResumeLayout(false);
            this.pBottomLine.ResumeLayout(false);
            this.pVersion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button bMainMenu;
        private System.Windows.Forms.Panel pCashRegisterSubMenu;
        private System.Windows.Forms.Button bElzabSynchronization;
        private System.Windows.Forms.Button bCashRegister;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pProductSubMenu;
        private System.Windows.Forms.Button bNewProduct;
        private System.Windows.Forms.Button bProductMenu;
        private System.Windows.Forms.Button bShowProductInfo;
        private System.Windows.Forms.Button AddProductFromPdf;
        private System.Windows.Forms.Button bPrintBarcode;
        private System.Windows.Forms.Panel pStockSubMenu;
        private System.Windows.Forms.Button bAddToStock;
        private System.Windows.Forms.Button bStock;
        private System.Windows.Forms.Button bPRintFromStock;
        private System.Windows.Forms.Button bShowStock;
        private System.Windows.Forms.Panel pMenuDeliminer;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pMainMenuSubMenu;
        private System.Windows.Forms.Button bPlayground;
        private System.Windows.Forms.Button bGeneralSettings;
        private System.Windows.Forms.Button bPriceRelatedUpdate;
        private System.Windows.Forms.Timer timer1sTick;
        private System.Windows.Forms.Button bSalesBufforReading;
        private System.Windows.Forms.Panel pBottomLine;
        private System.Windows.Forms.Panel pVersion;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Panel pWindowButtons;
        private System.Windows.Forms.Button bMinimize;
        private System.Windows.Forms.Button bMaximize;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Panel pStatusBar;
        private System.Windows.Forms.Button bManufacturersList;
        private System.Windows.Forms.Button bSupplierList;
        private System.Windows.Forms.Button bHistoryOfSales;
        private System.Windows.Forms.Panel pHistoryOfSales;
        private System.Windows.Forms.Button bHistoryOfProductSale;
        private System.Windows.Forms.Button bFullSalesHistory;
        private System.Windows.Forms.Button bCleanProductOutOfStock;
    }
}