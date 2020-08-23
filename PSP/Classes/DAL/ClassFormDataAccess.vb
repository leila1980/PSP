Imports Oracle.DataAccess.Client

''' <summary>
''' Developed by : Ehsan Soheili
''' Last Modified : 860726
''' </summary>
''' <remarks></remarks>
Public Class ClassFormDataAccess
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Shared dtGeneral As New DataTable
    Private dtForm As New DataTable
    Private dtFormID As New DataTable
    Private SQL As String
    Public Structure UserRightTemplate
        Dim FormID As Long
        Dim Name_vc As String
        Dim Text_vc As String
        Dim HaveNew As Boolean
        Dim HaveEdit As Boolean
        Dim HaveDelete As Boolean
        Dim HavePrint As Boolean
    End Structure
    Public Structure FormTemplate
        Dim FormID As Long
        Dim Name_vc As String
        Dim Text_vc As String
        Dim HaveNew As Boolean
        Dim HaveEdit As Boolean
        Dim HaveDelete As Boolean
        Dim HavePrint As Boolean
        Dim IOTypeID As Long
        Dim IsReport As Int16
    End Structure
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
    Public Function GetAll() As DataTable
        Try
            SQL = "SELECT * FROM Form_T"
            Me.Fill(CommandType.Text, SQL, dtForm)
            Return dtForm
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllReport() As DataTable
        Try
            SQL = "SELECT * FROM Form_T WHERE (IsReport = 1 )"
            Me.Fill(CommandType.Text, SQL, dtForm)
            Return dtForm
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal Id As Int64) As DataTable
        Try
            SQL = "SELECT * FROM Form_T WHERE (FormID = " + Id.ToString() + ")"
            Me.Fill(CommandType.Text, SQL, dtForm)
            Return dtForm
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNewID() As Int16
        Try
            SQL = "SELECT Max(FormID) FROM Form_T"
            Return Me.Execute_Scalar(CommandType.Text, SQL, 0) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert(ByVal FormT As FormTemplate)
        Try
            Dim parFormID As New OracleParameter("@FormID", OracleDbType.Int64)
            Dim parName_vc As New OracleParameter("@Name_vc", OracleDbType.Varchar2)
            Dim parText_vc As New OracleParameter("@Text_vc", OracleDbType.Varchar2)
            Dim parHaveNew As New OracleParameter("@HaveNew", OracleDbType.Int32)
            Dim parHaveEdit As New OracleParameter("@HaveEdit", OracleDbType.Int32)
            Dim parHaveDelete As New OracleParameter("@HaveDelete", OracleDbType.Int32)
            Dim parHavePrint As New OracleParameter("@HavePrint", OracleDbType.Int32)
            Dim parIOTypeID As New OracleParameter("@IOTypeID", OracleDbType.Int16)
            Dim parIsReport As New OracleParameter("@IsReport", OracleDbType.Int16)
            parFormID.Value = FormT.FormID
            parName_vc.Value = FormT.Name_vc
            parText_vc.Value = FormT.Text_vc
            parHaveNew.Value = FormT.HaveNew
            parHaveEdit.Value = FormT.HaveEdit
            parHaveDelete.Value = FormT.HaveDelete
            parHavePrint.Value = FormT.HavePrint
            parIOTypeID.Value = FormT.IOTypeID
            parIsReport.Value = FormT.IsReport
            SQL = "Insert Into Form_T (FormID,Name_vc,Text_vc,HaveNew,HaveEdit,HaveDelete,HavePrint,IOTypeID,IsReport) Values (@FormID,@Name_vc,@Text_vc,@HaveNew,@HaveEdit,@HaveDelete,@HavePrint,@IOTypeID,@IsReport)"
            Me.Execute_NonQuery(CommandType.Text, SQL, parFormID, parName_vc, parText_vc, parHaveNew, parHaveEdit, parHaveDelete, parHavePrint, parIOTypeID, parIsReport)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal FormT As FormTemplate, ByVal IoTypeID As Int16, ByVal IsReport As Int16)
        Try
            Dim parFormID As New OracleParameter("@FormID", OracleDbType.Int64)
            Dim parName_vc As New OracleParameter("@Name_vc", OracleDbType.Varchar2)
            Dim parText_vc As New OracleParameter("@Text_vc", OracleDbType.Varchar2)
            Dim parHaveNew As New OracleParameter("@HaveNew", OracleDbType.Int32)
            Dim parHaveEdit As New OracleParameter("@HaveEdit", OracleDbType.Int32)
            Dim parHaveDelete As New OracleParameter("@HaveDelete", OracleDbType.Int32)
            Dim parHavePrint As New OracleParameter("@HavePrint", OracleDbType.Int32)
            Dim parIOTypeID As New OracleParameter("@IOTypeID", OracleDbType.Int16)
            Dim parIsReport As New OracleParameter("@IsReport", OracleDbType.Int16)
            parFormID.Value = FormT.FormID
            parName_vc.Value = FormT.Name_vc
            parText_vc.Value = FormT.Text_vc
            parHaveNew.Value = FormT.HaveNew
            parHaveEdit.Value = FormT.HaveEdit
            parHaveDelete.Value = FormT.HaveDelete
            parHavePrint.Value = FormT.HavePrint
            parIOTypeID.Value = IoTypeID
            parIsReport.Value = IsReport
            SQL = "Update Form_T Set Name_vc = @Name_vc , Text_vc = @Text_vc , HaveNew = @HaveNew , HaveEdit = @HaveEdit, HaveDelete = @HaveDelete, HavePrint = @HavePrint, IOTypeID = " & IoTypeID & " , IsReport = " & IsReport & " Where IoTypeID = " & IoTypeID & " AND IsReport = " & IsReport & ""
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, SQL, parName_vc, parText_vc, parHaveNew, parHaveEdit, parHaveDelete, parHavePrint, parIOTypeID, parIsReport)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(ByVal IOTypeId As Integer)
        Try
            Dim parIOTypeId As New OracleParameter("@IOTypeId", OracleDbType.Int16)
            parIOTypeId.Value = IOTypeId
            SQL = "DELETE FROM Form_T WHERE IOTypeID = @IOTypeID"
            Me.Execute_NonQuery(CommandType.Text, SQL, parIOTypeId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllFormID() As DataTable
        Try
            SQL = "SELECT FormID FROM Form_T"
            dtFormID.Clear()
            Me.Fill(CommandType.Text, SQL, dtFormID)
            Return dtFormID
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
