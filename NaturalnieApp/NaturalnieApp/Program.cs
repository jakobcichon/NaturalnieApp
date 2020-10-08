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

            ElzabCommand_OTOWAR Test = new ElzabCommand_OTOWAR(@"F:\Projekty\02. NaturalnieApp\Test", 1);
            //Test.GenerateObjectFromRawData();
            Test.DataToElzab.AddElement();
            Test.DataToElzab.AddElement();
            Test.DataToElzab.AddElement();
            Test.DataToElzab.ChangeAllElementValues(0, "1" );
            Test.DataToElzab.ChangeAllElementValues(1, "2" );
            Test.DataToElzab.ChangeAllElementValues(2, "3" );
            Test.DataToElzab.GenerateRawDataFromObject();
            Test.WriteRawDataToFile(@"F:\Projekty\02. NaturalnieApp\Test", "OTOWAR", FileType.Inputfile, Test.DataToElzab.RawData);
            Test.DataToElzab.RunCommand();
            ;

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
