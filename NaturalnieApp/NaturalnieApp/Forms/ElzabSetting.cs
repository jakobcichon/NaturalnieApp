using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Database;
using NaturalnieApp.Forms.TestForm;
using NaturalnieApp.Initialization;

namespace NaturalnieApp.Forms
{
    public partial class ElzabSettings : Form
    {
        private ConfigFileObject ConfigFileObjInst;

        public ElzabSettings(ConfigFileObject conFileObj)
        {
            this.ConfigFileObjInst = conFileObj;
            InitializeComponent();
            UpdateView(conFileObj);
        }

        public void UpdateView(ConfigFileObject conFileObj)
        {

            //Update object with information from file
            conFileObj.ReadData();

            //Elzab Path - add text and format it
            this.tbElzabPath.Text = conFileObj.GetValueByVariableName("ElzabCommandPath");
            TextBoxFormat(this.tbElzabPath);

            //COM Ports - call method to choose proper COM port
            COMPortsFormat(conFileObj);

            //Baud rate - setting for connection baud rate  ComboBox
            
            int indexNumber = cBaudRate.Items.IndexOf(conFileObj.GetValueByVariableName("ElzabBaudRate"));
            if (indexNumber >= 0) cBaudRate.SelectedItem = cBaudRate.Items[indexNumber];

            //Database name
            this.rtbDatabaseName.Text = conFileObj.GetValueByVariableName("DatabaseName");

            ;

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
            
            if(cCOMPorts.Items.Count > 0) cCOMPorts.SelectedItem = cCOMPorts.Items[0];
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
            UpdateView(ConfigFileObjInst);
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
            //Update value of COM port
            ConfigFileObjInst.ChangeVariableValue("ElzabCOMPort", cCOMPorts.SelectedItem.ToString());

            //Update value of Baud rate
            ConfigFileObjInst.ChangeVariableValue("ElzabBaudRate", cBaudRate.SelectedItem.ToString());

            //Update value of path
            ConfigFileObjInst.ChangeVariableValue("ElzabCommandPath", tbElzabPath.Text.ToString());

            //Update database name
            ConfigFileObjInst.ChangeVariableValue("DatabaseName", rtbDatabaseName.Text.ToString());

            ConfigFileObjInst.SaveData();
        }

        private void bDefaults_Click(object sender, EventArgs e)
        {
            //String to show
            string textToShow = "Przywrócić ustawienia domyśle? Wszyskie aktualne dane zostaną utracone";

            //Confirm action of defaults set
            DialogResult dialogResult = MessageBox.Show(textToShow, "Ustawienia domyśle", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //Reset to defaults
                ConfigFileObjInst.ResetToDefault();

                //Udpate view of all properties
                UpdateView(ConfigFileObjInst);

                //Show message
                MessageBox.Show("Akcja zakończona sukcesem!");
            }
        }
    }
}
