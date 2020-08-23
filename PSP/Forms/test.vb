'Imports AcceptorManagement_2
Imports System.Data
Imports Oracle.DataAccess.Client
Imports System.Data.SqlClient

Imports RIZNARM.Data.Oracle_Client


Public Class test
    Protected Shared connection As OracleConnection
    Protected Shared command As OracleCommand
    Protected Shared dataAdapter As OracleDataAdapter
    Protected Shared Transaction As OracleTransaction
    Protected Shared OwnerObject As Integer
    'Protected Shared OwnerDataacess As DataAccess

    Private Shared ConnectionString As String
    Private _hasSqlErrorOccured As Boolean

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    'Dim _AcceptorManagementService As New AcceptorManagementServiceService
    '    'Dim _rq As New acceptorManagementRq
    '    'Dim _cardAcceptor As New cardAcceptorDTO
    '    '_rq.cardAcceptor = _cardAcceptor
    '    '_rq.cardAcceptor.id = "MERCHANT1410986"

    '    'Dim _getCardAcceptorDetailByIDResponse As New getCardAcceptorDetailByIDResponse
    '    'Dim _getCardAcceptorDetailByID As New getCardAcceptorDetailByID
    '    'Dim _getCardAcceptorDetailByIDRs As New acceptorManagementRs
    '    '_getCardAcceptorDetailByID.AcceptorManagementRq = _rq
    '    '_getCardAcceptorDetailByIDResponse = _AcceptorManagementService.getCardAcceptorDetailByID(_getCardAcceptorDetailByID)
    '    '_getCardAcceptorDetailByIDRs = _getCardAcceptorDetailByIDResponse.return
    '    'If _getCardAcceptorDetailByIDRs.responseCode = responseCode.DoneSuccessfully Then
    '    '    _cardAcceptor = _getCardAcceptorDetailByIDRs.cardAcceptor
    '    '    MsgBox(_cardAcceptor.businessCode)
    '    'Else
    '    '    MsgBox("not worked!!!")
    '    'End If
    '    'DataGridView1.DataSource = _getCardAcceptorDetailByIDRs.terminalList
    '    '===========================================================================
    '    'Dim _AcceptorManagementService As New AcceptorManagementServiceService
    '    'Dim _cardAcceptor As New cardAcceptorDTO

    '    'Dim _getCardAcceptorDetailByTerminalIDResponse As New getCardAcceptorDetailByTerminalIDResponse
    '    'Dim _getCardAcceptorDetailByTerminalID As New getCardAcceptorDetailByTerminalID
    '    'Dim _getCardAcceptorDetailByTerminalIDRs As New acceptorManagementRs
    '    '_getCardAcceptorDetailByTerminalID.TerminalID = "P0000126" '"P1410986"
    '    '_getCardAcceptorDetailByTerminalIDResponse = _AcceptorManagementService.getCardAcceptorDetailByTerminalID(_getCardAcceptorDetailByTerminalID)
    '    '_getCardAcceptorDetailByTerminalIDRs = _getCardAcceptorDetailByTerminalIDResponse.return
    '    'If _getCardAcceptorDetailByTerminalIDRs.responseCode = responseCode.DoneSuccessfully Then
    '    '    _cardAcceptor = _getCardAcceptorDetailByTerminalIDRs.cardAcceptor
    '    '    MsgBox(_cardAcceptor.businessCode)
    '    'Else
    '    '    MsgBox("not worked!!!")
    '    'End If
    '    'DataGridView1.DataSource = _getCardAcceptorDetailByTerminalIDRs.terminalList

    '    ''===========================================================================
    '    'Dim _AcceptorManagementService As New AcceptorManagementServiceService
    '    'Dim _terminal As New terminalDTO

    '    'Dim _getTerminalDetailByIDResponse As New getTerminalDetailByIDResponse
    '    'Dim _getTerminalDetailByID As New getTerminalDetailByID
    '    'Dim _getTerminalDetailByIDRs As New acceptorManagementRs
    '    '_getTerminalDetailByID.TerminalID = "P0000126" '"P1410986"
    '    '_getTerminalDetailByIDResponse = _AcceptorManagementService.getTerminalDetailByID(_getTerminalDetailByID)
    '    '_getTerminalDetailByIDRs = _getTerminalDetailByIDResponse.return
    '    'If _getTerminalDetailByIDRs.responseCode = responseCode.DoneSuccessfully Then
    '    '    _terminal = _getTerminalDetailByIDRs.terminal
    '    '    MsgBox(_terminal.peerName)
    '    'Else
    '    '    MsgBox("not worked!!!")
    '    'End If
    '    ''===========================================================================
    '    ''===========================================================================
    '    ''===========================================================================
    '    Dim _AcMgService As New AcceptorManagement_2.AcceptorManagementServiceService

    '    Dim _rq As New AcceptorManagementService.acceptorManagementRq

    '    Dim _cardAcceptor As New AcceptorManagement_2.cardAcceptorDTO
    '    Dim _institution As New AcceptorManagement_2.institutionDTO
    '    Dim _externalAccount As New AcceptorManagement_2.externalAccountDTO
    '    Dim _terminal As New AcceptorManagement_2.terminalDTO

    '    Dim _allocateTerminal2CardAcceptor_rs As New AcceptorManagement_2.allocateTerminal2CardAcceptorResponse
    '    Dim _allocateTerminal2CardAcceptor As New AcceptorManagement_2.allocateTerminal2CardAcceptor


    '    Dim _defineCardAcceptorAndAllocateTerminal_rs As New AcceptorManagement_2.defineCardAcceptorAndAllocateTerminalResponse
    '    Dim _defineCardAcceptorAndAllocateTerminal As New AcceptorManagement_2.defineCardAcceptorAndAllocateTerminal

    '    Dim _defineCardAcceptorAndAllocateTerminal_responseCode As AcceptorManagement_2.responseCode

    '    _rq.cardAcceptor = _cardAcceptor
    '    _rq.cardAcceptor.inst = _institution
    '    _rq.cardAcceptor.setlAcnt = _externalAccount
    '    _rq.terminal = _terminal

    '    Dim Switch_CardAcceptorID As String = "MERCHANT1900002"
    '    Dim Switch_TerminalID As String = "P1900002"
    '    Dim Serial As String = "2100002"
    '    Dim Switch_FeeID_int As Int32 = 1000

    '    _rq.cardAcceptor.businessCode = 1000
    '    _rq.cardAcceptor.id = Switch_CardAcceptorID
    '    _rq.cardAcceptor.inst.institutionAddress = "تست آدرس"
    '    _rq.cardAcceptor.inst.institutionCellphoneNumber = "0912"
    '    _rq.cardAcceptor.inst.institutionEmailAddress = "yahoo"
    '    ' _rq.cardAcceptor.inst.institutionID=
    '    _rq.cardAcceptor.inst.institutionIIN = 627961
    '    _rq.cardAcceptor.inst.institutionLatinAddress = String.Empty
    '    _rq.cardAcceptor.inst.institutionLatinName = String.Empty
    '    _rq.cardAcceptor.inst.institutionName = "تست"
    '    _rq.cardAcceptor.inst.institutionPhone = "88795642"

    '    _rq.cardAcceptor.inst.institutionType = institutionType.CardAcceptor
    '    _rq.cardAcceptor.inst.institutionTypeSpecified = True
    '    _rq.cardAcceptor.inst.institutionWebAddress = String.Empty
    '    _rq.cardAcceptor.reconciliationCycleLenght = 1
    '    _rq.cardAcceptor.setlAcnt.externalAccountBankBranchID = "000012"
    '    _rq.cardAcceptor.setlAcnt.externalAccountBankID = 11
    '    _rq.cardAcceptor.setlAcnt.externalAccountNumber = "0000000000"
    '    _rq.cardAcceptor.setlAcnt.externalAccountTitle = "کوتاه مدت"
    '    _rq.cardAcceptor.settlementMethodSpecified = True
    '    _rq.cardAcceptor.settlementMethod = settlementMethodType.Manual
    '    _rq.cardAcceptor.status = activeInactive.Active
    '    _rq.cardAcceptor.statusSpecified = True

    '    _rq.cardAcceptor.setlAcnt.externallAccountType = accountTypeCodeEnum.InvestmentAccount
    '    '_rq.cardAcceptor.setlAcnt.externallAccountType = accountTypeCodeEnum.PAN
    '    _rq.cardAcceptor.setlAcnt.externallAccountTypeSpecified = True
    '    _rq.cardAcceptor.settlementTime = "22:30:00"
    '    _rq.cardAcceptor.paymentMethodSpecified = True
    '    _rq.cardAcceptor.paymentMethod = paymentMethodType.Online_Transfer_Txn


    '    _rq.terminal.applicationReleaseDate = String.Empty
    '    _rq.terminal.applicationVersion = String.Empty
    '    _rq.terminal.dnsName = String.Empty
    '    _rq.terminal.id = Switch_TerminalID
    '    _rq.terminal.IPAddress = String.Empty

    '    _rq.terminal.peerName = "تست ف"
    '    _rq.terminal.peerType = peerType.Terminal
    '    _rq.terminal.peerTypeSpecified = True
    '    _rq.terminal.serialNo = Serial
    '    _rq.terminal.systemAuditNumber = 0



    '    _defineCardAcceptorAndAllocateTerminal.AcceptorManagementRq = _rq
    '    _defineCardAcceptorAndAllocateTerminal_rs = _AcMgService.defineCardAcceptorAndAllocateTerminal(_defineCardAcceptorAndAllocateTerminal)
    '    _defineCardAcceptorAndAllocateTerminal_responseCode = _defineCardAcceptorAndAllocateTerminal_rs.return.responseCode

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim str_Guid As String
        'str_Guid = InsertGUID()
        MessageBox.Show(str_Guid)

    End Sub

    Private Function InsertGUID() As String
        'Try

        '    Dim Title_Fa_nvc As New OracleParameter("Title_Fa_nvc_", OracleDbType.Varchar2, 100)
        '    Title_Fa_nvc.Value = "تست"


        '    Dim Title_En_nvc As New OracleParameter("Title_En_nvc_", OracleDbType.Varchar2, 100)
        '    Title_En_nvc.Value = "Test"

        '    Dim BankID As New OracleParameter("BankID_", OracleDbType.Int32)
        '    BankID.Value = 1

        '    Dim ActiveState As New OracleParameter("ActiveState_", OracleDbType.Char, 1)
        '    ActiveState.Value = "N"


        '    Dim BranchID As New OracleParameter("BranchID_", OracleDbType.Raw, 16)
        '    BranchID.Direction = ParameterDirection.Output

        '    Dim strSQL As String
        '    strSQL = "InsertBranch_New_SP"

        '    'Title_Fa_nvc_ IN NVARCHAR2,
        '    'Title_En_nvc_ IN NVARCHAR2,
        '    'BankID_ IN NUMBER,
        '    '--ContractDate_vc_ IN VARCHAR2, 
        '    'ActiveState_     IN char ,
        '    'BranchID_ OUT RAW(16)


        '    Dim da As New DataAccess("Persist Security Info=False;User ID=psptejarat;Password=oracle;Data Source=192.168.40.55/dbpsp")
        '    da.Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
        '                     , strSQL, Title_Fa_nvc, Title_En_nvc, BankID, ActiveState, BranchID)

        Return "" 'BranchID.Value.ToString()

        'Catch ex As Exception
        '    Throw ex
        'End Try

    End Function

   

End Class