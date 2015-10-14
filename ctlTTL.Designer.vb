<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlTTL
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.txtVal = New System.Windows.Forms.TextBox
    Me.comExt = New System.Windows.Forms.ComboBox
    Me.SuspendLayout()
    '
    'txtVal
    '
    Me.txtVal.Location = New System.Drawing.Point(0, 0)
    Me.txtVal.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
    Me.txtVal.MaxLength = 10
    Me.txtVal.Name = "txtVal"
    Me.txtVal.Size = New System.Drawing.Size(75, 20)
    Me.txtVal.TabIndex = 0
    Me.txtVal.Text = "0"
    '
    'comExt
    '
    Me.comExt.BackColor = System.Drawing.SystemColors.Window
    Me.comExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.comExt.FormattingEnabled = True
    Me.comExt.Items.AddRange(New Object() {"Seconds", "Minutes", "Hours", "Days"})
    Me.comExt.Location = New System.Drawing.Point(81, 0)
    Me.comExt.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.comExt.Name = "comExt"
    Me.comExt.Size = New System.Drawing.Size(75, 21)
    Me.comExt.TabIndex = 1
    '
    'ctlTTL
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.AutoSize = True
    Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.BackColor = System.Drawing.Color.Transparent
    Me.Controls.Add(Me.comExt)
    Me.Controls.Add(Me.txtVal)
    Me.Name = "ctlTTL"
    Me.Size = New System.Drawing.Size(156, 21)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtVal As System.Windows.Forms.TextBox
  Friend WithEvents comExt As System.Windows.Forms.ComboBox

End Class
