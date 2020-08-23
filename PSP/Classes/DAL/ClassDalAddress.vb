Imports Oracle.DataAccess.Client


Public Class ClassDalAddress
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Public Sub New(ByVal cs As String)
        MyBase.new(cs)
    End Sub
#Region "Property"

    Private mvarAddressID As Int32
    Public Property AddressID() As Int32
        Get
            Return mvarAddressID
        End Get
        Set(ByVal value As Int32)
            mvarAddressID = value
        End Set
    End Property

    Private mvarCode_NVC As String
    Public Property Code_NVC() As String
        Get
            Return mvarCode_NVC
        End Get
        Set(ByVal value As String)
            mvarCode_NVC = value
        End Set
    End Property

    Private mvarName_NVC As String
    Public Property Name_NVC() As String
        Get
            Return mvarName_NVC
        End Get
        Set(ByVal value As String)
            mvarName_NVC = value
        End Set
    End Property


    Private mvarPriority As Int32
    Public Property Priority() As Int32
        Get
            Return mvarPriority
        End Get
        Set(ByVal value As Int32)
            mvarPriority = value
        End Set
    End Property

    Private mvarPerfix_bit As Integer
    Public Property Perfix_BIT() As Integer
        Get
            Return mvarPerfix_bit
        End Get
        Set(ByVal value As Integer)
            mvarPerfix_bit = value
        End Set
    End Property

    Private mvarCode As String

    Public Property Code() As String
        Get
            Return mvarCode
        End Get
        Set(ByVal value As String)
            mvarCode = value
        End Set
    End Property

    Private mvarAddress3_nvc As String
    Public Property Address3_nvc() As String
        Get
            Return mvarAddress3_nvc
        End Get
        Set(ByVal value As String)
            mvarAddress3_nvc = value
        End Set
    End Property

    Enum MyEnum As Short
        perfixOne = 1
        perfixTwo = 2
    End Enum


    Private dtaddress As New DataTable
    Private newAddressDesc As String
#End Region


#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtaddress As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetAllAddress_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtaddress, parRefCursor)
            Return dtaddress
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAddressForPrefix(ByVal Perfix As Integer, Optional ByVal priority As Integer = 0) As DataTable
        Try
            Dim dtAddress As New DataTable
            Dim parPerfix As New OracleParameter(":PERFIX_BIT", OracleDbType.Int16)
            parPerfix.Value = Perfix

            Dim parPriority As New OracleParameter(":PERFIX_BIT", OracleDbType.Int16)
            parPriority.Value = priority

            If priority = 0 Then
                strSQL = "select name_nvc,code_nvc,priority from address_t  where perfix_bit=:PERFIX_BIT  "
                Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dtAddress, parPerfix)

            Else
                strSQL = "select name_nvc,code_nvc,priority from address_t  where perfix_bit=:PERFIX_BIT and  priority>:priority or priority=:priority"
                Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dtAddress, parPerfix, parPriority)
            End If

            Return dtAddress
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConvertAddressCodeToDescription(ByVal addressparameter As String) As DataTable
        Try
            Dim dtAddress As New DataTable
            Dim parameters() As String = addressparameter.Split("،")
            With dtAddress.Columns
                .Add("col1")
                .Add("col2")
                .Add("col3")
            End With
            For Each item As String In parameters

                If item.IndexOf("&") = 0 Then
                    item = item.Substring(1, item.Length - 1)
                End If

                Dim param() As String = item.Split("&")

                '    For i As Integer = 0 To param.Length - 3
                If param.Length = 3 Then
                    dtAddress.Rows.Add(param(0).Trim, param(1).Trim, param(2).Trim)
                ElseIf param.Length = 2 Then
                    dtAddress.Rows.Add(param(0).Trim, param(1).Trim)
                End If
                '  Next
            Next
            Return dtAddress ''
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetNameFromCode(ByVal value As String, ByVal Perfix As Integer) As String
        Dim dtAddress As New DataTable
        Dim param As String = Nothing
        Dim parValue As New OracleParameter("code_nvc_", OracleDbType.Varchar2, 12)
        parValue.Value = value
        Dim parPerfix As New OracleParameter("PERFIX_BIT_", OracleDbType.Int16)
        parPerfix.Value = Perfix
        Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

        strSQL = "GtAddressAccStrDvcPosSP"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtAddress, parValue, parPerfix, parRefCursor)

        If dtAddress.Rows.Count > 0 Then
            param = dtAddress.Rows(0).Item(0).ToString()
        Else
            param = "خالی"
        End If

        Return param
    End Function

    Public Function loadAddressDesc(ByVal value As String) As String
        '////کد آدرس
        Try

            dtaddress = ConvertAddressCodeToDescription(value)
            newAddressDesc = Nothing

            Dim param As String = Nothing

            If Not dtaddress.Rows.Count > 0 Then
                '   ShowErrorMessage("عدم صحت آدرس")
                Return value
                Exit Function
            End If

            For Each row As DataRow In dtaddress.Rows
                If row.ItemArray(2).ToString = Nothing Then
                    If row.ItemArray(0) Then
                        FillcboAddress(row.ItemArray(0), MyEnum.perfixTwo, param)
                        newAddressDesc += param & Space(1)
                    End If
                    newAddressDesc = newAddressDesc & row.ItemArray(1).ToString & Space(1) & "،"
                Else

                    If Not String.IsNullOrEmpty(row.ItemArray(0)) Then
                        FillcboAddress(row.ItemArray(0), MyEnum.perfixOne, param)
                        newAddressDesc += param & Space(1)
                    End If
                    If Not String.IsNullOrEmpty(row.ItemArray(1)) Then
                        FillcboAddress(row.ItemArray(1), MyEnum.perfixTwo, param)
                        newAddressDesc += param & Space(1)
                    End If
                    newAddressDesc = newAddressDesc & row.ItemArray(2).ToString & Space(1) & "،"

                End If
            Next
            '////شرح آدرس
            Return newAddressDesc.Substring(0, newAddressDesc.Length - 1)
        Catch ex As Exception
            Return value
        End Try
        
    End Function
    Private Function FillcboAddress(ByVal value As String, ByVal Perfix As Integer, ByRef param As String)
        Try
            BeginProc()
            param = Nothing
            param = GetNameFromCode(value, Perfix)
            Return param
        Catch ex As Exception
            Throw ex
        Finally
            EndProc()
        End Try
    End Function


#End Region


End Class
