// PrintLabel.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <vector>
#include "PrintLabel.h"

using namespace std;
using namespace DYMO_Label_Framework;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
    try
    {
        CoInitialize(NULL);

        IFrameworkPtr framework(__uuidof(Framework));

        // parse the parameters here
        // /printer = printer name
        // /tray = paper tray selection (0 = left, 1 = right, 2 = auto)
        // /copies = number of copies
        // /objdata = (name of the label object to set data=object data)
        // (i.e. /objdata "text=hello world!%20This is a test label")

        CString param, PrinterName, FileName;
        vector<CString> ObjDataList;
        int Tray = 2, Copies = 1, i = 1;
        while (i < argc)
        {
            param = CString(argv[i]).Trim();
            if (!param.CompareNoCase(L"/printer"))
            {	
                PrinterName = argv[++i];
            }
            else if (!param.CompareNoCase(L"/tray"))
            {				
                Tray = _tstoi(argv[++i]);
            }
            else if (!param.CompareNoCase(L"/copies"))
            {				
                Copies = _tstoi(argv[++i]);
            }
            else if (!param.CompareNoCase(L"/objdata"))
            {				
                ObjDataList.push_back(argv[++i]);
            }
            else
            {
                FileName = argv[i];
            }				
            i++;
        }

        if (PrinterName.IsEmpty())
        {
            throw L"printer is not specified";
            //m_DymoAddIn.SelectPrinter(PrinterName);
        }

        if (FileName.IsEmpty())
        {
            throw L"label file is not specified";
            //m_DymoAddIn.Open(FileName);
        }

        ILabelPtr label = framework->OpenLabel(_bstr_t(FileName));

        // set object data	
        int addr_i = 0;
        CString ObjName, ObjData;
        for (i = 0; i < int(ObjDataList.size()); i++)
        {
            ObjData = ObjDataList[i];
            int j = ObjData.Find(L'=');
            // 1. extract object name
            ObjName = ObjData.Left(j);

            // 2. extract object data
            ObjData = ObjData.Right(ObjData.GetLength() - j - 1);

            // 3. replace all %20 with \n
            ObjData.Replace(L"%20", L"\n");

            if (!ObjName.IsEmpty())
                //m_DymoLabels.SetField(ObjName, ObjData);
                label->SetObjectText(_bstr_t(ObjName), _bstr_t(ObjData));
            else
                //m_DymoLabels.SetAddress(++addr_i, ObjData);
                label->SetAddressText(++addr_i, _bstr_t(ObjData));
        }		

        //m_DymoAddIn.Print2(Copies, false, Tray);
        IPrinterPtr printer = framework->GetPrinterByName(_bstr_t(PrinterName));
        IPrintParamsPtr printParams;

        if (ILabelWriterPrinterPtr(printer).GetInterfacePtr() != NULL)
        {
            // LabelWriter printer - print using LabelWriter print params
            ILabelWriterPrintParamsPtr labelWriterPrintParams(__uuidof(LabelWriterPrintParams));
            printParams = labelWriterPrintParams;

            // set tray
            RollSelection rollSelection = RollSelection_Auto;
            switch (Tray)
            {
            case 0:
                rollSelection = RollSelection_Left;
                break;
            case 1:
                rollSelection = RollSelection_Right;
                break;
            }
            labelWriterPrintParams->PutRollSelection(rollSelection);
        }
        else if (ITapePrinterPtr(printer).GetInterfacePtr() != NULL)
        {
            // tape print params
            ITapePrintParamsPtr tapePrintParams(__uuidof(TapePrintParams));
            printParams = tapePrintParams;
        }
        else
        {
            throw L"Unknown printer type";
        }

        // common print params
        printParams->PutCopies(Copies);

        label->Print(printer, printParams);


        return 0;

    }
    catch(_com_error e)
    {
        CString message =  e.Description();
        if (message.IsEmpty())
            message = e.ErrorMessage();

        fwprintf(stderr, message);
        return 1;
    }
    catch(const wchar_t* message)
    {
        fwprintf(stderr, message);
        return 2;
    }

}
