Imports System.Text
Imports System.Collections.Generic
Imports System.Data
Imports System.IO


Namespace File

    Public Class DelimitedFile
        Inherits TextFile


#Region "Fields"
        Private _columnDelimiter As String
        Private _showDelimiter As Boolean
#End Region

#Region "Properties"

        Public Property ColumnDelimiter() As String
            Get
                Return _columnDelimiter
            End Get
            Set(ByVal value As String)
                _columnDelimiter = value
            End Set
        End Property

        Public Property ShowDelimiter() As Boolean
            Get
                Return _showDelimiter
            End Get
            Set(ByVal value As Boolean)
                _showDelimiter = value
            End Set
        End Property

#End Region


#Region "Constructor"
        Public Sub New(ByVal path As String, ByVal fields As List(Of Field), ByVal rowDelimiter As String, ByVal columnDelimiter As String, ByVal showDelimiter As Boolean)
            MyBase.New(path, fields, rowDelimiter)
            Me.ColumnDelimiter = columnDelimiter
            Me.ShowDelimiter = showDelimiter
        End Sub
#End Region

#Region "AbstractMethods"

        Public Overloads Overrides Sub Write(ByVal objects As List(Of Object))

            For i As Integer = 0 To objects.Count - 1
                For j As Integer = 0 To MyBase.Fields.Count - 1
                    Dim fieldsBytes As String = Fields(j).GetValue(objects(i))
                    File.Write(fieldsBytes)

                    If ShowDelimiter = False And j = MyBase.Fields.Count - 1 Then
                        Continue For
                    Else
                        File.Write(ColumnDelimiter)
                    End If
                Next

                If i < objects.Count - 1 Then
                    File.Write(RowDelimiter)
                End If
            Next
            File.Close()
        End Sub

        Public Overloads Overrides Sub Write(ByVal dataTable As DataTable)

            For i As Integer = 0 To dataTable.Rows.Count - 1
                For j As Integer = 0 To MyBase.Fields.Count - 1
                    Dim fieldsBytes As String = Fields(j).GetValue(dataTable.Rows(i))
                    File.Write(fieldsBytes)

                    If ShowDelimiter = False And j = MyBase.Fields.Count - 1 Then
                        Continue For
                    Else
                        File.Write(ColumnDelimiter)

                    End If
                Next

                If i < dataTable.Rows.Count - 1 Then
                    File.Write(RowDelimiter)
                End If
            Next

            File.Close()

        End Sub

#End Region
      
    End Class

End Namespace
