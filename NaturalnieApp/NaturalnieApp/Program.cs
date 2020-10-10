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
            int cashRegisterID = 1;

            ElzabCommand_ZTOWAR Test = new ElzabCommand_ZTOWAR(@"F:\Projekty\02. NaturalnieApp\Test", cashRegisterID);
            Test.DataToElzab.AddElement("8");
            Test.DataToElzab.ChangeAllElementValues("8", "", "CzyTOSieUda?", "1");
            Test.DataToElzab.GenerateRawDataFromObject();
            Test.WriteRawDataToFile(@"F:\Projekty\02. NaturalnieApp\Test", "ZTOWAR", FileType.Inputfile, Test.DataToElzab.RawData);
            Test.DataToElzab.RunCommand();
            ;

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
