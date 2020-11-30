﻿using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddNewProductFromExcel
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
            this.dgvExcelData = new System.Windows.Forms.DataGridView();
            this.bGenerateTemplate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bAddFromFile = new System.Windows.Forms.Button();
            this.bDeselectAll = new System.Windows.Forms.Button();
            this.bSelectAll = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).BeginInit();
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
            // dgvExcelData
            // 
            this.dgvExcelData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvExcelData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvExcelData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvExcelData.Location = new System.Drawing.Point(0, 30);
            this.dgvExcelData.Name = "dgvExcelData";
            this.dgvExcelData.Size = new System.Drawing.Size(1000, 472);
            this.dgvExcelData.TabIndex = 5;
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
            // bAddFromFile
            // 
            this.bAddFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bAddFromFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAddFromFile.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bAddFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bAddFromFile.Location = new System.Drawing.Point(110, 508);
            this.bAddFromFile.Name = "bAddFromFile";
            this.bAddFromFile.Size = new System.Drawing.Size(100, 50);
            this.bAddFromFile.TabIndex = 7;
            this.bAddFromFile.Text = "Dodaj plik";
            this.bAddFromFile.UseVisualStyleBackColor = false;
            this.bAddFromFile.Click += new System.EventHandler(this.bAddFromFile_Click);
            // 
            // bDeselectAll
            // 
            this.bDeselectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bDeselectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDeselectAll.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bDeselectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bDeselectAll.Location = new System.Drawing.Point(322, 508);
            this.bDeselectAll.Name = "bDeselectAll";
            this.bDeselectAll.Size = new System.Drawing.Size(100, 50);
            this.bDeselectAll.TabIndex = 8;
            this.bDeselectAll.Text = "Odznacz wszystko";
            this.bDeselectAll.UseVisualStyleBackColor = false;
            this.bDeselectAll.Visible = false;
            this.bDeselectAll.Click += new System.EventHandler(this.bDeselectAll_Click);
            // 
            // bSelectAll
            // 
            this.bSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSelectAll.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSelectAll.Location = new System.Drawing.Point(216, 508);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(100, 50);
            this.bSelectAll.TabIndex = 9;
            this.bSelectAll.Text = "Zaznacz wszytsko";
            this.bSelectAll.UseVisualStyleBackColor = false;
            this.bSelectAll.Visible = false;
            this.bSelectAll.Click += new System.EventHandler(this.bSelectAll_Click);
            // 
            // AddNewProductFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.bSelectAll);
            this.Controls.Add(this.bDeselectAll);
            this.Controls.Add(this.bAddFromFile);
            this.Controls.Add(this.bGenerateTemplate);
            this.Controls.Add(this.dgvExcelData);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewProductFromExcel";
            this.Text = "Submenu_ElzabInfo";
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvExcelData;
        private System.Windows.Forms.Button bGenerateTemplate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bAddFromFile;
        private System.Windows.Forms.Button bDeselectAll;
        private System.Windows.Forms.Button bSelectAll;
    }
}