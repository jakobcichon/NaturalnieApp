using NaturalnieApp.ElzabDriver;
using NaturalnieApp.Initialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ElzabCommands;

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


            /*
            ElzabCommand_ZTOWAR Test = new ElzabCommand_ZTOWAR(@"F:\Projekty\02. NaturalnieApp\Test", cashRegisterID);
            Test.DataToElzab.AddElement("8");
            Test.DataToElzab.ChangeAllElementValues("8", "", "CzyTOSieUda?", "1");
            Test.DataToElzab.RunCommand();
            */

            int cashRegisterID = 1;
            string path = @"F:\Projekty\02. NaturalnieApp\Test";


           // ElzabCommand_OBAJTY Test = new ElzabCommand_OBAJTY(path, cashRegisterID);
            ElzabCommand_OGRUPA OdczytGrupy = new ElzabCommand_OGRUPA(path, cashRegisterID);
            ElzabCommand_ZGRUPA ZapisGrupy = new ElzabCommand_ZGRUPA(path, cashRegisterID);
            ElzabCommand_KGRUPA KasowanieGrupy = new ElzabCommand_KGRUPA(path, cashRegisterID);
            ElzabCommand_OPSPRZED OdczytSprzedazy = new ElzabCommand_OPSPRZED(path, cashRegisterID);
            

            ;

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
