// Machine generated IDispatch wrapper class(es) created with ClassWizard
/////////////////////////////////////////////////////////////////////////////
// ILabelEngine wrapper class

class ILabelEngine : public COleDispatchDriver
{
public:
	ILabelEngine() {}		// Calls COleDispatchDriver default constructor
	ILabelEngine(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ILabelEngine(const ILabelEngine& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	LPDISPATCH LabelNames();
	LPDISPATCH LabelInfo();
	LPDISPATCH PrintObject();
	void NewLabel(LPCTSTR LabelType);
	BOOL OpenFile(LPCTSTR FileName);
	BOOL SaveFile(LPCTSTR FileName);
	BOOL PrintLabel(LPCTSTR DeviceName, LPCTSTR Port, long Quantity, BOOL bShowDialog);
	BOOL Output(long DC);
	BOOL OutputXY(long DC, long X, long Y);
	void DrawLabel(long DC);
	void SetZoom(long nNewValue);
	void SetShadow(BOOL bNewValue);
	long ValidateBarCode(LPCTSTR Text, long BCType);
};
/////////////////////////////////////////////////////////////////////////////
// ILabelList wrapper class

class ILabelList : public COleDispatchDriver
{
public:
	ILabelList() {}		// Calls COleDispatchDriver default constructor
	ILabelList(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ILabelList(const ILabelList& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetCount();
	CString GetItem(long Index);
	LPUNKNOWN Get_NewEnum();
};
/////////////////////////////////////////////////////////////////////////////
// ILblInfo wrapper class

class ILblInfo : public COleDispatchDriver
{
public:
	ILblInfo() {}		// Calls COleDispatchDriver default constructor
	ILblInfo(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ILblInfo(const ILblInfo& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	CString GetLabelName();
	CString GetPaperName();
	long GetPaperWidth();
	long GetPaperHeight();
	long GetBitmapWidth();
	long GetBitmapHeight();
	long GetLabelCount();
	long GetLabelWidth();
	long GetLabelHeight();
	BOOL GetModified();
};
/////////////////////////////////////////////////////////////////////////////
// IPrintObject wrapper class

class IPrintObject : public COleDispatchDriver
{
public:
	IPrintObject() {}		// Calls COleDispatchDriver default constructor
	IPrintObject(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IPrintObject(const IPrintObject& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	LPDISPATCH ObjectsAt(long X, long Y);
	LPDISPATCH Objects();
	LPDISPATCH LabelObject(long Obj);
	long ObjectAt(long X, long Y);
	LPDISPATCH VarObjects();
	long FindObj(LPCTSTR Name);
	void BringToFront(long Obj);
	void SendToBack(long Obj);
	void Delete(long Obj);
	long AddObject(long ObjType, LPCTSTR Name, long X, long Y, long Width, long Height, long Rotation);
	BOOL CopyToClipboard(long* Buf);
	BOOL PasteFromClipboard();
};
/////////////////////////////////////////////////////////////////////////////
// IObjectsAtEnum wrapper class

class IObjectsAtEnum : public COleDispatchDriver
{
public:
	IObjectsAtEnum() {}		// Calls COleDispatchDriver default constructor
	IObjectsAtEnum(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IObjectsAtEnum(const IObjectsAtEnum& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetCount();
	long GetItem(long Index);
	LPUNKNOWN Get_NewEnum();
};
/////////////////////////////////////////////////////////////////////////////
// IObjectList wrapper class

class IObjectList : public COleDispatchDriver
{
public:
	IObjectList() {}		// Calls COleDispatchDriver default constructor
	IObjectList(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IObjectList(const IObjectList& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetItem(long Index);
	long GetCount();
	LPUNKNOWN Get_NewEnum();
};
/////////////////////////////////////////////////////////////////////////////
// IVarObjectList wrapper class

class IVarObjectList : public COleDispatchDriver
{
public:
	IVarObjectList() {}		// Calls COleDispatchDriver default constructor
	IVarObjectList(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IVarObjectList(const IVarObjectList& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetItem(long Index);
	long GetCount();
	LPUNKNOWN Get_NewEnum();
};
/////////////////////////////////////////////////////////////////////////////
// ILabelObject wrapper class

class ILabelObject : public COleDispatchDriver
{
public:
	ILabelObject() {}		// Calls COleDispatchDriver default constructor
	ILabelObject(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ILabelObject(const ILabelObject& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ITextAttributes wrapper class

class ITextAttributes : public COleDispatchDriver
{
public:
	ITextAttributes() {}		// Calls COleDispatchDriver default constructor
	ITextAttributes(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ITextAttributes(const ITextAttributes& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	CString GetText();
	void SetText(LPCTSTR lpszNewValue);
	CString GetFont_1();
	void SetFont_1(LPCTSTR lpszNewValue);
	CString GetFont_2();
	void SetFont_2(LPCTSTR lpszNewValue);
	long GetJustify();
	void SetJustify(long nNewValue);
	long GetVJustify();
	void SetVJustify(long nNewValue);
	BOOL GetMirrored();
	void SetMirrored(BOOL bNewValue);
	BOOL GetVertical();
	void SetVertical(BOOL bNewValue);
	long GetTextColor();
	void SetTextColor(long nNewValue);
	long GetBackGroundColor();
	void SetBackGroundColor(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ITextAttributes2 wrapper class

class ITextAttributes2 : public COleDispatchDriver
{
public:
	ITextAttributes2() {}		// Calls COleDispatchDriver default constructor
	ITextAttributes2(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ITextAttributes2(const ITextAttributes2& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	CString GetText();
	void SetText(LPCTSTR lpszNewValue);
	CString GetFont_1();
	void SetFont_1(LPCTSTR lpszNewValue);
	CString GetFont_2();
	void SetFont_2(LPCTSTR lpszNewValue);
	long GetJustify();
	void SetJustify(long nNewValue);
	long GetVJustify();
	void SetVJustify(long nNewValue);
	BOOL GetMirrored();
	void SetMirrored(BOOL bNewValue);
	BOOL GetVertical();
	void SetVertical(BOOL bNewValue);
	long GetTextColor();
	void SetTextColor(long nNewValue);
	long GetBackGroundColor();
	void SetBackGroundColor(long nNewValue);
	CString GetRichText();
	void SetRichText(LPCTSTR lpszNewValue);
	BOOL GetShadowEffect();
	void SetShadowEffect(BOOL bNewValue);
	BOOL GetOutlineEffect();
	void SetOutlineEffect(BOOL bNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ITextObj wrapper class

class ITextObj : public COleDispatchDriver
{
public:
	ITextObj() {}		// Calls COleDispatchDriver default constructor
	ITextObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ITextObj(const ITextObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	BOOL GetIsVariable();
	void SetIsVariable(BOOL bNewValue);
	LPDISPATCH TextAttributes();
};
/////////////////////////////////////////////////////////////////////////////
// IRectObj wrapper class

class IRectObj : public COleDispatchDriver
{
public:
	IRectObj() {}		// Calls COleDispatchDriver default constructor
	IRectObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IRectObj(const IRectObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	BOOL GetBFilled();
	void SetBFilled(BOOL bNewValue);
	long GetBorder();
	void SetBorder(long nNewValue);
	long GetBorderColor();
	void SetBorderColor(long nNewValue);
	long GetFillColor();
	void SetFillColor(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ILineObj wrapper class

class ILineObj : public COleDispatchDriver
{
public:
	ILineObj() {}		// Calls COleDispatchDriver default constructor
	ILineObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ILineObj(const ILineObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	long GetLength();
	void SetLength(long nNewValue);
	long GetOrientation();
	void SetOrientation(long nNewValue);
	long GetThickness();
	void SetThickness(long nNewValue);
	long GetLineColor();
	void SetLineColor(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// IBarCodeObj wrapper class

class IBarCodeObj : public COleDispatchDriver
{
public:
	IBarCodeObj() {}		// Calls COleDispatchDriver default constructor
	IBarCodeObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IBarCodeObj(const IBarCodeObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	CString GetText();
	void SetText(LPCTSTR lpszNewValue);
	CString GetFont();
	void SetFont(LPCTSTR lpszNewValue);
	long GetTextPos();
	void SetTextPos(long nNewValue);
	long GetBCType();
	void SetBCType(long nNewValue);
	long GetSize();
	void SetSize(long nNewValue);
	long GetJustify();
	void SetJustify(long nNewValue);
	long GetLink();
	void SetLink(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// IGraphicObj wrapper class

class IGraphicObj : public COleDispatchDriver
{
public:
	IGraphicObj() {}		// Calls COleDispatchDriver default constructor
	IGraphicObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IGraphicObj(const IGraphicObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	long GetGraphicSource();
	void SetGraphicSource(long nNewValue);
	CString GetFileName();
	void SetFileName(LPCTSTR lpszNewValue);
	long GetBitmapHandle();
	void SetBitmapHandle(long nNewValue);
	long GetPaletteHandle();
	void SetPaletteHandle(long nNewValue);
	void SetWindowHandle(long nNewValue);
	long GetBorder();
	void SetBorder(long nNewValue);
	long GetBorderColor();
	void SetBorderColor(long nNewValue);
	void GrabClipboard();
};
/////////////////////////////////////////////////////////////////////////////
// IAddressObj wrapper class

class IAddressObj : public COleDispatchDriver
{
public:
	IAddressObj() {}		// Calls COleDispatchDriver default constructor
	IAddressObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IAddressObj(const IAddressObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	long GetBarCodePosition();
	void SetBarCodePosition(long nNewValue);
	BOOL GetB9DigitOnly();
	void SetB9DigitOnly(BOOL bNewValue);
	LPDISPATCH TextAttributes();
};
/////////////////////////////////////////////////////////////////////////////
// ICounterObj wrapper class

class ICounterObj : public COleDispatchDriver
{
public:
	ICounterObj() {}		// Calls COleDispatchDriver default constructor
	ICounterObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ICounterObj(const ICounterObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	CString GetPreText();
	void SetPreText(LPCTSTR lpszNewValue);
	CString GetPostText();
	void SetPostText(LPCTSTR lpszNewValue);
	long GetStart();
	void SetStart(long nNewValue);
	long GetCurrent();
	void SetCurrent(long nNewValue);
	long GetMinWidth();
	void SetMinWidth(long nNewValue);
	long GetIncrement();
	void SetIncrement(long nNewValue);
	BOOL GetUseLeadingZeros();
	void SetUseLeadingZeros(BOOL bNewValue);
	LPDISPATCH TextAttributes();
};
/////////////////////////////////////////////////////////////////////////////
// IDateTimeObj wrapper class

class IDateTimeObj : public COleDispatchDriver
{
public:
	IDateTimeObj() {}		// Calls COleDispatchDriver default constructor
	IDateTimeObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IDateTimeObj(const IDateTimeObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetObjType();
	CString GetName();
	void SetName(LPCTSTR lpszNewValue);
	long GetX();
	void SetX(long nNewValue);
	long GetY();
	void SetY(long nNewValue);
	long GetWidth();
	void SetWidth(long nNewValue);
	long GetHeight();
	void SetHeight(long nNewValue);
	long GetRotation();
	void SetRotation(long nNewValue);
	CString GetPreText();
	void SetPreText(LPCTSTR lpszNewValue);
	CString GetPostText();
	void SetPostText(LPCTSTR lpszNewValue);
	long GetFormat();
	void SetFormat(long nNewValue);
	BOOL GetIncludeTime();
	void SetIncludeTime(BOOL bNewValue);
	BOOL GetB24Hour();
	void SetB24Hour(BOOL bNewValue);
	LPDISPATCH TextAttributes();
};
/////////////////////////////////////////////////////////////////////////////
// ICircularTextAttributes wrapper class

class ICircularTextAttributes : public COleDispatchDriver
{
public:
	ICircularTextAttributes() {}		// Calls COleDispatchDriver default constructor
	ICircularTextAttributes(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ICircularTextAttributes(const ICircularTextAttributes& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	CString GetText();
	void SetText(LPCTSTR lpszNewValue);
	CString GetFont();
	void SetFont(LPCTSTR lpszNewValue);
	BOOL GetMirrored();
	void SetMirrored(BOOL bNewValue);
	long GetDisplayMode();
	void SetDisplayMode(long nNewValue);
	long GetTextColor();
	void SetTextColor(long nNewValue);
	long GetBackGroundColor();
	void SetBackGroundColor(long nNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ICircularTextAttributes2 wrapper class

class ICircularTextAttributes2 : public COleDispatchDriver
{
public:
	ICircularTextAttributes2() {}		// Calls COleDispatchDriver default constructor
	ICircularTextAttributes2(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ICircularTextAttributes2(const ICircularTextAttributes2& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	CString GetText();
	void SetText(LPCTSTR lpszNewValue);
	CString GetFont();
	void SetFont(LPCTSTR lpszNewValue);
	BOOL GetMirrored();
	void SetMirrored(BOOL bNewValue);
	long GetDisplayMode();
	void SetDisplayMode(long nNewValue);
	long GetTextColor();
	void SetTextColor(long nNewValue);
	long GetBackGroundColor();
	void SetBackGroundColor(long nNewValue);
	BOOL GetCenteredOnLabel();
	void SetCenteredOnLabel(BOOL bNewValue);
};
/////////////////////////////////////////////////////////////////////////////
// ICircularTextObj wrapper class

class ICircularTextObj : public COleDispatchDriver
{
public:
	ICircularTextObj() {}		// Calls COleDispatchDriver default constructor
	ICircularTextObj(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	ICircularTextObj(const ICircularTextObj& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	LPDISPATCH TextAttributes();
	BOOL GetIsVariable();
	void SetIsVariable(BOOL bNewValue);
};
