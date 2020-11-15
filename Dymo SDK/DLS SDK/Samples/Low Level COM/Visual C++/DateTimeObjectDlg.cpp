//***********************************************************************
// DATETIMEOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_DATETIME_OBJECT_DIALOG
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

// DateTimeObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "DateTimeObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDateTimeObjectDlg dialog


CDateTimeObjectDlg::CDateTimeObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDateTimeObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDateTimeObjectDlg)
	m_Text = _T("");
	m_Font1 = _T("");
	m_Font2 = _T("");
	m_Justify = 0;
	m_VJustify = 0;
	m_Mirrored = FALSE;
	m_Vertical = FALSE;
	m_TextColor = _T("");
	m_BackGroundColor = _T("");
	m_PreText = _T("");
	m_PostText = _T("");
	m_Format = 0;
	m_IncludeTime = FALSE;
	m_b24Hour = FALSE;
	//}}AFX_DATA_INIT
}


void CDateTimeObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDateTimeObjectDlg)
	DDX_Text(pDX, IDC_DATETIMEOBJ_TEXT, m_Text);
	DDX_Text(pDX, IDC_DATETIMEOBJ_FONT1, m_Font1);
	DDX_Text(pDX, IDC_DATETIMEOBJ_FONT2, m_Font2);
	DDX_Text(pDX, IDC_DATETIMEOBJ_JUSTIFY, m_Justify);
	DDX_Text(pDX, IDC_DATETIMEOBJ_VJUSTIFY, m_VJustify);
	DDX_Check(pDX, IDC_DATETIMEOBJ_MIRRORED, m_Mirrored);
	DDX_Check(pDX, IDC_DATETIMEOBJ_VERTICAL, m_Vertical);
	DDX_Text(pDX, IDC_DATETIMEOBJ_TEXTCOLOR, m_TextColor);
	DDX_Text(pDX, IDC_DATETIMEOBJ_BACKGROUNDCOLOR, m_BackGroundColor);
	DDX_Text(pDX, IDC_DATETIMEOBJ_PRETEXT, m_PreText);
	DDX_Text(pDX, IDC_DATETIMEOBJ_POSTTEXT, m_PostText);
	DDX_Text(pDX, IDC_DATETIMEOBJ_FORMAT, m_Format);
	DDX_Check(pDX, IDC_DATETIMEOBJ_INCLUDETIME, m_IncludeTime);
	DDX_Check(pDX, IDC_DATETIMEOBJ_B24HOUR, m_b24Hour);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDateTimeObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CDateTimeObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDateTimeObjectDlg message handlers
