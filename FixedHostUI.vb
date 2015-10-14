Imports JHSoftware.SimpleDNS.Plugin

Public Class FixedHostUI

  Public Overrides Sub LoadData(ByVal config As String)
    If config Is Nothing Then Exit Sub 'new instance

    Dim cfg = MyConfigHost.Load(config)
    txtHost.Text = cfg.HostName.ToString
    If cfg.CNAME Then radCNAME.Checked = True Else radTypes.Checked = True
    chkMX.Checked = cfg.MX
    chkNS.Checked = cfg.NS
    chkPTR.Checked = cfg.PTR
    ttl1.Value = cfg.TTL
  End Sub

  Public Overrides Function ValidateData() As Boolean
    If txtHost.Text.Trim.Length = 0 Then
      MessageBox.Show("Host name is required", "Fixed Host Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If

    Dim hn As JHSoftware.SimpleDNS.Plugin.DomainName
    If Not JHSoftware.SimpleDNS.Plugin.DomainName.TryParse(txtHost.Text.Trim, hn) Then
      MessageBox.Show("Invalid host name", "Fixed Host Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If

    If radTypes.Checked AndAlso _
       Not chkMX.Checked AndAlso _
       Not chkNS.Checked AndAlso _
       Not chkPTR.Checked Then
      MessageBox.Show("At least one record type must be selected", "Fixed Host Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If

    Return True
  End Function

  Public Overrides Function SaveData() As String
    Dim rv As New MyConfigHost
    rv.HostName = txtHost.Text.Trim
    rv.CNAME = radCNAME.Checked
    rv.MX = chkMX.Checked
    rv.NS = chkNS.Checked
    rv.PTR = chkPTR.Checked
    rv.TTL = ttl1.Value
    Return rv.Save()
  End Function

  Private Sub radCNAME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCNAME.CheckedChanged, radTypes.CheckedChanged
    chkMX.Enabled = radTypes.Checked
    chkNS.Enabled = radTypes.Checked
    chkPTR.Enabled = radTypes.Checked
  End Sub
End Class
