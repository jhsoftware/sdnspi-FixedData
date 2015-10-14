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
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtDummy1 = New System.Windows.Forms.TextBox
    Me.txtDummy2 = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.ttl1 = New ctlTTL
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
    'txtDummy1
    '
    Me.txtDummy1.Location = New System.Drawing.Point(0, 16)
    Me.txtDummy1.Name = "txtDummy1"
    Me.txtDummy1.Size = New System.Drawing.Size(100, 20)
    Me.txtDummy1.TabIndex = 1
    Me.txtDummy1.Visible = False
    '
    'txtDummy2
    '
    Me.txtDummy2.Location = New System.Drawing.Point(0, 65)
    Me.txtDummy2.Name = "txtDummy2"
    Me.txtDummy2.Size = New System.Drawing.Size(100, 20)
    Me.txtDummy2.TabIndex = 3
    Me.txtDummy2.Visible = False
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
    'OptionsUI
    '
    Me.Controls.Add(Me.ttl1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtDummy2)
    Me.Controls.Add(Me.txtDummy1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Name = "OptionsUI"
    Me.Size = New System.Drawing.Size(338, 146)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDummy1 As System.Windows.Forms.TextBox
  Friend WithEvents txtDummy2 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ttl1 As ctlTTL

End Class
