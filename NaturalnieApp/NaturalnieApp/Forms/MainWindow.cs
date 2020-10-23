using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturalnieApp.Forms
{
    public partial class MainWindow : Form
    {
        bool dragging = false;
        int xOffset = 0;
        int yOffset = 0;

        public MainWindow()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customizeDesign()
        {
            pCashRegisterSubMenu.Visible = false;
        }

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

        private void bCashRegister_Click(object sender, EventArgs e)
        {
            toggleSubMenu(pCashRegisterSubMenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
    }
}
