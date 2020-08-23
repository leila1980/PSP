Partial Class DSReport

    Partial Class dtProjectDataTable

        Private Sub dtProjectDataTable_dtProjectRowChanging(ByVal sender As System.Object, ByVal e As dtProjectRowChangeEvent) Handles Me.dtProjectRowChanging

        End Sub

    End Class

    Partial Class dtgetoutlettranmonthlyDataTable

        Private Sub dtgetoutlettranmonthlyDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.sesfandColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class dttest1DataTable


    End Class

    Partial Class dtTransPerBranchDataTable

        Private Sub dtTransPerBranchDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TrnsAvgColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class dtTejaratBankMontlyDataTable

    End Class

    Partial Class dtAgentTakhsisDiscordantDataTable

        Private Sub dtAgentTakhsisDiscordantDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.address_nvcColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class dtAgentActivityByTrnsDataTable

        Private Sub dtAgentActivityByTrnsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.LowTransPosSumColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class dtTransaction_Amount_LimitedDataTable

        Private Sub dtTransaction_Amount_LimitedDataTable_dtTransaction_Amount_LimitedRowChanging(ByVal sender As System.Object, ByVal e As dtTransaction_Amount_LimitedRowChangeEvent) Handles Me.dtTransaction_Amount_LimitedRowChanging

        End Sub

    End Class

    Partial Class dtStore_Device_Install_HistoryAtuoRriazationDataTable



    End Class

    Partial Class dtContractingPary_Contract_Account_Store_Device_PosDataTable






    End Class

    Partial Class dtContractingParty_Contract_Account_StoreDataTable



    End Class

    Partial Class dtGetAllContractingParty_Contract_Account_Store_Device_Pos_installingDetailDataTable

      

    End Class

End Class
