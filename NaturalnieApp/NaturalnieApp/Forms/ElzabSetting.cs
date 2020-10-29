using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
            //Elzab Path - add text and format it
            this.tbElzabPath.Text = conFileObj.GetValueByVariableName("ElzabCommandPath");
            TextBoxFormat(this.tbElzabPath);

            //COM Ports - call method to choose proper COM port
            COMPortsFormat(conFileObj);

            //Baud rate - setting for connection baud rate  ComboBox
            int indexNumber = cBaudRate.Items.IndexOf(conFileObj.GetValueByVariableName("ElzabBaudRate"));
            cBaudRate.SelectedItem = cBaudRate.Items[indexNumber];

        }

        //Method used to handle formatting of COM ports ComboBox
        public void COMPortsFormat(ConfigFileObject conFileObj)
        {
            //COM Port - settings for com port ComboBox
            string[] ports = SerialPort.GetPortNames();
            cCOMPorts.Items.Clear();
            foreach (string element in ports)
            {
                cCOMPorts.Items.Add(element);
            }
            cCOMPorts.SelectedItem = cCOMPorts.Items[0];
        }

        //Method used to handle formatting of textBox
        public void TextBoxFormat(RichTextBox textBox)
        {
            //Elzab path - setting for text box
            textBox.SelectionLength = 0;
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
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
            //Udpate view of all properties
            UpdateView(ConfigFileOjbInst);
        }

        private void cCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbElzabPath_TextChanged(object sender, EventArgs e)
        {
            //Format text window
            RichTextBox richTextBoxObject = (RichTextBox) sender;
            TextBoxFormat(richTextBoxObject);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            ConfigFileOjbInst.SaveData();
        }
    }
}
