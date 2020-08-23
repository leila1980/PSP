Imports File

Public Class StaticField
    Inherits Field

#Region "Fields"
    Private _values As String
#End Region

#Region "Properties"
    Public Property Value() As String
        Get
            Return _values
        End Get
        Set(ByVal value As String)
            _values = value
        End Set
    End Property
#End Region

#Region "Methods"

    Public Overloads Overrides Function GetValue(ByVal obj As Object) As String
        Return Value.ToString
    End Function

    Public Overloads Overrides Function GetValue(ByVal dataRow As System.Data.DataRow) As String
        Return Value.ToString
    End Function

    Public Overloads Overrides Function GetValueByte(ByVal obj As Object) As Byte()
        Return System.Text.ASCIIEncoding.UTF8.GetBytes(Value.ToString)
    End Function

    Public Overloads Overrides Function GetValueByte(ByVal dataRow As System.Data.DataRow) As Byte()
        Return System.Text.ASCIIEncoding.UTF8.GetBytes(Value.ToString)
    End Function

#End Region

End Class
