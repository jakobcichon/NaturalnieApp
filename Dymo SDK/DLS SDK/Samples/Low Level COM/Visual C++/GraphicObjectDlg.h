#if !defined(AFX_GRAPHICOBJECTDLG_H__24593EC1_CA62_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_GRAPHICOBJECTDLG_H__24593EC1_CA62_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// GraphicObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CGraphicObjectDlg dialog

class CGraphicObjectDlg : public CDialog
{
// Construction
public:
	CGraphicObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CGraphicObjectDlg)
	enum { IDD = IDD_GRAPHIC_OBJECT_DIALOG };
	long	m_GraphicSource;
	CString	m_FileName;
	CString	m_BitmapHandle;
	CString	m_PaletteHandle;
	CString	m_WindowHandle;
	long	m_Border;
	CString	m_BorderColor;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGraphicObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CGraphicObjectDlg)
	afx_msg void OnFileNameChangeClick();
	afx_msg void OnBitmapChangeClick();
	afx_msg void OnWindowHandleChangeClick();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GRAPHICOBJECTDLG_H__24593EC1_CA62_11D2_A3BA_0000E8D57653__INCLUDED_)
