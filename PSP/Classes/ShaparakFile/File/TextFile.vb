Namespace File

    Public Class TextFile
        Inherits File


#Region "Fields"
        Private _rowDelimiter As String
#End Region

#Region "Properties"

        Public Property RowDelimiter() As String
            Get
                Return _rowDelimiter
            End Get
            Set(ByVal value As String)
                _rowDelimiter = value
            End Set
        End Property

#End Region

#Region "Constructor"
        Public Sub New(ByVal path As String, ByVal fields As List(Of Field), ByVal rowDelimiter As String)
            MyBase.New(path, fields)
            Me.RowDelimiter = rowDelimiter
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

