using System;
using System.Collections.Generic;
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
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public Playground()
        {
            InitializeComponent();

            this.TestSearchBar = new SearchBarTemplate(true);
            pTest.Controls.Add(this.TestSearchBar);
            this.TestSearchBar.NewEntSelected += TestSearchBar_NewEntSelected;
            this.TestSearchBar.GenericButtonClick += TestSearchBar_GenericButtonClick;
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
            Product product = e.SelectedProduct;
        }

        #endregion

        private void bUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }


        private void Playground_Load(object sender, EventArgs e)
        {
           
        }

        private void bTestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
