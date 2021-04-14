using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NaturalnieApp.Database;
using NaturalnieApp.Dymo_Printer;
using NaturalnieApp.Forms.Common;

namespace NaturalnieApp.Forms
{
    public partial class Playground : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        Common.SearchBarTemplate TestSearchBar;
        BackgroundWorker testWorker;
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public Playground()
        {
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

            this.TestSearchBar = new SearchBarTemplate(true);
            pTest.Controls.Add(this.TestSearchBar);
            this.TestSearchBar.NewEntSelected += TestSearchBar_NewEntSelected;
            this.TestSearchBar.GenericButtonClick += TestSearchBar_GenericButtonClick;

            this.testWorker = new BackgroundWorker();
            this.testWorker.ProgressChanged += TestWorker_ProgressChanged;
            this.testWorker.DoWork += TestWorker_DoWork;
            this.testWorker.WorkerReportsProgress = true;
        }

        private void TestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string item in cbTest.Items)
            {
                (sender as BackgroundWorker).ReportProgress(cbTest.Items.IndexOf(item));
                System.Threading.Thread.Sleep(100);

            }
        }

        private void TestWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TestSearchBar.SelectBarcode(cbTest.Items[e.ProgressPercentage].ToString());
        }

        private void TestSearchBar_GenericButtonClick(object sender, SearchBarTemplate.GenericButtonClickEventArgs e)
        {
            ;
        }

        //General methods
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            this.TestSearchBar.Select();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TestSearchBar_NewEntSelected(object sender, SearchBarTemplate.NewEntSelectedEventArgs e)
        {
            textBox1.Text = e.SelectedProduct.BarCode;
        }

        #endregion

        private void bUpdate_Click(object sender, EventArgs e)
        {
            this.TestSearchBar.UpdateCurrentEntity();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }


        private void Playground_Load(object sender, EventArgs e)
        {
           
        }

        private void bTestButton_Click(object sender, EventArgs e)
        {
            //this.testWorker.RunWorkerAsync();

            ;
        }
    }
}
