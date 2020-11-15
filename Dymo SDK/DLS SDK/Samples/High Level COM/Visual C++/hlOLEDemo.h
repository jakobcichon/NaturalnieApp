//***********************************************************************
// hlOLEDemo.h : main header file for the HLOLEDEMO application
// Written 04/27/99 by Sergey Smirnov
//
// This program is meant to demonstrate the methods used to communicate with
// the Dymo Label Software via High-Level OLE Automation interface from C++.
//
// This code was written and tested using MS Visual C++ 6.0, under Windows 95.
//
// Copyright 1999 Dymo-CoStar Corporation
//
// Permission to use, copy, modify, and distribute this software for any
// purpose and without fee is hereby granted.
//
//***********************************************************************


#if !defined(AFX_HLOLEDEMO_H__92096F16_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_)
#define AFX_HLOLEDEMO_H__92096F16_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoApp:
// See hlOLEDemo.cpp for the implementation of this class
//

class CHlOLEDemoApp : public CWinApp
{
public:
	CHlOLEDemoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHlOLEDemoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CHlOLEDemoApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_HLOLEDEMO_H__92096F16_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_)
