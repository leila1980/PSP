Imports AcceptorManagementService
Imports Convertor

Public Class ClassBLLSwitch_AcceptorManagement

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalSwitchSend As New ClassDALSwitchSend(modPublicMethod.ConnectionString)
    Private clsBLLSwitch_FeeManagement As New ClassBLLSwitch_FeeManagement()


    Dim _AcceptorManagementServiceResponseCode As responseCode
    Dim _acceptorManagementRq As New acceptorManagementRq
    Dim _defineCardAcceptorAndAllocateTerminalResponse As New defineCardAcceptorAndAllocateTerminalResponse
    Dim _defineCardAcceptorAndAllocateTerminal As New defineCardAcceptorAndAllocateTerminal
    Dim _allocateTerminal2CardAcceptorResponse As New allocateTerminal2CardAcceptorResponse
    Dim _allocateTerminal2CardAcceptor As New allocateTerminal2CardAcceptor

    Dim _modifyCardAcceptorResponse As New modifyCardAcceptorResponse
    Dim _modifyCardAcceptor As New modifyCardAcceptor

    Dim _modifyTerminalSerialResponse As New modifyTerminalSerialResponse
    Dim _modifyTermianlSerial As New modifyTerminalSerial

    Dim _setTerminalToCancelledContractByTerminalIDResponse As New setTerminalToCancelledContractByTerminalIDResponse
    Dim _setTerminalToCancelledContractByTerminalID As New setTerminalToCancelledContractByTerminalID



    Dim _cardAcceptor As New cardAcceptorDTO
    Dim _terminal As New terminalDTO
    Dim _institution As New institutionDTO
    Dim _externalAccount As New externalAccountDTO

    Private mvarmurl As String
    Private mvarMobile As String
    Private mvarEmail As String
    Private mvarPostalCode As String
    Private mvarBranchID As String
    Private mvarAccountNO As String
    Private mvarAccountTypeName As String
    Private mvarStoreName As String
    Private mvarStoreAddress As String
    Private mvarStoreGroupID As String
    Private mvarStoreTel1 As String
    Private mvarSerialNo As String
    Private mvarDeviceID As Int64
    Private mvarSwitch_FeeID_int As Int32
    Private mvarSwitch_CardAcceptorID As String
    Private mvarSwitch_TerminalID As String
    Private mvarSwitch_ModifyID As Int64
    Private mvarSwitch_Modify_DeviceID As Int64
    Private Const constSwitchIIN As String = "581672061"
    Private Const constSwitchBankID As Short = 18
    Private Const constSwitchSettlementTime As String = "14:00:00"
    Private Const constDefaultSwitchFee = 1000
    Private Const consPaymentMethodtype As paymentMethodType = paymentMethodType.Offline_File_Txn
    Private Const consSettlementMethodType As settlementMethodType = settlementMethodType.Manual


    'Raeisi
    Private mvarSCityShaparakCode As String
    Private mvarSStateShaparakCode As String
    Private mvarShabaAccount As String
    Private mvarSCityName As String
    Private mvarSStateName As String
    Private mvarEnStoreName As String
    Private dtSwitch_CardAcceptorIDInfo As New DataTable
    Private dtSwitch_TerminalIDInfo As New DataTable


    'raeisi 

    Public Property mUrl() As String
        Get
            Return mvarmurl
        End Get
        Set(ByVal value As String)
            mvarmurl = value
        End Set
    End Property
    Public Property SCityName() As String
        Get
            Return mvarSCityName
        End Get
        Set(ByVal value As String)
            mvarSCityName = value
        End Set
    End Property
    Public Property SStateName() As String
        Get
            Return mvarSStateName
        End Get
        Set(ByVal value As String)
            mvarSStateName = value
        End Set
    End Property
    Public Property ShabaAccount() As String
        Get
            Return mvarShabaAccount
        End Get
        Set(ByVal value As String)
            mvarShabaAccount = value
        End Set
    End Property
    Public Property SCityShaparakCode() As String
        Get
            Return mvarSCityShaparakCode
        End Get
        Set(ByVal value As String)
            mvarSCityShaparakCode = value
        End Set
    End Property
    Public Property SStateShaparakCode() As String
        Get
            Return mvarSStateShaparakCode
        End Get
        Set(ByVal value As String)
            mvarSStateShaparakCode = value
        End Set
    End Property
    Public Property EnStoreName() As String
        Get
            Return mvarEnStoreName
        End Get

        Set(ByVal value As String)
            mvarEnStoreName = value
        End Set
    End Property

    Public Property Mobile() As String
        Get
            Return mvarMobile
        End Get
        Set(ByVal value As String)
            mvarMobile = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mvarEmail
        End Get
        Set(ByVal value As String)
            mvarEmail = value
        End Set
    End Property

    Public Property PostalCode() As String
        Get
            Return mvarPostalCode
        End Get
        Set(ByVal value As String)
            mvarPostalCode = value
        End Set
    End Property

    Public Property BranchID() As String
        Get
            Return mvarBranchID
        End Get
        Set(ByVal value As String)
            mvarBranchID = value
        End Set
    End Property
    Public Property AccountNO() As String
        Get
            Return mvarAccountNO
        End Get
        Set(ByVal value As String)
            mvarAccountNO = value
        End Set
    End Property
    Public Property AccountTypeName() As String
        Get
            Return mvarAccountTypeName
        End Get

        Set(ByVal value As String)
            mvarAccountTypeName = value
        End Set
    End Property
    Public Property StoreName() As String
        Get
            Return mvarStoreName
        End Get

        Set(ByVal value As String)
            mvarStoreName = value
        End Set
    End Property
    Public Property StoreAddress() As String
        Get
            Return mvarStoreAddress
        End Get

        Set(ByVal value As String)
            mvarStoreAddress = value
        End Set
    End Property
    Public Property StoreGroupID() As String
        Get
            Return mvarStoreGroupID
        End Get

        Set(ByVal value As String)
            mvarStoreGroupID = value
        End Set
    End Property
    Public Property StoreTel1() As String
        Get
            Return mvarStoreTel1
        End Get

        Set(ByVal value As String)
            mvarStoreTel1 = value
        End Set
    End Property
    Public Property SerialNo() As String
        Get
            Return mvarSerialNo
        End Get
        Set(ByVal value As String)
            mvarSerialNo = value
        End Set
    End Property
    Public Property DeviceID() As Int64
        Get
            Return mvarDeviceID
        End Get

        Set(ByVal value As Int64)
            mvarDeviceID = value
        End Set
    End Property
    Public Property Switch_FeeID_int() As Int32
        Get
            Return mvarSwitch_FeeID_int
        End Get

        Set(ByVal value As Int32)
            mvarSwitch_FeeID_int = value
        End Set
    End Property
    Public Property Switch_CardAcceptorID() As String
        Get
            Return mvarSwitch_CardAcceptorID
        End Get

        Set(ByVal value As String)
            mvarSwitch_CardAcceptorID = value
        End Set
    End Property
    Public Property Switch_TerminalID() As String
        Get
            Return mvarSwitch_TerminalID
        End Get

        Set(ByVal value As String)
            mvarSwitch_TerminalID = value
        End Set
    End Property
    Public Property Switch_ModifyID() As Int64
        Get
            Return mvarSwitch_ModifyID
        End Get
        Set(ByVal value As Int64)
            mvarSwitch_ModifyID = value
        End Set
    End Property
    Public Property Switch_Modify_DeviceID() As Int64
        Get
            Return mvarSwitch_Modify_DeviceID
        End Get
        Set(ByVal value As Int64)
            mvarSwitch_Modify_DeviceID = value
        End Set
    End Property


    Public Sub OnlyAllocateTerminal(ByVal Url As String)
        Dim _AcceptorManagementService As New AcceptorManagementServiceService()
        Dim GetNewSwithTerminalID As Boolean = True
        While GetNewSwithTerminalID = True
            Try
                GetNewSwithTerminalID = False
                clsDalContract.BeginProc()
                clsDalContract.DSwitch_CardAcceptorID_vc = Me.Switch_CardAcceptorID
                clsDalContract.DSwitch_TerminalID_vc = Me.Switch_TerminalID
                clsDalContract.DDeviceID = Me.DeviceID
                clsDalContract.UpdateDevice_CardAcceptorIDAndTerminalIDAndOtherCodes()

                'Allocate Terminal
                _acceptorManagementRq.cardAcceptor = _cardAcceptor
                _acceptorManagementRq.terminal = _terminal

                _acceptorManagementRq.cardAcceptor.id = Me.Switch_CardAcceptorID
                _acceptorManagementRq.terminal.id = Me.Switch_TerminalID
                _acceptorManagementRq.terminal.serialNo = Me.SerialNo
                If Me.StoreName.Length >= 63 Then
                    _acceptorManagementRq.terminal.peerName = Me.StoreName.Substring(0, 63)
                Else
                    _acceptorManagementRq.terminal.peerName = Me.StoreName
                End If
                _acceptorManagementRq.terminal.peerType = peerType.Terminal
                _acceptorManagementRq.terminal.peerTypeSpecified = True
                _acceptorManagementRq.terminal.applicationReleaseDate = String.Empty
                _acceptorManagementRq.terminal.applicationVersion = String.Empty
                _acceptorManagementRq.terminal.dnsName = String.Empty
                _acceptorManagementRq.terminal.IPAddress = String.Empty
                _acceptorManagementRq.terminal.systemAuditNumber = 0

                _allocateTerminal2CardAcceptor.AcceptorManagementRq = _acceptorManagementRq
                _allocateTerminal2CardAcceptorResponse = _AcceptorManagementService.allocateTerminal2CardAcceptor(_allocateTerminal2CardAcceptor)
                _AcceptorManagementServiceResponseCode = _allocateTerminal2CardAcceptorResponse.return.responseCode
                '---
                Select Case _AcceptorManagementServiceResponseCode
                    Case responseCode.DoneSuccessfully
                        clsDalContract.EndProc()
                    Case responseCode.DuplicateTerminalId
                        clsDalContract.RollBackProc()
                        GetNewSwithTerminalID = True
                        Me.Switch_TerminalID = Switch_TerminalIDPlus(Switch_TerminalID)
                        Continue While
                    Case Else
                        Throw New Exception(_AcceptorManagementServiceResponseCode.ToString)
                End Select
            Catch ex As Exception
                clsDalContract.RollBackProc()
                Throw ex
            End Try
        End While

    End Sub
    Public Sub DefineCarAcceptorAllocateTerminal(ByVal IsSend2Switch As Boolean, ByVal Url As String)
        Try
            Dim Address As String = ConvertMethods.FaToEnFirstLineString(Me.StoreAddress)
            Dim _AcceptorManagementService As New AcceptorManagementServiceService()

            Dim GetNewSwithTerminalIDOrSwitchCardAcceptorID As Boolean = True
            While GetNewSwithTerminalIDOrSwitchCardAcceptorID = True
                GetNewSwithTerminalIDOrSwitchCardAcceptorID = False
                clsDalContract.BeginProc()
                clsDalContract.DDeviceID = Me.DeviceID
                clsDalContract.DSwitch_CardAcceptorID_vc = Me.Switch_CardAcceptorID
                clsDalContract.DSwitch_TerminalID_vc = Me.Switch_TerminalID
                clsDalContract.UpdateDevice_CardAcceptorIDAndTerminalIDAndOtherCodes()


                If IsSend2Switch Then
                  

                    'Define CardAcceptor And Allocate Terminal
                    _acceptorManagementRq.cardAcceptor = _cardAcceptor
                    _acceptorManagementRq.cardAcceptor.inst = _institution
                    _acceptorManagementRq.cardAcceptor.setlAcnt = _externalAccount
                    _acceptorManagementRq.terminal = _terminal

                    _acceptorManagementRq.cardAcceptor.id = Me.Switch_CardAcceptorID
                    _acceptorManagementRq.terminal.id = Me.Switch_TerminalID
                    _acceptorManagementRq.terminal.serialNo = Me.SerialNo

                    _acceptorManagementRq.cardAcceptor.businessCode = Me.StoreGroupID
                    _acceptorManagementRq.cardAcceptor.setlAcnt.externalAccountBankBranchID = Int32.Parse(Me.BranchID.Replace((Me.BranchID.Substring(0, 1)), "0"))

                    _acceptorManagementRq.cardAcceptor.setlAcnt.externalAccountNumber = Me.AccountNO
                    _acceptorManagementRq.cardAcceptor.setlAcnt.externalAccountTitle = Me.AccountTypeName

                    'Raeisi
                    _acceptorManagementRq.cardAcceptor.inst.institutionLatinAddress = Address
                    _acceptorManagementRq.cardAcceptor.inst.institutionProvince = Me.SStateName
                    _acceptorManagementRq.cardAcceptor.inst.institutionCity = Me.SCityName
                    _acceptorManagementRq.cardAcceptor.inst.institutionLatinCity = SCityShaparakCode
                    _acceptorManagementRq.cardAcceptor.inst.institutionLatinProvince = SStateShaparakCode
                    _acceptorManagementRq.cardAcceptor.setlAcnt.externalAccountIban = Me.ShabaAccount

                    If Me.StoreName.Length >= 63 Then
                        _acceptorManagementRq.cardAcceptor.inst.institutionName = Me.StoreName.Substring(0, 63)
                        _acceptorManagementRq.cardAcceptor.inst.institutionLatinName = Me.EnStoreName.Substring(0, 63)
                    Else
                        _acceptorManagementRq.cardAcceptor.inst.institutionName = Me.StoreName
                        _acceptorManagementRq.cardAcceptor.inst.institutionLatinName = Me.EnStoreName
                    End If

                    If Me.StoreAddress.Length >= 63 Then
                        _acceptorManagementRq.cardAcceptor.inst.institutionAddress = Me.StoreAddress.Substring(0, 63)
                    Else
                        _acceptorManagementRq.cardAcceptor.inst.institutionAddress = Me.StoreAddress
                    End If

                    If Me.StoreTel1.Length >= 31 Then
                        _acceptorManagementRq.cardAcceptor.inst.institutionPhone = Me.StoreTel1.Substring(0, 31)
                    Else
                        _acceptorManagementRq.cardAcceptor.inst.institutionPhone = Me.StoreTel1
                    End If
                    If Me.Mobile.Length >= 12 Then
                        _acceptorManagementRq.cardAcceptor.inst.institutionCellphoneNumber = Me.Mobile.Substring(0, 12)
                    Else
                        _acceptorManagementRq.cardAcceptor.inst.institutionCellphoneNumber = Me.Mobile
                    End If
                    If Me.Email.Length >= 100 Then
                        _acceptorManagementRq.cardAcceptor.inst.institutionEmailAddress = Me.Email.Substring(0, 100)
                    Else
                        _acceptorManagementRq.cardAcceptor.inst.institutionEmailAddress = Me.Email
                    End If
                    If Me.StoreName.Length >= 63 Then
                        _acceptorManagementRq.terminal.peerName = Me.StoreName.Substring(0, 63)
                    Else
                        _acceptorManagementRq.terminal.peerName = Me.StoreName
                    End If

                    _acceptorManagementRq.cardAcceptor.inst.institutionPostCode = Me.PostalCode

                    _acceptorManagementRq.cardAcceptor.inst.institutionIIN = constSwitchIIN
                    _acceptorManagementRq.cardAcceptor.setlAcnt.externalAccountBankID = constSwitchBankID
                    _acceptorManagementRq.cardAcceptor.settlementMethodSpecified = True
                    _acceptorManagementRq.cardAcceptor.settlementMethod = consSettlementMethodType
                    _acceptorManagementRq.cardAcceptor.statusSpecified = True
                    _acceptorManagementRq.cardAcceptor.status = activeInactive.Active
                    _acceptorManagementRq.cardAcceptor.inst.institutionType = institutionType.CardAcceptor
                    _acceptorManagementRq.cardAcceptor.inst.institutionTypeSpecified = True

                    _acceptorManagementRq.cardAcceptor.inst.institutionWebAddress = String.Empty
                    _acceptorManagementRq.cardAcceptor.reconciliationCycleLenght = 1

                    _acceptorManagementRq.terminal.peerType = peerType.Terminal
                    _acceptorManagementRq.terminal.peerTypeSpecified = True
                    _acceptorManagementRq.terminal.systemAuditNumber = 0
                    _acceptorManagementRq.terminal.applicationReleaseDate = String.Empty
                    _acceptorManagementRq.terminal.applicationVersion = String.Empty
                    _acceptorManagementRq.terminal.dnsName = String.Empty
                    _acceptorManagementRq.terminal.IPAddress = String.Empty

                    _acceptorManagementRq.cardAcceptor.paymentMethod = consPaymentMethodtype
                    _acceptorManagementRq.cardAcceptor.settlementTime = constSwitchSettlementTime
                    _acceptorManagementRq.cardAcceptor.setlAcnt.externallAccountTypeSpecified = True
                    _acceptorManagementRq.cardAcceptor.paymentMethodSpecified = True

                    _defineCardAcceptorAndAllocateTerminal.AcceptorManagementRq = _acceptorManagementRq
                    _defineCardAcceptorAndAllocateTerminalResponse = _AcceptorManagementService.defineCardAcceptorAndAllocateTerminal(_defineCardAcceptorAndAllocateTerminal)
                    _AcceptorManagementServiceResponseCode = _defineCardAcceptorAndAllocateTerminalResponse.return.responseCode
                    '---

                End If


                Select Case _AcceptorManagementServiceResponseCode
                    Case responseCode.DoneSuccessfully
                        '===takhsise karmozd
                        'Try
                        clsDalContract.EndProc()
                        If IsSend2Switch Then
                            clsBLLSwitch_FeeManagement.Switch_CardAcceptorID = Switch_CardAcceptorID
                            clsBLLSwitch_FeeManagement.FeeSchema = constDefaultSwitchFee
                            clsBLLSwitch_FeeManagement.FeeAssign()
                        End If
                    Case responseCode.DuplicateCardAcceptorId
                        clsDalContract.RollBackProc()
                        GetNewSwithTerminalIDOrSwitchCardAcceptorID = True
                        Switch_CardAcceptorID = Switch_CardAcceptorIDPlus(Switch_CardAcceptorID)
                        Continue While
                    Case responseCode.DuplicateTerminalId
                        clsDalContract.RollBackProc()
                        GetNewSwithTerminalIDOrSwitchCardAcceptorID = True
                        Switch_TerminalID = Switch_TerminalIDPlus(Switch_TerminalID)
                        Continue While
                    Case Else
                        Throw New Exception(_AcceptorManagementServiceResponseCode.ToString)
                End Select
            End While
            'Catch feeEx As FeeException
            '    Throw feeEx
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try
    End Sub
    Public Sub SetTerminalToCancelled(ByVal Url As String)
        Dim _AcceptorManagementService As New AcceptorManagementServiceService()
        Try
            clsDalSwitchSend.BeginProc()
            clsDalSwitchSend.Switch_Modify_DevicelID = Me.Switch_Modify_DeviceID
            clsDalSwitchSend.Update_Switch_Modify_Device_Sent()

            _setTerminalToCancelledContractByTerminalID.TerminalID = Me.Switch_TerminalID
            _setTerminalToCancelledContractByTerminalIDResponse = _AcceptorManagementService.setTerminalToCancelledContractByTerminalID(_setTerminalToCancelledContractByTerminalID)
            _AcceptorManagementServiceResponseCode = _setTerminalToCancelledContractByTerminalIDResponse.return.responseCode
            '---
            Select Case _AcceptorManagementServiceResponseCode
                Case responseCode.DoneSuccessfully
                    clsDalSwitchSend.EndProc()
                Case Else
                    Throw New Exception(_AcceptorManagementServiceResponseCode.ToString)
            End Select
            '=================
        Catch ex As Exception
            clsDalSwitchSend.RollBackProc()
            Throw ex
        End Try
    End Sub
    Public Sub ModifyTermianlSerial(ByVal Url As String)
        Dim _AcceptorManagementService As New AcceptorManagementServiceService()
        Try
            clsDalSwitchSend.BeginProc()
            dtSwitch_TerminalIDInfo.Clear()
            clsDalSwitchSend.Switch_TerminalID = Me.Switch_TerminalID
            dtSwitch_TerminalIDInfo = clsDalSwitchSend.GetBySwitchTerminal_Info(ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtSwitch_TerminalIDInfo.Rows.Count > 0 Then
                clsDalSwitchSend.Switch_Modify_DevicelID = Me.Switch_Modify_DeviceID
                clsDalSwitchSend.Update_Switch_Modify_Device_Sent()
                _acceptorManagementRq.terminal = _terminal
                _acceptorManagementRq.terminal.id = Me.Switch_TerminalID
                _acceptorManagementRq.terminal.serialNo = Me.SerialNo
                If dtSwitch_TerminalIDInfo.Rows(0).Item("SName_nvc").ToString.Length >= 63 Then
                    _acceptorManagementRq.terminal.peerName = dtSwitch_TerminalIDInfo.Rows(0).Item("SName_nvc").ToString.Substring(0, 63)
                Else
                    _acceptorManagementRq.terminal.peerName = dtSwitch_TerminalIDInfo.Rows(0).Item("SName_nvc").ToString
                End If
                _acceptorManagementRq.terminal.peerType = peerType.Terminal
                _acceptorManagementRq.terminal.peerTypeSpecified = True
                _acceptorManagementRq.terminal.applicationReleaseDate = String.Empty
                _acceptorManagementRq.terminal.applicationVersion = String.Empty
                _acceptorManagementRq.terminal.dnsName = String.Empty
                _acceptorManagementRq.terminal.IPAddress = String.Empty
                _acceptorManagementRq.terminal.systemAuditNumber = 0

                _modifyTermianlSerial.AcceptorManagementRq = _acceptorManagementRq
                _modifyTerminalSerialResponse = _AcceptorManagementService.modifyTerminalSerial(_modifyTermianlSerial)
                _AcceptorManagementServiceResponseCode = _modifyTerminalSerialResponse.return.responseCode
                Select Case _AcceptorManagementServiceResponseCode
                    Case responseCode.DoneSuccessfully
                        clsDalSwitchSend.EndProc()
                    Case Else
                        Throw New Exception(_AcceptorManagementServiceResponseCode.ToString)
                End Select
            Else
                Throw New Exception("SwitchTerminalID is not found in PSPDataBase")
            End If
        Catch ex As Exception
            clsDalSwitchSend.RollBackProc()
            Throw ex
        End Try
    End Sub

    Public Sub ModifyCardAcceptor(ByVal FieldName As String, ByVal FieldValue As String)
        Try
            Dim _AcceptorManagementService As New AcceptorManagementServiceService()
            Dim _GetCardAcceptorRS As New getCardAcceptorDetailByIDResponse
            Dim _GetCardAcceptor As New getCardAcceptorDetailByID
            clsDalSwitchSend.BeginProc()
            dtSwitch_CardAcceptorIDInfo.Clear()
            clsDalSwitchSend.Switch_CardAcceptorID = Me.Switch_CardAcceptorID
            dtSwitch_CardAcceptorIDInfo = clsDalSwitchSend.GetBySwitchCardAcceptor_Info(ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtSwitch_CardAcceptorIDInfo.Rows.Count > 0 Then
                clsDalSwitchSend.Switch_ModifyID = Me.Switch_ModifyID
                clsDalSwitchSend.Update_Switch_Modify_Sent()


                '   If CMSProjectID <> 3 Then


                _acceptorManagementRq.cardAcceptor = _cardAcceptor
                _acceptorManagementRq.cardAcceptor.inst = _institution
                _acceptorManagementRq.cardAcceptor.setlAcnt = _externalAccount

                Dim CA As New AcceptorManagementService.getCardAcceptorDetailByID
                Dim mhd As New AcceptorManagementService.cardAcceptorDTO
                mhd.id = Me.Switch_CardAcceptorID
                Dim rq As New AcceptorManagementService.acceptorManagementRq
                rq.cardAcceptor = mhd
                CA.AcceptorManagementRq = rq
                _GetCardAcceptorRS = _AcceptorManagementService.getCardAcceptorDetailByID(CA)

                _acceptorManagementRq.cardAcceptor = _GetCardAcceptorRS.return.cardAcceptor
                '_acceptorManagementRq.terminal = _GetCardAcceptorRS.return.terminal

                _acceptorManagementRq.cardAcceptor.inst.institutionAddress = _GetCardAcceptorRS.return.cardAcceptor.inst.institutionLatinAddress


                Select Case FieldName
                    Case "STel1_vc"
                        If FieldValue.Length >= 31 Then
                            _acceptorManagementRq.cardAcceptor.inst.institutionPhone = Left(FieldValue, 31).ToString
                        Else
                            _acceptorManagementRq.cardAcceptor.inst.institutionPhone = FieldValue
                        End If
                    Case "SName_nvc"
                        If FieldValue.Length >= 63 Then
                            _acceptorManagementRq.cardAcceptor.inst.institutionName = Left(FieldValue, 63).ToString
                            '_acceptorManagementRq.terminal.peerName = Left(FieldValue, 63).ToString
                        Else
                            _acceptorManagementRq.cardAcceptor.inst.institutionName = FieldValue
                            '_acceptorManagementRq.terminal.peerName = FieldValue
                        End If
                    Case "SAddress_nvc"
                        If FieldValue.Length >= 63 Then
                            _acceptorManagementRq.cardAcceptor.inst.institutionAddress = Left(FieldValue, 63).ToString
                        Else
                            _acceptorManagementRq.cardAcceptor.inst.institutionAddress = FieldValue
                        End If
                    Case "Email_nvc"
                        If FieldValue.Length >= 100 Then
                            _acceptorManagementRq.cardAcceptor.inst.institutionEmailAddress = Left(FieldValue, 100).ToString
                        Else
                            _acceptorManagementRq.cardAcceptor.inst.institutionEmailAddress = FieldValue
                        End If
                    Case "GroupID"
                        _acceptorManagementRq.cardAcceptor.businessCode = FieldValue
                    Case "Mobile_vc"
                        If FieldValue.Length >= 12 Then
                            _acceptorManagementRq.cardAcceptor.inst.institutionCellphoneNumber = Left(FieldValue, 12).ToString
                        Else
                            _acceptorManagementRq.cardAcceptor.inst.institutionCellphoneNumber = FieldValue
                        End If
                End Select

                _modifyCardAcceptor.AcceptorManagementRq = _acceptorManagementRq
                _modifyCardAcceptorResponse = _AcceptorManagementService.modifyCardAcceptor(_modifyCardAcceptor)

                _AcceptorManagementServiceResponseCode = _modifyCardAcceptorResponse.return.responseCode

                Select Case _AcceptorManagementServiceResponseCode
                    Case responseCode.DoneSuccessfully
                        clsDalSwitchSend.EndProc()
                    Case Else
                        Throw New Exception(_AcceptorManagementServiceResponseCode.ToString)
                End Select

                '   End If
            Else
                Throw New Exception("SwitchCardAcceptorID is not found in PSPDataBase")
            End If
        Catch ex As Exception
            clsDalSwitchSend.RollBackProc()
            Throw ex
        End Try
    End Sub

    Private Function Switch_CardAcceptorIDPlus(ByVal Switch_CardAcceptorID As String) As String
        Try
            Dim CodeFirstPart As String = "MERCHANT"
            Dim Counter As Int64
            Dim strCounter As String
            Counter = Convert.ToInt64(Microsoft.VisualBasic.Right(Switch_CardAcceptorID, 7)) + 1
            strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

            Switch_CardAcceptorIDPlus = CodeFirstPart & strCounter

        Catch ex As Exception
            Switch_CardAcceptorIDPlus = String.Empty
        End Try

    End Function
    Private Function Switch_TerminalIDPlus(ByVal Switch_TerminalID As String) As String
        Try
            Dim CodeFirstPart As String = "L"
            Dim Counter As Int64
            Dim strCounter As String
            Counter = Convert.ToInt64(Microsoft.VisualBasic.Right(Switch_TerminalID, 7)) + 1
            strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

            Switch_TerminalIDPlus = CodeFirstPart & strCounter

        Catch ex As Exception
            Switch_TerminalIDPlus = String.Empty
        End Try

    End Function
    Public Class FeeException
        Inherits Exception
        Public Sub New()
            MyBase.New("در بخش تخصیص کارمزد خطا رخ داده است ")
        End Sub
       

    End Class
End Class
