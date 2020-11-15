// VC Tester.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "VC Tester.h"
#include "VC TesterDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CVCTesterApp

BEGIN_MESSAGE_MAP(CVCTesterApp, CWinApp)
	//{{AFX_MSG_MAP(CVCTesterApp)
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVCTesterApp construction

CVCTesterApp::CVCTesterApp()
{
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CVCTesterApp object

CVCTesterApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CVCTesterApp initialization

BOOL CVCTesterApp::InitInstance()
{
	AfxEnableControlContainer();
	AfxOleInit();
	// Standard initialization

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	CVCTesterDlg dlg;
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
