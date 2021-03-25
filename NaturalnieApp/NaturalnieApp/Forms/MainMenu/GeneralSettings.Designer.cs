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
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.cBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bDefaults = new System.Windows.Forms.Button();
            this.gpConnectionSettings = new System.Windows.Forms.GroupBox();
            this.tpElzabPath = new System.Windows.Forms.TableLayoutPanel();
            this.bElzabPath = new System.Windows.Forms.Button();
            this.tbElzabPath = new System.Windows.Forms.RichTextBox();
            this.lELzabCommandPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tpPortNumber = new System.Windows.Forms.TableLayoutPanel();
            this.lCOMPortNr = new System.Windows.Forms.Label();
            this.cCOMPorts = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.Button();
            this.gbPrinterSelection = new System.Windows.Forms.GroupBox();
            this.tpLabelPath = new System.Windows.Forms.TableLayoutPanel();
            this.bLabelPath = new System.Windows.Forms.Button();
            this.rtbLabelPath = new System.Windows.Forms.RichTextBox();
            this.lLabelPath = new System.Windows.Forms.Label();
            this.tpSelectedPrinterName = new System.Windows.Forms.TableLayoutPanel();
            this.lSelectedPrinterName = new System.Windows.Forms.Label();
            this.tbSelectedPrinterName = new System.Windows.Forms.TextBox();
            this.tpAvailablePrintersList = new System.Windows.Forms.TableLayoutPanel();
            this.lAvailablePrintersList = new System.Windows.Forms.Label();
            this.cbAvailablePrintersList = new System.Windows.Forms.ComboBox();
            this.gbDatabaseSettings = new System.Windows.Forms.GroupBox();
            this.tpDbBackupPath = new System.Windows.Forms.TableLayoutPanel();
            this.bDbBackupPath = new System.Windows.Forms.Button();
            this.rtbDbBackupPath = new System.Windows.Forms.RichTextBox();
            this.lDbBackupPath = new System.Windows.Forms.Label();
            this.bDbBackup = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lSqlServerName = new System.Windows.Forms.Label();
            this.rtbSqlServerName = new System.Windows.Forms.RichTextBox();
            this.gpGeneralSettings = new System.Windows.Forms.GroupBox();
            this.tpLibraryPath = new System.Windows.Forms.TableLayoutPanel();
            this.bLibraryPath = new System.Windows.Forms.Button();
            this.rtbLibraryPath = new System.Windows.Forms.RichTextBox();
            this.lLibraryPath = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.gpConnectionSettings.SuspendLayout();
            this.tpElzabPath.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpPortNumber.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            this.gbPrinterSelection.SuspendLayout();
            this.tpLabelPath.SuspendLayout();
            this.tpSelectedPrinterName.SuspendLayout();
            this.tpAvailablePrintersList.SuspendLayout();
            this.gbDatabaseSettings.SuspendLayout();
            this.tpDbBackupPath.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gpGeneralSettings.SuspendLayout();
            this.tpLibraryPath.SuspendLayout();
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
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 22;
            this.tbDummyForCtrl.Visible = false;
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
            this.cBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // gpConnectionSettings
            // 
            this.gpConnectionSettings.Controls.Add(this.tpElzabPath);
            this.gpConnectionSettings.Controls.Add(this.tableLayoutPanel1);
            this.gpConnectionSettings.Controls.Add(this.tpPortNumber);
            this.gpConnectionSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpConnectionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gpConnectionSettings.Location = new System.Drawing.Point(0, 30);
            this.gpConnectionSettings.Name = "gpConnectionSettings";
            this.gpConnectionSettings.Size = new System.Drawing.Size(920, 130);
            this.gpConnectionSettings.TabIndex = 13;
            this.gpConnectionSettings.TabStop = false;
            this.gpConnectionSettings.Text = "Ustawienie połączenia kasy fiskalnej";
            // 
            // tpElzabPath
            // 
            this.tpElzabPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpElzabPath.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpElzabPath.ColumnCount = 3;
            this.tpElzabPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tpElzabPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 690F));
            this.tpElzabPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpElzabPath.Controls.Add(this.bElzabPath, 2, 0);
            this.tpElzabPath.Controls.Add(this.tbElzabPath, 1, 0);
            this.tpElzabPath.Controls.Add(this.lELzabCommandPath, 0, 0);
            this.tpElzabPath.Location = new System.Drawing.Point(8, 81);
            this.tpElzabPath.Name = "tpElzabPath";
            this.tpElzabPath.Padding = new System.Windows.Forms.Padding(2);
            this.tpElzabPath.RowCount = 1;
            this.tpElzabPath.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpElzabPath.Size = new System.Drawing.Size(909, 40);
            this.tpElzabPath.TabIndex = 21;
            // 
            // bElzabPath
            // 
            this.bElzabPath.BackColor = System.Drawing.Color.White;
            this.bElzabPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bElzabPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bElzabPath.Location = new System.Drawing.Point(868, 6);
            this.bElzabPath.Name = "bElzabPath";
            this.bElzabPath.Size = new System.Drawing.Size(35, 30);
            this.bElzabPath.TabIndex = 3;
            this.bElzabPath.Text = "...";
            this.bElzabPath.UseVisualStyleBackColor = false;
            this.bElzabPath.Click += new System.EventHandler(this.bElzabPath_Click);
            // 
            // tbElzabPath
            // 
            this.tbElzabPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElzabPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabPath.Location = new System.Drawing.Point(177, 6);
            this.tbElzabPath.Multiline = false;
            this.tbElzabPath.Name = "tbElzabPath";
            this.tbElzabPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbElzabPath.Size = new System.Drawing.Size(684, 30);
            this.tbElzabPath.TabIndex = 18;
            this.tbElzabPath.Text = "";
            this.tbElzabPath.WordWrap = false;
            this.tbElzabPath.Validating += new System.ComponentModel.CancelEventHandler(this.tbElzabPath_Validating);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(467, 35);
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
            this.cCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.cCOMPorts.FormattingEnabled = true;
            this.cCOMPorts.Location = new System.Drawing.Point(217, 6);
            this.cCOMPorts.Name = "cCOMPorts";
            this.cCOMPorts.Size = new System.Drawing.Size(227, 28);
            this.cCOMPorts.Sorted = true;
            this.cCOMPorts.TabIndex = 9;
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
            // gbPrinterSelection
            // 
            this.gbPrinterSelection.Controls.Add(this.tpLabelPath);
            this.gbPrinterSelection.Controls.Add(this.tpSelectedPrinterName);
            this.gbPrinterSelection.Controls.Add(this.tpAvailablePrintersList);
            this.gbPrinterSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPrinterSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbPrinterSelection.Location = new System.Drawing.Point(0, 160);
            this.gbPrinterSelection.Margin = new System.Windows.Forms.Padding(5);
            this.gbPrinterSelection.Name = "gbPrinterSelection";
            this.gbPrinterSelection.Padding = new System.Windows.Forms.Padding(5);
            this.gbPrinterSelection.Size = new System.Drawing.Size(920, 130);
            this.gbPrinterSelection.TabIndex = 17;
            this.gbPrinterSelection.TabStop = false;
            this.gbPrinterSelection.Text = "Ustawienia drukarki Dymo";
            // 
            // tpLabelPath
            // 
            this.tpLabelPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpLabelPath.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpLabelPath.ColumnCount = 3;
            this.tpLabelPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpLabelPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 660F));
            this.tpLabelPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpLabelPath.Controls.Add(this.bLabelPath, 2, 0);
            this.tpLabelPath.Controls.Add(this.rtbLabelPath, 1, 0);
            this.tpLabelPath.Controls.Add(this.lLabelPath, 0, 0);
            this.tpLabelPath.Location = new System.Drawing.Point(11, 77);
            this.tpLabelPath.Name = "tpLabelPath";
            this.tpLabelPath.Padding = new System.Windows.Forms.Padding(2);
            this.tpLabelPath.RowCount = 1;
            this.tpLabelPath.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpLabelPath.Size = new System.Drawing.Size(906, 40);
            this.tpLabelPath.TabIndex = 22;
            // 
            // bLabelPath
            // 
            this.bLabelPath.BackColor = System.Drawing.Color.White;
            this.bLabelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLabelPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLabelPath.Location = new System.Drawing.Point(868, 6);
            this.bLabelPath.Name = "bLabelPath";
            this.bLabelPath.Size = new System.Drawing.Size(35, 30);
            this.bLabelPath.TabIndex = 3;
            this.bLabelPath.Text = "...";
            this.bLabelPath.UseVisualStyleBackColor = false;
            this.bLabelPath.Click += new System.EventHandler(this.bLabelPath_Click);
            // 
            // rtbLabelPath
            // 
            this.rtbLabelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLabelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbLabelPath.Location = new System.Drawing.Point(207, 6);
            this.rtbLabelPath.Multiline = false;
            this.rtbLabelPath.Name = "rtbLabelPath";
            this.rtbLabelPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLabelPath.Size = new System.Drawing.Size(654, 30);
            this.rtbLabelPath.TabIndex = 18;
            this.rtbLabelPath.Text = "";
            this.rtbLabelPath.TextChanged += new System.EventHandler(this.rtbLabelPath_TextChanged);
            this.rtbLabelPath.Validating += new System.ComponentModel.CancelEventHandler(this.rtbLabelPath_Validating);
            // 
            // lLabelPath
            // 
            this.lLabelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLabelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLabelPath.Location = new System.Drawing.Point(8, 8);
            this.lLabelPath.Margin = new System.Windows.Forms.Padding(5);
            this.lLabelPath.Name = "lLabelPath";
            this.lLabelPath.Size = new System.Drawing.Size(190, 26);
            this.lLabelPath.TabIndex = 0;
            this.lLabelPath.Text = "Ścieżka etykiety Dymo";
            this.lLabelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpSelectedPrinterName
            // 
            this.tpSelectedPrinterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSelectedPrinterName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSelectedPrinterName.ColumnCount = 2;
            this.tpSelectedPrinterName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSelectedPrinterName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSelectedPrinterName.Controls.Add(this.lSelectedPrinterName, 0, 0);
            this.tpSelectedPrinterName.Controls.Add(this.tbSelectedPrinterName, 1, 0);
            this.tpSelectedPrinterName.ForeColor = System.Drawing.Color.Black;
            this.tpSelectedPrinterName.Location = new System.Drawing.Point(467, 29);
            this.tpSelectedPrinterName.Margin = new System.Windows.Forms.Padding(5);
            this.tpSelectedPrinterName.Name = "tpSelectedPrinterName";
            this.tpSelectedPrinterName.Padding = new System.Windows.Forms.Padding(2);
            this.tpSelectedPrinterName.RowCount = 1;
            this.tpSelectedPrinterName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSelectedPrinterName.Size = new System.Drawing.Size(450, 40);
            this.tpSelectedPrinterName.TabIndex = 1;
            // 
            // lSelectedPrinterName
            // 
            this.lSelectedPrinterName.AutoSize = true;
            this.lSelectedPrinterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSelectedPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSelectedPrinterName.Location = new System.Drawing.Point(8, 8);
            this.lSelectedPrinterName.Margin = new System.Windows.Forms.Padding(5);
            this.lSelectedPrinterName.Name = "lSelectedPrinterName";
            this.lSelectedPrinterName.Size = new System.Drawing.Size(204, 26);
            this.lSelectedPrinterName.TabIndex = 0;
            this.lSelectedPrinterName.Text = "Aktualnie wybrana drukarka";
            this.lSelectedPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSelectedPrinterName
            // 
            this.tbSelectedPrinterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSelectedPrinterName.Location = new System.Drawing.Point(223, 8);
            this.tbSelectedPrinterName.Margin = new System.Windows.Forms.Padding(5);
            this.tbSelectedPrinterName.Name = "tbSelectedPrinterName";
            this.tbSelectedPrinterName.ReadOnly = true;
            this.tbSelectedPrinterName.Size = new System.Drawing.Size(219, 26);
            this.tbSelectedPrinterName.TabIndex = 1;
            // 
            // tpAvailablePrintersList
            // 
            this.tpAvailablePrintersList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpAvailablePrintersList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpAvailablePrintersList.ColumnCount = 2;
            this.tpAvailablePrintersList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpAvailablePrintersList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpAvailablePrintersList.Controls.Add(this.lAvailablePrintersList, 0, 0);
            this.tpAvailablePrintersList.Controls.Add(this.cbAvailablePrintersList, 1, 0);
            this.tpAvailablePrintersList.ForeColor = System.Drawing.Color.Black;
            this.tpAvailablePrintersList.Location = new System.Drawing.Point(10, 29);
            this.tpAvailablePrintersList.Margin = new System.Windows.Forms.Padding(5);
            this.tpAvailablePrintersList.Name = "tpAvailablePrintersList";
            this.tpAvailablePrintersList.Padding = new System.Windows.Forms.Padding(2);
            this.tpAvailablePrintersList.RowCount = 1;
            this.tpAvailablePrintersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpAvailablePrintersList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tpAvailablePrintersList.Size = new System.Drawing.Size(450, 40);
            this.tpAvailablePrintersList.TabIndex = 0;
            // 
            // lAvailablePrintersList
            // 
            this.lAvailablePrintersList.AutoSize = true;
            this.lAvailablePrintersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lAvailablePrintersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lAvailablePrintersList.Location = new System.Drawing.Point(8, 8);
            this.lAvailablePrintersList.Margin = new System.Windows.Forms.Padding(5);
            this.lAvailablePrintersList.Name = "lAvailablePrintersList";
            this.lAvailablePrintersList.Size = new System.Drawing.Size(200, 24);
            this.lAvailablePrintersList.TabIndex = 0;
            this.lAvailablePrintersList.Text = "Lista dostępnych drukarek";
            this.lAvailablePrintersList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAvailablePrintersList
            // 
            this.cbAvailablePrintersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAvailablePrintersList.FormattingEnabled = true;
            this.cbAvailablePrintersList.Location = new System.Drawing.Point(217, 6);
            this.cbAvailablePrintersList.Name = "cbAvailablePrintersList";
            this.cbAvailablePrintersList.Size = new System.Drawing.Size(227, 28);
            this.cbAvailablePrintersList.TabIndex = 1;
            this.cbAvailablePrintersList.SelectedIndexChanged += new System.EventHandler(this.cbAvailablePrintersList_SelectedIndexChanged);
            // 
            // gbDatabaseSettings
            // 
            this.gbDatabaseSettings.Controls.Add(this.tpDbBackupPath);
            this.gbDatabaseSettings.Controls.Add(this.bDbBackup);
            this.gbDatabaseSettings.Controls.Add(this.tableLayoutPanel3);
            this.gbDatabaseSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDatabaseSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbDatabaseSettings.Location = new System.Drawing.Point(0, 290);
            this.gbDatabaseSettings.Name = "gbDatabaseSettings";
            this.gbDatabaseSettings.Size = new System.Drawing.Size(920, 130);
            this.gbDatabaseSettings.TabIndex = 18;
            this.gbDatabaseSettings.TabStop = false;
            this.gbDatabaseSettings.Text = "Ustawienia bazy danych";
            // 
            // tpDbBackupPath
            // 
            this.tpDbBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpDbBackupPath.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpDbBackupPath.ColumnCount = 3;
            this.tpDbBackupPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tpDbBackupPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tpDbBackupPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpDbBackupPath.Controls.Add(this.bDbBackupPath, 2, 0);
            this.tpDbBackupPath.Controls.Add(this.rtbDbBackupPath, 1, 0);
            this.tpDbBackupPath.Controls.Add(this.lDbBackupPath, 0, 0);
            this.tpDbBackupPath.Location = new System.Drawing.Point(8, 71);
            this.tpDbBackupPath.Name = "tpDbBackupPath";
            this.tpDbBackupPath.Padding = new System.Windows.Forms.Padding(2);
            this.tpDbBackupPath.RowCount = 1;
            this.tpDbBackupPath.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpDbBackupPath.Size = new System.Drawing.Size(909, 40);
            this.tpDbBackupPath.TabIndex = 23;
            // 
            // bDbBackupPath
            // 
            this.bDbBackupPath.BackColor = System.Drawing.Color.White;
            this.bDbBackupPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bDbBackupPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDbBackupPath.Location = new System.Drawing.Point(868, 6);
            this.bDbBackupPath.Name = "bDbBackupPath";
            this.bDbBackupPath.Size = new System.Drawing.Size(35, 30);
            this.bDbBackupPath.TabIndex = 3;
            this.bDbBackupPath.Text = "...";
            this.bDbBackupPath.UseVisualStyleBackColor = false;
            this.bDbBackupPath.Click += new System.EventHandler(this.bDbBackupPath_Click);
            // 
            // rtbDbBackupPath
            // 
            this.rtbDbBackupPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDbBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbDbBackupPath.Location = new System.Drawing.Point(307, 6);
            this.rtbDbBackupPath.Multiline = false;
            this.rtbDbBackupPath.Name = "rtbDbBackupPath";
            this.rtbDbBackupPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDbBackupPath.Size = new System.Drawing.Size(554, 30);
            this.rtbDbBackupPath.TabIndex = 18;
            this.rtbDbBackupPath.Text = "";
            this.rtbDbBackupPath.TextChanged += new System.EventHandler(this.rtbDbBackupPath_TextChanged);
            this.rtbDbBackupPath.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDbBackupPath_Validating);
            // 
            // lDbBackupPath
            // 
            this.lDbBackupPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDbBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDbBackupPath.Location = new System.Drawing.Point(8, 8);
            this.lDbBackupPath.Margin = new System.Windows.Forms.Padding(5);
            this.lDbBackupPath.Name = "lDbBackupPath";
            this.lDbBackupPath.Size = new System.Drawing.Size(290, 26);
            this.lDbBackupPath.TabIndex = 0;
            this.lDbBackupPath.Text = "Ścieżka kopii zapasowej bazy danych";
            this.lDbBackupPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bDbBackup
            // 
            this.bDbBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bDbBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDbBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bDbBackup.Location = new System.Drawing.Point(467, 25);
            this.bDbBackup.Margin = new System.Windows.Forms.Padding(5);
            this.bDbBackup.Name = "bDbBackup";
            this.bDbBackup.Size = new System.Drawing.Size(450, 40);
            this.bDbBackup.TabIndex = 15;
            this.bDbBackup.Text = "Kopia zapasowa bazy danych";
            this.bDbBackup.UseVisualStyleBackColor = false;
            this.bDbBackup.Click += new System.EventHandler(this.bDbBackup_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lSqlServerName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbSqlServerName, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(450, 40);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // lSqlServerName
            // 
            this.lSqlServerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lSqlServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSqlServerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lSqlServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSqlServerName.Location = new System.Drawing.Point(6, 3);
            this.lSqlServerName.Name = "lSqlServerName";
            this.lSqlServerName.Size = new System.Drawing.Size(204, 34);
            this.lSqlServerName.TabIndex = 8;
            this.lSqlServerName.Text = "Nazwa serwera bazy";
            this.lSqlServerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbSqlServerName
            // 
            this.rtbSqlServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSqlServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbSqlServerName.Location = new System.Drawing.Point(217, 6);
            this.rtbSqlServerName.Multiline = false;
            this.rtbSqlServerName.Name = "rtbSqlServerName";
            this.rtbSqlServerName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbSqlServerName.ShowSelectionMargin = true;
            this.rtbSqlServerName.Size = new System.Drawing.Size(227, 28);
            this.rtbSqlServerName.TabIndex = 8;
            this.rtbSqlServerName.Text = "";
            // 
            // gpGeneralSettings
            // 
            this.gpGeneralSettings.Controls.Add(this.tpLibraryPath);
            this.gpGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpGeneralSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gpGeneralSettings.Location = new System.Drawing.Point(0, 420);
            this.gpGeneralSettings.Name = "gpGeneralSettings";
            this.gpGeneralSettings.Size = new System.Drawing.Size(920, 79);
            this.gpGeneralSettings.TabIndex = 19;
            this.gpGeneralSettings.TabStop = false;
            this.gpGeneralSettings.Text = "Ustawienia ogólne";
            // 
            // tpLibraryPath
            // 
            this.tpLibraryPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpLibraryPath.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpLibraryPath.ColumnCount = 3;
            this.tpLibraryPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tpLibraryPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 610F));
            this.tpLibraryPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpLibraryPath.Controls.Add(this.bLibraryPath, 2, 0);
            this.tpLibraryPath.Controls.Add(this.rtbLibraryPath, 1, 0);
            this.tpLibraryPath.Controls.Add(this.lLibraryPath, 0, 0);
            this.tpLibraryPath.Location = new System.Drawing.Point(8, 25);
            this.tpLibraryPath.Name = "tpLibraryPath";
            this.tpLibraryPath.Padding = new System.Windows.Forms.Padding(2);
            this.tpLibraryPath.RowCount = 1;
            this.tpLibraryPath.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpLibraryPath.Size = new System.Drawing.Size(909, 40);
            this.tpLibraryPath.TabIndex = 23;
            // 
            // bLibraryPath
            // 
            this.bLibraryPath.BackColor = System.Drawing.Color.White;
            this.bLibraryPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLibraryPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLibraryPath.Location = new System.Drawing.Point(868, 6);
            this.bLibraryPath.Name = "bLibraryPath";
            this.bLibraryPath.Size = new System.Drawing.Size(35, 30);
            this.bLibraryPath.TabIndex = 3;
            this.bLibraryPath.Text = "...";
            this.bLibraryPath.UseVisualStyleBackColor = false;
            this.bLibraryPath.Click += new System.EventHandler(this.bLibraryPath_Click);
            // 
            // rtbLibraryPath
            // 
            this.rtbLibraryPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLibraryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbLibraryPath.Location = new System.Drawing.Point(257, 6);
            this.rtbLibraryPath.Multiline = false;
            this.rtbLibraryPath.Name = "rtbLibraryPath";
            this.rtbLibraryPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLibraryPath.Size = new System.Drawing.Size(604, 30);
            this.rtbLibraryPath.TabIndex = 18;
            this.rtbLibraryPath.Text = "";
            this.rtbLibraryPath.TextChanged += new System.EventHandler(this.rtbLibraryPath_TextChanged);
            this.rtbLibraryPath.Validating += new System.ComponentModel.CancelEventHandler(this.rtbLibraryPath_Validating);
            // 
            // lLibraryPath
            // 
            this.lLibraryPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibraryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLibraryPath.Location = new System.Drawing.Point(8, 8);
            this.lLibraryPath.Margin = new System.Windows.Forms.Padding(5);
            this.lLibraryPath.Name = "lLibraryPath";
            this.lLibraryPath.Size = new System.Drawing.Size(240, 26);
            this.lLibraryPath.TabIndex = 0;
            this.lLibraryPath.Text = "Ścieżka bibliotek programu";
            this.lLibraryPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.gpGeneralSettings);
            this.Controls.Add(this.gbDatabaseSettings);
            this.Controls.Add(this.gbPrinterSelection);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.gpConnectionSettings);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "GeneralSettings";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gpConnectionSettings.ResumeLayout(false);
            this.tpElzabPath.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpPortNumber.ResumeLayout(false);
            this.pButtonsPanel.ResumeLayout(false);
            this.gbPrinterSelection.ResumeLayout(false);
            this.tpLabelPath.ResumeLayout(false);
            this.tpSelectedPrinterName.ResumeLayout(false);
            this.tpSelectedPrinterName.PerformLayout();
            this.tpAvailablePrintersList.ResumeLayout(false);
            this.tpAvailablePrintersList.PerformLayout();
            this.gbDatabaseSettings.ResumeLayout(false);
            this.tpDbBackupPath.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gpGeneralSettings.ResumeLayout(false);
            this.tpLibraryPath.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.ComboBox cBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDefaults;
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
        private System.Windows.Forms.TableLayoutPanel tpElzabPath;
        private System.Windows.Forms.Button bElzabPath;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.GroupBox gbPrinterSelection;
        private System.Windows.Forms.TableLayoutPanel tpLabelPath;
        private System.Windows.Forms.Button bLabelPath;
        private System.Windows.Forms.RichTextBox rtbLabelPath;
        private System.Windows.Forms.Label lLabelPath;
        private System.Windows.Forms.TableLayoutPanel tpSelectedPrinterName;
        private System.Windows.Forms.Label lSelectedPrinterName;
        private System.Windows.Forms.TextBox tbSelectedPrinterName;
        private System.Windows.Forms.TableLayoutPanel tpAvailablePrintersList;
        private System.Windows.Forms.Label lAvailablePrintersList;
        private System.Windows.Forms.ComboBox cbAvailablePrintersList;
        private System.Windows.Forms.GroupBox gbDatabaseSettings;
        private System.Windows.Forms.Button bDbBackup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lSqlServerName;
        private System.Windows.Forms.RichTextBox rtbSqlServerName;
        private System.Windows.Forms.TableLayoutPanel tpDbBackupPath;
        private System.Windows.Forms.Button bDbBackupPath;
        private System.Windows.Forms.RichTextBox rtbDbBackupPath;
        private System.Windows.Forms.Label lDbBackupPath;
        private System.Windows.Forms.GroupBox gpGeneralSettings;
        private System.Windows.Forms.TableLayoutPanel tpLibraryPath;
        private System.Windows.Forms.Button bLibraryPath;
        private System.Windows.Forms.RichTextBox rtbLibraryPath;
        private System.Windows.Forms.Label lLibraryPath;
    }
}