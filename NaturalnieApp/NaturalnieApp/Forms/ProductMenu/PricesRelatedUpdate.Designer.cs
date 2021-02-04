using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class PricesRelatedUpdate
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bAddFromFile = new System.Windows.Forms.Button();
            this.bGenerateTemplate = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.advancedDataGridView2 = new Zuby.ADGV.AdvancedDataGridView();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.pButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).BeginInit();
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
            this.pHeader.TabIndex = 0;
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
            this.panel1.TabIndex = 1;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.GridColor = System.Drawing.Color.Black;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 76);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.ShowEditingIcon = false;
            this.advancedDataGridView1.Size = new System.Drawing.Size(460, 544);
            this.advancedDataGridView1.TabIndex = 0;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bAddFromFile);
            this.pButtonsPanel.Controls.Add(this.bGenerateTemplate);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 7;
            // 
            // bAddFromFile
            // 
            this.bAddFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAddFromFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAddFromFile.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bAddFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bAddFromFile.Location = new System.Drawing.Point(219, 7);
            this.bAddFromFile.Name = "bAddFromFile";
            this.bAddFromFile.Size = new System.Drawing.Size(100, 50);
            this.bAddFromFile.TabIndex = 9;
            this.bAddFromFile.Text = "Dodaj plik";
            this.bAddFromFile.UseVisualStyleBackColor = false;
            this.bAddFromFile.Click += new System.EventHandler(this.bAddFromFile_Click);
            // 
            // bGenerateTemplate
            // 
            this.bGenerateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bGenerateTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bGenerateTemplate.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bGenerateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bGenerateTemplate.Location = new System.Drawing.Point(113, 7);
            this.bGenerateTemplate.Name = "bGenerateTemplate";
            this.bGenerateTemplate.Size = new System.Drawing.Size(100, 50);
            this.bGenerateTemplate.TabIndex = 8;
            this.bGenerateTemplate.Text = "Generuj formatkę";
            this.bGenerateTemplate.UseVisualStyleBackColor = false;
            this.bGenerateTemplate.Click += new System.EventHandler(this.bGenerateTemplate_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(5, 7);
            this.bClose.Margin = new System.Windows.Forms.Padding(5);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 7;
            this.bClose.Text = "Zamknij";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(813, 7);
            this.bSave.Margin = new System.Windows.Forms.Padding(5);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 40);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // advancedDataGridView2
            // 
            this.advancedDataGridView2.AllowUserToAddRows = false;
            this.advancedDataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.advancedDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.advancedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView2.FilterAndSortEnabled = true;
            this.advancedDataGridView2.GridColor = System.Drawing.Color.Black;
            this.advancedDataGridView2.Location = new System.Drawing.Point(460, 76);
            this.advancedDataGridView2.Name = "advancedDataGridView2";
            this.advancedDataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView2.ShowEditingIcon = false;
            this.advancedDataGridView2.Size = new System.Drawing.Size(460, 544);
            this.advancedDataGridView2.TabIndex = 9;
            // 
            // PricesRelatedUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.advancedDataGridView2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "PricesRelatedUpdate";
            this.Size = new System.Drawing.Size(920, 690);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.pButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bAddFromFile;
        private System.Windows.Forms.Button bGenerateTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView2;
    }
}