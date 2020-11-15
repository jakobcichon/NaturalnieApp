//***********************************************************************
// OUTPUTXYDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_OUTPUTXY_DIALOG
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
#include "OutputXYDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/////////////////////////////////////////////////////////////////////////////
// COutputXYDlg dialog


COutputXYDlg::COutputXYDlg(CWnd* pParent /*=NULL*/)
	: CDialog(COutputXYDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(COutputXYDlg)
	m_X = 0;
	m_Y = 0;
	//}}AFX_DATA_INIT
}


void COutputXYDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(COutputXYDlg)
	DDX_Text(pDX, IDC_X, m_X);
	DDX_Text(pDX, IDC_Y, m_Y);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(COutputXYDlg, CDialog)
	//{{AFX_MSG_MAP(COutputXYDlg)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputXYDlg message handlers

BOOL COutputXYDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// Set default dialog values
	m_X = 0;
	m_Y = 0;
	UpdateData(FALSE);
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
