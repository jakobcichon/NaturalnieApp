using ElzabDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.ElzabDriver
{
    public interface IElzabSaleBufforInterface
    {
        ElzabFileObject DataFromElzab { get; set; }
        ElzabFileObject DataToElzab { get; set; }
        ElzabFileObject Report { get; set; }
        CommandExecutionStatus ReportStatus { get; set; }
        ElzabFileObject Config { get; set; }
        CommandExecutionStatus ExecuteCommand();

    }

    public interface IElzabCommandInterface
    {
        ElzabFileObject DataFromElzab { get; set; }
        ElzabFileObject DataToElzab { get; set; }
        ElzabFileObject Report { get; set; }
        CommandExecutionStatus ReportStatus { get; set; }
        ElzabFileObject Config { get; set; }
        CommandExecutionStatus ExecuteCommand(bool executeBackup = true);
        bool OutputFileExist { get;}

    }
}
