Module modPipeEncoder

  Function PipeEncode(ByVal s As String) As String
    Return s.Replace("\"c, "\\").Replace("|", "\|")
  End Function

  Function PipeDecode(ByVal s As String) As String()
    Dim tmp As New Generic.List(Of String)
    If s.Length = 0 Then Return tmp.ToArray
    Dim i, j, p As Integer
    Dim x As String = ""
    p = 0
    Do
      i = s.IndexOf("|"c, p)
      If i < 0 Then i = s.Length
      j = s.IndexOf("\"c, p)
      If j < 0 Then j = s.Length

      If i <= j Then
        tmp.Add(x & s.Substring(p, i - p))
        If i = j Then Return tmp.ToArray
        x = ""
        p = i + 1
      Else
        x &= s.Substring(p, j - p) & s(j + 1)
        p = j + 2
      End If
    Loop
  End Function

End Module
