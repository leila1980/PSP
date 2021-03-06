Imports Oracle.DataAccess.Client

Public Class ClassDalPAcking
    Inherits RIZNARM.Data.Oracle_Client.DataAccess

    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
        'MyBase.New("Data Source=software;Initial Catalog=PSPwarehouse;User Id=sa;Password=sa123;timeout=60;")

    End Sub
    Public Function Fill_DsProduceCode()
        Try
            Dim Ds As New DataSet
            Dim StrSQL As String = "Select * from Pos_T"
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, Ds, "Pos_T")
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()

        End Try
    End Function
    Public Function Fill_DtAfterProduceCode(ByVal EniacValue As String)
        Try
            Dim dt As New DataTable
            Dim StrSQL As String = "SELECT * FROM Pos_T WHERE  CAST(EniacCode_vc AS bigINT)>=" + EniacValue + _
            "ORDER BY CAST(EniacCode_vc AS bigINT)"
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, dt)
            'Me.EndProc()
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()

        End Try
    End Function
    Public Function Fill_DsPacking()
        Try
            Dim Ds As New DataSet
            Dim StrSQL As String = "Select * from Pos_T"
            Dim StrSQLProject As String = "Select * from PosModel_T"
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, Ds, "Pos_T")
            Me.Fill(CommandType.Text, StrSQLProject, Ds, "PosModel_T")
            'Me.EndProc()
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()

        End Try
    End Function
    Public Function GetProductModel() As DataTable
        Try
            Dim Dt As New DataTable
            Dim StrSQLProject As String = "Select * from PosModel_T"
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQLProject, Dt)
            'Me.EndProc()
            Return Dt
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()

        End Try
    End Function
    Public Function GetPackingForSendPosInfo(ByVal ProjectID As String, ByVal BatchNo As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim StrSQL As String = "SELECT * from Packing_T where ProjectID=@ProjectID and BatchNo_int=@BatchNo_int"
            Dim parProjectID As New OracleParameter("ProjectID", OracleDbType.Varchar2)
            parProjectID.Value = ProjectID
            Dim parBatchNo As New OracleParameter("BatchNo_int", OracleDbType.Int32)
            parBatchNo.Value = BatchNo
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, StrSQL, dt, parProjectID, parBatchNo)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetPackingForViewPosInfo(ByVal BatchNo As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim StrSQL As String = "SELECT *, dbo.PosModel_T.Name_nvc AS ProductModel" + _
                    " FROM  dbo.Pos_T LEFT OUTER JOIN" + _
                    " dbo.PosModel_T ON dbo.Pos_T.PosModelID = dbo.PosModel_T.PosModelID" + _
                    " where  BatchNo_int=@BatchNo_int"
            Dim parBatchNo As New OracleParameter("BatchNo_int", OracleDbType.Int32)
            parBatchNo.Value = BatchNo
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, StrSQL, dt, parBatchNo)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMaxCode(ByVal CodeColumn As String) As String
        Dim MaxValue As String = "1"
        Try

            Me.BeginProc()
            MaxValue = Me.Execute_Scalar(CommandType.Text, "exec SP_GetMaxValueProduceAndPack '" + CodeColumn + "'", 1)


        Catch ex As Exception
            MsgBox(ex.Message)
            MaxValue = "1"
        Finally
            Me.EndProc()
        End Try
        Return MaxValue

    End Function
    Public Function GetMaxProprty() As String
        Dim MaxValue As String = "1"
        Try

            Me.BeginProc()
            MaxValue = Me.Execute_Scalar(CommandType.Text, "exec SP_GetMaxProprty ", 1)


        Catch ex As Exception
            MsgBox(ex.Message)
            MaxValue = "1"
        Finally
            Me.EndProc()
        End Try
        Return MaxValue

    End Function

    Public Sub InsertIntoPos_T(ByVal EniacCode As Object, ByVal TempPropertyNo As Object)
        Try

            Dim prmEniacCode As New OracleParameter("@EniacCode_vc", OracleDbType.Varchar2)
            prmEniacCode.Value = EniacCode

            Dim prmTempPropertyNo As New OracleParameter("@TempPropertyNo_vc", OracleDbType.Varchar2)
            prmTempPropertyNo.Value = TempPropertyNo

            Dim prmSaveDate_vc As New OracleParameter("@SaveDate_vc", OracleDbType.Varchar2, 10)
            prmSaveDate_vc.Value = GetDateNow()

            Dim prmSaveUserID As New OracleParameter("@SaveUserID", OracleDbType.Int64)
            prmSaveUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID


            Dim strSQL As String = "INSERT INTO Pos_T (EniacCode_vc,TempPropertyNo_vc,SaveUserID,SaveDate_vc) VALUES(@EniacCode_vc,@TempPropertyNo_vc,@SaveUserID,@SaveDate_vc)"
            BeginProc()
            Execute_NonQuery(CommandType.Text, strSQL, prmEniacCode, prmTempPropertyNo, prmSaveUserID, prmSaveDate_vc)
        Catch ex As Exception
            MsgBox("کد های وارد شده تکراریست")
            'Throw ex
        Finally
            EndProc()

        End Try
    End Sub
    Public Sub UpdatePackingTBySomefields(ByVal EniacCode As String, ByVal Serial_vc As String, ByVal PM_vc As String, ByVal PN_vc As String, ByVal Date_nvc As String, ByVal PartNo_int As String)
        Try

            BeginProc()
            'Execute_NonQuery(CommandType.Text, "Packing_Update", prmSerial_vc, prmPropertyNo_vc, prmEniacCode, prmPM_vc, prmPN_vc, prmBatchNo_int)
            Execute_NonQuery(CommandType.Text, "exec Packing_UpdateBySomefields '" + EniacCode + "','" + Serial_vc + "'," + PM_vc + ",'" + PN_vc + "','" + Date_nvc + "'," + PartNo_int)
            'EndProc()
        Catch ex As Exception
            MsgBox("کد های وارد شده تکراریست")
            'Throw ex
        Finally
            EndProc()
        End Try
    End Sub
    Public Sub UpdatePackingT(ByVal EniacCode As String, ByVal PropertyNo As String, ByVal Serial_vc As String, ByVal PM_vc As String, ByVal PN_vc As String, ByVal BatchNo_int As Int32, ByVal Date_nvc As String, ByVal PartNo_int As String)
        Try


            BeginProc()
            Execute_NonQuery(CommandType.Text, "exec Pos_Update '" & Serial_vc & "','" & PropertyNo & "','" & EniacCode & "'," & PM_vc & ",'" & PN_vc & "'," & BatchNo_int.ToString & ",'" & Date_nvc & "'," & PartNo_int & "," & ClassUserLoginDataAccess.ThisUser.UserID & ",1")
        Catch ex As Exception
            MsgBox(ex.Message)
            'Throw ex
        Finally
            EndProc()
        End Try
    End Sub
    Public Function IsNotValueInPacking(ByVal ColumnName As String, ByVal Value As String) As Boolean
        Dim ctrl As Boolean = False
        Try
            BeginProc()
            Dim count As Int64 = Execute_Scalar(CommandType.Text, "exec SP_IsValueInPacking '" + ColumnName + "','" + Value + "'", 0)

            If count <= 0 Then ctrl = True
            Return ctrl
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()

        End Try
    End Function
    Public Function IsNotSerialInPacking(ByVal Value As String) As Boolean
        Dim ctrl As Boolean = False
        Try
            BeginProc()
            Dim count As Int64 = Execute_Scalar(CommandType.Text, "Select Count(Serial_vc) from dbo.Pos_T where Serial_vc='" + Value + "'", 0)

            If count <= 0 Then ctrl = True
            Return ctrl
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()

        End Try
    End Function

    Public Function IsPacking(ByVal Value As String) As Boolean
        Dim ctrl As Boolean = False
        Try
            BeginProc()
            Dim count As Int32 = Execute_Scalar(CommandType.Text, "exec SP_GetPropertyNoInPacking '" + Value + "'", -1000)
            'EndProc()
            If count <> -1000 And count > 0 Then ctrl = True
            Return ctrl
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()
        End Try

    End Function
    Public Function IsPackingByProjectID(ByVal EniacValue As String, ByVal ProjectID As String) As Boolean
        Dim ctrl As Boolean = False
        Try
            BeginProc()
            Dim count As Int32 = CType(Execute_Scalar(CommandType.Text, "exec SP_GetPropertyNoInPackingByProjectID '" + EniacValue + "','" + ProjectID + "'", -1000), Int32)
            'EndProc()
            If count <> -1000 And count > 0 Then ctrl = True
            Return ctrl
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()
        End Try
        Return ctrl
    End Function
    Public Function IsExistCodeInPacking(ByVal ColumnName As String, ByVal Value As String) As Boolean
        Dim ctrl As Boolean = False
        Try
            BeginProc()
            Dim count As Int32 = Execute_Scalar(CommandType.Text, "exec CheckCodeInPacking '" + ColumnName + "','" + Value + "'", 0)
            'EndProc()
            If count > 0 Then ctrl = True
            Return ctrl
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()
        End Try

    End Function
    Public Function GetProject(ByVal Value As String)
        Dim ProjectName As Object
        Try
            Dim Dr As OracleDataReader


            Dim PrmValue As New OracleParameter("@EniacCode_vc", OracleDbType.Varchar2)
            PrmValue.Value = Value
            BeginProc()
            Dr = Execute_Reader(CommandType.Text, "GetProjectNameForPacking '" + Value + "'")
            While Dr.Read
                ProjectName = Dr.GetValue(0).ToString
            End While
            Dr.Close()
            'EndProc()
            'If count <> -1000 And count > 0 Then ctrl = True
            Return ProjectName
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            EndProc()
        End Try

    End Function
    Public Function Fill_DsPrintCode()
        Try
            Dim Ds As New DataSet
            Dim StrSQL As String = "Select * from Pos_T "
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, Ds, "Pos_T")
            'Me.EndProc()
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Function
    Public Function Fill_DsPrintCode(ByVal BatchNo As String)
        Try
            Dim Ds As New DataSet
            Dim StrSQL As String = "Select EniacCode_vc,TempPropertyNo_vc from Pos_T where BatchNo_int=" + BatchNo
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, Ds, "Pos_T")
            'Me.EndProc()
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Function
    Public Function Fill_DsPrintCode(ByVal ByEniacCode As Boolean, ByVal ByPropertyCode As Boolean, ByVal FromEniacCode As String _
    , ByVal ToEniacCode As String, ByVal FromPropertyCode As String, ByVal ToPropertyCode As String)
        Try
            Dim Ds As New DataSet
            Dim StrSQL As String
            If ByEniacCode And ByPropertyCode Then
                StrSQL = "Select EniacCode_vc,TempPropertyNo_vc from Pos_T where EniacCode_vc>=" + FromEniacCode + " And EniacCode_vc<=" _
                + ToEniacCode + " And TempPropertyNo_vc>=" + FromPropertyCode + _
                " And TempPropertyNo_vc<=" + ToPropertyCode
            ElseIf ByEniacCode Then
                StrSQL = "Select EniacCode_vc from Pos_T where EniacCode_vc>=" + FromEniacCode + " And EniacCode_vc<=" _
                + ToEniacCode
            ElseIf ByPropertyCode Then
                StrSQL = "Select TempPropertyNo_vc from Pos_T where TempPropertyNo_vc>=" + FromPropertyCode + _
                " And TempPropertyNo_vc<=" + ToPropertyCode

            End If
            'Dim StrSQL As String = "Select * from Packing_T where BatchNo_int=" + BatchNo
            Me.BeginProc()
            Me.Fill(CommandType.Text, StrSQL, Ds, "Pos_T")
            'Me.EndProc()
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Function
    Public Sub PrintMyReport(ByVal SelectionFormula As String, ByVal ReportName As String, ByVal PrinterName As String, ByVal nCopy As Int16, ByVal M_Ds As DataSet)
        Try
            Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rpt.Load(Application.StartupPath & "\Reports\" + ReportName, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            rpt.SetDataSource(M_Ds)
            rpt.RecordSelectionFormula = SelectionFormula
            rpt.PrintOptions.PrinterName = PrinterName
            rpt.PrintToPrinter(nCopy, False, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function InsertIntoMaskanPrj(ByVal BatchNo_int As String, ByVal ProjectID As String) As Boolean

        Dim Result As Boolean = True
        Dim Cnn As New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
        Try
            Dim Cmd As New Oracle.DataAccess.Client.OracleCommand
            With Cmd
                .Connection = Cnn
                .CommandType = Data.CommandType.StoredProcedure
                .CommandText = "SentToPSPMaskanBank"
                With .Parameters
                    .Add("@ProjectID", OracleDbType.Varchar2)
                    .Add("@BatchNo_int", OracleDbType.Int32)
                    .Add("@SentDate_nvc", OracleDbType.Varchar2)
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@BatchNo_int").Value = BatchNo_int
                    .Item("@SentDate_nvc").Value = GetDateNow()
                End With
                Cnn.Open()
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Result = False
            If ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.Pos_T' with unique index 'Serial_ind'.") Then
                ShowErrorMessage("بدلیل وجود مقادیر تکراری در سریال عملیات ارسال انجام نشد")
            Else
                ShowErrorMessage(ex.Message)
            End If
        Finally
            Cnn.Close()
        End Try
        Return Result
    End Function
    Public Function InsertIntoTejaratPrj(ByVal BatchNo_int As String, ByVal ProjectID As String) As Boolean
        Dim Result As Boolean = True
        Dim Cnn As New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
        Try
            Dim Cmd As New Oracle.DataAccess.Client.OracleCommand
            With Cmd
                .Connection = Cnn
                .CommandType = Data.CommandType.StoredProcedure
                .CommandText = "SentToPSPTejarat"
                With .Parameters
                    .Add("@ProjectID", OracleDbType.Varchar2)
                    .Add("@BatchNo_int", OracleDbType.Int32)
                    .Add("@SentDate_nvc", OracleDbType.Varchar2)
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@BatchNo_int").Value = BatchNo_int
                    .Item("@SentDate_nvc").Value = GetDateNow()

                End With
                Cnn.Open()
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Result = False
            If ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.Pos_T' with unique index 'Serial_ind'.") Then
                ShowErrorMessage("بدلیل وجود مقادیر تکراری در سریال عملیات ارسال انجام نشد")
            Else
                ShowErrorMessage(ex.Message)
            End If
        Finally
            Cnn.Close()
        End Try
        Return Result
    End Function

    Public Function InsertIntoKeshavarziPrj(ByVal BatchNo_int As String, ByVal ProjectID As String) As Boolean
        Dim Result As Boolean = True
        Dim Cnn As New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
        Try
            Dim Cmd As New Oracle.DataAccess.Client.OracleCommand
            With Cmd
                .Connection = Cnn
                .CommandType = Data.CommandType.StoredProcedure
                .CommandText = "SentToPSPKeshavarziBank_Bank"
                .CommandTimeout = 0
                With .Parameters
                    .Add("@ProjectID", OracleDbType.Varchar2)
                    .Add("@BatchNo_int", OracleDbType.Int32)
                    .Add("@SentDate_nvc", OracleDbType.Varchar2)
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@BatchNo_int").Value = BatchNo_int
                    .Item("@SentDate_nvc").Value = GetDateNow()

                End With
                Cnn.Open()
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Result = False
            If ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.Pos_T' with unique index 'Serial_ind'.") Then
                ShowErrorMessage("بدلیل وجود مقادیر تکراری در سریال عملیات ارسال انجام نشد")
            Else
                ShowErrorMessage(ex.Message)
            End If
        Finally
            Cnn.Close()
        End Try
        Return Result
    End Function
End Class
