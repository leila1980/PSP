Public Class frmWarehouseStatementDetailsReport

    Private Property statementID As Integer

    Public Sub New(ByVal statementID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.statementID = statementID
    End Sub

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim warehouse As New ClassDALWarehouseStatement(modPublicMethod.ConnectionString)
        warehouse.BeginProc()
        Dim dt As DataTable = warehouse.GetStatement(Me.statementID)
        Me.ReportDataSet.WarehouseStatement.Merge(dt)

        dt = warehouse.GetStatementDetailSerials(Me.statementID)
        Me.ReportDataSet.WarehouseStatementDetailSerails.Merge(dt)
        warehouse.EndProc()

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class