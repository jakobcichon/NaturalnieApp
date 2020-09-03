using NaturalnieApp.ElzabDriver;
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
            [DllImport("WinIP.dll", CallingConvention = CallingConvention.Cdecl)]
            byte __TowarMax(string inputfile, string outputfile);

            ElzabFileOperation ElzabDriverInst = new ElzabFileOperation();
            currentDirectory = Directory.GetCurrentDirectory();
            ElzabDriverInst.CheckElzabFilesExist(currentDirectory, "");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



        }
    }
}
