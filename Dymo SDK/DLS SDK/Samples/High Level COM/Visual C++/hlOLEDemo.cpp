//***********************************************************************
// hlOLEDemo.cpp : Defines the class behaviors for the application.
// Written 04/27/99 by Sergey Smirnov
//
// This program is meant to demonstrate the methods used to communicate with
// the Dymo Label Software via High-Level OLE Automation interface from C++.
//
// This code was written and tested using MS Visual C++ 6.0, under Windows 95.
//
// Copyright 1999, 2002 DYMO Corporation
//
// Permission to use, copy, modify, and distribute this software for any
// purpose and without fee is hereby granted.
//
//***********************************************************************

#include "stdafx.h"
#include "hlOLEDemo.h"
#include "hlOLEDemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoApp

BEGIN_MESSAGE_MAP(CHlOLEDemoApp, CWinApp)
	//{{AFX_MSG_MAP(CHlOLEDemoApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoApp construction

CHlOLEDemoApp::CHlOLEDemoApp()
{
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CHlOLEDemoApp object

CHlOLEDemoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoApp initialization

BOOL CHlOLEDemoApp::InitInstance()
{
	AfxEnableControlContainer();

	AfxOleInit();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	CHlOLEDemoDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{

	}
	else if (nResponse == IDCANCEL)
	{

	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
