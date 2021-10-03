Imports JHSoftware.SimpleDNS

Public Class FixedIPUI

  Public Overrides Sub LoadData(ByVal config As String)
    If config Is Nothing Then Exit Sub 'new instance

    Dim cfg = MyConfigIP.Load(config)
    If cfg.IPv4 IsNot Nothing Then txtIPv4.Text = cfg.IPv4.ToString
    If cfg.IPv6 IsNot Nothing Then txtIPv6.Text = cfg.IPv6.ToString
    ttl1.Value = cfg.TTL
  End Sub

  Public Overrides Function ValidateData() As Boolean
    Dim ip As SdnsIP = Nothing
    If txtIPv4.Text.Trim.Length > 0 Then
      If Not SdnsIP.TryParse(txtIPv4.Text.Trim, ip) OrElse
       Not ip.IsIPv4 Then
        MessageBox.Show("Invalid IPv4 address", "Fixed IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If
    End If
    If txtIPv6.Text.Trim.Length > 0 Then
      If Not SdnsIP.TryParse(txtIPv6.Text.Trim, ip) OrElse
        Not ip.IsIPv6 Then
        MessageBox.Show("Invalid IPv6 address", "Fixed IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If
    End If
    If txtIPv4.Text.Trim.Length = 0 AndAlso txtIPv6.Text.Trim.Length = 0 Then
      MessageBox.Show("At least one of the IP addresses must be entered", "Fixed IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    Return True
  End Function

  Public Overrides Function SaveData() As String
    Dim rv As New MyConfigIP
    If txtIPv4.Text.Trim.Length > 0 Then rv.IPv4 = SdnsIPv4.Parse(txtIPv4.Text.Trim)
    If txtIPv6.Text.Trim.Length > 0 Then rv.IPv6 = SdnsIPv6.Parse(txtIPv6.Text.Trim)
    rv.TTL = ttl1.Value
    Return rv.Save()
  End Function

End Class
