//***********************************************************************
// PRINTLABELDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_PRINT_DIALOG
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

#include "stdafx.h"
#include "VC Tester.h"
#include "PrintLabelDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPrintLabelDlg dialog


CPrintLabelDlg::CPrintLabelDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPrintLabelDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CPrintLabelDlg)
	m_DeviceName = _T("");
	m_Port = _T("");
	m_Quantity = 0;
	m_IsShowDialog = FALSE;
	//}}AFX_DATA_INIT
}


void CPrintLabelDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CPrintLabelDlg)
	DDX_Control(pDX, IDC_QUANTITY_SPIN, m_Spin);
	DDX_Text(pDX, IDC_DEVICE_NAME, m_DeviceName);
	DDX_Text(pDX, IDC_PORT, m_Port);
	DDX_Text(pDX, IDC_QUANTITY, m_Quantity);
	DDV_MinMaxLong(pDX, m_Quantity, 0, 100);
	DDX_Check(pDX, IDC_SHOWDIALOG, m_IsShowDialog);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CPrintLabelDlg, CDialog)
	//{{AFX_MSG_MAP(CPrintLabelDlg)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPrintLabelDlg message handlers

BOOL CPrintLabelDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// Set default dialog values
	m_Spin.SetRange(0, 100);
	m_DeviceName = "DYMO LabelWriter 330 Turbo";
	m_Port = "COM1:";
	m_Quantity = 1;
	m_IsShowDialog = TRUE;
	UpdateData(FALSE);
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
