<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedIPUI
  Inherits JHSoftware.SimpleDNS.Plugin.OptionsUI

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtIPv4 = New JHSoftware.SimpleDNS.ctlIP()
    Me.txtIPv6 = New JHSoftware.SimpleDNS.ctlIP()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ttl1 = New JHSoftware.SimpleDNS.ctlTTL()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(-3, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(152, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "IPv4 address (DNS A-records):"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-3, 49)
    Me.Label2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(173, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "IPv6 address (DNS AAAA-records):"
    '
    'txtIPv4
    '
    Me.txtIPv4.AutoSize = True
    Me.txtIPv4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.txtIPv4.IPVersion = JHSoftware.SimpleDNS.IPVersionEnum.IPv4
    Me.txtIPv4.Location = New System.Drawing.Point(0, 16)
    Me.txtIPv4.Name = "txtIPv4"
    Me.txtIPv4.Size = New System.Drawing.Size(174, 22)
    Me.txtIPv4.TabIndex = 1
    Me.txtIPv4.Value = Nothing
    '
    'txtIPv6
    '
    Me.txtIPv6.AutoSize = True
    Me.txtIPv6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.txtIPv6.IPVersion = JHSoftware.SimpleDNS.IPVersionEnum.IPv6
    Me.txtIPv6.Location = New System.Drawing.Point(0, 65)
    Me.txtIPv6.Name = "txtIPv6"
    Me.txtIPv6.Size = New System.Drawing.Size(281, 22)
    Me.txtIPv6.TabIndex = 3
    Me.txtIPv6.Value = Nothing
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(-3, 98)
    Me.Label3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "DNS record TTL (Time To Live):"
    '
    'ttl1
    '
    Me.ttl1.AutoSize = True
    Me.ttl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.ttl1.BackColor = System.Drawing.Color.Transparent
    Me.ttl1.Location = New System.Drawing.Point(0, 114)
    Me.ttl1.Name = "ttl1"
    Me.ttl1.ReadOnly = False
    Me.ttl1.Size = New System.Drawing.Size(156, 21)
    Me.ttl1.TabIndex = 5
    Me.ttl1.Value = 300
    '
    'FixedIPUI
    '
    Me.Controls.Add(Me.ttl1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtIPv6)
    Me.Controls.Add(Me.txtIPv4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Name = "FixedIPUI"
    Me.Size = New System.Drawing.Size(338, 146)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtIPv4 As JHSoftware.SimpleDNS.ctlIP
  Friend WithEvents txtIPv6 As JHSoftware.SimpleDNS.ctlIP
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ttl1 As JHSoftware.SimpleDNS.ctlTTL

End Class
