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
using System.Diagnostics;
using System.Reflection;
using System.IO.Ports;

namespace NaturalnieApp
{
    static class Program
    {
        public static class GlobalVariables
        {
            static public string LabelPath { get; set; }
            static public string ElzabCommandPath { get; set; }
            static public int ElzabCashRegisterId { get; set; }
            static public int ElzabPortCom { get; set; }
            static public int ElzabBaudRate { get; set; }
            static public string SqlServerName { get; set; }
            static public string ConnectionString { get; set; }
            static public string DymoPrinterName { get; set; }
            static public string LibraryPath { get; set; }
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

                AssemblyResolver.Hook(@"C:\NaturalnieApp\NaturalnieApp\NaturalnieApp\NaturalnieApp\Libs");
                //AssemblyResolver.Hook(@"D:\PrivateRepo\NaturalnieApp\NaturalnieApp\NaturalnieApp\Libs");

                //Read data from config file 
                ConfigFileObject ConfigFileInst = new ConfigFileObject();

                string path = ConfigFileInst.GetValueByVariableName("ElzabCommandPath");
                GlobalVariables.ElzabCommandPath = path;
                GlobalVariables.ElzabCashRegisterId = 1;
                GlobalVariables.ElzabBaudRate = Int32.Parse(ConfigFileInst.GetValueByVariableName("ElzabBaudRate"));

                //Check available com ports
                GlobalVariables.ElzabPortCom = Int32.Parse(ConfigFileInst.GetValueByVariableName("ElzabCOMPort"));
                string[] ports = SerialPort.GetPortNames();
                bool result = false;
                foreach (string port in ports)
                {
                    int portInt = Int32.Parse(port.Replace("COM", ""));
                    if (GlobalVariables.ElzabPortCom == portInt) result = true;
                }
                if (!result && ports.Count() > 0) GlobalVariables.ElzabPortCom = Int32.Parse(ports[0].Replace("COM", ""));

                GlobalVariables.LabelPath = ConfigFileInst.GetValueByVariableName("LabelPath");
                GlobalVariables.SqlServerName = ConfigFileInst.GetValueByVariableName("DatabaseName");
                GlobalVariables.ConnectionString = string.Format("server = {0}; port = 3306; database = shop;" +
                    "uid = admin; password = admin; Connection Timeout = 60", GlobalVariables.SqlServerName);
                GlobalVariables.LibraryPath = ConfigFileInst.GetValueByVariableName("LibraryPath");

                //Pronter selection
                List<string> printersNames = PrinterMethods.GetPrintersNameList();
                if (printersNames.Count > 0) GlobalVariables.DymoPrinterName = printersNames[0];


                Application.EnableVisualStyles();
                Application.Run(new MainWindow(ConfigFileInst));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex.ToString());
            }


        }


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
