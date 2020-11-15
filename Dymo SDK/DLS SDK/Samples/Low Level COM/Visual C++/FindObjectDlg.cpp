//***********************************************************************
// FINDOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_FINDOBJECT_DIALOG
// for main MFC application.
//
// This program is meant to demonstrate the methods used to communicate with
// the Dymo Label Software DLL via LabelServer Automation Server interface 
// from C++.
//
// This code was written and tested using MS Visual C++ 6.0, under Windows 95.
//
// Copyright 1996,2002 DYMO Corporation
//
// Permission to use, copy, modify, and distribute this software for any
// purpose and without fee is hereby granted.
//
//***********************************************************************

// FindObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "FindObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CFindObjectDlg dialog


CFindObjectDlg::CFindObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CFindObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CFindObjectDlg)
	m_ObjectName = _T("");
	//}}AFX_DATA_INIT
}


void CFindObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CFindObjectDlg)
	DDX_Text(pDX, IDC_OBJECTNAME, m_ObjectName);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CFindObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CFindObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFindObjectDlg message handlers
