//***********************************************************************
// VCTESTERDLG.CPP
// Written 04/15/99 by Alexei Zapari
// Last update, April, 2002, DLB
//
// This implements main MFC application dialog with ID: IDD_VCTESTER_DIALOG.
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

// VC TesterDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Tester.h"
#include "VC TesterDlg.h"
#include "PrintLabelDlg.h"
#include "OutputXYDlg.h"
#include "ValidateBarCodeDlg.h"
#include "ZoomDlg.h"
#include "FindObjectDlg.h"
#include "AddObjectDlg.h"
#include "TextObjectDlg.h"
#include "AddressObjectDlg.h"
#include "GraphicObjectDlg.h"
#include "RectangleObjectDlg.h"
#include "LineObjectDlg.h"
#include "BarCodeObjectDlg.h"
#include "CounterObjectDlg.h"
#include "DateTimeObjectDlg.h"
#include <afxtempl.h>
#include <afxctl.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CVCTesterDlg dialog

CVCTesterDlg::CVCTesterDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CVCTesterDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CVCTesterDlg)
	m_Shadow = TRUE;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

}

CVCTesterDlg::~CVCTesterDlg()
{
}

void CVCTesterDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CVCTesterDlg)
	DDX_Control(pDX, IDC_LABEL_LIST, m_LabelsList);
	DDX_Control(pDX, IDC_OBJECTS_LIST, m_ObjectsList);
	DDX_Control(pDX, IDC_ZOOM_BUTTON, m_ZoomButton);
	DDX_Control(pDX, IDC_STATIC_PICTURE, m_Picture);
	DDX_Check(pDX, IDC_SHADOW_CHECK, m_Shadow);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CVCTesterDlg, CDialog)
	//{{AFX_MSG_MAP(CVCTesterDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_CLOSE()
	ON_LBN_SELCHANGE(IDC_LABEL_LIST, OnSelchangeLabelsList)
	ON_BN_CLICKED(IDC_LOAD_BUTTON, OnLoadLabelClick)
	ON_BN_CLICKED(IDC_SAVE_BUTTON, OnSaveLabelClick)
	ON_BN_CLICKED(IDC_PRINT_LABEL_BUTTON, OnPrintLabelClick)
	ON_BN_CLICKED(IDC_OUTPUT_BUTTON, OnOutputClick)
	ON_BN_CLICKED(IDC_OUTPUTXY_BUTTON, OnOutputXYClick)
	ON_BN_CLICKED(IDC_VALIDATEBARCODE_BUTTON, OnValidateBarCodeClick)
	ON_BN_CLICKED(IDC_ZOOM_BUTTON, OnZoomClick)
	ON_BN_CLICKED(IDC_SHADOW_CHECK, OnShadowClick)
	ON_BN_CLICKED(IDC_OBJECTS_BUTTON, OnAllObjectsClick)
	ON_BN_CLICKED(IDC_VAROBJECTS_BUTTON, OnVarObjectsClick)
	ON_BN_CLICKED(IDC_BRINGTOFRONT_BUTTON, OnBringToFrontClick)
	ON_BN_CLICKED(IDC_FINDOBJECT_BUTTON, OnFindObjectClick)
	ON_BN_CLICKED(IDC_SENDTOBACK_BUTTON, OnSendToBackClick)
	ON_BN_CLICKED(IDC_DELETE_BUTTON, OnDeleteClick)
	ON_BN_CLICKED(IDC_ADDOBJECT_BUTTON, OnAddObjectClick)
	ON_BN_CLICKED(IDC_GENERAL_BUTTON, OnGeneralClick)
	ON_BN_CLICKED(IDC_COPYTO_BUTTON, OnCopyToClipboardClick)
	ON_BN_CLICKED(IDC_PASTEFROM_BUTTON, OnPasteFromClipboardClick)
	ON_BN_CLICKED(IDC_SPECIAL_BUTTON, OnSpecialClick)
	ON_BN_CLICKED(IDC_GETMODIFIED_BUTTON, OnGetModifiedClick)
	ON_BN_CLICKED(IDC_STATIC_PICTURE, OnStaticPictureClick)

	ON_COMMAND(ID_OBJECT_AT, OnObjectAtSelected)
	ON_COMMAND(ID_OBJECTS_AT, OnObjectsAtSelected)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//////////////////////////////////////////////////////////////////////
// Global variables
extern BOOL bAddObject;	// used for correct caption of 
						// Add/Modify Object's General Attributes dialog

/////////////////////////////////////////////////////////////////////////////
// CVCTesterDlg message handlers

BOOL CVCTesterDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	
	// Create IDispatch object for our LabelServer DLL
	LE.CreateDispatch("Dymo.LabelEngine");
	PopupMenu.LoadMenu(IDR_POPUP_MENU);

	// Count total number of labels available
	char s[50];
	long lc = ((ILabelList)LE.LabelNames()).GetCount();
	wsprintf(s,"Label List (Total Labels = %d)", lc);
	SetDlgItemText(IDC_LBL_LABELLIST,s);
	// and fill labels list with the names of the labels
	for (int i = 1; i <= lc; ++i)
		m_LabelsList.AddString(((ILabelList)LE.LabelNames()).GetItem(i));

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.
   
void CVCTesterDlg::OnPaint() 
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
HCURSOR CVCTesterDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

// Automation servers should not exit when a user closes the UI
//  if a controller still holds on to one of its objects.  These
//  message handlers make sure that if the proxy is still in use,
//  then the UI is hidden but the dialog remains around if it
//  is dismissed.

void CVCTesterDlg::OnClose() 
{
	LE.ReleaseDispatch();
	if (CanExit())
		CDialog::OnClose();
}

BOOL CVCTesterDlg::CanExit()
{
	return TRUE;
}

void CVCTesterDlg::FillLabelInfo()
{
	// Fills label info with label data
		 SetDlgItemText(IDC_LI_LABELNAME,((ILblInfo)LE.LabelInfo()).GetLabelName());
		 SetDlgItemText(IDC_LI_PAPERNAME,((ILblInfo)LE.LabelInfo()).GetPaperName());
		 SetDlgItemInt(IDC_LI_PAPERWIDTH,((ILblInfo)LE.LabelInfo()).GetPaperWidth());
		 SetDlgItemInt(IDC_LI_PAPERHEIGHT,((ILblInfo)LE.LabelInfo()).GetPaperHeight());
		 SetDlgItemInt(IDC_LI_BITMAPWIDTH,((ILblInfo)LE.LabelInfo()).GetBitmapWidth());
		 SetDlgItemInt(IDC_LI_BITMAPHEIGHT,((ILblInfo)LE.LabelInfo()).GetBitmapHeight());
		 SetDlgItemInt(IDC_LI_LABELCOUNT,((ILblInfo)LE.LabelInfo()).GetLabelCount());
		 SetDlgItemInt(IDC_LI_LABELWIDTH,((ILblInfo)LE.LabelInfo()).GetLabelWidth());
		 SetDlgItemInt(IDC_LI_LABELHEIGHT,((ILblInfo)LE.LabelInfo()).GetLabelHeight());
		 SetDlgItemInt(IDC_LI_MODIFIED,((ILblInfo)LE.LabelInfo()).GetModified());
}

void CVCTesterDlg::ReDrawLabel()
{
	// Redraws label picture
	m_Picture.RedrawWindow();

	CWindowDC pWDC(&m_Picture);
	HDC MyHDC = pWDC.GetSafeHdc();
	LE.DrawLabel((long) MyHDC);


  // If the label is displayed for the first time,
	// set current selection of the label list to the first label
	// to show the label to which other information pertain
	if (m_LabelsList.GetCurSel() == LB_ERR)
		m_LabelsList.SetCurSel(0);
}

void CVCTesterDlg::OnSelchangeLabelsList() 
{
	// If the selection of the label list is changed,
	// load new label, and update label info and label picture
	CString CurItem;
	m_LabelsList.GetText(m_LabelsList.GetCurSel( ), CurItem);
	LE.NewLabel(CurItem);
	FillLabelInfo();
	ReDrawLabel();
}

void CVCTesterDlg::OnLoadLabelClick() 
{
	// Loads label from file
	CFileDialog fodlg(TRUE);
	char ss[256];
	DWORD l=256,x;
	HKEY hKey;

	RegOpenKeyEx(HKEY_CURRENT_USER, "Software\\DYMO\\LabelWriter\\Directories", 0,KEY_ALL_ACCESS,&hKey);
	RegQueryValueEx(hKey, "Label Directory", NULL, &x, (LPBYTE)ss, &l);
	RegCloseKey(hKey);

	SetCurrentDirectory(ss);
	if (fodlg.DoModal() == IDOK)
	{
		if (LE.OpenFile(fodlg.GetFileName()))
			FillLabelInfo();
		else 
			MessageBox("OpenFile() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnSaveLabelClick() 
{
	// Saves current label into file
	CFileDialog fodlg(FALSE);
	char ss[256];
	DWORD l=256,x;
	HKEY hKey;

	RegOpenKeyEx(HKEY_CURRENT_USER, "Software\\DYMO\\LabelWriter\\Directories", 0,KEY_ALL_ACCESS,&hKey);
	RegQueryValueEx(hKey, "Label Directory", NULL, &x, (LPBYTE)ss, &l);
	RegCloseKey(hKey);

	SetCurrentDirectory(ss);
	if (fodlg.DoModal() == IDOK)
	{
		if (!LE.SaveFile(fodlg.GetFileName()))
			MessageBox("SaveFile() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnPrintLabelClick() 
{
	// Prints current label
	CPrintLabelDlg pldlg;
	if (pldlg.DoModal() == IDOK)
	{
		if (!LE.PrintLabel(pldlg.m_DeviceName, pldlg.m_Port, pldlg.m_Quantity, pldlg.m_IsShowDialog))
			MessageBox("PrintLabel() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnOutputClick() 
{
	// Prints current label to the default device
	CPrintDialog Mypd(FALSE);
	CDC MyDC;
	DOCINFO di;
	
	Mypd.GetDefaults();
	MyDC.Attach(Mypd.m_pd.hDC);
	di.lpszDocName = "VC Tester: Output() function test";
	di.lpszOutput = NULL;
	di.cbSize = sizeof(di);
	MyDC.StartDoc(&di);
	MyDC.StartPage();
	if (!LE.Output(long(MyDC.GetSafeHdc())))
		MessageBox("Output() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
	MyDC.EndPage();
	MyDC.EndDoc();
	MyDC.Detach();
}

void CVCTesterDlg::OnOutputXYClick() 
{
	// Prints current label to the default device 
	// at the position specified in the dialog
	COutputXYDlg dlg;
	if (dlg.DoModal() == IDOK)
	{
		CPrintDialog Mypd(FALSE);
		CDC MyDC;
		DOCINFO di;
	
		Mypd.GetDefaults();
		MyDC.Attach(Mypd.m_pd.hDC);
		di.lpszDocName = "VC Tester: Output() function test";
		di.lpszOutput = NULL;
		di.cbSize = sizeof(di);
		MyDC.StartDoc(&di);
		MyDC.StartPage();
		if (!LE.OutputXY(dlg.m_X, dlg.m_Y, long(MyDC.GetSafeHdc())))
			MessageBox("OutputXY() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
		MyDC.EndPage();
		MyDC.EndDoc();
		MyDC.Detach();
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnValidateBarCodeClick() 
{
	// Validates bar code of the bar code type 
	// specified in the dialog 
	// and displays appropriate message
	CValidateBarCodeDlg dlg;
	if (dlg.DoModal() == IDOK)
	{
		CString res;
		switch(LE.ValidateBarCode(dlg.m_Text, dlg.m_Type))
		{
		case 0: res = "No Error";
				break;
		case 1: res = "Text contains an invalid character";
				break;
		case 2: res = "Text is too long";
				break;
		case 3: res = "The text string is empty";
				break;
		case 4: res = "The Bar Code type is unsupported";
				break;
		case 5: res = "Numeric only bar code, and text contains non-numeric characters";
				break;
		case 6: res = "Text string must have an odd number of characters";
				break;
		case 7: res = "Text may not contain control characters";
				break;
		case 8: res = "Text may not contain lower case characters";
				break;
		case 9: res = "Text has not 7-bit ASCII characters";
				break;
		case 10: res = "Text has invalid start/stop codes";
				break;
		case 11: res = "Invalid Postnet bar code length (must be 7, 9, or 11 digits only).";
				break;
		case 12: res = "Library bar codes must have 13 or 14 digits";
				break;
		default: res = "UNREGISTERED RESULT!";
		}
		MessageBox("ValidateBarCode() returned: '"+res+"'", NULL, MB_OK | MB_ICONINFORMATION);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnZoomClick() 
{
	// Changes zoom level of the current label
	// displaying new zoom value as the text on the button
	CZoomDlg dlg;
	if (dlg.DoModal() == IDOK)
	{
		LE.SetZoom(dlg.m_Zoom);
		char s[20];
		wsprintf(s,"Zoom: %d%%", dlg.m_Zoom);
		m_ZoomButton.SetWindowText(s);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnShadowClick() 
{
	// When shadow control is clicked,
	// update label info and label picture
	UpdateData(TRUE);
	LE.SetShadow(m_Shadow);
	FillLabelInfo();
	ReDrawLabel();
}

void CVCTesterDlg::OnAllObjectsClick() 
{
	// Enumerates all objects on the current label
	// and fills objects list with their IDs
	m_ObjectsList.ResetContent();
	char s[16];
	long num = ((IObjectList)((IPrintObject)LE.PrintObject()).Objects()).GetCount();
	for (int i = 1; i <= num; ++i)
	{
		wsprintf(s, "0x%x", ((IObjectList)((IPrintObject)LE.PrintObject()).Objects()).GetItem(i));
		m_ObjectsList.AddString(s);
	}
}

void CVCTesterDlg::OnVarObjectsClick() 
{
	// Enumerates all variable objects on the current label
	// and fills objects list with their IDs
	m_ObjectsList.ResetContent();
	char s[16];
	long num = ((IObjectList)((IPrintObject)LE.PrintObject()).VarObjects()).GetCount();
	for (int i = 1; i <= num; ++i)
	{
		wsprintf(s, "0x%x", ((IVarObjectList)((IPrintObject)LE.PrintObject()).VarObjects()).GetItem(i));
		m_ObjectsList.AddString(s);
	}
}

void CVCTesterDlg::OnFindObjectClick() 
{
	// Finds an object (if any) on the current label 
	// by its name specified in the dialog
	// and fills objects list with its ID 
	CFindObjectDlg dlg;
	if (dlg.DoModal() == IDOK)
	{
		m_ObjectsList.ResetContent();
		long objid = ((IPrintObject)LE.PrintObject()).FindObj(dlg.m_ObjectName);
		if (objid == 0)
			MessageBox("FindObj() returned 0 ('Object not found').", NULL, MB_OK | MB_ICONINFORMATION);
		else
		{
			char s[16];
			wsprintf(s, "0x%x", objid);
			m_ObjectsList.AddString(s);
		}
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnBringToFrontClick() 
{
	// Moves the object with the ID selected in the objects list
	// to the foreground of all the other objects on the current label
	int num = m_ObjectsList.GetCaretIndex();
	if (m_ObjectsList.GetSel(num) != LB_ERR)
	{
		CString CurItem;
		m_ObjectsList.GetText(num, CurItem);
		((IPrintObject)LE.PrintObject()).BringToFront(strtol(CurItem, NULL, 16));
		ReDrawLabel();
		// Then updates the objects list by refilling it
		// with the IDs of all objects on the label
		OnAllObjectsClick();
	}
}

void CVCTesterDlg::OnSendToBackClick() 
{
	// Moves the object with the ID selected in the objects list
	// to the background of all the other objects on the current label
	int num = m_ObjectsList.GetCaretIndex();
	if (m_ObjectsList.GetSel(num) != LB_ERR)
	{
		CString CurItem;
		m_ObjectsList.GetText(num, CurItem);
		((IPrintObject)LE.PrintObject()).SendToBack(strtol(CurItem, NULL, 16));
		ReDrawLabel();
		// Then updates the objects list by refilling it
		// with the IDs of all objects on the label
		OnAllObjectsClick();
	}
}

void CVCTesterDlg::OnDeleteClick() 
{
	// Deletes all objects on the current label 
	// selected in the objects list
	int count = m_ObjectsList.GetCount();
	if (count != LB_ERR)
	{
		for (int i=0; i<count; i++)
			if (m_ObjectsList.GetSel(i))
			{
				CString CurItem;
				m_ObjectsList.GetText(i, CurItem);
				((IPrintObject)LE.PrintObject()).Delete(strtol(CurItem, NULL, 16));
			}
		ReDrawLabel();
		// Then updates the objects list by refilling it
		// with the IDs of all the rest objects on the label
		OnAllObjectsClick();
	}
}

void CVCTesterDlg::OnAddObjectClick() 
{
	// Adds a new object to the current label
	// by specifying its general attributes
	CAddObjectDlg dlg;
	bAddObject = TRUE;
	if (dlg.DoModal() == IDOK)
	{
		long objid = ((IPrintObject)LE.PrintObject()).AddObject(dlg.m_ObjType, dlg.m_Name, dlg.m_X, dlg.m_Y, dlg.m_Width, dlg.m_Height, dlg.m_Rotation);
		// Displays ID of the added object
		CString str;
		str.Format("0x%x", objid);
		MessageBox("AddObject() returned objid: '" + str + "'", NULL, MB_OK | MB_ICONINFORMATION);
	}
	ReDrawLabel();
}

void CVCTesterDlg::OnGeneralClick() 
{
	// Shows general attributes of the object on the current label
	// which ID is selected in the objects list
	int num = m_ObjectsList.GetCaretIndex();
	if (m_ObjectsList.GetSel(num) != LB_ERR)
	{
		CString CurItem;
		m_ObjectsList.GetText(num, CurItem);
		long l = strtol(CurItem, NULL, 16);
		
		// Fill dialog fields with object's general attributes
		CAddObjectDlg dlg;
		bAddObject = FALSE;
		ILabelObject ILO = (ILabelObject)((IPrintObject)LE.PrintObject()).LabelObject(l);
		dlg.m_ObjType = ILO.GetObjType();
		dlg.m_Name = ILO.GetName();
		dlg.m_X = ILO.GetX();
		dlg.m_Y = ILO.GetY();
		dlg.m_Width = ILO.GetWidth();
		dlg.m_Height = ILO.GetHeight();
		dlg.m_Rotation = ILO.GetRotation();
		if (dlg.DoModal() == IDOK)
		{
			// Save new general attributes of the object
			ILO.SetName(dlg.m_Name);
			ILO.SetX(dlg.m_X);
			ILO.SetY(dlg.m_Y);
			ILO.SetWidth(dlg.m_Width);
			ILO.SetHeight(dlg.m_Height);
			ILO.SetRotation(dlg.m_Rotation);
		}
		ReDrawLabel();
	}
}

void CVCTesterDlg::OnCopyToClipboardClick() 
{
	// Copies all objects on the current label 
	// selected in the objects list to the clipboard
	int count = m_ObjectsList.GetCount();
	if (count != LB_ERR)
	{
		CArray<long,long> SelIDArray;
		for (int i=0; i<count; i++)
			if (m_ObjectsList.GetSel(i))
			{
				CString CurItem;
				m_ObjectsList.GetText(i, CurItem);
				SelIDArray.Add(strtol(CurItem, NULL, 16));
			}
		SelIDArray.Add(0);
		if (((IPrintObject)LE.PrintObject()).CopyToClipboard(SelIDArray.GetData()))
		{
			// Then displays a message indicating 
			// the number of objects copied
			CString str;
			str.Format("%d", SelIDArray.GetSize() - 1);
			MessageBox(str + " object(s) copied successfully.", NULL, MB_OK | MB_ICONINFORMATION);
		}
		else
			MessageBox("CopyToClipboard() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
	}
}

void CVCTesterDlg::OnPasteFromClipboardClick() 
{
	// Pastes objects from the clipboard onto the current label
	if (((IPrintObject)LE.PrintObject()).PasteFromClipboard())
		ReDrawLabel();
	else
		MessageBox("PasteFromClipboard() returned FALSE!", NULL, MB_OK | MB_ICONSTOP);
}

void CVCTesterDlg::OnSpecialClick() 
{
  // Shows specific attributes of the object on the current label
	// which ID is selected in the objects list
	int num = m_ObjectsList.GetCaretIndex();
	if (m_ObjectsList.GetSel(num) != LB_ERR)
	{
		CString CurItem;
		m_ObjectsList.GetText(num, CurItem);
		long l = strtol(CurItem, NULL, 16);
  
		ILabelObject ILO = (ILabelObject)((IPrintObject)LE.PrintObject()).LabelObject(l);


    // Show dialog corresponding to the type of the object
		switch(ILO.GetObjType())
		{
		case 0: // Object of type TEXT
			{
				CTextObjectDlg dlg;
				ITextObj ITO;
				ITO.AttachDispatch(ILO.m_lpDispatch, false);

				// Fill dialog with default object's special attributes
				dlg.m_Text = ((ITextAttributes)ITO.TextAttributes()).GetText();
				dlg.m_Font1 = ((ITextAttributes)ITO.TextAttributes()).GetFont_1();
				dlg.m_Font2 = ((ITextAttributes)ITO.TextAttributes()).GetFont_2();
				dlg.m_Justify = ((ITextAttributes)ITO.TextAttributes()).GetJustify();
				dlg.m_VJustify = ((ITextAttributes)ITO.TextAttributes()).GetVJustify();
				dlg.m_Mirrored = ((ITextAttributes)ITO.TextAttributes()).GetMirrored();
				dlg.m_Vertical = ((ITextAttributes)ITO.TextAttributes()).GetVertical();
				dlg.m_TextColor.Format("0x%x", ((ITextAttributes)ITO.TextAttributes()).GetTextColor());
				dlg.m_BackGroundColor.Format("0x%x", ((ITextAttributes)ITO.TextAttributes()).GetBackGroundColor());
				dlg.m_IsVariable = ITO.GetIsVariable();

				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					((ITextAttributes)ITO.TextAttributes()).SetText(dlg.m_Text);
					((ITextAttributes)ITO.TextAttributes()).SetFont_1(dlg.m_Font1);
					((ITextAttributes)ITO.TextAttributes()).SetFont_2(dlg.m_Font2);
					((ITextAttributes)ITO.TextAttributes()).SetJustify(dlg.m_Justify);
					((ITextAttributes)ITO.TextAttributes()).SetVJustify(dlg.m_VJustify);
					((ITextAttributes)ITO.TextAttributes()).SetMirrored(dlg.m_Mirrored);
					((ITextAttributes)ITO.TextAttributes()).SetVertical(dlg.m_Vertical);
					((ITextAttributes)ITO.TextAttributes()).SetTextColor(strtol(dlg.m_TextColor, NULL, 16));
					((ITextAttributes)ITO.TextAttributes()).SetBackGroundColor(strtol(dlg.m_BackGroundColor, NULL, 16));
					ITO.SetIsVariable(dlg.m_IsVariable);
				}
			}
			break;
		case 1: // Object of type ADDRESS 
			{
				CAddressObjectDlg dlg;
				IAddressObj IAO;
				IAO.AttachDispatch(ILO.m_lpDispatch, false);

				// Fill dialog with default object's special attributes
				dlg.m_Text = ((ITextAttributes)IAO.TextAttributes()).GetText();
				dlg.m_Font1 = ((ITextAttributes)IAO.TextAttributes()).GetFont_1();
				dlg.m_Font2 = ((ITextAttributes)IAO.TextAttributes()).GetFont_2();
				dlg.m_Justify = ((ITextAttributes)IAO.TextAttributes()).GetJustify();
				dlg.m_VJustify = ((ITextAttributes)IAO.TextAttributes()).GetVJustify();
				dlg.m_Mirrored = ((ITextAttributes)IAO.TextAttributes()).GetMirrored();
				dlg.m_Vertical = ((ITextAttributes)IAO.TextAttributes()).GetVertical();
				dlg.m_TextColor.Format("0x%x", ((ITextAttributes)IAO.TextAttributes()).GetTextColor());
				dlg.m_BackGroundColor.Format("0x%x", ((ITextAttributes)IAO.TextAttributes()).GetBackGroundColor());
				dlg.m_BarCodePosition = IAO.GetBarCodePosition();
				dlg.m_b9DigitOnly = IAO.GetB9DigitOnly();
				
				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					((ITextAttributes)IAO.TextAttributes()).SetText(dlg.m_Text);
					((ITextAttributes)IAO.TextAttributes()).SetFont_1(dlg.m_Font1);
					((ITextAttributes)IAO.TextAttributes()).SetFont_2(dlg.m_Font2);
					((ITextAttributes)IAO.TextAttributes()).SetJustify(dlg.m_Justify);
					((ITextAttributes)IAO.TextAttributes()).SetVJustify(dlg.m_VJustify);
					((ITextAttributes)IAO.TextAttributes()).SetMirrored(dlg.m_Mirrored);
					((ITextAttributes)IAO.TextAttributes()).SetVertical(dlg.m_Vertical);
					((ITextAttributes)IAO.TextAttributes()).SetTextColor(strtol(dlg.m_TextColor, NULL, 16));
					((ITextAttributes)IAO.TextAttributes()).SetBackGroundColor(strtol(dlg.m_BackGroundColor, NULL, 16));
					IAO.SetBarCodePosition(dlg.m_BarCodePosition);
					IAO.SetB9DigitOnly(dlg.m_b9DigitOnly);
				}
			}
			break;
		case 2: // Object of type GRAPHIC
			{
				CGraphicObjectDlg dlg;
				IGraphicObj IGO = (IGraphicObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_GraphicSource = IGO.GetGraphicSource();
				dlg.m_FileName = IGO.GetFileName();
				dlg.m_BitmapHandle.Format("0x%x", IGO.GetBitmapHandle());
				dlg.m_PaletteHandle.Format("0x%x", IGO.GetPaletteHandle());
				dlg.m_WindowHandle.Format("Write Only");
				dlg.m_Border = IGO.GetBorder();
				dlg.m_BorderColor.Format("0x%x", IGO.GetBorderColor());

				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					// (in relation to its graphic source)
					switch(dlg.m_GraphicSource)
					{
					case 0:	// From file
						IGO.SetFileName(dlg.m_FileName);
						break;
					case 1:	// From picture handle (in the bitmap field)
						IGO.SetBitmapHandle(strtol(dlg.m_BitmapHandle, NULL, 16));
						IGO.SetPaletteHandle(strtol(dlg.m_PaletteHandle, NULL, 16));
						break;
					case 2: // From window handle
						IGO.SetWindowHandle(strtol(dlg.m_WindowHandle, NULL, 16));
						break;
					case 3: // From clipboard
						break;
					}
					IGO.SetGraphicSource(dlg.m_GraphicSource);
					IGO.SetBorder(dlg.m_Border);
					IGO.SetBorderColor(strtol(dlg.m_BorderColor, NULL, 16));
				}
			}
			break;
		case 3: // Object of type RECTANGLE 
			{
				CRectangleObjectDlg dlg;
				IRectObj IRO = (IRectObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_bFilled = IRO.GetBFilled();
				dlg.m_Border = IRO.GetBorder();
				dlg.m_BorderColor.Format("0x%x", IRO.GetBorderColor());
				dlg.m_FillColor.Format("0x%x", IRO.GetFillColor());

				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					IRO.SetBFilled(dlg.m_bFilled);
					IRO.SetBorder(dlg.m_Border);
					IRO.SetBorderColor(strtol(dlg.m_BorderColor, NULL, 16));
					IRO.SetFillColor(strtol(dlg.m_FillColor, NULL, 16));
				}
			}
			break;
		case 4: // Object of type LINE 
			{
				CLineObjectDlg dlg;
				ILineObj ILiO = (ILineObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_Length = ILiO.GetLength();
				dlg.m_Orientation = ILiO.GetOrientation();
				dlg.m_Thickness = ILiO.GetThickness();
				dlg.m_LineColor.Format("0x%x", ILiO.GetLineColor());

				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					ILiO.SetLength(dlg.m_Length);
					ILiO.SetOrientation(dlg.m_Orientation);
					ILiO.SetThickness(dlg.m_Thickness);
					ILiO.SetLineColor(strtol(dlg.m_LineColor, NULL, 16));
				}
			}
			break;
		case 5: // Object of type BARCODE
			{
				CBarCodeObjectDlg dlg;
				IBarCodeObj IBCO = (IBarCodeObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_Text = IBCO.GetText();
				dlg.m_Font = IBCO.GetFont();
				dlg.m_TextPos = IBCO.GetTextPos();
				dlg.m_BCType = IBCO.GetBCType();
				dlg.m_Size = IBCO.GetSize();
				dlg.m_Justify = IBCO.GetJustify();
				dlg.m_Link.Format("0x%x", IBCO.GetLink());

				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					IBCO.SetText(dlg.m_Text);
					IBCO.SetFont(dlg.m_Font);
					IBCO.SetTextPos(dlg.m_TextPos);
					IBCO.SetBCType(dlg.m_BCType);
					IBCO.SetSize(dlg.m_Size);
					IBCO.SetJustify(dlg.m_Justify);

					long l = strtol(dlg.m_Link, NULL, 16);
					IBCO.SetLink(l);
				}
			}
			break;
		case 6: // Object of type COUNTER 
			{
				CCounterObjectDlg dlg;
				ICounterObj ICO = (ICounterObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_Text = ((ITextAttributes)ICO.TextAttributes()).GetText();
				dlg.m_Font1 = ((ITextAttributes)ICO.TextAttributes()).GetFont_1();
				dlg.m_Font2 = ((ITextAttributes)ICO.TextAttributes()).GetFont_2();
				dlg.m_Justify = ((ITextAttributes)ICO.TextAttributes()).GetJustify();
				dlg.m_VJustify = ((ITextAttributes)ICO.TextAttributes()).GetVJustify();
				dlg.m_Mirrored = ((ITextAttributes)ICO.TextAttributes()).GetMirrored();
				dlg.m_Vertical = ((ITextAttributes)ICO.TextAttributes()).GetVertical();
				dlg.m_TextColor.Format("0x%x", ((ITextAttributes)ICO.TextAttributes()).GetTextColor());
				dlg.m_BackGroundColor.Format("0x%x", ((ITextAttributes)ICO.TextAttributes()).GetBackGroundColor());
				dlg.m_PreText = ICO.GetPreText();
				dlg.m_PostText = ICO.GetPostText();
				dlg.m_Start = ICO.GetStart();
				dlg.m_Current = ICO.GetCurrent();
				dlg.m_Width = ICO.GetMinWidth();
				dlg.m_Increment = ICO.GetIncrement();
				dlg.m_UseLeadingZeros = ICO.GetUseLeadingZeros();
				
				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					((ITextAttributes)ICO.TextAttributes()).SetText(dlg.m_Text);
					((ITextAttributes)ICO.TextAttributes()).SetFont_1(dlg.m_Font1);
					((ITextAttributes)ICO.TextAttributes()).SetFont_2(dlg.m_Font2);
					((ITextAttributes)ICO.TextAttributes()).SetJustify(dlg.m_Justify);
					((ITextAttributes)ICO.TextAttributes()).SetVJustify(dlg.m_VJustify);
					((ITextAttributes)ICO.TextAttributes()).SetMirrored(dlg.m_Mirrored);
					((ITextAttributes)ICO.TextAttributes()).SetVertical(dlg.m_Vertical);
					((ITextAttributes)ICO.TextAttributes()).SetTextColor(strtol(dlg.m_TextColor, NULL, 16));
					((ITextAttributes)ICO.TextAttributes()).SetBackGroundColor(strtol(dlg.m_BackGroundColor, NULL, 16));
					ICO.SetPreText(dlg.m_PreText);
					ICO.SetPostText(dlg.m_PostText);
					ICO.SetStart(dlg.m_Start);
					ICO.SetCurrent(dlg.m_Current);
					ICO.SetMinWidth(dlg.m_Width);
					ICO.SetIncrement(dlg.m_Increment);
					ICO.SetUseLeadingZeros(dlg.m_UseLeadingZeros);
				}
			}
			break;
		case 7: // Object of type DATE_TIME 
			{
				CDateTimeObjectDlg dlg;
				IDateTimeObj IDTO = (IDateTimeObj)ILO;

				// Fill dialog with default object's special attributes
				dlg.m_Text = ((ITextAttributes)IDTO.TextAttributes()).GetText();
				dlg.m_Font1 = ((ITextAttributes)IDTO.TextAttributes()).GetFont_1();
				dlg.m_Font2 = ((ITextAttributes)IDTO.TextAttributes()).GetFont_2();
				dlg.m_Justify = ((ITextAttributes)IDTO.TextAttributes()).GetJustify();
				dlg.m_VJustify = ((ITextAttributes)IDTO.TextAttributes()).GetVJustify();
				dlg.m_Mirrored = ((ITextAttributes)IDTO.TextAttributes()).GetMirrored();
				dlg.m_Vertical = ((ITextAttributes)IDTO.TextAttributes()).GetVertical();
				dlg.m_TextColor.Format("0x%x", ((ITextAttributes)IDTO.TextAttributes()).GetTextColor());
				dlg.m_BackGroundColor.Format("0x%x", ((ITextAttributes)IDTO.TextAttributes()).GetBackGroundColor());
				dlg.m_PreText = IDTO.GetPreText();
				dlg.m_PostText = IDTO.GetPostText();
				dlg.m_Format = IDTO.GetFormat();
				dlg.m_IncludeTime = IDTO.GetIncludeTime();
				dlg.m_b24Hour = IDTO.GetB24Hour();
				
				if (dlg.DoModal() == IDOK)
				{
					// Save new special attributes of the object
					((ITextAttributes)IDTO.TextAttributes()).SetText(dlg.m_Text);
					((ITextAttributes)IDTO.TextAttributes()).SetFont_1(dlg.m_Font1);
					((ITextAttributes)IDTO.TextAttributes()).SetFont_2(dlg.m_Font2);
					((ITextAttributes)IDTO.TextAttributes()).SetJustify(dlg.m_Justify);
					((ITextAttributes)IDTO.TextAttributes()).SetVJustify(dlg.m_VJustify);
					((ITextAttributes)IDTO.TextAttributes()).SetMirrored(dlg.m_Mirrored);
					((ITextAttributes)IDTO.TextAttributes()).SetVertical(dlg.m_Vertical);
					((ITextAttributes)IDTO.TextAttributes()).SetTextColor(strtol(dlg.m_TextColor, NULL, 16));
					((ITextAttributes)IDTO.TextAttributes()).SetBackGroundColor(strtol(dlg.m_BackGroundColor, NULL, 16));
					IDTO.SetPreText(dlg.m_PreText);
					IDTO.SetPostText(dlg.m_PostText);
					IDTO.SetFormat(dlg.m_Format);
					IDTO.SetIncludeTime(dlg.m_IncludeTime);
					IDTO.SetB24Hour(dlg.m_b24Hour);
				}
			}
			break;
		}
  }
  ReDrawLabel();
}

void CVCTesterDlg::OnGetModifiedClick() 
{
	// Gets modified state of the current label
	SetDlgItemInt(IDC_LI_MODIFIED,((ILblInfo)LE.LabelInfo()).GetModified());
}

void CVCTesterDlg::OnStaticPictureClick() 
{
	// Get cursor's position in screen coordinates
	GetCursorPos(&PopupPoint);
	// and display popup menu
	CMenu* pPopup = PopupMenu.GetSubMenu(0);;
	pPopup->TrackPopupMenu(TPM_LEFTALIGN | TPM_LEFTBUTTON, PopupPoint.x, PopupPoint.y, this, NULL);
}

void CVCTesterDlg::OnObjectAtSelected()
{
	// Finds an object at the cursor's position on the current label
	// and fills objects list with its ID 
	::MapWindowPoints(NULL, m_Picture.GetSafeHwnd(), &PopupPoint, 1);	// convert to picture coordinates
	int nPix = this->GetDC()->GetDeviceCaps(LOGPIXELSY);				// convert to TWIPS
	PopupPoint.x = PopupPoint.x * 1440 / nPix;
	PopupPoint.y = PopupPoint.y * 1440 / nPix;

	long objid = ((IPrintObject)LE.PrintObject()).ObjectAt(PopupPoint.x, PopupPoint.y);
	if (objid != 0)
	{
		m_ObjectsList.ResetContent();
		char s[16];
		wsprintf(s, "0x%x", objid);
		m_ObjectsList.AddString(s);
	}
	else
		MessageBox("Can't find an object at this point", NULL, MB_OK | MB_ICONINFORMATION);
}

void CVCTesterDlg::OnObjectsAtSelected()
{
	// Finds objects at the cursor's position on the current label
	// and fills objects list with their IDs
	::MapWindowPoints(NULL, m_Picture.GetSafeHwnd(), &PopupPoint, 1);	// convert to picture coordinates
	int nPix = this->GetDC()->GetDeviceCaps(LOGPIXELSY);				// convert to TWIPS
	PopupPoint.x = PopupPoint.x * 1440 / nPix;
	PopupPoint.y = PopupPoint.y * 1440 / nPix;

	long num = ((IObjectsAtEnum)((IPrintObject)LE.PrintObject()).ObjectsAt(PopupPoint.x, PopupPoint.y)).GetCount();
	m_ObjectsList.ResetContent();
	char s[16];
	for (int i = 1; i <= num; ++i)
	{
		wsprintf(s, "0x%x", ((IObjectsAtEnum)((IPrintObject)LE.PrintObject()).ObjectsAt(PopupPoint.x, PopupPoint.y)).GetItem(i));
		m_ObjectsList.AddString(s);
	}
}
