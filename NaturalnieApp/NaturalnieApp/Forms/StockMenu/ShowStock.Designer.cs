using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class ShowStock
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
            this.bGenerateCashRegisterProductList = new System.Windows.Forms.Button();
            this.bSaveToFile = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.bShow = new System.Windows.Forms.Button();
            this.lNumberOfProducts = new System.Windows.Forms.Label();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturers = new System.Windows.Forms.ComboBox();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.tbNumberOfProducts = new System.Windows.Forms.TextBox();
            this.tbStockQuantity = new System.Windows.Forms.TextBox();
            this.lStockQuantity = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pManufacturer.SuspendLayout();
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
            this.tbDummyForCtrl.TabIndex = 7;
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
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 150);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(920, 470);
            this.advancedDataGridView1.TabIndex = 2;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.bGenerateCashRegisterProductList);
            this.pButtonsPanel.Controls.Add(this.bSaveToFile);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // bGenerateCashRegisterProductList
            // 
            this.bGenerateCashRegisterProductList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bGenerateCashRegisterProductList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bGenerateCashRegisterProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bGenerateCashRegisterProductList.Location = new System.Drawing.Point(457, 10);
            this.bGenerateCashRegisterProductList.Name = "bGenerateCashRegisterProductList";
            this.bGenerateCashRegisterProductList.Size = new System.Drawing.Size(239, 50);
            this.bGenerateCashRegisterProductList.TabIndex = 8;
            this.bGenerateCashRegisterProductList.Text = "Generuj listę produktów Elzab";
            this.bGenerateCashRegisterProductList.UseMnemonic = false;
            this.bGenerateCashRegisterProductList.UseVisualStyleBackColor = false;
            this.bGenerateCashRegisterProductList.Click += new System.EventHandler(this.bGenerateCashRegisterProductList_Click);
            // 
            // bSaveToFile
            // 
            this.bSaveToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSaveToFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveToFile.Location = new System.Drawing.Point(702, 10);
            this.bSaveToFile.Name = "bSaveToFile";
            this.bSaveToFile.Size = new System.Drawing.Size(100, 50);
            this.bSaveToFile.TabIndex = 7;
            this.bSaveToFile.Text = "Zapisz do pliku";
            this.bSaveToFile.UseMnemonic = false;
            this.bSaveToFile.UseVisualStyleBackColor = false;
            this.bSaveToFile.Click += new System.EventHandler(this.bSaveToFile_Click);
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
            this.gbProductSelection.Controls.Add(this.bShow);
            this.gbProductSelection.Controls.Add(this.lNumberOfProducts);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Controls.Add(this.tbNumberOfProducts);
            this.gbProductSelection.Controls.Add(this.tbStockQuantity);
            this.gbProductSelection.Controls.Add(this.lStockQuantity);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 30);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(920, 120);
            this.gbProductSelection.TabIndex = 17;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // bShow
            // 
            this.bShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bShow.Location = new System.Drawing.Point(265, 30);
            this.bShow.Name = "bShow";
            this.bShow.Size = new System.Drawing.Size(70, 70);
            this.bShow.TabIndex = 15;
            this.bShow.Text = "Pokaż";
            this.bShow.UseVisualStyleBackColor = false;
            this.bShow.Click += new System.EventHandler(this.bShow_Click);
            // 
            // lNumberOfProducts
            // 
            this.lNumberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfProducts.Location = new System.Drawing.Point(368, 72);
            this.lNumberOfProducts.Margin = new System.Windows.Forms.Padding(5);
            this.lNumberOfProducts.Name = "lNumberOfProducts";
            this.lNumberOfProducts.Size = new System.Drawing.Size(166, 30);
            this.lNumberOfProducts.TabIndex = 30;
            this.lNumberOfProducts.Text = "Ilość produktów";
            this.lNumberOfProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 379F));
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
            this.cbManufacturers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
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
            // tbNumberOfProducts
            // 
            this.tbNumberOfProducts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbNumberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberOfProducts.Location = new System.Drawing.Point(554, 74);
            this.tbNumberOfProducts.Margin = new System.Windows.Forms.Padding(5);
            this.tbNumberOfProducts.Name = "tbNumberOfProducts";
            this.tbNumberOfProducts.ReadOnly = true;
            this.tbNumberOfProducts.Size = new System.Drawing.Size(123, 26);
            this.tbNumberOfProducts.TabIndex = 29;
            // 
            // tbStockQuantity
            // 
            this.tbStockQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbStockQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbStockQuantity.Location = new System.Drawing.Point(554, 33);
            this.tbStockQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.tbStockQuantity.Name = "tbStockQuantity";
            this.tbStockQuantity.ReadOnly = true;
            this.tbStockQuantity.Size = new System.Drawing.Size(123, 26);
            this.tbStockQuantity.TabIndex = 27;
            // 
            // lStockQuantity
            // 
            this.lStockQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lStockQuantity.Location = new System.Drawing.Point(368, 33);
            this.lStockQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.lStockQuantity.Name = "lStockQuantity";
            this.lStockQuantity.Size = new System.Drawing.Size(166, 30);
            this.lStockQuantity.TabIndex = 28;
            this.lStockQuantity.Text = "Stan magazynowy";
            this.lStockQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // ShowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(920, 690);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ShowStock";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.AddToStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddToStock_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            this.gbProductSelection.ResumeLayout(false);
            this.gbProductSelection.PerformLayout();
            this.pManufacturer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.ComboBox cbManufacturers;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbNumberOfProducts;
        private System.Windows.Forms.TextBox tbStockQuantity;
        private System.Windows.Forms.Label lNumberOfProducts;
        private System.Windows.Forms.Label lStockQuantity;
        private System.Windows.Forms.Button bShow;
        private System.Windows.Forms.Button bSaveToFile;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button bGenerateCashRegisterProductList;
    }
}