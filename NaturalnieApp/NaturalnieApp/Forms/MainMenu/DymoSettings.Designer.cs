using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class DymoSettings
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
            this.gbPrinterSelection = new System.Windows.Forms.GroupBox();
            this.tpSelectedPrinterName = new System.Windows.Forms.TableLayoutPanel();
            this.lSelectedPrinterName = new System.Windows.Forms.Label();
            this.tbSelectedPrinterName = new System.Windows.Forms.TextBox();
            this.tpAvailablePrintersList = new System.Windows.Forms.TableLayoutPanel();
            this.lAvailablePrintersList = new System.Windows.Forms.Label();
            this.cbAvailablePrintersList = new System.Windows.Forms.ComboBox();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.pTest = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            this.gbPrinterSelection.SuspendLayout();
            this.tpSelectedPrinterName.SuspendLayout();
            this.tpAvailablePrintersList.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
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
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 0;
            // 
            // gbPrinterSelection
            // 
            this.gbPrinterSelection.Controls.Add(this.tpSelectedPrinterName);
            this.gbPrinterSelection.Controls.Add(this.tpAvailablePrintersList);
            this.gbPrinterSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPrinterSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbPrinterSelection.Location = new System.Drawing.Point(0, 30);
            this.gbPrinterSelection.Margin = new System.Windows.Forms.Padding(5);
            this.gbPrinterSelection.Name = "gbPrinterSelection";
            this.gbPrinterSelection.Padding = new System.Windows.Forms.Padding(5);
            this.gbPrinterSelection.Size = new System.Drawing.Size(920, 132);
            this.gbPrinterSelection.TabIndex = 1;
            this.gbPrinterSelection.TabStop = false;
            this.gbPrinterSelection.Text = "Wybór drukarki";
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
            this.tpSelectedPrinterName.Location = new System.Drawing.Point(10, 79);
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
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 5;
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(701, 7);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 29;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(807, 7);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 28;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // pTest
            // 
            this.pTest.AutoSize = true;
            this.pTest.Location = new System.Drawing.Point(0, 195);
            this.pTest.Name = "pTest";
            this.pTest.Size = new System.Drawing.Size(200, 100);
            this.pTest.TabIndex = 6;
            // 
            // DymoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pTest);
            this.Controls.Add(this.gbPrinterSelection);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pButtonsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Name = "DymoSettings";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.DymoSettings_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbPrinterSelection.ResumeLayout(false);
            this.tpSelectedPrinterName.ResumeLayout(false);
            this.tpSelectedPrinterName.PerformLayout();
            this.tpAvailablePrintersList.ResumeLayout(false);
            this.tpAvailablePrintersList.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.GroupBox gbPrinterSelection;
        private System.Windows.Forms.TableLayoutPanel tpAvailablePrintersList;
        private System.Windows.Forms.Label lAvailablePrintersList;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.ComboBox cbAvailablePrintersList;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TableLayoutPanel tpSelectedPrinterName;
        private System.Windows.Forms.Label lSelectedPrinterName;
        private System.Windows.Forms.TextBox tbSelectedPrinterName;
        private System.Windows.Forms.Panel pTest;
    }
}