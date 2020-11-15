//***********************************************************************
// hlOLEDemoDlg.cpp : Defines the class behaviors for the dialog.
// Written 04/27/99 by Sergey Smirnov
//
// This program is meant to demonstrate the methods used to communicate with
// the Dymo Label Software via High-Level OLE Automation interface from C++.
//
// This code was written and tested using MS Visual C++ 6.0, under Windows 95.
//
// Copyright 1999, 2002 DYMO Corporation
//
// Permission to use, copy, modify, and distribute this software for any
// purpose and without fee is hereby granted.
//
//***********************************************************************


#include "stdafx.h"
#include "hlOLEDemo.h"
#include "hlOLEDemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define APPNAME "High Level OLE Demo"

//objects to communicate with DLS
IDymoAddIn DymoAddIn;
IDymoLabels DymoLabels;

//create OLE objects to communicate with DLS
//return TRUE on success
BOOL CreateOLEObjects()
{
	
	DymoAddIn.CreateDispatch("Dymo.DymoAddIn");
	DymoLabels.CreateDispatch("Dymo.DymoLabels");
	//check if creations were successful
	BOOL result = DymoAddIn.m_lpDispatch && DymoLabels.m_lpDispatch;
	if (!result)
		MessageBox(0,"Unable to create OLE objects",APPNAME, MB_OK|MB_ICONEXCLAMATION);
	return result;
}

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoDlg dialog

CHlOLEDemoDlg::CHlOLEDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CHlOLEDemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CHlOLEDemoDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CHlOLEDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CHlOLEDemoDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CHlOLEDemoDlg, CDialog)
	//{{AFX_MSG_MAP(CHlOLEDemoDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_FIELDS, OnSelchangeFields)
	ON_BN_CLICKED(IDC_OPENFILE, OnOpenfile)
	ON_BN_CLICKED(IDC_SAVEFILE, OnSavefile)
	ON_BN_CLICKED(IDC_GETFIELDS, OnGetfields)
	ON_BN_CLICKED(IDC_HIDEDLS, OnHidedls)
	ON_BN_CLICKED(IDC_SYSTRAY, OnSystray)
	ON_BN_CLICKED(IDC_PRINT, OnPrint)
	ON_BN_CLICKED(IDC_SETADDRESS, OnSetaddress)
	ON_BN_CLICKED(IDC_SETTEXT, OnSettext)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHlOLEDemoDlg message handlers

BOOL CHlOLEDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	if (!CreateOLEObjects()) SendMessage(WM_CLOSE); //Close the dialog if we unable 
													//to create OLE objects
	//DLS hidden by default
	((CButton *)GetDlgItem(IDC_HIDEDLS))->SetCheck(TRUE);

	//retrieve "variable only" objects by default
	((CButton *)GetDlgItem(IDC_VARONLY))->SetCheck(TRUE);
	
	//No POSTNET by default
	((CButton *)GetDlgItem(IDC_RBNONE))->SetCheck(TRUE);
	
	//link Spin button to NADDRESS edit control
	((CSpinButtonCtrl *)GetDlgItem(IDC_SPIN))->SetBuddy(GetDlgItem(IDC_NADDRESS));


	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CHlOLEDemoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CHlOLEDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CHlOLEDemoDlg::OnSelchangeFields() 
{
	char s[255];
	//get currently selected field 
	GetDlgItemText(IDC_FIELDS,s,255);
	//retrieve field content and place it in the edit box
	SetDlgItemText(IDC_FIELDTEXT,DymoLabels.GetText(s));
	
}

void CHlOLEDemoDlg::OnOpenfile() 
{
	//standard open dialog
	CFileDialog od(TRUE);
	char ss[256];
	DWORD l=256,x;
	HKEY hKey;

	RegOpenKeyEx(HKEY_CURRENT_USER, "Software\\DYMO\\LabelWriter\\Directories", 0,KEY_ALL_ACCESS,&hKey);
	RegQueryValueEx(hKey, "Label Directory", NULL, &x, (LPBYTE)ss, &l);
	RegCloseKey(hKey);

	SetCurrentDirectory(ss);

	//if user selected a file then open it
	if (od.DoModal()==IDOK)
		DymoAddIn.Open(od.GetPathName());
	//update available fields for newly loaded label
	OnGetfields();
	
}

void CHlOLEDemoDlg::OnSavefile() 
{
	//standard SaveAs dialog
	CFileDialog sd(FALSE);
	char ss[256];
	DWORD l=256,x;
	HKEY hKey;

	RegOpenKeyEx(HKEY_CURRENT_USER, "Software\\DYMO\\LabelWriter\\Directories", 0,KEY_ALL_ACCESS,&hKey);
	RegQueryValueEx(hKey, "Label Directory", NULL, &x, (LPBYTE)ss, &l);
	RegCloseKey(hKey);

	SetCurrentDirectory(ss);

	//if user selected a file then save it
	if (sd.DoModal()==IDOK)
		DymoAddIn.SaveAs(sd.GetPathName());
	
}

void CHlOLEDemoDlg::OnGetfields() 
{
	char szBuf[256], *s;
	int i;

	//clear combobox
	SendDlgItemMessage(IDC_FIELDS, CB_RESETCONTENT, 0, 0);
	//retrieve available fields depending on VarOnly checkbox and copy them into szBuf
	strcpy(szBuf,DymoLabels.GetObjectNames(((CButton *)GetDlgItem(IDC_VARONLY))->GetCheck()));

	// first, divide the returned data into individual strings
	for (i = 0; szBuf[i]; i++) 
	{
		if (szBuf[i] == '|' || szBuf[i] == '\r' || szBuf[i] == '\n') szBuf[i] = NULL;
	}
	szBuf[i+1]=NULL;
	// Now, insert each string in the list box
	s = szBuf;
	while (*s) 
	{
		SendDlgItemMessage(IDC_FIELDS, CB_ADDSTRING, 0, (LPARAM) (LPCSTR)s);
		s += lstrlen(s)+1;
	}
	//select the first field by default
	SendDlgItemMessage(IDC_FIELDS, CB_SETCURSEL, 0, 0);
	//update field content
	OnSelchangeFields();

	CSpinButtonCtrl *sb = (CSpinButtonCtrl*)GetDlgItem(IDC_SPIN);
	
	//request number of address fields
    int p = DymoLabels.GetAddressFieldCount();

    if (p == 0)
	{
        //set range for spin control
		sb->SetRange(0,0);
        sb->SetPos(0);
		//set default address #
        SetDlgItemInt(IDC_NADDRESS,0);
	}
    else
	{
		//set default address #
        SetDlgItemInt(IDC_NADDRESS,1);
        //set range for spin control
		sb->SetRange(1,p);
	}
    
	//enable/disable controls if needed
    SendDlgItemMessage(IDC_NADDRESS,WM_ENABLE,(p > 0),NULL);
    SendDlgItemMessage(IDC_SPIN,WM_ENABLE,(p > 0),NULL);
        
}

void CHlOLEDemoDlg::OnHidedls() 
{
	//hide or show DLS depending on checkbox state
	if (((CButton *)GetDlgItem(IDC_HIDEDLS))->GetCheck())
		DymoAddIn.Hide();
	else
		DymoAddIn.Show();
	
}

void CHlOLEDemoDlg::OnSystray() 
{
	//minimize to or restore from windows systray
	//depending on Sys Tray check box
	DymoAddIn.SysTray(((CButton *)GetDlgItem(IDC_SYSTRAY))->GetCheck());
}

void CHlOLEDemoDlg::OnPrint() 
{
	//print one copy and display progress dialog
	DymoAddIn.Print(1,TRUE);
}

void CHlOLEDemoDlg::OnCancel() 
{
	//free OLE objects before quit
	DymoAddIn.ReleaseDispatch();	
	DymoLabels.ReleaseDispatch();	

	CDialog::OnCancel();
}

void CHlOLEDemoDlg::OnSetaddress() 
{

	//get amount of address field available
	int MaxN = DymoLabels.GetAddressFieldCount();

	if (MaxN == 0)
	{
        MessageBox("There is no address field on the label.", APPNAME, MB_OK|MB_ICONEXCLAMATION);
	}
    else 
	{
		int N;
		//get # of address to modify
		GetDlgItemInt(IDC_NADDRESS,&N);
        if (N<1 || N>MaxN)
		{
			char msg[255];
			wsprintf(msg,"Max address number is %d.",MaxN);
			MessageBox(msg, APPNAME, MB_OK|MB_ICONEXCLAMATION);
		}
        else 
		{
			char s[255];
			//get address from edit control
			GetDlgItemText(IDC_ADDRESSTEXT,s,255);
			//set address
            DymoLabels.SetAddress(N, s);
            //set POSTNET barcode position
            if (((CButton *)GetDlgItem(IDC_RBNONE))->GetCheck()) 
				DymoLabels.PostNet (N, "None");
            if (((CButton *)GetDlgItem(IDC_RBABOVE))->GetCheck()) 
				DymoLabels.PostNet (N, "Top");
            if (((CButton *)GetDlgItem(IDC_RBBELOW))->GetCheck()) 
				DymoLabels.PostNet (N, "Bottom");
		}
	}
}

void CHlOLEDemoDlg::OnSettext() 
{
	char field[255],data[255];
	//get field name to update
	GetDlgItemText(IDC_FIELDS,field,255);
	//get data
	GetDlgItemText(IDC_FIELDTEXT,data,255);
	//update field
	DymoLabels.SetField(field,data);
}
