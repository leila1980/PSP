Imports Oracle.DataAccess.Client

Public Class ClassUserLoginDataAccess
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Public Shared ThisUser As UserTemplate
    Private Shared dtUserRight As New DataTable
    Public Shared dtUserRightOnControls As New DataTable
    Private Shared dtUserWarehouse As New DataTable
    Private _UserDataTable As DataTable
    Private strSQL As String
    Public Structure UserTemplate
        Dim UserID As Int64
        Dim UserName_vc As String
        Dim Password_vc As String
        Dim FullName_vc As String
        Dim IsActive_bit As Boolean
        Dim Admin_tint As Int16
        Dim ProjectID As Int64
        Dim UserProjectID As Int64
        Dim MinAmount As Int64
    End Structure
    Public Enum Forms As Short
        frmsupplier = 1
        FrmProjectDefinition = 2
    End Enum
    Public Structure PermissionTemplate
        Dim View_bit As Boolean
        Dim New_bit As Boolean
        Dim Edit_bit As Boolean
        Dim Delete_bit As Boolean
        Dim Print_bit As Boolean
    End Structure

    Public Function Login(ByVal UserName As String, ByVal Password As String, ByVal ProjectID As Int16) As Boolean
        Try
            Login = False
            Dim _UserTemplate As ClassUserLoginDataAccess.UserTemplate
            _UserTemplate = GetByUserNameAndPass(UserName, EnCode(Password), ProjectID)
            If _UserTemplate.UserName_vc IsNot Nothing Then
                ClassUserLoginDataAccess.ThisUser = _UserTemplate
                FillUserRight(ClassUserLoginDataAccess.ThisUser.UserProjectID)
                FillUserRightOnControls(ClassUserLoginDataAccess.ThisUser.UserProjectID)
                Login = True
            Else
                Throw New ApplicationException(msgInvalidUserNamOrPass)
                Login = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub FillUserRight(ByVal UserProjectID As Int16)
        Try
            Dim parUserProjectID As New OracleParameter(":UserProjectID", OracleDbType.Int64)
            parUserProjectID.Value = UserProjectID

            strSQL = "SELECT *  from UserRight_T Where UserProjectID = :UserProjectID"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dtUserRight, parUserProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub FillUserRightOnControls(ByVal UserProjectID As Int16)
        Try
            Dim parUserProjectID As New OracleParameter(":UserProjectID", OracleDbType.Int64)
            parUserProjectID.Value = UserProjectID

            strSQL = "SELECT UserRightOnControls_T.*,Form_T.Name_vc as FormName  from UserRightOnControls_T inner join Form_T on UserRightOnControls_T.FormID=Form_T.FormID Where UserProjectID = :UserProjectID "

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dtUserRightOnControls, parUserProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function UserRight(ByVal Form As Forms) As PermissionTemplate '===AfterCall fillUserRight
        Try
            Dim drUserRight() As DataRow = dtUserRight.Select("FormID =" & Form)
            If drUserRight.Length > 0 Then
                UserRight.View_bit = drUserRight(0).Item("View_bit")
                UserRight.New_bit = drUserRight(0).Item("New_bit")
                UserRight.Edit_bit = drUserRight(0).Item("Edit_bit")
                UserRight.Delete_bit = drUserRight(0).Item("Delete_bit")
                UserRight.Print_bit = drUserRight(0).Item("Print_bit")

            Else
                UserRight = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Sub Insert(ByVal User As UserTemplate)
        Try

            Dim strSQL As String

            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int64)
            parUserID.Value = User.UserID

            Dim parUserName_vc As New OracleParameter(":UserName_vc", OracleDbType.Varchar2)
            parUserName_vc.Value = User.UserName_vc

            Dim parPassword_vc As New OracleParameter(":Password_vc", OracleDbType.Varchar2)
            parPassword_vc.Value = User.Password_vc

            Dim parFullName_vc As New OracleParameter(":FullName_vc", OracleDbType.Varchar2)
            parFullName_vc.Value = User.FullName_vc

            Dim parIsActive_bit As New OracleParameter(":IsActive_bit", OracleDbType.Int32)
            parIsActive_bit.Value = User.IsActive_bit

            strSQL = "INSERT INTO User_T (UserID, UserName_vc, Password_vc,FullName_vc,IsActive_bit)  VALUES (:UserID,:UserName_vc,:Password_vc,:FullName_vc,:IsActive_bit)"
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, parUserID, parUserName_vc, parPassword_vc, parFullName_vc, parIsActive_bit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal User As UserTemplate)
        Try
            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int64)
            parUserID.Value = User.UserID

            Dim parUserName_vc As New OracleParameter(":UserName_vc", OracleDbType.Varchar2)
            parUserName_vc.Value = User.UserName_vc

            Dim parPassword_vc As New OracleParameter(":Password_vc", OracleDbType.Varchar2)
            parPassword_vc.Value = User.Password_vc

            Dim parFullName_vc As New OracleParameter(":FullName_vc", OracleDbType.Varchar2)
            parFullName_vc.Value = User.FullName_vc

            Dim parIsActive_bit As New OracleParameter(":IsActive_bit", OracleDbType.Int32)
            parIsActive_bit.Value = User.IsActive_bit

            strSQL = "UPDATE User_T SET    UserName_vc =:UserName_vc,Password_vc =:Password_vc,FullName_vc =:FullName_vc,IsActive_bit =:IsActive_bit  WHERE (UserID =:UserID )"

            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, parUserName_vc, parPassword_vc, parFullName_vc, parIsActive_bit, parUserID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(ByVal ID As Int64)
        Try
            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int64)
            parUserID.Value = ID

            strSQL = "DELETE FROM User_T WHERE (UserID =:UserID)"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, parUserID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAll() As DataTable
        Try
            _UserDataTable = New DataTable
            strSQL = "SELECT *  from User_T "
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, _UserDataTable)
            Return _UserDataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID(ByVal ID As Int64) As DataTable
        Try
            _UserDataTable = New DataTable

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ID

            strSQL = "GetByIDUser_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, _UserDataTable, parUserID)
            Return _UserDataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByUserName(ByVal UserName As String) As DataTable
        Try
            _UserDataTable = New DataTable

            Dim parUserName_vc As New OracleParameter(":UserName_vc", OracleDbType.Varchar2)
            parUserName_vc.Value = UserName

            strSQL = "SELECT *  from User_T Where UserName_vc = :UserName_vc "
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, _UserDataTable, parUserName_vc)
            Return _UserDataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByUserNameAndPass(ByVal UserName As String, ByVal Password As String, ByVal ProjectID As Int16) As UserTemplate '===must be Changed to Reader And Where It is Used must be Changed
        Try
            _UserDataTable = New DataTable

            Dim parUserName_vc As New OracleParameter(":UserName_vc", OracleDbType.Varchar2)
            parUserName_vc.Value = UserName

            Dim parPassword_vc As New OracleParameter(":Password_vc", OracleDbType.Varchar2)
            parPassword_vc.Value = Password

            Dim parProjectID As New OracleParameter(":ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "SELECT User_T.*,UserProject_T.UserProjectID,UserProject_T.ProjectID_tint  from User_T inner join UserProject_T on User_T.UserID=UserProject_T.USERID Where upper(UserName_vc) = upper(:UserName_vc) and upper(Password_vc)=upper(:Password_vc) and ProjectID_tint=:ProjectID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, _UserDataTable, parUserName_vc, parPassword_vc, parProjectID)
            If _UserDataTable.Rows.Count > 0 Then
                GetByUserNameAndPass.UserID = _UserDataTable.Rows(0).Item(0)
                GetByUserNameAndPass.UserName_vc = _UserDataTable.Rows(0).Item(1)
                GetByUserNameAndPass.Password_vc = _UserDataTable.Rows(0).Item(2)
                GetByUserNameAndPass.FullName_vc = _UserDataTable.Rows(0).Item(3)
                GetByUserNameAndPass.IsActive_bit = _UserDataTable.Rows(0).Item(4)
                GetByUserNameAndPass.Admin_tint = _UserDataTable.Rows(0).Item("Admin_tint")
                GetByUserNameAndPass.UserProjectID = _UserDataTable.Rows(0).Item("UserProjectID")
                GetByUserNameAndPass.ProjectID = _UserDataTable.Rows(0).Item("ProjectID_tint")
                GetByUserNameAndPass.MinAmount = _UserDataTable.Rows(0).Item("MinAmount")
            Else
                GetByUserNameAndPass = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVisitorIDByUserID(ByVal UserID As Int64) As Integer
        Try
            Dim VisitorID As Integer
            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int32)
            parUserID.Value = UserID

            strSQL = "SELECT VisitorID  from UserVisitor_T Where UserID = :UserID"

            VisitorID = Execute_Scalar(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, -1, parUserID)

            Return VisitorID
        Catch ex As Exception
            'Return -1
            Throw ex
        End Try
    End Function
    Public Function GetUserIsSuperUser(ByVal UserID As Int32) As Integer
        Try
            Dim IsSuperUser As Integer
            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int32)
            parUserID.Value = UserID
      
            strSQL = "SELECT ISSUPERUSER  FROM  User_T WHERE UserID = :UserID "
            IsSuperUser = Execute_Scalar(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, -1, parUserID)

            Return IsSuperUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCountVisitorByUserID(ByVal UserID As Int64) As Integer
        Try
            Dim VisitorID As Integer
            Dim parUserID As New OracleParameter(":UserID", OracleDbType.Int64)
            parUserID.Value = UserID

            strSQL = "SELECT count(VisitorID)  from UserVisitor_T Where UserID = :UserID"
            VisitorID = Execute_Scalar(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, -1, parUserID)
            Return VisitorID
        Catch ex As Exception
            Return -1
            Throw ex
        End Try
    End Function
End Class