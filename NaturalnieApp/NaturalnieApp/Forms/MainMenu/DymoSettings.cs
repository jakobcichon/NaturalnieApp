﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NaturalnieApp.Dymo_Printer;
using NaturalnieApp.Forms.Common;

namespace NaturalnieApp.Forms
{
    public partial class DymoSettings : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        Common.SearchBarTemplate TestSearchBar;
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public DymoSettings()
        {
            InitializeComponent();

            this.TestSearchBar = new SearchBarTemplate();
            pTest.Controls.Add(this.TestSearchBar);


        }
        #endregion

        private void bUpdate_Click(object sender, EventArgs e)
        {
            this.TestSearchBar.UpdateCurrentEntity();

            List<string> printersNames = PrinterMethods.GetPrintersNameList();
            if (printersNames.Count != 0)
            {
                cbAvailablePrintersList.Items.Clear();
                int i = 0;
                foreach (string printerName in printersNames)
                {
                    cbAvailablePrintersList.Items.Add(i.ToString() + "." + printerName);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono drukarki dymo");
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {

            if (tbSelectedPrinterName.Text != "")
            {
                int indexOfDeliminer = tbSelectedPrinterName.Text.IndexOf('.');
                int numberOfCharsToCopy = (tbSelectedPrinterName.Text.Length - tbSelectedPrinterName.Text.IndexOf('.')) - 1;
                try
                {
                    Program.GlobalVariables.DymoPrinterName = tbSelectedPrinterName.Text.Substring(indexOfDeliminer + 1, numberOfCharsToCopy);
                    MessageBox.Show("Zapisano!");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Brak drukarki do zapisu!");
            }
        }

        private void cbAvailablePrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAvailablePrintersList.SelectedIndex > -1) tbSelectedPrinterName.Text = cbAvailablePrintersList.SelectedItem.ToString();
        }

        private void DymoSettings_Load(object sender, EventArgs e)
        {
            List<string> printersNames = PrinterMethods.GetPrintersNameList();
            if (printersNames.Count != 0)
            {
                cbAvailablePrintersList.Items.Clear();
                int i = 0;
                foreach (string printerName in printersNames)
                {
                    cbAvailablePrintersList.Items.Add(i.ToString() + "." + printerName);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono drukarki dymo");
            }
        }
    }
}
