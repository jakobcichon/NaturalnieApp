// VC TesterDlg.h : header file
//
//{{AFX_INCLUDES()
//#include "msflexgrid.h"
//}}AFX_INCLUDES

#if !defined(AFX_VCTESTERDLG_H__30C67BAA_B770_11D2_A3BA_0000E8D57653__INCLUDED_)
#define AFX_VCTESTERDLG_H__30C67BAA_B770_11D2_A3BA_0000E8D57653__INCLUDED_

#include "labels.h"	// Added by ClassView
#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CVCTesterDlg dialog

class CVCTesterDlg : public CDialog
{

// Construction
public:
	POINT PopupPoint;
	CMenu PopupMenu;
	void ReDrawLabel();
	void FillLabelInfo(void);
	ILabelEngine LE;
	CVCTesterDlg(CWnd* pParent = NULL);	// standard constructor
	virtual ~CVCTesterDlg();

// Dialog Data
	//{{AFX_DATA(CVCTesterDlg)
	enum { IDD = IDD_VCTESTER_DIALOG };
	CListBox	m_LabelsList;
	CListBox	m_ObjectsList;
	CButton	m_ZoomButton;
	CStatic	m_Picture;
	BOOL	m_Shadow;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVCTesterDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	BOOL CanExit();

	// Generated message map functions
	//{{AFX_MSG(CVCTesterDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	afx_msg void OnSelchangeLabelsList();
	afx_msg void OnLoadLabelClick();
	afx_msg void OnSaveLabelClick();
	afx_msg void OnPrintLabelClick();
	afx_msg void OnOutputClick();
	afx_msg void OnOutputXYClick();
	afx_msg void OnValidateBarCodeClick();
	afx_msg void OnZoomClick();
	afx_msg void OnShadowClick();
	afx_msg void OnAllObjectsClick();
	afx_msg void OnVarObjectsClick();
	afx_msg void OnBringToFrontClick();
	afx_msg void OnFindObjectClick();
	afx_msg void OnSendToBackClick();
	afx_msg void OnDeleteClick();
	afx_msg void OnAddObjectClick();
	afx_msg void OnGeneralClick();
	afx_msg void OnCopyToClipboardClick();
	afx_msg void OnPasteFromClipboardClick();
	afx_msg void OnSpecialClick();
	afx_msg void OnGetModifiedClick();
	afx_msg void OnStaticPictureClick();

	afx_msg void OnObjectAtSelected();
	afx_msg void OnObjectsAtSelected();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VCTESTERDLG_H__30C67BAA_B770_11D2_A3BA_0000E8D57653__INCLUDED_)
