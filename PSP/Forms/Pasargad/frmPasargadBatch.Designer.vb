<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPasargadBatch
    Inherits frmBase

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
        Me.gbxBatchHeader = New System.Windows.Forms.GroupBox()
        Me.cmbHeaderNumber = New System.Windows.Forms.ComboBox()
        Me.lblBatchDesc = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtBatchDescription_nvc = New System.Windows.Forms.TextBox()
        Me.txtDate_vc = New DateTextBox.DateTextBox()
        Me.lblHeaderNumber = New System.Windows.Forms.Label()
        Me.gbxBatchHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxBatchHeader
        '
        Me.gbxBatchHeader.Controls.Add(Me.lblHeaderNumber)
        Me.gbxBatchHeader.Controls.Add(Me.cmbHeaderNumber)
        Me.gbxBatchHeader.Controls.Add(Me.lblBatchDesc)
        Me.gbxBatchHeader.Controls.Add(Me.lblDate)
        Me.gbxBatchHeader.Controls.Add(Me.txtBatchDescription_nvc)
        Me.gbxBatchHeader.Controls.Add(Me.txtDate_vc)
        Me.gbxBatchHeader.Location = New System.Drawing.Point(12, 27)
        Me.gbxBatchHeader.Name = "gbxBatchHeader"
        Me.gbxBatchHeader.Size = New System.Drawing.Size(815, 58)
        Me.gbxBatchHeader.TabIndex = 19
        Me.gbxBatchHeader.TabStop = False
        '
        'cmbHeaderNumber
        '
        Me.cmbHeaderNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeaderNumber.FormattingEnabled = True
        Me.cmbHeaderNumber.Location = New System.Drawing.Point(620, 22)
        Me.cmbHeaderNumber.Name = "cmbHeaderNumber"
        Me.cmbHeaderNumber.Size = New System.Drawing.Size(121, 21)
        Me.cmbHeaderNumber.TabIndex = 14
        '
        'lblBatchDesc
        '
        Me.lblBatchDesc.AutoSize = True
        Me.lblBatchDesc.Location = New System.Drawing.Point(378, 22)
        Me.lblBatchDesc.Name = "lblBatchDesc"
        Me.lblBatchDesc.Size = New System.Drawing.Size(51, 13)
        Me.lblBatchDesc.TabIndex = 18
        Me.lblBatchDesc.Text = "توضیحات:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(551, 24)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(32, 13)
        Me.lblDate.TabIndex = 16
        Me.lblDate.Text = "تاریخ:"
        '
        'txtBatchDescription_nvc
        '
        Me.txtBatchDescription_nvc.Location = New System.Drawing.Point(33, 19)
        Me.txtBatchDescription_nvc.MaxLength = 120
        Me.txtBatchDescription_nvc.Name = "txtBatchDescription_nvc"
        Me.txtBatchDescription_nvc.ReadOnly = True
        Me.txtBatchDescription_nvc.Size = New System.Drawing.Size(339, 21)
        Me.txtBatchDescription_nvc.TabIndex = 17
        '
        'txtDate_vc
        '
        Me.txtDate_vc.AutoSize = True
        Me.txtDate_vc.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDate_vc.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDate_vc.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDate_vc.DateReadOnly = True
        Me.txtDate_vc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDate_vc.Location = New System.Drawing.Point(460, 20)
        Me.txtDate_vc.Name = "txtDate_vc"
        Me.txtDate_vc.Size = New System.Drawing.Size(87, 20)
        Me.txtDate_vc.TabIndex = 15
        Me.txtDate_vc.Value = ""
        '
        'lblHeaderNumber
        '
        Me.lblHeaderNumber.AutoSize = True
        Me.lblHeaderNumber.Location = New System.Drawing.Point(747, 25)
        Me.lblHeaderNumber.Name = "lblHeaderNumber"
        Me.lblHeaderNumber.Size = New System.Drawing.Size(41, 13)
        Me.lblHeaderNumber.TabIndex = 20
        Me.lblHeaderNumber.Text = "شماره:"
        '
        'frmPasargadBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 488)
        Me.Controls.Add(Me.gbxBatchHeader)
        Me.Name = "frmPasargadBatch"
        Me.ShowInTaskbar = False
        Me.Text = "ساخت بچ پاسارگاد"
        Me.Controls.SetChildIndex(Me.gbxBatchHeader, 0)
        Me.gbxBatchHeader.ResumeLayout(False)
        Me.gbxBatchHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbHeaderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtDate_vc As DateTextBox.DateTextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblBatchDesc As System.Windows.Forms.Label
    Friend WithEvents txtBatchDescription_nvc As System.Windows.Forms.TextBox
    Friend WithEvents gbxBatchHeader As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblHeaderNumber As System.Windows.Forms.Label
End Class
