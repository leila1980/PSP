Public Class ClassSetting
    Private Shared _Add_Shortcut As String = "F6"
    Private Shared _Edit_Shortcut As String = "F4"
    Private Shared _Delete_Shortcut As String = "F7"
    Private Shared _Cancel_Shortcut As String = "ESC"
    Private Shared _SaveExit_Shortcut As String = "F10"
    Private Shared _Print_Shortcut As String = "F9"
    Private Shared _Search_Shortcut As String = "F5"
    Private Shared _List_Shortcut As String = "F3"
    Private Shared _OnlySave_Shortcut As String = "F2"
    Private Shared _FormDeleteItem_Shortcut As String = "F8"
    Private Shared _Help_Shortcut As String
    Private Shared _DemoVersion As Boolean
    Private Shared _WithLock As Boolean

    Public Shared Property WithLock() As Boolean
        Get
            Return _WithLock
        End Get
        Set(ByVal value As Boolean)
            _WithLock = value
        End Set
    End Property
    Public Shared Property Help_Shortcut() As String
        Get
            Return _Help_Shortcut
        End Get
        Set(ByVal value As String)
            _Help_Shortcut = value
        End Set
    End Property
    Public Shared Property FormDeleteItem_Shortcut() As String
        Get
            Return _FormDeleteItem_Shortcut
        End Get
        Set(ByVal value As String)
            _FormDeleteItem_Shortcut = value
        End Set
    End Property
    Public Shared Property OnlySave_Shortcut() As String
        Get
            Return _OnlySave_Shortcut
        End Get
        Set(ByVal value As String)
            _OnlySave_Shortcut = value
        End Set
    End Property
    Public Shared Property List_Shortcut() As String
        Get
            Return _List_Shortcut
        End Get
        Set(ByVal value As String)
            _List_Shortcut = value
        End Set
    End Property
    Public Shared Property Search_Shortcut() As String
        Get
            Return _Search_Shortcut
        End Get
        Set(ByVal value As String)
            _Search_Shortcut = value
        End Set
    End Property
    Public Shared Property Add_Shortcut() As String
        Get
            Return _Add_Shortcut
        End Get
        Set(ByVal value As String)
            _Add_Shortcut = value
        End Set
    End Property
    Public Shared Property Edit_Shortcut() As String
        Get
            Return _Edit_Shortcut
        End Get
        Set(ByVal value As String)
            _Edit_Shortcut = value
        End Set
    End Property
    Public Shared Property Delete_Shortcut() As String
        Get
            Return _Delete_Shortcut
        End Get
        Set(ByVal value As String)
            _Delete_Shortcut = value
        End Set
    End Property
    Public Shared Property Cancel_Shortcut() As String
        Get
            Return _Cancel_Shortcut
        End Get
        Set(ByVal value As String)
            _Cancel_Shortcut = value
        End Set
    End Property
    Public Shared Property SaveExit_Shortcut() As String
        Get
            Return _SaveExit_Shortcut
        End Get
        Set(ByVal value As String)
            _SaveExit_Shortcut = value
        End Set
    End Property
    Public Shared Property Print_Shortcut() As String
        Get
            Return _Print_Shortcut
        End Get
        Set(ByVal value As String)
            _Print_Shortcut = value
        End Set
    End Property
    Public Shared Property DemoVersion() As Boolean
        Get
            Return _DemoVersion
        End Get
        Set(ByVal value As Boolean)
            _DemoVersion = value
        End Set
    End Property



End Class