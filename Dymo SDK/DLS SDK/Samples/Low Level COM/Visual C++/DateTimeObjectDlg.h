#if !defined(AFX_DATETIMEOBJECTDLG_H__9C14C484_DADD_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_DATETIMEOBJECTDLG_H__9C14C484_DADD_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// DateTimeObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CDateTimeObjectDlg dialog

class CDateTimeObjectDlg : public CDialog
{
// Construction
public:
	CDateTimeObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CDateTimeObjectDlg)
	enum { IDD = IDD_DATETIME_OBJECT_DIALOG };
	CString	m_Text;
	CString	m_Font1;
	CString	m_Font2;
	long	m_Justify;
	long	m_VJustify;
	BOOL	m_Mirrored;
	BOOL	m_Vertical;
	CString	m_TextColor;
	CString	m_BackGroundColor;
	CString	m_PreText;
	CString	m_PostText;
	long	m_Format;
	BOOL	m_IncludeTime;
	BOOL	m_b24Hour;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDateTimeObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CDateTimeObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DATETIMEOBJECTDLG_H__9C14C484_DADD_11D2_A3BA_0000E8D57653__INCLUDED_)
