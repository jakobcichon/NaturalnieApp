
namespace NaturalnieApp.Forms.Common
{
    partial class SearchBarTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBarTemplate));
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.pBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.cbBarcodes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pProductName = new System.Windows.Forms.TableLayoutPanel();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lProductName = new System.Windows.Forms.Label();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.cbManufacturers = new System.Windows.Forms.ComboBox();
            this.tpLoadingBar = new System.Windows.Forms.TableLayoutPanel();
            this.pbLoadingBar = new System.Windows.Forms.PictureBox();
            this.lLoadingBar = new System.Windows.Forms.Label();
            this.bGenericButton = new System.Windows.Forms.Button();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.tpLoadingBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProductSelection
            // 
            this.gbProductSelection.Controls.Add(this.bGenericButton);
            this.gbProductSelection.Controls.Add(this.tpLoadingBar);
            this.gbProductSelection.Controls.Add(this.tbDummyForCtrl);
            this.gbProductSelection.Controls.Add(this.pBarCode);
            this.gbProductSelection.Controls.Add(this.pProductName);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 0);
            this.gbProductSelection.Margin = new System.Windows.Forms.Padding(5);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(920, 106);
            this.gbProductSelection.TabIndex = 2;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Location = new System.Drawing.Point(820, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 26);
            this.tbDummyForCtrl.TabIndex = 9;
            this.tbDummyForCtrl.Visible = false;
            this.tbDummyForCtrl.Enter += new System.EventHandler(this.tbDummyForCtrl_Enter);
            // 
            // pBarCode
            // 
            this.pBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pBarCode.ColumnCount = 1;
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pBarCode.Controls.Add(this.cbBarcodes, 0, 1);
            this.pBarCode.Controls.Add(this.label1, 0, 0);
            this.pBarCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBarCode.Location = new System.Drawing.Point(685, 36);
            this.pBarCode.Margin = new System.Windows.Forms.Padding(5);
            this.pBarCode.Name = "pBarCode";
            this.pBarCode.RowCount = 2;
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pBarCode.Size = new System.Drawing.Size(175, 70);
            this.pBarCode.TabIndex = 2;
            // 
            // cbBarcodes
            // 
            this.cbBarcodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBarcodes.DropDownHeight = 200;
            this.cbBarcodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbBarcodes.FormattingEnabled = true;
            this.cbBarcodes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbBarcodes.IntegralHeight = false;
            this.cbBarcodes.ItemHeight = 20;
            this.cbBarcodes.Location = new System.Drawing.Point(6, 37);
            this.cbBarcodes.Margin = new System.Windows.Forms.Padding(5);
            this.cbBarcodes.Name = "cbBarcodes";
            this.cbBarcodes.Size = new System.Drawing.Size(163, 28);
            this.cbBarcodes.TabIndex = 1;
            this.cbBarcodes.SelectedIndexChanged += new System.EventHandler(this.cbBarcodes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kod kreskowy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pProductName
            // 
            this.pProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductName.ColumnCount = 1;
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pProductName.Controls.Add(this.cbProducts, 0, 1);
            this.pProductName.Controls.Add(this.lProductName, 0, 0);
            this.pProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pProductName.Location = new System.Drawing.Point(230, 36);
            this.pProductName.Margin = new System.Windows.Forms.Padding(0);
            this.pProductName.Name = "pProductName";
            this.pProductName.RowCount = 2;
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pProductName.Size = new System.Drawing.Size(450, 70);
            this.pProductName.TabIndex = 4;
            // 
            // cbProducts
            // 
            this.cbProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbProducts.ContextMenuStrip = this.contextMenuStrip1;
            this.cbProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbProducts.IntegralHeight = false;
            this.cbProducts.Items.AddRange(new object[] {
            "Test",
            "Test2"});
            this.cbProducts.Location = new System.Drawing.Point(6, 37);
            this.cbProducts.Margin = new System.Windows.Forms.Padding(5);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(438, 28);
            this.cbProducts.TabIndex = 1;
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            this.cbProducts.Leave += new System.EventHandler(this.cbProducts_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            this.lProductName.Size = new System.Drawing.Size(438, 20);
            this.lProductName.TabIndex = 0;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.pManufacturer.Controls.Add(this.cbManufacturers, 0, 1);
            this.pManufacturer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pManufacturer.Location = new System.Drawing.Point(5, 36);
            this.pManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.pManufacturer.Name = "pManufacturer";
            this.pManufacturer.RowCount = 2;
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pManufacturer.Size = new System.Drawing.Size(220, 70);
            this.pManufacturer.TabIndex = 0;
            // 
            // lManufacturer
            // 
            this.lManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(6, 6);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(208, 20);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Producent";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbManufacturers
            // 
            this.cbManufacturers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbManufacturers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturers.FormattingEnabled = true;
            this.cbManufacturers.IntegralHeight = false;
            this.cbManufacturers.Items.AddRange(new object[] {
            "Wszyscy"});
            this.cbManufacturers.Location = new System.Drawing.Point(6, 37);
            this.cbManufacturers.Margin = new System.Windows.Forms.Padding(5);
            this.cbManufacturers.Name = "cbManufacturers";
            this.cbManufacturers.Size = new System.Drawing.Size(208, 28);
            this.cbManufacturers.TabIndex = 1;
            this.cbManufacturers.SelectedIndexChanged += new System.EventHandler(this.cbManufacturers_SelectedIndexChanged);
            // 
            // tpLoadingBar
            // 
            this.tpLoadingBar.ColumnCount = 2;
            this.tpLoadingBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpLoadingBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpLoadingBar.Controls.Add(this.pbLoadingBar, 1, 0);
            this.tpLoadingBar.Controls.Add(this.lLoadingBar, 0, 0);
            this.tpLoadingBar.Location = new System.Drawing.Point(318, 2);
            this.tpLoadingBar.Margin = new System.Windows.Forms.Padding(2);
            this.tpLoadingBar.Name = "tpLoadingBar";
            this.tpLoadingBar.RowCount = 1;
            this.tpLoadingBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpLoadingBar.Size = new System.Drawing.Size(344, 30);
            this.tpLoadingBar.TabIndex = 10;
            // 
            // pbLoadingBar
            // 
            this.pbLoadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.pbLoadingBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoadingBar.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadingBar.Image")));
            this.pbLoadingBar.Location = new System.Drawing.Point(314, 0);
            this.pbLoadingBar.Margin = new System.Windows.Forms.Padding(0);
            this.pbLoadingBar.Name = "pbLoadingBar";
            this.pbLoadingBar.Size = new System.Drawing.Size(30, 30);
            this.pbLoadingBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingBar.TabIndex = 3;
            this.pbLoadingBar.TabStop = false;
            // 
            // lLoadingBar
            // 
            this.lLoadingBar.AutoSize = true;
            this.lLoadingBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLoadingBar.Location = new System.Drawing.Point(3, 0);
            this.lLoadingBar.Name = "lLoadingBar";
            this.lLoadingBar.Size = new System.Drawing.Size(308, 30);
            this.lLoadingBar.TabIndex = 4;
            this.lLoadingBar.Text = "Pobieranie informacji z bazy danych";
            this.lLoadingBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bGenericButton
            // 
            this.bGenericButton.Image = ((System.Drawing.Image)(resources.GetObject("bGenericButton.Image")));
            this.bGenericButton.Location = new System.Drawing.Point(864, 36);
            this.bGenericButton.Margin = new System.Windows.Forms.Padding(5);
            this.bGenericButton.Name = "bGenericButton";
            this.bGenericButton.Size = new System.Drawing.Size(51, 70);
            this.bGenericButton.TabIndex = 11;
            this.bGenericButton.UseVisualStyleBackColor = true;
            // 
            // SearchBarTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.gbProductSelection);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(920, 106);
            this.Name = "SearchBarTemplate";
            this.Size = new System.Drawing.Size(920, 106);
            this.Load += new System.EventHandler(this.SearchBarTemplate_Load);
            this.gbProductSelection.ResumeLayout(false);
            this.gbProductSelection.PerformLayout();
            this.pBarCode.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.tpLoadingBar.ResumeLayout(false);
            this.tpLoadingBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pBarCode;
        private System.Windows.Forms.ComboBox cbBarcodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel pProductName;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.ComboBox cbManufacturers;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tpLoadingBar;
        private System.Windows.Forms.PictureBox pbLoadingBar;
        private System.Windows.Forms.Label lLoadingBar;
        private System.Windows.Forms.Button bGenericButton;
    }
}
