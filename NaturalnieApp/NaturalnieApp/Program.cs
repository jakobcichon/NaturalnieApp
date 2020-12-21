using NaturalnieApp.Initialization;
using NaturalnieApp.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using ElzabCommands;
using NaturalnieApp.Database;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using NaturalnieApp.PdfToExcel;
using System.Data;
using NaturalnieApp.Dymo_Printer;

namespace NaturalnieApp
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            
            //Create instance to DB
            DatabaseCommands tempDB = new DatabaseCommands();
            Product tempProduct = tempDB.GetProductEntityByProductName(tempDB.GetProductsNameList()[2]);

            //Dymo printer
            Printer PrinterInstance = new Printer(@"F:\Projekty\02. NaturalnieApp\NaturalnieApp\NaturalnieApp\NaturalnieApp\Dymo Printer\BarcodeFinal.label");
            //Printer PrinterInstance = new Printer(@"D:\PrivateRepo\NaturalnieApp\NaturalnieApp\NaturalnieApp\Dymo printer\barcode.label");
            PrinterInstance.PrintPriceCardFromProduct(tempProduct);
            
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
