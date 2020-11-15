#if !defined(AFX_LINEOBJECTDLG_H__8D51C721_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_LINEOBJECTDLG_H__8D51C721_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// LineObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CLineObjectDlg dialog

class CLineObjectDlg : public CDialog
{
// Construction
public:
	CLineObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CLineObjectDlg)
	enum { IDD = IDD_LINE_OBJECT_DIALOG };
	long	m_Length;
	long	m_Orientation;
	long	m_Thickness;
	CString	m_LineColor;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CLineObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CLineObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_LINEOBJECTDLG_H__8D51C721_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
