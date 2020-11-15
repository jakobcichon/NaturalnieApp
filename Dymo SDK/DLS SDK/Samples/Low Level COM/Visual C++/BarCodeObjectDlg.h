#if !defined(AFX_BARCODEOBJECTDLG_H__8D51C722_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_BARCODEOBJECTDLG_H__8D51C722_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// BarCodeObjectDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CBarCodeObjectDlg dialog

class CBarCodeObjectDlg : public CDialog
{
// Construction
public:
	CBarCodeObjectDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CBarCodeObjectDlg)
	enum { IDD = IDD_BARCODE_OBJECT_DIALOG };
	CString	m_Text;
	CString	m_Font;
	long	m_TextPos;
	int		m_BCType;
	long	m_Size;
	long	m_Justify;
	CString	m_Link;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CBarCodeObjectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CBarCodeObjectDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_BARCODEOBJECTDLG_H__8D51C722_CFDB_11D2_A3BA_0000E8D57653__INCLUDED_)
