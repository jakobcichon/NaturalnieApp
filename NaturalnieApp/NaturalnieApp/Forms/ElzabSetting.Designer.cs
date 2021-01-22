using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class ElzabSettings
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
            this.pSettingNr1 = new System.Windows.Forms.Panel();
            this.tbElzabPath = new System.Windows.Forms.RichTextBox();
            this.bBrowsePath = new System.Windows.Forms.Button();
            this.lElzabPath = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.cBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bDefaults = new System.Windows.Forms.Button();
            this.bTest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbDatabaseName = new System.Windows.Forms.RichTextBox();
            this.lDatabaseName = new System.Windows.Forms.Label();
            this.gpConnectionSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tpPortNumber = new System.Windows.Forms.TableLayoutPanel();
            this.lCOMPortNr = new System.Windows.Forms.Label();
            this.cCOMPorts = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.pSearchBar = new System.Windows.Forms.Panel();
            this.pSettingNr1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gpConnectionSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpPortNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSettingNr1
            // 
            this.pSettingNr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.pSettingNr1.Controls.Add(this.tbElzabPath);
            this.pSettingNr1.Controls.Add(this.bBrowsePath);
            this.pSettingNr1.Controls.Add(this.lElzabPath);
            this.pSettingNr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSettingNr1.Location = new System.Drawing.Point(0, 30);
            this.pSettingNr1.Name = "pSettingNr1";
            this.pSettingNr1.Size = new System.Drawing.Size(920, 40);
            this.pSettingNr1.TabIndex = 0;
            // 
            // tbElzabPath
            // 
            this.tbElzabPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbElzabPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabPath.Location = new System.Drawing.Point(300, 0);
            this.tbElzabPath.Multiline = false;
            this.tbElzabPath.Name = "tbElzabPath";
            this.tbElzabPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbElzabPath.ShowSelectionMargin = true;
            this.tbElzabPath.Size = new System.Drawing.Size(582, 40);
            this.tbElzabPath.TabIndex = 8;
            this.tbElzabPath.Text = "";
            this.tbElzabPath.TextChanged += new System.EventHandler(this.tbElzabPath_TextChanged);
            this.tbElzabPath.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabPath_Validating);
            // 
            // bBrowsePath
            // 
            this.bBrowsePath.BackColor = System.Drawing.Color.White;
            this.bBrowsePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.bBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowsePath.Location = new System.Drawing.Point(880, 0);
            this.bBrowsePath.Name = "bBrowsePath";
            this.bBrowsePath.Size = new System.Drawing.Size(40, 40);
            this.bBrowsePath.TabIndex = 2;
            this.bBrowsePath.Text = "...";
            this.bBrowsePath.UseVisualStyleBackColor = false;
            this.bBrowsePath.Click += new System.EventHandler(this.bBrowsePath_Click);
            // 
            // lElzabPath
            // 
            this.lElzabPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lElzabPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lElzabPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lElzabPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElzabPath.Location = new System.Drawing.Point(0, 0);
            this.lElzabPath.Name = "lElzabPath";
            this.lElzabPath.Size = new System.Drawing.Size(300, 40);
            this.lElzabPath.TabIndex = 0;
            this.lElzabPath.Text = "Ścieżka do plików Elzab";
            this.lElzabPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pHeader
            // 
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
            this.bSave.Location = new System.Drawing.Point(777, 508);
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
            this.bUpdate.Location = new System.Drawing.Point(559, 508);
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
            "9600",
            "19200",
            "57600",
            "115200"});
            this.cBaudRate.Location = new System.Drawing.Point(217, 6);
            this.cBaudRate.Name = "cBaudRate";
            this.cBaudRate.Size = new System.Drawing.Size(227, 28);
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
            this.bDefaults.Location = new System.Drawing.Point(12, 508);
            this.bDefaults.Name = "bDefaults";
            this.bDefaults.Size = new System.Drawing.Size(100, 50);
            this.bDefaults.TabIndex = 8;
            this.bDefaults.Text = "Ustawienia domyślne";
            this.bDefaults.UseVisualStyleBackColor = false;
            this.bDefaults.Click += new System.EventHandler(this.bDefaults_Click);
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(0, 0);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(75, 23);
            this.bTest.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.rtbDatabaseName);
            this.panel2.Controls.Add(this.lDatabaseName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 40);
            this.panel2.TabIndex = 11;
            // 
            // rtbDatabaseName
            // 
            this.rtbDatabaseName.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbDatabaseName.Location = new System.Drawing.Point(300, 0);
            this.rtbDatabaseName.Multiline = false;
            this.rtbDatabaseName.Name = "rtbDatabaseName";
            this.rtbDatabaseName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDatabaseName.ShowSelectionMargin = true;
            this.rtbDatabaseName.Size = new System.Drawing.Size(281, 40);
            this.rtbDatabaseName.TabIndex = 8;
            this.rtbDatabaseName.Text = "";
            this.rtbDatabaseName.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDatabaseName_Validating);
            // 
            // lDatabaseName
            // 
            this.lDatabaseName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lDatabaseName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lDatabaseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDatabaseName.Location = new System.Drawing.Point(0, 0);
            this.lDatabaseName.Name = "lDatabaseName";
            this.lDatabaseName.Size = new System.Drawing.Size(300, 40);
            this.lDatabaseName.TabIndex = 0;
            this.lDatabaseName.Text = "Nazwa bazy danych";
            this.lDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gpConnectionSettings
            // 
            this.gpConnectionSettings.Controls.Add(this.tableLayoutPanel1);
            this.gpConnectionSettings.Controls.Add(this.tpPortNumber);
            this.gpConnectionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gpConnectionSettings.Location = new System.Drawing.Point(4, 113);
            this.gpConnectionSettings.Name = "gpConnectionSettings";
            this.gpConnectionSettings.Size = new System.Drawing.Size(479, 146);
            this.gpConnectionSettings.TabIndex = 13;
            this.gpConnectionSettings.TabStop = false;
            this.gpConnectionSettings.Text = "Ustawienie połączenia";
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
            this.cCOMPorts.TabIndex = 9;
            this.cCOMPorts.Validating += new System.ComponentModel.CancelEventHandler(this.cCOMPorts_Validating);
            // 
            // bApply
            // 
            this.bApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bApply.Location = new System.Drawing.Point(665, 508);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(100, 50);
            this.bApply.TabIndex = 14;
            this.bApply.Text = "Zastosuj";
            this.bApply.UseVisualStyleBackColor = false;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // pSearchBar
            // 
            this.pSearchBar.Location = new System.Drawing.Point(0, 291);
            this.pSearchBar.Name = "pSearchBar";
            this.pSearchBar.Size = new System.Drawing.Size(917, 120);
            this.pSearchBar.TabIndex = 15;
            // 
            // ElzabSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pSearchBar);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.gpConnectionSettings);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bTest);
            this.Controls.Add(this.bDefaults);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pSettingNr1);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ElzabSettings";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.ElzabSettings_Load);
            this.pSettingNr1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gpConnectionSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpPortNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSettingNr1;
        private System.Windows.Forms.Label lElzabPath;
        private System.Windows.Forms.Button bBrowsePath;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.ComboBox cBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbElzabPath;
        private System.Windows.Forms.Button bDefaults;
        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtbDatabaseName;
        private System.Windows.Forms.Label lDatabaseName;
        private System.Windows.Forms.GroupBox gpConnectionSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tpPortNumber;
        private System.Windows.Forms.Label lCOMPortNr;
        private System.Windows.Forms.ComboBox cCOMPorts;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Panel pSearchBar;
    }
}