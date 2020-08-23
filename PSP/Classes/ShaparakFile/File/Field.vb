Namespace File

    Public MustInherit Class Field
#Region "Properties"

#End Region


#Region "Constructor"

#End Region

#Region "AbstractMethods"
        Public MustOverride Function GetValue(ByVal dataRow As DataRow) As String
        Public MustOverride Function GetValueByte(ByVal dataRow As DataRow) As Byte()
        Public MustOverride Function GetValue(ByVal obj As Object) As String
        Public MustOverride Function GetValueByte(ByVal obj As Object) As Byte()
#End Region
    End Class

End Namespace




