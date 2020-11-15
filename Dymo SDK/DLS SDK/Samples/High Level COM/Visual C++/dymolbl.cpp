// Machine generated IDispatch wrapper class(es) created with ClassWizard

#include "stdafx.h"
#include "dymolbl.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



/////////////////////////////////////////////////////////////////////////////
// IDymoAddIn properties

/////////////////////////////////////////////////////////////////////////////
// IDymoAddIn operations

BOOL IDymoAddIn::Open(LPCTSTR FileName)
{
	BOOL result;
	static BYTE parms[] =
		VTS_BSTR;
	InvokeHelper(0x1, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms,
		FileName);
	return result;
}

BOOL IDymoAddIn::Save()
{
	BOOL result;
	InvokeHelper(0x2, DISPATCH_METHOD, VT_BOOL, (void*)&result, NULL);
	return result;
}

BOOL IDymoAddIn::SaveAs(LPCTSTR FileName)
{
	BOOL result;
	static BYTE parms[] =
		VTS_BSTR;
	InvokeHelper(0x3, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms,
		FileName);
	return result;
}

BOOL IDymoAddIn::Print(long Copies, BOOL bShowDialog)
{
	BOOL result;
	static BYTE parms[] =
		VTS_I4 VTS_BOOL;
	InvokeHelper(0x4, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms,
		Copies, bShowDialog);
	return result;
}

void IDymoAddIn::Hide()
{
	InvokeHelper(0x5, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
}

void IDymoAddIn::Show()
{
	InvokeHelper(0x6, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
}

void IDymoAddIn::SysTray(BOOL State)
{
	static BYTE parms[] =
		VTS_BOOL;
	InvokeHelper(0x7, DISPATCH_METHOD, VT_EMPTY, NULL, parms,
		 State);
}

void IDymoAddIn::Quit()
{
	InvokeHelper(0x8, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
}

CString IDymoAddIn::GetFileName()
{
	CString result;
	InvokeHelper(0x9, DISPATCH_PROPERTYGET, VT_BSTR, (void*)&result, NULL);
	return result;
}


/////////////////////////////////////////////////////////////////////////////
// IDymoLabels properties

/////////////////////////////////////////////////////////////////////////////
// IDymoLabels operations

BOOL IDymoLabels::SetAddress(long AddrIdx, LPCTSTR Address)
{
	BOOL result;
	static BYTE parms[] =
		VTS_I4 VTS_BSTR;
	InvokeHelper(0x1, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms,
		AddrIdx, Address);
	return result;
}

BOOL IDymoLabels::SetField(LPCTSTR Field, LPCTSTR Text)
{
	BOOL result;
	static BYTE parms[] =
		VTS_BSTR VTS_BSTR;
	InvokeHelper(0x2, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms,
		Field, Text);
	return result;
}

void IDymoLabels::PostNet(long Index, LPCTSTR Position)
{
	static BYTE parms[] =
		VTS_I4 VTS_BSTR;
	InvokeHelper(0x3, DISPATCH_METHOD, VT_EMPTY, NULL, parms,
		 Index, Position);
}

CString IDymoLabels::GetText(LPCTSTR Field)
{
	CString result;
	static BYTE parms[] =
		VTS_BSTR;
	InvokeHelper(0x4, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms,
		Field);
	return result;
}

CString IDymoLabels::GetObjectNames(BOOL bVariableOnly)
{
	CString result;
	static BYTE parms[] =
		VTS_BOOL;
	InvokeHelper(0x5, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms,
		bVariableOnly);
	return result;
}

long IDymoLabels::GetAddressFieldCount()
{
	long result;
	InvokeHelper(0x6, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
	return result;
}
