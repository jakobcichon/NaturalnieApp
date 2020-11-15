//***********************************************************************
// ADDRESSOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_ADDRESS_OBJECT_DIALOG
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

// AddressObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "AddressObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAddressObjectDlg dialog


CAddressObjectDlg::CAddressObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CAddressObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CAddressObjectDlg)
	m_Text = _T("");
	m_Font1 = _T("");
	m_Font2 = _T("");
	m_Justify = 0;
	m_VJustify = 0;
	m_Mirrored = FALSE;
	m_Vertical = FALSE;
	m_TextColor = _T("");
	m_BackGroundColor = _T("");
	m_BarCodePosition = 0;
	m_b9DigitOnly = FALSE;
	//}}AFX_DATA_INIT
}


void CAddressObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAddressObjectDlg)
	DDX_Text(pDX, IDC_ADDRESSOBJ_TEXT, m_Text);
	DDX_Text(pDX, IDC_ADDRESSOBJ_FONT1, m_Font1);
	DDX_Text(pDX, IDC_ADDRESSOBJ_FONT2, m_Font2);
	DDX_Text(pDX, IDC_ADDRESSOBJ_JUSTIFY, m_Justify);
	DDX_Text(pDX, IDC_ADDRESSOBJ_VJUSTIFY, m_VJustify);
	DDX_Check(pDX, IDC_ADDRESSOBJ_MIRRORED, m_Mirrored);
	DDX_Check(pDX, IDC_ADDRESSOBJ_VERTICAL, m_Vertical);
	DDX_Text(pDX, IDC_ADDRESSOBJ_TEXTCOLOR, m_TextColor);
	DDX_Text(pDX, IDC_ADDRESSOBJ_BACKGROUNDCOLOR, m_BackGroundColor);
	DDX_Text(pDX, IDC_ADDRESSOBJ_BARCODEPOSITION, m_BarCodePosition);
	DDX_Check(pDX, IDC_ADDRESSOBJ_B9DIGITONLY, m_b9DigitOnly);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CAddressObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CAddressObjectDlg)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAddressObjectDlg message handlers
