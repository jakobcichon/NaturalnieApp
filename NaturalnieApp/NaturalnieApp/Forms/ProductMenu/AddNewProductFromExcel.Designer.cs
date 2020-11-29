using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddNewProductFromPDF
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.pSettingNr1 = new System.Windows.Forms.Panel();
            this.tbPdfPath = new System.Windows.Forms.RichTextBox();
            this.lExcelPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bBrowsePath = new System.Windows.Forms.Button();
            this.bGenerateTemplate = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.pSettingNr1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1000, 30);
            this.pHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
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
            // 
            // pSettingNr1
            // 
            this.pSettingNr1.Controls.Add(this.bBrowsePath);
            this.pSettingNr1.Controls.Add(this.lExcelPath);
            this.pSettingNr1.Controls.Add(this.tbPdfPath);
            this.pSettingNr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSettingNr1.Location = new System.Drawing.Point(0, 30);
            this.pSettingNr1.Name = "pSettingNr1";
            this.pSettingNr1.Size = new System.Drawing.Size(1000, 45);
            this.pSettingNr1.TabIndex = 4;
            // 
            // tbPdfPath
            // 
            this.tbPdfPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPdfPath.Location = new System.Drawing.Point(302, 1);
            this.tbPdfPath.Margin = new System.Windows.Forms.Padding(0);
            this.tbPdfPath.Multiline = false;
            this.tbPdfPath.Name = "tbPdfPath";
            this.tbPdfPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbPdfPath.ShowSelectionMargin = true;
            this.tbPdfPath.Size = new System.Drawing.Size(660, 40);
            this.tbPdfPath.TabIndex = 8;
            this.tbPdfPath.Text = "";
            // 
            // lExcelPath
            // 
            this.lExcelPath.BackColor = System.Drawing.Color.White;
            this.lExcelPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lExcelPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lExcelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lExcelPath.Location = new System.Drawing.Point(0, 0);
            this.lExcelPath.Name = "lExcelPath";
            this.lExcelPath.Size = new System.Drawing.Size(300, 45);
            this.lExcelPath.TabIndex = 0;
            this.lExcelPath.Text = "Ścieżka do pliku exlec z produktami";
            this.lExcelPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1000, 427);
            this.dataGridView1.TabIndex = 5;
            // 
            // bBrowsePath
            // 
            this.bBrowsePath.BackColor = System.Drawing.Color.White;
            this.bBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrowsePath.Location = new System.Drawing.Point(960, 1);
            this.bBrowsePath.Name = "bBrowsePath";
            this.bBrowsePath.Size = new System.Drawing.Size(35, 40);
            this.bBrowsePath.TabIndex = 9;
            this.bBrowsePath.Text = "...";
            this.bBrowsePath.UseVisualStyleBackColor = false;
            // 
            // bGenerateTemplate
            // 
            this.bGenerateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bGenerateTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bGenerateTemplate.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bGenerateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bGenerateTemplate.Location = new System.Drawing.Point(4, 508);
            this.bGenerateTemplate.Name = "bGenerateTemplate";
            this.bGenerateTemplate.Size = new System.Drawing.Size(100, 50);
            this.bGenerateTemplate.TabIndex = 6;
            this.bGenerateTemplate.Text = "Generuj formatkę";
            this.bGenerateTemplate.UseVisualStyleBackColor = false;
            this.bGenerateTemplate.Click += new System.EventHandler(this.bGenerateTemplate_Click);
            // 
            // AddNewProductFromPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.bGenerateTemplate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pSettingNr1);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewProductFromPDF";
            this.Text = "Submenu_ElzabInfo";
            this.pHeader.ResumeLayout(false);
            this.pSettingNr1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pSettingNr1;
        private System.Windows.Forms.RichTextBox tbPdfPath;
        private System.Windows.Forms.Label lExcelPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bBrowsePath;
        private System.Windows.Forms.Button bGenerateTemplate;
    }
}