using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NaturalnieApp.Forms
{
    public partial class ElzabSettings : Form
    {
        public ElzabSettings()
        {
            InitializeComponent();

            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cCOMPorts.Items.Clear();
            foreach (string element in ports)
            {
                cCOMPorts.Items.Add(element);
            }
            

        }


        private void bBrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.tbElzabPath.Text = fbd.SelectedPath;
            }
        }

        private void ElzabSettings_Load(object sender, EventArgs e)
        {

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cCOMPorts.Items.Clear();
            foreach (string element in ports)
            {
                cCOMPorts.Items.Add(element);
            }
        }

    }
}
