Imports Oracle.DataAccess.Client

Public Class frmTMSSendToOld
    Dim clsDalTMS As New ClassDALTMS()
    Dim clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Dim dtPos As New DataTable

    Private Sub btnMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeFile.Click
        Dim trn As OracleTransaction
        Try
            clsDalTMS.OpenConnection()
            trn = clsDalTMS.cnt.BeginTransaction()
            clsDalTMS.cmd.Transaction = trn
            MakeFile()
            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            ShowErrorMessage(ex.Message)
        Finally
            clsDalTMS.CloseConnection()
        End Try
    End Sub
    Private Sub MakeFile()
        Try
            Dim dtNotSentTMS As New DataTable
            Dim dtTMS As New DataTable
            Dim dtTMSTerminal_MAXTerminalID As New DataTable
            Dim dtTMSTerminal_GetByCityID As New DataTable
            Dim Arr()
            Dim EniacCode As String
            Dim Serial As String
            Dim ProductNo As String
            Dim CityID As String
            Dim TMSID As Int64
            Dim Status As String

            dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("P")
            Dim dtNotSentTMSExcel As New DataTable
            CreateDatatable(dtNotSentTMSExcel)
            For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
                Status = dtNotSentTMS.Rows(i).Item("Status_vc")
                If Status = "assign" Then
                    Application.DoEvents()
                    TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
                    Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
                    EniacCode = Arr(0)
                    Serial = Arr(1)
                    ProductNo = Arr(2)
                    CityID = Arr(3)
                    If IsCastles(Serial) Then
                        AddToDataTable(dtNotSentTMSExcel, CityID, EniacCode, Serial)
                        clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID)

                    End If
                End If
            Next

            ExportToExcel(dtNotSentTMSExcel)
            If dtNotSentTMSExcel.Rows.Count > 0 Then
                ShowMessage(modApplicationMessage.msgSuccess)
            Else
                ShowErrorMessage("موردی برای ارسال یافت نشد")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function IsCastles(ByVal Serial As String) As Boolean
        Try
            dtPos.Clear()

            clsDalPos.Serial_vc = Serial
            dtPos = clsDalPos.GetBySerialPos()
            If dtPos.Rows.Count > 0 Then
                If modPublicMethod.GetPosModel(dtPos.Rows(0).Item("PosModelID")) = "Castles" Then
                    IsCastles = True
                Else
                    IsCastles = False
                End If
            Else
                IsCastles = False
            End If
        Catch ex As Exception
            IsCastles = False
            Throw ex
        End Try
    End Function
    Private Sub CreateDatatable(ByRef dtNotSentTMSExcel As DataTable)
        Try
            dtNotSentTMSExcel.Columns.Add("CityID")
            dtNotSentTMSExcel.Columns.Add("EniacCode_vc")
            dtNotSentTMSExcel.Columns.Add("Serial_vc")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AddToDataTable(ByRef dtNotSentTMSExcel As DataTable, ByVal CityID As String, ByVal EniacCode As String, ByVal Serial As String)
        Try
            Dim dr As Data.DataRow
            dr = dtNotSentTMSExcel.NewRow()
            dr.Item("CityID") = CityID
            dr.Item("EniacCode_vc") = EniacCode
            dr.Item("Serial_vc") = Serial

            dtNotSentTMSExcel.Rows.Add(dr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ExportToExcel(ByVal dtNotSentTMSExcel As DataTable)
        Try
            Me.dgvNotSentTMS.DataSource = dtNotSentTMSExcel
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvNotSentTMS)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub StateUpdate()
    '    Try
    '        Dim dtNotSentTMS As New DataTable
    '        Dim dtTMS As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim Arr()
    '        Dim StateID As String
    '        Dim StateName As String
    '        Dim TMSID As Int64
    '        Dim MaxTerminalID As String
    '        dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("S")
    '        For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
    '            TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
    '            Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
    '            StateID = Arr(0)
    '            StateName = Arr(1)
    '            dtTMS = clsDalTMS.ForTMS_TMSTerminal_GetByStateID(StateID)
    '            If dtTMS.Rows.Count = 0 Then
    '                dtTMSTerminal_MAXTerminalID = clsDalTMS.ForTMS_TMSTerminal_MAXTerminalID()
    '                MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '                clsDalTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '                clsDalTMS.SIGNATURE = StateID
    '                clsDalTMS.NAME = StateName
    '                clsDalTMS.TYPE = vbCrLf
    '                clsDalTMS.STATUS = 0
    '                clsDalTMS.CATEGORY = 0
    '                clsDalTMS.DESCRIPTION = String.Empty
    '                clsDalTMS.REGISTRATION_DATE = Date.Now

    '                clsDalTMS.ForTMS_TMSTerminal_Insert1() 'warnning:has Transaction Problem
    '                clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID) 'warnning:has Transaction Problem
    '            Else
    '                'Nothing
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub CityUpdate()
    '    Try
    '        Dim dtNotSentTMS As New DataTable
    '        Dim dtTMS As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim dtTMSTerminal_GetByStateID As New DataTable
    '        Dim Arr()
    '        Dim CityID As String
    '        Dim CityName As String
    '        Dim StateID As String
    '        Dim TMSID As Int64
    '        Dim MaxTerminalID As String

    '        dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("C")
    '        For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
    '            TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
    '            Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
    '            CityID = Arr(0)
    '            CityName = Arr(1)
    '            StateID = Arr(2)
    '            dtTMS = clsDalTMS.ForTMS_TMSTerminal_GetByCityID(CityID)
    '            If dtTMS.Rows.Count = 0 Then
    '                dtTMSTerminal_MAXTerminalID = clsDalTMS.ForTMS_TMSTerminal_MAXTerminalID()
    '                MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '                dtTMSTerminal_GetByStateID = clsDalTMS.ForTMS_TMSTerminal_GetByStateID(StateID)
    '                clsDalTMS.PARENT_ID = dtTMSTerminal_GetByStateID.Rows(0).Item("TERMINAL_ID")
    '                clsDalTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '                clsDalTMS.SIGNATURE = CityID
    '                clsDalTMS.NAME = CityName
    '                clsDalTMS.TYPE = vbCrLf
    '                clsDalTMS.STATUS = 0
    '                clsDalTMS.CATEGORY = 0
    '                clsDalTMS.DESCRIPTION = String.Empty
    '                clsDalTMS.REGISTRATION_DATE = Date.Now

    '                clsDalTMS.ForTMS_TMSTerminal_Insert2() 'warnning:has Transaction Problem
    '                clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID) 'warnning:has Transaction Problem

    '            Else
    '                'Nothing
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class