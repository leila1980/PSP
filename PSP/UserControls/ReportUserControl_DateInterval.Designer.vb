<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUserControl_DateInterval
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
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.txtDateTo = New DateTextBox.DateTextBox
        Me.txtDateFrom = New DateTextBox.DateTextBox
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.dpDateTo = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.dpDateFrom = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDate = New System.Windows.Forms.ComboBox
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.txtDateTo)
        Me.GroupBox.Controls.Add(Me.txtDateFrom)
        Me.GroupBox.Controls.Add(Me.lblDateTo)
        Me.GroupBox.Controls.Add(Me.dpDateTo)
        Me.GroupBox.Controls.Add(Me.lblDateFrom)
        Me.GroupBox.Controls.Add(Me.dpDateFrom)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.cboDate)
        Me.GroupBox.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(222, 100)
        Me.GroupBox.TabIndex = 15
        Me.GroupBox.TabStop = False
        '
        'txtDateTo
        '
        Me.txtDateTo.AutoSize = True
        Me.txtDateTo.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateTo.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateTo.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateTo.DateReadOnly = False
        Me.txtDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateTo.Location = New System.Drawing.Point(18, 69)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(119, 20)
        Me.txtDateTo.TabIndex = 16
        Me.txtDateTo.Value = ""
        '
        'txtDateFrom
        '
        Me.txtDateFrom.AutoSize = True
        Me.txtDateFrom.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateFrom.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateFrom.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateFrom.DateReadOnly = False
        Me.txtDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateFrom.Location = New System.Drawing.Point(17, 44)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(119, 20)
        Me.txtDateFrom.TabIndex = 15
        Me.txtDateFrom.Value = ""
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(144, 75)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(16, 13)
        Me.lblDateTo.TabIndex = 3
        Me.lblDateTo.Text = "تا "
        '
        'dpDateTo
        '
        Me.dpDateTo.CalendarType = FarsiLibrary.Win.Enums.CalendarTypes.English
        Me.dpDateTo.IsHot = True
        Me.dpDateTo.Location = New System.Drawing.Point(18, 68)
        Me.dpDateTo.Name = "dpDateTo"
        Me.dpDateTo.Size = New System.Drawing.Size(120, 20)
        Me.dpDateTo.TabIndex = 14
        Me.dpDateTo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(144, 46)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(17, 13)
        Me.lblDateFrom.TabIndex = 2
        Me.lblDateFrom.Text = "از "
        '
        'dpDateFrom
        '
        Me.dpDateFrom.CalendarType = FarsiLibrary.Win.Enums.CalendarTypes.English
        Me.dpDateFrom.IsHot = True
        Me.dpDateFrom.Location = New System.Drawing.Point(17, 43)
        Me.dpDateFrom.Name = "dpDateFrom"
        Me.dpDateFrom.Size = New System.Drawing.Size(120, 20)
        Me.dpDateFrom.TabIndex = 13
        Me.dpDateFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "بازه تاریخی "
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(17, 19)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(121, 21)
        Me.cboDate.TabIndex = 1
        '
        'ReportUserControl_DateInterval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "ReportUserControl_DateInterval"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(229, 100)
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpDateTo As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents dpDateFrom As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateTo As DateTextBox.DateTextBox
    Friend WithEvents txtDateFrom As DateTextBox.DateTextBox

End Class
