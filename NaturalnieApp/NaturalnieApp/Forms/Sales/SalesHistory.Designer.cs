namespace NaturalnieApp.Forms
{
    partial class SalesHistory
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
            this.bSaveSummaryData = new System.Windows.Forms.Button();
            this.bReadingSaleBufforFromFile = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.tcDataFromFile = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pButtonsPanel.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bSaveSummaryData);
            this.pButtonsPanel.Controls.Add(this.bReadingSaleBufforFromFile);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(923, 70);
            this.pButtonsPanel.TabIndex = 6;
            // 
            // bSaveSummaryData
            // 
            this.bSaveSummaryData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSaveSummaryData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSaveSummaryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveSummaryData.Location = new System.Drawing.Point(723, 7);
            this.bSaveSummaryData.Margin = new System.Windows.Forms.Padding(5);
            this.bSaveSummaryData.Name = "bSaveSummaryData";
            this.bSaveSummaryData.Size = new System.Drawing.Size(180, 50);
            this.bSaveSummaryData.TabIndex = 30;
            this.bSaveSummaryData.Text = "Zapisz dane sumaryczne do pliku";
            this.bSaveSummaryData.UseVisualStyleBackColor = false;
            this.bSaveSummaryData.Click += new System.EventHandler(this.bSaveSummaryData_Click);
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
            this.pHeader.Size = new System.Drawing.Size(923, 30);
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
            this.tbDummyForCtrl.Visible = false;
            // 
            // tcDataFromFile
            // 
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
            // SalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.tcDataFromFile);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "SalesHistory";
            this.Size = new System.Drawing.Size(923, 690);
            this.pButtonsPanel.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.TabControl tcDataFromFile;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bReadingSaleBufforFromFile;
        private System.Windows.Forms.Button bSaveSummaryData;
    }
}