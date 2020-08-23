<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferContract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TransferPanel = New System.Windows.Forms.Panel()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.txtContract = New System.Windows.Forms.TextBox()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.LblContractID = New System.Windows.Forms.Label()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.TransferPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TransferPanel
        '
        Me.TransferPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TransferPanel.Controls.Add(Me.cmbProject)
        Me.TransferPanel.Controls.Add(Me.txtContract)
        Me.TransferPanel.Controls.Add(Me.lblProject)
        Me.TransferPanel.Controls.Add(Me.LblContractID)
        Me.TransferPanel.Location = New System.Drawing.Point(4, 3)
        Me.TransferPanel.Name = "TransferPanel"
        Me.TransferPanel.Size = New System.Drawing.Size(332, 78)
        Me.TransferPanel.TabIndex = 0
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(11, 41)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(242, 22)
        Me.cmbProject.TabIndex = 3
        '
        'txtContract
        '
        Me.txtContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContract.Location = New System.Drawing.Point(11, 13)
        Me.txtContract.Name = "txtContract"
        Me.txtContract.Size = New System.Drawing.Size(242, 22)
        Me.txtContract.TabIndex = 2
        '
        'lblProject
        '
        Me.lblProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(255, 49)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(52, 14)
        Me.lblProject.TabIndex = 1
        Me.lblProject.Text = "نام پروژه:"
        '
        'LblContractID
        '
        Me.LblContractID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblContractID.AutoSize = True
        Me.LblContractID.Location = New System.Drawing.Point(255, 16)
        Me.LblContractID.Name = "LblContractID"
        Me.LblContractID.Size = New System.Drawing.Size(60, 14)
        Me.LblContractID.TabIndex = 0
        Me.LblContractID.Text = "کد قرارداد:"
        '
        'OkButton
        '
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OkButton.Location = New System.Drawing.Point(83, 86)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 27)
        Me.OkButton.TabIndex = 9
        Me.OkButton.Text = "تایید"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelButton.Location = New System.Drawing.Point(4, 87)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 27)
        Me.CancelButton.TabIndex = 10
        Me.CancelButton.Text = "انصراف"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'frmTransferContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 122)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.TransferPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferContract"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "انتقال قرارداد"
        Me.TransferPanel.ResumeLayout(False)
        Me.TransferPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TransferPanel As System.Windows.Forms.Panel
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents LblContractID As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton As System.Windows.Forms.Button
End Class
