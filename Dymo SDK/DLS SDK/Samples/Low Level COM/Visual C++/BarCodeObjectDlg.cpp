//***********************************************************************
// BARCODEOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_BARCODE_OBJECT_DIALOG
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

// BarCodeObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "BarCodeObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CBarCodeObjectDlg dialog


CBarCodeObjectDlg::CBarCodeObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CBarCodeObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CBarCodeObjectDlg)
	m_Text = _T("");
	m_Font = _T("");
	m_TextPos = 0;
	m_BCType = -1;
	m_Size = 0;
	m_Justify = 0;
	m_Link = _T("");
	//}}AFX_DATA_INIT
}


void CBarCodeObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CBarCodeObjectDlg)
	DDX_Text(pDX, IDC_BARCODEOBJ_TEXT, m_Text);
	DDX_Text(pDX, IDC_BARCODEOBJ_FONT, m_Font);
	DDX_Text(pDX, IDC_BARCODEOBJ_TEXTPOS, m_TextPos);
	DDX_CBIndex(pDX, IDC_BARCODEOBJ_BCTYPE, m_BCType);
	DDX_Text(pDX, IDC_BARCODEOBJ_SIZE, m_Size);
	DDX_Text(pDX, IDC_BARCODEOBJ_JUSTIFY, m_Justify);
	DDX_Text(pDX, IDC_BARCODEOBJ_LINK, m_Link);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CBarCodeObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CBarCodeObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CBarCodeObjectDlg message handlers
