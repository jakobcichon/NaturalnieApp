using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class AddToStock
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
            this.lName = new System.Windows.Forms.Label();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bPrint = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.cbAddWithEveryScanCycle = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pSearchBar = new System.Windows.Forms.Panel();
            this.tpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pBottomPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbQuantityOnList = new System.Windows.Forms.TextBox();
            this.lQuantityOnList = new System.Windows.Forms.Label();
            this.tpMarigin = new System.Windows.Forms.TableLayoutPanel();
            this.bMariginChange = new System.Windows.Forms.Button();
            this.lMarigin = new System.Windows.Forms.Label();
            this.tbMarigin = new System.Windows.Forms.TextBox();
            this.tpFinalPrice = new System.Windows.Forms.TableLayoutPanel();
            this.tbFinalPrice = new System.Windows.Forms.TextBox();
            this.lFinalPrice = new System.Windows.Forms.Label();
            this.tpActualQuantity = new System.Windows.Forms.TableLayoutPanel();
            this.lActualQuantity = new System.Windows.Forms.Label();
            this.tbActualQuantity = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chbExpDateReq = new System.Windows.Forms.CheckBox();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lDateOfAccept = new System.Windows.Forms.Label();
            this.dtpDateOfAccept = new System.Windows.Forms.DateTimePicker();
            this.lQuantity = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.pHeader.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            this.tpMainLayout.SuspendLayout();
            this.pBottomPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpMarigin.SuspendLayout();
            this.tpFinalPrice.SuspendLayout();
            this.tpActualQuantity.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.pHeader.TabIndex = 1;
            // 
            // lName
            // 
            this.lName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lName.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tbDummyForCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDummyForCtrl_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 4;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bPrint);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Controls.Add(this.bSave);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 4;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bPrint.Location = new System.Drawing.Point(490, 10);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(100, 50);
            this.bPrint.TabIndex = 33;
            this.bPrint.Text = "Drukuj etykiety";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(596, 10);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 28;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(702, 10);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 50);
            this.bSave.TabIndex = 26;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(808, 10);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(100, 50);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "Zamknij";
            this.bClose.UseMnemonic = false;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // cbAddWithEveryScanCycle
            // 
            this.cbAddWithEveryScanCycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.cbAddWithEveryScanCycle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAddWithEveryScanCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAddWithEveryScanCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAddWithEveryScanCycle.Location = new System.Drawing.Point(584, 4);
            this.cbAddWithEveryScanCycle.Name = "cbAddWithEveryScanCycle";
            this.cbAddWithEveryScanCycle.Size = new System.Drawing.Size(174, 24);
            this.cbAddWithEveryScanCycle.TabIndex = 3;
            this.cbAddWithEveryScanCycle.Text = "Dodaj przy odczycie";
            this.cbAddWithEveryScanCycle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAddWithEveryScanCycle.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(298, 10);
            this.panel5.TabIndex = 0;
            // 
            // pSearchBar
            // 
            this.pSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSearchBar.Location = new System.Drawing.Point(0, 30);
            this.pSearchBar.Margin = new System.Windows.Forms.Padding(5);
            this.pSearchBar.Name = "pSearchBar";
            this.pSearchBar.Size = new System.Drawing.Size(920, 106);
            this.pSearchBar.TabIndex = 36;
            // 
            // tpMainLayout
            // 
            this.tpMainLayout.ColumnCount = 1;
            this.tpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMainLayout.Controls.Add(this.pBottomPanel, 0, 2);
            this.tpMainLayout.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tpMainLayout.Controls.Add(this.advancedDataGridView1, 0, 1);
            this.tpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMainLayout.Location = new System.Drawing.Point(0, 136);
            this.tpMainLayout.Name = "tpMainLayout";
            this.tpMainLayout.RowCount = 3;
            this.tpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tpMainLayout.Size = new System.Drawing.Size(920, 484);
            this.tpMainLayout.TabIndex = 38;
            // 
            // pBottomPanel
            // 
            this.pBottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBottomPanel.Controls.Add(this.tableLayoutPanel1);
            this.pBottomPanel.Controls.Add(this.tpMarigin);
            this.pBottomPanel.Controls.Add(this.tpFinalPrice);
            this.pBottomPanel.Controls.Add(this.tpActualQuantity);
            this.pBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomPanel.Location = new System.Drawing.Point(1, 448);
            this.pBottomPanel.Margin = new System.Windows.Forms.Padding(1);
            this.pBottomPanel.Name = "pBottomPanel";
            this.pBottomPanel.Size = new System.Drawing.Size(918, 35);
            this.pBottomPanel.TabIndex = 38;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbQuantityOnList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lQuantityOnList, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(661, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 35);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // tbQuantityOnList
            // 
            this.tbQuantityOnList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbQuantityOnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantityOnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantityOnList.Location = new System.Drawing.Point(195, 4);
            this.tbQuantityOnList.Name = "tbQuantityOnList";
            this.tbQuantityOnList.ReadOnly = true;
            this.tbQuantityOnList.Size = new System.Drawing.Size(60, 26);
            this.tbQuantityOnList.TabIndex = 31;
            // 
            // lQuantityOnList
            // 
            this.lQuantityOnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lQuantityOnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lQuantityOnList.Location = new System.Drawing.Point(4, 4);
            this.lQuantityOnList.Margin = new System.Windows.Forms.Padding(3);
            this.lQuantityOnList.Name = "lQuantityOnList";
            this.lQuantityOnList.Size = new System.Drawing.Size(184, 27);
            this.lQuantityOnList.TabIndex = 32;
            this.lQuantityOnList.Text = "Ilość produktów na liście";
            this.lQuantityOnList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpMarigin
            // 
            this.tpMarigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpMarigin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpMarigin.ColumnCount = 3;
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tpMarigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMarigin.Controls.Add(this.bMariginChange, 2, 0);
            this.tpMarigin.Controls.Add(this.lMarigin, 0, 0);
            this.tpMarigin.Controls.Add(this.tbMarigin, 1, 0);
            this.tpMarigin.Location = new System.Drawing.Point(1, 0);
            this.tpMarigin.Margin = new System.Windows.Forms.Padding(0);
            this.tpMarigin.Name = "tpMarigin";
            this.tpMarigin.RowCount = 1;
            this.tpMarigin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMarigin.Size = new System.Drawing.Size(242, 35);
            this.tpMarigin.TabIndex = 9;
            // 
            // bMariginChange
            // 
            this.bMariginChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bMariginChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bMariginChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bMariginChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bMariginChange.Location = new System.Drawing.Point(136, 2);
            this.bMariginChange.Margin = new System.Windows.Forms.Padding(1);
            this.bMariginChange.Name = "bMariginChange";
            this.bMariginChange.Size = new System.Drawing.Size(106, 31);
            this.bMariginChange.TabIndex = 34;
            this.bMariginChange.Text = "Zmień";
            this.bMariginChange.UseVisualStyleBackColor = false;
            this.bMariginChange.Click += new System.EventHandler(this.bMariginChange_Click);
            // 
            // lMarigin
            // 
            this.lMarigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMarigin.Location = new System.Drawing.Point(2, 2);
            this.lMarigin.Margin = new System.Windows.Forms.Padding(1);
            this.lMarigin.Name = "lMarigin";
            this.lMarigin.Size = new System.Drawing.Size(64, 31);
            this.lMarigin.TabIndex = 29;
            this.lMarigin.Text = "Marża";
            this.lMarigin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMarigin
            // 
            this.tbMarigin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbMarigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMarigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMarigin.Location = new System.Drawing.Point(71, 4);
            this.tbMarigin.Name = "tbMarigin";
            this.tbMarigin.Size = new System.Drawing.Size(60, 26);
            this.tbMarigin.TabIndex = 33;
            this.tbMarigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMarigin.Validating += new System.ComponentModel.CancelEventHandler(this.tbMarigin_Validating);
            // 
            // tpFinalPrice
            // 
            this.tpFinalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpFinalPrice.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpFinalPrice.ColumnCount = 2;
            this.tpFinalPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tpFinalPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpFinalPrice.Controls.Add(this.tbFinalPrice, 1, 0);
            this.tpFinalPrice.Controls.Add(this.lFinalPrice, 0, 0);
            this.tpFinalPrice.Location = new System.Drawing.Point(243, 0);
            this.tpFinalPrice.Margin = new System.Windows.Forms.Padding(0);
            this.tpFinalPrice.Name = "tpFinalPrice";
            this.tpFinalPrice.RowCount = 1;
            this.tpFinalPrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpFinalPrice.Size = new System.Drawing.Size(193, 35);
            this.tpFinalPrice.TabIndex = 32;
            // 
            // tbFinalPrice
            // 
            this.tbFinalPrice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbFinalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbFinalPrice.Location = new System.Drawing.Point(125, 4);
            this.tbFinalPrice.Name = "tbFinalPrice";
            this.tbFinalPrice.ReadOnly = true;
            this.tbFinalPrice.Size = new System.Drawing.Size(64, 26);
            this.tbFinalPrice.TabIndex = 27;
            // 
            // lFinalPrice
            // 
            this.lFinalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFinalPrice.Location = new System.Drawing.Point(4, 4);
            this.lFinalPrice.Margin = new System.Windows.Forms.Padding(3);
            this.lFinalPrice.Name = "lFinalPrice";
            this.lFinalPrice.Size = new System.Drawing.Size(114, 27);
            this.lFinalPrice.TabIndex = 31;
            this.lFinalPrice.Text = "Cena klienta";
            this.lFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpActualQuantity
            // 
            this.tpActualQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tpActualQuantity.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpActualQuantity.ColumnCount = 2;
            this.tpActualQuantity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tpActualQuantity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpActualQuantity.Controls.Add(this.lActualQuantity, 0, 0);
            this.tpActualQuantity.Controls.Add(this.tbActualQuantity, 1, 0);
            this.tpActualQuantity.Location = new System.Drawing.Point(436, 0);
            this.tpActualQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.tpActualQuantity.Name = "tpActualQuantity";
            this.tpActualQuantity.RowCount = 1;
            this.tpActualQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpActualQuantity.Size = new System.Drawing.Size(225, 35);
            this.tpActualQuantity.TabIndex = 33;
            // 
            // lActualQuantity
            // 
            this.lActualQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lActualQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lActualQuantity.Location = new System.Drawing.Point(4, 4);
            this.lActualQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lActualQuantity.Name = "lActualQuantity";
            this.lActualQuantity.Size = new System.Drawing.Size(144, 27);
            this.lActualQuantity.TabIndex = 30;
            this.lActualQuantity.Text = "Aktualna ilość";
            this.lActualQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbActualQuantity
            // 
            this.tbActualQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbActualQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActualQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbActualQuantity.Location = new System.Drawing.Point(155, 4);
            this.tbActualQuantity.Name = "tbActualQuantity";
            this.tbActualQuantity.ReadOnly = true;
            this.tbActualQuantity.Size = new System.Drawing.Size(66, 26);
            this.tbActualQuantity.TabIndex = 29;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel4.Controls.Add(this.chbExpDateReq, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpExpirationDate, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lDateOfAccept, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpDateOfAccept, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lQuantity, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbQuantity, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbAddWithEveryScanCycle, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(918, 30);
            this.tableLayoutPanel4.TabIndex = 36;
            // 
            // chbExpDateReq
            // 
            this.chbExpDateReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.chbExpDateReq.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbExpDateReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbExpDateReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExpDateReq.Location = new System.Drawing.Point(303, 3);
            this.chbExpDateReq.Margin = new System.Windows.Forms.Padding(2);
            this.chbExpDateReq.Name = "chbExpDateReq";
            this.chbExpDateReq.Padding = new System.Windows.Forms.Padding(2);
            this.chbExpDateReq.Size = new System.Drawing.Size(150, 26);
            this.chbExpDateReq.TabIndex = 2;
            this.chbExpDateReq.Text = "Data ważności";
            this.chbExpDateReq.UseVisualStyleBackColor = false;
            this.chbExpDateReq.CheckedChanged += new System.EventHandler(this.chbExpDateReq_CheckedChanged);
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpirationDate.Location = new System.Drawing.Point(458, 3);
            this.dtpExpirationDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpExpirationDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpExpirationDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(120, 26);
            this.dtpExpirationDate.TabIndex = 7;
            this.dtpExpirationDate.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lDateOfAccept
            // 
            this.lDateOfAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lDateOfAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDateOfAccept.Location = new System.Drawing.Point(3, 3);
            this.lDateOfAccept.Margin = new System.Windows.Forms.Padding(2);
            this.lDateOfAccept.Name = "lDateOfAccept";
            this.lDateOfAccept.Size = new System.Drawing.Size(170, 26);
            this.lDateOfAccept.TabIndex = 3;
            this.lDateOfAccept.Text = "Data przyjęcia towaru";
            this.lDateOfAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateOfAccept
            // 
            this.dtpDateOfAccept.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.CustomFormat = "dd/MM/yyyy";
            this.dtpDateOfAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDateOfAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfAccept.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfAccept.Location = new System.Drawing.Point(178, 3);
            this.dtpDateOfAccept.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateOfAccept.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfAccept.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfAccept.Name = "dtpDateOfAccept";
            this.dtpDateOfAccept.Size = new System.Drawing.Size(120, 26);
            this.dtpDateOfAccept.TabIndex = 5;
            this.dtpDateOfAccept.Value = new System.DateTime(2020, 12, 10, 0, 0, 0, 0);
            // 
            // lQuantity
            // 
            this.lQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(187)))), ((int)(((byte)(160)))));
            this.lQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQuantity.Location = new System.Drawing.Point(764, 3);
            this.lQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.lQuantity.Name = "lQuantity";
            this.lQuantity.Size = new System.Drawing.Size(61, 26);
            this.lQuantity.TabIndex = 2;
            this.lQuantity.Text = "Ilość";
            this.lQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQuantity.Location = new System.Drawing.Point(830, 3);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(85, 26);
            this.tbQuantity.TabIndex = 2;
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.tbQuantity_Validating);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(1, 33);
            this.advancedDataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(918, 413);
            this.advancedDataGridView1.TabIndex = 3;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.AdvancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            this.advancedDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellValueChanged);
            this.advancedDataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.advancedDataGridView1_RowsAdded);
            this.advancedDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.advancedDataGridView1_UserDeletedRow);
            // 
            // AddToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.tpMainLayout);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.pSearchBar);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "AddToStock";
            this.Size = new System.Drawing.Size(920, 690);
            this.Load += new System.EventHandler(this.AddToStock_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
            this.tpMainLayout.ResumeLayout(false);
            this.pBottomPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tpMarigin.ResumeLayout(false);
            this.tpMarigin.PerformLayout();
            this.tpFinalPrice.ResumeLayout(false);
            this.tpFinalPrice.PerformLayout();
            this.tpActualQuantity.ResumeLayout(false);
            this.tpActualQuantity.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.CheckBox cbAddWithEveryScanCycle;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Panel pSearchBar;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TableLayoutPanel tpMainLayout;
        private System.Windows.Forms.Panel pBottomPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbQuantityOnList;
        private System.Windows.Forms.Label lQuantityOnList;
        private System.Windows.Forms.TableLayoutPanel tpMarigin;
        private System.Windows.Forms.Button bMariginChange;
        private System.Windows.Forms.Label lMarigin;
        private System.Windows.Forms.TextBox tbMarigin;
        private System.Windows.Forms.TableLayoutPanel tpFinalPrice;
        private System.Windows.Forms.TextBox tbFinalPrice;
        private System.Windows.Forms.Label lFinalPrice;
        private System.Windows.Forms.TableLayoutPanel tpActualQuantity;
        private System.Windows.Forms.Label lActualQuantity;
        private System.Windows.Forms.TextBox tbActualQuantity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chbExpDateReq;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label lDateOfAccept;
        private System.Windows.Forms.DateTimePicker dtpDateOfAccept;
        private System.Windows.Forms.Label lQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
    }
}