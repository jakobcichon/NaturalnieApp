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

        #region Clipboard
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;

        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void DisplayClipboardData()
        {
            try
            {
                IDataObject iData = new DataObject();
                iData = Clipboard.GetDataObject();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion

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

            ;

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
            AddNewProduct frm = new AddNewProduct() { TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frm);
            frm.Show();
        }

        #endregion

        #region Find product submenu
        private void bFindProduct_Click(object sender, EventArgs e)
        {


            this.pContainer.Controls.Clear();
            ShowProductInfo frm = new ShowProductInfo(ref this.databaseCommands) { TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frm);
            frm.Show();

        }
        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            List<string> productNameList = this.databaseCommands.GetProductsNameList();
        }
    }
}
