Imports Oracle.DataAccess.Client

''' <summary>
''' Developed by : Ehsan Soheili
''' Last Modified : 860726
''' </summary>
''' <remarks></remarks>
Public Class ClassUserDataAccess
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Shared dtGeneral As New DataTable
    Dim dtUser As New DataTable
    Private SQL As String
    Public Structure UserTemplate
        Dim UserID As Long
        Dim UserName_vc As String
        Dim Password_vc As String
        Dim FullName_vc As String
        Dim IsActive_bit As Boolean
    End Structure
    Public Structure UserInsertTemplate
        Dim UserID As Long
        Dim FormID As Long
        Dim View_bit As Boolean
        Dim New_bit As Boolean
        Dim Edit_bit As Boolean
        Dim Delete_bit As Boolean
        Dim Print_bit As Boolean
    End Structure
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
    Public Function GetAll() As DataTable
        Try
            SQL = "SELECT * FROM User_T"
            'SQL = "SELECT *, Form_T.Name_vc AS FormName, Form_T.Text_vc AS FormCaption FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID"
            Me.Fill(CommandType.Text, SQL, dtUser)
            Return dtUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal Id As Int64) As DataTable
        Try
            SQL = "SELECT * FROM User_T WHERE (UserID = " + Id.ToString() + ")"
            Me.Fill(CommandType.Text, SQL, dtUser)
            Return dtUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByName(ByVal Name As String) As DataTable
        Try
            Name = Name.Replace("'", "''")
            SQL = "SELECT * FROM User_T" & _
                  " WHERE (UserName_vc " + Name + ")"
            Me.Fill(CommandType.Text, SQL, dtUser)
            Return dtUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNewId() As Int64
        Try
            SQL = "SELECT MAX(UserID) AS UserID FROM User_T"
            Return Me.Execute_Scalar(CommandType.Text, SQL, 0) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetUserProjectID(ByVal UserID As Int32) As Int64
        Try
            Dim tmp As Int64
            SQL = "SELECT UserProjectID FROM UserProject_T Where ProjectID_tint = " & ClassUserLoginDataAccess.ThisUser.ProjectID & " And UserID = " & UserID
            tmp = Me.Execute_Scalar(CommandType.Text, SQL, 0)
            If tmp = 0 Then
                SQL = "Insert Into UserProject_T Values(" & ClassUserLoginDataAccess.ThisUser.ProjectID & ", " & UserID & ")"
                Me.Execute_NonQuery(CommandType.Text, SQL)

                SQL = "SELECT UserProjectID FROM UserProject_T Where ProjectID_tint = " & ClassUserLoginDataAccess.ThisUser.ProjectID & " And UserID = " & UserID
                tmp = Me.Execute_Scalar(CommandType.Text, SQL, 0)
            End If
            Return tmp
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert(ByVal Name As UserTemplate)
        Try
            'If (Me.GetById(Name.UserID).Rows.Count > 0) Then
            '    'Throw New ArgumentException(modApplicationMessage.msgDuplicateI)
            'End If
            Dim parUserID As New OracleParameter("UserID", OracleDbType.Int64)
            parUserID.Value = Name.UserID
            Dim parUserName As New OracleParameter("UserName", OracleDbType.Varchar2)
            parUserName.Value = Name.UserName_vc
            Dim parPassword As New OracleParameter("Password", OracleDbType.Varchar2)
            parPassword.Value = Name.Password_vc
            Dim parFullName As New OracleParameter("FullName", OracleDbType.Varchar2)
            parFullName.Value = Name.FullName_vc
            Dim parIsActive As New OracleParameter("IsActive", OracleDbType.Int32)
            parIsActive.Value = Name.IsActive_bit
            SQL = "Insert Into User_T (UserID,UserName_vc,Password_vc,FullName_vc,IsActive_bit) Values(@UserID,@UserName,@Password,@FullName,@IsActive)"
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, SQL, parUserID, parUserName, parPassword, parFullName, parIsActive)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal Name As UserTemplate)
        Try
            Dim parUserID As New OracleParameter("UserID", OracleDbType.Int64)
            parUserID.Value = Name.UserID
            Dim parUserName As New OracleParameter("UserName", OracleDbType.Varchar2)
            parUserName.Value = Name.UserName_vc
            Dim parPassword As New OracleParameter("Password", OracleDbType.Varchar2)
            parPassword.Value = Name.Password_vc
            Dim parFullName As New OracleParameter("FullName", OracleDbType.Varchar2)
            parFullName.Value = Name.FullName_vc
            Dim parIsActive As New OracleParameter("IsActive", OracleDbType.Int32)
            parIsActive.Value = Name.IsActive_bit
            SQL = "Update User_T Set UserID = @UserID , UserName_vc = @UserName , Password_vc = @Password , FullName_vc = @FullName , IsActive_bit = @IsActive Where UserID = @UserID "
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, SQL, parUserID, parUserName, parPassword, parFullName, parIsActive)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(ByVal IDToDelete As Int64)
        Try
            SQL = "DELETE FROM User_T WHERE UserID = " & IDToDelete & ""
            Me.Execute_NonQuery(CommandType.Text, SQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class