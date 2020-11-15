Attribute VB_Name = "Module1"

   Option Explicit
   
   Private Declare Function DeviceCapabilities Lib "winspool.drv" _
    Alias "DeviceCapabilitiesA" (ByVal lpsDeviceName As String, _
    ByVal lpPort As String, ByVal iIndex As Long, lpOutput As Any, _
    ByVal dev As Long) As Long
    

    

   Private Const DC_PAPERS = 2
   Private Const DC_PAPERNAMES = 16
   Private Const CCHDEVICENAME = 32
   Private Const CCHFORMNAME = 32
   Private Const PRINTER_ACCESS_ADMINISTER = &H4
   Private Const PRINTER_ACCESS_USE = &H8
   Private Const STANDARD_RIGHTS_REQUIRED = &HF0000
   Private Const PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED Or _
     PRINTER_ACCESS_ADMINISTER Or PRINTER_ACCESS_USE)

   Private Const DM_MODIFY = 8
   Private Const DM_COPY = 2
   Private Const DM_IN_BUFFER = DM_MODIFY
   Private Const DM_OUT_BUFFER = DM_COPY
   Private Const IDOK = 1
   Private Const GMEM_MOVEABLE = &H2
   Private Const GMEM_ZEROINIT = &H40
   Private Const GHND = (GMEM_MOVEABLE Or GMEM_ZEROINIT)
   Private Const vbNullPtr = 0&

   ' Add appripriate Constants for what you want to change
   Private Const DM_DUPLEX = &H1000&
   Private Const DM_ORIENTATION = &H1&
   Private Const DM_COPIES = &H100&
   Private Const DMPAPER_A4 = 9
   Private Const DM_PAPERSIZE = &H2&

   ' Constants for Duplex
   Private Const DMDUP_SIMPLEX = 1
   Private Const DMDUP_VERTICAL = 2
   Private Const DMDUP_HORIZONTAL = 3

   ' Constants for Orientation
   Private Const DMORIENT_PORTRAIT = 1
   Private Const DMORIENT_LANDSCAPE = 2

   Private Type ACL
      AclRevision As Byte
      Sbz1 As Byte
      AclSize As Integer
      AceCount As Integer
      Sbz2 As Integer
   End Type

   Private Type SECURITY_DESCRIPTOR
      Revision As Byte
      Sbz1 As Byte
      Control As Long
      Owner As Long
      Group As Long
      Sacl As Long   ' PACL
      Dacl As Long   ' PACL
   End Type

   
   Private Type PRINTER_DEFAULTS
      pDatatype As String
      pDevMode As Long
      DesiredAccess As Long
   End Type

   Private Type PRINTER_INFO_2
      pServerName As Long    ' Pointer to a String
      pPrinterName As Long   ' Pointer to a String
      pShareName As Long     ' Pointer to a String
      pPortName As Long      ' Pointer to a String
      pDriverName As Long    ' Pointer to a String
      pComment As Long       ' Pointer to a String
      pLocation As Long      ' Pointer to a String
      pDevMode As Long
      pSepFile As Long       ' Pointer to a String
      pPrintProcessor As Long   ' Pointer to a String
      pDatatype As Long      ' Pointer to a String
      pParameters As Long    ' Pointer to a String
      pSecurityDescriptor As Long
      Attributes As Long
      Priority As Long
      DefaultPriority As Long
      StartTime As Long
      UntilTime As Long
      Status As Long
      cJobs As Long
      AveragePPM As Long
   End Type

   Private Type DEVMODE
      dmDeviceName(1 To CCHDEVICENAME) As Byte ' As String * CCHDEVICENAME
      dmSpecVersion As Integer
      dmDriverVersion As Integer
      dmSize As Integer
      dmDriverExtra As Integer
      dmFields As Long
      dmOrientation As Integer
      dmPaperSize As Integer
      dmPaperLength As Integer
      dmPaperWidth As Integer
      dmScale As Integer
      dmCopies As Integer
      dmDefaultSource As Integer
      dmPrintQuality As Integer
      dmColor As Integer
      dmDuplex As Integer
      dmYResolution As Integer
      dmTTOption As Integer
      dmCollate As Integer
      dmFormName(1 To CCHFORMNAME) As Byte ' As String * CCHFORMNAME
      dmUnusedPadding As Integer
      dmBitsPerPel As Integer
      dmPelsWidth As Long
      dmPelsHeight As Long
      dmDisplayFlags As Long
      dmDisplayFrequency As Long
   End Type

   Private Declare Function OpenPrinter Lib "winspool.drv" Alias _
     "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, _
     pDefault As PRINTER_DEFAULTS) As Long
   Private Declare Function GetPrinter Lib "winspool.drv" Alias "GetPrinterA" _
     (ByVal hPrinter As Long, ByVal Level As Long, pPrinter As Any, _
     ByVal cbBuf As Long, pcbNeeded As Long) As Long
   Private Declare Function SetPrinter Lib "winspool.drv" Alias "SetPrinterA" _
     (ByVal hPrinter As Long, ByVal Level As Long, pPrinter As Any, _
     ByVal Command As Long) As Long
   Private Declare Function ClosePrinter Lib "winspool.drv" _
     (ByVal hPrinter As Long) As Long
   Private Declare Function DocumentProperties Lib "winspool.drv" Alias _
     "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, _
     ByVal pDeviceName As String, pDevModeOutput As Any, _
     pDevModeInput As Any, ByVal fMode As Long) As Long
   Private Declare Sub CopyMemory Lib "KERNEL32" Alias "RtlMoveMemory" ( _
     hpvDest As Any, hpvSource As Any, ByVal cbCopy As Long)


   ' get a list of all supported paper names and their corresponding ID's. If
' the requested paper is found, return the ID. Otherwise, return -1 on error
Function GetPaperID(PaperName As String) As Integer
    Dim prn As Printer
    Dim dwpapers As Long    ' number of papers being returned
    Dim ct As Long
    Dim nameslist As String ' array of 64 byte paper names
    Dim numPapers() As Integer  ' corresponding array of paper IDs'
    Dim LabelName As String
    
    Set prn = Printer
    PaperName = UCase(PaperName)    ' always do a case insensitive compare
    ' DeviceCapabilities is sued to return list of PaperID's and Paper Names
    dwpapers = DeviceCapabilities(prn.DeviceName, prn.Port, _
        DC_PAPERS, ByVal vbNullString, 0)   ' Number of papers in driver
    ReDim numPapers(1 To dwpapers)          ' make room for all the paper ID's
    nameslist = String(64 * dwpapers, 0)    ' make room for all the paper Names (each is 64 chars max)
    dwpapers = DeviceCapabilities(prn.DeviceName, prn.Port, _
        DC_PAPERS, numPapers(1), 0) ' get the paper ID's into the array
    dwpapers = DeviceCapabilities(prn.DeviceName, prn.Port, _
        DC_PAPERNAMES, ByVal nameslist, 0)  ' get the array of paper names

    For ct = 1 To dwpapers  ' walk through list of paper names looking for desired paper
        LabelName = Mid(nameslist, 64 * (ct - 1) + 1, 64)
        LabelName = UCase(Left(LabelName, InStr(1, LabelName, _
           Chr(0)) - 1))    ' get the uppercase versionof the paper name
        If LabelName = PaperName Then   ' paper found, get it's ID and exit
            GetPaperID = numPapers(ct)
            Exit Function
        End If
    Next ct
    GetPaperID = -1 ' paper not found
End Function

Public Sub SetPrnt(PaperID As Integer, Orientation As Integer)
      Dim hGlobal As Long, hPrinter As Long, dwNeeded As Long
      Dim pi2 As PRINTER_INFO_2, i As Integer, pbuf() As Byte
      Dim dm As DEVMODE
      Dim pd As PRINTER_DEFAULTS
      Dim bFlag As Long, lFlag As Long
     
      hGlobal = 0: hPrinter = 0: dwNeeded = 0
      pd.pDatatype = "TEXT"
      pd.pDevMode = VarPtr(dm)
      pd.DesiredAccess = PRINTER_ACCESS_USE
      ' Open printer handle (in Windows NT/2000, you need full-access
      ' because you will eventually use SetPrinter)
      bFlag = OpenPrinter(Printer.DeviceName, hPrinter, pd)
      If (bFlag = 0) Or (hPrinter = vbNullPtr) Then GoTo ABORT
      
      '  The first GetPrinter() tells you how big the buffer should be in
      '  order to hold all of PRINTER_INFO_2. Note that this usually returns
      '  as FALSE, which only means that the buffer (the third parameter) was
      '  not filled in. You don't want it filled in here.
      
      Call GetPrinter(hPrinter, 2, 0, 0, dwNeeded)
      If (dwNeeded = 0) Then GoTo ABORT
      
      '  Allocate enough space for PRINTER_INFO_2
      
      ReDim pbuf(dwNeeded)
      For i = 0 To dwNeeded
          pbuf(i) = 0
      Next i
      
      '  The second GetPrinter() call fills in all the current settings,
      '  so all you need to do is modify what you're interested in.
      
      bFlag = GetPrinter(hPrinter, 2, pbuf(0), dwNeeded, dwNeeded)
      If bFlag = 0 Then GoTo ABORT
      Call CopyMemory(pi2, pbuf(0), Len(pi2)) ' now, make a working copy of DevMode
      
     '  Set orientation and papersize based on what is in Pritner object.

     If pi2.pDevMode <> vbNullPtr Then
          Call CopyMemory(dm, ByVal pi2.pDevMode, Len(dm))
          ' Change the devmode by first setting dmFields to the
          ' members that will change, using a bitwise Or
          dm.dmFields = DM_ORIENTATION Or DM_PAPERSIZE  ' setting papersize and orientation
          dm.dmPaperSize = PaperID
          dm.dmOrientation = Orientation
          Call CopyMemory(ByVal pi2.pDevMode, dm, Len(dm))  ' set it back
             
              '  Merge changes back into DevMode
          lFlag = DocumentProperties(vbNullPtr, hPrinter, _
                   Printer.DeviceName, _
                   ByVal pi2.pDevMode, ByVal pi2.pDevMode, _
                   DM_IN_BUFFER Or DM_OUT_BUFFER)
          If lFlag <> IDOK Then GoTo ABORT
             
          Call CopyMemory(pbuf(0), pi2, Len(pi2))

          bFlag = SetPrinter(hPrinter, 2, pbuf(0), 0)
          If bFlag = 0 Then GoTo ABORT
     End If

ABORT:
     '  Clean up.
   End Sub


