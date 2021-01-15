using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NaturalnieApp.Dymo_Printer;


namespace NaturalnieApp.Forms
{
    public partial class DymoSettings : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public DymoSettings()
        {
            InitializeComponent();
        }
        #endregion

        private void bUpdate_Click(object sender, EventArgs e)
        {
            List<string> test = PrinterMethods.GetPrintersNameList();
            ;
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }
    }
}
