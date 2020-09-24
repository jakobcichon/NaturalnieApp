using NaturalnieApp.ElzabDriver;
using NaturalnieApp.Initialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NaturalnieApp
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string currentDirectory;

            ConfigFile ConfigFileInst = new ConfigFile();
            ConfigFileInst.InitializeConfigFile("\\config\\config.txt", "");

            List<ConfigElement> ConfigFileElements = new List<ConfigElement>();
            ConfigFileElements = ConfigFileInst.ReadConfigFileElement(ConfigFileInst.FullPath);

            ElzabCommand_OTOWAR Test1 = new ElzabCommand_OTOWAR();
            Test1.DataReceived.ChangeAttribute("unit_no", "2");
            Test1.ExecuteCommand(ref Test1.DataToSend);

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
