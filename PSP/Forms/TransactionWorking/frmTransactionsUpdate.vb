'Imports MonitoringService
Public Class frmTransactionsUpdate
    Dim clsDalTransaction As New ClassDALTransaction(modPublicMethod.ConnectionString)
    'Dim Str As String = "Insert Into Openrowset('SQLOLEDB','Netsisserver\sql2005';'mhosseini';'pspmaskan',CallCenter.dbo.temp_test_1) " & _
    '                    "(temname) " & _
    '                    "Select Case firstname_nvc " & _
    '                    "From Visitor_T  "
    'Dim osqlParams As String = ""
    '    If (isWinAuth) Then
    '        osqlParams = String.Format("-E -d {0} -i ", dbName)
    '    Else
    '        osqlParams = String.Format("-U {0} -P {1} -d {2} -q ", login, pwd, _
    '            dbName)
    '    End If
    'Dim proc As New Process
    '    proc.StartInfo.FileName = "osql.exe"
    '    proc.StartInfo.CreateNoWindow = True
    '    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '    proc.StartInfo.Arguments = osqlParams & """" & Str + """"
    '    proc.Start()
    '    proc.WaitForExit()

  
    '==================With WebService
    'Dim _MonitoringService As New MonitoringServiceService
    'Dim _rq As New monitoringRq
    'Dim _essCurTransaction As essCurrentTransaction
    'Dim _essCurTransactionList() As essCurrentTransaction

    'Dim _getTransactionList_rs As New getTransactionListResponse
    'Dim _getTransactionList As New getTransactionList
    'Dim _monitoringRs As MonitoringService.monitoringRs

    '_essCurTransaction.id.transactionTimeFrom = convertToMiladi(1)
    '_essCurTransaction.id.transactionTimeTo = convertToMiladi(2)
    '_rq.transactionFilter.essCurrentTransaction = _essCurTransaction
    '_getTransactionList.MonitoringRq = _rq
    '_getTransactionList_rs = _MonitoringService.getTransactionList(_getTransactionList)
    '_monitoringRs = _getTransactionList_rs.return
    '_essCurTransactionList = _monitoringRs.essCurrentTransactionList
    'For i As Int32 = 0 To _essCurTransactionList.Length - 1
    '    clsDalTransaction.ACC_NAME = _essCurTransactionList(i).id.accName
    '    clsDalTransaction.ACCOUNT = _essCurTransactionList(i).id.account
    '    clsDalTransaction.ACTION = _essCurTransactionList(i).id.action
    '    clsDalTransaction.ACTION_CODE = _essCurTransactionList(i).id.actionCode
    '    clsDalTransaction.AMOUNT = _essCurTransactionList(i).id.amount
    '    clsDalTransaction.CARD_NUMBER = _essCurTransactionList(i).id.cardNumber

    '    clsDalTransaction.LOCAL_DATE = _essCurTransactionList(i).id.localDate
    '    clsDalTransaction.LOCAL_DATE_FA = converttoshamsi(_essCurTransactionList(i).id.localDateFa)
    '    clsDalTransaction.MCC = _essCurTransactionList(i).id.mcc
    '    clsDalTransaction.MTI = _essCurTransactionList(i).id.mti
    '    clsDalTransaction.OUTLET = _essCurTransactionList(i).id.outlet
    '    clsDalTransaction.PC = _essCurTransactionList(i).id.pc
    '    clsDalTransaction.REFERENCE = _essCurTransactionList(i).id.reference
    '    clsDalTransaction.REVERSAL_FLAG = _essCurTransactionList(i).id.reversalFlag
    '    clsDalTransaction.ROUTING_CODE = _essCurTransactionList(i).id.routingCode
    '    clsDalTransaction.STAN = _essCurTransactionList(i).id.stan
    '    clsDalTransaction.TRANSACTION_TIME = _essCurTransactionList(i).id.transactionTime
    '    clsDalTransaction.TRANSACTION_TIME_FA = converttoshamsi(_essCurTransactionList(i).id.transactionTimeFa)

    'Next
    '==================With WebService==========================================================================
End Class