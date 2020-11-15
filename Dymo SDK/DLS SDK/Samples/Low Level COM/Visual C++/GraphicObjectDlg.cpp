//***********************************************************************
// GRAPHICOBJECTDLG.CPP
// Written 04/15/99 by Alexei Zapari
//
// This implements supporting dialog with ID: IDD_GRAPHIC_OBJECT_DIALOG
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

// GraphicObjectDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "GraphicObjectDlg.h"
#include "ChooseWindowDlg.h"
#include <afxctl.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


HWND SelectedWindow;	// used for choosing window

/////////////////////////////////////////////////////////////////////////////
// CGraphicObjectDlg dialog


CGraphicObjectDlg::CGraphicObjectDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CGraphicObjectDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CGraphicObjectDlg)
	m_GraphicSource = 0;
	m_FileName = _T("");
	m_BitmapHandle = _T("");
	m_PaletteHandle = _T("");
	m_WindowHandle = _T("");
	m_Border = 0;
	m_BorderColor = _T("");
	//}}AFX_DATA_INIT
}


void CGraphicObjectDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CGraphicObjectDlg)
	DDX_Text(pDX, IDC_GRAPHICOBJ_GRAPHICSOURCE, m_GraphicSource);
	DDV_MinMaxLong(pDX, m_GraphicSource, 0, 3);
	DDX_Text(pDX, IDC_GRAPHICOBJ_FILENAME, m_FileName);
	DDX_Text(pDX, IDC_GRAPHICOBJ_BITMAPHANDLE, m_BitmapHandle);
	DDX_Text(pDX, IDC_GRAPHICOBJ_PALETTEHANDLE, m_PaletteHandle);
	DDX_Text(pDX, IDC_GRAPHICOBJ_WINDOWHANDLE, m_WindowHandle);
	DDX_Text(pDX, IDC_GRAPHICOBJ_BORDER, m_Border);
	DDX_Text(pDX, IDC_GRAPHICOBJ_BORDERCOLOR, m_BorderColor);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CGraphicObjectDlg, CDialog)
	//{{AFX_MSG_MAP(CGraphicObjectDlg)
	ON_BN_CLICKED(IDC_FILENAME_CHANGE, OnFileNameChangeClick)
	ON_BN_CLICKED(IDC_BITMAP_CHANGE, OnBitmapChangeClick)
	ON_BN_CLICKED(IDC_WINDOWHANDLE_CHANGE, OnWindowHandleChangeClick)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGraphicObjectDlg message handlers

void CGraphicObjectDlg::OnFileNameChangeClick() 
{
	// Loads image from file
	CFileDialog fodlg(TRUE);
	if (fodlg.DoModal() == IDOK)
	{
		m_GraphicSource = 0;
		m_FileName = fodlg.GetPathName();
		UpdateData(FALSE);
	}
}

void CGraphicObjectDlg::OnBitmapChangeClick() 
{
	// Loads bitmap from resource
	m_GraphicSource = 1;
	OLE_HANDLE handle;
	static CPictureHolder PictureHolder;
	PictureHolder.CreateFromBitmap(IDB_SAMPLE_BITMAP);
	PictureHolder.m_pPict->get_Handle(&handle);
	m_BitmapHandle.Format("0x%x", handle);
	PictureHolder.m_pPict->get_hPal(&handle);
	m_PaletteHandle.Format("0x%x", handle);
	UpdateData(FALSE);
}

void CGraphicObjectDlg::OnWindowHandleChangeClick() 
{
	CChooseWindowDlg dlg;
	if (dlg.DoModal() == IDOK)
	{
		m_GraphicSource = 2;
		m_WindowHandle.Format("0x%x", SelectedWindow);
		UpdateData(FALSE);
	}
}
