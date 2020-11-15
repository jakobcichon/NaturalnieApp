//***********************************************************************
// LINEOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_LINE_OBJECT_DIALOG
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

// LineObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "LineObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CLineObjectDlg dialog


CLineObjectDlg::CLineObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLineObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CLineObjectDlg)
	m_Length = 0;
	m_Orientation = 0;
	m_Thickness = 0;
	m_LineColor = _T("");
	//}}AFX_DATA_INIT
}


void CLineObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CLineObjectDlg)
	DDX_Text(pDX, IDC_LINEOBJ_LENGTH, m_Length);
	DDX_Text(pDX, IDC_LINEOBJ_ORIENTATION, m_Orientation);
	DDX_Text(pDX, IDC_LINEOBJ_THICKNESS, m_Thickness);
	DDX_Text(pDX, IDC_LINEOBJ_LINECOLOR, m_LineColor);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CLineObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CLineObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CLineObjectDlg message handlers
