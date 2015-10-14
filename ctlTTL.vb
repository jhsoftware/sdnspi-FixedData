Public Class ctlTTL

  Private DoChangeEvents As Boolean = True

  Property [ReadOnly]() As Boolean
    Get
      Return txtVal.ReadOnly
    End Get
    Set(ByVal value As Boolean)
      txtVal.ReadOnly = value
      comExt.Enabled = (value = False)
    End Set
  End Property

  <System.ComponentModel.DefaultValue(0)> _
  Property Value() As Integer
    Get
      Dim rv As Integer, lv As Long
      If Not Long.TryParse(txtVal.Text, lv) Then Return 0
      If lv < 0 Then Return 0
      If lv > 2147483647 Then rv = 2147483647 Else rv = CInt(lv)
      Select Case comExt.SelectedIndex
        Case 0 ' seconds
          Return rv
        Case 1 ' minutes
          If rv > 35791394 Then rv = 35791394
          Return rv * 60
        Case 2 ' hours
          If rv > 596523 Then rv = 596523
          Return rv * 3600
        Case 3 ' days
          If rv > 24855 Then rv = 24855
          Return rv * 86400
      End Select
      Return 500
    End Get
    Set(ByVal value As Integer)
      If value < 0 Then Throw New ArgumentException("TTL must be zero or greater")
      DoChangeEvents = False
      If value = 0 Then
        txtVal.Text = "0"
        comExt.SelectedIndex = 0
      ElseIf value Mod 86400 = 0 Then
        comExt.SelectedIndex = 3
        txtVal.Text = (value \ 86400).ToString
      ElseIf value Mod 3600 = 0 Then
        comExt.SelectedIndex = 2
        txtVal.Text = (value \ 3600).ToString
      ElseIf value Mod 60 = 0 Then
        comExt.SelectedIndex = 1
        txtVal.Text = (value \ 60).ToString
      Else
        comExt.SelectedIndex = 0
        txtVal.Text = value.ToString
      End If
      DoChangeEvents = True
    End Set
  End Property

  Private Sub txtVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVal.KeyPress
    Select Case e.KeyChar
      Case "s"c, "S"c
        comExt.SelectedIndex = 0
      Case "m"c, "M"c
        comExt.SelectedIndex = 1
      Case "h"c, "H"c
        comExt.SelectedIndex = 2
      Case "d"c, "D"c
        comExt.SelectedIndex = 3
      Case "0"c To "9"c
        Exit Sub
      Case Else
        Dim a As Integer = AscW(e.KeyChar)
        If a < 32 Or a = 127 Then Exit Sub ' control chars
    End Select
    e.Handled = True
  End Sub

  Private Sub txtVal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVal.TextChanged
    If Not DoChangeEvents Then Exit Sub
    REM for example on paste
    Dim nv As String = ""
    For i As Integer = 0 To txtVal.Text.Length - 1
      If txtVal.Text(i) >= "0" AndAlso txtVal.Text(i) <= "9" Then nv &= txtVal.Text(i)
    Next
    If txtVal.Text <> nv Then txtVal.Text = nv
  End Sub

  Private Sub ctlTTL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
    Value = Value
  End Sub
End Class
