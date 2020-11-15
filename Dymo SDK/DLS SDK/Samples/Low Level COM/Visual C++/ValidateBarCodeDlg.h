#if !defined(AFX_VALIDATEBARCODEDLG_H__037C3C06_C19F_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_VALIDATEBARCODEDLG_H__037C3C06_C19F_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// ValidateBarCodeDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CValidateBarCodeDlg dialog

class CValidateBarCodeDlg : public CDialog
{
// Construction
public:
	CValidateBarCodeDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CValidateBarCodeDlg)
	enum { IDD = IDD_VALIDATEBARCODE_DIALOG };
	CComboBox	m_BCType;
	CString	m_Text;
	int		m_Type;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CValidateBarCodeDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CValidateBarCodeDlg)
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VALIDATEBARCODEDLG_H__037C3C06_C19F_11D2_A3BA_0000E8D57653__INCLUDED_)
