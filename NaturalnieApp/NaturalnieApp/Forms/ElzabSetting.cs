using System;
using System.IO.Ports;
using System.Windows.Forms;
using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    public partial class ElzabSettings : Form
    {
        private ConfigFileObject ConfigFileOjbInst;

        public ElzabSettings(ConfigFileObject conFileObj)
        {
            this.ConfigFileOjbInst = conFileObj;
            InitializeComponent();
            UpdateView(conFileObj);
        }

        public void UpdateView(ConfigFileObject conFileObj)
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cCOMPorts.Items.Clear();
            foreach (string element in ports)
            {
                cCOMPorts.Items.Add(element);
            }
            cCOMPorts.SelectedItem = cCOMPorts.Items[0];

            //Show path
            tbElzabPath.Text = conFileObj.GetValueByVariableName("ElzabCommandPath");

            //Show Elzab connection baud rate
            int indexNumber = cBaudRate.Items.IndexOf(conFileObj.GetValueByVariableName("ElzabBaudRate"));
            cBaudRate.SelectedItem = cBaudRate.Items[indexNumber];
        }


        //============================================================================================
        //Events
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
            UpdateView(ConfigFileOjbInst);
        }

        private void cCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
