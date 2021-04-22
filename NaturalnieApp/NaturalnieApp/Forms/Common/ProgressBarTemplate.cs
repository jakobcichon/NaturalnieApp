using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturalnieApp.Forms.Common
{
    public partial class ProgressBarTemplate : UserControl
    {

        #region Class properties
        int ProgressTimerSeconds { get; set; }
        int ProgressTimerMinutes { get; set; }
        int Increment { get; set; }
        int IncrementPerInterval { get; set; }
        int MaxIntervalTime { get; set; }
        bool IsTimeUpdateUsed { get; set; }
        #endregion

        #region Class constructor
        public ProgressBarTemplate()
        {
            //Call setup method
            Setup();

            //Adjust appearance of search bar
            AdjustSearchBarAppearance();
        }
        #endregion

        #region Public methods
        public void StatusBarSettings(int increment = 1, bool isTimeUpdateUsed = true, double durationTime = 1.0)
        {
            //Progress bar settings
            this.pbProgress.Value = 0;
            this.IsTimeUpdateUsed = isTimeUpdateUsed;
            this.Increment = increment;
            this.tProgressTime.Enabled = true;
            this.tStatusTimer.Enabled = true;

            //Timer settings
            this.tStatusTimer.Stop();
            StopProgressTimer();
             if(this.IsTimeUpdateUsed)
            {
                int convertedtime = Convert.ToInt32(durationTime * 1000);

                int optimalIntervalTime = FindOptimalIntervalTime(durationTime, this.pbProgress.Maximum, this.MaxIntervalTime);
                this.tStatusTimer.Interval = optimalIntervalTime;

                this.IncrementPerInterval = this.pbProgress.Maximum / (convertedtime / optimalIntervalTime);
                this.pbProgress.Step = this.IncrementPerInterval;
            }
            else this.pbProgress.Step = this.Increment;
        }

        private int FindOptimalIntervalTime(double durationTime, int maxProgressValue, int maxIntervalTime)
        {
            int intervalTime = maxIntervalTime, lastIncrementPerInterval = 0, i = 0;

            //Convert time to ms
            int convertedtime = Convert.ToInt32(durationTime * 1000);

            //If duration less then maxInterval time, return max interval time
            if (maxIntervalTime > convertedtime) return maxIntervalTime;

            while (true)
            {
                lastIncrementPerInterval = (convertedtime / intervalTime);
                if (lastIncrementPerInterval <= 10)
                {
                    return intervalTime;
                }
                else
                {
                    intervalTime += maxIntervalTime;
                }

                i++;

                if (i >= 100) return intervalTime;
            }


        }

        public void StartByTimer()
        {
            StartProgressTimer();
            this.pbProgress.Value = 0;
            if (this.IsTimeUpdateUsed && !this.tStatusTimer.Enabled) this.tStatusTimer.Start();

        }
        public void Reset()
        {
            StopProgressTimer();
            this.tStatusTimer.Stop();
            this.pbProgress.Value = 0;
        }

        public void StatusBarUpdate(int actualValue)
        {
            if(this.IsTimeUpdateUsed) this.tStatusTimer.Stop();
            this.pbProgress.Value = actualValue;
            if (this.IsTimeUpdateUsed) this.tStatusTimer.Start();
        }
        #endregion

        #region General methods
        //Setup method
        private void Setup()
        {
            //Initialize component
            InitializeComponent();

            //Set double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);

            //Initialize properties
            this.IsTimeUpdateUsed = true;
            this.ProgressTimerSeconds = 0;
            this.ProgressTimerMinutes = 0;
            this.pbProgress.Maximum = 100;
            this.Increment = 1;
            this.MaxIntervalTime = 500;
            StopProgressTimer();
            this.tProgressTime.Stop();
        }

        //Mathod used to adjusted search bar appearance
        private void AdjustSearchBarAppearance()
        {
            //Basic layout settings
            this.tpProgress.ColumnStyles[2].Width = this.Width - this.tpProgress.ColumnStyles[0].Width - this.tpProgress.ColumnStyles[1].Width;

            //Progress bar settings
            this.pbProgress.MarqueeAnimationSpeed = 1;
            this.pbProgress.Step = 1;
        }

        #endregion

        #region Progress time related
        private void tProgressTime_Tick(object sender, EventArgs e)
        {
            //Increment seconds
            this.ProgressTimerSeconds += 1;

            //If minutes equals 99, stop timer
            if (this.ProgressTimerMinutes >= 99 && this.ProgressTimerSeconds >= 60)
            {
                StopProgressTimer();
            }
            //If match 60, increment minutes
            else if (this.ProgressTimerSeconds >= 60)
            {
                this.ProgressTimerMinutes += 1;
                this.ProgressTimerSeconds = 0;
            }

            UpdateTimeDisplay();

        }

        public void StopProgressTimer()
        {
            this.tProgressTime.Stop();
            UpdateTimeDisplay();
        }

        public void StartProgressTimer()
        {
            this.ProgressTimerSeconds = 0;
            this.ProgressTimerMinutes = 0;
            UpdateTimeDisplay();
            this.tProgressTime.Start();
        }

        private void UpdateTimeDisplay()
        {
            this.lElapsedTimeValues.Text = (this.ProgressTimerMinutes.ToString("00") + ":" + this.ProgressTimerSeconds.ToString("00"));
        }
        #endregion

        #region Status timer
        private void tStatusTimer_Tick(object sender, EventArgs e)
        {
            if ((this.pbProgress.Value + this.IncrementPerInterval) > this.pbProgress.Maximum) this.pbProgress.Value = this.pbProgress.Maximum;
            else this.pbProgress.Value += this.IncrementPerInterval;
            if (this.pbProgress.Value >= this.pbProgress.Maximum)
            {
                StopProgressTimer();
                this.tStatusTimer.Stop();
            }
        }
        #endregion

    }
}
