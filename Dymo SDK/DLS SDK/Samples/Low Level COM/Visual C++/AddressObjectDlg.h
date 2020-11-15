#if !defined(AFX_ADDRESSOBJECTDLG_H__331C2325_CA42_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_ADDRESSOBJECTDLG_H__331C2325_CA42_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000
// AddressObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CAddressObjectDlg dialog

class CAddressObjectDlg : public CDialog
{
// Construction
public:
	CAddressObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CAddressObjectDlg)
	enum { IDD = IDD_ADDRESS_OBJECT_DIALOG };
	CString	m_Text;
	CString	m_Font1;
	CString	m_Font2;
	long	m_Justify;
	long	m_VJustify;
	BOOL	m_Mirrored;
	BOOL	m_Vertical;
	CString	m_TextColor;
	CString	m_BackGroundColor;
	long	m_BarCodePosition;
	BOOL	m_b9DigitOnly;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAddressObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CAddressObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_ADDRESSOBJECTDLG_H__331C2325_CA42_11D2_A3BA_0000E8D57653__INCLUDED_)
