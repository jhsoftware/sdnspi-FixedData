<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedHostUI
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
    Me.Label3 = New System.Windows.Forms.Label
    Me.ttl1 = New ctlTTL
    Me.radCNAME = New System.Windows.Forms.RadioButton
    Me.chkMX = New System.Windows.Forms.CheckBox
    Me.chkPTR = New System.Windows.Forms.CheckBox
    Me.chkNS = New System.Windows.Forms.CheckBox
    Me.radTypes = New System.Windows.Forms.RadioButton
    Me.txtHost = New System.Windows.Forms.TextBox
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(-3, 130)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(127, 13)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Respond with host name:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(-3, 179)
    Me.Label3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "DNS record TTL (Time To Live):"
    '
    'ttl1
    '
    Me.ttl1.AutoSize = True
    Me.ttl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.ttl1.BackColor = System.Drawing.Color.Transparent
    Me.ttl1.Location = New System.Drawing.Point(0, 195)
    Me.ttl1.Name = "ttl1"
    Me.ttl1.ReadOnly = False
    Me.ttl1.Size = New System.Drawing.Size(156, 21)
    Me.ttl1.TabIndex = 8
    Me.ttl1.Value = 300
    '
    'radCNAME
    '
    Me.radCNAME.CheckAlign = System.Drawing.ContentAlignment.TopLeft
    Me.radCNAME.Checked = True
    Me.radCNAME.Location = New System.Drawing.Point(0, 0)
    Me.radCNAME.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
    Me.radCNAME.Name = "radCNAME"
    Me.radCNAME.Size = New System.Drawing.Size(293, 31)
    Me.radCNAME.TabIndex = 0
    Me.radCNAME.TabStop = True
    Me.radCNAME.Text = "Respond to all DNS requests (for any record type) with a CNAME-record (alias) poi" & _
        "nting to the host name below"
    Me.radCNAME.TextAlign = System.Drawing.ContentAlignment.TopLeft
    Me.radCNAME.UseVisualStyleBackColor = True
    '
    'chkMX
    '
    Me.chkMX.AutoSize = True
    Me.chkMX.Enabled = False
    Me.chkMX.Location = New System.Drawing.Point(20, 57)
    Me.chkMX.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.chkMX.Name = "chkMX"
    Me.chkMX.Size = New System.Drawing.Size(80, 17)
    Me.chkMX.TabIndex = 2
    Me.chkMX.Text = "MX-records"
    Me.chkMX.UseVisualStyleBackColor = True
    '
    'chkPTR
    '
    Me.chkPTR.AutoSize = True
    Me.chkPTR.Enabled = False
    Me.chkPTR.Location = New System.Drawing.Point(20, 97)
    Me.chkPTR.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.chkPTR.Name = "chkPTR"
    Me.chkPTR.Size = New System.Drawing.Size(86, 17)
    Me.chkPTR.TabIndex = 4
    Me.chkPTR.Text = "PTR-records"
    Me.chkPTR.UseVisualStyleBackColor = True
    '
    'chkNS
    '
    Me.chkNS.AutoSize = True
    Me.chkNS.Enabled = False
    Me.chkNS.Location = New System.Drawing.Point(20, 77)
    Me.chkNS.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.chkNS.Name = "chkNS"
    Me.chkNS.Size = New System.Drawing.Size(79, 17)
    Me.chkNS.TabIndex = 3
    Me.chkNS.Text = "NS-records"
    Me.chkNS.UseVisualStyleBackColor = True
    '
    'radTypes
    '
    Me.radTypes.AutoSize = True
    Me.radTypes.Location = New System.Drawing.Point(0, 37)
    Me.radTypes.Name = "radTypes"
    Me.radTypes.Size = New System.Drawing.Size(309, 17)
    Me.radTypes.TabIndex = 1
    Me.radTypes.Text = "Only respond to DNS requests for the following record types:"
    Me.radTypes.UseVisualStyleBackColor = True
    '
    'txtHost
    '
    Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtHost.Location = New System.Drawing.Point(0, 146)
    Me.txtHost.Name = "txtHost"
    Me.txtHost.Size = New System.Drawing.Size(346, 20)
    Me.txtHost.TabIndex = 6
    '
    'FixedHostUI
    '
    Me.Controls.Add(Me.txtHost)
    Me.Controls.Add(Me.radTypes)
    Me.Controls.Add(Me.chkNS)
    Me.Controls.Add(Me.chkPTR)
    Me.Controls.Add(Me.chkMX)
    Me.Controls.Add(Me.radCNAME)
    Me.Controls.Add(Me.ttl1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Name = "FixedHostUI"
    Me.Size = New System.Drawing.Size(346, 224)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ttl1 As JHSoftware.SimpleDNS.ctlTTL
  Friend WithEvents radCNAME As System.Windows.Forms.RadioButton
  Friend WithEvents chkMX As System.Windows.Forms.CheckBox
  Friend WithEvents chkPTR As System.Windows.Forms.CheckBox
  Friend WithEvents chkNS As System.Windows.Forms.CheckBox
  Friend WithEvents radTypes As System.Windows.Forms.RadioButton
  Friend WithEvents txtHost As System.Windows.Forms.TextBox

End Class
