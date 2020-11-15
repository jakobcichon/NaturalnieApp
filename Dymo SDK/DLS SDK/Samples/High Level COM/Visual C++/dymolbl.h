// Machine generated IDispatch wrapper class(es) created with ClassWizard
/////////////////////////////////////////////////////////////////////////////
// IDymoAddIn wrapper class

class IDymoAddIn : public COleDispatchDriver
{
public:
	IDymoAddIn() {}		// Calls COleDispatchDriver default constructor
	IDymoAddIn(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IDymoAddIn(const IDymoAddIn& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	BOOL Open(LPCTSTR FileName);
	BOOL Save();
	BOOL SaveAs(LPCTSTR FileName);
	BOOL Print(long Copies, BOOL bShowDialog);
	void Hide();
	void Show();
	void SysTray(BOOL State);
	void Quit();
	CString GetFileName();
};
/////////////////////////////////////////////////////////////////////////////
// IDymoLabels wrapper class

class IDymoLabels : public COleDispatchDriver
{
public:
	IDymoLabels() {}		// Calls COleDispatchDriver default constructor
	IDymoLabels(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IDymoLabels(const IDymoLabels& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	BOOL SetAddress(long AddrIdx, LPCTSTR Address);
	BOOL SetField(LPCTSTR Field, LPCTSTR Text);
	void PostNet(long Index, LPCTSTR Position);
	CString GetText(LPCTSTR Field);
	CString GetObjectNames(BOOL bVariableOnly);
	long GetAddressFieldCount();
};
