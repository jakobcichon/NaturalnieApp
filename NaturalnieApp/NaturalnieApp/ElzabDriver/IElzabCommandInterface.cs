using ElzabDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.ElzabDriver
{
    public interface IElzabCommandInterface
    {
        ElzabFileObject DataFromElzab { get; set; }
        ElzabFileObject DataToElzab { get; set; }
        ElzabFileObject Report { get; set; }
        ElzabFileObject Config { get; set; }
        bool ExecuteCommand();

    }
}
