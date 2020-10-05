using NaturalnieApp.ElzabDriver;
using NaturalnieApp.Initialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ElzabDriver;

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

            /*
            ElzabCommand_OTOWAR Test1 = new ElzabCommand_OTOWAR(@"F:\Projekty\02. NaturalnieApp\ElzabFilesTest");
            Test1.ExecuteCommand();
            Test TestClass = new Test();
            TestClass.TestMt(1, 2, 3, 4);
            */

            ElzabCommand_OTOWAR Test = new ElzabCommand_OTOWAR(@"F:\Projekty\02. NaturalnieApp\NaturalnieApp\Otowar test");
            //Test.GenerateObjectFromRawData();
            Test.DataToElzab.AddElement();
            Test.DataToElzab.ChangeAttributeValue(0, "nr_tow", "44");
            Test.DataToElzab.GenerateRawDataFromObject();
            ;

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
