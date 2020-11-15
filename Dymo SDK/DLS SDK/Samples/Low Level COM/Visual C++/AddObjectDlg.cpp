//***********************************************************************
// ADDOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_ADDOBJECT_DIALOG 
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

// AddObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "AddObjectDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


BOOL bAddObject;

/////////////////////////////////////////////////////////////////////////////
// CAddObjectDlg dialog


CAddObjectDlg::CAddObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CAddObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CAddObjectDlg)
	m_Height = 0;
	m_Name = _T("");
	m_Rotation = 0;
	m_Width = 0;
	m_X = 0;
	m_Y = 0;
	m_ObjType = -1;
	//}}AFX_DATA_INIT
}


void CAddObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAddObjectDlg)
	DDX_Text(pDX, IDC_ADDHEIGHT, m_Height);
	DDX_Text(pDX, IDC_ADDNAME, m_Name);
	DDX_Text(pDX, IDC_ADDROTATION, m_Rotation);
	DDX_Text(pDX, IDC_ADDWIDTH, m_Width);
	DDX_Text(pDX, IDC_ADDX, m_X);
	DDX_Text(pDX, IDC_ADDY, m_Y);
	DDX_CBIndex(pDX, IDC_OBJTYPE, m_ObjType);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CAddObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CAddObjectDlg)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAddObjectDlg message handlers

BOOL CAddObjectDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// Display appropriate dialog caption
	if (bAddObject)
		SetWindowText("Add Object");
	else
		SetWindowText("Modify Object's General Attributes");
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
