Imports CMSFeeSchemaService

Public Class ClassBLLCMSSwitch_FeeManagement
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)

    Private _FeeSchemaService As New FeeSchemaServiceService
    Private _FeeSchemaRs As New feeSchemaRs
    Private _feeSchemaRq As New feeSchemaRq
    Private _getFeeSchemaListResponse As New getFeeSchemaListResponse
    Private _getFeeSchemaList As New getFeeSchemaList
    Private _assignFeeSchema2CardAcceptor_rs As New assignFeeSchema2CardAcceptorResponse
    Private _assignFeeSchema2CardAcceptor_responseCode As CMSFeeSchemaService.responseCode
    Private _assignFeeSchema2CardAcceptor As New assignFeeSchema2CardAcceptor
    Private _cardAcceptor As New CMSFeeSchemaService.cardAcceptorDTO
    Private _feeschema As New feeSchema

    Private dtContractIDAllCardAcceptor As New DataTable

    Private mvarSwitch_CardAcceptorID As String
    Private mvarFeeSchema As Int32
    Private mvarContractID As Int64
    Public Property Switch_CardAcceptorID() As String
        Get
            Return mvarSwitch_CardAcceptorID
        End Get

        Set(ByVal value As String)
            mvarSwitch_CardAcceptorID = value
        End Set
    End Property
    Public Property FeeSchema() As Int32
        Get
            Return mvarFeeSchema
        End Get
        Set(ByVal value As Int32)
            mvarFeeSchema = value
        End Set
    End Property
    Public Property ContractID() As Int64
        Get
            Return mvarContractID
        End Get
        Set(ByVal value As Int64)
            mvarContractID = value
        End Set
    End Property

    Public Function GetFeeSchemaList() As feeSchema()
        Try
            _getFeeSchemaList.arg0 = _feeSchemaRq
            _FeeSchemaRs = _FeeSchemaService.getFeeSchemaList(_getFeeSchemaList).return
            Return _FeeSchemaRs.feeSchemaList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub FeeAssign()
        Try
            clsDalContract.BeginProc()
            clsDalContract.DSwitch_CardAcceptorID_vc = Me.Switch_CardAcceptorID
            clsDalContract.DSwitch_FeeID_int = Me.FeeSchema
            clsDalContract.UpdateDevice_OnlySwitch_FeeID()
            clsDalContract.InsertSwitch_Fee_History(Me.Switch_CardAcceptorID, Me.FeeSchema, GetTimeNow, ClassUserLoginDataAccess.ThisUser.UserID)

            'assign FeeSchema
            _feeSchemaRq.cardAcceptor = _cardAcceptor
            _feeSchemaRq.feeSchema = _feeschema
            _feeSchemaRq.cardAcceptor.id = Me.Switch_CardAcceptorID
            _feeSchemaRq.feeSchema.id = Me.FeeSchema
            _assignFeeSchema2CardAcceptor.arg0 = _feeSchemaRq
            _assignFeeSchema2CardAcceptor_rs = _FeeSchemaService.assignFeeSchema2CardAcceptor(_assignFeeSchema2CardAcceptor)
            _assignFeeSchema2CardAcceptor_responseCode = _assignFeeSchema2CardAcceptor_rs.return.responseCode
            Select Case _assignFeeSchema2CardAcceptor_responseCode
                Case responseCode.DoneSuccessfully
                    clsDalContract.EndProc()
                Case Else
                    Throw New Exception(_assignFeeSchema2CardAcceptor_responseCode.ToString())
            End Select
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try
    End Sub
    Public Sub ContractFeeAssign()
        Try
            clsDalContract.BeginProc()
            dtContractIDAllCardAcceptor.Clear()
            dtContractIDAllCardAcceptor = clsDalContract.GetByContractIDAllCardAcceptor(Me.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            clsDalContract.UpdateContract_OnlyFeeSchema(ContractID, FeeSchema)
            For j As Int32 = 0 To dtContractIDAllCardAcceptor.Rows.Count - 1
                Me.Switch_CardAcceptorID = dtContractIDAllCardAcceptor.Rows(j).Item("Switch_CardAcceptorID_vc")
                clsDalContract.DSwitch_CardAcceptorID_vc = Me.Switch_CardAcceptorID
                clsDalContract.DSwitch_FeeID_int = Me.FeeSchema
                clsDalContract.UpdateDevice_OnlySwitch_FeeID()
                clsDalContract.InsertSwitch_Fee_History(Me.Switch_CardAcceptorID, Me.FeeSchema, GetTimeNow, ClassUserLoginDataAccess.ThisUser.UserID)

                'assign FeeSchema
                _feeSchemaRq.cardAcceptor = _cardAcceptor
                _feeSchemaRq.feeSchema = _feeschema
                _feeSchemaRq.cardAcceptor.id = Me.Switch_CardAcceptorID
                _feeSchemaRq.feeSchema.id = Me.FeeSchema
                _assignFeeSchema2CardAcceptor.arg0 = _feeSchemaRq
                _assignFeeSchema2CardAcceptor_rs = _FeeSchemaService.assignFeeSchema2CardAcceptor(_assignFeeSchema2CardAcceptor)
                _assignFeeSchema2CardAcceptor_responseCode = _assignFeeSchema2CardAcceptor_rs.return.responseCode
                Select Case _assignFeeSchema2CardAcceptor_responseCode
                    Case responseCode.DoneSuccessfully
                    Case Else
                        Throw New Exception(_assignFeeSchema2CardAcceptor_responseCode.ToString())
                End Select
            Next
            clsDalContract.EndProc()
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try
    End Sub
End Class
