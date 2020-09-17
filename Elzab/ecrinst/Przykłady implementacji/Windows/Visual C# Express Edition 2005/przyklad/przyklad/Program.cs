using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        //deklaracja funkcji z dwoma parametrami
        [DllImport("WinIP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte __TowarMax(string inputfile, string outputfile);
        //deklaracja funkcji z jednym parametrem     
        [DllImport("WinIP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte __ZTowar(string inputfile);

        static int Main(string[] args)
        {
            byte error;

            //wywołanie funkcji z dwoma parametrami
            error = __TowarMax("towarmax.in", "towarmax.out");
            if (error != 0)
            {
                //obsługa błędów
                return error;
            }

            //wywołanie funkcji z jednym parametrem
            error = __ZTowar("ztowar.in");
            if (error != 0)
            {
                //obsługa błędów
                return error;
            }

            return error;

        }
    }
}
