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

        private void FillDataFromObject(Product obj)
        {
            //Supplier name
            //need to  add

            //Elzab product number
            this.tbElzabProductNumber.Text = obj.ElzabProductId.ToString();
            this.tbPrice.Text = obj.PriceNet.ToString();
            this.cbTax.Text = obj.Tax.ToString();
            this.tbMarigin.Text = obj.Marigin.ToString();
            this.tbBarCode.Text = obj.BarCode.ToString();
            this.rtbProductInfo.Text = obj.ProductInfo.ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void ShowProductInfo_Load(object sender, EventArgs e)
        {
            //Get product name list and product suppliers
            List<string> productNameList = this.databaseCommands.GetProductsNameList();
            List<string> productSuppliersList = this.databaseCommands.GetSuppliersNameList();

            //Add fetched data to proper combo box
            cbProductList.Items.AddRange(productNameList.ToArray());
            cbManufacturer.Items.Clear();
            cbManufacturer.Items.Add("Wszyscy");
            cbManufacturer.Items.AddRange(productSuppliersList.ToArray());
        }


        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbManufacturer.SelectedIndex != 0)
            {
                //Fetch filtered information from database
                List<string> filteredProductNames = this.databaseCommands.GetProductsNameListByManufacturer(cbManufacturer.SelectedItem.ToString());
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(filteredProductNames.ToArray());

            }
            else
            {
                //Fetch filtered information from database
                List<string> productNames = this.databaseCommands.GetProductsNameList();
                cbProductList.Items.Clear();
                cbProductList.Items.AddRange(productNames.ToArray());
            }

        }

        private void tbSuppierName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSuppierName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int value;
            bool success = int.TryParse(tbSuppierName.Text, out value);
            if (!success)
            {
                errorProvider1.SetError(tbSuppierName, "Numer w kasie Elzab musi być wartością numeryczną");
            }
        }

        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product entity = this.databaseCommands.GetProductEntityByProductName(this.cbProductList.SelectedItem.ToString());

            this.FillDataFromObject(entity);
        }
    }
}
