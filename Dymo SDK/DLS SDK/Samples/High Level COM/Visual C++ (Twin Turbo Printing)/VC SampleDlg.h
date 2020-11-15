// VC SampleDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "CDymoAddIn4.h"
#include "CDymoLabels.h"


// CVCSampleDlg dialog
class CVCSampleDlg : public CDialog
{
// Construction
public:
	CVCSampleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_VCSAMPLE_DIALOG };

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
	CDymoAddIn4 m_DymoAddIn;
	CDymoLabels m_DymoLabels;
	
	CEdit m_FileNameEdit;
	afx_msg void OnBnClickedBrowseBtn();
	CComboBox m_LabelObjCmb;
	CEdit m_LabelDataEdit;
	CComboBox m_LabelWriterCmb;
	CComboBox m_TraySelCmb;
	afx_msg void OnBnClickedPrintBtn();
	
	void SetupLabelObject();
	void SetupLabelWriterSelection(bool InitCmb);
	afx_msg void OnEnKillfocusObjdataEdit();
	afx_msg void OnCbnSelchangeLabelwriterCmb();
};
