// VC SampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC Sample.h"
#include "VC SampleDlg.h"
#include ".\vc sampledlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CVCSampleDlg dialog



CVCSampleDlg::CVCSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CVCSampleDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVCSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FILENAME_EDIT, m_FileNameEdit);
	DDX_Control(pDX, IDC_OBJNAME_CMB, m_LabelObjCmb);
	DDX_Control(pDX, IDC_OBJDATA_EDIT, m_LabelDataEdit);
	DDX_Control(pDX, IDC_LABELWRITER_CMB, m_LabelWriterCmb);
	DDX_Control(pDX, IDC_TRAYSEL_CMB, m_TraySelCmb);
}

BEGIN_MESSAGE_MAP(CVCSampleDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BROWSE_BTN, OnBnClickedBrowseBtn)
	ON_BN_CLICKED(IDC_PRINT_BTN, OnBnClickedPrintBtn)
	ON_EN_KILLFOCUS(IDC_OBJDATA_EDIT, OnEnKillfocusObjdataEdit)
	ON_CBN_SELCHANGE(IDC_LABELWRITER_CMB, OnCbnSelchangeLabelwriterCmb)
END_MESSAGE_MAP()


// CVCSampleDlg message handlers

BOOL CVCSampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	// create the DymoAddIn
	if (m_DymoAddIn.m_lpDispatch == NULL)
	{		
		if (!m_DymoAddIn.CreateDispatch(_T("Dymo.DymoAddIn")))
		{
			MessageBox(_T("Error: Cannot create the DymoAddIn."),
				_T("DYMO VC Sample"), MB_OK | MB_ICONERROR);					
		}
	}

	// create the DymoLabels
	if (m_DymoLabels.m_lpDispatch == NULL)
	{
		if (!m_DymoLabels.CreateDispatch(_T("Dymo.DymoLabels")))
		{
			MessageBox(_T("Error: Cannot create the DymoLabels."),
				_T("DYMO VC Sample"), MB_OK | MB_ICONERROR);					
		}
	}

	// setup tray selections
	m_TraySelCmb.AddString(_T("Left"));
	m_TraySelCmb.AddString(_T("Right"));
	m_TraySelCmb.AddString(_T("Auto Switch"));
	
	m_FileNameEdit.SetReadOnly();
	
	// show the file name
	m_FileNameEdit.SetWindowText(m_DymoAddIn.get_FileName());

	// populate label objects
	SetupLabelObject();					

	// obtain the currently selected printer
	SetupLabelWriterSelection(true);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CVCSampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVCSampleDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

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

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CVCSampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CVCSampleDlg::OnBnClickedBrowseBtn()
{
	// TODO: Add your control notification handler code here
	//standard open dialog
	CFileDialog od(TRUE);
	od.m_pOFN->lpstrFilter = _T("*.lwl");

	// show the file name
	CString str;
	m_FileNameEdit.GetWindowText(str);

	// use the current file name's folder as the initial
	// directory for the open file dialog
	int i = str.ReverseFind('\\');
	CString path = str.Left(i);
	od.m_pOFN->lpstrInitialDir = path;

	//if user selected a file then open it
	if (od.DoModal()==IDOK)
	{
		if (m_DymoAddIn.Open(od.GetPathName()))
		{				
			// show the file name
			str = od.GetPathName();
			str += '\\';
			str += od.GetFileName();
			m_FileNameEdit.SetWindowText(str);
			
			// populate label objects
			SetupLabelObject();					

			// setup paper tray selection
			SetupLabelWriterSelection(false);
		}	
	}
}

void CVCSampleDlg::OnBnClickedPrintBtn()
{
	// TODO: Add your control notification handler code here
	// ATTENTION: This call is very important if you're making mutiple calls to the Print() or Print2() function!
	// It's a good idea to always wrap StartPrintJob() and EndPrintJob() around a call to Print() or Print2() function.
	m_DymoAddIn.StartPrintJob();
	
	// print two copies
	m_DymoAddIn.Print2(1, false, m_TraySelCmb.GetCurSel());
	
	// ATTENTION: Every StartPrintJob() must have a matching EndPrintJob()
	m_DymoAddIn.EndPrintJob();
}

void CVCSampleDlg::SetupLabelObject()
{
	// clear edit control
	m_LabelDataEdit.SetWindowText(_T(""));
	
	// clear all items first
	m_LabelObjCmb.ResetContent();

	// get the objects on the label
	CString ObjNames = m_DymoLabels.GetObjectNames(TRUE);

	if (!ObjNames.IsEmpty())
	{
		// parse the result
		int i = ObjNames.Find('|');
		while (i >= 0)
		{
			m_LabelObjCmb.AddString(ObjNames.Left(i));
			ObjNames = ObjNames.Right(ObjNames.GetLength() - i - 1);
			i = ObjNames.Find('|');
		}
		if (ObjNames.GetLength() > 0)
			m_LabelObjCmb.AddString(ObjNames);
			
		m_LabelObjCmb.SetCurSel(0);
	}
}

void CVCSampleDlg::SetupLabelWriterSelection(bool InitCmb)
{
	// get the objects on the label
	if (InitCmb)
	{
		// clear all items first
		m_LabelWriterCmb.ResetContent();
		
		CString PrtNames = m_DymoAddIn.GetDymoPrinters();

		if (!PrtNames.IsEmpty())
		{
			// parse the result
			int i = PrtNames.Find('|');
			while (i >= 0)
			{
				m_LabelWriterCmb.AddString(PrtNames.Left(i));
				PrtNames = PrtNames.Right(PrtNames.GetLength() - i - 1);
				i = PrtNames.Find('|');
			}
			if (PrtNames.GetLength() > 0)
				m_LabelWriterCmb.AddString(PrtNames);
				
			PrtNames = m_DymoAddIn.GetCurrentPrinterName();
			if (!PrtNames.IsEmpty())
				m_LabelWriterCmb.SelectString(0, PrtNames);
			else
				m_LabelWriterCmb.SetCurSel(0);
		}
	}
		
	// check if selected/current printer is a twin turbo printer
	CString CurPrinter;
	m_LabelWriterCmb.GetWindowText(CurPrinter);
	m_TraySelCmb.EnableWindow(m_DymoAddIn.IsTwinTurboPrinter(CurPrinter));
	if (m_TraySelCmb.IsWindowEnabled())
	{
		// show the current tray selection if the printer
		// is a twin turbo
		switch (m_DymoAddIn.GetCurrentPaperTray())
		{
			case 0: // left tray
				m_TraySelCmb.SetCurSel(0);
				break;
				
			case 1: // right tray
				m_TraySelCmb.SetCurSel(1);
				break;
			
			case 2: // auto switch
				m_TraySelCmb.SetCurSel(2);
				break;
				
			default: // tray selection not set, so default to auto switch
				m_TraySelCmb.SetCurSel(2);
				break;
		}
	}
}

void CVCSampleDlg::OnEnKillfocusObjdataEdit()
{
	// TODO: Add your control notification handler code here
	CString objName, objData;
	m_LabelObjCmb.GetWindowText(objName);
	m_LabelDataEdit.GetWindowText(objData);
	m_DymoLabels.SetField(objName, objData);
}

void CVCSampleDlg::OnCbnSelchangeLabelwriterCmb()
{
	// TODO: Add your control notification handler code here
	CString CurPrinter;
	m_LabelWriterCmb.GetWindowText(CurPrinter);
	m_DymoAddIn.SelectPrinter(CurPrinter);
	SetupLabelWriterSelection(false);
}
