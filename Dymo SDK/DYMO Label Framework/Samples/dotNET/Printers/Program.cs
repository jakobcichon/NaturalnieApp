//----------------------------------------------------------------------------
//
//  $Id: Program.cs 10868 2010-02-04 19:38:12Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework Samples
//
// Content -------------------------------------------------------------------
//
//  Sample shows how to enumerate and get information about
//  available DYMO printers
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------
using System;
using DYMO.Label.Framework;

namespace PrinterInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (IPrinter printer in new Printers())
                {
                    // output common printer properties
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Printer Name: {0}", printer.Name);
                    Console.WriteLine("Printer Model Name: {0}", printer.ModelName);
                    Console.WriteLine("?Local: {0}", printer.IsLocal);
                    Console.WriteLine("?Connected: {0}", printer.IsConnected);

                    // printer type specific properties
                    ILabelWriterPrinter labelWriterPrinter = printer as ILabelWriterPrinter;
                    if (labelWriterPrinter != null)
                    {
                        Console.WriteLine("Printer Type: LabelWriterPrinter");
                        Console.WriteLine("?Twin Turbo: {0}", labelWriterPrinter.IsTwinTurbo);
                    }

                    ITapePrinter tapePrinter = printer as ITapePrinter;
                    if (tapePrinter != null)
                    {
                        Console.WriteLine("Printer Type: TapePrinter");
                        Console.WriteLine("?AutoCutSupported: {0}", tapePrinter.IsAutoCutSupported);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
