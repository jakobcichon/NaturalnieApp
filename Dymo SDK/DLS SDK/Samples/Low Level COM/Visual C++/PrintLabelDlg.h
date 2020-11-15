/////////////////////////////////////////////////////////////////////////////
// CPrintLabelDlg dialog

class CPrintLabelDlg : public CDialog
{
// Construction
public:
	CPrintLabelDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CPrintLabelDlg)
	enum { IDD = IDD_PRINT_DIALOG };
	CSpinButtonCtrl	m_Spin;
	CString	m_DeviceName;
	CString	m_Port;
	long	m_Quantity;
	BOOL	m_IsShowDialog;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CPrintLabelDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CPrintLabelDlg)
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
