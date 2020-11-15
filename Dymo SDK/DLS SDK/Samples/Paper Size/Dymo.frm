VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3015
   ClientLeft      =   90
   ClientTop       =   390
   ClientWidth     =   7140
   LinkTopic       =   "Form1"
   ScaleHeight     =   3015
   ScaleWidth      =   7140
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   1695
      Left            =   3480
      MultiLine       =   -1  'True
      TabIndex        =   3
      Text            =   "Dymo.frx":0000
      Top             =   360
      Width           =   3375
   End
   Begin VB.ListBox List1 
      Height          =   1620
      Left            =   120
      TabIndex        =   1
      Top             =   360
      Width           =   3132
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Print..."
      Height          =   552
      Left            =   5280
      TabIndex        =   0
      Top             =   2280
      Width           =   1632
   End
   Begin VB.Label Label2 
      Caption         =   "Text to print:"
      Height          =   255
      Left            =   3480
      TabIndex        =   4
      Top             =   120
      Width           =   2415
   End
   Begin VB.Label Label1 
      Caption         =   "Select Printer:"
      Height          =   252
      Left            =   120
      TabIndex        =   2
      Top             =   120
      Width           =   1452
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit





Private Sub Command1_Click()

Dim FoundPrn As Boolean
Dim i As Integer
Dim PaperID As Integer
Dim PrinterOrient As Integer

'MsgBox ("Using " + Printer.DeviceName)
   PaperID = GetPaperID("30252 Address") 'Look for Shipping Label
' This method (the VB way) shows htat VB doesn't properly modify the DevMode. The API mode below works great.
'If PaperID <> -1 Then   ' label was found, so print
'        Printer.PaperSize = PaperID
'        Printer.Orientation = vbPRORLandscape
'        Printer.CurrentX = 0
'        Printer.CurrentY = 0
'        Printer.Print "Printed the VB way. This is a test. This is only a test. Please stand by."
'        Printer.EndDoc
'   End If
'   If PaperID <> -1 Then   ' label was found, so print
'        Printer.PaperSize = PaperID
'        Printer.Orientation = vbPRORPortrait
'        Printer.CurrentX = 0
'        Printer.CurrentY = 0
'        Printer.Print "Printed the VB way. This is a test. This is only a test. Please stand by."
'        Printer.EndDoc
'   End If
' Now, the WinAPI way...
   If PaperID <> -1 Then   ' label was found, so print
' print in landscape orientation
        PrinterOrient = vbPRORLandscape
        SetPrnt PaperID, vbPRORLandscape
        Printer.CurrentX = 0
        Printer.CurrentY = 0
        Printer.Print Text1.Text
        Printer.EndDoc
' print in portrait orientation
        SetPrnt PaperID, vbPRORPortrait
        Printer.CurrentX = 0
        Printer.CurrentY = 0
        Printer.Print Text1.Text
        Printer.EndDoc
   End If


   If PaperID = -1 Then
    MsgBox ("Selected paper not supported by printer")
   End If

End Sub



Private Sub Form_Load()
    Dim i As Integer

    ' List all available printers
    For i = 0 To Printers.Count - 1
        List1.AddItem Printers(i).DeviceName
        If Printers(i).DeviceName = Printer.DeviceName Then
            List1.Selected(i) = True  ' Select current default printer
    End If
    Next i
End Sub
Private Sub List1_Click()
    Dim Prt As Printer

    ' Find and use the printer just selected in the ListBox
    For Each Prt In Printers
        If Prt.DeviceName = List1.Text Then
            Set Printer = Prt
            Exit For
        End If
    Next
      
End Sub




