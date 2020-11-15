Public Class Form1
    Inherits System.Windows.Forms.Form

    Public DymoAddIn As Dymo.DymoAddIn
    Public DymoLabels As Dymo.DymoLabels

    Public Sub SetupLabelObject()
        ' get the objects on the label
        Dim ObjNames As String
        Dim i As Integer

        ' clear edit control
        ObjectDataEdit.Clear()

        ' clear all items first
        ObjectNameCmb.Items.Clear()

        ObjNames = DymoLabels.GetObjectNames(True)

        If Not (ObjNames Is Nothing) Then
            ' parse the result
            i = ObjNames.IndexOf("|")
            While i >= 0
                ObjectNameCmb.Items.Add(ObjNames.Substring(0, i))
                ObjNames = ObjNames.Remove(0, i + 1)
                i = ObjNames.IndexOf("|")
            End While
            If ObjNames.Length > 0 Then
                ObjectNameCmb.Items.Add(ObjNames)
            End If

            ObjectNameCmb.SelectedIndex = 0
        End If
    End Sub

    Public Sub SetupLabelWriterSelection(ByVal InitCmb As Boolean)
        Dim PrtNames As String
        Dim i As Integer

        ' get the objects on the label
        If InitCmb Then
            ' clear all items first
            LabelWriterCmb.Items.Clear()

            PrtNames = DymoAddIn.GetDymoPrinters()

            If Not (PrtNames Is Nothing) Then
                ' parse the result
                i = PrtNames.IndexOf("|")
                While i >= 0
                    LabelWriterCmb.Items.Add(PrtNames.Substring(0, i))
                    PrtNames = PrtNames.Remove(0, i + 1)
                    i = PrtNames.IndexOf("|")
                End While
                If PrtNames.Length > 0 Then
                    LabelWriterCmb.Items.Add(PrtNames)
                End If

                PrtNames = DymoAddIn.GetCurrentPrinterName()
                If Not (PrtNames Is Nothing) Then
                    LabelWriterCmb.SelectedIndex = LabelWriterCmb.Items.IndexOf(PrtNames)
                Else
                    LabelWriterCmb.SelectedIndex = 0
                End If
            End If
        End If

        ' check if selected/current printer is a twin turbo printer
        TrayCmb.Enabled = DymoAddIn.IsTwinTurboPrinter(LabelWriterCmb.Text)
        If TrayCmb.Enabled Then
            ' show the current tray selection if the printer
            ' is a twin turbo
            i = DymoAddIn.GetCurrentPaperTray()
            If i = 0 Then
                TrayCmb.SelectedIndex = 0 ' left tray
            ElseIf i = 1 Then
                TrayCmb.SelectedIndex = 1 ' right tray
            ElseIf i = 2 Then
                TrayCmb.SelectedIndex = 2 ' auto switch
            Else
                TrayCmb.SelectedIndex = 2 ' tray selection not set, so default to auto switch
            End If
        End If
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' create DYMO COM objects
        DymoAddIn = New Dymo.DymoAddIn
        DymoLabels = New Dymo.DymoLabels

        ' show the file name
        FileNameEdit.Text = DymoAddIn.FileName

        ' populate label objects
        SetupLabelObject()

        ' obtain the currently selected printer
		SetupLabelWriterSelection(True)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents CloseBtn As System.Windows.Forms.Button
    Friend WithEvents BrowseBtn As System.Windows.Forms.Button
    Friend WithEvents FileNameEdit As System.Windows.Forms.TextBox
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintLabelBtn As System.Windows.Forms.Button
    Friend WithEvents TrayCmb As System.Windows.Forms.ComboBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents LabelWriterCmb As System.Windows.Forms.ComboBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ObjectDataEdit As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents ObjectNameCmb As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.CloseBtn = New System.Windows.Forms.Button
Me.BrowseBtn = New System.Windows.Forms.Button
Me.FileNameEdit = New System.Windows.Forms.TextBox
Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
Me.label1 = New System.Windows.Forms.Label
Me.groupBox2 = New System.Windows.Forms.GroupBox
Me.PrintLabelBtn = New System.Windows.Forms.Button
Me.TrayCmb = New System.Windows.Forms.ComboBox
Me.label6 = New System.Windows.Forms.Label
Me.LabelWriterCmb = New System.Windows.Forms.ComboBox
Me.label5 = New System.Windows.Forms.Label
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.ObjectDataEdit = New System.Windows.Forms.TextBox
Me.label3 = New System.Windows.Forms.Label
Me.label2 = New System.Windows.Forms.Label
Me.ObjectNameCmb = New System.Windows.Forms.ComboBox
Me.groupBox2.SuspendLayout()
Me.groupBox1.SuspendLayout()
Me.SuspendLayout()
'
'CloseBtn
'
Me.CloseBtn.Location = New System.Drawing.Point(448, 372)
Me.CloseBtn.Name = "CloseBtn"
Me.CloseBtn.TabIndex = 11
Me.CloseBtn.Text = "Close"
'
'BrowseBtn
'
Me.BrowseBtn.Location = New System.Drawing.Point(444, 36)
Me.BrowseBtn.Name = "BrowseBtn"
Me.BrowseBtn.TabIndex = 8
Me.BrowseBtn.Text = "Browse..."
'
'FileNameEdit
'
Me.FileNameEdit.Location = New System.Drawing.Point(12, 36)
Me.FileNameEdit.Name = "FileNameEdit"
Me.FileNameEdit.ReadOnly = True
Me.FileNameEdit.Size = New System.Drawing.Size(424, 20)
Me.FileNameEdit.TabIndex = 7
Me.FileNameEdit.Text = ""
'
'openFileDialog1
'
Me.openFileDialog1.DefaultExt = "lwl"
Me.openFileDialog1.Filter = "DYMO Label File (*.lwl)|*.lwl"
Me.openFileDialog1.Title = "Open DYMO Label File"
'
'label1
'
Me.label1.Location = New System.Drawing.Point(12, 16)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(316, 16)
Me.label1.TabIndex = 6
Me.label1.Text = "Select a label file here: (click Browse... to browse to the file)"
'
'groupBox2
'
Me.groupBox2.Controls.Add(Me.PrintLabelBtn)
Me.groupBox2.Controls.Add(Me.TrayCmb)
Me.groupBox2.Controls.Add(Me.label6)
Me.groupBox2.Controls.Add(Me.LabelWriterCmb)
Me.groupBox2.Controls.Add(Me.label5)
Me.groupBox2.Location = New System.Drawing.Point(16, 232)
Me.groupBox2.Name = "groupBox2"
Me.groupBox2.Size = New System.Drawing.Size(508, 132)
Me.groupBox2.TabIndex = 10
Me.groupBox2.TabStop = False
Me.groupBox2.Text = "LabelWriter Selection"
'
'PrintLabelBtn
'
Me.PrintLabelBtn.Location = New System.Drawing.Point(8, 96)
Me.PrintLabelBtn.Name = "PrintLabelBtn"
Me.PrintLabelBtn.Size = New System.Drawing.Size(84, 23)
Me.PrintLabelBtn.TabIndex = 4
Me.PrintLabelBtn.Text = "Print Label"
'
'TrayCmb
'
Me.TrayCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.TrayCmb.Items.AddRange(New Object() {"Left Tray", "Right Tray", "Auto Switch"})
Me.TrayCmb.Location = New System.Drawing.Point(312, 64)
Me.TrayCmb.Name = "TrayCmb"
Me.TrayCmb.Size = New System.Drawing.Size(128, 21)
Me.TrayCmb.TabIndex = 3
'
'label6
'
Me.label6.Location = New System.Drawing.Point(308, 24)
Me.label6.Name = "label6"
Me.label6.Size = New System.Drawing.Size(188, 32)
Me.label6.TabIndex = 2
Me.label6.Text = "Set tray selection (available only with LabelWriter TWIN TURBO)"
'
'LabelWriterCmb
'
Me.LabelWriterCmb.Location = New System.Drawing.Point(8, 64)
Me.LabelWriterCmb.Name = "LabelWriterCmb"
Me.LabelWriterCmb.Size = New System.Drawing.Size(280, 21)
Me.LabelWriterCmb.TabIndex = 1
'
'label5
'
Me.label5.Location = New System.Drawing.Point(16, 40)
Me.label5.Name = "label5"
Me.label5.Size = New System.Drawing.Size(156, 16)
Me.label5.TabIndex = 0
Me.label5.Text = "Select a LabelWriter here:"
'
'groupBox1
'
Me.groupBox1.Controls.Add(Me.ObjectDataEdit)
Me.groupBox1.Controls.Add(Me.label3)
Me.groupBox1.Controls.Add(Me.label2)
Me.groupBox1.Controls.Add(Me.ObjectNameCmb)
Me.groupBox1.Location = New System.Drawing.Point(16, 72)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(508, 148)
Me.groupBox1.TabIndex = 9
Me.groupBox1.TabStop = False
Me.groupBox1.Text = "Label Object"
'
'ObjectDataEdit
'
Me.ObjectDataEdit.Location = New System.Drawing.Point(204, 48)
Me.ObjectDataEdit.Multiline = True
Me.ObjectDataEdit.Name = "ObjectDataEdit"
Me.ObjectDataEdit.Size = New System.Drawing.Size(284, 84)
Me.ObjectDataEdit.TabIndex = 3
Me.ObjectDataEdit.Text = ""
'
'label3
'
Me.label3.Location = New System.Drawing.Point(208, 28)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(188, 16)
Me.label3.TabIndex = 2
Me.label3.Text = "Set label object data here:"
'
'label2
'
Me.label2.Location = New System.Drawing.Point(16, 28)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(172, 16)
Me.label2.TabIndex = 1
Me.label2.Text = "Select a label object here:"
'
'ObjectNameCmb
'
Me.ObjectNameCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ObjectNameCmb.Location = New System.Drawing.Point(16, 48)
Me.ObjectNameCmb.Name = "ObjectNameCmb"
Me.ObjectNameCmb.Size = New System.Drawing.Size(172, 21)
Me.ObjectNameCmb.TabIndex = 0
'
'Form1
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(540, 406)
Me.Controls.Add(Me.BrowseBtn)
Me.Controls.Add(Me.FileNameEdit)
Me.Controls.Add(Me.label1)
Me.Controls.Add(Me.groupBox2)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.CloseBtn)
Me.Name = "Form1"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "DYMO SDK VB Sample"
Me.groupBox2.ResumeLayout(False)
Me.groupBox1.ResumeLayout(False)
Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        ' clean up DYMO COM objects
        DymoAddIn = Nothing
        DymoLabels = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub BrowseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseBtn.Click
        Dim str As String
        Dim i As Integer

        'use the current file name's folder as the initial
        'directory for the open file dialog
        str = FileNameEdit.Text
        i = str.LastIndexOf("\")
        str = str.Substring(0, i)
        openFileDialog1.InitialDirectory = str

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' open user selected label file
            If DymoAddIn.Open(openFileDialog1.FileName) Then
                ' show the file name
                FileNameEdit.Text = openFileDialog1.FileName

                ' populate label objects
                SetupLabelObject()

                ' setup paper tray selection
                SetupLabelWriterSelection(False)
            End If
        End If
    End Sub

    Private Sub LabelWriterCmb_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelWriterCmb.SelectionChangeCommitted
        DymoAddIn.SelectPrinter(LabelWriterCmb.Text)
        SetupLabelWriterSelection(False)
    End Sub

    Private Sub PrintLabelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLabelBtn.Click
        ' ATTENTION: This call is very important if you're making mutiple calls to the Print() or Print2() function!
        ' It's a good idea to always wrap StartPrintJob() and EndPrintJob() around a call to Print() or Print2() function.
        'DymoAddIn.StartPrintJob()

        ' print two copies
        DymoAddIn.Print2(1, False, TrayCmb.SelectedIndex)

        ' ATTENTION: Every StartPrintJob() must have a matching EndPrintJob()
        'DymoAddIn.EndPrintJob()
    End Sub

    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        Close()
    End Sub

    Private Sub ObjectDataEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjectDataEdit.Leave
        DymoLabels.SetField(ObjectNameCmb.Text, ObjectDataEdit.Text)
    End Sub
End Class
