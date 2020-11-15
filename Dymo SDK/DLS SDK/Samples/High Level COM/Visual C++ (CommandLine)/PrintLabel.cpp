// PrintLabel.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "PrintLabel.h"
#include "CDymoAddIn4.h"
#include "CDymoLabels.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// The one and only application object

CWinApp theApp;
CDymoAddIn4 m_DymoAddIn;
CDymoLabels m_DymoLabels;

//const CLSID CLSID_DymoAddIn = {0x09DAFAE2,0x8EB0,0x11D2,{0x8E,0x5D,0x00,0xA0,0x24,0x15,0xE9,0x0F}};
//const CLSID CLSID_DymoLabels = {0x3AAD7661,0x8F83,0x11D2,{0x8E,0x5D,0x00,0xA0,0x24,0x15,0xE9,0x0F}};

using namespace std;

bool CreateDymoObjects()
{
	// create the DymoAddIn
	if (m_DymoAddIn.m_lpDispatch == NULL)
	{		
		if (!m_DymoAddIn.CreateDispatch(_T("Dymo.DymoAddIn")))
		{
			_tprintf(_T("Error: Cannot create the DymoAddIn."));					
			return false;
		}
	}

	// create the DymoLabels
	if (m_DymoLabels.m_lpDispatch == NULL)
	{
		if (!m_DymoLabels.CreateDispatch(_T("Dymo.DymoLabels")))
		{
			_tprintf(_T("Error: Cannot create the DymoLabels."));									
			return false;
		}
	}
	
	return true;
}

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		_tprintf(_T("Fatal Error: MFC initialization failed\n"));
		nRetCode = 1;
	}
	else
	{
		// TODO: code your application's behavior here.


		//Initialize the OLE libraries
		CoInitialize(NULL);

		// Create DYMO COM objects
		if (!CreateDymoObjects())
			nRetCode = 1;
			
		// parse the parameters here
		// /printer = printer name
		// /tray = paper tray selection (0 = left, 1 = right, 2 = auto)
		// /copies = number of copies
		// /objdata = (name of the label object to set data=object data)
		// (i.e. /objdata "text=hello world!%20This is a test label")
		
		CString param, PrinterName, FileName;
		CStringList ObjDataList;
		int Tray = 0, Copies = 1, i = 1;
		while (i < argc)
		{
			param = CString(argv[i]).Trim();
			if (!param.CompareNoCase(_T("/printer")))
			{	
				PrinterName = argv[++i];
			}
			else if (!param.CompareNoCase(_T("/tray")))
			{				
				Tray = _tstoi(argv[++i]);
			}
			else if (!param.CompareNoCase(_T("/copies")))
			{				
				Copies = _tstoi(argv[++i]);
			}
			else if (!param.CompareNoCase(_T("/objdata")))
			{				
				ObjDataList.AddTail(argv[++i]);
			}
			else
			{
				FileName = argv[i];
			}				
			i++;
		}
		
		if (!PrinterName.IsEmpty())
			m_DymoAddIn.SelectPrinter(PrinterName);
			
		if (!FileName.IsEmpty())
			m_DymoAddIn.Open(FileName);
		
		// set object data	
		int addr_i = 0;
		CString ObjName, ObjData;
		for (i = 0; i < ObjDataList.GetCount(); i++)
		{
			ObjData = ObjDataList.GetAt(ObjDataList.FindIndex(i));
			int j = ObjData.Find(_T('='));
			// 1. extract object name
			ObjName = ObjData.Left(j);
			
			// 2. extract object data
			ObjData = ObjData.Right(ObjData.GetLength() - j - 1);
			
			// 3. replace all %20 with \n
			ObjData.Replace(_T("%20"), _T("\n"));

			if (!ObjName.IsEmpty())
				m_DymoLabels.SetField(ObjName, ObjData);
			else
				m_DymoLabels.SetAddress(++addr_i, ObjData);
		}		
					
		m_DymoAddIn.Print2(Copies, false, Tray);
	}

	return nRetCode;
}
