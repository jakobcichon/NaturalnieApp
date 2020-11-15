// SmartPasteTestDlg.cpp : implementation file
//

#include "stdafx.h"
#include "SmartPasteTest.h"
#include "SmartPasteTestDlg.h"
#include ".\smartpastetestdlg.h"

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


// CSmartPasteTestDlg dialog



CSmartPasteTestDlg::CSmartPasteTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSmartPasteTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSmartPasteTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FILE_EDIT, m_FileEdit);
}

BEGIN_MESSAGE_MAP(CSmartPasteTestDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BROWSE_BTN, OnBnClickedBrowseBtn)
	ON_BN_CLICKED(IDC_PASTECLIPBOARD_BTN, OnBnClickedPasteclipboardBtn)
	ON_BN_CLICKED(IDC_PASTEFILE_BTN, OnBnClickedPastefileBtn)
	ON_BN_CLICKED(IDC_LABEL_RBTN, OnBnClickedLabelRbtn)
	ON_BN_CLICKED(IDC_TAPE_RBTN, OnBnClickedTapeRbtn)
END_MESSAGE_MAP()


// CSmartPasteTestDlg message handlers

BOOL CSmartPasteTestDlg::OnInitDialog()
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
	if (m_DymoAddIn.m_lpDispatch == 0)
		m_DymoAddIn.CreateDispatch(_T("Dymo.DymoAddIn"));
		
	if (m_DymoTape.m_lpDispatch == 0)
		m_DymoTape.CreateDispatch(_T("Dymo.DymoTape"));

	CheckRadioButton(IDC_LABEL_RBTN, IDC_TAPE_RBTN, IDC_LABEL_RBTN);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CSmartPasteTestDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CSmartPasteTestDlg::OnPaint() 
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
HCURSOR CSmartPasteTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CSmartPasteTestDlg::OnBnClickedBrowseBtn()
{
	// TODO: Add your control notification handler code here
	CFileDialog dlg(true);
	
	if (dlg.DoModal() == IDOK)
		m_FileEdit.SetWindowText(dlg.GetPathName());
}

void CSmartPasteTestDlg::OnBnClickedPasteclipboardBtn()
{
	// TODO: Add your control notification handler code here
	if (GetCheckedRadioButton(IDC_LABEL_RBTN, IDC_TAPE_RBTN) == IDC_LABEL_RBTN)
		m_DymoAddIn.SmartPasteFromClipboard();
	else
		m_DymoTape.SmartPasteFromClipboard();
}

void CSmartPasteTestDlg::OnBnClickedPastefileBtn()
{
	// TODO: Add your control notification handler code here
	CString fileName;
	m_FileEdit.GetWindowText(fileName);
	
	if (GetCheckedRadioButton(IDC_LABEL_RBTN, IDC_TAPE_RBTN) == IDC_LABEL_RBTN)
		m_DymoAddIn.SmartPasteFromFile(fileName);
	else
		m_DymoTape.SmartPasteFromFile(fileName);
}

void CSmartPasteTestDlg::OnBnClickedLabelRbtn()
{
	// TODO: Add your control notification handler code here
	CheckRadioButton(IDC_LABEL_RBTN, IDC_TAPE_RBTN, IDC_LABEL_RBTN);
}

void CSmartPasteTestDlg::OnBnClickedTapeRbtn()
{
	// TODO: Add your control notification handler code here
	CheckRadioButton(IDC_LABEL_RBTN, IDC_TAPE_RBTN, IDC_TAPE_RBTN);
}
