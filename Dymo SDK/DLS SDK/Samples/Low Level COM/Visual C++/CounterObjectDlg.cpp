//***********************************************************************
// COUNTEROBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_COUNTER_OBJECT_DIALOG
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

// CounterObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "CounterObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CCounterObjectDlg dialog


CCounterObjectDlg::CCounterObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CCounterObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CCounterObjectDlg)
	m_PreText = _T("");
	m_PostText = _T("");
	m_Start = 0;
	m_Current = 0;
	m_Width = 0;
	m_Increment = 0;
	m_UseLeadingZeros = FALSE;
	m_Text = _T("");
	m_Font1 = _T("");
	m_Font2 = _T("");
	m_Justify = 0;
	m_Mirrored = FALSE;
	m_Vertical = FALSE;
	m_TextColor = _T("");
	m_BackGroundColor = _T("");
	m_VJustify = 0;
	//}}AFX_DATA_INIT
}


void CCounterObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CCounterObjectDlg)
	DDX_Text(pDX, IDC_COUNTEROBJ_PRETEXT, m_PreText);
	DDX_Text(pDX, IDC_COUNTEROBJ_POSTTEXT, m_PostText);
	DDX_Text(pDX, IDC_COUNTEROBJ_START, m_Start);
	DDX_Text(pDX, IDC_COUNTEROBJ_CURRENT, m_Current);
	DDX_Text(pDX, IDC_COUNTEROBJ_WIDTH, m_Width);
	DDX_Text(pDX, IDC_COUNTEROBJ_INCREMENT, m_Increment);
	DDX_Check(pDX, IDC_COUNTEROBJ_USELEADINGZEROS, m_UseLeadingZeros);
	DDX_Text(pDX, IDC_COUNTEROBJ_TEXT, m_Text);
	DDX_Text(pDX, IDC_COUNTEROBJ_FONT1, m_Font1);
	DDX_Text(pDX, IDC_COUNTEROBJ_FONT2, m_Font2);
	DDX_Text(pDX, IDC_COUNTEROBJ_JUSTIFY, m_Justify);
	DDX_Check(pDX, IDC_COUNTEROBJ_MIRRORED, m_Mirrored);
	DDX_Check(pDX, IDC_COUNTEROBJ_VERTICAL, m_Vertical);
	DDX_Text(pDX, IDC_COUNTEROBJ_TEXTCOLOR, m_TextColor);
	DDX_Text(pDX, IDC_COUNTEROBJ_BACKGROUNDCOLOR, m_BackGroundColor);
	DDX_Text(pDX, IDC_COUNTEROBJ_VJUSTIFY, m_VJustify);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CCounterObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CCounterObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CCounterObjectDlg message handlers
