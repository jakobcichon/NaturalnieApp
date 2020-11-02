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
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lBarCode = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lPrice = new System.Windows.Forms.Label();
            this.lQuantity = new System.Windows.Forms.Label();
            this.lProductName = new System.Windows.Forms.Label();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.lTax = new System.Windows.Forms.Label();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tbManufacturer = new System.Windows.Forms.TextBox();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.cbTax = new System.Windows.Forms.ComboBox();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.pHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lBarCode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPrice, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbQuantity, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbProductName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lPrice, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lQuantity, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lProductName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lManufacturer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lTax, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lMarigin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbManufacturer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMarigin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbTax, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbBarCode, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 136);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lBarCode
            // 
            this.lBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarCode.Location = new System.Drawing.Point(501, 66);
            this.lBarCode.Margin = new System.Windows.Forms.Padding(3);
            this.lBarCode.Name = "lBarCode";
            this.lBarCode.Size = new System.Drawing.Size(244, 24);
            this.lBarCode.TabIndex = 12;
            this.lBarCode.Text = "Kod kreskowy (ENA)";
            this.lBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrice.Location = new System.Drawing.Point(752, 35);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(244, 26);
            this.tbPrice.TabIndex = 9;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantity.Location = new System.Drawing.Point(501, 35);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(244, 26);
            this.tbQuantity.TabIndex = 8;
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbProductName.Location = new System.Drawing.Point(250, 35);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(244, 26);
            this.tbProductName.TabIndex = 7;
            // 
            // lPrice
            // 
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrice.Location = new System.Drawing.Point(752, 4);
            this.lPrice.Margin = new System.Windows.Forms.Padding(3);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(244, 24);
            this.lPrice.TabIndex = 3;
            this.lPrice.Text = "Cena";
            this.lPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lQuantity
            // 
            this.lQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lQuantity.Location = new System.Drawing.Point(501, 4);
            this.lQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(244, 24);
            this.lQuantity.TabIndex = 2;
            this.lQuantity.Text = "Ilość";
            this.lQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lProductName
            // 
            this.lProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProductName.Location = new System.Drawing.Point(250, 4);
            this.lProductName.Margin = new System.Windows.Forms.Padding(3);
            this.lProductName.Name = "lProductName";
            this.lProductName.Size = new System.Drawing.Size(244, 24);
            this.lProductName.TabIndex = 1;
            this.lProductName.Text = "Nazwa produktu";
            this.lProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lManufacturer
            // 
            this.lManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(4, 4);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(3);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(239, 24);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Producent";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTax
            // 
            this.lTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTax.Location = new System.Drawing.Point(4, 66);
            this.lTax.Margin = new System.Windows.Forms.Padding(3);
            this.lTax.Name = "lTax";
            this.lTax.Size = new System.Drawing.Size(239, 24);
            this.lTax.TabIndex = 4;
            this.lTax.Text = "Stawka VAT";
            this.lTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lMarigin
            // 
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(250, 66);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(3);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(244, 24);
            this.lMarigin.TabIndex = 5;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbManufacturer
            // 
            this.tbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbManufacturer.Location = new System.Drawing.Point(4, 35);
            this.tbManufacturer.Name = "tbManufacturer";
            this.tbManufacturer.Size = new System.Drawing.Size(239, 26);
            this.tbManufacturer.TabIndex = 6;
            // 
            // tbMarigin
            // 
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(250, 97);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(239, 26);
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
            this.cbTax.Location = new System.Drawing.Point(4, 97);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(239, 28);
            this.cbTax.TabIndex = 11;
            // 
            // tbBarCode
            // 
            this.tbBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarCode.Location = new System.Drawing.Point(501, 97);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(239, 26);
            this.tbBarCode.TabIndex = 13;
            // 
            // AddNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewProduct";
            this.Text = "Submenu_ElzabInfo";
            this.pHeader.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.Label lQuantity;
        private System.Windows.Forms.Label lProductName;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lTax;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.ComboBox cbTax;
        private System.Windows.Forms.Label lBarCode;
        private System.Windows.Forms.TextBox tbBarCode;
    }
}