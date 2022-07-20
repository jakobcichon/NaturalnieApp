using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Database;
using NaturalnieApp.Forms.TestForm;
using NaturalnieApp.Initialization;
using static NaturalnieApp.Program;
using NaturalnieApp.Forms.Common;
using NaturalnieApp.Dymo_Printer;
using System.Net;
using static NaturalnieApp.ElzabRelated;

namespace NaturalnieApp.Forms
{
    public partial class GeneralSettings : UserControl
    {
        //============================================================================================
        //Object fields

        //Last valid text o rtb
        string ElzabPathLastValidText {get; set;}
        string LabelPathLastValidText { get; set; }
        string DbBackupPathLastValidText { get; set; }
        string LibraryPathLastValidText { get; set; }

        private ConfigFileObject ConfigFileObjInst;
        private CashRegisterSerialPort cashRegisterSerialPort;

        //============================================================================================
        //Constructor
        public GeneralSettings(ConfigFileObject conFileObj, CashRegisterSerialPort cashRegisterSerialPort)
        {
            this.ConfigFileObjInst = conFileObj;
            this.cashRegisterSerialPort = cashRegisterSerialPort;
            InitializeComponent();
            UpdateView(conFileObj);

        }

        #region General methods
        private void UpdateControl(ref TextBox dummyForControl)
        {
            //this.Select();
            this.Focus();
            dummyForControl.Select();
        }
        public void UpdateView(ConfigFileObject conFileObj)
        {

            //Update object with information from file
            conFileObj.ReadData();

            //Elzab Path - add text and format it
            this.tbElzabPath.Text = conFileObj.GetValueByVariableName("ElzabCommandPath");
            TextBoxFormat(this.tbElzabPath);

            this.cbElzabCommunicationOptions.DataSource = Enum.GetValues(typeof(ElzabCommunicationOptions));
            ElzabCommunicationOptions selectedOption;
            Enum.TryParse<ElzabCommunicationOptions>(conFileObj.GetValueByVariableName("ElzabCommunicationOptions"), out selectedOption);
            this.cbElzabCommunicationOptions.SelectedItem = selectedOption;

            this.rtbElzabIp.Text = conFileObj.GetValueByVariableName("ElzabIpAddress");

            //COM Ports - call method to choose proper COM port
            COMPortsFormat(conFileObj, false);

            //Baud rate - setting for connection baud rate  ComboBox 
            int indexNumber = cBaudRate.Items.IndexOf(conFileObj.GetValueByVariableName("ElzabBaudRate"));
            if (indexNumber >= 0) cBaudRate.SelectedItem = cBaudRate.Items[indexNumber];

            //Database name
            this.rtbSqlServerName.Text = conFileObj.GetValueByVariableName("SqlServerName");
            this.rtbDbBackupPath.Text = conFileObj.GetValueByVariableName("DbBackupPath");

            //Dymo printer
            this.rtbLabelPath.Text = conFileObj.GetValueByVariableName("LabelPath");

            //General settings
            this.rtbLibraryPath.Text = conFileObj.GetValueByVariableName("LibraryPath");

            //Intilialize last valid text for rtb
            this.ElzabPathLastValidText = this.tbElzabPath.Text;
            this.LabelPathLastValidText = this.rtbLabelPath.Text;
            this.DbBackupPathLastValidText = this.rtbDbBackupPath.Text;
            this.LibraryPathLastValidText = this.rtbLibraryPath.Text;

        }
        //Method used to handle formatting of COM ports ComboBox
        public void COMPortsFormat(ConfigFileObject conFileObj, bool fromConfigFile = true)
        {
            //COM Port - settings for com port ComboBox
            string[] ports = SerialPort.GetPortNames();
            string comPortFromFile;
            if (fromConfigFile) comPortFromFile = conFileObj.GetValueByVariableName("ElzabCOMPort");
            else comPortFromFile = GlobalVariables.ElzabPortCom.PortName;

            cCOMPorts.Items.Clear();
            bool result = false;
            foreach (string element in ports)
            {
                cCOMPorts.Items.Add(element);
                if (comPortFromFile == element && GlobalVariables.ElzabConnectionTested && 
                    GlobalVariables.ElzabCommunicationOption == ElzabCommunicationOptions.COM)
                {
                    cCOMPorts.SelectedItem = comPortFromFile;
                    result = true;
                    break;
                }
            }
            if (!result)
            {
                string comPortNewName = comPortFromFile + " (domyślny, nieaktywny)";
                cCOMPorts.Items.Add(comPortNewName);
                cCOMPorts.SelectedItem = comPortNewName;
            }

        }
        //Method used to handle formatting of textBox
        public void TextBoxFormat(RichTextBox textBox)
        {
            //Elzab path - setting for text box
            textBox.DeselectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Left;
        }
        //Method used to get printer list
        private void GetPrinterList()
        {
            List<string> printersNames = PrinterMethods.GetPrintersNameList();
            if (printersNames.Count != 0)
            {
                cbAvailablePrintersList.Items.Clear();
                int i = 0;
                foreach (string printerName in printersNames)
                {
                    cbAvailablePrintersList.Items.Add(i.ToString() + "." + printerName);
                    i++;
                }
            }
        }
        private void SaveData()
        {
            if (AllObjectSelected())
            {
                //Update value of Elzab communication option
                ConfigFileObjInst.ChangeVariableValue("ElzabCommunicationOptions", cbElzabCommunicationOptions.SelectedItem.ToString());
                GlobalVariables.ElzabCommunicationOption = GetElzabCommunicationOption();

                if (GlobalVariables.ElzabCommunicationOption != ElzabCommunicationOptions.COM)
                {
                    //Update value of Elzab ip address
                    ConfigFileObjInst.ChangeVariableValue("ElzabIpAddress", rtbElzabIp.Text);
                    GlobalVariables.ElzabIpAddress = rtbElzabIp.Text;
                }

                if(GlobalVariables.ElzabCommunicationOption != ElzabCommunicationOptions.LAN)
                {
                    //Update value of COM port
                    ConfigFileObjInst.ChangeVariableValue("ElzabCOMPort", ElzabRelated.CleanComPortName(cCOMPorts.SelectedItem.ToString()));
                    GlobalVariables.ElzabPortCom.PortName = ElzabRelated.CleanComPortName(cCOMPorts.SelectedItem.ToString());

                    //Update value of Baud rate
                    ConfigFileObjInst.ChangeVariableValue("ElzabBaudRate", cBaudRate.SelectedItem.ToString());
                    GlobalVariables.ElzabPortCom.BaudRate = Int32.Parse(cBaudRate.SelectedItem.ToString());
                }

                //Update value of path
                ConfigFileObjInst.ChangeVariableValue("ElzabCommandPath", tbElzabPath.Text.ToString());
                GlobalVariables.ElzabCommandPath = tbElzabPath.Text.ToString();

                //Update database name
                ConfigFileObjInst.ChangeVariableValue("SqlServerName", rtbSqlServerName.Text.ToString());
                GlobalVariables.SqlServerName = rtbSqlServerName.Text.ToString();

                //Update label path
                ConfigFileObjInst.ChangeVariableValue("LabelPath", rtbLabelPath.Text.ToString());
                GlobalVariables.LabelPath = rtbLabelPath.Text.ToString();

                //Update library path
                ConfigFileObjInst.ChangeVariableValue("LibraryPath", rtbLibraryPath.Text.ToString());
                GlobalVariables.LibraryPath = rtbLibraryPath.Text.ToString();

                //Update db backups path path
                ConfigFileObjInst.ChangeVariableValue("DbBackupPath", rtbDbBackupPath.Text.ToString());
                GlobalVariables.DbBackupPath = rtbDbBackupPath.Text.ToString();
                GlobalVariables.ConnectionString = string.Format("server = {0}; port = 3306; database = shop;" +
                "uid = admin; password = admin; Connection Timeout = 2", GlobalVariables.SqlServerName);

                ConfigFileObjInst.SaveData();

                this.cashRegisterSerialPort.ChangeCashRegisterData();
                this.cashRegisterSerialPort.Execute();

                MessageBox.Show("Zapisano zmiany!");

            }
        }
        private bool AllObjectSelected()
        {
            bool retVal = false;
            if (cCOMPorts.SelectedIndex != -1 && cBaudRate.SelectedIndex != -1 && tbElzabPath.Text != "" && rtbSqlServerName.Text != ""
                && rtbLabelPath.Text != "" && rtbLibraryPath.Text != "" && rtbDbBackupPath.Text != "" && rtbElzabIp.Text != "" 
                && cbElzabCommunicationOptions.SelectedIndex != -1)
            {
                retVal = true;
            }

            return retVal;
        }
        #endregion

        public void UpdateComPort()
        {

            //Update com ports
            COMPortsFormat(this.ConfigFileObjInst, false);
            this.cCOMPorts.Update();
        }

        //============================================================================================
        //Events

        #region User control events
        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            try
            {
                //Get printers list
                GetPrinterList();
            }
            catch
            {
                MessageBox.Show("Dymo printer drivers could not be found!");
            }

            //Update com ports
            COMPortsFormat(this.ConfigFileObjInst, false);

            UpdateElzabCommunicationOptionFields(this.ConfigFileObjInst);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((keyData == Keys.Enter))
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (keyData == Keys.Escape)
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Buttons events
        private void bUpdate_Click(object sender, EventArgs e)
        {
            //Udpate view of all properties
            UpdateView(ConfigFileObjInst);

            UpdateElzabCommunicationOptionFields();
        }
        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Check result
                bool result = AllObjectSelected();
                if (!result)
                {
                    DialogResult decision = MessageBox.Show("Nie wszystkie wymagane pola zostały uzupełnione. " +
                        "Czy chcesz kontunuować i dla nie uzupełnionych danych przywrócić wartości domyślne?",
                        "Brakujące dane do zapisu", MessageBoxButtons.YesNo);

                    if (decision == DialogResult.Yes)
                    {
                        if (cCOMPorts.SelectedIndex == -1)
                        {
                            int index = cCOMPorts.Items.IndexOf(this.ConfigFileObjInst.ElzabCOMPortDefaultValue);
                            if (index == -1)
                            {
                                cCOMPorts.Items.Add("COM" + this.ConfigFileObjInst.ElzabCOMPortDefaultValue);
                                index = cCOMPorts.Items.IndexOf(this.ConfigFileObjInst.ElzabCOMPortDefaultValue);
                            }
                            cCOMPorts.SelectedIndex = index;
                        }
                        if (cBaudRate.SelectedIndex == -1)
                        {
                            int index = cBaudRate.Items.IndexOf(this.ConfigFileObjInst.ElzabBaudRateDefaultValue);
                            if (index == -1)
                            {
                                cBaudRate.Items.Add(this.ConfigFileObjInst.ElzabCOMPortDefaultValue);
                                index = cBaudRate.Items.IndexOf(this.ConfigFileObjInst.ElzabCOMPortDefaultValue);
                            }
                            cBaudRate.SelectedIndex = index;
                        }
                        if (tbElzabPath.Text == "")
                        {
                            tbElzabPath.Text = this.ConfigFileObjInst.ElzabCommandPathDefaultValue;
                        }
                        if (rtbSqlServerName.Text == "")
                        {
                            rtbSqlServerName.Text = this.ConfigFileObjInst.SqlServerNameDefaultValue;
                        }
                        if (rtbLabelPath.Text == "")
                        {
                            rtbLabelPath.Text = this.ConfigFileObjInst.LabelPathDefaultValue;
                        }
                        if (rtbLibraryPath.Text == "")
                        {
                            rtbLibraryPath.Text = this.ConfigFileObjInst.LibraryPathDefaultValue;
                        }
                        if (rtbDbBackupPath.Text == "")
                        {
                            rtbDbBackupPath.Text = this.ConfigFileObjInst.DbBackupPathDefaultValue;
                        }
                        if (rtbElzabIp.Text == "" || !isIP(rtbElzabIp.Text))
                        {
                            rtbElzabIp.Text = this.ConfigFileObjInst.ElzabIpAddressDefaultValue;
                        }


                        SaveData();
                    }

                }
                else
                {

                    SaveData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void bApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllObjectSelected())
                {
                    //Update communication option
                    GlobalVariables.ElzabCommunicationOption = GetElzabCommunicationOption();

                    if(GlobalVariables.ElzabCommunicationOption != ElzabCommunicationOptions.COM)
                    {
                        GlobalVariables.ElzabIpAddress = rtbElzabIp.Text;
                    }

                    if (GlobalVariables.ElzabCommunicationOption != ElzabCommunicationOptions.LAN)
                    {
                        //Update value of COM port
                        GlobalVariables.ElzabPortCom.PortName = ElzabRelated.CleanComPortName(cCOMPorts.SelectedItem.ToString());

                        //Update value of Baud rate
                        GlobalVariables.ElzabPortCom.BaudRate = Int32.Parse(cBaudRate.SelectedItem.ToString());
                    }

                    //Update value of path
                    GlobalVariables.ElzabCommandPath = tbElzabPath.Text.ToString();

                    //Update database name
                    GlobalVariables.SqlServerName = rtbSqlServerName.Text.ToString();

                    //Label path
                    GlobalVariables.LabelPath = rtbLabelPath.Text.ToString();

                    //Library path
                    GlobalVariables.LibraryPath = rtbLibraryPath.Text.ToString();

                    //Db backup path
                    GlobalVariables.DbBackupPath = rtbDbBackupPath.Text.ToString();
                    GlobalVariables.ConnectionString = string.Format("server = {0}; port = 3306; database = shop;" +
                    "uid = admin; password = admin; Connection Timeout = 2", GlobalVariables.SqlServerName);

                    this.cashRegisterSerialPort.ChangeCashRegisterData();
                    this.cashRegisterSerialPort.Execute();

                    MessageBox.Show("Zastosowano zmiany!");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Elzab settings
        private void cbElzabCommunicationOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateElzabCommunicationOptionFields();
        }

        private void UpdateElzabCommunicationOptionFields(string selectedEnum)
        {

            ElzabCommunicationOptions selectedOption;
            Enum.TryParse<ElzabCommunicationOptions>(selectedEnum, out selectedOption);

            switch (selectedOption)
            {
                case (ElzabCommunicationOptions.LAN):
                    ShowElzabCommunicationFeilds_Lan();
                    HideElzabCommunicationFeilds_COM();
                    break;
                case (ElzabCommunicationOptions.COM):
                    HideElzabCommunicationFeilds_Lan();
                    ShowElzabCommunicationFeilds_COM();
                    break;
                default:
                    ShowElzabCommunicationFeilds_Lan();
                    ShowElzabCommunicationFeilds_COM();
                    break;
            }
        }

        private void UpdateElzabCommunicationOptionFields(ConfigFileObject conFileObj)
        {
            UpdateElzabCommunicationOptionFields(conFileObj.GetValueByVariableName("ElzabCommunicationOptions"));
        }

        private void UpdateElzabCommunicationOptionFields()
        {
            UpdateElzabCommunicationOptionFields(cbElzabCommunicationOptions.SelectedItem.ToString());
        }

        private ElzabCommunicationOptions GetElzabCommunicationOption()
        {
            ElzabCommunicationOptions selectedOption;
            bool result = Enum.TryParse<ElzabCommunicationOptions>(cbElzabCommunicationOptions.SelectedItem.ToString(), out selectedOption);

            if (result)
            {
                return selectedOption;
            }

            return ElzabCommunicationOptions.NONE;
        }

        private void ShowElzabCommunicationFeilds_Lan()
        {
            this.pElzabCommunicationLAN.Visible = true;
        }

        private void HideElzabCommunicationFeilds_Lan()
        {
            this.pElzabCommunicationLAN.Visible = false;
        }

        private void ShowElzabCommunicationFeilds_COM()
        {
            this.pElzabCommunicationCOM.Visible = true;
        }
        private void HideElzabCommunicationFeilds_COM()
        {
            this.pElzabCommunicationCOM.Visible = false;
        }

        bool isIP(string host)
        {
            IPAddress ip;
            return IPAddress.TryParse(host, out ip);
        }

        private void tbElzabPath_TextChanged(object sender, EventArgs e)
        {
            //Format text window
            RichTextBox richTextBoxObject = (RichTextBox)sender;
            TextBoxFormat(richTextBoxObject);
        }
        private void bElzabPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.tbElzabPath.Focus();
                this.tbElzabPath.Text = fbd.SelectedPath;

                //Udpate view of all properties
                UpdateControl(ref this.tbDummyForCtrl);
            }
        }
        private void tbElzabPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RichTextBox localSender = (RichTextBox)sender;
            bool exist = Directory.Exists(localSender.Text);
            if (!exist)
            {
                localSender.Text = this.ElzabPathLastValidText;
            }
            else this.ElzabPathLastValidText = localSender.Text;

            //Udpate view of all properties
            UpdateControl(ref this.tbDummyForCtrl);
        }
        #endregion

        #region Dymo settings
        private void rtbLabelPath_TextChanged(object sender, EventArgs e)
        {
            //Format text window
            RichTextBox richTextBoxObject = (RichTextBox)sender;
            TextBoxFormat(richTextBoxObject);
        }
        private void bLabelPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.rtbLabelPath.Focus();
                   this.rtbLabelPath.Text = ofd.FileName;

                //Udpate view of all properties
                UpdateControl(ref this.tbDummyForCtrl);
            }
        }
        private void rtbLabelPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RichTextBox localSender = (RichTextBox)sender;
            bool exist = File.Exists(localSender.Text);
            if (!exist)
            {
                localSender.Text = this.LabelPathLastValidText;
            }
            else
            {
                string extension = Path.GetExtension(localSender.Text);
                if (extension != ".label")
                {
                    MessageBox.Show("Błąd! Plik musi posiadać rozserzenie \".label\".");
                    localSender.Text = this.LabelPathLastValidText;
                }
                else this.LabelPathLastValidText = localSender.Text;
            }

            //Udpate view of all properties
            UpdateControl(ref this.tbDummyForCtrl);
        }
        private void cbAvailablePrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAvailablePrintersList.SelectedIndex > -1) tbSelectedPrinterName.Text = cbAvailablePrintersList.SelectedItem.ToString();
        }
        #endregion

        #region Db Backup path settings
        private void rtbDbBackupPath_TextChanged(object sender, EventArgs e)
        {
            //Format text window
            RichTextBox richTextBoxObject = (RichTextBox)sender;
            TextBoxFormat(richTextBoxObject);
        }
        private void bDbBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.rtbDbBackupPath.Focus();
                this.rtbDbBackupPath.Text = fbd.SelectedPath;

                //Udpate view of all properties
                UpdateControl(ref this.tbDummyForCtrl);
            }
        }
        private void rtbDbBackupPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RichTextBox localSender = (RichTextBox)sender;
            bool exist = Directory.Exists(localSender.Text);
            if (!exist)
            {
                localSender.Text = this.DbBackupPathLastValidText;
            }
            else this.DbBackupPathLastValidText = localSender.Text;

            //Udpate view of all properties
            UpdateControl(ref this.tbDummyForCtrl);
        }
        private void bDbBackup_Click(object sender, EventArgs e)
        {
            bool result = DatabaseBackup.MakeBackup("root", "admin", "shop", GlobalVariables.DbBackupPath);

            if (result) MessageBox.Show("Udało się utworzyć kopię zapasową bazy danych!");
            else MessageBox.Show("NIE udało się utworzyć kopię zapasową bazy danych!");
        }
        #endregion

        #region Library path settings
        private void rtbLibraryPath_TextChanged(object sender, EventArgs e)
        {
            //Format text window
            RichTextBox richTextBoxObject = (RichTextBox)sender;
            TextBoxFormat(richTextBoxObject);
        }
        private void bLibraryPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.rtbLibraryPath.Focus();
                this.rtbLibraryPath.Text = fbd.SelectedPath;

                //Udpate view of all properties
                UpdateControl(ref this.tbDummyForCtrl);
            }
        }
        private void rtbLibraryPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RichTextBox localSender = (RichTextBox)sender;
            bool exist = Directory.Exists(localSender.Text);
            if (!exist)
            {
                localSender.Text = this.LibraryPathLastValidText;
            }
            else this.LibraryPathLastValidText = localSender.Text;

            //Udpate view of all properties
            UpdateControl(ref this.tbDummyForCtrl);
        }

        #endregion
    }
}
