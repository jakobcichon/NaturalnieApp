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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pSettingNr1 = new System.Windows.Forms.Panel();
            this.bBrowsePath = new System.Windows.Forms.Button();
            this.tbElzabPath = new System.Windows.Forms.TextBox();
            this.lElzabPath = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.cCOMPorts = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lCOMPortNr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pSettingNr1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSettingNr1
            // 
            this.pSettingNr1.Controls.Add(this.bBrowsePath);
            this.pSettingNr1.Controls.Add(this.tbElzabPath);
            this.pSettingNr1.Controls.Add(this.lElzabPath);
            this.pSettingNr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSettingNr1.Location = new System.Drawing.Point(0, 30);
            this.pSettingNr1.Name = "pSettingNr1";
            this.pSettingNr1.Size = new System.Drawing.Size(1000, 40);
            this.pSettingNr1.TabIndex = 0;
            // 
            // bBrowsePath
            // 
            this.bBrowsePath.BackColor = System.Drawing.Color.White;
            this.bBrowsePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.bBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowsePath.Location = new System.Drawing.Point(960, 0);
            this.bBrowsePath.Name = "bBrowsePath";
            this.bBrowsePath.Size = new System.Drawing.Size(40, 40);
            this.bBrowsePath.TabIndex = 2;
            this.bBrowsePath.Text = "...";
            this.bBrowsePath.UseVisualStyleBackColor = false;
            this.bBrowsePath.Click += new System.EventHandler(this.bBrowsePath_Click);
            // 
            // tbElzabPath
            // 
            this.tbElzabPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbElzabPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbElzabPath.Location = new System.Drawing.Point(300, 0);
            this.tbElzabPath.Multiline = true;
            this.tbElzabPath.Name = "tbElzabPath";
            this.tbElzabPath.Size = new System.Drawing.Size(660, 40);
            this.tbElzabPath.TabIndex = 1;
            this.tbElzabPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lElzabPath
            // 
            this.lElzabPath.BackColor = System.Drawing.Color.White;
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
            this.pHeader.Size = new System.Drawing.Size(1000, 30);
            this.pHeader.TabIndex = 1;
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
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // cCOMPorts
            // 
            this.cCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cCOMPorts.FormattingEnabled = true;
            this.cCOMPorts.Location = new System.Drawing.Point(167, 52);
            this.cCOMPorts.Name = "cCOMPorts";
            this.cCOMPorts.Size = new System.Drawing.Size(132, 28);
            this.cCOMPorts.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(148)))), ((int)(((byte)(119)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cBaudRate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lCOMPortNr);
            this.panel1.Controls.Add(this.cCOMPorts);
            this.panel1.Location = new System.Drawing.Point(12, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 129);
            this.panel1.TabIndex = 7;
            // 
            // lCOMPortNr
            // 
            this.lCOMPortNr.BackColor = System.Drawing.Color.White;
            this.lCOMPortNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lCOMPortNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCOMPortNr.Location = new System.Drawing.Point(11, 51);
            this.lCOMPortNr.Name = "lCOMPortNr";
            this.lCOMPortNr.Size = new System.Drawing.Size(150, 28);
            this.lCOMPortNr.TabIndex = 7;
            this.lCOMPortNr.Text = "Numer Portu COM";
            this.lCOMPortNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Prędkość transmisji";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBaudRate
            // 
            this.cBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cBaudRate.FormattingEnabled = true;
            this.cBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200"});
            this.cBaudRate.Location = new System.Drawing.Point(167, 83);
            this.cBaudRate.Name = "cBaudRate";
            this.cBaudRate.Size = new System.Drawing.Size(132, 28);
            this.cBaudRate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 40);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ustawienia połączenia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ElzabSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pSettingNr1);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ElzabSettings";
            this.Text = "Submenu_ElzabInfo";
            this.Load += new System.EventHandler(this.ElzabSettings_Load);
            this.pSettingNr1.ResumeLayout(false);
            this.pSettingNr1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSettingNr1;
        private System.Windows.Forms.TextBox tbElzabPath;
        private System.Windows.Forms.Label lElzabPath;
        private System.Windows.Forms.Button bBrowsePath;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.ComboBox cCOMPorts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lCOMPortNr;
        private System.Windows.Forms.ComboBox cBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}