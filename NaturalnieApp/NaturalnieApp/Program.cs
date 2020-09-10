using NaturalnieApp.ElzabDriver;
using NaturalnieApp.Initialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ConfigFileInst.InitializeConfigFile();

            ConfigFileInst.ReadConfigFileElement("", "config", "", "config");

            ElzabFileOperation ElzabDriverInst = new ElzabFileOperation();
            currentDirectory = Directory.GetCurrentDirectory();
            ElzabDriverInst.CheckElzabFilesExist(currentDirectory, "");

            ElzabDriverInst.ExecuteCommand("F:\\Projekty\\02. NaturalnieApp\\NaturalnieApp\\Elzab\\winexe\\winexe\\Test\\OTowar.exe");
            ElzabDriverInst.GetFilesFromPath("F:\\Projekty\\02. NaturalnieApp\\NaturalnieApp\\Pliki Elzab\\Komendy");

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());



        }
    }
}
