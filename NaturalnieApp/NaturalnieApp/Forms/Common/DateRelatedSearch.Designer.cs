
namespace NaturalnieApp.Forms.Common
{
    partial class DateRelatedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRelatedSearch));
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.bGenericButton = new System.Windows.Forms.Button();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.tpLoadingBar = new System.Windows.Forms.TableLayoutPanel();
            this.pbLoadingBar = new System.Windows.Forms.PictureBox();
            this.lLoadingBar = new System.Windows.Forms.Label();
            this.pEndDate = new System.Windows.Forms.TableLayoutPanel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lEndDate = new System.Windows.Forms.Label();
            this.pStartDate = new System.Windows.Forms.TableLayoutPanel();
            this.lStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.cbManufacturers = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbProductSelection.SuspendLayout();
            this.tpLoadingBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar)).BeginInit();
            this.pEndDate.SuspendLayout();
            this.pStartDate.SuspendLayout();
            this.pManufacturer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProductSelection
            // 
            this.gbProductSelection.Controls.Add(this.bGenericButton);
            this.gbProductSelection.Controls.Add(this.tbDummyForCtrl);
            this.gbProductSelection.Controls.Add(this.tpLoadingBar);
            this.gbProductSelection.Controls.Add(this.pEndDate);
            this.gbProductSelection.Controls.Add(this.pStartDate);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 0);
            this.gbProductSelection.Margin = new System.Windows.Forms.Padding(5);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(920, 106);
            this.gbProductSelection.TabIndex = 2;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór daty";
            // 
            // bGenericButton
            // 
            this.bGenericButton.Image = ((System.Drawing.Image)(resources.GetObject("bGenericButton.Image")));
            this.bGenericButton.Location = new System.Drawing.Point(861, 36);
            this.bGenericButton.Margin = new System.Windows.Forms.Padding(5);
            this.bGenericButton.Name = "bGenericButton";
            this.bGenericButton.Size = new System.Drawing.Size(51, 70);
            this.bGenericButton.TabIndex = 12;
            this.bGenericButton.UseVisualStyleBackColor = true;
            this.bGenericButton.Click += new System.EventHandler(this.bGenericButton_Click);
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Location = new System.Drawing.Point(895, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(25, 26);
            this.tbDummyForCtrl.TabIndex = 11;
            this.tbDummyForCtrl.Visible = false;
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
            // pEndDate
            // 
            this.pEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pEndDate.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pEndDate.ColumnCount = 1;
            this.pEndDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pEndDate.Controls.Add(this.dtpEndDate, 0, 1);
            this.pEndDate.Controls.Add(this.lEndDate, 0, 0);
            this.pEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pEndDate.Location = new System.Drawing.Point(535, 36);
            this.pEndDate.Margin = new System.Windows.Forms.Padding(5);
            this.pEndDate.Name = "pEndDate";
            this.pEndDate.RowCount = 2;
            this.pEndDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pEndDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pEndDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pEndDate.Size = new System.Drawing.Size(300, 70);
            this.pEndDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyy HH:mm:ss";
            this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(7, 38);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpEndDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(286, 26);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lEndDate
            // 
            this.lEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lEndDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lEndDate.Location = new System.Drawing.Point(6, 6);
            this.lEndDate.Margin = new System.Windows.Forms.Padding(5);
            this.lEndDate.Name = "lEndDate";
            this.lEndDate.Size = new System.Drawing.Size(288, 20);
            this.lEndDate.TabIndex = 0;
            this.lEndDate.Text = "Data końcowa";
            this.lEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pStartDate
            // 
            this.pStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pStartDate.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pStartDate.ColumnCount = 1;
            this.pStartDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pStartDate.Controls.Add(this.lStartDate, 0, 0);
            this.pStartDate.Controls.Add(this.dtpStartDate, 0, 1);
            this.pStartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pStartDate.Location = new System.Drawing.Point(230, 36);
            this.pStartDate.Margin = new System.Windows.Forms.Padding(0);
            this.pStartDate.Name = "pStartDate";
            this.pStartDate.RowCount = 2;
            this.pStartDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pStartDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pStartDate.Size = new System.Drawing.Size(300, 70);
            this.pStartDate.TabIndex = 4;
            // 
            // lStartDate
            // 
            this.lStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.lStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lStartDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lStartDate.Location = new System.Drawing.Point(6, 6);
            this.lStartDate.Margin = new System.Windows.Forms.Padding(5);
            this.lStartDate.Name = "lStartDate";
            this.lStartDate.Size = new System.Drawing.Size(288, 20);
            this.lStartDate.TabIndex = 0;
            this.lStartDate.Text = "Data początkowa";
            this.lStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyy HH:mm:ss";
            this.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(7, 38);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpStartDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(286, 26);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
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
            this.pManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.cbManufacturers.TextChanged += new System.EventHandler(this.cbManufacturers_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DateRelatedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.gbProductSelection);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(920, 106);
            this.Name = "DateRelatedSearch";
            this.Size = new System.Drawing.Size(920, 106);
            this.Load += new System.EventHandler(this.SearchBarTemplate_Load);
            this.gbProductSelection.ResumeLayout(false);
            this.gbProductSelection.PerformLayout();
            this.tpLoadingBar.ResumeLayout(false);
            this.tpLoadingBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar)).EndInit();
            this.pEndDate.ResumeLayout(false);
            this.pStartDate.ResumeLayout(false);
            this.pManufacturer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProductSelection;
        private System.Windows.Forms.TableLayoutPanel pEndDate;
        private System.Windows.Forms.Label lEndDate;
        private System.Windows.Forms.TableLayoutPanel pStartDate;
        private System.Windows.Forms.Label lStartDate;
        private System.Windows.Forms.TableLayoutPanel pManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.ComboBox cbManufacturers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tpLoadingBar;
        private System.Windows.Forms.PictureBox pbLoadingBar;
        private System.Windows.Forms.Label lLoadingBar;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Button bGenericButton;
    }
}
