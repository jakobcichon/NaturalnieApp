// Machine generated IDispatch wrapper class(es) created with Add Class from Typelib Wizard

// CDymoTape2 wrapper class

class CDymoTape2 : public COleDispatchDriver
{
public:
	CDymoTape2(){} // Calls COleDispatchDriver default constructor
	CDymoTape2(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CDymoTape2(const CDymoTape2& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

	// Attributes
public:

	// Operations
public:


	// IDymoTape2 methods
public:
	CString get_FileName()
	{
		CString result;
		InvokeHelper(0xc9, DISPATCH_PROPERTYGET, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	long get_LabelOrientation()
	{
		long result;
		InvokeHelper(0xca, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_LabelOrientation(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xca, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	long get_TextAlignment()
	{
		long result;
		InvokeHelper(0xcb, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_TextAlignment(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xcb, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	long get_LabelLength()
	{
		long result;
		InvokeHelper(0xcc, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_LabelLength(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xcc, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	long get_BorderMode()
	{
		long result;
		InvokeHelper(0xcd, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_BorderMode(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xcd, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL get_SysTray()
	{
		BOOL result;
		InvokeHelper(0xce, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void put_SysTray(BOOL newValue)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0xce, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL Open(LPCTSTR FileName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0xcf, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, FileName);
		return result;
	}
	BOOL Save()
	{
		BOOL result;
		InvokeHelper(0xd0, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL SaveAs(LPCTSTR FileName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0xd1, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, FileName);
		return result;
	}
	BOOL Print(long Copies)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xd2, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, Copies);
		return result;
	}
	void Hide()
	{
		InvokeHelper(0xd3, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void Show()
	{
		InvokeHelper(0xd4, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void Quit()
	{
		InvokeHelper(0xd5, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	CString GetPrinters()
	{
		CString result;
		InvokeHelper(0xd6, DISPATCH_METHOD, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	BOOL SelectPrinter(LPCTSTR PrinterName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0xd7, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, PrinterName);
		return result;
	}
	BOOL AddText(LPCTSTR TextString, LPCTSTR FontFormat, BOOL OutlineEffect, BOOL ShadowEffect)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR VTS_BSTR VTS_BOOL VTS_BOOL ;
		InvokeHelper(0xd8, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, TextString, FontFormat, OutlineEffect, ShadowEffect);
		return result;
	}
	BOOL AddBarcode(LPCTSTR Data, long Format, long Size, long TextPosition)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR VTS_I4 VTS_I4 VTS_I4 ;
		InvokeHelper(0xd9, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, Data, Format, Size, TextPosition);
		return result;
	}
	BOOL AddPicture(LPCTSTR FileName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0xda, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, FileName);
		return result;
	}
	BOOL PasteText()
	{
		BOOL result;
		InvokeHelper(0xdb, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL PastePicture()
	{
		BOOL result;
		InvokeHelper(0xdc, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	long AddTabStop(long Position, long Style)
	{
		long result;
		static BYTE parms[] = VTS_I4 VTS_I4 ;
		InvokeHelper(0xdd, DISPATCH_METHOD, VT_I4, (void*)&result, parms, Position, Style);
		return result;
	}
	BOOL DeleteTabStop(long TabIndex)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xde, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, TabIndex);
		return result;
	}
	BOOL New()
	{
		BOOL result;
		InvokeHelper(0xdf, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL IsTapeWidthSupported(long Width)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xe0, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, Width);
		return result;
	}
	BOOL SetTapeWidth(long Width)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xe1, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, Width);
		return result;
	}
	BOOL SmartPasteFromClipboard()
	{
		BOOL result;
		InvokeHelper(0x12d, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL SmartPasteFromFile(LPCTSTR FileName)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x12e, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, FileName);
		return result;
	}

	// IDymoTape2 properties
public:

};
