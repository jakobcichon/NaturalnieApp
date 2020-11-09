using System;
using System.CodeDom;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using NaturalnieApp.Database;
using System.Collections.Generic;


namespace NaturalnieApp.Forms
{
    public partial class ShowProductInfo : Form
    {
        DatabaseCommands databaseCommands;
        public ShowProductInfo()
        {
            InitializeComponent();
            this.databaseCommands = new DatabaseCommands();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void ShowProductInfo_Load(object sender, EventArgs e)
        {
            
            List<string> tmp = this.databaseCommands.GetProductsNameList();
            List<string> tmp2 = this.databaseCommands.GetSuppliersNameList();

            cbManufacturer.Items.AddRange(tmp2.ToArray());
            cbProductList.Items.AddRange(tmp.ToArray());
            ;

        }

        private void cbManufacturer_ValueMemberChanged(object sender, EventArgs e)
        {
            List<string> tmp = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturer.SelectedItem.ToString());
            ;
        }
    }
}
