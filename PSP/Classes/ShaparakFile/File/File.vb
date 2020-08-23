Imports System.Collections.Generic
Imports System.IO

Namespace File

    Public MustInherit Class File

#Region "Fields"
        Private _path As String
        Private _fields As List(Of Field)
        Private _file As IO.StreamWriter
        Private _streamWriter As IO.StreamWriter
#End Region

#Region "Properties"
        Public Property Path() As String
            Get
                Return _path
            End Get
            Set(ByVal value As String)
                _path = value
            End Set
        End Property

        Public Property Fields() As List(Of Field)
            Get
                Return _fields
            End Get
            Set(ByVal value As List(Of Field))
                _fields = value
            End Set
        End Property

        Public ReadOnly Property File() As IO.StreamWriter
            Get
                If _file Is Nothing Then
                    _file = New IO.StreamWriter(Path, False, System.Text.Encoding.Default)

                End If
                Return _file
            End Get
        End Property
      
#End Region

#Region "Constructor"

        Public Sub New(ByVal path As String, ByVal fields As List(Of Field))
            Me.Path = path
            Me.Fields = fields
        End Sub

#End Region

#Region "AbstractMethods"
        Public MustOverride Sub Write(ByVal dataTable As DataTable)
        Public MustOverride Sub Write(ByVal objects As List(Of Object))
#End Region

          
        

    End Class

End Namespace

