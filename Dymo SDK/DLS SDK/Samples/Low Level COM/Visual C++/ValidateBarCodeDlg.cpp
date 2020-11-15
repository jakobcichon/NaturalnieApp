//***********************************************************************
// VALIDATEBARCODEDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_VALIDATEBARCODE_DIALOG
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

// ValidateBarCodeDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "ValidateBarCodeDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CValidateBarCodeDlg dialog


CValidateBarCodeDlg::CValidateBarCodeDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CValidateBarCodeDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CValidateBarCodeDlg)
	m_Text = _T("");
	m_Type = -1;
	//}}AFX_DATA_INIT
}


void CValidateBarCodeDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CValidateBarCodeDlg)
	DDX_Control(pDX, IDC_BCTYPE, m_BCType);
	DDX_Text(pDX, IDC_TEXT, m_Text);
	DDX_CBIndex(pDX, IDC_BCTYPE, m_Type);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CValidateBarCodeDlg, CDialog)
	//{{AFX_MSG_MAP(CValidateBarCodeDlg)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CValidateBarCodeDlg message handlers

BOOL CValidateBarCodeDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
