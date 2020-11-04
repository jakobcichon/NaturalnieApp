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
            Product tmp2 = databaseCommands.GetProductEntityByProductName("Krem na noc");
            Product productTmp = new Product
            {
                ProductId = 3,
                Manufacturer = "Producent Miodów2",
                ProductName = "Miód wielokwiatowy2",
                Quantity = 3,
                PriceNet =  (float) 39.80,
                Tax = 8,
                Marigin = 4

            };
            databaseCommands.AddNewProduct2(productTmp);
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
