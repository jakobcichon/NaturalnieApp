
namespace NaturalnieApp.Forms.Common
{
    partial class StatusBar
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
            this.pbCashRegisterCommunication = new System.Windows.Forms.PictureBox();
            this.pbDbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCashRegisterCommunication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCashRegisterCommunication
            // 
            this.pbCashRegisterCommunication.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbCashRegisterCommunication.Image = global::NaturalnieApp.Properties.Resources.cashRegisterOffline;
            this.pbCashRegisterCommunication.Location = new System.Drawing.Point(0, 0);
            this.pbCashRegisterCommunication.Margin = new System.Windows.Forms.Padding(0);
            this.pbCashRegisterCommunication.MaximumSize = new System.Drawing.Size(60, 30);
            this.pbCashRegisterCommunication.MinimumSize = new System.Drawing.Size(30, 30);
            this.pbCashRegisterCommunication.Name = "pbCashRegisterCommunication";
            this.pbCashRegisterCommunication.Size = new System.Drawing.Size(30, 30);
            this.pbCashRegisterCommunication.TabIndex = 8;
            this.pbCashRegisterCommunication.TabStop = false;
            this.pbCashRegisterCommunication.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseDown);
            this.pbCashRegisterCommunication.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseMove);
            this.pbCashRegisterCommunication.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseUp);
            // 
            // pbDbStatus
            // 
            this.pbDbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbDbStatus.Image = global::NaturalnieApp.Properties.Resources.DbStatusNok;
            this.pbDbStatus.Location = new System.Drawing.Point(30, 0);
            this.pbDbStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pbDbStatus.Name = "pbDbStatus";
            this.pbDbStatus.Size = new System.Drawing.Size(30, 30);
            this.pbDbStatus.TabIndex = 9;
            this.pbDbStatus.TabStop = false;
            this.pbDbStatus.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pbDbStatus_ControlAdded);
            this.pbDbStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseDown);
            this.pbDbStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseMove);
            this.pbDbStatus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralEvent_MouseUp);
            // 
            // StatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbDbStatus);
            this.Controls.Add(this.pbCashRegisterCommunication);
            this.Name = "StatusBar";
            this.Size = new System.Drawing.Size(150, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pbCashRegisterCommunication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDbStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCashRegisterCommunication;
        private System.Windows.Forms.PictureBox pbDbStatus;
    }
}
