<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchMakeFile
    Inherits frmBaseMakeFile

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
        Me.txtHour = New System.Windows.Forms.MaskedTextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(311, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "���� :"
        '
        'txtHour
        '
        Me.txtHour.Location = New System.Drawing.Point(271, 45)
        Me.txtHour.Mask = "90:00"
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(37, 21)
        Me.txtHour.TabIndex = 5
        Me.txtHour.ValidatingType = GetType(Date)
        '
        'frmSwitchMakeFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 522)
        Me.Controls.Add(Me.txtHour)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSwitchMakeFile"
        Me.ShowInTaskbar = False
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtHour, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHour As System.Windows.Forms.MaskedTextBox
End Class
