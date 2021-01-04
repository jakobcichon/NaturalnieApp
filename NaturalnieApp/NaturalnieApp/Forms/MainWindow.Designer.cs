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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pMenu = new System.Windows.Forms.Panel();
            this.pStockSubMenu = new System.Windows.Forms.Panel();
            this.bAddToStock = new System.Windows.Forms.Button();
            this.bStock = new System.Windows.Forms.Button();
            this.pProductSubMenu = new System.Windows.Forms.Panel();
            this.bAddManufacturer = new System.Windows.Forms.Button();
            this.bPrintBarcode = new System.Windows.Forms.Button();
            this.bShowProductInfo = new System.Windows.Forms.Button();
            this.AddProductFromPdf = new System.Windows.Forms.Button();
            this.bNewProduct = new System.Windows.Forms.Button();
            this.bProductMenu = new System.Windows.Forms.Button();
            this.pCashRegisterSubMenu = new System.Windows.Forms.Panel();
            this.bCashRegisterSettings = new System.Windows.Forms.Button();
            this.bCashRegisterInfo = new System.Windows.Forms.Button();
            this.bCashRegister = new System.Windows.Forms.Button();
            this.bMainMenu = new System.Windows.Forms.Button();
            this.pLogo = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lDtabaseStatus = new System.Windows.Forms.Label();
            this.lDatabaseConnState = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.pContainer = new System.Windows.Forms.Panel();
            this.bPRintFromStock = new System.Windows.Forms.Button();
            this.pMenu.SuspendLayout();
            this.pStockSubMenu.SuspendLayout();
            this.pProductSubMenu.SuspendLayout();
            this.pCashRegisterSubMenu.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.White;
            this.pMenu.Controls.Add(this.pStockSubMenu);
            this.pMenu.Controls.Add(this.bStock);
            this.pMenu.Controls.Add(this.pProductSubMenu);
            this.pMenu.Controls.Add(this.bProductMenu);
            this.pMenu.Controls.Add(this.pCashRegisterSubMenu);
            this.pMenu.Controls.Add(this.bCashRegister);
            this.pMenu.Controls.Add(this.bMainMenu);
            this.pMenu.Controls.Add(this.pLogo);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenu.Location = new System.Drawing.Point(0, 30);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(200, 570);
            this.pMenu.TabIndex = 0;
            // 
            // pStockSubMenu
            // 
            this.pStockSubMenu.AutoSize = true;
            this.pStockSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pStockSubMenu.Controls.Add(this.bPRintFromStock);
            this.pStockSubMenu.Controls.Add(this.bAddToStock);
            this.pStockSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pStockSubMenu.Location = new System.Drawing.Point(0, 446);
            this.pStockSubMenu.Name = "pStockSubMenu";
            this.pStockSubMenu.Size = new System.Drawing.Size(200, 60);
            this.pStockSubMenu.TabIndex = 7;
            // 
            // bAddToStock
            // 
            this.bAddToStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAddToStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bAddToStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bAddToStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddToStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddToStock.ForeColor = System.Drawing.Color.White;
            this.bAddToStock.Location = new System.Drawing.Point(0, 0);
            this.bAddToStock.Name = "bAddToStock";
            this.bAddToStock.Size = new System.Drawing.Size(200, 30);
            this.bAddToStock.TabIndex = 8;
            this.bAddToStock.Text = "Dodaj do magazynu";
            this.bAddToStock.UseVisualStyleBackColor = false;
            this.bAddToStock.Click += new System.EventHandler(this.bAddToStock_Click);
            // 
            // bStock
            // 
            this.bStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStock.ForeColor = System.Drawing.Color.White;
            this.bStock.Location = new System.Drawing.Point(0, 406);
            this.bStock.Name = "bStock";
            this.bStock.Size = new System.Drawing.Size(200, 40);
            this.bStock.TabIndex = 6;
            this.bStock.Text = "Magazyn";
            this.bStock.UseVisualStyleBackColor = false;
            this.bStock.Click += new System.EventHandler(this.bStock_Click);
            // 
            // pProductSubMenu
            // 
            this.pProductSubMenu.AutoSize = true;
            this.pProductSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pProductSubMenu.Controls.Add(this.bAddManufacturer);
            this.pProductSubMenu.Controls.Add(this.bPrintBarcode);
            this.pProductSubMenu.Controls.Add(this.bShowProductInfo);
            this.pProductSubMenu.Controls.Add(this.AddProductFromPdf);
            this.pProductSubMenu.Controls.Add(this.bNewProduct);
            this.pProductSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pProductSubMenu.Location = new System.Drawing.Point(0, 256);
            this.pProductSubMenu.Name = "pProductSubMenu";
            this.pProductSubMenu.Size = new System.Drawing.Size(200, 150);
            this.pProductSubMenu.TabIndex = 5;
            // 
            // bAddManufacturer
            // 
            this.bAddManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAddManufacturer.Dock = System.Windows.Forms.DockStyle.Top;
            this.bAddManufacturer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bAddManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bAddManufacturer.ForeColor = System.Drawing.Color.White;
            this.bAddManufacturer.Location = new System.Drawing.Point(0, 120);
            this.bAddManufacturer.Name = "bAddManufacturer";
            this.bAddManufacturer.Size = new System.Drawing.Size(200, 30);
            this.bAddManufacturer.TabIndex = 9;
            this.bAddManufacturer.Text = "Dodaj producenta/dostawcę";
            this.bAddManufacturer.UseVisualStyleBackColor = false;
            this.bAddManufacturer.Click += new System.EventHandler(this.bAddManufacturer_Click);
            // 
            // bPrintBarcode
            // 
            this.bPrintBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrintBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrintBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrintBarcode.ForeColor = System.Drawing.Color.White;
            this.bPrintBarcode.Location = new System.Drawing.Point(0, 90);
            this.bPrintBarcode.Name = "bPrintBarcode";
            this.bPrintBarcode.Size = new System.Drawing.Size(200, 30);
            this.bPrintBarcode.TabIndex = 8;
            this.bPrintBarcode.Text = "Drukuj kod kreskowy";
            this.bPrintBarcode.UseVisualStyleBackColor = false;
            this.bPrintBarcode.Click += new System.EventHandler(this.bPrintBarcode_Click);
            // 
            // bShowProductInfo
            // 
            this.bShowProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bShowProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowProductInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bShowProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowProductInfo.ForeColor = System.Drawing.Color.White;
            this.bShowProductInfo.Location = new System.Drawing.Point(0, 60);
            this.bShowProductInfo.Name = "bShowProductInfo";
            this.bShowProductInfo.Size = new System.Drawing.Size(200, 30);
            this.bShowProductInfo.TabIndex = 7;
            this.bShowProductInfo.Text = "Znajdź produkt";
            this.bShowProductInfo.UseVisualStyleBackColor = false;
            this.bShowProductInfo.Click += new System.EventHandler(this.bShowProductInfo_Click);
            // 
            // AddProductFromPdf
            // 
            this.AddProductFromPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.AddProductFromPdf.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddProductFromPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddProductFromPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductFromPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductFromPdf.ForeColor = System.Drawing.Color.White;
            this.AddProductFromPdf.Location = new System.Drawing.Point(0, 30);
            this.AddProductFromPdf.Name = "AddProductFromPdf";
            this.AddProductFromPdf.Size = new System.Drawing.Size(200, 30);
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
            this.bNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNewProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNewProduct.ForeColor = System.Drawing.Color.White;
            this.bNewProduct.Location = new System.Drawing.Point(0, 0);
            this.bNewProduct.Name = "bNewProduct";
            this.bNewProduct.Size = new System.Drawing.Size(200, 30);
            this.bNewProduct.TabIndex = 4;
            this.bNewProduct.Text = "Dodaj nowy produkt";
            this.bNewProduct.UseVisualStyleBackColor = false;
            this.bNewProduct.Click += new System.EventHandler(this.bNewProduct_Click);
            // 
            // bProductMenu
            // 
            this.bProductMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bProductMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.bProductMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bProductMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bProductMenu.ForeColor = System.Drawing.Color.White;
            this.bProductMenu.Location = new System.Drawing.Point(0, 216);
            this.bProductMenu.Name = "bProductMenu";
            this.bProductMenu.Size = new System.Drawing.Size(200, 40);
            this.bProductMenu.TabIndex = 4;
            this.bProductMenu.Text = "Menu produktu";
            this.bProductMenu.UseVisualStyleBackColor = false;
            this.bProductMenu.Click += new System.EventHandler(this.bProductMenu_Click);
            // 
            // pCashRegisterSubMenu
            // 
            this.pCashRegisterSubMenu.BackColor = System.Drawing.Color.DimGray;
            this.pCashRegisterSubMenu.Controls.Add(this.bCashRegisterSettings);
            this.pCashRegisterSubMenu.Controls.Add(this.bCashRegisterInfo);
            this.pCashRegisterSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCashRegisterSubMenu.Location = new System.Drawing.Point(0, 156);
            this.pCashRegisterSubMenu.Name = "pCashRegisterSubMenu";
            this.pCashRegisterSubMenu.Size = new System.Drawing.Size(200, 60);
            this.pCashRegisterSubMenu.TabIndex = 3;
            // 
            // bCashRegisterSettings
            // 
            this.bCashRegisterSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegisterSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegisterSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegisterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegisterSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegisterSettings.ForeColor = System.Drawing.Color.White;
            this.bCashRegisterSettings.Location = new System.Drawing.Point(0, 30);
            this.bCashRegisterSettings.Name = "bCashRegisterSettings";
            this.bCashRegisterSettings.Size = new System.Drawing.Size(200, 30);
            this.bCashRegisterSettings.TabIndex = 5;
            this.bCashRegisterSettings.Text = "Ustawienia";
            this.bCashRegisterSettings.UseVisualStyleBackColor = false;
            this.bCashRegisterSettings.Click += new System.EventHandler(this.bCashRegisterSettings_Click);
            // 
            // bCashRegisterInfo
            // 
            this.bCashRegisterInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegisterInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bCashRegisterInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegisterInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegisterInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegisterInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegisterInfo.ForeColor = System.Drawing.Color.White;
            this.bCashRegisterInfo.Location = new System.Drawing.Point(0, 0);
            this.bCashRegisterInfo.Name = "bCashRegisterInfo";
            this.bCashRegisterInfo.Size = new System.Drawing.Size(200, 30);
            this.bCashRegisterInfo.TabIndex = 4;
            this.bCashRegisterInfo.Text = "Informacje";
            this.bCashRegisterInfo.UseVisualStyleBackColor = false;
            this.bCashRegisterInfo.Click += new System.EventHandler(this.bCashRegisterInfo_Click);
            // 
            // bCashRegister
            // 
            this.bCashRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bCashRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCashRegister.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bCashRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCashRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCashRegister.ForeColor = System.Drawing.Color.White;
            this.bCashRegister.Location = new System.Drawing.Point(0, 116);
            this.bCashRegister.Name = "bCashRegister";
            this.bCashRegister.Size = new System.Drawing.Size(200, 40);
            this.bCashRegister.TabIndex = 2;
            this.bCashRegister.Text = "Kasa fiskalna";
            this.bCashRegister.UseVisualStyleBackColor = false;
            this.bCashRegister.Click += new System.EventHandler(this.bCashRegister_Click);
            // 
            // bMainMenu
            // 
            this.bMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.bMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMainMenu.ForeColor = System.Drawing.Color.White;
            this.bMainMenu.Location = new System.Drawing.Point(0, 76);
            this.bMainMenu.Name = "bMainMenu";
            this.bMainMenu.Size = new System.Drawing.Size(200, 40);
            this.bMainMenu.TabIndex = 1;
            this.bMainMenu.Text = "Menu główne";
            this.bMainMenu.UseVisualStyleBackColor = false;
            // 
            // pLogo
            // 
            this.pLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pLogo.BackgroundImage")));
            this.pLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pLogo.Location = new System.Drawing.Point(0, 0);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(200, 76);
            this.pLogo.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.pHeader.Controls.Add(this.lDtabaseStatus);
            this.pHeader.Controls.Add(this.lDatabaseConnState);
            this.pHeader.Controls.Add(this.bExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1200, 30);
            this.pHeader.TabIndex = 4;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // lDtabaseStatus
            // 
            this.lDtabaseStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lDtabaseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDtabaseStatus.Location = new System.Drawing.Point(271, 0);
            this.lDtabaseStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lDtabaseStatus.Name = "lDtabaseStatus";
            this.lDtabaseStatus.Size = new System.Drawing.Size(259, 30);
            this.lDtabaseStatus.TabIndex = 2;
            this.lDtabaseStatus.Text = "Brak informacji";
            this.lDtabaseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDatabaseConnState
            // 
            this.lDatabaseConnState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lDatabaseConnState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDatabaseConnState.Location = new System.Drawing.Point(0, 0);
            this.lDatabaseConnState.Margin = new System.Windows.Forms.Padding(5);
            this.lDatabaseConnState.Name = "lDatabaseConnState";
            this.lDatabaseConnState.Size = new System.Drawing.Size(271, 30);
            this.lDatabaseConnState.TabIndex = 1;
            this.lDatabaseConnState.Text = "Status połączenia do bazy danych:";
            this.lDatabaseConnState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bExit
            // 
            this.bExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bExit.BackgroundImage")));
            this.bExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Location = new System.Drawing.Point(1170, 0);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(30, 30);
            this.bExit.TabIndex = 0;
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // pContainer
            // 
            this.pContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pContainer.Location = new System.Drawing.Point(200, 30);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(1000, 570);
            this.pContainer.TabIndex = 5;
            // 
            // bPRintFromStock
            // 
            this.bPRintFromStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPRintFromStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.bPRintFromStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPRintFromStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPRintFromStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPRintFromStock.ForeColor = System.Drawing.Color.White;
            this.bPRintFromStock.Location = new System.Drawing.Point(0, 30);
            this.bPRintFromStock.Name = "bPRintFromStock";
            this.bPRintFromStock.Size = new System.Drawing.Size(200, 30);
            this.bPRintFromStock.TabIndex = 9;
            this.bPRintFromStock.Text = "Drukuj z magazynu";
            this.bPRintFromStock.UseVisualStyleBackColor = false;
            this.bPRintFromStock.Click += new System.EventHandler(this.bPRintFromStock_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.pContainer);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "ElzabCommands";
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.pStockSubMenu.ResumeLayout(false);
            this.pProductSubMenu.ResumeLayout(false);
            this.pCashRegisterSubMenu.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button bMainMenu;
        private System.Windows.Forms.Panel pCashRegisterSubMenu;
        private System.Windows.Forms.Button bCashRegisterSettings;
        private System.Windows.Forms.Button bCashRegisterInfo;
        private System.Windows.Forms.Button bCashRegister;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Panel pProductSubMenu;
        private System.Windows.Forms.Button bNewProduct;
        private System.Windows.Forms.Button bProductMenu;
        private System.Windows.Forms.Label lDtabaseStatus;
        private System.Windows.Forms.Label lDatabaseConnState;
        private System.Windows.Forms.Button bShowProductInfo;
        private System.Windows.Forms.Button AddProductFromPdf;
        private System.Windows.Forms.Button bPrintBarcode;
        private System.Windows.Forms.Panel pStockSubMenu;
        private System.Windows.Forms.Button bAddToStock;
        private System.Windows.Forms.Button bStock;
        private System.Windows.Forms.Button bAddManufacturer;
        private System.Windows.Forms.Button bPRintFromStock;
    }
}