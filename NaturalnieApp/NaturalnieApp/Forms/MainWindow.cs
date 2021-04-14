using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NaturalnieApp.Initialization;
using NaturalnieApp.Database;
using System.Reflection;
using System.IO.Ports;
using System.Collections.Generic;
using ElzabDriver;
using System.Management;
using System.Linq;
using Microsoft.Win32;

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
        public Playground playground { get; set; }
        public GeneralSettings generalSettings { get; set; }
        public ElzabSynchronization elzabSynchronization { get; set; }
        public SalesBufferReading salesBufferReading { get; set; }
        public PricesRelatedUpdate pricesRelatedUpdate { get; set; }
        public Common.StatusBar statusBar { get; set; }
        public ElzabRelated.CashRegisterSerialPort cashRegisterSerialPort { get; set; }


        //Creat EF databse connection object
        DatabaseCommands databaseCommands;

        //Cyclic db check
        DatabaseCommands databaseCommandsCyclic;

        //Backgorund workers
        BackgroundWorker bwCheckDbConnection;

        public MainWindow(ConfigFileObject conFileObj)
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.ConfigFileOjbInst = conFileObj;
            InitializeComponent();
            customizeDesign();

            //Initialize EF databse connection object
            this.databaseCommands = new DatabaseCommands();
            this.databaseCommandsCyclic = new DatabaseCommands();

            //Set double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);

            //Background workers
            InitializeBackgroundWorker();

            //Start the timer
            this.timer1sTick.Start();

            this.addNewProductFromExcel = new AddNewProductFromExcel(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.printBarcode = new PrintBarcode() ;
            this.showProductInfo = new ShowProductInfo(ref this.databaseCommands) ;
            this.addNewProduct = new AddNewProduct(ref this.databaseCommands);
            this.addToStock = new AddToStock(ref this.databaseCommands);
            this.addManufacturer = new AddManufacturer(ref this.databaseCommands);
            this.printFromStock = new PrintFromStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.showStock = new ShowStock(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.playground = new Playground();
            this.generalSettings = new GeneralSettings(this.ConfigFileOjbInst);
            this.elzabSynchronization = new ElzabSynchronization(ref this.databaseCommands);
            this.salesBufferReading = new SalesBufferReading(ref this.databaseCommands);
            this.pricesRelatedUpdate = new PricesRelatedUpdate(ref this.databaseCommands);

            //Add status bar
            this.statusBar = new Common.StatusBar();
            this.pStatusBar.Controls.Add(this.statusBar);
            this.statusBar.Dock = DockStyle.Left;
            this.statusBar.BringToFront();
            this.pStatusBar.Update();

            //Add status bar events
            this.statusBar.MouseDown += new MouseEventHandler(this.pHeader_MouseDown);
            this.statusBar.MouseUp += new MouseEventHandler(this.pHeader_MouseUp);
            this.statusBar.MouseMove += new MouseEventHandler(this.pHeader_MouseMove);

            //Set version
            lVersion.Text = typeof(Program).Assembly.GetName().Version.ToString();

            //Cash register serial port instance
            this.cashRegisterSerialPort = new ElzabRelated.CashRegisterSerialPort();
            this.cashRegisterSerialPort.ProgressChanged += CashRegisterSerialPort_ProgressChanged;
            this.cashRegisterSerialPort.WorkDone += CashRegisterSerialPort_WorkDone;

            //Check cash register serial ports for the first time
            if (!this.cashRegisterSerialPort.IsBusy()) this.cashRegisterSerialPort.Execute();

    }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        //Method used to initialize backgroundworkers
        private void InitializeBackgroundWorker()
        {
            //Check DB connection background worker
            this.bwCheckDbConnection = new BackgroundWorker();
            this.bwCheckDbConnection.DoWork += bwCheckDbConnection_DoWork;
            this.bwCheckDbConnection.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwCheckDbConnection_RunWorkerCompleted);

        }

        //Check DB connection background worker
        void bwCheckDbConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            this.databaseCommandsCyclic.CheckConnection(false);
            e.Result = this.databaseCommandsCyclic.ConnectionStatus;
        }
        private void bwCheckDbConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if((bool)e.Result == true)
            {
                if(this.statusBar != null) this.statusBar.UpdateStatusFrom_Db(Common.GeneralStatus.Online);
            }
            else
            {
                if (this.statusBar != null) this.statusBar.UpdateStatusFrom_Db(Common.GeneralStatus.Offline);
            }
        }

        private void CashRegisterSerialPort_WorkDone(object sender, ElzabRelated.CashRegisterSerialPort.StatusUpdateEventArgs e)
        {
            Common.GeneralStatus valueToUpdate = (Common.GeneralStatus)e.Status.CashRegisterStatus;
            this.statusBar.UpdateStatus_CashRegister(valueToUpdate);

            //Update general settings window
            this.generalSettings.UpdateComPort();
        }

        private void CashRegisterSerialPort_ProgressChanged(object sender, ElzabRelated.CashRegisterSerialPort.StatusUpdateEventArgs e)
        {
            Common.GeneralStatus valueToUpdate = (Common.GeneralStatus)e.Status.CashRegisterStatus;
            this.statusBar.UpdateStatus_CashRegister(valueToUpdate);
        }
        //=============================================================================
        #endregion

        //====================================================================================================
        //Resizable window
        #region Resizable window
        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);
                    ResizeWindow(ref m);
                    return;
                case 537: //WM_DEVICECHANGE
                    if (m.WParam == (IntPtr)0x0007/*DBT_DEVNODES_CHANGED*/) HardwareHasHanged();
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
        private void ResizeWindow(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 20;
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
                else if ((clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)))
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

        #region Hardware monitor
        private void HardwareHasHanged()
        {
            if (!this.cashRegisterSerialPort.IsBusy()) this.cashRegisterSerialPort.Execute();
            else
            {
                this.cashRegisterSerialPort.Cancel();
                this.cashRegisterSerialPort.Execute();
            }
        }
        #endregion

        #region Main window general settings
        //Method used to customize initialize menu
        private void customizeDesign()
        {
            pMainMenuSubMenu.Visible = false;
            pCashRegisterSubMenu.Visible = false;
            pProductSubMenu.Visible = false;
            pStockSubMenu.Visible = false;
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Zamknięcie programu", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) Application.Exit();
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
        private void bGeneralSettings_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.generalSettings);
                this.generalSettings.Select();
                this.generalSettings.BringToFront();
                this.generalSettings.Show();
            }
            catch (ObjectDisposedException)
            {
                this.generalSettings = new GeneralSettings(this.ConfigFileOjbInst);
                this.pContainer.Controls.Add(this.generalSettings);
                this.generalSettings.Select();
                this.generalSettings.BringToFront();
                this.generalSettings.Show();
            }
        }
        #endregion

        #region Main menu subMenu
        private void bMainMenu_Click(object sender, EventArgs e)
        {
            toggleSubMenu(pMainMenuSubMenu);
        }
        private void bPlayground_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.playground);
                this.playground.Select();
                this.playground.BringToFront();
                this.playground.Show();
            }
            catch (ObjectDisposedException)
            {
                this.playground = new Playground();
                this.pContainer.Controls.Add(this.playground);
                this.playground.Select();
                this.playground.BringToFront();
                this.playground.Show();
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

        private void bElzabSynchronization_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.elzabSynchronization);
                this.elzabSynchronization.Select();
                this.elzabSynchronization.BringToFront();
                this.elzabSynchronization.Show();
            }
            catch (ObjectDisposedException)
            {
                this.elzabSynchronization = new ElzabSynchronization(ref this.databaseCommands);
                this.pContainer.Controls.Add(this.elzabSynchronization);
                this.elzabSynchronization.Select();
                this.elzabSynchronization.BringToFront();
                this.elzabSynchronization.Show();
            }

        }

        private void bSalesBufferReading_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.salesBufferReading);
                this.salesBufferReading.Select();
                this.salesBufferReading.BringToFront();
                this.salesBufferReading.Show();
            }
            catch (ObjectDisposedException)
            {
                this.salesBufferReading = new SalesBufferReading(ref this.databaseCommands);
                this.pContainer.Controls.Add(this.salesBufferReading);
                this.salesBufferReading.Select();
                this.salesBufferReading.BringToFront();
                this.salesBufferReading.Show();
            }

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
                this.addNewProduct = new AddNewProduct(ref this.databaseCommands);
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
                this.printBarcode = new PrintBarcode();
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
                this.addManufacturer = new AddManufacturer(ref this.databaseCommands);
                this.pContainer.Controls.Add(this.addManufacturer);
                this.addManufacturer.Select();
                this.addManufacturer.BringToFront();
                this.addManufacturer.Show();
            }
        }
        private void bPriceRelatedUpdate_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();
            try
            {
                this.pContainer.Controls.Add(this.pricesRelatedUpdate);
                this.pricesRelatedUpdate.Select();
                this.pricesRelatedUpdate.BringToFront();
                this.pricesRelatedUpdate.Show();
            }
            catch (ObjectDisposedException)
            {
                this.pricesRelatedUpdate = new PricesRelatedUpdate(ref this.databaseCommands);
                this.pContainer.Controls.Add(this.pricesRelatedUpdate);
                this.pricesRelatedUpdate.Select();
                this.pricesRelatedUpdate.BringToFront();
                this.pricesRelatedUpdate.Show();
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
                this.addToStock = new AddToStock(ref this.databaseCommands);
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

        #region Timer event
        private void timer5sTick_Tick(object sender, EventArgs e)
        {
            if(!this.bwCheckDbConnection.IsBusy) this.bwCheckDbConnection.RunWorkerAsync();
        }
        #endregion

        private void pLogo_Click(object sender, EventArgs e)
        {
            this.pContainer.Controls.Clear();


            this.Select();
            this.BringToFront();
            this.Show();

        }

    }
}
