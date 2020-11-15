// VC Tester.h : main header file for the VC TESTER application
//

#if !defined(AFX_VCTESTER_H__E3CE2E84_FC96_11D2_BE58_0000E8D4216C__INCLUDED_)
#define AFX_VCTESTER_H__E3CE2E84_FC96_11D2_BE58_0000E8D4216C__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CVCTesterApp:
// See VC Tester.cpp for the implementation of this class
//

class CVCTesterApp : public CWinApp
{
public:
	CVCTesterApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVCTesterApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CVCTesterApp)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VCTESTER_H__E3CE2E84_FC96_11D2_BE58_0000E8D4216C__INCLUDED_)
