using NaturalnieApp.Initialization;
using NaturalnieApp.Forms;
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
            //Read data from config file 
            ConfigFileObject ConfigFileInst = new ConfigFileObject();
            string test = ConfigFileInst.GetValueByVariableName("ElzabCommandPath");


            int cashRegisterID = 1;
            string path = ConfigFileInst.GetValueByVariableName("ElzabCommandPath");


           // ElzabCommand_OBAJTY Test = new ElzabCommand_OBAJTY(path, cashRegisterID);
            ElzabCommand_OGRUPA OdczytGrupy = new ElzabCommand_OGRUPA(path, cashRegisterID);
            ElzabCommand_ZGRUPA ZapisGrupy = new ElzabCommand_ZGRUPA(path, cashRegisterID);
            ElzabCommand_KGRUPA KasowanieGrupy = new ElzabCommand_KGRUPA(path, cashRegisterID);
            ElzabCommand_OPSPRZED OdczytSprzedazy = new ElzabCommand_OPSPRZED(path, cashRegisterID);
            

            

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());


            ;
        }
    }
}
