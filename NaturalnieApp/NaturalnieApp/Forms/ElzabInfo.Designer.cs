namespace NaturalnieApp.Forms
{
    partial class ElzabInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pInfo1 = new System.Windows.Forms.Panel();
            this.pInfo1Value = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pInfo1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pInfo1Value);
            this.panel1.Controls.Add(this.pInfo1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 50);
            this.panel1.TabIndex = 1;
            // 
            // pInfo1
            // 
            this.pInfo1.BackColor = System.Drawing.Color.White;
            this.pInfo1.Controls.Add(this.label1);
            this.pInfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pInfo1.Location = new System.Drawing.Point(0, 0);
            this.pInfo1.Name = "pInfo1";
            this.pInfo1.Size = new System.Drawing.Size(200, 50);
            this.pInfo1.TabIndex = 0;
            // 
            // pInfo1Value
            // 
            this.pInfo1Value.Dock = System.Windows.Forms.DockStyle.Left;
            this.pInfo1Value.Location = new System.Drawing.Point(200, 0);
            this.pInfo1Value.Name = "pInfo1Value";
            this.pInfo1Value.Size = new System.Drawing.Size(400, 50);
            this.pInfo1Value.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ElzabInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ElzabInfo";
            this.Text = "Submenu_ElzabInfo";
            this.panel1.ResumeLayout(false);
            this.pInfo1.ResumeLayout(false);
            this.pInfo1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pInfo1Value;
        private System.Windows.Forms.Panel pInfo1;
        private System.Windows.Forms.Label label1;
    }
}