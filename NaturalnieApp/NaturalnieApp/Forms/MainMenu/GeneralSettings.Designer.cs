using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class GeneralSettings
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

        //Method used to update config data from config file
        public void UpdateConfigData(ConfigFileObject obj)
        {
            string[] elementsList = obj.ListAllVariables();
            this.cCOMPorts.Items.Clear();

            foreach (string element in elementsList)
            {
                this.cCOMPorts.Items.Add(element);
            }

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pHeader = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.cBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bDefaults = new System.Windows.Forms.Button();
            this.rtbDatabaseName = new System.Windows.Forms.RichTextBox();
            this.gpConnectionSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bBrowsePath = new System.Windows.Forms.Button();
            this.tbElzabPath = new System.Windows.Forms.RichTextBox();
            this.lELzabCommandPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tpPortNumber = new System.Windows.Forms.TableLayoutPanel();
            this.lCOMPortNr = new System.Windows.Forms.Label();
            this.cCOMPorts = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lDatabaseName = new System.Windows.Forms.Label();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.pHeader.SuspendLayout();
            this.gpConnectionSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpPortNumber.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(920, 30);
            this.pHeader.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(806, 8);
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
            this.bUpdate.Location = new System.Drawing.Point(590, 8);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // cBaudRate
            // 
            this.cBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cBaudRate.FormattingEnabled = true;
            this.cBaudRate.Items.AddRange(new object[] {
            "115200",
            "19200",
            "57600",
            "9600"});
            this.cBaudRate.Location = new System.Drawing.Point(217, 6);
            this.cBaudRate.Name = "cBaudRate";
            this.cBaudRate.Size = new System.Drawing.Size(227, 28);
            this.cBaudRate.Sorted = true;
            this.cBaudRate.TabIndex = 9;
            this.cBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cBaudRate_Validating);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Prędkość transmisji";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bDefaults
            // 
            this.bDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bDefaults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bDefaults.Location = new System.Drawing.Point(10, 8);
            this.bDefaults.Margin = new System.Windows.Forms.Padding(5);
            this.bDefaults.Name = "bDefaults";
            this.bDefaults.Size = new System.Drawing.Size(100, 50);
            this.bDefaults.TabIndex = 8;
            this.bDefaults.Text = "Ustawienia domyślne";
            this.bDefaults.UseVisualStyleBackColor = false;
            this.bDefaults.Click += new System.EventHandler(this.bDefaults_Click);
            // 
            // rtbDatabaseName
            // 
            this.rtbDatabaseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbDatabaseName.Location = new System.Drawing.Point(217, 6);
            this.rtbDatabaseName.Multiline = false;
            this.rtbDatabaseName.Name = "rtbDatabaseName";
            this.rtbDatabaseName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDatabaseName.ShowSelectionMargin = true;
            this.rtbDatabaseName.Size = new System.Drawing.Size(227, 28);
            this.rtbDatabaseName.TabIndex = 8;
            this.rtbDatabaseName.Text = "";
            this.rtbDatabaseName.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDatabaseName_Validating);
            // 
            // gpConnectionSettings
            // 
            this.gpConnectionSettings.Controls.Add(this.tableLayoutPanel2);
            this.gpConnectionSettings.Controls.Add(this.tableLayoutPanel1);
            this.gpConnectionSettings.Controls.Add(this.tpPortNumber);
            this.gpConnectionSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpConnectionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gpConnectionSettings.Location = new System.Drawing.Point(0, 30);
            this.gpConnectionSettings.Name = "gpConnectionSettings";
            this.gpConnectionSettings.Size = new System.Drawing.Size(920, 146);
            this.gpConnectionSettings.TabIndex = 13;
            this.gpConnectionSettings.TabStop = false;
            this.gpConnectionSettings.Text = "Ustawienie połączenia";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.bBrowsePath, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbElzabPath, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lELzabCommandPath, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(464, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 40);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // bBrowsePath
            // 
            this.bBrowsePath.BackColor = System.Drawing.Color.White;
            this.bBrowsePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowsePath.Location = new System.Drawing.Point(418, 6);
            this.bBrowsePath.Name = "bBrowsePath";
            this.bBrowsePath.Size = new System.Drawing.Size(30, 30);
            this.bBrowsePath.TabIndex = 3;
            this.bBrowsePath.Text = "...";
            this.bBrowsePath.UseVisualStyleBackColor = false;
            // 
            // tbElzabPath
            // 
            this.tbElzabPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElzabPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabPath.Location = new System.Drawing.Point(177, 6);
            this.tbElzabPath.Name = "tbElzabPath";
            this.tbElzabPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbElzabPath.Size = new System.Drawing.Size(234, 30);
            this.tbElzabPath.TabIndex = 18;
            this.tbElzabPath.Text = "";
            this.tbElzabPath.TextChanged += new System.EventHandler(this.tbElzabPath_TextChanged_1);
            // 
            // lELzabCommandPath
            // 
            this.lELzabCommandPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lELzabCommandPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lELzabCommandPath.Location = new System.Drawing.Point(8, 8);
            this.lELzabCommandPath.Margin = new System.Windows.Forms.Padding(5);
            this.lELzabCommandPath.Name = "lELzabCommandPath";
            this.lELzabCommandPath.Size = new System.Drawing.Size(160, 26);
            this.lELzabCommandPath.TabIndex = 0;
            this.lELzabCommandPath.Text = "Ścieżka plików Elzab";
            this.lELzabCommandPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lELzabCommandPath.Click += new System.EventHandler(this.lELzabCommandPath_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cBaudRate, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 40);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tpPortNumber
            // 
            this.tpPortNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpPortNumber.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpPortNumber.ColumnCount = 2;
            this.tpPortNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpPortNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpPortNumber.Controls.Add(this.lCOMPortNr, 0, 0);
            this.tpPortNumber.Controls.Add(this.cCOMPorts, 1, 0);
            this.tpPortNumber.Location = new System.Drawing.Point(8, 35);
            this.tpPortNumber.Name = "tpPortNumber";
            this.tpPortNumber.Padding = new System.Windows.Forms.Padding(2);
            this.tpPortNumber.RowCount = 1;
            this.tpPortNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpPortNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tpPortNumber.Size = new System.Drawing.Size(450, 40);
            this.tpPortNumber.TabIndex = 19;
            // 
            // lCOMPortNr
            // 
            this.lCOMPortNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lCOMPortNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCOMPortNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lCOMPortNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCOMPortNr.Location = new System.Drawing.Point(6, 3);
            this.lCOMPortNr.Name = "lCOMPortNr";
            this.lCOMPortNr.Size = new System.Drawing.Size(204, 34);
            this.lCOMPortNr.TabIndex = 8;
            this.lCOMPortNr.Text = "Numer Portu COM";
            this.lCOMPortNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cCOMPorts
            // 
            this.cCOMPorts.DisplayMember = "Test";
            this.cCOMPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.cCOMPorts.FormattingEnabled = true;
            this.cCOMPorts.Location = new System.Drawing.Point(217, 6);
            this.cCOMPorts.Name = "cCOMPorts";
            this.cCOMPorts.Size = new System.Drawing.Size(227, 28);
            this.cCOMPorts.Sorted = true;
            this.cCOMPorts.TabIndex = 9;
            this.cCOMPorts.Validating += new System.ComponentModel.CancelEventHandler(this.cCOMPorts_Validating);
            // 
            // bApply
            // 
            this.bApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bApply.Location = new System.Drawing.Point(698, 8);
            this.bApply.Margin = new System.Windows.Forms.Padding(5);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(100, 50);
            this.bApply.TabIndex = 14;
            this.bApply.Text = "Zastosuj";
            this.bApply.UseVisualStyleBackColor = false;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bApply);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Controls.Add(this.bDefaults);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 15;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 80);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustawienia bazy danych";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lDatabaseName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbDatabaseName, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(450, 40);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // lDatabaseName
            // 
            this.lDatabaseName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lDatabaseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDatabaseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDatabaseName.Location = new System.Drawing.Point(6, 3);
            this.lDatabaseName.Name = "lDatabaseName";
            this.lDatabaseName.Size = new System.Drawing.Size(204, 34);
            this.lDatabaseName.TabIndex = 8;
            this.lDatabaseName.Text = "Nazwa bazy danych";
            this.lDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 22;
            this.tbDummyForCtrl.Visible = false;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.gpConnectionSettings);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "GeneralSettings";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.ElzabSettings_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gpConnectionSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpPortNumber.ResumeLayout(false);
            this.pButtonsPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.ComboBox cBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDefaults;
        private System.Windows.Forms.RichTextBox rtbDatabaseName;
        private System.Windows.Forms.GroupBox gpConnectionSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tpPortNumber;
        private System.Windows.Forms.Label lCOMPortNr;
        private System.Windows.Forms.ComboBox cCOMPorts;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.RichTextBox tbElzabPath;
        private System.Windows.Forms.Label lELzabCommandPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bBrowsePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lDatabaseName;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
    }
}