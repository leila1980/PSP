Namespace File

    Public Class FixedLengthFile
        Inherits TextFile

#Region "Properties"

#End Region


#Region "Constructor"
        Public Sub New(ByVal path As String, ByVal fields As List(Of Field), ByVal rowDelimiter As String)
            MyBase.New(path, fields, rowDelimiter)
        End Sub
#End Region

#Region "AbstractMethods"
        Public Overloads Overrides Sub Write(ByVal objects As System.Collections.Generic.List(Of Object))

        End Sub

        Public Overloads Overrides Sub Write(ByVal dataTable As System.Data.DataTable)

        End Sub
#End Region

    End Class

End Namespace

