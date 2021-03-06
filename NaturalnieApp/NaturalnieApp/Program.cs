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
using NaturalnieApp.PdfToExcel;
using System.Data;
using NaturalnieApp.Dymo_Printer;
using System.Diagnostics;
using System.Reflection;
using System.IO.Ports;

namespace NaturalnieApp
{
    static class Program
    {
        public static class GlobalVariables
        {
            //Thread-Safe
            static private object sync_ElzabPortCom = new object();
            static private SerialPort _elzabPortCom;
            static public SerialPort ElzabPortCom
            {
                get
                {
                    lock (sync_ElzabPortCom)
                    {
                        return _elzabPortCom;
                    }
                }
                set
                {
                    lock (sync_ElzabPortCom)
                    {
                        _elzabPortCom = value;
                    }
                }
            }
            static private bool _elzabConnectionTested;
            static public bool ElzabConnectionTested
            {
                get 
                {
                    lock(sync_ElzabPortCom)
                    {
                        return _elzabConnectionTested;
                    }
                }
                set
                {
                    lock (sync_ElzabPortCom)
                    {
                        _elzabConnectionTested = value;
                    }
                }
            }

            static public string LabelPath { get; set; }
            static public string ElzabCommandPath { get; set; }
            static public int ElzabCashRegisterId { get; set; }
            static public string SqlServerName { get; set; }
            static public string ConnectionString { get; set; }
            static public string DymoPrinterName { get; set; }
            static public string LibraryPath { get; set; }
            static public string DbBackupPath { get; set; }
            static public int CashRegisterFirstPossibleId { get { return 280; } }
            static public int CashRegisterLastPossibleId {  get {  return 4095; } }

        }
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        { 
            try
            {
#if DEBUG
                    string path1 = @"C:\NaturalnieApp\NaturalnieApp\NaturalnieApp\NaturalnieApp\Libs";
                    string path2 = @"D:\PrivateRepo\NaturalnieApp\NaturalnieApp\NaturalnieApp\Libs";
                    if(Directory.Exists(path1)) AssemblyResolver.Hook(path1);
                    else if(Directory.Exists(path2)) AssemblyResolver.Hook(path2);
#endif

                //Prevent to launch application more than once
                string thisprocessname = Process.GetCurrentProcess().ProcessName;
                if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                {
                    MessageBox.Show("Aplikacja NaturalnieApp już została uruchomiona!");
                    return;

                }

                //Initialize global variables
                ConfigFileObject ConfigFileInst = InitGlobalVariables();

                //Initialize DB backups
                try
                {
                    DatabaseBackup.Initialize();
                    bool test = DatabaseBackup.MakeBackup("root", "admin", "shop", GlobalVariables.DbBackupPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się wykonać kopii zapasowej bazy danych. Wyjątek: " + ex.Message);
                }

                Application.EnableVisualStyles();
                Application.Run(new MainWindow(ConfigFileInst));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace);
                Debug.WriteLine(ex.ToString());
            }


        }

        //Initialization of global variables
        public static ConfigFileObject InitGlobalVariables()
        {
            //Read data from config file 
            ConfigFileObject ConfigFileInst = new ConfigFileObject();

            string path = ConfigFileInst.GetValueByVariableName("ElzabCommandPath");
            GlobalVariables.ElzabCommandPath = path;
            GlobalVariables.ElzabCashRegisterId = 1;

            int baudRate = Int32.Parse(ConfigFileInst.GetValueByVariableName("ElzabBaudRate"));
            string comName = ConfigFileInst.GetValueByVariableName("ElzabCOMPort");
            GlobalVariables.ElzabPortCom = new SerialPort(comName, baudRate);
            GlobalVariables.ElzabConnectionTested = false;

            GlobalVariables.LabelPath = ConfigFileInst.GetValueByVariableName("LabelPath");
            GlobalVariables.SqlServerName = ConfigFileInst.GetValueByVariableName("SqlServerName");
            GlobalVariables.ConnectionString = string.Format("server = {0}; port = 3306; database = shop;" +
                "uid = admin; password = admin; Connection Timeout = 2", GlobalVariables.SqlServerName);
            GlobalVariables.LibraryPath = ConfigFileInst.GetValueByVariableName("LibraryPath");
            GlobalVariables.DbBackupPath = ConfigFileInst.GetValueByVariableName("DbBackupPath");

            //Printer selection
            List<string> printersNames = PrinterMethods.GetPrintersNameList();
            if (printersNames.Count > 0) GlobalVariables.DymoPrinterName = printersNames[0];

            return ConfigFileInst;

        }

        //Assembly resolver
        public static class AssemblyResolver
        {
            internal static void Hook(params string[] folders)
            {
                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    // Check if the requested assembly is part of the loaded assemblies
                    var loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
                    if (loadedAssembly != null)
                        return loadedAssembly;

                    // This resolver is called when a loaded control tries to load a generated XmlSerializer - We need to discard it.
                    // http://connect.microsoft.com/VisualStudio/feedback/details/88566/bindingfailure-an-assembly-failed-to-load-while-using-xmlserialization

                    var n = new AssemblyName(args.Name);

                    if (n.Name.EndsWith(".xmlserializers", StringComparison.OrdinalIgnoreCase))
                        return null;

                    // http://stackoverflow.com/questions/4368201/appdomain-currentdomain-assemblyresolve-asking-for-a-appname-resources-assembl

                    if (n.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
                        return null;

                    string assy = null;
                    // Get execution folder to use as base folder
                    var rootFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

                    // Find the corresponding assembly file
                    foreach (var dir in folders)
                    {
                        assy = new[] { "*.dll", "*.exe" }.SelectMany(g => Directory.EnumerateFiles(Path.Combine(rootFolder, dir), g)).FirstOrDefault(f =>
                        {
                            try
                            {
                                return n.Name.Equals(AssemblyName.GetAssemblyName(f).Name,
                                    StringComparison.OrdinalIgnoreCase);
                            }
                            catch (BadImageFormatException)
                            {
                                return false; /* Bypass assembly is not a .net exe */
                            }
                            catch (Exception ex)
                            {
                                // Logging etc here
                                throw;
                            }
                        });

                        if (assy != null)
                            return Assembly.LoadFrom(assy);
                    }

                    // More logging for failure here
                    return null;
                };
            }
        }
    }
}
