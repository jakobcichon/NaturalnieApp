using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class FullSalesHistory
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbDummyForCtrl = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pButtonsPanel = new System.Windows.Forms.Panel();
            this.bSaveToFile = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tlpSummarizedData = new System.Windows.Forms.TableLayoutPanel();
            this.tbSummarizedSale = new System.Windows.Forms.TextBox();
            this.tbNumberOfProducts = new System.Windows.Forms.TextBox();
            this.tbSummarizedProfit = new System.Windows.Forms.TextBox();
            this.tbSummarizedDiscount = new System.Windows.Forms.TextBox();
            this.lSummarizedProfit = new System.Windows.Forms.Label();
            this.lSummarizedDiscount = new System.Windows.Forms.Label();
            this.lSummarizedSale = new System.Windows.Forms.Label();
            this.lNumberOfProducts = new System.Windows.Forms.Label();
            this.lNumberOfSales = new System.Windows.Forms.Label();
            this.tbNumberOfSales = new System.Windows.Forms.TextBox();
            this.pProgressPanel = new System.Windows.Forms.Panel();
            this.lPercentageProgress = new System.Windows.Forms.Label();
            this.lProgressText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateRelatedSearch1 = new NaturalnieApp.Forms.Common.DateRelatedSearch();
            this.pHeader.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.tlpSummarizedData.SuspendLayout();
            this.pProgressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 0;
            // 
            // tbDummyForCtrl
            // 
            this.tbDummyForCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbDummyForCtrl.Name = "tbDummyForCtrl";
            this.tbDummyForCtrl.Size = new System.Drawing.Size(100, 20);
            this.tbDummyForCtrl.TabIndex = 8;
            this.tbDummyForCtrl.Visible = false;
            // 
            // lName
            // 
            this.lName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(2, 2);
            this.lName.Margin = new System.Windows.Forms.Padding(3);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(916, 26);
            this.lName.TabIndex = 7;
            this.lName.Text = "lName";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.tbDummyForCtrl);
            this.pHeader.Controls.Add(this.lName);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Padding = new System.Windows.Forms.Padding(2);
            this.pHeader.Size = new System.Drawing.Size(920, 30);
            this.pHeader.TabIndex = 1;
            // 
            // pButtonsPanel
            // 
            this.pButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(178)))), ((int)(((byte)(148)))));
            this.pButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pButtonsPanel.Controls.Add(this.bSaveToFile);
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 7;
            // 
            // bSaveToFile
            // 
            this.bSaveToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bSaveToFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveToFile.Location = new System.Drawing.Point(705, 7);
            this.bSaveToFile.Name = "bSaveToFile";
            this.bSaveToFile.Size = new System.Drawing.Size(100, 50);
            this.bSaveToFile.TabIndex = 8;
            this.bSaveToFile.Text = "Zapisz do pliku";
            this.bSaveToFile.UseMnemonic = false;
            this.bSaveToFile.UseVisualStyleBackColor = false;
            this.bSaveToFile.Click += new System.EventHandler(this.bSaveToFile_Click);
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
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(154)))), ((int)(((byte)(121)))));
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUpdate.Location = new System.Drawing.Point(813, 7);
            this.bUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(100, 50);
            this.bUpdate.TabIndex = 0;
            this.bUpdate.Text = "Odśwież";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(6, 142);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(908, 400);
            this.advancedDataGridView1.TabIndex = 9;
            this.advancedDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.advancedDataGridView1_UserDeletedRow);
            this.advancedDataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.advancedDataGridView1_UserDeletingRow);
            // 
            // tlpSummarizedData
            // 
            this.tlpSummarizedData.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpSummarizedData.ColumnCount = 5;
            this.tlpSummarizedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSummarizedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSummarizedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSummarizedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSummarizedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tlpSummarizedData.Controls.Add(this.tbSummarizedSale, 0, 1);
            this.tlpSummarizedData.Controls.Add(this.tbNumberOfProducts, 0, 1);
            this.tlpSummarizedData.Controls.Add(this.tbSummarizedProfit, 2, 1);
            this.tlpSummarizedData.Controls.Add(this.tbSummarizedDiscount, 1, 1);
            this.tlpSummarizedData.Controls.Add(this.lSummarizedProfit, 4, 0);
            this.tlpSummarizedData.Controls.Add(this.lSummarizedDiscount, 3, 0);
            this.tlpSummarizedData.Controls.Add(this.lSummarizedSale, 2, 0);
            this.tlpSummarizedData.Controls.Add(this.lNumberOfProducts, 1, 0);
            this.tlpSummarizedData.Controls.Add(this.lNumberOfSales, 0, 0);
            this.tlpSummarizedData.Controls.Add(this.tbNumberOfSales, 0, 1);
            this.tlpSummarizedData.Location = new System.Drawing.Point(6, 547);
            this.tlpSummarizedData.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSummarizedData.Name = "tlpSummarizedData";
            this.tlpSummarizedData.RowCount = 2;
            this.tlpSummarizedData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSummarizedData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSummarizedData.Size = new System.Drawing.Size(908, 66);
            this.tlpSummarizedData.TabIndex = 11;
            // 
            // tbSummarizedSale
            // 
            this.tbSummarizedSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSummarizedSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSummarizedSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSummarizedSale.Location = new System.Drawing.Point(309, 38);
            this.tbSummarizedSale.Margin = new System.Windows.Forms.Padding(5);
            this.tbSummarizedSale.Name = "tbSummarizedSale";
            this.tbSummarizedSale.Size = new System.Drawing.Size(162, 22);
            this.tbSummarizedSale.TabIndex = 9;
            this.tbSummarizedSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbNumberOfProducts
            // 
            this.tbNumberOfProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumberOfProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberOfProducts.Location = new System.Drawing.Point(182, 38);
            this.tbNumberOfProducts.Margin = new System.Windows.Forms.Padding(5);
            this.tbNumberOfProducts.Name = "tbNumberOfProducts";
            this.tbNumberOfProducts.Size = new System.Drawing.Size(116, 22);
            this.tbNumberOfProducts.TabIndex = 8;
            this.tbNumberOfProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSummarizedProfit
            // 
            this.tbSummarizedProfit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSummarizedProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSummarizedProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSummarizedProfit.Location = new System.Drawing.Point(689, 38);
            this.tbSummarizedProfit.Margin = new System.Windows.Forms.Padding(5);
            this.tbSummarizedProfit.Name = "tbSummarizedProfit";
            this.tbSummarizedProfit.Size = new System.Drawing.Size(221, 22);
            this.tbSummarizedProfit.TabIndex = 7;
            this.tbSummarizedProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSummarizedDiscount
            // 
            this.tbSummarizedDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSummarizedDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSummarizedDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSummarizedDiscount.Location = new System.Drawing.Point(482, 38);
            this.tbSummarizedDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.tbSummarizedDiscount.Name = "tbSummarizedDiscount";
            this.tbSummarizedDiscount.Size = new System.Drawing.Size(196, 22);
            this.tbSummarizedDiscount.TabIndex = 6;
            this.tbSummarizedDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSummarizedProfit
            // 
            this.lSummarizedProfit.AutoSize = true;
            this.lSummarizedProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSummarizedProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSummarizedProfit.Location = new System.Drawing.Point(687, 1);
            this.lSummarizedProfit.Name = "lSummarizedProfit";
            this.lSummarizedProfit.Size = new System.Drawing.Size(225, 31);
            this.lSummarizedProfit.TabIndex = 5;
            this.lSummarizedProfit.Text = "Sumaryczny zysk";
            this.lSummarizedProfit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSummarizedDiscount
            // 
            this.lSummarizedDiscount.AutoSize = true;
            this.lSummarizedDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSummarizedDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSummarizedDiscount.Location = new System.Drawing.Point(480, 1);
            this.lSummarizedDiscount.Name = "lSummarizedDiscount";
            this.lSummarizedDiscount.Size = new System.Drawing.Size(200, 31);
            this.lSummarizedDiscount.TabIndex = 3;
            this.lSummarizedDiscount.Text = "Wartoś wszystkich rabatów";
            this.lSummarizedDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSummarizedSale
            // 
            this.lSummarizedSale.AutoSize = true;
            this.lSummarizedSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSummarizedSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSummarizedSale.Location = new System.Drawing.Point(307, 1);
            this.lSummarizedSale.Name = "lSummarizedSale";
            this.lSummarizedSale.Size = new System.Drawing.Size(166, 31);
            this.lSummarizedSale.TabIndex = 2;
            this.lSummarizedSale.Text = "Sumaryczna sprzedaż";
            this.lSummarizedSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lNumberOfProducts
            // 
            this.lNumberOfProducts.AutoSize = true;
            this.lNumberOfProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNumberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfProducts.Location = new System.Drawing.Point(180, 1);
            this.lNumberOfProducts.Name = "lNumberOfProducts";
            this.lNumberOfProducts.Size = new System.Drawing.Size(120, 31);
            this.lNumberOfProducts.TabIndex = 1;
            this.lNumberOfProducts.Text = "Ilość produktów";
            this.lNumberOfProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lNumberOfSales
            // 
            this.lNumberOfSales.AutoSize = true;
            this.lNumberOfSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNumberOfSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfSales.Location = new System.Drawing.Point(4, 1);
            this.lNumberOfSales.Name = "lNumberOfSales";
            this.lNumberOfSales.Size = new System.Drawing.Size(169, 31);
            this.lNumberOfSales.TabIndex = 0;
            this.lNumberOfSales.Text = "Ilość pozycji sprzedaży";
            this.lNumberOfSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNumberOfSales
            // 
            this.tbNumberOfSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumberOfSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumberOfSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberOfSales.Location = new System.Drawing.Point(6, 38);
            this.tbNumberOfSales.Margin = new System.Windows.Forms.Padding(5);
            this.tbNumberOfSales.Name = "tbNumberOfSales";
            this.tbNumberOfSales.Size = new System.Drawing.Size(165, 22);
            this.tbNumberOfSales.TabIndex = 4;
            this.tbNumberOfSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pProgressPanel
            // 
            this.pProgressPanel.BackColor = System.Drawing.Color.White;
            this.pProgressPanel.Controls.Add(this.lPercentageProgress);
            this.pProgressPanel.Controls.Add(this.lProgressText);
            this.pProgressPanel.Controls.Add(this.pictureBox1);
            this.pProgressPanel.Location = new System.Drawing.Point(300, 226);
            this.pProgressPanel.Name = "pProgressPanel";
            this.pProgressPanel.Size = new System.Drawing.Size(319, 218);
            this.pProgressPanel.TabIndex = 12;
            // 
            // lPercentageProgress
            // 
            this.lPercentageProgress.AutoSize = true;
            this.lPercentageProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPercentageProgress.Location = new System.Drawing.Point(144, 72);
            this.lPercentageProgress.Name = "lPercentageProgress";
            this.lPercentageProgress.Size = new System.Drawing.Size(54, 20);
            this.lPercentageProgress.TabIndex = 2;
            this.lPercentageProgress.Text = "100%";
            this.lPercentageProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lProgressText
            // 
            this.lProgressText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProgressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lProgressText.Location = new System.Drawing.Point(0, 172);
            this.lProgressText.Name = "lProgressText";
            this.lProgressText.Size = new System.Drawing.Size(319, 46);
            this.lProgressText.TabIndex = 1;
            this.lProgressText.Text = "Przykładowy text";
            this.lProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::NaturalnieApp.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dateRelatedSearch1
            // 
            this.dateRelatedSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.dateRelatedSearch1.ForeColor = System.Drawing.Color.Black;
            this.dateRelatedSearch1.IsBussy = false;
            this.dateRelatedSearch1.Location = new System.Drawing.Point(0, 30);
            this.dateRelatedSearch1.MinimumSize = new System.Drawing.Size(920, 106);
            this.dateRelatedSearch1.Name = "dateRelatedSearch1";
            this.dateRelatedSearch1.Size = new System.Drawing.Size(920, 106);
            this.dateRelatedSearch1.TabIndex = 10;
            this.dateRelatedSearch1.NewEntSelected += new NaturalnieApp.Forms.Common.DateRelatedSearch.NewEntSelectedEventHandler(this.dateRelatedSearch1_NewEntSelected);
            // 
            // FullSalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pProgressPanel);
            this.Controls.Add(this.tlpSummarizedData);
            this.Controls.Add(this.dateRelatedSearch1);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FullSalesHistory";
            this.Size = new System.Drawing.Size(920, 690);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.tlpSummarizedData.ResumeLayout(false);
            this.tlpSummarizedData.PerformLayout();
            this.pProgressPanel.ResumeLayout(false);
            this.pProgressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void AdvancedDataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbDummyForCtrl;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pButtonsPanel;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bUpdate;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private Common.DateRelatedSearch dateRelatedSearch1;
        private System.Windows.Forms.Button bSaveToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tlpSummarizedData;
        private System.Windows.Forms.Label lSummarizedDiscount;
        private System.Windows.Forms.Label lSummarizedSale;
        private System.Windows.Forms.Label lNumberOfProducts;
        private System.Windows.Forms.Label lNumberOfSales;
        private System.Windows.Forms.Label lSummarizedProfit;
        private System.Windows.Forms.TextBox tbNumberOfSales;
        private System.Windows.Forms.TextBox tbSummarizedSale;
        private System.Windows.Forms.TextBox tbNumberOfProducts;
        private System.Windows.Forms.TextBox tbSummarizedProfit;
        private System.Windows.Forms.TextBox tbSummarizedDiscount;
        private System.Windows.Forms.Panel pProgressPanel;
        private System.Windows.Forms.Label lPercentageProgress;
        private System.Windows.Forms.Label lProgressText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}