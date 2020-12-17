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
            this.panel1 = new System.Windows.Forms.Panel();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.bPrint = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.pBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pProductName = new System.Windows.Forms.TableLayoutPanel();
            this.lProductName = new System.Windows.Forms.Label();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.tbManufacturers = new System.Windows.Forms.TextBox();
            this.tbProducts = new System.Windows.Forms.TextBox();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
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
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 156);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(1000, 344);
            this.advancedDataGridView1.TabIndex = 2;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(888, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 3;
            this.bPrint.Text = "Drukuj";
            this.bPrint.UseVisualStyleBackColor = false;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 500);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(1000, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // gbProductSelection
            // 
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
            // pBarCode
            // 
            this.pBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pBarCode.ColumnCount = 1;
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.pBarCode.Controls.Add(this.tbBarCode, 0, 1);
            this.pBarCode.Controls.Add(this.label1, 0, 0);
            this.pBarCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBarCode.Location = new System.Drawing.Point(740, 30);
            this.pBarCode.Margin = new System.Windows.Forms.Padding(0);
            this.pBarCode.Name = "pBarCode";
            this.pBarCode.RowCount = 2;
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pBarCode.Size = new System.Drawing.Size(252, 70);
            this.pBarCode.TabIndex = 18;
            // 
            // tbBarCode
            // 
            this.tbBarCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarCode.Location = new System.Drawing.Point(6, 37);
            this.tbBarCode.Margin = new System.Windows.Forms.Padding(5);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(230, 26);
            this.tbBarCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kod kreskowy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pProductName
            // 
            this.pProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductName.ColumnCount = 1;
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 524F));
            this.pProductName.Controls.Add(this.tbProducts, 0, 1);
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
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.pManufacturer.Controls.Add(this.tbManufacturers, 0, 1);
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
            // tbManufacturers
            // 
            this.tbManufacturers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbManufacturers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbManufacturers.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbManufacturers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbManufacturers.Location = new System.Drawing.Point(6, 37);
            this.tbManufacturers.Margin = new System.Windows.Forms.Padding(5);
            this.tbManufacturers.Name = "tbManufacturers";
            this.tbManufacturers.Size = new System.Drawing.Size(240, 26);
            this.tbManufacturers.TabIndex = 4;
            // 
            // tbProducts
            // 
            this.tbProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProducts.Location = new System.Drawing.Point(6, 37);
            this.tbProducts.Margin = new System.Windows.Forms.Padding(5);
            this.tbProducts.Name = "tbProducts";
            this.tbProducts.Size = new System.Drawing.Size(450, 26);
            this.tbProducts.TabIndex = 5;
            // 
            // PrintBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.gbProductSelection);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PrintBarcode";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.PrintBarcode_Load);
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            this.gbProductSelection.ResumeLayout(false);
            this.pBarCode.ResumeLayout(false);
            this.pBarCode.PerformLayout();
            this.pProductName.ResumeLayout(false);
            this.pProductName.PerformLayout();
            this.pManufacturer.ResumeLayout(false);
            this.pManufacturer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pBarCode;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel pProductName;
        private System.Windows.Forms.TextBox tbProducts;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.TextBox tbManufacturers;
        private System.Windows.Forms.Label lManufacturer;
    }
}