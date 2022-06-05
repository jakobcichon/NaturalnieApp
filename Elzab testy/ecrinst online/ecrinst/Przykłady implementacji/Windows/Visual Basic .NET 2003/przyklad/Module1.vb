Module Module1

    'deklaracja funkcji z dwoma parametrami
    Private Declare Function __StdTowarMax Lib "WinIP.Dll" (ByVal InputFile As String, ByVal OutputFile As String) As Byte
    'deklaracja funkcji z jednym parametrem
    Private Declare Function __StdZTowar Lib "WinIP.Dll" (ByVal InputFile As String) As Byte

    Sub Main()

        Dim Err As Byte

        Err = __StdTowarMax("towarmax.in", "towarmax.out")
        If Err <> 0 Then
            'obs³uga b³êdów
            Exit Sub
        End If

        Err = __StdZTowar("ztowar.in")
        If Err <> 0 Then
            'obs³uga b³êdów
            Exit Sub
        End If

    End Sub

End Module



