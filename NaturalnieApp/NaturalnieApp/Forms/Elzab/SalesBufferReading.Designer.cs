namespace NaturalnieApp.Forms
{
    partial class SalesBufferReading
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
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bReadingSaleBufforFromFile = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.gbSynchronization = new System.Windows.Forms.GroupBox();
            this.progressBarTemplate1 = new NaturalnieApp.Forms.Common.ProgressBarTemplate();
            this.tpProductNameToEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.bReadingSaleBufforFromCashRegister = new System.Windows.Forms.Button();
            this.tcDataFromFile = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pButtonsPanel.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.gbSynchronization.SuspendLayout();
            this.tpProductNameToEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bReadingSaleBufforFromFile);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 6;
            // 
            // bReadingSaleBufforFromFile
            // 
            this.bReadingSaleBufforFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bReadingSaleBufforFromFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bReadingSaleBufforFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bReadingSaleBufforFromFile.Location = new System.Drawing.Point(11, 7);
            this.bReadingSaleBufforFromFile.Margin = new System.Windows.Forms.Padding(5);
            this.bReadingSaleBufforFromFile.Name = "bReadingSaleBufforFromFile";
            this.bReadingSaleBufforFromFile.Size = new System.Drawing.Size(261, 50);
            this.bReadingSaleBufforFromFile.TabIndex = 29;
            this.bReadingSaleBufforFromFile.Text = "Odczyt danych o sprzedaży z pliku";
            this.bReadingSaleBufforFromFile.UseVisualStyleBackColor = false;
            this.bReadingSaleBufforFromFile.Click += new System.EventHandler(this.bReadingSaleBufforFromFile_Click);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(920, 30);
            this.pHeader.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 7;
            // 
            // gbSynchronization
            // 
            this.gbSynchronization.Controls.Add(this.progressBarTemplate1);
            this.gbSynchronization.Controls.Add(this.tpProductNameToEdit);
            this.gbSynchronization.Controls.Add(this.bReadingSaleBufforFromCashRegister);
            this.gbSynchronization.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSynchronization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbSynchronization.ForeColor = System.Drawing.Color.Black;
            this.gbSynchronization.Location = new System.Drawing.Point(0, 30);
            this.gbSynchronization.Name = "gbSynchronization";
            this.gbSynchronization.Size = new System.Drawing.Size(920, 134);
            this.gbSynchronization.TabIndex = 8;
            this.gbSynchronization.TabStop = false;
            this.gbSynchronization.Text = "Synchronizacja z kasą";
            // 
            // progressBarTemplate1
            // 
            this.progressBarTemplate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.progressBarTemplate1.ForeColor = System.Drawing.Color.Black;
            this.progressBarTemplate1.Location = new System.Drawing.Point(12, 81);
            this.progressBarTemplate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarTemplate1.MinimumSize = new System.Drawing.Size(510, 46);
            this.progressBarTemplate1.Name = "progressBarTemplate1";
            this.progressBarTemplate1.Size = new System.Drawing.Size(898, 50);
            this.progressBarTemplate1.TabIndex = 29;
            // 
            // tpProductNameToEdit
            // 
            this.tpProductNameToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpProductNameToEdit.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpProductNameToEdit.ColumnCount = 2;
            this.tpProductNameToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tpProductNameToEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProductNameToEdit.Controls.Add(this.tbStatus, 0, 0);
            this.tpProductNameToEdit.Controls.Add(this.lStatus, 0, 0);
            this.tpProductNameToEdit.Location = new System.Drawing.Point(277, 27);
            this.tpProductNameToEdit.Name = "tpProductNameToEdit";
            this.tpProductNameToEdit.RowCount = 1;
            this.tpProductNameToEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpProductNameToEdit.Size = new System.Drawing.Size(633, 50);
            this.tpProductNameToEdit.TabIndex = 28;
            // 
            // tbStatus
            // 
            this.tbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbStatus.Location = new System.Drawing.Point(107, 6);
            this.tbStatus.Margin = new System.Windows.Forms.Padding(5);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(520, 38);
            this.tbStatus.TabIndex = 2;
            // 
            // lStatus
            // 
            this.lStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lStatus.Location = new System.Drawing.Point(6, 6);
            this.lStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(90, 38);
            this.lStatus.TabIndex = 1;
            this.lStatus.Text = "Status";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bReadingSaleBufforFromCashRegister
            // 
            this.bReadingSaleBufforFromCashRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bReadingSaleBufforFromCashRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bReadingSaleBufforFromCashRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bReadingSaleBufforFromCashRegister.Location = new System.Drawing.Point(12, 27);
            this.bReadingSaleBufforFromCashRegister.Margin = new System.Windows.Forms.Padding(5);
            this.bReadingSaleBufforFromCashRegister.Name = "bReadingSaleBufforFromCashRegister";
            this.bReadingSaleBufforFromCashRegister.Size = new System.Drawing.Size(261, 50);
            this.bReadingSaleBufforFromCashRegister.TabIndex = 27;
            this.bReadingSaleBufforFromCashRegister.Text = "Odczyt danych o sprzedaży z kasy fiskalnej";
            this.bReadingSaleBufforFromCashRegister.UseVisualStyleBackColor = false;
            this.bReadingSaleBufforFromCashRegister.Click += new System.EventHandler(this.bReadingSaleBufforFromCashRegister_Click);
            // 
            // tcDataFromFile
            // 
            this.tcDataFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDataFromFile.Location = new System.Drawing.Point(0, 164);
            this.tcDataFromFile.Name = "tcDataFromFile";
            this.tcDataFromFile.SelectedIndex = 0;
            this.tcDataFromFile.Size = new System.Drawing.Size(920, 456);
            this.tcDataFromFile.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SalesBufferReading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.tcDataFromFile);
            this.Controls.Add(this.gbSynchronization);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "SalesBufferReading";
            this.Size = new System.Drawing.Size(920, 690);
            this.pButtonsPanel.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbSynchronization.ResumeLayout(false);
            this.tpProductNameToEdit.ResumeLayout(false);
            this.tpProductNameToEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.GroupBox gbSynchronization;
        private System.Windows.Forms.Button bReadingSaleBufforFromCashRegister;
        private System.Windows.Forms.TableLayoutPanel tpProductNameToEdit;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.TabControl tcDataFromFile;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bReadingSaleBufforFromFile;
        private Common.ProgressBarTemplate progressBarTemplate1;
    }
}