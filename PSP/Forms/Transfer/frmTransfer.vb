Imports System.Data
Imports Oracle.DataAccess.Client

Public Class frmTransfer
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Dim da As New RIZNARM.Data.Oracle_Client.DataAccess(modPublicMethod.ConnectionString)
        Dim cnn As New Oracle.DataAccess.Client.OracleConnection

        Try
            Application.DoEvents()

            If txtDate.Text.Length < 10 Then
                ShowErrorMessage("تاريخ به طور کامل وارد نشده است")
                txtDate.Focus()
                Exit Sub
            End If


            da.BeginProc()
            Dim rs As String = "GetForInsertingCallCenterDBTej_SP"
            Dim dt As New DataTable
            Dim parIns_date As New OracleParameter("@Ins_date", OracleDbType.Varchar2, 10)
            parIns_date.Value = txtDate.Value
            da.Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, rs, dt, parIns_date)

            cnn.ConnectionString = modPublicMethod.ConnectionString
            cnn.Open()
            Dim cmd As New Oracle.DataAccess.Client.OracleCommand

            prgbar.Maximum = dt.Rows.Count
            prgbar.Value = 0
            For i As Int32 = 0 To dt.Rows.Count - 1
                prgbar.Value = i + 1

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.CommandText = "InsertCallCenterDBTej_SP"

                cmd.Parameters.Clear()
                cmd.Parameters.Add("@st", OracleDbType.Varchar2, 9)
                cmd.Parameters.Item("@st").Value = dt.Rows(i).Item("OUTLET_vc")
                cmd.ExecuteNonQuery()

            Next
            MsgBox("عمليات با موفقيت انجام شد")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            da.EndProc()
            cnn.Close()
            Application.DoEvents()
        End Try



    End Sub
    Private Sub frmShowResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Dim _ConvertDate As New FarsiLibrary.Utils.PersianCalendar
            txtDate.Text = _ConvertDate.AddMonths(GetDateNow, -1).ToShortDateString()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    'Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

    '    Try
    '        Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    '        Dim cmd_AllChange As New Oracle.DataAccess.Client.OracleCommand
    '        Dim cmd_CallCenterIDs As New Oracle.DataAccess.Client.OracleCommand
    '        Dim cmd_Update As New Oracle.DataAccess.Client.OracleCommand

    '        Dim da_AllChange As New OracleDataAdapter
    '        Dim da_CallCenterIDs As New OracleDataAdapter
    '        Dim dtAllChange As New DataTable
    '        Dim dtCallCenterIDs As New DataTable
    '        'Dim dr As SqlClient.SqlDataReader


    '        Dim strSELECT As String
    '        Dim strWHERE As String


    '        With cnt
    '            .ConnectionString = modPublicMethod.ConnectionString
    '            .Open()
    '        End With
    '        With cmd_AllChange
    '            .Connection = cnt
    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = "GetAllChange_TheLatestInfo_SP"
    '        End With
    '        With da_AllChange
    '            .SelectCommand = cmd_AllChange
    '            dtAllChange.Clear()
    '            .Fill(dtAllChange)
    '        End With


    '        strSELECT = "Select C.CustomerID,S.StoreID,P.POSID From "
    '        strSELECT += " Openrowset('SQLOLEDB','Netsysserver';'sa';'sapass',CallCenter.dbo.Customers) C "
    '        strSELECT += "Inner join Openrowset('SQLOLEDB','Netsysserver';'sa';'sapass',CallCenter.dbo.Stores) S On C.CustomerID=S.CustomerID "
    '        strSELECT += "Inner Join Openrowset('SQLOLEDB','Netsysserver';'sa';'sapass',CallCenter.dbo.POS) P on P.StoreID=S.StoreID "

    '        prgbarUpdate.Value = 0
    '        prgbarUpdate.Maximum = dtAllChange.Rows.Count
    '        For i As Int32 = 0 To dtAllChange.Rows.Count - 1
    '            prgbarUpdate.Value = i
    '            strWHERE = " WHERE Pazirandeh='" & dtAllChange.Rows(i).Item("Outlet_vc") & "'"
    '            With cmd_CallCenterIDs
    '                .Connection = cnt
    '                .CommandType = CommandType.Text
    '                .CommandText = strSELECT & strWHERE
    '            End With
    '            With da_CallCenterIDs
    '                .SelectCommand = cmd_CallCenterIDs
    '                dtCallCenterIDs.Clear()
    '                .Fill(dtCallCenterIDs)
    '            End With

    '            For j As Int32 = 0 To dtCallCenterIDs.Rows.Count - 1

    '                With cmd_Update
    '                    .Connection = cnt
    '                    .CommandType = CommandType.StoredProcedure
    '                    .CommandText = "UpdateCllCenterDB_SP"
    '                    .Parameters.Clear()
    '                    .Parameters.Add("@StoreID", OracleDbType.Int32)
    '                    .Parameters.Item("@StoreID").Value = dtCallCenterIDs.Rows(j).Item("StoreID")
    '                    .Parameters.Add("@Email", OracleDbType.Varchar2, 100)
    '                    .Parameters.Item("@Email").Value = dtAllChange.Rows(i).Item("Email_nvc")
    '                    .Parameters.Add("@Name", OracleDbType.Varchar2, 100)
    '                    .Parameters.Item("@Name").Value = dtAllChange.Rows(i).Item("Name_nvc")
    '                    .Parameters.Add("@Address", OracleDbType.Varchar2, 1000)
    '                    .Parameters.Item("@Address").Value = dtAllChange.Rows(i).Item("Address_nvc")
    '                    .Parameters.Add("@PostCode", OracleDbType.Varchar2, 100)
    '                    .Parameters.Item("@PostCode").Value = dtAllChange.Rows(i).Item("PostCode_vc")
    '                    .Parameters.Add("@CityID", OracleDbType.Varchar2, 5)
    '                    .Parameters.Item("@CityID").Value = dtAllChange.Rows(i).Item("CityID")
    '                    .Parameters.Add("@Phone", OracleDbType.Varchar2, 100)
    '                    .Parameters.Item("@Phone").Value = dtAllChange.Rows(i).Item("Tel1_vc")
    '                    .Parameters.Add("@Fax", OracleDbType.Varchar2, 100)
    '                    .Parameters.Item("@Fax").Value = dtAllChange.Rows(i).Item("Fax_vc")
    '                    .Parameters.Add("@MunicipalAreaNO_sint", OracleDbType.Int16)
    '                    .Parameters.Item("@MunicipalAreaNO_sint").Value = dtAllChange.Rows(i).Item("MunicipalAreaNO_sint")

    '                    .ExecuteNonQuery()
    '                End With

    '            Next
    '        Next
    '        cmd_AllChange.Dispose()
    '        cmd_AllChange = Nothing
    '        cmd_CallCenterIDs.Dispose()
    '        cmd_CallCenterIDs = Nothing
    '        cmd_Update.Dispose()
    '        cmd_Update = Nothing

    '        cnt.Close()
    '        cnt.Dispose()
    '        cnt = Nothing

    '        MsgBox("عملیات با موفقیت انجام شد")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    '    Application.DoEvents()


    '    '    Dim da1 As New RIZNARM.Data.Oracle_Client.DataAccess(modPublicMethod.ConnectionString)
    '    '    Dim rdr1 As SqlClient.SqlDataReader

    '    '    da1.BeginProc()

    '    '    Dim rs As String = ""
    '    '    rs = " Select D.Outlet_vc,InsD.InstallingDetailId "
    '    '    rs += " From Device_T as D Inner Join InstallingDetail_T As InsD On D.DeviceId = InsD.DeviceId "
    '    '    rs += " Where Install_Ok = 1 "
    '    '    rs += " And D.Outlet_vc Not In(Select Distinct Pazirandeh From Openrowset ('SQLOLEDB','Netsysserver';'sa';'sapass',CallCenter.dbo.Customers))"

    '    '    Dim da As New RIZNARM.Data.Oracle_Client.DataAccess(modPublicMethod.ConnectionString)
    '    '    da.BeginProc()
    '    '    rdr1 = da1.Execute_Reader(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, rs)
    '    '    Dim cnn As New Oracle.DataAccess.Client.OracleConnection
    '    '    cnn.ConnectionString = modPublicMethod.ConnectionString
    '    '    cnn.Open()
    '    '    While rdr1.Read
    '    '        Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    '    '        cmd.CommandType = CommandType.StoredProcedure
    '    '        cmd.Connection = cnn
    '    '        cmd.CommandText = "InsertCallCenterDB_SP"

    '    '        cmd.Parameters.Clear()

    '    '        'Dim par As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
    '    '        'par.Value = rdr1("InstallingDetailID")
    '    '        cmd.Parameters.Add("@InstallingDetailID", OracleDbType.Int64)
    '    '        cmd.Parameters.Item("@InstallingDetailID").Value = rdr1("InstallingDetailID")
    '    '        cmd.Parameters.Add("@Ins_date", OracleDbType.Varchar2, 10)
    '    '        cmd.Parameters.Item("@Ins_date").Value = txtDate.Text

    '    '        cmd.ExecuteNonQuery()

    '    '        'da.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "InsertCallCenterDB_SP", par)
    '    '    End While
    '    '    cnn.Close()
    '    '    da.EndProc()
    '    '    rdr1.Close()
    '    '    da1.EndProc()
    '    '    MsgBox("عملیات با موفقیت انجام شد")
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'Finally
    '    '    '  PictureBox1.Enabled = False
    '    '    Application.DoEvents()
    '    'End Try
    'End Sub




    ''dar tejarat bahse installing detail ra nadashtim va baraye bazdideshan 1 bar kle SwitchterminalID hayee ke oon var narafte bood ra ferestadim ke beravad
    ''felan harzaman ke khstand baste be sharayeti ke bekhahan Khodeman yek enteghal anjam midahim,dar barname felan chizi nadarim
    'Try
    '    ' PictureBox1.Enabled = True
    '    Application.DoEvents()

    '    If txtDate.Text.Length < 10 Then
    '        ShowErrorMessage("تاریخ به طور کامل وارد نشده است")
    '        txtDate.Focus()
    '        Exit Sub
    '    End If

    '    Dim da1 As New RIZNARM.Data.Oracle_Client.DataAccess(modPublicMethod.ConnectionString)
    '    Dim rdr1 As SqlClient.SqlDataReader

    '    da1.BeginProc()

    '    Dim rs As String = ""
    '    'rs = "Select InstallingDetailID "
    '    'rs += "  From InstallingDetail_T "
    '    'rs += " Where Install_OK = 1 "

    '    ''rs = " Select D.Switch_TerminalID_vc,InsD.InstallingDetailId "
    '    ''rs += " From Device_T as D Inner Join InstallingDetail_T As InsD On D.DeviceId = InsD.DeviceId "
    '    ''rs += " Inner join Pos_T P on P.Posid=D.PosID  "
    '    ''rs += " Where Install_Ok = 1 "
    '    ''rs += " And D.Switch_TerminalID_vc Not In(Select Distinct Payaneh From Openrowset ('SQLOLEDB','dbserver1';'callcenter';'callcenter',CallCenter.dbo.Customers))"


    '    'rs = " Select D.Switch_TerminalID_vc "
    '    'rs += " From Device_T as D Inner Join Pos_T p  On D.posid = p.posid "
    '    'rs += " Where D.Switch_TerminalID_vc Not In(Select Distinct Payaneh From Openrowset ('SQLOLEDB','dbserver1';'callcenter';'callcenter',CallCenter.dbo.Customers))"

    '    Dim da As New RIZNARM.Data.Oracle_Client.DataAccess(modPublicMethod.ConnectionString)
    '    da.BeginProc()
    '    rdr1 = da1.Execute_Reader(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, rs)
    '    Dim cnn As New Oracle.DataAccess.Client.OracleConnection
    '    cnn.ConnectionString = modPublicMethod.ConnectionString
    '    cnn.Open()
    '    While rdr1.Read
    '        Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Connection = cnn
    '        cmd.CommandText = "InsertCallCenterDB_SP"

    '        cmd.Parameters.Clear()

    '        Dim par As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
    '        par.Value = rdr1("InstallingDetailID")
    '        cmd.Parameters.Add("@InstallingDetailID", OracleDbType.Int64)
    '        cmd.Parameters.Item("@InstallingDetailID").Value = rdr1("InstallingDetailID")
    '        cmd.Parameters.Add("@Ins_date", OracleDbType.Varchar2, 10)
    '        cmd.Parameters.Item("@Ins_date").Value = txtDate.Text

    '        'cmd.Parameters.Add("@st", OracleDbType.Varchar2, 8)
    '        'cmd.Parameters.Item("@st").Value = rdr1("Switch_TerminalID_vc")

    '        cmd.ExecuteNonQuery()

    '        'da.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "InsertCallCenterDB_SP", par)
    '    End While
    '    cnn.Close()
    '    da.EndProc()
    '    rdr1.Close()
    '    da1.EndProc()
    '    MsgBox("عملیات با موفقیت انجام شد")
    'Catch ex As Exception
    '    MsgBox(ex.Message)
    'Finally
    '    '  PictureBox1.Enabled = False
    '    Application.DoEvents()
    'End Try


End Class
