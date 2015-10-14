Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedIPUI

  Private txtIPv4 As Control
  Private txtIPv6 As Control

  Public Overrides Sub LoadData(ByVal config As String)
    txtIPv4 = GetIPCtrl(True, False)
    Me.Controls.Add(txtIPv4)
    txtIPv4.Location = txtDummy1.Location
    txtIPv4.TabIndex = txtDummy1.TabIndex
    txtIPv6 = GetIPCtrl(False, True)
    Me.Controls.Add(txtIPv6)
    txtIPv6.Location = txtDummy2.Location
    txtIPv6.TabIndex = txtDummy2.TabIndex

    If config Is Nothing Then Exit Sub 'new instance

    Dim cfg = MyConfigIP.Load(config)
    If cfg.IPv4 IsNot Nothing Then txtIPv4.Text = cfg.IPv4.ToString
    If cfg.IPv6 IsNot Nothing Then txtIPv6.Text = cfg.IPv6.ToString
    ttl1.Value = cfg.TTL
  End Sub

  Public Overrides Function ValidateData() As Boolean
    Dim ip As IPAddress = Nothing
    If txtIPv4.Text.Trim.Length > 0 Then
      If Not IPAddress.TryParse(txtIPv4.Text.Trim, ip) OrElse _
         ip.IPVersion <> 4 Then
        MessageBox.Show("Invalid IPv4 address", "Fixed IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If
    End If
    If txtIPv6.Text.Trim.Length > 0 Then
      If Not IPAddress.TryParse(txtIPv6.Text.Trim, ip) OrElse _
         ip.IPVersion <> 6 Then
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
    If txtIPv4.Text.Trim.Length > 0 Then rv.IPv4 = IPAddressV4.Parse(txtIPv4.Text.Trim)
    If txtIPv6.Text.Trim.Length > 0 Then rv.IPv6 = IPAddressV6.Parse(txtIPv6.Text.Trim)
    rv.TTL = ttl1.Value
    Return rv.Save()
  End Function

End Class
