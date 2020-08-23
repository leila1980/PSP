Namespace File

    Public Class ComputeField
        Inherits Field

#Region "Fields"
        Private _entityFields As List(Of EntityField)
        Private _funcString As Func(Of Object, String)
        Private _funcByte As Func(Of Object, Byte())
        Private _fieldName As String
#End Region

#Region "Properties"

        Public Property FuncString() As Func(Of Object, String)
            Get
                Return _funcString
            End Get
            Set(ByVal value As Func(Of Object, String))
                _funcString = value
            End Set
        End Property
        Public Property FuncByte() As Func(Of Object, Byte())
            Get
                Return _funcByte
            End Get
            Set(ByVal value As Func(Of Object, Byte()))
                _funcByte = value
            End Set
        End Property
        Public Property EntityFields() As List(Of EntityField)
            Get
                Return _entityFields
            End Get
            Set(ByVal value As List(Of EntityField))
                _entityFields = value
            End Set
        End Property

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
        Public Sub New(ByVal funcString As Func(Of Object, String), ByVal fieldName As String)
            Me.FuncString = funcString
            Me.FieldName = fieldName
            '  Me.EntityFields = entityFields
        End Sub
        Public Sub New(ByVal funcByte As Func(Of Object, Byte()), ByVal fieldName As String)
            Me.FuncByte = funcByte
            Me.FieldName = fieldName
            '  Me.EntityFields = entityFields
        End Sub
#End Region

#Region "AbstractMethods"

        Public Overloads Overrides Function GetValue(ByVal obj As Object) As String
            Dim objectType As Type = obj.GetType
            Dim propertyInfo As Reflection.PropertyInfo = objectType.GetProperty(FieldName)

            If FuncString IsNot Nothing Then
                Return FuncString.Invoke(propertyInfo.GetValue(obj, Nothing).ToString.Trim)
            End If
            Return String.Empty

        End Function

        Public Overloads Overrides Function GetValue(ByVal dataRow As DataRow) As String
            If FuncString IsNot Nothing Then
                Return FuncString.Invoke(dataRow(FieldName).ToString.Trim)
            End If
            Return String.Empty
        End Function

        Public Overloads Overrides Function GetValueByte(ByVal obj As Object) As Byte()
            Dim objectType As Type = obj.GetType
            Dim propertyInfo As Reflection.PropertyInfo = objectType.GetProperty(FieldName)
            Dim result As String = propertyInfo.GetValue(obj, Nothing).ToString.Trim


            If FuncByte IsNot Nothing Then
                Return System.Text.ASCIIEncoding.ASCII.GetBytes(FuncByte.Invoke(result).ToString.Trim)
            End If
            Return System.Text.ASCIIEncoding.ASCII.GetBytes(String.Empty)

        End Function

        Public Overloads Overrides Function GetValueByte(ByVal dataRow As System.Data.DataRow) As Byte()
            Dim result As String = dataRow(FieldName).ToString.Trim

            If FuncByte IsNot Nothing Then
                Return FuncByte.Invoke(result)
            End If
            Return System.Text.ASCIIEncoding.ASCII.GetBytes(String.Empty)

        End Function

#End Region
    End Class

End Namespace

