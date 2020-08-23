<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Timing
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtMin = New AMS.TextBox.NumericTextBox
        Me.txtHour = New AMS.TextBox.NumericTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtMin
        '
        Me.txtMin.AllowNegative = True
        Me.txtMin.DigitsInGroup = 0
        Me.txtMin.Flags = 0
        Me.txtMin.Location = New System.Drawing.Point(77, 3)
        Me.txtMin.MaxDecimalPlaces = 4
        Me.txtMin.MaxLength = 2
        Me.txtMin.MaxWholeDigits = 2
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Prefix = ""
        Me.txtMin.RangeMax = 1.7976931348623157E+308
        Me.txtMin.RangeMin = -1.7976931348623157E+308
        Me.txtMin.Size = New System.Drawing.Size(28, 20)
        Me.txtMin.TabIndex = 12
        '
        'txtHour
        '
        Me.txtHour.AllowNegative = True
        Me.txtHour.DigitsInGroup = 0
        Me.txtHour.Flags = 0
        Me.txtHour.Location = New System.Drawing.Point(3, 3)
        Me.txtHour.MaxDecimalPlaces = 4
        Me.txtHour.MaxLength = 1000
        Me.txtHour.MaxWholeDigits = 1000
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Prefix = ""
        Me.txtHour.RangeMax = 1.7976931348623157E+308
        Me.txtHour.RangeMin = -1.7976931348623157E+308
        Me.txtHour.Size = New System.Drawing.Size(59, 20)
        Me.txtHour.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = ":"
        '
        'Timing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMin)
        Me.Controls.Add(Me.txtHour)
        Me.Name = "Timing"
        Me.Size = New System.Drawing.Size(107, 26)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtMin As AMS.TextBox.NumericTextBox
    Private WithEvents txtHour As AMS.TextBox.NumericTextBox

End Class
