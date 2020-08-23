Public Class ClassCMSProject
    Private mvarCMSProjectID As Int32
    Private mvarName As String
    Private mvarIsSent2Switch As Int16
    Private mvarESSWS As String
    Private mvarISEniacMerchant As Int16
    Private mvarIsEniacOutlet As Int16

#Region "Property"

    Public Property CMSProjectID() As String
        Get
            Return mvarCMSProjectID
        End Get
        Set(ByVal value As String)
            mvarCMSProjectID = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mvarName
        End Get
        Set(ByVal value As String)
            mvarName = value
        End Set
    End Property
    Public Property IsSent2Switch() As Int16
        Get
            Return mvarIsSent2Switch
        End Get
        Set(ByVal value As Int16)
            mvarIsSent2Switch = value
        End Set
    End Property
    Public Property ESSWS_NVC() As String
        Get
            Return mvarESSWS
        End Get
        Set(ByVal value As String)
            mvarESSWS = value
        End Set
    End Property
 
    Public Property ISEniacMerchant() As Int16
        Get
            Return mvarISEniacMerchant
        End Get
        Set(ByVal value As Int16)
            mvarISEniacMerchant = value
        End Set
    End Property

    Public Property IsEniacOutlet() As Int16
        Get
            Return mvarIsEniacOutlet
        End Get
        Set(ByVal value As Int16)
            mvarIsEniacOutlet = value
        End Set
    End Property

    Public Sub New(ByVal CMSProjectID As Integer, ByVal Name As String, ByVal isSent2Switch As Boolean, ByVal ESSWS_NVC As String)
        Me.mvarCMSProjectID = CMSProjectID
        Me.mvarName = Name
        Me.mvarIsSent2Switch = isSent2Switch
        'Me.mvarESSWS = ESSWS_NVC
    End Sub




#End Region
End Class
