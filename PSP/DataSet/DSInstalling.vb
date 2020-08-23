Partial Class DataSet1
    Partial Class DTInstallInfoDataTable

        Private Sub DTInstallInfoDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ContractingPartyFullName_nvcColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class DTInstallingDataTable

        Private Sub DTInstallingDataTable_DTInstallingRowChanging(ByVal sender As System.Object, ByVal e As DTInstallingRowChangeEvent) Handles Me.DTInstallingRowChanging

        End Sub

    End Class

    Partial Class HeaderDataTable

    End Class

  

End Class
