using NaturalnieApp.Initialization;

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
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.bDummyForControl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bGenerateTemplate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bAddFromFile = new System.Windows.Forms.Button();
            this.bDeselectAll = new System.Windows.Forms.Button();
            this.bSelectAll = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.bClose = new System.Windows.Forms.Button();
            this.tpMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.lMarigin = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.tpMarigin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.bDummyForControl);
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1000, 30);
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
            // bDummyForControl
            // 
            this.bDummyForControl.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.bDummyForControl.BackColor = System.Drawing.Color.Transparent;
            this.bDummyForControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDummyForControl.CausesValidation = false;
            this.bDummyForControl.Cursor = System.Windows.Forms.Cursors.No;
            this.bDummyForControl.Enabled = false;
            this.bDummyForControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDummyForControl.ForeColor = System.Drawing.Color.Transparent;
            this.bDummyForControl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bDummyForControl.Location = new System.Drawing.Point(496, 11);
            this.bDummyForControl.Name = "bDummyForControl";
            this.bDummyForControl.Size = new System.Drawing.Size(8, 8);
            this.bDummyForControl.TabIndex = 0;
            this.bDummyForControl.UseVisualStyleBackColor = false;
            this.bDummyForControl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(732, 510);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(150, 50);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Zapisz do bazy danych";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(626, 510);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 7;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bGenerateTemplate
            // 
            this.bGenerateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bGenerateTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bGenerateTemplate.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bGenerateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bGenerateTemplate.Location = new System.Drawing.Point(4, 510);
            this.bGenerateTemplate.Name = "bGenerateTemplate";
            this.bGenerateTemplate.Size = new System.Drawing.Size(100, 50);
            this.bGenerateTemplate.TabIndex = 3;
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
            this.bAddFromFile.Location = new System.Drawing.Point(110, 510);
            this.bAddFromFile.Name = "bAddFromFile";
            this.bAddFromFile.Size = new System.Drawing.Size(100, 50);
            this.bAddFromFile.TabIndex = 4;
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
            this.bDeselectAll.Location = new System.Drawing.Point(322, 510);
            this.bDeselectAll.Name = "bDeselectAll";
            this.bDeselectAll.Size = new System.Drawing.Size(100, 50);
            this.bDeselectAll.TabIndex = 6;
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
            this.bSelectAll.Location = new System.Drawing.Point(216, 510);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(100, 50);
            this.bSelectAll.TabIndex = 5;
            this.bSelectAll.Text = "Zaznacz wszytsko";
            this.bSelectAll.UseVisualStyleBackColor = false;
            this.bSelectAll.Visible = false;
            this.bSelectAll.Click += new System.EventHandler(this.bSelectAll_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 27);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(1000, 420);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellEndEdit);
            this.advancedDataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellValidated);
            this.advancedDataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.advancedDataGridView1_CellValidating);
            this.advancedDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellValueChanged);
            this.advancedDataGridView1.Click += new System.EventHandler(this.advancedDataGridView1_Click);
            this.advancedDataGridView1.DoubleClick += new System.EventHandler(this.advancedDataGridView1_DoubleClick);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(888, 510);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 9;
            this.bClose.Text = "Zamknij";
            this.bClose.UseMnemonic = false;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // tpMarigin
            // 
            this.tpMarigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpMarigin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpMarigin.ColumnCount = 2;
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMarigin.Controls.Add(this.tbMarigin, 0, 0);
            this.tpMarigin.Controls.Add(this.lMarigin, 0, 0);
            this.tpMarigin.Location = new System.Drawing.Point(4, 453);
            this.tpMarigin.Name = "tpMarigin";
            this.tpMarigin.RowCount = 1;
            this.tpMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMarigin.Size = new System.Drawing.Size(147, 40);
            this.tpMarigin.TabIndex = 2;
            // 
            // tbMarigin
            // 
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(83, 6);
            this.tbMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(55, 26);
            this.tbMarigin.TabIndex = 1;
            this.tbMarigin.Text = "30";
            this.tbMarigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMarigin.Validating += new System.ComponentModel.CancelEventHandler(this.tbMarigin_Validating);
            // 
            // lMarigin
            // 
            this.lMarigin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(6, 6);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(5);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(66, 30);
            this.lMarigin.TabIndex = 0;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddNewProductFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.tpMarigin);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.bSelectAll);
            this.Controls.Add(this.bDeselectAll);
            this.Controls.Add(this.bAddFromFile);
            this.Controls.Add(this.bGenerateTemplate);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewProductFromExcel";
            this.Text = "Submenu_ElzabInfo";
            this.Load += new System.EventHandler(this.AddNewProductFromExcel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddNewProductFromExcel_KeyDown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.tpMarigin.ResumeLayout(false);
            this.tpMarigin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bGenerateTemplate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bAddFromFile;
        private System.Windows.Forms.Button bDeselectAll;
        private System.Windows.Forms.Button bSelectAll;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TableLayoutPanel tpMarigin;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.Button bDummyForControl;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
    }
}