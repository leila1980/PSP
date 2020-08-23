Imports System.IO
Public Class frmReqImgShow

    Private clsMyControlerReqImg As New RIZNARM.WINDOWS.FORMS.ClassFormController(dgvReqImg, True, True, True, True)
    Private dt As New DataTable

    Private Sub frmReqImgShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DalReq As New ClassDALRequest(modPublicMethod.ConnectionString)
            Dim dtDB As New DataTable

            dt.Columns.Add("ColImgPath", GetType(String))
            dt.Columns.Add("ColImg", GetType(Image))
            dt.Columns.Add("ColDesc", GetType(String))
            dt.Columns.Add("Colconfirm", GetType(Integer))

            DalReq.RequestID = 1
            dtDB = DalReq.GetAllReqImg()



            For i As Integer = 0 To dtDB.Rows.Count - 1

                Dim dr As DataRow = dt.NewRow
                dr("ColImgPath") = dtDB.Rows(i)("IMGPATH")
                dr("ColImg") = Image.FromFile(dtDB.Rows(i)("IMGPATH"))
                dr("ColDesc") = dtDB.Rows(i)("IMGREQDESCR")

                If dtDB.Rows(i)("CONFIRM") = 1 Then
                    dr("Colconfirm") = True
                ElseIf dtDB.Rows(i)("CONFIRM") = 0 Then
                    dr("Colconfirm") = False
                End If

                dt.Rows.Add(dr)

            Next

            InitControls()
            dgvReqImg.DataSource = dt
            Me.clsMyControlerReqImg.SetControlsValue()



        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub



    Private Sub dgvReqImg_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReqImg.RowEnter
        Try

            If e.RowIndex >= 0 Then
                dgvReqImgRowEnter(e.RowIndex)
            End If

        Catch ex As Exception
            Me.dt.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub dgvReqImgRowEnter(ByVal RowIndex As Int32)
        Try
            dgvReqImg.Rows(RowIndex).Selected = True
            Me.clsMyControlerReqImg.DataGridView = Me.dgvReqImg
            clsMyControlerReqImg.SetControlsValue(RowIndex)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitControls()

        Me.dgvReqImg.AutoGenerateColumns = False

        Dim Confrim_bit As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Confrim_bit.Control = chkConfirm
        Confrim_bit.EnabledInViewState = True
        Confrim_bit.MappedColumn = "Colconfirm"
        Confrim_bit.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        clsMyControlerReqImg.AddControl(Confrim_bit)

        Dim IMgDescription_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        IMgDescription_vc.Control = txtImgDescription
        IMgDescription_vc.EnabledInViewState = True
        IMgDescription_vc.MappedColumn = "ColDesc"
        IMgDescription_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text


        clsMyControlerReqImg.AddControl(IMgDescription_vc)

    End Sub

    Private Sub dgvReqImg_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReqImg.CellDoubleClick

        Try
            If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
                Dim frm As New frmReqImgFullShow(dgvReqImg.CurrentRow.Cells("ColImgPath").Value.ToString)
                frm.ShowDialog()

            End If





        Catch ex As Exception

            MessageBox.Show(ex.ToString())
        End Try


    End Sub
End Class