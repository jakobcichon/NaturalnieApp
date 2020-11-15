//***********************************************************************
// hlOLEDemoDlg.h : header file
// Written 04/27/99 by Sergey Smirnov
//
// This program is meant to demonstrate the methods used to communicate with
// the Dymo Label Software via High-Level OLE Automation interface from C++.
//
// This code was written and tested using MS Visual C++ 6.0, under Windows 95.
//
// Copyright 1999 Dymo-CoStar Corporation
//
// Permission to use, copy, modify, and distribute this software for any
// purpose and without fee is hereby granted.
//
//***********************************************************************


#if !defined(AFX_HLOLEDEMODLG_H__92096F18_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_)
#define AFX_HLOLEDEMODLG_H__92096F18_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "dymolbl.h"

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoDlg dialog

class CHlOLEDemoDlg : public CDialog
{
// Construction
public:
	CHlOLEDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CHlOLEDemoDlg)
	enum { IDD = IDD_HLOLEDEMO_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHlOLEDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CHlOLEDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeFields();
	afx_msg void OnOpenfile();
	afx_msg void OnSavefile();
	afx_msg void OnGetfields();
	afx_msg void OnHidedls();
	afx_msg void OnSystray();
	afx_msg void OnPrint();
	virtual void OnCancel();
	afx_msg void OnSetaddress();
	afx_msg void OnSettext();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_HLOLEDEMODLG_H__92096F18_F7EC_11D2_BE58_0000E8D4216C__INCLUDED_)
