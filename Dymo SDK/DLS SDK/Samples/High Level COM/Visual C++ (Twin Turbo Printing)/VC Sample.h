// VC Sample.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols


// CVCSampleApp:
// See VC Sample.cpp for the implementation of this class
//

class CVCSampleApp : public CWinApp
{
public:
	CVCSampleApp();

// Overrides
	public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CVCSampleApp theApp;