#if !defined(AFX_RECTANGLEOBJECTDLG_H__FD92B3C4_CA75_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_RECTANGLEOBJECTDLG_H__FD92B3C4_CA75_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// RectangleObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CRectangleObjectDlg dialog

class CRectangleObjectDlg : public CDialog
{
// Construction
public:
	CRectangleObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CRectangleObjectDlg)
	enum { IDD = IDD_RECTANGLE_OBJECT_DIALOG };
	BOOL	m_bFilled;
	long	m_Border;
	CString	m_BorderColor;
	CString	m_FillColor;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRectangleObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CRectangleObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RECTANGLEOBJECTDLG_H__FD92B3C4_CA75_11D2_A3BA_0000E8D57653__INCLUDED_)
