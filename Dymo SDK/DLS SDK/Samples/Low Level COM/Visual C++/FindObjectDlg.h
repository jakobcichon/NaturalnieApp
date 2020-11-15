#if !defined(AFX_FINDOBJECTDLG_H__343C3AC1_C500_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_FINDOBJECTDLG_H__343C3AC1_C500_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// FindObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CFindObjectDlg dialog

class CFindObjectDlg : public CDialog
{
// Construction
public:
	CFindObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CFindObjectDlg)
	enum { IDD = IDD_FINDOBJECT_DIALOG };
	CString	m_ObjectName;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFindObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CFindObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FINDOBJECTDLG_H__343C3AC1_C500_11D2_A3BA_0000E8D57653__INCLUDED_)
