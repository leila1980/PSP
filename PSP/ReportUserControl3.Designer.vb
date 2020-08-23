<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUserControl3
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
        Me.cboFilterType = New System.Windows.Forms.ComboBox
        Me.MytxtFirst = New System.Windows.Forms.TextBox
        Me.MytxtSecond = New System.Windows.Forms.TextBox
        Me.lblBetween = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboFilterType
        '
        Me.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterType.FormattingEnabled = True
        Me.cboFilterType.Location = New System.Drawing.Point(251, 2)
        Me.cboFilterType.Name = "cboFilterType"
        Me.cboFilterType.Size = New System.Drawing.Size(121, 21)
        Me.cboFilterType.TabIndex = 0
        '
        'MytxtFirst
        '
        Me.MytxtFirst.Location = New System.Drawing.Point(118, 2)
        Me.MytxtFirst.Name = "MytxtFirst"
        Me.MytxtFirst.Size = New System.Drawing.Size(100, 21)
        Me.MytxtFirst.TabIndex = 1
        '
        'MytxtSecond
        '
        Me.MytxtSecond.Location = New System.Drawing.Point(4, 2)
        Me.MytxtSecond.Name = "MytxtSecond"
        Me.MytxtSecond.Size = New System.Drawing.Size(100, 21)
        Me.MytxtSecond.TabIndex = 2
        '
        'lblBetween
        '
        Me.lblBetween.AutoSize = True
        Me.lblBetween.Location = New System.Drawing.Point(106, 5)
        Me.lblBetween.Name = "lblBetween"
        Me.lblBetween.Size = New System.Drawing.Size(12, 13)
        Me.lblBetween.TabIndex = 3
        Me.lblBetween.Text = "æ"
        '
        'ReportUserControl3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBetween)
        Me.Controls.Add(Me.MytxtSecond)
        Me.Controls.Add(Me.MytxtFirst)
        Me.Controls.Add(Me.cboFilterType)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "ReportUserControl3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(373, 26)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFilterType As System.Windows.Forms.ComboBox
    Friend WithEvents MytxtFirst As System.Windows.Forms.TextBox
    Friend WithEvents MytxtSecond As System.Windows.Forms.TextBox
    Friend WithEvents lblBetween As System.Windows.Forms.Label

End Class
