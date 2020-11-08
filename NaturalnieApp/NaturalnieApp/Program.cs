﻿using NaturalnieApp.Initialization;
using NaturalnieApp.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using ElzabCommands;
using NaturalnieApp.Database;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;

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
            DatabaseCommands databaseCommands = new DatabaseCommands();
            List<string> tmp = databaseCommands.GetProductsNameList();
            List<string> tmp2 = databaseCommands.GetSuppliersNameList();
            var supplier = new Supplier { Name = "Sylveco", 
                Info = " Test info" };
            //databaseCommands.AddSupplier(supplier)
            ;


            //Read data from config file 
            ConfigFileObject ConfigFileInst = new ConfigFileObject();

            int cashRegisterID = 1;
            string path = ConfigFileInst.GetValueByVariableName("ElzabCommandPath");

           // ElzabCommand_OBAJTY Test = new ElzabCommand_OBAJTY(path, cashRegisterID);
            ElzabCommand_OGRUPA OdczytGrupy = new ElzabCommand_OGRUPA(path, cashRegisterID);
            ElzabCommand_ZGRUPA ZapisGrupy = new ElzabCommand_ZGRUPA(path, cashRegisterID);
            ElzabCommand_KGRUPA KasowanieGrupy = new ElzabCommand_KGRUPA(path, cashRegisterID);
            ElzabCommand_OPSPRZED OdczytSprzedazy = new ElzabCommand_OPSPRZED(path, cashRegisterID);
            

            

            Application.EnableVisualStyles();
            Application.Run(new MainWindow(ConfigFileInst));
            ;

            ;
        }
    }
}
