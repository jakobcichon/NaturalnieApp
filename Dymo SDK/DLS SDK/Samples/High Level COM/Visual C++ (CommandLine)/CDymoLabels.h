// Machine generated IDispatch wrapper class(es) created with Add Class from Typelib Wizard

// CDymoLabels wrapper class

class CDymoLabels : public COleDispatchDriver
{
public:
	CDymoLabels(){} // Calls COleDispatchDriver default constructor
	CDymoLabels(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CDymoLabels(const CDymoLabels& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

	// Attributes
public:

	// Operations
public:


	// IDymoLabels methods
public:
	BOOL SetAddress(long AddrIdx, LPCTSTR Address)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 VTS_BSTR ;
		InvokeHelper(0x1, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, AddrIdx, Address);
		return result;
	}
	BOOL SetField(LPCTSTR Field, LPCTSTR Text)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR VTS_BSTR ;
		InvokeHelper(0x2, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, Field, Text);
		return result;
	}
	void PostNet(long Index, LPCTSTR Position)
	{
		static BYTE parms[] = VTS_I4 VTS_BSTR ;
		InvokeHelper(0x3, DISPATCH_METHOD, VT_EMPTY, NULL, parms, Index, Position);
	}
	CString GetText(LPCTSTR Field)
	{
		CString result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x4, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, Field);
		return result;
	}
	CString GetObjectNames(BOOL bVariableOnly)
	{
		CString result;
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x5, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, bVariableOnly);
		return result;
	}
	long get_AddressFieldCount()
	{
		long result;
		InvokeHelper(0x6, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	BOOL PasteFromClipboard(LPCTSTR ObjectName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0xc9, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, ObjectName);
		return result;
	}
	BOOL SetImageFile(LPCTSTR ObjectName, LPCTSTR FileName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR VTS_BSTR ;
		InvokeHelper(0xca, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, ObjectName, FileName);
		return result;
	}

	// IDymoLabels properties
public:

};
