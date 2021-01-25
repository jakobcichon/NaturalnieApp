using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class PrintFromStock
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
            this.tbNumberOfLabels = new System.Windows.Forms.TextBox();
            this.lNumberOfLabels = new System.Windows.Forms.Label();
            this.bPrint = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.gbProductSelection = new System.Windows.Forms.GroupBox();
            this.tpDateTo = new System.Windows.Forms.TableLayoutPanel();
            this.lDateTo = new System.Windows.Forms.Label();
            this.dpDateTo = new System.Windows.Forms.DateTimePicker();
            this.tpFromDate = new System.Windows.Forms.TableLayoutPanel();
            this.lFromDate = new System.Windows.Forms.Label();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chFromStockHistoryOnly = new System.Windows.Forms.CheckBox();
            this.bShow = new System.Windows.Forms.Button();
            this.pManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.cbManufacturers = new System.Windows.Forms.ComboBox();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            this.gbProductSelection.SuspendLayout();
            this.tpDateTo.SuspendLayout();
            this.tpFromDate.SuspendLayout();
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
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.AdvancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.AdvancedDataGridView1_FilterStringChanged);
            this.advancedDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellValueChanged);
            this.advancedDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.advancedDataGridView1_UserDeletedRow);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.Controls.Add(this.tbNumberOfLabels);
            this.pButtonsPanel.Controls.Add(this.lNumberOfLabels);
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // tbNumberOfLabels
            // 
            this.tbNumberOfLabels.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbNumberOfLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberOfLabels.Location = new System.Drawing.Point(281, 11);
            this.tbNumberOfLabels.Margin = new System.Windows.Forms.Padding(5);
            this.tbNumberOfLabels.Name = "tbNumberOfLabels";
            this.tbNumberOfLabels.ReadOnly = true;
            this.tbNumberOfLabels.Size = new System.Drawing.Size(64, 29);
            this.tbNumberOfLabels.TabIndex = 27;
            // 
            // lNumberOfLabels
            // 
            this.lNumberOfLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfLabels.Location = new System.Drawing.Point(105, 10);
            this.lNumberOfLabels.Margin = new System.Windows.Forms.Padding(5);
            this.lNumberOfLabels.Name = "lNumberOfLabels";
            this.lNumberOfLabels.Size = new System.Drawing.Size(197, 30);
            this.lNumberOfLabels.TabIndex = 28;
            this.lNumberOfLabels.Text = "Liczba etykiet do druku";
            this.lNumberOfLabels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(702, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 26;
            this.bPrint.Text = "Drukuj";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
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
            this.gbProductSelection.Controls.Add(this.tpDateTo);
            this.gbProductSelection.Controls.Add(this.tpFromDate);
            this.gbProductSelection.Controls.Add(this.chFromStockHistoryOnly);
            this.gbProductSelection.Controls.Add(this.bShow);
            this.gbProductSelection.Controls.Add(this.pManufacturer);
            this.gbProductSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProductSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProductSelection.Location = new System.Drawing.Point(0, 30);
            this.gbProductSelection.Name = "gbProductSelection";
            this.gbProductSelection.Size = new System.Drawing.Size(920, 120);
            this.gbProductSelection.TabIndex = 17;
            this.gbProductSelection.TabStop = false;
            this.gbProductSelection.Text = "Wybór produktu";
            // 
            // tpDateTo
            // 
            this.tpDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpDateTo.ColumnCount = 2;
            this.tpDateTo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tpDateTo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpDateTo.Controls.Add(this.lDateTo, 0, 0);
            this.tpDateTo.Controls.Add(this.dpDateTo, 1, 0);
            this.tpDateTo.Location = new System.Drawing.Point(552, 70);
            this.tpDateTo.Name = "tpDateTo";
            this.tpDateTo.RowCount = 1;
            this.tpDateTo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpDateTo.Size = new System.Drawing.Size(300, 30);
            this.tpDateTo.TabIndex = 19;
            this.tpDateTo.Visible = false;
            // 
            // lDateTo
            // 
            this.lDateTo.AutoSize = true;
            this.lDateTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDateTo.Location = new System.Drawing.Point(3, 0);
            this.lDateTo.Name = "lDateTo";
            this.lDateTo.Size = new System.Drawing.Size(94, 30);
            this.lDateTo.TabIndex = 0;
            this.lDateTo.Text = "Pokaż do";
            this.lDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpDateTo
            // 
            this.dpDateTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateTo.Location = new System.Drawing.Point(103, 3);
            this.dpDateTo.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Size = new System.Drawing.Size(194, 26);
            this.dpDateTo.TabIndex = 16;
            // 
            // tpFromDate
            // 
            this.tpFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpFromDate.ColumnCount = 2;
            this.tpFromDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tpFromDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpFromDate.Controls.Add(this.lFromDate, 0, 0);
            this.tpFromDate.Controls.Add(this.dpFromDate, 1, 0);
            this.tpFromDate.Location = new System.Drawing.Point(552, 25);
            this.tpFromDate.Name = "tpFromDate";
            this.tpFromDate.RowCount = 1;
            this.tpFromDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpFromDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpFromDate.Size = new System.Drawing.Size(300, 30);
            this.tpFromDate.TabIndex = 18;
            this.tpFromDate.Visible = false;
            // 
            // lFromDate
            // 
            this.lFromDate.AutoSize = true;
            this.lFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFromDate.Location = new System.Drawing.Point(3, 0);
            this.lFromDate.Name = "lFromDate";
            this.lFromDate.Size = new System.Drawing.Size(94, 30);
            this.lFromDate.TabIndex = 0;
            this.lFromDate.Text = "Pokaż od";
            this.lFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpFromDate
            // 
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(103, 3);
            this.dpFromDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(194, 26);
            this.dpFromDate.TabIndex = 16;
            // 
            // chFromStockHistoryOnly
            // 
            this.chFromStockHistoryOnly.AutoSize = true;
            this.chFromStockHistoryOnly.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chFromStockHistoryOnly.Location = new System.Drawing.Point(358, 47);
            this.chFromStockHistoryOnly.Name = "chFromStockHistoryOnly";
            this.chFromStockHistoryOnly.Size = new System.Drawing.Size(176, 38);
            this.chFromStockHistoryOnly.TabIndex = 17;
            this.chFromStockHistoryOnly.Text = "Pokaż ostatnio dodane";
            this.chFromStockHistoryOnly.UseVisualStyleBackColor = true;
            this.chFromStockHistoryOnly.CheckedChanged += new System.EventHandler(this.chFromStockHistoryOnly_CheckedChanged);
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
            // pManufacturer
            // 
            this.pManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(199)))), ((int)(((byte)(102)))));
            this.pManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturer.ColumnCount = 1;
            this.pManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
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
            // PrintFromStock
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
            this.Name = "PrintFromStock";
            this.Text = "PrintBarcode";
            this.Load += new System.EventHandler(this.AddToStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddToStock_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            this.pButtonsPanel.PerformLayout();
            this.gbProductSelection.ResumeLayout(false);
            this.gbProductSelection.PerformLayout();
            this.tpDateTo.ResumeLayout(false);
            this.tpDateTo.PerformLayout();
            this.tpFromDate.ResumeLayout(false);
            this.tpFromDate.PerformLayout();
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
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TextBox tbNumberOfLabels;
        private System.Windows.Forms.Label lNumberOfLabels;
        private System.Windows.Forms.Button bShow;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.CheckBox chFromStockHistoryOnly;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.TableLayoutPanel tpFromDate;
        private System.Windows.Forms.Label lFromDate;
        private System.Windows.Forms.TableLayoutPanel tpDateTo;
        private System.Windows.Forms.Label lDateTo;
        private System.Windows.Forms.DateTimePicker dpDateTo;
    }
}