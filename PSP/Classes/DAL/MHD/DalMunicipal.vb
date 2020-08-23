Imports Oracle.DataAccess.Client

Partial Class Dal
    Public Structure MunicipalAreaTemplate
        Dim MunicipalAreaId As Int64
        Dim Name_nvc As String
        Dim ParentID As Nullable(Of Int64)
    End Structure

    Public Function GetMunicipalArea() As DataTable
        'This Query Return the resualt with recursive query.

        'Dim strSQL As String
        'strSQL = "WITH MyChart(MunicipalAreaID,Name_nvc,ParentID,ParentName,lvl) AS "
        'strSQL += "(SELECT Emp.MunicipalAreaID,Emp.Name_nvc,Boss.MunicipalAreaID,Boss.Name_nvc, 1 "
        'strSQL += "FROM MunicipalArea_T Emp LEFT JOIN MunicipalArea_T Boss "
        'strSQL += "ON Emp.ParentID=Boss.MunicipalAreaID "
        'strSQL += "WHERE Emp.MunicipalAreaID in (Select MunicipalAreaID From MunicipalArea_T Where ParentId is NULL) "
        'strSQL += "UNION ALL "
        'strSQL += "SELECT Emp.MunicipalAreaID,Emp.Name_nvc,MyChart.MunicipalAreaID, "
        'strSQL += "MyChart.Name_nvc, MyChart.lvl + 1 "
        'strSQL += "FROM MunicipalArea_T Emp INNER JOIN MyChart "
        'strSQL += "ON Emp.ParentID=MyChart.MunicipalAreaID)  SELECT * FROM MyChart"

        Try
            Dim strSQL As String = "Select * From MunicipalArea_T Order by Name_nvc"
            Dim dt As New DataTable
            Me.Fill(CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Insert(ByVal MunicipalArea As MunicipalAreaTemplate) As Integer
        Try
            Dim SeqSql As String = "Select MUNICIPALAREA_SEQ.Nextval from Dual"

            Dim parID As New OracleParameter(":MUNICIPALAREAID", OracleDbType.Varchar2)
            parID.Value = Me.Execute_Scalar(CommandType.Text, SeqSql, 0)

            Dim parName_nvc As New OracleParameter(":Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = MunicipalArea.Name_nvc

            Dim parParentId As New OracleParameter(":ParentID", OracleDbType.Int64)
            If MunicipalArea.ParentID.HasValue Then
                parParentId.Value = MunicipalArea.ParentID.Value
            Else
                parParentId.Value = DBNull.Value
            End If

            Dim strSQL As String = "Insert into MunicipalArea_T(MUNICIPALAREAID,Name_nvc,ParentID) Values(:MUNICIPALAREAID,:Name_nvc,:ParentID)"
            Me.Execute_NonQuery(CommandType.Text, strSQL, parID, parName_nvc, parParentId)

            Return parID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Update(ByVal MunicipalArea As MunicipalAreaTemplate) As Integer
        Try
            Dim parMunicipalAreaID As New OracleParameter(":MunicipalAreaID", OracleDbType.Int64)
            parMunicipalAreaID.Value = MunicipalArea.MunicipalAreaId

            Dim parName_nvc As New OracleParameter(":Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = MunicipalArea.Name_nvc

            Dim strSQL As String = "Update MunicipalArea_T Set Name_nvc=:Name_nvc Where MunicipalAreaID=:MunicipalAreaID"
            Me.Execute_NonQuery(CommandType.Text, strSQL, parName_nvc, parMunicipalAreaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Delete(ByVal MunicipalArea As MunicipalAreaTemplate) As Integer
        Try
            Dim parMunicipalAreaID As New OracleParameter(":MunicipalAreaID", OracleDbType.Int64)
            parMunicipalAreaID.Value = MunicipalArea.MunicipalAreaId

            Dim strSQL As String = "Delete MunicipalArea_T Where MunicipalAreaID=:MunicipalAreaID"
            Me.Execute_NonQuery(CommandType.Text, strSQL, parMunicipalAreaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
