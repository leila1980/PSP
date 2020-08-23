Public Class frmReprint
    Private clsDALCallCenterInfo As New ClassDALCallCenterInfo(modPublicMethod.ConnectionString)
    Private clsDALContract As New ClassDALContract(modPublicMethod.ConnectionString)

    Private CustomerName As String
    Private CardNo As String
    Private Tel As String
    Private MoghayeratAmount As String
    Private PosCode As String
    Private EniacCode As String
    Private StoreName As String
    Private CallID As String
    Private Amount As String
    Private TransactionDate As String
    Private StoreTel As String
    Private TransactionTime As String
    Private CallDate As String
    Private CallTime As String
    Private municipalareaNo As String
    Private CallerName As String
    Private StoreAddress As String
    Private RequestDesc As String
    Private FullName As String
    Dim dtCallsInfo As New DataTable
    Dim dtContract As New DataTable
    Private visitorname As String
    Private Description As String
    Dim Referto As Int32
    Public Enum FormtTypeEnum As Short
        Print = 1
        PDF = 2
    End Enum

    Public FormtType As FormtTypeEnum

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click, btnPDF.Click
        Try
            ErrorProvider.Clear()
            If txtCallID.Text.Trim = String.Empty Then
                ErrorProvider.SetError(txtCallID, "كد پيگيري را وارد نماييد")
                Exit Sub
            End If
            clsDALCallCenterInfo.BeginProc()
            clsDALContract.BeginProc()
            PrintRoutin(sender)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDALCallCenterInfo.EndProc()
            clsDALContract.EndProc()
        End Try
    End Sub
    Private Sub PrintRoutin(ByVal sender As Object)
        Try
            dtCallsInfo.Clear()
            CallID = Convert.ToInt64(txtCallID.Text)
            dtCallsInfo = clsDALCallCenterInfo.GetByCallIDCallsInfo(Convert.ToInt64(txtCallID.Text))
            If dtCallsInfo.Rows.Count > 0 Then
                Referto = dtCallsInfo.Rows(0).Item("ReferTo")
                Select Case Referto
                    Case 1 'fani

                        'Case 3 'bank
                        '    CustomerName = dtCallsInfo.Rows(0).Item("Moghayerat_CustomerName_nvc")
                        '    CardNo = dtCallsInfo.Rows(0).Item("Moghayerat_CardNo_vc")
                        '    Tel = dtCallsInfo.Rows(0).Item("Moghayerat_Tel_vc")
                        '    MoghayeratAmount = Convert.ToString(dtCallsInfo.Rows(0).Item("Moghayerat_Amount_num"))
                        '    Amount = Convert.ToString(dtCallsInfo.Rows(0).Item("Moghayerat_Amount2_num"))
                        '    TransactionDate = dtCallsInfo.Rows(0).Item("Moghayerat_TranDate_vc")
                        '    TransactionTime = dtCallsInfo.Rows(0).Item("Moghayerat_TranTime_vc")
                    Case Else
                        ErrorProvider.SetError(txtCallID, "كد پيگيري وارد شده جهت چاپ نامعتبر مي باشد")
                        Exit Sub
                End Select
                dtContract.Clear()
                dtContract = clsDALContract.GetByDDeviceid_ContractingParty_Contract_Account_Store_Device_Pos(dtCallsInfo.Rows(0).Item("DDeviceid"), ClassUserLoginDataAccess.ThisUser.ProjectID)
                If dtContract.Rows.Count > 0 Then
                    StoreName = dtContract.Rows(0).Item("SName_nvc")
                    StoreTel = dtContract.Rows(0).Item("STel1_vc")
                    municipalareaNo = Convert.ToString(dtContract.Rows(0).Item("SMunicipalAreaNO_sint"))
                    FullName = dtContract.Rows(0).Item("FirstName_nvc").ToString + " " + dtContract.Rows(0).Item("LastName_nvc").ToString
                    StoreAddress = IIf(dtContract.Rows(0).Item("SAddress_nvc").ToString = Nothing, String.Empty, dtContract.Rows(0).Item("SAddress_nvc"))
                    RequestDesc = dtCallsInfo.Rows(0).Item("RequestDesc")
                    'Reza Raeisi
                    CallDate = dtCallsInfo.Rows(0).Item("CallDate_vc")
                    CallTime = dtCallsInfo.Rows(0).Item("CallTime_vc")
                    Description = IIf(dtCallsInfo.Rows(0).Item("Description_nvc").ToString = Nothing, String.Empty, dtCallsInfo.Rows(0).Item("Description_nvc"))

                    '-------------------------------------------------
                    PosCode = dtCallsInfo.Rows(0).Item("DCode_vc")
                    EniacCode = dtCallsInfo.Rows(0).Item("EniacCode_vc")
                    visitorname = dtCallsInfo.Rows(0).Item("visitorname").ToString
                Else
                    ErrorProvider.SetError(txtCallID, "كد انياك به دست آمده در سيستم داراي اطلاعات معتبري نيست")
                    Exit Sub
                End If
            Else
                ErrorProvider.SetError(txtCallID, "كد پيگيري وارد شده جهت چاپ نامعتبر مي باشد")
                Exit Sub
            End If
            If DirectCast(sender, ToolStripButton).Name = "btnPrint" Then
                PrintForms()

            ElseIf DirectCast(sender, ToolStripButton).Name = "btnPDF" Then
                PDFForms()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrintForms()
        Try

            Dim sReportPath As String = ""
            Dim objReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Select Case Referto
                Case 1 '===fani
                    objReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptFani.rpt"
                    'sReportPath = "D:\Projects\ConnectToCallCenter\ConnectToCallCenter\Reports\rptFani.rpt"

                    objReport.FileName = sReportPath.Trim.ToString
                    'objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
                    objReport.SetParameterValue("@CallID", CallID)
                    objReport.SetParameterValue("@CallDate", CallDate)
                    objReport.SetParameterValue("@CallTime", CallTime)
                    objReport.SetParameterValue("@StoreName", StoreName)
                    objReport.SetParameterValue("@StoreTel", StoreTel)
                    objReport.SetParameterValue("@PosCode", PosCode)
                    objReport.SetParameterValue("@visitor", visitorname)

                    objReport.SetParameterValue("@MunicipalAreaNo", municipalareaNo)
                    objReport.SetParameterValue("@FullName", FullName)
                    objReport.SetParameterValue("@StoreAddress", StoreAddress)
                    objReport.SetParameterValue("@EniacCode", EniacCode)
                    objReport.SetParameterValue("@RequestDesc", RequestDesc)
                    objReport.SetParameterValue("@Description", Description)
                    frmViewr.CrystalReportViewer.ReportSource = objReport
                    frmViewr.ShowDialog()


                    'Case 3 '===bank
                    '    objReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    '    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptMoghyerat.rpt"
                    '    'sReportPath = "D:\Projects\ConnectToCallCenter\ConnectToCallCenter\Reports\rptMoghyerat.rpt"

                    '    objReport.FileName = sReportPath.Trim.ToString
                    '    'objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
                    '    objReport.SetParameterValue("@MoghayeratAmount", MoghayeratAmount)
                    '    objReport.SetParameterValue("@Customername", CustomerName)
                    '    objReport.SetParameterValue("@CardNo", CardNo)
                    '    objReport.SetParameterValue("@Tel", Tel)
                    '    objReport.SetParameterValue("@PosCode", PosCode)
                    '    objReport.SetParameterValue("@StoreName", StoreName)
                    '    objReport.SetParameterValue("@CallID", CallID)
                    '    objReport.SetParameterValue("@Amount", Amount)
                    '    objReport.SetParameterValue("@Date", GetDateNow)

                    '    If TransactionDate Is Nothing Then
                    '        objReport.SetParameterValue("@TransactionDate", "")
                    '    Else
                    '        objReport.SetParameterValue("@TransactionDate", TransactionDate)
                    '    End If
                    '    objReport.SetParameterValue("@StoreTel", StoreTel)
                    '    If TransactionTime Is Nothing Then
                    '        objReport.SetParameterValue("@TransactionTime", "")
                    '    Else
                    '        objReport.SetParameterValue("@TransactionTime", TransactionTime)
                    '    End If
                    '    frmViewr.CrystalReportViewer.ReportSource = objReport
                    '    frmViewr.ShowDialog()
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PDFForms()
        Try

            Dim sReportPath As String = ""
            Dim objReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Select Case Referto
                Case 1 '===fani
                    objReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptFani.rpt"
                    'sReportPath = "D:\Projects\ConnectToCallCenter\ConnectToCallCenter\Reports\rptFani.rpt"

                    objReport.FileName = sReportPath.Trim.ToString
                    'objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
                    objReport.SetParameterValue("@CallID", CallID)
                    objReport.SetParameterValue("@CallDate", CallDate)
                    objReport.SetParameterValue("@CallTime", CallTime)
                    objReport.SetParameterValue("@StoreName", StoreName)
                    objReport.SetParameterValue("@StoreTel", StoreTel)
                    objReport.SetParameterValue("@PosCode", PosCode)
                    objReport.SetParameterValue("@visitor", visitorname)

                    objReport.SetParameterValue("@MunicipalAreaNo", municipalareaNo)
                    objReport.SetParameterValue("@FullName", FullName)
                    objReport.SetParameterValue("@StoreAddress", StoreAddress)
                    objReport.SetParameterValue("@EniacCode", EniacCode)
                    objReport.SetParameterValue("@RequestDesc", RequestDesc)
                    objReport.SetParameterValue("@Description", Description)

                    Dim clsPDF As New ClassPDF
                    Dim pdfpath As String = PDFFilePath & "\HelpDesk"
                    Dim datetime As String = Replace(GetDateNow(), "/", "") & Replace(GetTimeNow, ":", "")
                    clsPDF.CreatePDF(pdfpath, "کارتابل فنی" & datetime, objReport)
            End Select
            ShowMessage(modApplicationMessage.msgSuccess)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FormtType = FormtTypeEnum.Print Then
            btnPrint.Visible = True
            btnPDF.Visible = False
        ElseIf FormtType = FormtTypeEnum.PDF Then
            btnPrint.Visible = False
            btnPDF.Visible = True

        End If
    End Sub
End Class