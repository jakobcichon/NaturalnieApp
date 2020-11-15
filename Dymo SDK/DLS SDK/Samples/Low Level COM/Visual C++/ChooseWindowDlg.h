#if !defined(AFX_CHOOSEWINDOWDLG_H__D20C6110_FBD8_11D2_A3BB_0000E8D57653__INCLUDED_)
#define AFX_CHOOSEWINDOWDLG_H__D20C6110_FBD8_11D2_A3BB_0000E8D57653__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// ChooseWindowDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CChooseWindowDlg dialog

class CChooseWindowDlg : public CDialog
{
// Construction
public:
//	BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam);
	CChooseWindowDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CChooseWindowDlg)
	enum { IDD = IDD_WINDOWS_DIALOG };
	CListBox	m_WindowsList;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CChooseWindowDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CChooseWindowDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnDblclkWindowsList();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CHOOSEWINDOWDLG_H__D20C6110_FBD8_11D2_A3BB_0000E8D57653__INCLUDED_)
