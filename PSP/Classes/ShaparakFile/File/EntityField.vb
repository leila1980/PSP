Imports System.Reflection
Imports System.Data
Namespace File

    Public Class EntityField
        Inherits Field


#Region "Properties"

        Private _fieldName As String

#End Region

#Region "Properties"
        Public Property FieldName() As String
            Get
                Return _fieldName
            End Get
            Set(ByVal value As String)
                _fieldName = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Public Sub New(ByVal fieldName As String)
            Me.FieldName = fieldName
        End Sub
#End Region

#Region "AbstractMethods"

        Public Overloads Overrides Function GetValue(ByVal obj As Object) As String
            Dim objectType As Type = obj.GetType
            Dim propertyInfo As PropertyInfo = objectType.GetProperty(FieldName)
            Return propertyInfo.GetValue(obj, Nothing).ToString.Trim
        End Function

        Public Overloads Overrides Function GetValue(ByVal dataRow As DataRow) As String
            Return dataRow(FieldName).ToString.Trim
        End Function

        Public Overloads Overrides Function GetValueByte(ByVal obj As Object) As Byte()
            Dim objectType As Type = obj.GetType
            Dim propertyInfo As PropertyInfo = objectType.GetProperty(FieldName)
            Dim result As String = propertyInfo.GetValue(obj, Nothing).ToString.Trim
            Return System.Text.ASCIIEncoding.UTF8.GetBytes(result)
        End Function

        Public Overloads Overrides Function GetValueByte(ByVal dataRow As System.Data.DataRow) As Byte()
            Dim result As String = dataRow(FieldName).ToString.Trim
            Return System.Text.ASCIIEncoding.UTF8.GetBytes(result)
        End Function

#End Region

    End Class


    Public Class Person

    End Class
End Namespace

