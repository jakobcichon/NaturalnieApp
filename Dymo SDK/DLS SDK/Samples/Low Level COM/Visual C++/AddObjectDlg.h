#if !defined(AFX_ADDOBJECTDLG_H__A8F3E91C_C71A_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_ADDOBJECTDLG_H__A8F3E91C_C71A_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// AddObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CAddObjectDlg dialog

class CAddObjectDlg : public CDialog
{
// Construction
public:
	CAddObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CAddObjectDlg)
	enum { IDD = IDD_ADDOBJECT_DIALOG };
	long	m_Height;
	CString	m_Name;
	long	m_Rotation;
	long	m_Width;
	long	m_X;
	long	m_Y;
	int		m_ObjType;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAddObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CAddObjectDlg)
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_ADDOBJECTDLG_H__A8F3E91C_C71A_11D2_A3BA_0000E8D57653__INCLUDED_)
