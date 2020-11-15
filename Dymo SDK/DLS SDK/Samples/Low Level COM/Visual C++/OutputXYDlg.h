/////////////////////////////////////////////////////////////////////////////
// COutputXYDlg dialog

class COutputXYDlg : public CDialog
{
// Construction
public:
	COutputXYDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(COutputXYDlg)
	enum { IDD = IDD_OUTPUTXY_DIALOG };
	long	m_X;
	long	m_Y;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(COutputXYDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(COutputXYDlg)
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
