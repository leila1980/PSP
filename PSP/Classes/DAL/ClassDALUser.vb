Imports Oracle.DataAccess.Client

Public Class ClassDALUser
    Public UserID As Int64 = 0
    Public UserName As String = String.Empty
    Public Password As String = String.Empty
    Public FullName As String = String.Empty
    Public IsActive As Boolean = False
    Public IsSuperUser As Boolean = False
    Public MinAmount As Long = 0

    Public dtUserVisitor As DataTable
    Public dtUserProject As DataTable
    Public dtUserRight As DataTable
    Public dtUserRightOnControls As DataTable
    Public dtUserprojectBy As DataTable

    Private cnUser As New Oracle.DataAccess.Client.OracleConnection()
    Private trnUser As OracleTransaction

    Public Sub New()
        cnUser = New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
    End Sub

#Region "Get Info"

    Public Function GetAllUser() As DataTable
        Try

            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUser As New OracleDataAdapter()
            Dim dtUser As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parUserName As New OracleParameter("UserName_", OracleDbType.Varchar2, 100)
            Dim parFullName As New OracleParameter("FullName_", OracleDbType.Varchar2, 100)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            parUserID.Value = UserID
            parUserName.Value = UserName
            parFullName.Value = FullName

            cmdUser.Connection = cnUser
            cmdUser.CommandType = Data.CommandType.StoredProcedure
            cmdUser.CommandText = "usp_GetAllUser"
            cmdUser.Parameters.Add(parUserID)
            cmdUser.Parameters.Add(parUserName)
            cmdUser.Parameters.Add(parFullName)
            cmdUser.Parameters.Add(parRefCursor)

            daUser.SelectCommand = cmdUser
            cnUser.Open()
            daUser.Fill(dtUser)
            cnUser.Close()
            Return dtUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVisitorForUser() As DataTable
        Try
            Dim cmdUserVisitor As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserVisitor As New OracleDataAdapter()
            Dim dtUserVisitor As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            parUserID.Value = UserID

            cmdUserVisitor.Connection = cnUser
            cmdUserVisitor.CommandType = Data.CommandType.StoredProcedure
            cmdUserVisitor.CommandText = "usp_UserVisitor"
            cmdUserVisitor.Parameters.Add(parUserID)
            cmdUserVisitor.Parameters.Add(parRefCursor)

            daUserVisitor.SelectCommand = cmdUserVisitor
            cnUser.Open()
            daUserVisitor.Fill(dtUserVisitor)
            cnUser.Close()
            Return dtUserVisitor

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetManagementForUser() As DataTable
        Try
            Dim cmdUserManagement As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserManagement As New OracleDataAdapter()
            Dim dtUserManagement As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            parUserID.Value = UserID

            cmdUserManagement.Connection = cnUser
            cmdUserManagement.CommandType = Data.CommandType.StoredProcedure
            cmdUserManagement.CommandText = "usp_GetUserManagement"
            cmdUserManagement.Parameters.Add(parUserID)

            daUserManagement.SelectCommand = cmdUserManagement
            cnUser.Open()
            daUserManagement.Fill(dtUserManagement)
            cnUser.Close()
            Return dtUserManagement

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProjectForUser() As DataTable
        Try
            Dim cmdUserProject As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserProject As New OracleDataAdapter()
            Dim dtUserProject As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            parUserID.Value = UserID

            cmdUserProject.Connection = cnUser
            cmdUserProject.CommandType = Data.CommandType.StoredProcedure
            cmdUserProject.CommandText = "usp_GetUserProjects"
            cmdUserProject.Parameters.Add(parUserID)
            cmdUserProject.Parameters.Add(parRefCursor)

            daUserProject.SelectCommand = cmdUserProject
            cnUser.Open()
            daUserProject.Fill(dtUserProject)
            cnUser.Close()
            Return dtUserProject

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUserRight() As DataTable
        Try
            Dim cmdUserRight As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserRight As New OracleDataAdapter()
            Dim dtUserRight As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            parUserID.Value = UserID

            cmdUserRight.Connection = cnUser
            cmdUserRight.CommandType = Data.CommandType.StoredProcedure
            cmdUserRight.CommandText = "usp_GetUserRight"
            cmdUserRight.Parameters.Add(parUserID)
            cmdUserRight.Parameters.Add(parRefCursor)


            daUserRight.SelectCommand = cmdUserRight
            cnUser.Open()
            daUserRight.Fill(dtUserRight)
            cnUser.Close()
            Return dtUserRight
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUserProjects() As DataTable
        Try
            Dim cmdUserProjrct As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserProject As New OracleDataAdapter()
            Dim dtUserProject As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            parUserID.Value = UserID

            cmdUserProjrct.Connection = cnUser
            cmdUserProjrct.CommandType = Data.CommandType.StoredProcedure
            cmdUserProjrct.CommandText = "GetAllProject_ByUserID_SP"
            cmdUserProjrct.Parameters.Add(parUserID)

            daUserProject.SelectCommand = cmdUserProjrct
            cnUser.Open()
            daUserProject.Fill(dtUserProject)
            cnUser.Close()
            Return dtUserProject
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetStateForUser() As DataTable
        Try
            Dim cmdUserState As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserState As New OracleDataAdapter()
            Dim dtUserState As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            parUserID.Value = UserID

            cmdUserState.Connection = cnUser
            cmdUserState.CommandType = Data.CommandType.StoredProcedure
            cmdUserState.CommandText = "usp_GetState"
            cmdUserState.Parameters.Add(parUserID)

            daUserState.SelectCommand = cmdUserState
            cnUser.Open()
            daUserState.Fill(dtUserState)
            cnUser.Close()
            Return dtUserState

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUserRightOnControls(ByVal UserID As Long) As DataTable
        Try
            Dim cmdUserRightOnControls As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserRightOnControls As New OracleDataAdapter()
            Dim dtUserRightOnControls As New DataTable

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            parUserID.Value = UserID

            cmdUserRightOnControls.Connection = cnUser
            cmdUserRightOnControls.CommandType = Data.CommandType.StoredProcedure
            cmdUserRightOnControls.CommandText = "GetAllUserRightOnControls_SP"
            cmdUserRightOnControls.Parameters.Add(parUserID)
            cmdUserRightOnControls.Parameters.Add(parRefCursor)

            daUserRightOnControls.SelectCommand = cmdUserRightOnControls
            cnUser.Open()
            daUserRightOnControls.Fill(dtUserRightOnControls)
            cnUser.Close()
            Return dtUserRightOnControls

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUserProjectByUserIDAndPrjID(ByVal UserID As Long) As DataTable
        Try
            Dim cmdUserProjet As New Oracle.DataAccess.Client.OracleCommand()
            Dim daUserProject As New OracleDataAdapter()
            Dim dtUserRightOnControls As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dtUserprojectBy = New DataTable

            parUserID.Value = UserID
            parProjectID.Value = 1

            cmdUserProjet.Connection = cnUser
            cmdUserProjet.CommandType = Data.CommandType.StoredProcedure
            'cmdUserProjet.CommandText = "GetUserproject_SP"
            cmdUserProjet.CommandText = " GetUserProjectBy_sp"
            cmdUserProjet.Parameters.Add(parUserID)
            cmdUserProjet.Parameters.Add(parProjectID)
            cmdUserProjet.Parameters.Add(parRefCursor)

            daUserProject.SelectCommand = cmdUserProjet
            cnUser.Open()
            daUserProject.Fill(dtUserprojectBy)
            cnUser.Close()


            Return dtUserprojectBy

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "Insert, Delete Or Update Date"

    Public Sub InsertUser()
        Try

            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()
            cnUser.Open()
            trnUser = cnUser.BeginTransaction()
            cmdUser.Connection = cnUser
            cmdUser.Transaction = trnUser
            cmdUser.CommandType = Data.CommandType.StoredProcedure
            cmdUser.CommandText = "usp_InsertUser"
            Dim parUserName As New OracleParameter("UserName_vc_", OracleDbType.Varchar2, 100)
            Dim parPassword As New OracleParameter("Password_vc_", OracleDbType.Varchar2, 100)
            Dim parFullName As New OracleParameter("FullName_vc_", OracleDbType.Varchar2, 100)
            Dim parIsActive As New OracleParameter("IsActive_bit_", OracleDbType.Int32)
            Dim parMinAmount As New OracleParameter("MinAmount_", OracleDbType.Int64)
            Dim parISSUPERUSER As New OracleParameter("ISSUPERUSER_", OracleDbType.Int16)
            Dim parRefCursor As New OracleParameter("UserID_", OracleDbType.Int64, ParameterDirection.Output)

            parUserName.Value = UserName
            parPassword.Value = Password
            parFullName.Value = FullName
            parIsActive.Value = IsActive
            parMinAmount.Value = MinAmount
            parISSUPERUSER.Value = IsSuperUser

            Try
                cmdUser.Parameters.Add(parUserName)
                cmdUser.Parameters.Add(parPassword)
                cmdUser.Parameters.Add(parFullName)
                cmdUser.Parameters.Add(parIsActive)
                cmdUser.Parameters.Add(parMinAmount)
                cmdUser.Parameters.Add(parISSUPERUSER)
                cmdUser.Parameters.Add(parRefCursor)

                cmdUser.ExecuteScalar()
                UserID = Int64.Parse(parRefCursor.Value.ToString())

                InsertUserVisitor()
                InsertUserProject()
                trnUser.Commit()
            Catch ex As Exception
                trnUser.Rollback()
            End Try
            cnUser.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateUser()
        Try
            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()
            cnUser.Open()
            trnUser = cnUser.BeginTransaction()
            cmdUser.Connection = cnUser
            cmdUser.Transaction = trnUser
            cmdUser.CommandType = Data.CommandType.StoredProcedure
            cmdUser.CommandText = "usp_UpdateUser"
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parUserName As New OracleParameter("UserName_vc_", OracleDbType.Varchar2, 100)
            Dim parPassword As New OracleParameter("Password_vc_", OracleDbType.Varchar2, 100)
            Dim parFullName As New OracleParameter("FullName_vc_", OracleDbType.Varchar2, 100)
            Dim parIsActive As New OracleParameter("IsActive_bit_", OracleDbType.Int32)
            Dim parMinAmount As New OracleParameter("MinAmount_", OracleDbType.Int64)
            Dim parISSUPERUSER As New OracleParameter("ISSUPERUSER_", OracleDbType.Int16)

            parUserID.Value = UserID
            parUserName.Value = UserName
            parPassword.Value = Password
            parFullName.Value = FullName
            parIsActive.Value = IsActive
            parMinAmount.Value = MinAmount
            parISSUPERUSER.Value = IsSuperUser
            Try
                cmdUser.Parameters.Add(parUserID)
                cmdUser.Parameters.Add(parUserName)
                cmdUser.Parameters.Add(parPassword)
                cmdUser.Parameters.Add(parFullName)
                cmdUser.Parameters.Add(parIsActive)
                cmdUser.Parameters.Add(parMinAmount)
                cmdUser.Parameters.Add(parISSUPERUSER)

                cmdUser.ExecuteNonQuery()

                InsertUserVisitor()
                InsertUserProject()
                trnUser.Commit()
            Catch ex As Exception
                trnUser.Rollback()
            End Try
            cnUser.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertUserVisitor()
        Try
            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()
            cmdUser.Connection = cnUser
            cmdUser.Transaction = trnUser

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int64)
            parUserID.Value = UserID
            cmdUser.CommandType = Data.CommandType.StoredProcedure
            cmdUser.CommandText = "usp_DeleteUserVisitor"
            cmdUser.Parameters.Add(parUserID)
            cmdUser.ExecuteNonQuery()

            cmdUser.CommandText = "usp_InsertUserVisitor"
            For Each dRow As DataRow In dtUserVisitor.Select("Selected = 1")
                cmdUser.Parameters.Clear()
                parVisitorID.Value = dRow("VisitorID")
                cmdUser.Parameters.Add(parUserID)
                cmdUser.Parameters.Add(parVisitorID)
                cmdUser.ExecuteNonQuery()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertUserProject()
        Try
            Dim cmdUserProject As New Oracle.DataAccess.Client.OracleCommand()
            cmdUserProject.Connection = cnUser
            cmdUserProject.Transaction = trnUser

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int64)
            Dim parSelected As New OracleParameter("Selected_", OracleDbType.Int32)

            cmdUserProject.CommandType = Data.CommandType.StoredProcedure
            cmdUserProject.CommandText = "usp_SetUserProject"
            parUserID.Value = UserID

            For Each dRow As DataRow In dtUserProject.Rows
                parProjectID.Value = dRow("ProjectID_tint")
                parSelected.Value = dRow("Selected")

                cmdUserProject.Parameters.Clear()
                cmdUserProject.Parameters.Add(parUserID)
                cmdUserProject.Parameters.Add(parProjectID)
                cmdUserProject.Parameters.Add(parSelected)
                cmdUserProject.ExecuteNonQuery()
                If dRow("Selected") = 1 Then
                    InsertUserRight(dRow("ProjectID_tint"))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertUserRight(ByVal ProjectID As Int32)
        Try
            Dim cmdUserRight As New Oracle.DataAccess.Client.OracleCommand()
            cmdUserRight.Connection = cnUser
            cmdUserRight.Transaction = trnUser

            cmdUserRight.CommandType = Data.CommandType.StoredProcedure
            Dim parFormID As New OracleParameter("FormID_", OracleDbType.Int64)
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int64)
            Dim parViewCheck As New OracleParameter("View_", OracleDbType.Int32)
            Dim parNewCheck As New OracleParameter("New_", OracleDbType.Int32)
            Dim parEditCheck As New OracleParameter("Edit_", OracleDbType.Int32)
            Dim parDeleteCheck As New OracleParameter("Delete_", OracleDbType.Int32)
            Dim parPrintCheck As New OracleParameter("Print_", OracleDbType.Int32)

            cmdUserRight.CommandText = "usp_SetUserRight"
            For Each dRow As DataRow In dtUserRight.Select("ProjectID_Tint = " & ProjectID)
                cmdUserRight.Parameters.Clear()
                parFormID.Value = dRow("FormID")
                parUserID.Value = UserID
                parProjectID.Value = ProjectID
                If dRow("View_bit") Is DBNull.Value Then
                    parViewCheck.Value = False
                Else
                    parViewCheck.Value = dRow("View_bit")
                End If
                If dRow("New_bit") Is DBNull.Value Then
                    parNewCheck.Value = False
                Else
                    parNewCheck.Value = dRow("New_bit")
                End If
                If dRow("Edit_bit") Is DBNull.Value Then
                    parEditCheck.Value = False
                Else
                    parEditCheck.Value = dRow("Edit_bit")
                End If
                If dRow("Delete_bit") Is DBNull.Value Then
                    parDeleteCheck.Value = False
                Else
                    parDeleteCheck.Value = dRow("Delete_bit")
                End If
                If dRow("Print_bit") Is DBNull.Value Then
                    parPrintCheck.Value = False
                Else
                    parPrintCheck.Value = dRow("Print_bit")
                End If
                cmdUserRight.Parameters.Add(parFormID)
                cmdUserRight.Parameters.Add(parUserID)
                cmdUserRight.Parameters.Add(parProjectID)
                cmdUserRight.Parameters.Add(parViewCheck)
                cmdUserRight.Parameters.Add(parNewCheck)
                cmdUserRight.Parameters.Add(parEditCheck)
                cmdUserRight.Parameters.Add(parDeleteCheck)
                cmdUserRight.Parameters.Add(parPrintCheck)
                cmdUserRight.ExecuteNonQuery()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertUserRightOnControls()

        Try
            Dim cmdUserRightOnControls As New Oracle.DataAccess.Client.OracleCommand()

            cnUser.Open()
            trnUser = cnUser.BeginTransaction()
            cmdUserRightOnControls.Connection = cnUser
            cmdUserRightOnControls.Transaction = trnUser

            cmdUserRightOnControls.CommandType = Data.CommandType.StoredProcedure

            Dim parUSERID As New OracleParameter("USERID_", OracleDbType.Int64)
            Dim parUSERPROJECTID As New OracleParameter("USERPROJECTID_", OracleDbType.Int32)

            parUSERID.Value = UserID


            If dtUserprojectBy.Rows.Count > 0 Then
                parUSERPROJECTID.Value = dtUserprojectBy.Rows(0)("USERPROJECTID")
            End If


            cmdUserRightOnControls.CommandText = "usp_InsertUserRightonControls"

            Try
                cmdUserRightOnControls.Parameters.Clear()
                cmdUserRightOnControls.Parameters.Add(parUSERID)
                cmdUserRightOnControls.Parameters.Add(parUSERPROJECTID)
                cmdUserRightOnControls.ExecuteNonQuery()
                trnUser.Commit()

            Catch ex As Exception
                trnUser.Rollback()
                Throw ex
            End Try
            cnUser.Close()
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Public Sub DeleteUserRightOnControls()
        Try
            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            Dim trnUser As OracleTransaction

            parUserID.Value = UserID
            cnUser.Open()

            trnUser = cnUser.BeginTransaction()
            cmdUser.Transaction = trnUser
            Try

                cmdUser.Connection = cnUser
                cmdUser.CommandType = Data.CommandType.StoredProcedure

                cmdUser.CommandText = "usp_DeleteUserRightonControls"
                cmdUser.Parameters.Add(parUserID)
                cmdUser.ExecuteNonQuery()

                trnUser.Commit()
            Catch ex As Exception
                trnUser.Rollback()
                Throw ex
            End Try
            cnUser.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteUser()
        Try
            Dim cmdUser As New Oracle.DataAccess.Client.OracleCommand()

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)

            Dim trnUser As OracleTransaction

            parUserID.Value = UserID
            cnUser.Open()

            trnUser = cnUser.BeginTransaction()
            cmdUser.Transaction = trnUser
            Try

                cmdUser.Connection = cnUser
                cmdUser.CommandType = Data.CommandType.StoredProcedure

                cmdUser.CommandText = "usp_DeleteUser"
                cmdUser.Parameters.Add(parUserID)
                cmdUser.ExecuteNonQuery()

                trnUser.Commit()
            Catch ex As Exception
                trnUser.Rollback()
            End Try
            cnUser.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
