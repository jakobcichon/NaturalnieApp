// SmartPasteTestDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "CDymoAddIn5.h"
#include "CDymoTape2.h"


// CSmartPasteTestDlg dialog
class CSmartPasteTestDlg : public CDialog
{
// Construction
public:
	CSmartPasteTestDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_SMARTPASTETEST_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CDymoAddIn5 m_DymoAddIn;
	CDymoTape2 m_DymoTape;
	CEdit m_FileEdit;
	
	afx_msg void OnBnClickedBrowseBtn();
	afx_msg void OnBnClickedPasteclipboardBtn();
	afx_msg void OnBnClickedPastefileBtn();
	afx_msg void OnBnClickedLabelRbtn();
	afx_msg void OnBnClickedTapeRbtn();
};
