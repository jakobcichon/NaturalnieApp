//***********************************************************************
// TEXTOBJECTLDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_TEXT_OBJECT_DIALOG
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

// TextObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "TextObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTextObjectDlg dialog


CTextObjectDlg::CTextObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTextObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTextObjectDlg)
	m_Text = _T("");
	m_Font1 = _T("");
	m_Font2 = _T("");
	m_Justify = 0;
	m_VJustify = 0;
	m_Mirrored = FALSE;
	m_Vertical = FALSE;
	m_TextColor = _T("");
	m_BackGroundColor = _T("");
	m_IsVariable = FALSE;
	//}}AFX_DATA_INIT
}


void CTextObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTextObjectDlg)
	DDX_Text(pDX, IDC_TEXTOBJ_TEXT, m_Text);
	DDX_Text(pDX, IDC_TEXTOBJ_FONT1, m_Font1);
	DDX_Text(pDX, IDC_TEXTOBJ_FONT2, m_Font2);
	DDX_Text(pDX, IDC_TEXTOBJ_JUSTIFY, m_Justify);
	DDX_Text(pDX, IDC_TEXTOBJ_VJUSTIFY, m_VJustify);
	DDX_Check(pDX, IDC_TEXTOBJ_MIRRORED, m_Mirrored);
	DDX_Check(pDX, IDC_TEXTOBJ_VERTICAL, m_Vertical);
	DDX_Text(pDX, IDC_TEXTOBJ_TEXTCOLOR, m_TextColor);
	DDX_Text(pDX, IDC_TEXTOBJ_BACKGROUNDCOLOR, m_BackGroundColor);
	DDX_Check(pDX, IDC_TEXTOBJ_ISVARIABLE, m_IsVariable);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CTextObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CTextObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTextObjectDlg message handlers
