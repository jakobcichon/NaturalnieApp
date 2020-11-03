using NaturalnieApp.Initialization;
using NaturalnieApp.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using ElzabCommands;
using NaturalnieApp.Database;
using MySql.Data.MySqlClient;


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

            string connectionString = "server=127.0.0.1;port=3306;database=shop;uid=admin;password=admin";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create database if not exists
                using (ShopContext contextDB = new ShopContext(connection, false))
                {
                    contextDB.Database.CreateIfNotExists();
                    contextDB.Product.
                }

                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                connection.Close();
            }

                //DatabaseMain testDB = new DatabaseMain();
                //testDB.ReadAllFromTable("products");
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
