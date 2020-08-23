<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGetAllTransactionsInDetail
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
        Me.txtAccountNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPayaneh = New System.Windows.Forms.TextBox
        Me.cmbTransactionState = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkList = New System.Windows.Forms.CheckedListBox
        Me.ucVisitor = New Visitor
        Me.ucManagement_Branch = New Management_Branch
        Me.rucDate = New ReportUserControl_DateInterval
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCnt = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccountNo.Location = New System.Drawing.Point(8, 25)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(137, 21)
        Me.txtAccountNo.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "شماره حساب :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 265)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(3, 17)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(950, 245)
        Me.dgv.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "پایانه :"
        '
        'txtPayaneh
        '
        Me.txtPayaneh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPayaneh.Location = New System.Drawing.Point(8, 51)
        Me.txtPayaneh.Name = "txtPayaneh"
        Me.txtPayaneh.Size = New System.Drawing.Size(137, 21)
        Me.txtPayaneh.TabIndex = 47
        '
        'cmbTransactionState
        '
        Me.cmbTransactionState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTransactionState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionState.FormattingEnabled = True
        Me.cmbTransactionState.Items.AddRange(New Object() {"همه", "موفق", "نا موفق"})
        Me.cmbTransactionState.Location = New System.Drawing.Point(231, 101)
        Me.cmbTransactionState.Name = "cmbTransactionState"
        Me.cmbTransactionState.Size = New System.Drawing.Size(157, 21)
        Me.cmbTransactionState.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(391, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "وضعیت تراکنش :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(391, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "نوع تراکنش :"
        '
        'ChkList
        '
        Me.ChkList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkList.FormattingEnabled = True
        Me.ChkList.Items.AddRange(New Object() {"شارژ", "خرید", "پرداخت قبض", "موجودی"})
        Me.ChkList.Location = New System.Drawing.Point(293, 29)
        Me.ChkList.Name = "ChkList"
        Me.ChkList.Size = New System.Drawing.Size(95, 68)
        Me.ChkList.TabIndex = 49
        '
        'ucVisitor
        '
        Me.ucVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucVisitor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucVisitor.Location = New System.Drawing.Point(487, 30)
        Me.ucVisitor.Name = "ucVisitor"
        Me.ucVisitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ucVisitor.Size = New System.Drawing.Size(235, 24)
        Me.ucVisitor.TabIndex = 43
        Me.ucVisitor.VisitorID = 0
        '
        'ucManagement_Branch
        '
        Me.ucManagement_Branch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucManagement_Branch.BranchID = ""
        Me.ucManagement_Branch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ucManagement_Branch.Location = New System.Drawing.Point(488, 56)
        Me.ucManagement_Branch.ManagementID = ""
        Me.ucManagement_Branch.Name = "ucManagement_Branch"
        Me.ucManagement_Branch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ucManagement_Branch.Size = New System.Drawing.Size(236, 67)
        Me.ucManagement_Branch.TabIndex = 42
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.GroupBoxText = ""
        Me.rucDate.Location = New System.Drawing.Point(736, 25)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(231, 103)
        Me.rucDate.TabIndex = 39
        '
        'ReportSearchToolStrip1
        '
        Me.ReportSearchToolStrip1.btnExportExcelVisible = True
        Me.ReportSearchToolStrip1.btnPrintVisible = False
        Me.ReportSearchToolStrip1.btnShowVisible = True
        Me.ReportSearchToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportSearchToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ReportSearchToolStrip1.Name = "ReportSearchToolStrip1"
        Me.ReportSearchToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(967, 24)
        Me.ReportSearchToolStrip1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCnt, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 396)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(967, 22)
        Me.StatusStrip1.TabIndex = 53
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusLabel1.Text = "تعداد کل :"
        '
        'lblCnt
        '
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(10, 17)
        Me.lblCnt.Text = " "
        '
        'slblRowsCount
        '
        Me.slblRowsCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblRowsCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.slblRowsCount.Name = "slblRowsCount"
        Me.slblRowsCount.Size = New System.Drawing.Size(0, 17)
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "پروژه"
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(8, 101)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(178, 21)
        Me.cmbProject.TabIndex = 54
        '
        'frmRptGetAllTransactionsInDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 418)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmbTransactionState)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChkList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPayaneh)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAccountNo)
        Me.Controls.Add(Me.ucVisitor)
        Me.Controls.Add(Me.ucManagement_Branch)
        Me.Controls.Add(Me.rucDate)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmRptGetAllTransactionsInDetail"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش ریز تراکنشها"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents ucManagement_Branch As Management_Branch
    Friend WithEvents ucVisitor As Visitor
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPayaneh As System.Windows.Forms.TextBox
    Friend WithEvents cmbTransactionState As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkList As System.Windows.Forms.CheckedListBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCnt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
End Class
