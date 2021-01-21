
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
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.pBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.cbBarcodes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pProductName = new System.Windows.Forms.TableLayoutPanel();
            this.cbProductList = new System.Windows.Forms.ComboBox();
            this.lProductName = new System.Windows.Forms.Label();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.gbProductSelection.SuspendLayout();
            this.pBarCode.SuspendLayout();
            this.pProductName.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProductSelection
            // 
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
            // pBarCode
            // 
            this.pBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pBarCode.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pBarCode.ColumnCount = 1;
            this.pBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pBarCode.Controls.Add(this.cbBarcodes, 0, 1);
            this.pBarCode.Controls.Add(this.label1, 0, 0);
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
            this.cbBarcodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBarcodes.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.cbBarcodes.Size = new System.Drawing.Size(165, 28);
            this.cbBarcodes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kod kreskowy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pProductName
            // 
            this.pProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pProductName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pProductName.ColumnCount = 1;
            this.pProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 633F));
            this.pProductName.Controls.Add(this.cbProductList, 0, 1);
            this.pProductName.Controls.Add(this.lProductName, 0, 0);
            this.pProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pProductName.Location = new System.Drawing.Point(270, 30);
            this.pProductName.Margin = new System.Windows.Forms.Padding(0);
            this.pProductName.Name = "pProductName";
            this.pProductName.RowCount = 2;
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pProductName.Size = new System.Drawing.Size(462, 70);
            this.pProductName.TabIndex = 1;
            // 
            // cbProductList
            // 
            this.cbProductList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProductList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbProductList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbProductList.FormattingEnabled = true;
            this.cbProductList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbProductList.IntegralHeight = false;
            this.cbProductList.Location = new System.Drawing.Point(6, 37);
            this.cbProductList.Margin = new System.Windows.Forms.Padding(5);
            this.cbProductList.Name = "cbProductList";
            this.cbProductList.Size = new System.Drawing.Size(450, 28);
            this.cbProductList.TabIndex = 1;
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
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 423F));
            this.pManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.pManufacturer.Controls.Add(this.cbManufacturer, 0, 1);
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
            // cbManufacturer
            // 
            this.cbManufacturer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.IntegralHeight = false;
            this.cbManufacturer.Items.AddRange(new object[] {
            "Wszyscy"});
            this.cbManufacturer.Location = new System.Drawing.Point(6, 37);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(240, 28);
            this.cbManufacturer.TabIndex = 1;
            // 
            // SearchBarTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.gbProductSelection);
            this.MinimumSize = new System.Drawing.Size(920, 106);
            this.Name = "SearchBarTemplate";
            this.Size = new System.Drawing.Size(920, 106);
            this.gbProductSelection.ResumeLayout(false);
            this.pBarCode.ResumeLayout(false);
            this.pProductName.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pBarCode;
        private System.Windows.Forms.ComboBox cbBarcodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel pProductName;
        private System.Windows.Forms.ComboBox cbProductList;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.ComboBox cbManufacturer;
    }
}
