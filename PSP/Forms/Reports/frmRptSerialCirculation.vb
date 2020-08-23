Public Class frmRptSerialCirculation

    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Private Sub rtsSearch_Show_Click() Handles rtsSearch.Show_Click
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            FillGrid()
            InitGrid()
            InitSearchToolbar()

        Catch ex As Exception
            Throw ex
        End Try


    End Sub
   
    Private Function RequiredValidator() As Boolean
        If txtSerial.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtSerial, "شماره سریال نمی تواند خالی باشد")
            Return False
        Else
            ErrorProvider1.SetError(txtSerial, "")
            Return True
        End If
    End Function

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            dtdgv = clsDALReport.GetSerialCirculation(txtSerial.Text)

            If dtdgv.Rows.Count > 0 Then
                lblPosModel.Text = dtdgv.Rows(0).Item("PosModelName").ToString()
                lblEniacCode.Text = dtdgv.Rows(0).Item("EniacCode_vc").ToString()
            End If
            dgvReport.DataSource = dtdgv
            dvdgv = dtdgv.DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("PosID").Visible = False
        dgvReport.Columns("Serial_vc").Visible = False
        dgvReport.Columns("EniacCode_vc").Visible = False
        dgvReport.Columns("PosModelName").Visible = False

        dgvReport.Columns("VisitorName").HeaderText = "نماینده"
        dgvReport.Columns("VisitorName").Width = 250
        dgvReport.Columns("DateFa_vc").HeaderText = "تاریخ"
        dgvReport.Columns("StatusDesc").HeaderText = "وضعیت"
    End Sub
    Private Sub InitSearchToolbar()

        rtsSearch.Init(dgvReport, dtdgv, "")


    End Sub

End Class