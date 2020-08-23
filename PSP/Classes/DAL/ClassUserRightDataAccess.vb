Imports Oracle.DataAccess.Client

''' <summary>
''' Developed by : Ehsan Soheili
''' Last Modified : 860726
''' </summary>
''' <remarks></remarks>
Public Class ClassUserRightDataAccess
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Dim dtUserRight As New DataTable
    Private SQL As String
    Private _View As Boolean
    Private _New As Boolean
    Private _Edit As Boolean
    Private _Delete As Boolean
    Private _Print As Boolean
    Public Structure UserRightTemplate
        Dim FormID As Long
        Dim View_bit As Boolean
        Dim New_bit As Boolean
        Dim Edit_bit As Boolean
        Dim Delete_bit As Boolean
        Dim Print_bit As Boolean
        Dim UserProjectID As Int64
        Dim UserID As Long
    End Structure
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
    Public Property CanView() As Boolean
        Get
            Return _View
        End Get
        Set(ByVal value As Boolean)
            _View = value
        End Set
    End Property
    Public Property CanNew() As Boolean
        Get
            Return _New
        End Get
        Set(ByVal value As Boolean)
            _New = value
        End Set
    End Property
    Public Property CanEdit() As Boolean
        Get
            Return _Edit
        End Get
        Set(ByVal value As Boolean)
            _Edit = value
        End Set
    End Property
    Public Property CanDelete() As Boolean
        Get
            Return _Delete
        End Get
        Set(ByVal value As Boolean)
            _Delete = value
        End Set
    End Property
    Public Property CanPrint() As Boolean
        Get
            Return _Print
        End Get
        Set(ByVal value As Boolean)
            _Print = value
        End Set
    End Property
    Public Function GetAll() As DataTable
        Try
            SQL = "SELECT * FROM UserRight_T"
            Me.Fill(CommandType.Text, SQL, dtUserRight)
            Return dtUserRight
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal Id As Int64) As DataTable
        Try
            SQL = " SELECT *, Form_T.Name_vc AS FormName, Form_T.Text_vc AS FormCaption FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE (UserID = " + Id.ToString() + ")"
            Me.Fill(CommandType.Text, SQL, dtUserRight)
            Return dtUserRight
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Insert New User into UserRight_T 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Insert(ByVal Name As UserRightTemplate)
        Try
            Dim parUserProjectID As New OracleParameter("@UserProjectID", OracleDbType.Int64)
            parUserProjectID.Value = Name.UserProjectID
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = Name.UserID
            Dim parFormID As New OracleParameter("@FormID", OracleDbType.Int64)
            parFormID.Value = Name.FormID
            Dim parView As New OracleParameter("@View_bit", OracleDbType.Int32)
            parView.Value = Name.View_bit
            Dim parNew As New OracleParameter("@New_bit", OracleDbType.Int32)
            parNew.Value = Name.New_bit
            Dim parEdit As New OracleParameter("@Edit_bit", OracleDbType.Int32)
            parEdit.Value = Name.Edit_bit
            Dim parDelete As New OracleParameter("@Delete_bit", OracleDbType.Int32)
            parDelete.Value = Name.Delete_bit
            Dim parPrint As New OracleParameter("@Print_bit", OracleDbType.Int32)
            parPrint.Value = Name.Print_bit
            SQL = "Insert Into UserRight_T (UserID,FormID,View_bit,New_bit,Edit_bit,Delete_bit,Print_bit,UserProjectID) Values(@UserID,@FormID,@View_bit,@New_bit,@Edit_bit,@Delete_bit,@Print_bit,@UserProjectID)"
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, SQL, parUserID, parFormID, parView, parNew, parEdit, parDelete, parPrint, parUserProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal Name As UserRightTemplate)
        Try
            Dim parUserProjectID As New OracleParameter("@UserProjectID", OracleDbType.Int64)
            parUserProjectID.Value = Name.UserProjectID
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = Name.UserID
            Dim parFormID As New OracleParameter("@FormID", OracleDbType.Int64)
            parFormID.Value = Name.FormID
            Dim parView As New OracleParameter("@View_bit", OracleDbType.Int32)
            parView.Value = Name.View_bit
            Dim parNew As New OracleParameter("@New_bit", OracleDbType.Int32)
            parNew.Value = Name.New_bit
            Dim parEdit As New OracleParameter("@Edit_bit", OracleDbType.Int32)
            parEdit.Value = Name.Edit_bit
            Dim parDelete As New OracleParameter("@Delete_bit", OracleDbType.Int32)
            parDelete.Value = Name.Delete_bit
            Dim parPrint As New OracleParameter("@Print_bit", OracleDbType.Int32)
            parPrint.Value = Name.Print_bit
            SQL = "Update UserRight_T Set View_bit = @View_bit , New_bit = @New_bit , Edit_bit = @Edit_bit , Delete_bit = @Delete_bit , Print_bit = @Print_bit Where UserProjectID = @UserProjectID AND UserID = @UserID AND FormID = @FormID"
            Me.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, SQL, parUserID, parFormID, parView, parNew, parEdit, parDelete, parPrint, parUserProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(ByVal UserID As Integer, ByVal FormID As Integer)
        Try
            SQL = "DELETE FROM UserRight_T WHERE UserID = " & UserID & " AND FormID = " & FormID & " "
            Me.Execute_NonQuery(CommandType.Text, SQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UserPermission(ByVal UserId As Integer, ByVal FormName As String)
        Dim dtUserPer As New DataTable
        Try

            SQL = "SELECT * FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE UserID = " & UserId & " AND Form_T.Name_vc = '" & FormName & "' And UserRight_T.ProjectID = " & ClassUserLoginDataAccess.ThisUser.ProjectID
            Me.Fill(CommandType.Text, SQL, dtUserPer)
            If dtUserPer.Rows.Count > 0 Then
                Me.CanView = IIf(dtUserPer.Rows(0).Item("View_bit").ToString() = True, True, False)
                Me.CanNew = IIf(dtUserPer.Rows(0).Item("New_bit").ToString() = True, True, False)
                Me.CanEdit = IIf(dtUserPer.Rows(0).Item("Edit_bit").ToString() = True, True, False)
                Me.CanDelete = IIf(dtUserPer.Rows(0).Item("Delete_bit").ToString() = True, True, False)
                Me.CanPrint = IIf(dtUserPer.Rows(0).Item("Print_bit").ToString() = True, True, False)
            Else
                Me.CanView = True
                Me.CanNew = True
                Me.CanEdit = True
                Me.CanDelete = True
                Me.CanPrint = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UserPermission(ByVal UserId As Integer, ByVal FormName As String, ByVal IsReport As Int16, ByVal FormID As Int16)
        Dim dtUserPer As New DataTable
        Try
            If IsReport = 1 Then
                SQL = "SELECT * FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE UserID = " & UserId & " AND Form_T.Name_vc = '" & FormName & "' AND ISReport = '1' AND Form_T.FormID = '" & FormID & "' "
            ElseIf IsReport = 0 Then
                SQL = "SELECT * FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE UserID = " & UserId & " AND Form_T.Name_vc = '" & FormName & "' AND ISReport = '0' AND Form_T.FormID = '" & FormID & "' "
            End If
            Me.Fill(CommandType.Text, SQL, dtUserPer)
            If dtUserPer.Rows.Count > 0 Then
                Me.CanView = IIf(dtUserPer.Rows(0).Item("View_bit").ToString() = True, True, False)
                Me.CanNew = IIf(dtUserPer.Rows(0).Item("New_bit").ToString() = True, True, False)
                Me.CanEdit = IIf(dtUserPer.Rows(0).Item("Edit_bit").ToString() = True, True, False)
                Me.CanDelete = IIf(dtUserPer.Rows(0).Item("Delete_bit").ToString() = True, True, False)
                Me.CanPrint = IIf(dtUserPer.Rows(0).Item("Print_bit").ToString() = True, True, False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UserPermission(ByVal UserId As Integer, ByVal FormName As String, ByVal IsReport As Int16)
        Dim dtUserPer As New DataTable
        Try
            SQL = "SELECT * FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE UserID = " & UserId & " AND Form_T.Name_vc = '" & FormName & "' AND ISReport = '1' "
            Me.Fill(CommandType.Text, SQL, dtUserPer)
            If dtUserPer.Rows.Count > 0 Then
                Me.CanView = IIf(dtUserPer.Rows(0).Item("View_bit").ToString() = True, True, False)
                Me.CanNew = IIf(dtUserPer.Rows(0).Item("New_bit").ToString() = True, True, False)
                Me.CanEdit = IIf(dtUserPer.Rows(0).Item("Edit_bit").ToString() = True, True, False)
                Me.CanDelete = IIf(dtUserPer.Rows(0).Item("Delete_bit").ToString() = True, True, False)
                Me.CanPrint = IIf(dtUserPer.Rows(0).Item("Print_bit").ToString() = True, True, False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UserPermission(ByVal UserId As Integer, ByVal BasicType As SByte)
        Dim dtUserPer As New DataTable
        Try
            SQL = "SELECT * FROM Form_T INNER JOIN UserRight_T ON Form_T.FormID = UserRight_T.FormID WHERE UserID = " & UserId & " AND Form_T.BasicType = '" & BasicType & "' "
            Me.Fill(CommandType.Text, SQL, dtUserPer)
            If dtUserPer.Rows.Count > 0 Then
                Me.CanView = IIf(dtUserPer.Rows(0).Item("View_bit").ToString() = True, True, False)
                Me.CanNew = IIf(dtUserPer.Rows(0).Item("New_bit").ToString() = True, True, False)
                Me.CanEdit = IIf(dtUserPer.Rows(0).Item("Edit_bit").ToString() = True, True, False)
                Me.CanDelete = IIf(dtUserPer.Rows(0).Item("Delete_bit").ToString() = True, True, False)
                Me.CanPrint = IIf(dtUserPer.Rows(0).Item("Print_bit").ToString() = True, True, False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
