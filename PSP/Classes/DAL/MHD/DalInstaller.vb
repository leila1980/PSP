Imports Oracle.DataAccess.Client

Partial Class Dal
    Public Structure InstallerTemplat
        Dim InstallerID As Int64
        Dim FirstName_nvc As String
        Dim LastName_nvc As String
        Dim Tel_vc As String
        Dim Mobile_vc As String
        Dim Address_nvc As String
    End Structure

    Public Function Insert(ByVal Installer As InstallerTemplat) As Int64
        Try
            Dim parFirstName_nvc As New OracleParameter("@FirstName_nvc", OracleDbType.Varchar2, 100)
            parFirstName_nvc.Value = Installer.FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("@LastName_nvc", OracleDbType.Varchar2, 200)
            parLastName_nvc.Value = Installer.LastName_nvc

            Dim parTel_vc As New OracleParameter("@Tel_vc", OracleDbType.Varchar2, 20)
            parTel_vc.Value = Installer.Tel_vc

            Dim parMobile_vc As New OracleParameter("@Mobile_vc", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Installer.Mobile_vc

            Dim parAddress_nvc As New OracleParameter("@Address_nvc", OracleDbType.Varchar2, 500)
            parAddress_nvc.Value = Installer.Address_nvc

            Dim strSQL As String
            strSQL = "Insert into Installer_T(FirstName_nvc,LastName_nvc,Tel_vc,Mobile_vc,Address_nvc) "
            strSQL += "Values(@FirstName_nvc,@LastName_nvc,@Tel_vc,@Mobile_vc,@Address_nvc)"

            Me.Execute_NonQuery(CommandType.Text, strSQL, parFirstName_nvc, parLastName_nvc, parTel_vc, parMobile_vc, parAddress_nvc)

            strSQL = "Select @@Identity"
            Return Me.Execute_Scalar(CommandType.Text, strSQL, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Update(ByVal Installer As InstallerTemplat)
        Try
            Dim parInstallerId As New OracleParameter("@InstallerID", OracleDbType.Int64)
            parInstallerId.Value = Installer.InstallerID

            Dim parFirstName_nvc As New OracleParameter("@FirstName_nvc", OracleDbType.Varchar2, 100)
            parFirstName_nvc.Value = Installer.FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("@LastName_nvc", OracleDbType.Varchar2, 200)
            parLastName_nvc.Value = Installer.LastName_nvc

            Dim parTel_vc As New OracleParameter("@Tel_vc", OracleDbType.Varchar2, 20)
            parTel_vc.Value = Installer.Tel_vc

            Dim parMobile_vc As New OracleParameter("@Mobile_vc", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Installer.Mobile_vc

            Dim parAddress_nvc As New OracleParameter("@Address_nvc", OracleDbType.Varchar2, 500)
            parAddress_nvc.Value = Installer.Address_nvc

            Dim strSQL As String
            strSQL = "Update Installer_T Set FirstName_nvc=@FirstName_nvc,LastName_nvc=@LastName_nvc,"
            strSQL += "Tel_vc=@Tel_vc,Mobile_vc=@Mobile_vc,Address_nvc=@Address_nvc Where InstallerID=@InstallerID"

            Me.Execute_NonQuery(CommandType.Text, strSQL, parFirstName_nvc, parLastName_nvc, parTel_vc, parMobile_vc, parAddress_nvc, parInstallerId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Delete(ByVal Installer As InstallerTemplat)
        Try
            Dim parInstallerId As New OracleParameter("@InstallerID", OracleDbType.Int64)
            parInstallerId.Value = Installer.InstallerID

            Dim strSQL As String
            strSQL = "Delete From Installer_T Where InstallerID=@InstallerID"

            Me.Execute_NonQuery(CommandType.Text, strSQL, parInstallerId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAllInstaller() As DataTable
        Try
            Dim dt As New DataTable
            Dim strSQL As String
            strSQL = "Select *,(FirstName_nvc || ' ' || LastName_nvc) as FullName_nvc From Installer_T Order by LastName_nvc"
            Me.Fill(CommandType.Text, strSQL, dt)
            Return dt


        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllCMSPROJECT() As DataTable
        Try
            Dim dt As New DataTable
            Dim strSQL As String
            strSQL = "Select cmsprojectid_int, name_nvc From cmsproject_t order by cmsprojectid_int "
            Me.Fill(CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByInstallerIDInstaller(ByVal InstallerID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim strSQL As String
            strSQL = "Select *,(FirstName_nvc || ' ' || LastName_nvc) as FullName_nvc From Installer_T Where InstallerID=" & InstallerID.ToString
            Me.Fill(CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
