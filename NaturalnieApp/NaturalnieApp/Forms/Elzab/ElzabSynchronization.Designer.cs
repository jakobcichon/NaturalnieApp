namespace NaturalnieApp.Forms
{
    partial class ElzabSynchronization
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
            this.components = new System.ComponentModel.Container();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bReadingFromSaleBuffor = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.gbSynchronization = new System.Windows.Forms.GroupBox();
            this.tpProgress = new System.Windows.Forms.TableLayoutPanel();
            this.lElapsedTime = new System.Windows.Forms.Label();
            this.tbElapsedTime = new System.Windows.Forms.TextBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.tpProductNameToEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.bReadingFromCashRegister = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.tProgressTime = new System.Windows.Forms.Timer(this.components);
            this.pButtonsPanel.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.gbSynchronization.SuspendLayout();
            this.tpProgress.SuspendLayout();
            this.tpProductNameToEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bReadingFromSaleBuffor);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 6;
            // 
            // bReadingFromSaleBuffor
            // 
            this.bReadingFromSaleBuffor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bReadingFromSaleBuffor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bReadingFromSaleBuffor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bReadingFromSaleBuffor.Location = new System.Drawing.Point(18, 7);
            this.bReadingFromSaleBuffor.Name = "bReadingFromSaleBuffor";
            this.bReadingFromSaleBuffor.Size = new System.Drawing.Size(155, 50);
            this.bReadingFromSaleBuffor.TabIndex = 27;
            this.bReadingFromSaleBuffor.Text = "Odczyt bufora sprzedaży";
            this.bReadingFromSaleBuffor.UseVisualStyleBackColor = false;
            this.bReadingFromSaleBuffor.Click += new System.EventHandler(this.bReadingFromSaleBuffor_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(809, 7);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 26;
            this.bSave.Text = "Zapisz do kasy";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(989, 10);
            this.bClose.Name = "bClose";
            this.bClose.Padding = new System.Windows.Forms.Padding(5);
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "Zamknij";
            this.bClose.UseMnemonic = false;
            this.bClose.UseVisualStyleBackColor = false;
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
            this.gbSynchronization.Controls.Add(this.tpProgress);
            this.gbSynchronization.Controls.Add(this.tpProductNameToEdit);
            this.gbSynchronization.Controls.Add(this.bReadingFromCashRegister);
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
            // tpProgress
            // 
            this.tpProgress.ColumnCount = 3;
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProgress.Controls.Add(this.lElapsedTime, 0, 0);
            this.tpProgress.Controls.Add(this.tbElapsedTime, 1, 0);
            this.tpProgress.Controls.Add(this.pbProgress, 2, 0);
            this.tpProgress.Location = new System.Drawing.Point(12, 85);
            this.tpProgress.Name = "tpProgress";
            this.tpProgress.RowCount = 1;
            this.tpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpProgress.Size = new System.Drawing.Size(898, 30);
            this.tpProgress.TabIndex = 29;
            // 
            // lElapsedTime
            // 
            this.lElapsedTime.AutoSize = true;
            this.lElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lElapsedTime.Location = new System.Drawing.Point(3, 0);
            this.lElapsedTime.Name = "lElapsedTime";
            this.lElapsedTime.Size = new System.Drawing.Size(159, 30);
            this.lElapsedTime.TabIndex = 0;
            this.lElapsedTime.Text = "Czas trwania";
            this.lElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbElapsedTime
            // 
            this.tbElapsedTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.tbElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElapsedTime.Location = new System.Drawing.Point(168, 5);
            this.tbElapsedTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbElapsedTime.Name = "tbElapsedTime";
            this.tbElapsedTime.Size = new System.Drawing.Size(94, 19);
            this.tbElapsedTime.TabIndex = 1;
            this.tbElapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProgress.Location = new System.Drawing.Point(268, 3);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(627, 24);
            this.pbProgress.TabIndex = 2;
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
            // bReadingFromCashRegister
            // 
            this.bReadingFromCashRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bReadingFromCashRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bReadingFromCashRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bReadingFromCashRegister.Location = new System.Drawing.Point(12, 27);
            this.bReadingFromCashRegister.Margin = new System.Windows.Forms.Padding(5);
            this.bReadingFromCashRegister.Name = "bReadingFromCashRegister";
            this.bReadingFromCashRegister.Size = new System.Drawing.Size(261, 50);
            this.bReadingFromCashRegister.TabIndex = 27;
            this.bReadingFromCashRegister.Text = "Odczyt danych o produktach z kasy fiskalnej";
            this.bReadingFromCashRegister.UseVisualStyleBackColor = false;
            this.bReadingFromCashRegister.Click += new System.EventHandler(this.bReadingFromCashRegister_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 164);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(920, 456);
            this.advancedDataGridView1.TabIndex = 9;
            // 
            // tProgressTime
            // 
            this.tProgressTime.Interval = 1000;
            this.tProgressTime.Tick += new System.EventHandler(this.tProgressTime_Tick);
            // 
            // ElzabSynchronization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.gbSynchronization);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ElzabSynchronization";
            this.Size = new System.Drawing.Size(920, 690);
            this.pButtonsPanel.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbSynchronization.ResumeLayout(false);
            this.tpProgress.ResumeLayout(false);
            this.tpProgress.PerformLayout();
            this.tpProductNameToEdit.ResumeLayout(false);
            this.tpProductNameToEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.GroupBox gbSynchronization;
        private System.Windows.Forms.Button bReadingFromCashRegister;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tpProductNameToEdit;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label lStatus;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.TableLayoutPanel tpProgress;
        private System.Windows.Forms.Label lElapsedTime;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.TextBox tbElapsedTime;
        private System.Windows.Forms.Timer tProgressTime;
        private System.Windows.Forms.Button bReadingFromSaleBuffor;
    }
}