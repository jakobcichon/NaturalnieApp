using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    partial class DisplayHistoryOfProductSale
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
            this.bClose = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.searchBarTemplate1 = new NaturalnieApp.Forms.Common.SearchBarTemplate();
            this.pHeader.SuspendLayout();
            this.pButtonsPanel.SuspendLayout();
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
            this.pButtonsPanel.Controls.Add(this.bClose);
            this.pButtonsPanel.Controls.Add(this.bUpdate);
            this.pButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtonsPanel.Location = new System.Drawing.Point(0, 620);
            this.pButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.pButtonsPanel.Name = "pButtonsPanel";
            this.pButtonsPanel.Size = new System.Drawing.Size(920, 70);
            this.pButtonsPanel.TabIndex = 7;
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
            // 
            // searchBarTemplate1
            // 
            this.searchBarTemplate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.searchBarTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarTemplate1.ForeColor = System.Drawing.Color.Black;
            this.searchBarTemplate1.IsBussy = false;
            this.searchBarTemplate1.Location = new System.Drawing.Point(0, 30);
            this.searchBarTemplate1.MinimumSize = new System.Drawing.Size(920, 106);
            this.searchBarTemplate1.Name = "searchBarTemplate1";
            this.searchBarTemplate1.Size = new System.Drawing.Size(920, 106);
            this.searchBarTemplate1.TabIndex = 8;
            // 
            // DisplayHistoryOfProductSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.searchBarTemplate1);
            this.Controls.Add(this.pButtonsPanel);
            this.Controls.Add(this.pHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "DisplayHistoryOfProductSale";
            this.Size = new System.Drawing.Size(920, 690);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pButtonsPanel.ResumeLayout(false);
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
        private Common.SearchBarTemplate searchBarTemplate1;
    }
}