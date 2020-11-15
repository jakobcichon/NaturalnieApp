#if !defined(AFX_TEXTOBJECTDLG_H__331C2324_CA42_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_TEXTOBJECTDLG_H__331C2324_CA42_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// TextObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CTextObjectDlg dialog

class CTextObjectDlg : public CDialog
{
// Construction
public:
	CTextObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CTextObjectDlg)
	enum { IDD = IDD_TEXT_OBJECT_DIALOG };
	CString	m_Text;
	CString	m_Font1;
	CString	m_Font2;
	long	m_Justify;
	long	m_VJustify;
	BOOL	m_Mirrored;
	BOOL	m_Vertical;
	CString	m_TextColor;
	CString	m_BackGroundColor;
	BOOL	m_IsVariable;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTextObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CTextObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TEXTOBJECTDLG_H__331C2324_CA42_11D2_A3BA_0000E8D57653__INCLUDED_)
