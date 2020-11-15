#if !defined(AFX_COUNTEROBJECTDLG_H__8D51C723_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_COUNTEROBJECTDLG_H__8D51C723_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// CounterObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CCounterObjectDlg dialog

class CCounterObjectDlg : public CDialog
{
// Construction
public:
	CCounterObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CCounterObjectDlg)
	enum { IDD = IDD_COUNTER_OBJECT_DIALOG };
	CString	m_PreText;
	CString	m_PostText;
	long	m_Start;
	long	m_Current;
	long	m_Width;
	long	m_Increment;
	BOOL	m_UseLeadingZeros;
	CString	m_Text;
	CString	m_Font1;
	CString	m_Font2;
	long	m_Justify;
	BOOL	m_Mirrored;
	BOOL	m_Vertical;
	CString	m_TextColor;
	CString	m_BackGroundColor;
	long	m_VJustify;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CCounterObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CCounterObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_COUNTEROBJECTDLG_H__8D51C723_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
