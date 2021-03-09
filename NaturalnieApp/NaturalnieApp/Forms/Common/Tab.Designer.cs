
namespace NaturalnieApp.Forms.Common
{
    partial class Tab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lText = new System.Windows.Forms.Label();
            this.pBottomLine = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lText
            // 
            this.lText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lText.Location = new System.Drawing.Point(0, 0);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(150, 25);
            this.lText.TabIndex = 0;
            this.lText.Text = "lText";
            this.lText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBottomLine
            // 
            this.pBottomLine.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pBottomLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomLine.Location = new System.Drawing.Point(0, 20);
            this.pBottomLine.Name = "pBottomLine";
            this.pBottomLine.Size = new System.Drawing.Size(150, 5);
            this.pBottomLine.TabIndex = 1;
            // 
            // Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pBottomLine);
            this.Controls.Add(this.lText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tab";
            this.Size = new System.Drawing.Size(150, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.Panel pBottomLine;
    }
}
