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
        public AddNewProductFromExcel addNewProductFromExcel { get; set; }
        public PrintBarcode printBarcode { get; set; }
        public ShowProductInfo showProductInfo { get; set; }
        public AddNewProduct addNewProduct { get; set; }
        public AddToStock addToStock { get; set; }
        public AddManufacturer addManufacturer { get; set; }
        public PrintFromStock printFromStock { get; set; }
        public ShowStock showStock { get; set; }

        public DymoSettings dymoSettings { get; set; }


        //Creat EF databse connection object
        DatabaseCommands databaseCommands;

        public MainWindow(ConfigFileObject conFileObj)
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);


            this.ConfigFileOjbInst = conFileObj;
            InitializeComponent();
            customizeDesign();

            //Initialize EF databse connection object
            this.databaseCommands = new DatabaseCommands();
            //check if Database reachable 
            this.databaseCommands.CheckConnection(true);

            this.addNewProductFromExcel = new AddNewProductFromExcel(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.printBarcode = new PrintBarcode(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.showProductInfo = new ShowProductInfo(ref this.databaseCommands) ;
            this.addNewProduct = new AddNewProduct(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.addToStock = new AddToStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.addManufacturer = new AddManufacturer(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.printFromStock = new PrintFromStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.showStock = new ShowStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.dymoSettings = new DymoSettings();
        }

        //====================================================================================================
        //Resizable window
        #region Resizable window
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;
            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if ((clientPoint.Y <= RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if ((clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)) )
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if ((clientPoint.X <= RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }

                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
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

        private void bMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else if(this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Main menu subMenu
        private void bDymoSettings_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.dymoSettings);
                this.dymoSettings.Select();
                this.dymoSettings.BringToFront();
                this.dymoSettings.Show();
            }
            catch (ObjectDisposedException)
            {
                this.dymoSettings = new DymoSettings();
                this.pContainer.Controls.Add(this.dymoSettings);
                this.dymoSettings.Select();
                this.dymoSettings.BringToFront();
                this.dymoSettings.Show();
            }
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
                this.addNewProduct.Select();
                this.addNewProduct.BringToFront();
                this.addNewProduct.Show();
            }
            catch (ObjectDisposedException)
            {
                this.addNewProduct = new AddNewProduct(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addNewProduct);
                this.addNewProduct.Select();
                this.addNewProduct.BringToFront();
                this.addNewProduct.Show();
            }
        }
        private void AddProductFromPdf_Click(object sender, EventArgs e)
        {
            try
            {
                this.pContainer.Controls.Add(this.addNewProductFromExcel);
                this.addNewProductFromExcel.Select();
                this.addNewProductFromExcel.BringToFront();
                this.addNewProductFromExcel.Show();
            }
            catch (ObjectDisposedException)
            {
                this.addNewProductFromExcel = new AddNewProductFromExcel(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addNewProductFromExcel);
                this.addNewProductFromExcel.Select();
                this.addNewProductFromExcel.BringToFront();
                this.addNewProductFromExcel.Show();
            }

        }
    
        private void bShowProductInfo_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.showProductInfo);
                this.showProductInfo.Select();
                this.showProductInfo.BringToFront();
                this.showProductInfo.Show();
            }
            catch (ObjectDisposedException)
            {
                this.showProductInfo = new ShowProductInfo(ref this.databaseCommands);
                this.pContainer.Controls.Add(this.showProductInfo);
                this.showProductInfo.Select();
                this.showProductInfo.BringToFront();
                this.showProductInfo.Show();
            }
        }

        private void bPrintBarcode_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.printBarcode);
                this.printBarcode.Select();
                this.printBarcode.BringToFront();
                this.printBarcode.Show();
            }
            catch (ObjectDisposedException)
            {
                this.printBarcode = new PrintBarcode(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.printBarcode);
                this.printBarcode.Select();
                this.printBarcode.BringToFront();
                this.printBarcode.Show();
            }

        }

        private void bAddManufacturer_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.addManufacturer);
                this.addManufacturer.Select();
                this.addManufacturer.BringToFront();
                this.addManufacturer.Show();
            }
            catch (ObjectDisposedException)
            {
                this.addManufacturer = new AddManufacturer(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addManufacturer);
                this.addManufacturer.Select();
                this.addManufacturer.BringToFront();
                this.addManufacturer.Show();
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
                this.addToStock.Select();
                this.addToStock.BringToFront();
                this.addToStock.Show();
            }
            catch (ObjectDisposedException)
            {
                this.addToStock = new AddToStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.addToStock);
                this.addToStock.Select();
                this.addToStock.BringToFront();
                this.addToStock.Show();
            }

        }

        private void bPrintFromStock_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.printFromStock);
                this.printFromStock.Select();
                this.printFromStock.BringToFront();
                this.printFromStock.Show();
            }
            catch (ObjectDisposedException)
            {
                this.printFromStock = new PrintFromStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.printFromStock);
                this.printFromStock.Select();
                this.printFromStock.BringToFront();
                this.printFromStock.Show();
            }
        }
        private void bShowStock_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.showStock);
                this.showStock.Select();
                this.showStock.BringToFront();
                this.showStock.Show();
            }
            catch (ObjectDisposedException)
            {
                this.showStock = new ShowStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
                this.pContainer.Controls.Add(this.showStock);
                this.showStock.Select();
                this.showStock.BringToFront();
                this.showStock.Show();
            }
        }


        #endregion
    }
}
