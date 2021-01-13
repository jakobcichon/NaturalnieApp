using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class PrintBarcode
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
            this.bPrint = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.pHeader.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1094, 30);
            this.pHeader.TabIndex = 0;
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
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(782, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 0;
            this.bPrint.Text = "Drukuj";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 626);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(1094, 70);
            this.pButtonsPanel.TabIndex = 3;
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(888, 10);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 1;
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
            this.gbProductSelection.Size = new System.Drawing.Size(1094, 106);
            this.gbProductSelection.TabIndex = 1;
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
            this.bAdd.TabIndex = 3;
            this.bAdd.Text = "Dodaj";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // pBarCode
            // 
            this.pBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pBarCode.ColumnCount = 1;
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 368F));
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
            this.pBarCode.TabIndex = 2;
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
            this.cbBarcodes.TabIndex = 1;
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
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 555F));
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
            this.pProductName.TabIndex = 1;
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
            this.cbProductsList.TabIndex = 1;
            this.cbProductsList.SelectedIndexChanged += new System.EventHandler(this.cbProductsList_SelectedIndexChanged);
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
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 345F));
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
            this.pManufacturer.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridView1);
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 362);
            this.panel2.TabIndex = 5;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(732, 362);
            this.advancedDataGridView1.TabIndex = 5;
            // 
            // PrintBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1094, 696);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PrintBarcode";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.PrintBarcode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintBarcode_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
            this.gbProductSelection.ResumeLayout(false);
            this.pBarCode.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bPrint;
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
        private System.Windows.Forms.Panel panel2;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
    }
}