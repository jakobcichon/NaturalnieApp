﻿using System;
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


namespace NaturalnieApp.Forms
{

    public partial class MainWindow : Form
    {
        private ConfigFileObject ConfigFileOjbInst;
        bool dragging = false;
        int xOffset = 0;
        int yOffset = 0;

        public MainWindow(ConfigFileObject conFileObj)
        {
            this.ConfigFileOjbInst = conFileObj;
            InitializeComponent();
            customizeDesign();
        }

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
            ShowProductInfo frm = new ShowProductInfo() { TopLevel = false, TopMost = true };
            this.pContainer.Controls.Add(frm);
            frm.Show();

        }
        #endregion
    }
}
