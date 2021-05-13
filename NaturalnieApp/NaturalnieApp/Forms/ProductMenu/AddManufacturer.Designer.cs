using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddManufacturer
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
            this.components = new System.ComponentModel.Container();
            this.gbManufacturerInfo = new System.Windows.Forms.GroupBox();
            this.bSaveManufacturer = new System.Windows.Forms.Button();
            this.tpManufacturer = new System.Windows.Forms.TableLayoutPanel();
            this.tbManufacturerName = new System.Windows.Forms.TextBox();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.tpBarcodePrefix = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarcodePrefix = new System.Windows.Forms.TextBox();
            this.lBarcodePrefix = new System.Windows.Forms.Label();
            this.pManufacturerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lManufacturerInfo = new System.Windows.Forms.Label();
            this.rtbManufacturerInfo = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbSupplierInfo = new System.Windows.Forms.GroupBox();
            this.bSaveSupplier = new System.Windows.Forms.Button();
            this.tpSupplierName = new System.Windows.Forms.TableLayoutPanel();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.lSupplierName = new System.Windows.Forms.Label();
            this.tpSupplierInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lSupplierInfo = new System.Windows.Forms.Label();
            this.rtbSupplierInfo = new System.Windows.Forms.RichTextBox();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lName = new System.Windows.Forms.Label();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbManufacturerInfo.SuspendLayout();
            this.tpManufacturer.SuspendLayout();
            this.tpBarcodePrefix.SuspendLayout();
            this.pManufacturerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbSupplierInfo.SuspendLayout();
            this.tpSupplierName.SuspendLayout();
            this.tpSupplierInfo.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbManufacturerInfo
            // 
            this.gbManufacturerInfo.Controls.Add(this.bSaveManufacturer);
            this.gbManufacturerInfo.Controls.Add(this.tpManufacturer);
            this.gbManufacturerInfo.Controls.Add(this.tpBarcodePrefix);
            this.gbManufacturerInfo.Controls.Add(this.pManufacturerInfo);
            this.gbManufacturerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbManufacturerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbManufacturerInfo.Location = new System.Drawing.Point(0, 30);
            this.gbManufacturerInfo.Name = "gbManufacturerInfo";
            this.gbManufacturerInfo.Size = new System.Drawing.Size(920, 327);
            this.gbManufacturerInfo.TabIndex = 1;
            this.gbManufacturerInfo.TabStop = false;
            this.gbManufacturerInfo.Text = "Dane producenta";
            // 
            // bSaveManufacturer
            // 
            this.bSaveManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSaveManufacturer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSaveManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveManufacturer.Location = new System.Drawing.Point(356, 277);
            this.bSaveManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.bSaveManufacturer.Name = "bSaveManufacturer";
            this.bSaveManufacturer.Size = new System.Drawing.Size(100, 50);
            this.bSaveManufacturer.TabIndex = 15;
            this.bSaveManufacturer.Text = "Zapisz";
            this.bSaveManufacturer.UseVisualStyleBackColor = false;
            this.bSaveManufacturer.Click += new System.EventHandler(this.bSaveManufacturer_Click);
            // 
            // tpManufacturer
            // 
            this.tpManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpManufacturer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpManufacturer.ColumnCount = 2;
            this.tpManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpManufacturer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpManufacturer.Controls.Add(this.tbManufacturerName, 1, 0);
            this.tpManufacturer.Controls.Add(this.lManufacturer, 0, 0);
            this.tpManufacturer.ForeColor = System.Drawing.Color.Black;
            this.tpManufacturer.Location = new System.Drawing.Point(6, 23);
            this.tpManufacturer.Name = "tpManufacturer";
            this.tpManufacturer.RowCount = 1;
            this.tpManufacturer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpManufacturer.Size = new System.Drawing.Size(450, 40);
            this.tpManufacturer.TabIndex = 0;
            // 
            // tbManufacturerName
            // 
            this.tbManufacturerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbManufacturerName.Location = new System.Drawing.Point(217, 6);
            this.tbManufacturerName.Margin = new System.Windows.Forms.Padding(5);
            this.tbManufacturerName.Name = "tbManufacturerName";
            this.tbManufacturerName.Size = new System.Drawing.Size(213, 26);
            this.tbManufacturerName.TabIndex = 1;
            this.tbManufacturerName.MouseHover += new System.EventHandler(this.tbManufacturerName_MouseHover);
            this.tbManufacturerName.Validating += new System.ComponentModel.CancelEventHandler(this.tbManufacturerName_Validating);
            // 
            // lManufacturer
            // 
            this.lManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturer.Location = new System.Drawing.Point(6, 6);
            this.lManufacturer.Margin = new System.Windows.Forms.Padding(5);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(200, 30);
            this.lManufacturer.TabIndex = 0;
            this.lManufacturer.Text = "Nazwa producenta";
            this.lManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpBarcodePrefix
            // 
            this.tpBarcodePrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpBarcodePrefix.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpBarcodePrefix.ColumnCount = 2;
            this.tpBarcodePrefix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpBarcodePrefix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpBarcodePrefix.Controls.Add(this.tbBarcodePrefix, 0, 0);
            this.tpBarcodePrefix.Controls.Add(this.lBarcodePrefix, 0, 0);
            this.tpBarcodePrefix.ForeColor = System.Drawing.Color.Black;
            this.tpBarcodePrefix.Location = new System.Drawing.Point(6, 70);
            this.tpBarcodePrefix.Name = "tpBarcodePrefix";
            this.tpBarcodePrefix.RowCount = 1;
            this.tpBarcodePrefix.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpBarcodePrefix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tpBarcodePrefix.Size = new System.Drawing.Size(450, 40);
            this.tpBarcodePrefix.TabIndex = 5;
            // 
            // tbBarcodePrefix
            // 
            this.tbBarcodePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBarcodePrefix.Location = new System.Drawing.Point(217, 6);
            this.tbBarcodePrefix.Margin = new System.Windows.Forms.Padding(5);
            this.tbBarcodePrefix.Name = "tbBarcodePrefix";
            this.tbBarcodePrefix.Size = new System.Drawing.Size(213, 26);
            this.tbBarcodePrefix.TabIndex = 0;
            this.tbBarcodePrefix.MouseHover += new System.EventHandler(this.tbBarcodePrefix_MouseHover);
            this.tbBarcodePrefix.Validating += new System.ComponentModel.CancelEventHandler(this.tbBarcodePrefix_Validating);
            // 
            // lBarcodePrefix
            // 
            this.lBarcodePrefix.Dock = System.Windows.Forms.DockStyle.Top;
            this.lBarcodePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBarcodePrefix.Location = new System.Drawing.Point(6, 6);
            this.lBarcodePrefix.Margin = new System.Windows.Forms.Padding(5);
            this.lBarcodePrefix.Name = "lBarcodePrefix";
            this.lBarcodePrefix.Size = new System.Drawing.Size(200, 30);
            this.lBarcodePrefix.TabIndex = 0;
            this.lBarcodePrefix.Text = "Prefiks kodu kreskowego";
            this.lBarcodePrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pManufacturerInfo
            // 
            this.pManufacturerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.pManufacturerInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pManufacturerInfo.ColumnCount = 1;
            this.pManufacturerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pManufacturerInfo.Controls.Add(this.lManufacturerInfo, 0, 0);
            this.pManufacturerInfo.Controls.Add(this.rtbManufacturerInfo, 0, 1);
            this.pManufacturerInfo.ForeColor = System.Drawing.Color.Black;
            this.pManufacturerInfo.Location = new System.Drawing.Point(6, 112);
            this.pManufacturerInfo.Name = "pManufacturerInfo";
            this.pManufacturerInfo.RowCount = 3;
            this.pManufacturerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.pManufacturerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pManufacturerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pManufacturerInfo.Size = new System.Drawing.Size(450, 166);
            this.pManufacturerInfo.TabIndex = 12;
            // 
            // lManufacturerInfo
            // 
            this.lManufacturerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lManufacturerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lManufacturerInfo.Location = new System.Drawing.Point(4, 4);
            this.lManufacturerInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lManufacturerInfo.Name = "lManufacturerInfo";
            this.lManufacturerInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lManufacturerInfo.Size = new System.Drawing.Size(442, 34);
            this.lManufacturerInfo.TabIndex = 0;
            this.lManufacturerInfo.Text = "Informacje o producencie";
            this.lManufacturerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbManufacturerInfo
            // 
            this.rtbManufacturerInfo.BackColor = System.Drawing.SystemColors.Info;
            this.rtbManufacturerInfo.Location = new System.Drawing.Point(6, 47);
            this.rtbManufacturerInfo.Margin = new System.Windows.Forms.Padding(5);
            this.rtbManufacturerInfo.MaxLength = 1024;
            this.rtbManufacturerInfo.Name = "rtbManufacturerInfo";
            this.rtbManufacturerInfo.Size = new System.Drawing.Size(425, 88);
            this.rtbManufacturerInfo.TabIndex = 0;
            this.rtbManufacturerInfo.Text = "";
            this.rtbManufacturerInfo.Validating += new System.ComponentModel.CancelEventHandler(this.rtbManufacturerInfo_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbSupplierInfo
            // 
            this.gbSupplierInfo.Controls.Add(this.bSaveSupplier);
            this.gbSupplierInfo.Controls.Add(this.tpSupplierName);
            this.gbSupplierInfo.Controls.Add(this.tpSupplierInfo);
            this.gbSupplierInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSupplierInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbSupplierInfo.Location = new System.Drawing.Point(0, 357);
            this.gbSupplierInfo.Name = "gbSupplierInfo";
            this.gbSupplierInfo.Size = new System.Drawing.Size(920, 263);
            this.gbSupplierInfo.TabIndex = 6;
            this.gbSupplierInfo.TabStop = false;
            this.gbSupplierInfo.Text = "Dane produktu";
            // 
            // bSaveSupplier
            // 
            this.bSaveSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSaveSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSaveSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveSupplier.Location = new System.Drawing.Point(812, 190);
            this.bSaveSupplier.Margin = new System.Windows.Forms.Padding(5);
            this.bSaveSupplier.Name = "bSaveSupplier";
            this.bSaveSupplier.Size = new System.Drawing.Size(100, 50);
            this.bSaveSupplier.TabIndex = 1;
            this.bSaveSupplier.Text = "Zapisz";
            this.bSaveSupplier.UseVisualStyleBackColor = false;
            this.bSaveSupplier.Click += new System.EventHandler(this.bSaveSupplier_Click);
            // 
            // tpSupplierName
            // 
            this.tpSupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierName.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierName.ColumnCount = 2;
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tpSupplierName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierName.Controls.Add(this.tbSupplierName, 1, 0);
            this.tpSupplierName.Controls.Add(this.lSupplierName, 0, 0);
            this.tpSupplierName.Location = new System.Drawing.Point(6, 25);
            this.tpSupplierName.Name = "tpSupplierName";
            this.tpSupplierName.RowCount = 1;
            this.tpSupplierName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierName.Size = new System.Drawing.Size(450, 40);
            this.tpSupplierName.TabIndex = 0;
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSupplierName.Location = new System.Drawing.Point(217, 6);
            this.tbSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(213, 26);
            this.tbSupplierName.TabIndex = 1;
            this.tbSupplierName.MouseHover += new System.EventHandler(this.tbSupplierName_MouseHover);
            this.tbSupplierName.Validating += new System.ComponentModel.CancelEventHandler(this.tbSupplierName_Validating);
            // 
            // lSupplierName
            // 
            this.lSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierName.ForeColor = System.Drawing.Color.Black;
            this.lSupplierName.Location = new System.Drawing.Point(6, 6);
            this.lSupplierName.Margin = new System.Windows.Forms.Padding(5);
            this.lSupplierName.Name = "lSupplierName";
            this.lSupplierName.Size = new System.Drawing.Size(200, 30);
            this.lSupplierName.TabIndex = 0;
            this.lSupplierName.Text = "Nazwa dostawcy";
            this.lSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpSupplierInfo
            // 
            this.tpSupplierInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpSupplierInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpSupplierInfo.ColumnCount = 1;
            this.tpSupplierInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpSupplierInfo.Controls.Add(this.lSupplierInfo, 0, 0);
            this.tpSupplierInfo.Controls.Add(this.rtbSupplierInfo, 0, 1);
            this.tpSupplierInfo.Location = new System.Drawing.Point(462, 25);
            this.tpSupplierInfo.Name = "tpSupplierInfo";
            this.tpSupplierInfo.RowCount = 3;
            this.tpSupplierInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpSupplierInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpSupplierInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpSupplierInfo.Size = new System.Drawing.Size(450, 157);
            this.tpSupplierInfo.TabIndex = 12;
            // 
            // lSupplierInfo
            // 
            this.lSupplierInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lSupplierInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSupplierInfo.ForeColor = System.Drawing.Color.Black;
            this.lSupplierInfo.Location = new System.Drawing.Point(4, 4);
            this.lSupplierInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lSupplierInfo.Name = "lSupplierInfo";
            this.lSupplierInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lSupplierInfo.Size = new System.Drawing.Size(442, 34);
            this.lSupplierInfo.TabIndex = 0;
            this.lSupplierInfo.Text = "Informacje o dostawcy";
            this.lSupplierInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbSupplierInfo
            // 
            this.rtbSupplierInfo.BackColor = System.Drawing.SystemColors.Info;
            this.rtbSupplierInfo.Location = new System.Drawing.Point(6, 47);
            this.rtbSupplierInfo.Margin = new System.Windows.Forms.Padding(5);
            this.rtbSupplierInfo.MaxLength = 1024;
            this.rtbSupplierInfo.Name = "rtbSupplierInfo";
            this.rtbSupplierInfo.Size = new System.Drawing.Size(425, 78);
            this.rtbSupplierInfo.TabIndex = 0;
            this.rtbSupplierInfo.Text = "";
            this.rtbSupplierInfo.Validating += new System.ComponentModel.CancelEventHandler(this.rtbSupplierInfo_Validating);
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 7;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.lName);
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.panel1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Padding = new System.Windows.Forms.Padding(2);
            this.pHeader.Size = new System.Drawing.Size(920, 30);
            this.pHeader.TabIndex = 8;
            // 
            // lName
            // 
            this.lName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(22, 2);
            this.lName.Margin = new System.Windows.Forms.Padding(3);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(896, 26);
            this.lName.TabIndex = 7;
            this.lName.Text = "lName";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDummyForCtrl.Location = new System.Drawing.Point(2, 2);
            this.tbDummyForCtrl.Multiline = true;
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(20, 26);
            this.tbDummyForCtrl.TabIndex = 6;
            this.tbDummyForCtrl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
            // 
            // AddManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.gbSupplierInfo);
            this.Controls.Add(this.gbManufacturerInfo);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "AddManufacturer";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.AddManufacturer_Load);
            this.gbManufacturerInfo.ResumeLayout(false);
            this.tpManufacturer.ResumeLayout(false);
            this.tpManufacturer.PerformLayout();
            this.tpBarcodePrefix.ResumeLayout(false);
            this.tpBarcodePrefix.PerformLayout();
            this.pManufacturerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbSupplierInfo.ResumeLayout(false);
            this.tpSupplierName.ResumeLayout(false);
            this.tpSupplierName.PerformLayout();
            this.tpSupplierInfo.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbManufacturerInfo;
        private System.Windows.Forms.TableLayoutPanel pManufacturerInfo;
        private System.Windows.Forms.Label lManufacturerInfo;
        private System.Windows.Forms.RichTextBox rtbManufacturerInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tpBarcodePrefix;
        private System.Windows.Forms.TextBox tbBarcodePrefix;
        private System.Windows.Forms.Label lBarcodePrefix;
        private System.Windows.Forms.TableLayoutPanel tpManufacturer;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.TextBox tbManufacturerName;
        private System.Windows.Forms.GroupBox gbSupplierInfo;
        private System.Windows.Forms.TableLayoutPanel tpSupplierName;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.Label lSupplierName;
        private System.Windows.Forms.TableLayoutPanel tpSupplierInfo;
        private System.Windows.Forms.Label lSupplierInfo;
        private System.Windows.Forms.RichTextBox rtbSupplierInfo;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bSaveSupplier;
        private System.Windows.Forms.Button bSaveManufacturer;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Panel panel1;
    }
}