//***********************************************************************
// CHOOSEWINDOWDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_WINDOWS_DIALOG
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

// ChooseWindowDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "ChooseWindowDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

extern HWND SelectedWindow;
/////////////////////////////////////////////////////////////////////////////
// CChooseWindowDlg dialog


CChooseWindowDlg::CChooseWindowDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CChooseWindowDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CChooseWindowDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void CChooseWindowDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CChooseWindowDlg)
	DDX_Control(pDX, IDC_WINDOWS_LIST, m_WindowsList);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CChooseWindowDlg, CDialog)
	//{{AFX_MSG_MAP(CChooseWindowDlg)
	ON_LBN_DBLCLK(IDC_WINDOWS_LIST, OnDblclkWindowsList)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam)
{
	char name[30];
	::GetWindowText(hwnd, name, 30);
	if (name[0] != 0 && hwnd != NULL)
		((CListBox *)lParam)->AddString(name);
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CChooseWindowDlg message handlers

BOOL CChooseWindowDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// Populate windows list with the available windows names
	::EnumWindows(&EnumWindowsProc, (LPARAM)(&m_WindowsList));
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CChooseWindowDlg::OnDblclkWindowsList() 
{
	// Return selected window handle
	CString str;
	m_WindowsList.GetText(m_WindowsList.GetCurSel(), str);
	SelectedWindow = FindWindow(NULL, str)->GetSafeHwnd();
	EndDialog(IDOK);
}
