
namespace NaturalnieApp.Forms.Common
{
    partial class ProgressBarTemplate
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
            this.tpProgress = new System.Windows.Forms.TableLayoutPanel();
            this.lElapsedTime = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lElapsedTimeValues = new System.Windows.Forms.Label();
            this.tProgressTime = new System.Timers.Timer();
            this.tStatusTimer = new System.Timers.Timer();
            this.tpProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tProgressTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatusTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // tpProgress
            // 
            this.tpProgress.ColumnCount = 3;
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tpProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpProgress.Controls.Add(this.lElapsedTime, 0, 0);
            this.tpProgress.Controls.Add(this.pbProgress, 2, 0);
            this.tpProgress.Controls.Add(this.lElapsedTimeValues, 1, 0);
            this.tpProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpProgress.Location = new System.Drawing.Point(0, 0);
            this.tpProgress.Name = "tpProgress";
            this.tpProgress.Padding = new System.Windows.Forms.Padding(1);
            this.tpProgress.RowCount = 1;
            this.tpProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpProgress.Size = new System.Drawing.Size(346, 50);
            this.tpProgress.TabIndex = 30;
            // 
            // lElapsedTime
            // 
            this.lElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElapsedTime.Location = new System.Drawing.Point(4, 1);
            this.lElapsedTime.Name = "lElapsedTime";
            this.lElapsedTime.Size = new System.Drawing.Size(104, 48);
            this.lElapsedTime.TabIndex = 0;
            this.lElapsedTime.Text = "Czas trwania";
            this.lElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProgress.Location = new System.Drawing.Point(174, 4);
            this.pbProgress.MarqueeAnimationSpeed = 1;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(168, 42);
            this.pbProgress.TabIndex = 2;
            // 
            // lElapsedTimeValues
            // 
            this.lElapsedTimeValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lElapsedTimeValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lElapsedTimeValues.Location = new System.Drawing.Point(114, 1);
            this.lElapsedTimeValues.Name = "lElapsedTimeValues";
            this.lElapsedTimeValues.Size = new System.Drawing.Size(54, 48);
            this.lElapsedTimeValues.TabIndex = 3;
            this.lElapsedTimeValues.Text = "00:00";
            this.lElapsedTimeValues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tProgressTime
            // 
            this.tProgressTime.Interval = 1000D;
            this.tProgressTime.SynchronizingObject = this;
            this.tProgressTime.Elapsed += new System.Timers.ElapsedEventHandler(this.tProgressTime_Tick);
            // 
            // tStatusTimer
            // 
            this.tStatusTimer.SynchronizingObject = this;
            this.tStatusTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.tStatusTimer_Tick);
            // 
            // ProgressBarTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(227)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.tpProgress);
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(340, 30);
            this.Name = "ProgressBarTemplate";
            this.Size = new System.Drawing.Size(346, 50);
            this.Resize += new System.EventHandler(this.ProgressBarTemplate_Resize);
            this.tpProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tProgressTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatusTimer)).EndInit();
            this.ResumeLayout(false);

        }

        private void TProgressTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpProgress;
        private System.Windows.Forms.Label lElapsedTime;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Timers.Timer tProgressTime;
        private System.Timers.Timer tStatusTimer;
        private System.Windows.Forms.Label lElapsedTimeValues;
    }
}
