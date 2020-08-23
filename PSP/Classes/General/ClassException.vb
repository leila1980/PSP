Namespace PSP.Exception.Account
    Public Class AccountNotFoundException
        Inherits System.ApplicationException

        Public Sub New()
            MyBase.New("حساب مورد نظر موجود نمی باشد")
        End Sub
    End Class
End Namespace
