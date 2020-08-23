Module modUserPermission
    Friend CheckUser As Boolean = True

    Public Sub SetPermission(ByVal _FormController As RIZNARM.WINDOWS.FORMS.ClassFormController, ByVal Form As Form, ByVal UserID As Integer, ByVal FormName As String)
        Dim clsUserPermit As New ClassUserRightDataAccess(ConnectionString)

        With clsUserPermit
            .UserPermission(UserID, FormName)
            If .CanView = False Then MsgBox("دسترسی ممنوع") : Form.Close() : Return
            If .CanView = False Then _FormController.CanView = False Else _FormController.CanView = True
            If .CanNew = False Then _FormController.CanAdd = False Else _FormController.CanAdd = True
            If .CanEdit = False Then _FormController.CanEdit = False Else _FormController.CanEdit = True
            If .CanDelete = False Then _FormController.CanDelete = False Else _FormController.CanDelete = True
            If .CanPrint = False Then _FormController.CanPrint = False Else _FormController.CanPrint = True

        End With
    End Sub
    ''' <summary>
    ''' Cancel Isnot Used
    ''' </summary>
    ''' <param name="_FormController"></param>
    ''' <param name="Form"></param>
    ''' <param name="UserID"></param>
    ''' <param name="BasicType"></param>
    ''' <param name="Cancel"></param>
    ''' <remarks></remarks>
    Public Sub SetPermission(ByVal _FormController As RIZNARM.WINDOWS.FORMS.ClassFormController, ByVal Form As Form, ByVal UserID As Integer, ByVal BasicType As SByte, ByVal Cancel As Boolean)
        Try
            Dim clsUserPermit As New ClassUserRightDataAccess(ConnectionString)

            With clsUserPermit
                .UserPermission(UserID, BasicType)
                If .CanView = False Then MsgBox("دسترسی ممنوع") : Form.Close() : Return
                If .CanView = False Then _FormController.CanView = False Else _FormController.CanView = True
                If .CanNew = False Then _FormController.CanAdd = False Else _FormController.CanAdd = True
                If .CanEdit = False Then _FormController.CanEdit = False Else _FormController.CanEdit = True
                If .CanDelete = False Then _FormController.CanDelete = False Else _FormController.CanDelete = True
                If .CanPrint = False Then _FormController.CanPrint = False Else _FormController.CanPrint = True

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub SetPermission(ByVal Form As Form, ByVal UserID As Integer, ByVal FormName As String, ByVal FormID As Int16)
        Dim clsUserPermit As New ClassUserRightDataAccess(ConnectionString)

        With clsUserPermit
            .UserPermission(UserID, FormName, 1, FormID)
            If .CanView = False Then MsgBox("دسترسی ممنوع") : Form.Close() : Return
        End With
    End Sub
    Public Sub SetPermission(ByVal Form As Form, ByVal UserID As Integer, ByVal FormName As String)
        Dim clsUserPermit As New ClassUserRightDataAccess(ConnectionString)

        With clsUserPermit
            .UserPermission(UserID, FormName)
            If .CanView = False Then MsgBox("دسترسی ممنوع") : Form.Close() : Return
        End With
    End Sub
    Public Sub SetPermission(ByVal Form As Form, ByVal UserID As Integer, ByVal FormName As String, ByRef CanView As Boolean, ByRef CanNew As Boolean, ByRef CanEdit As Boolean, ByRef CanDelete As Boolean, ByRef CanPrint As Boolean, ByVal FormID As Int16)
        Dim clsUserPermit As New ClassUserRightDataAccess(ConnectionString)
        With clsUserPermit
            .UserPermission(UserID, FormName, False, FormID)
            If .CanView = False Then MsgBox("دسترسی ممنوع") : Form.Close() : Return
            CanView = .CanView
            CanNew = .CanNew
            CanEdit = .CanEdit
            CanDelete = .CanDelete
            CanPrint = .CanPrint
        End With
    End Sub
End Module