<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MyReprint
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MyReprint))
        Me.Rdo_Batch = New System.Windows.Forms.RadioButton()
        Me.Rdo_Code = New System.Windows.Forms.RadioButton()
        Me.Txt_BatchNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_FromEniacCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_ToEniacCode = New System.Windows.Forms.TextBox()
        Me.Pnl_Eniac = New System.Windows.Forms.Panel()
        Me.Pnl_Property = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_FromPropertyCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_ToPropertyCode = New System.Windows.Forms.TextBox()
        Me.Pnl_Batch = New System.Windows.Forms.Panel()
        Me.Btn_Reprint = New System.Windows.Forms.Button()
        Me.Btn_ExportToExcel = New System.Windows.Forms.Button()
        Me.Chk_PropertyCode = New System.Windows.Forms.CheckBox()
        Me.Chk_EniacCode = New System.Windows.Forms.CheckBox()
        Me.Pnl_Code = New System.Windows.Forms.Panel()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Pnl_Eniac.SuspendLayout()
        Me.Pnl_Property.SuspendLayout()
        Me.Pnl_Batch.SuspendLayout()
        Me.Pnl_Code.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rdo_Batch
        '
        Me.Rdo_Batch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo_Batch.AutoSize = True
        Me.Rdo_Batch.Location = New System.Drawing.Point(30, 16)
        Me.Rdo_Batch.Name = "Rdo_Batch"
        Me.Rdo_Batch.Size = New System.Drawing.Size(82, 18)
        Me.Rdo_Batch.TabIndex = 0
        Me.Rdo_Batch.Text = "براساس بچ"
        Me.Rdo_Batch.UseVisualStyleBackColor = True
        '
        'Rdo_Code
        '
        Me.Rdo_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo_Code.AutoSize = True
        Me.Rdo_Code.Location = New System.Drawing.Point(30, 81)
        Me.Rdo_Code.Name = "Rdo_Code"
        Me.Rdo_Code.Size = New System.Drawing.Size(84, 18)
        Me.Rdo_Code.TabIndex = 1
        Me.Rdo_Code.Text = "براساس کد"
        Me.Rdo_Code.UseVisualStyleBackColor = True
        '
        'Txt_BatchNo
        '
        Me.Txt_BatchNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_BatchNo.Location = New System.Drawing.Point(241, 3)
        Me.Txt_BatchNo.Name = "Txt_BatchNo"
        Me.Txt_BatchNo.Size = New System.Drawing.Size(127, 22)
        Me.Txt_BatchNo.TabIndex = 2
        Me.Txt_BatchNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(371, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "شماره بچ"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "از"
        '
        'Txt_FromEniacCode
        '
        Me.Txt_FromEniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_FromEniacCode.Location = New System.Drawing.Point(203, 5)
        Me.Txt_FromEniacCode.Name = "Txt_FromEniacCode"
        Me.Txt_FromEniacCode.Size = New System.Drawing.Size(128, 22)
        Me.Txt_FromEniacCode.TabIndex = 4
        Me.Txt_FromEniacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "تا"
        '
        'Txt_ToEniacCode
        '
        Me.Txt_ToEniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_ToEniacCode.Location = New System.Drawing.Point(25, 5)
        Me.Txt_ToEniacCode.Name = "Txt_ToEniacCode"
        Me.Txt_ToEniacCode.Size = New System.Drawing.Size(127, 22)
        Me.Txt_ToEniacCode.TabIndex = 6
        Me.Txt_ToEniacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pnl_Eniac
        '
        Me.Pnl_Eniac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Eniac.Controls.Add(Me.Txt_FromEniacCode)
        Me.Pnl_Eniac.Controls.Add(Me.Label2)
        Me.Pnl_Eniac.Controls.Add(Me.Txt_ToEniacCode)
        Me.Pnl_Eniac.Controls.Add(Me.Label3)
        Me.Pnl_Eniac.Enabled = False
        Me.Pnl_Eniac.Location = New System.Drawing.Point(6, 3)
        Me.Pnl_Eniac.Name = "Pnl_Eniac"
        Me.Pnl_Eniac.Size = New System.Drawing.Size(353, 30)
        Me.Pnl_Eniac.TabIndex = 14
        '
        'Pnl_Property
        '
        Me.Pnl_Property.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Property.Controls.Add(Me.Label5)
        Me.Pnl_Property.Controls.Add(Me.Txt_FromPropertyCode)
        Me.Pnl_Property.Controls.Add(Me.Label4)
        Me.Pnl_Property.Controls.Add(Me.Txt_ToPropertyCode)
        Me.Pnl_Property.Enabled = False
        Me.Pnl_Property.Location = New System.Drawing.Point(6, 35)
        Me.Pnl_Property.Name = "Pnl_Property"
        Me.Pnl_Property.Size = New System.Drawing.Size(353, 30)
        Me.Pnl_Property.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "تا"
        '
        'Txt_FromPropertyCode
        '
        Me.Txt_FromPropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_FromPropertyCode.Location = New System.Drawing.Point(203, 5)
        Me.Txt_FromPropertyCode.Name = "Txt_FromPropertyCode"
        Me.Txt_FromPropertyCode.Size = New System.Drawing.Size(128, 22)
        Me.Txt_FromPropertyCode.TabIndex = 4
        Me.Txt_FromPropertyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(334, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "از"
        '
        'Txt_ToPropertyCode
        '
        Me.Txt_ToPropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_ToPropertyCode.Location = New System.Drawing.Point(25, 4)
        Me.Txt_ToPropertyCode.Name = "Txt_ToPropertyCode"
        Me.Txt_ToPropertyCode.Size = New System.Drawing.Size(127, 22)
        Me.Txt_ToPropertyCode.TabIndex = 6
        Me.Txt_ToPropertyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pnl_Batch
        '
        Me.Pnl_Batch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Batch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Batch.Controls.Add(Me.Txt_BatchNo)
        Me.Pnl_Batch.Controls.Add(Me.Label1)
        Me.Pnl_Batch.Enabled = False
        Me.Pnl_Batch.Location = New System.Drawing.Point(30, 40)
        Me.Pnl_Batch.Name = "Pnl_Batch"
        Me.Pnl_Batch.Size = New System.Drawing.Size(438, 35)
        Me.Pnl_Batch.TabIndex = 16
        '
        'Btn_Reprint
        '
        Me.Btn_Reprint.Image = CType(resources.GetObject("Btn_Reprint.Image"), System.Drawing.Image)
        Me.Btn_Reprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Reprint.Location = New System.Drawing.Point(231, 188)
        Me.Btn_Reprint.Name = "Btn_Reprint"
        Me.Btn_Reprint.Size = New System.Drawing.Size(117, 27)
        Me.Btn_Reprint.TabIndex = 17
        Me.Btn_Reprint.Text = "چـــاپ مجـــدد"
        Me.Btn_Reprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Reprint.UseVisualStyleBackColor = True
        '
        'Btn_ExportToExcel
        '
        Me.Btn_ExportToExcel.Image = CType(resources.GetObject("Btn_ExportToExcel.Image"), System.Drawing.Image)
        Me.Btn_ExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_ExportToExcel.Location = New System.Drawing.Point(351, 188)
        Me.Btn_ExportToExcel.Name = "Btn_ExportToExcel"
        Me.Btn_ExportToExcel.Size = New System.Drawing.Size(117, 27)
        Me.Btn_ExportToExcel.TabIndex = 18
        Me.Btn_ExportToExcel.Text = "Export To Excel"
        Me.Btn_ExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_ExportToExcel.UseVisualStyleBackColor = True
        '
        'Chk_PropertyCode
        '
        Me.Chk_PropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chk_PropertyCode.AutoSize = True
        Me.Chk_PropertyCode.Location = New System.Drawing.Point(359, 42)
        Me.Chk_PropertyCode.Name = "Chk_PropertyCode"
        Me.Chk_PropertyCode.Size = New System.Drawing.Size(68, 18)
        Me.Chk_PropertyCode.TabIndex = 13
        Me.Chk_PropertyCode.Text = "کد اموال"
        Me.Chk_PropertyCode.UseVisualStyleBackColor = True
        '
        'Chk_EniacCode
        '
        Me.Chk_EniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chk_EniacCode.AutoSize = True
        Me.Chk_EniacCode.Location = New System.Drawing.Point(352, 11)
        Me.Chk_EniacCode.Name = "Chk_EniacCode"
        Me.Chk_EniacCode.Size = New System.Drawing.Size(75, 18)
        Me.Chk_EniacCode.TabIndex = 12
        Me.Chk_EniacCode.Text = "کد پیگیری"
        Me.Chk_EniacCode.UseVisualStyleBackColor = True
        '
        'Pnl_Code
        '
        Me.Pnl_Code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Code.Controls.Add(Me.Chk_PropertyCode)
        Me.Pnl_Code.Controls.Add(Me.Chk_EniacCode)
        Me.Pnl_Code.Controls.Add(Me.Pnl_Eniac)
        Me.Pnl_Code.Controls.Add(Me.Pnl_Property)
        Me.Pnl_Code.Enabled = False
        Me.Pnl_Code.Location = New System.Drawing.Point(30, 103)
        Me.Pnl_Code.Name = "Pnl_Code"
        Me.Pnl_Code.Size = New System.Drawing.Size(438, 71)
        Me.Pnl_Code.TabIndex = 19
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Frm_MyReprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 227)
        Me.Controls.Add(Me.Pnl_Code)
        Me.Controls.Add(Me.Btn_ExportToExcel)
        Me.Controls.Add(Me.Btn_Reprint)
        Me.Controls.Add(Me.Pnl_Batch)
        Me.Controls.Add(Me.Rdo_Code)
        Me.Controls.Add(Me.Rdo_Batch)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MyReprint"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "چاپ مجدد برچسب"
        Me.Pnl_Eniac.ResumeLayout(False)
        Me.Pnl_Eniac.PerformLayout()
        Me.Pnl_Property.ResumeLayout(False)
        Me.Pnl_Property.PerformLayout()
        Me.Pnl_Batch.ResumeLayout(False)
        Me.Pnl_Batch.PerformLayout()
        Me.Pnl_Code.ResumeLayout(False)
        Me.Pnl_Code.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Rdo_Batch As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_Code As System.Windows.Forms.RadioButton
    Friend WithEvents Txt_BatchNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_FromEniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_ToEniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Eniac As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Property As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_FromPropertyCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_ToPropertyCode As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Batch As System.Windows.Forms.Panel
    Friend WithEvents Btn_Reprint As System.Windows.Forms.Button
    Friend WithEvents Btn_ExportToExcel As System.Windows.Forms.Button
    Friend WithEvents Chk_PropertyCode As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_EniacCode As System.Windows.Forms.CheckBox
    Friend WithEvents Pnl_Code As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class


   
