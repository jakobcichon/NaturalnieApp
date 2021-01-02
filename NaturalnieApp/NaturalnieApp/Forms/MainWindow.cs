using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Initialization;
using NaturalnieApp.Database;
using System.Threading;
using System.Runtime.InteropServices;



namespace NaturalnieApp.Forms
{


    public partial class MainWindow : Form
    {
        private ConfigFileObject ConfigFileOjbInst;
        bool dragging = false;
        int xOffset = 0;
        int yOffset = 0;

        //Forms instances
        AddNewProductFromExcel addNewProductFromExcel { get; set; }
        PrintBarcode printBarcode { get; set; }
        ShowProductInfo showProductInfo { get; set; }
        AddNewProduct addNewProduct { get; set; }
        AddToStock addToStock { get; set; }
        AddManufacturer addManufacturer { get; set; }


        //Creat EF databse connection object
        DatabaseCommands databaseCommands;

        public MainWindow(ConfigFileObject conFileObj)
        {
            this.ConfigFileOjbInst = conFileObj;
            InitializeComponent();
            customizeDesign();

            //Initialize EF databse connection object
            this.databaseCommands = new DatabaseCommands();
            //check if Database reachable 
            this.databaseCommands.CheckConnection(true);

            this.addNewProductFromExcel = new AddNewProductFromExcel(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.printBarcode = new PrintBarcode(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.showProductInfo = new ShowProductInfo(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.addNewProduct = new AddNewProduct(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.addToStock = new AddToStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.addManufacturer = new AddManufacturer(ref this.databaseCommands) { TopLevel = false, TopMost = true };

        }

        //====================================================================================================
        //Clipboard events
        #region Clipboard events
        
 
        #endregion

        #region Movable window
        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;

            xOffset = Cursor.Position.X - this.Location.X;
            yOffset = Cursor.Position.Y - this.Location.Y;
        }

        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Location = new Point(Cursor.Position.X - xOffset, Cursor.Position.Y - yOffset);
                this.Update();
            }
        }
        #endregion

        #region Main window general settings
        //Method used to customize initialize menu
        private void customizeDesign()
        {
            pCashRegisterSubMenu.Visible = false;
            pProductSubMenu.Visible = false;
            pStockSubMenu.Visible = false;
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Method used to operate with submenu
        private void hideSubMenu(Panel panel)
        {
            if (panel.Visible == true)
                panel.Visible = false;
        }

        private void toggleSubMenu(Panel panel)
        {
            if (panel.Visible == true)
                panel.Visible = false;
            else panel.Visible = true;
        }
        #endregion 

        #region Cash register submenu

        private void bCashRegisterInfo_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            ElzabInfo frm = new ElzabInfo() { TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frm);
            frm.Show();

        }

        private void bCashRegisterSettings_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            ElzabSettings frm = new ElzabSettings(ConfigFileOjbInst) { TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frm);
            frm.Show();

        }
        private void bCashRegister_Click(object sender, EventArgs e)
        {
            toggleSubMenu(pCashRegisterSubMenu);
        }

        #endregion

        #region Product submenu
        private void bProductMenu_Click(object sender, EventArgs e)
        {
            toggleSubMenu(pProductSubMenu);
        }
        private void bNewProduct_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.addNewProduct);
                this.addNewProduct.Show();
                this.addNewProduct.BringToFront();
                this.addNewProduct.Activate();
            }
            catch (ObjectDisposedException)
            {
                this.addNewProduct = new AddNewProduct(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addNewProduct);
                this.addNewProduct.Show();
                this.addNewProduct.BringToFront();
                this.addNewProduct.Activate();
            }
        }
        private void AddProductFromPdf_Click(object sender, EventArgs e)
        {
            try
            {
                this.pContainer.Controls.Add(this.addNewProductFromExcel);
                this.addNewProductFromExcel.Show();
                this.addNewProductFromExcel.BringToFront();
                this.addNewProductFromExcel.Activate();
            }
            catch (ObjectDisposedException)
            {
                this.addNewProductFromExcel = new AddNewProductFromExcel(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addNewProductFromExcel);
                this.addNewProductFromExcel.Show();
                this.addNewProductFromExcel.BringToFront();
                this.addNewProductFromExcel.Activate();
            }

        }
    
        private void bShowProductInfo_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.showProductInfo);
                this.showProductInfo.Show();
                this.showProductInfo.BringToFront();
                this.showProductInfo.Activate();
            }
            catch (ObjectDisposedException)
            {
                this.showProductInfo = new ShowProductInfo(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.showProductInfo);
                this.showProductInfo.Show();
                this.showProductInfo.BringToFront();
                this.showProductInfo.Activate();
            }
        }

        private void bPrintBarcode_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.printBarcode);
                this.printBarcode.Show();
                this.printBarcode.BringToFront();
                this.printBarcode.Activate();
            }
            catch (ObjectDisposedException)
            {
                this.printBarcode = new PrintBarcode(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.printBarcode);
                this.printBarcode.Show();
                this.printBarcode.BringToFront();
                this.printBarcode.Activate();
            }

        }

        private void bAddManufacturer_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.addManufacturer);
                this.addManufacturer.Show();
                this.addManufacturer.BringToFront();
                this.addManufacturer.Activate();
            }
            catch (ObjectDisposedException)
            {
                this.addManufacturer = new AddManufacturer(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addManufacturer);
                this.addManufacturer.Show();
                this.addManufacturer.BringToFront();
                this.addManufacturer.Activate();
            }
        }

        #endregion

        #region Stock submenu
        private void bStock_Click(object sender, EventArgs e)
        {
            toggleSubMenu(pStockSubMenu);
        }


        private void bAddToStock_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.addToStock);
                this.addToStock.Show();
                this.addToStock.BringToFront();
                this.addToStock.Activate();
                this.addToStock.Focus();
            }
            catch (ObjectDisposedException)
            {
                this.addToStock = new AddToStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addToStock);
                this.addToStock.Show();
                this.addToStock.BringToFront();
                this.addToStock.Activate();
                this.addToStock.Focus();
            }

        }

        #endregion


    }
}
