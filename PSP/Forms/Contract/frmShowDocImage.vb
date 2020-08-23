Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Public Class frmShowDocImage
    Inherits Form

    Private CounterVar As Integer = 0

    Public ContractId As String

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    'Private ImageList1 As List(Of Image) = Nothing
    Private ImageDictionary As Dictionary(Of Integer, Byte())

    Private dt As New DataTable
    Private ImageURL As String = ""
    Private Image As Image = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub


    Private Sub frmShowDocImage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            'SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FillcboDocType()
            intitForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub intitForm()
        Try
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            If Me.ContractId IsNot Nothing Then


                clsDalContract.ContractID = Me.ContractId
                dt = clsDalContract.GetDocImgByContractID()

                If dt.Rows.Count > 0 Then

                    'ImageList1 = New List(Of Image)

                    ImageDictionary = New Dictionary(Of Integer, Byte())
                    ' Add four entries.


                    'For Each r As DataRow In dt.Select("[IMAGEURL_VC]<>''")
                    '    If System.IO.File.Exists(r("IMAGEURL_VC")) = True Then
                    '        'ImageList1.Add(Bitmap.FromFile(r("IMAGEURL_VC")))
                    '        ImageDictionary.Add(r("CONTRACTDOCIMGID"), Bitmap.FromFile(r("IMAGEURL_VC")))
                    '    End If
                    'Next


                    For Each r As DataRow In dt.Rows
                        If r("IMAGE_VB") IsNot DBNull.Value Then
                            ImageDictionary.Add(r("CONTRACTDOCIMGID"), r("IMAGE_VB"))
                        End If

                    Next


                    'Set imagebox to first index image.
                    If ImageDictionary.Count > 0 Then
                        txtTotalCount.Text = ImageDictionary.Count
                        'PictureBox2.Image = ImageList1.Item(0)
                        ImageUpdate()
                    Else
                        PictureBox2.Image = Nothing
                    End If


                Else
                    txtTotalCount.Text = "0"
                    txtCurrent.Text = "0"
                    PictureBox2.Image = Nothing
                End If

                Me.txtContractID.Text = Me.ContractId
                btnSearch.Enabled = False
                Me.btnNext.Enabled = True
                Me.btnPrevious.Enabled = True

            Else
                MessageBox.Show("شماره قرارداد خالی است")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub ImageUpdate()

        Try
            'CONTRACTDOCIMGID
            'Sets the picture box to the first image of the series.
            If dt.Rows.Count > 0 Then

                If ImageDictionary.Count > CounterVar Then
                    Me.cboDocType.SelectedValue = dt.Rows(CounterVar)("IMAGETYPEID")
                    If dt.Rows(CounterVar)("IMAGEDESC_VC") IsNot Nothing Then
                        Me.txtImageDesc.Text = dt.Rows(CounterVar)("IMAGEDESC_VC").ToString()
                    End If

                    If dt.Rows(CounterVar)("ATTACHDATE_VC") IsNot Nothing Then
                        Me.dtxtAttachDate_vc.Value = dt.Rows(CounterVar)("ATTACHDATE_VC").ToString()
                    End If


                    Dim ms As New IO.MemoryStream(ImageDictionary.Item(dt.Rows(CounterVar)("CONTRACTDOCIMGID")))
                    PictureBox2.Image = Image.FromStream(ms)

                    txtCurrent.Text = CounterVar + 1


                ElseIf ImageDictionary.Count = CounterVar Then
                    Me.cboDocType.SelectedValue = dt.Rows(CounterVar - 1)("IMAGETYPEID")

                    Dim ms As New IO.MemoryStream(ImageDictionary.Item(dt.Rows(CounterVar - 1)("CONTRACTDOCIMGID")))
                    PictureBox2.Image = Image.FromStream(ms)


                    txtCurrent.Text = CounterVar

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevious.Click

        If dt.Rows.Count > 0 And CounterVar > 0 Then
            CounterVar = CounterVar - 1
        End If

        ImageUpdate()

    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
        If dt.Rows.Count > 0 And ImageDictionary IsNot Nothing Then
            If CounterVar < ImageDictionary.Count - 1 Then
                CounterVar += 1
            End If
            ImageUpdate()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If Me.dt.Rows.Count > 0 Then
                Edit()
            End If

        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub Edit()
        Me.cboDocType.Enabled = True
        Me.txtImageDesc.Enabled = True
        Me.txtImageDesc.ReadOnly = False
    End Sub

    Private Sub FillcboDocType()
        Try
            clsDalContract.BeginProc()

            Dim dtcbo As New DataTable()
            dtcbo = clsDalContract.GetAllImageTypes()

            If dtcbo.Rows.Count > 0 Then
                Me.cboDocType.DataSource = clsDalContract.GetAllImageTypes()
                Me.cboDocType.DisplayMember = "ImageType"
                Me.cboDocType.ValueMember = "ImageTypeID"

            Else
                ShowErrorMessage("جدول نوع عکس خالی می باشد")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Me.cboDocType.Enabled = False
        If Me.PictureBox2.Image IsNot Nothing Then
            Me.Save()
            Me.CounterVar = 0
            intitForm()

            btnSearch.Enabled = False
            Me.btnNext.Enabled = True
            Me.btnPrevious.Enabled = True
        Else
            MessageBox.Show("هیج عکسی انتخاب نشده است", "خطا")
            Return
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.cboDocType.Enabled = False
        Me.txtImageDesc.Enabled = False
        Me.txtImageDesc.ReadOnly = False
        intitForm()
    End Sub

    Private Sub Save()
        Try
            clsDalContract.BeginProc()

            Dim imagesize As Long = 0
            imagesize = GetImageSize(Me.PictureBox2.Image)

            'If imagesize > 320 And imagesize < 420 Then

            '    Me.PictureBox2.Image = Me.ResizeImage(Me.PictureBox2.Image, New Size(600, 800))

            If imagesize > 420 Then
                ShowMessage(" سایز عکس وارد شده باید کوچکتر از 420 کیلوبایت باشد")
                Exit Sub
            End If

            If btnSearch.Enabled = True Then
                clsDalContract.ContractID = Me.ContractId
                clsDalContract.ImageTypeID = Me.cboDocType.SelectedValue
                clsDalContract.ImageDesc_vc = Me.txtImageDesc.Text
                clsDalContract.AttachDate_vc = GetDateNow()


                Dim converter As New ImageConverter
                clsDalContract.Image_vb = converter.ConvertTo(Me.PictureBox2.Image, GetType(Byte()))

                If Me.ImageURL <> String.Empty Then
                    clsDalContract.ImageURL_vc = Me.ImageURL.Trim
                    clsDalContract.InsertContractDocImg()
                    ShowMessage("عملیات ذخیره سازی با موفقیت انجام شد.")
                Else
                    ShowErrorMessage("عکسی انتخاب نشده است")
                End If


            Else
                clsDalContract.ContractDocImgeID = Me.dt.Rows(CounterVar)("CONTRACTDOCIMGID")
                clsDalContract.ImageTypeID = Me.cboDocType.SelectedValue
                clsDalContract.ImageDesc_vc = Me.txtImageDesc.Text

                Dim converter As New ImageConverter
                clsDalContract.Image_vb = converter.ConvertTo(Me.PictureBox2.Image, GetType(Byte()))

                clsDalContract.UpdateContractDocImg()
                ShowMessage("عملیات ذخیره سازی با موفقیت انجام شد.")

            End If

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
        Me.CounterVar = 0
        Me.cboDocType.Enabled = False
        intitForm()
    End Sub
    Private Sub Delete()
        Try
            If Me.dt.Rows.Count > 0 Then


                If modPublicMethod.ShowConfirmDeleteMessage() = False Then
                    Exit Sub
                End If
                clsDalContract.BeginProc()
                clsDalContract.ContractDocImgeID = Me.dt.Rows(CounterVar)("CONTRACTDOCIMGID")
                clsDalContract.DeleteContractDocImg()
                Me.DatatableContractDocImgDelete()
                Me.dt.AcceptChanges()
            End If
        Catch ex As Exception
            Me.dt.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            clsDalContract.EndProc()
            'clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            'clsMyControlerStore.SetControlsValue()
        End Try
    End Sub

    Private Sub DatatableContractDocImgDelete()
        Try
            Dim drDeletedRow() As DataRow = Me.dt.Select("CONTRACTDOCIMGID = " + Me.dt.Rows(CounterVar)("CONTRACTDOCIMGID").ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.cboDocType.Enabled = True
        dtxtAttachDate_vc.Value = modPublicMethod.GetDateNow
        txtImageDesc.Text = String.Empty
        txtImageDesc.Enabled = True
        txtImageDesc.ReadOnly = False

        If Me.cboDocType.Items.Count > 0 Then
            Me.cboDocType.SelectedIndex = 0
        End If
        btnSearch.Enabled = True
        Me.ImageURL = String.Empty
        Me.btnNext.Enabled = False
        Me.btnPrevious.Enabled = False
        If Not IsNothing(PictureBox2.Image) Then PictureBox2.Image.Dispose()
        PictureBox2.Image = Nothing

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim ofd As New OpenFileDialog
            'ofd.Filter = "Bitmap|*.jpg|*.bmp|JPEG" 'If you like file type filters you can add them here
            ofd.Title = "Please Select a File"
            'ofd.DefaultExt = "*.jpg"
            'any other modifications to the dialog
            If ofd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Try
                Dim bmp As New Bitmap(ofd.FileName)
                If Not IsNothing(PictureBox2.Image) Then PictureBox2.Image.Dispose() 'Optional if you want to destroy the previously loaded image
                PictureBox2.Image = bmp
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                Me.ImageURL = ofd.FileName.ToString
            Catch
                MsgBox("  فایل عکس نامعتبر است")
            End Try

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function ResizeImage(ByVal image As Image, ByVal NewImageSize As Size) As Image
        ' Get the scale factor.
        'Dim scale_factor As Single = Single.Parse(NewImageSize)

        ' Get the source bitmap.
        Dim bm_source As New Bitmap(image)

        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap(image, NewImageSize)


        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(bm_source, 0, 0, _
            bm_dest.Width + 1, _
            bm_dest.Height + 1)

        ' Display the result.
        Return bm_dest
    End Function

    Private Function GetImageSize(ByVal img As Image) As Long

        Dim File As String = IO.Path.ChangeExtension(IO.Path.GetTempFileName, "jpg")

        'img.Save(File, System.Drawing.Imaging.ImageFormat.Jpeg)

        img.Save(File)

        Dim fInfo As New IO.FileInfo(File)
        Dim Imagesize As Long = fInfo.Length / 1024
            'MessageBox.Show(Imagesize & "KB")
        IO.File.Delete(File)

      
            Return Imagesize

    End Function

    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click
        Try
            Dim F As New WIA.ImageFile
            Dim strFileName As String = cboDocType.Text
            Dim strBasePath As String = Nothing

            If Not Me.PictureBox2.Image Is Nothing Then
                'strBasePath = My.Settings.ContractDocImg_Path.Trim & "\DocumentsPhotos\" + ContractId
                '' >> Check if Folder Exists 
                'If System.IO.Directory.Exists(strBasePath) = False Then
                '    Call System.IO.Directory.CreateDirectory(strBasePath)
                'End If
                ' >> Save Picture 

                Dim saveFileDialog1 As New SaveFileDialog()
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
                saveFileDialog1.Title = "ذخیره مدارک قرداد"


                With saveFileDialog1

                    .ShowDialog()

                    If .FileName.Length > 0 Then

                        PictureBox2.Image.Save(.FileName)
                        MsgBox("عکس مورد نظر در مسیر مربوطه با موفقیت ذخیره شد")
                    End If
                End With

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("مشکلی در ذخیره سازی عکس وجود دارد")
        End Try
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Dim dtAll As New DataTable
    '        dtAll = clsDalContract.GetAllContractHasDocImg

    '        Dim F As New WIA.ImageFile
    '        Dim strFileName As String = ""
    '        Dim strBasePath As String = Nothing



    '        'Dim PictureCol As Integer = 0 ' the column # of the BLOB field
    '        'Dim cn As New SqlConnection("server=localhost;integrated security=yes;database=NorthWind")
    '        'Dim cmd As New SqlCommand("SELECT Picture FROM Categories WHERE CategoryName='Test'", cn)
    '        'cn.Open()
    '        'Dim dr As SqlDataReader = cmd.ExecuteReader()
    '        'dr.Read()
    '        'Dim b(dr.GetBytes(PictureCol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
    '        'dr.GetBytes(PictureCol, 0, b, 0, b.Length)
    '        'dr.Close()
    '        'cn.Close()
    '        'Dim fs As New System.IO.FileStream(DestFilePath, IO.FileMode.Create, IO.FileAccess.Write)
    '        'fs.Write(b, 0, b.Length)
    '        'fs.Close()

    '        For Each dr As DataRow In dtAll.Rows

    '            Dim contractid As String
    '            contractid = dr(0).ToString()

    '            Dim dtImg As New DataTable
    '            clsDalContract.ContractID = contractid
    '            dtImg = clsDalContract.GetDocImgByContractID

    '            For Each dr1 As DataRow In dtImg.Rows


    '                If dr1("image_vb") IsNot Nothing Then
    '                    Dim saveFileDialog1 As New SaveFileDialog()
    '                    saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
    '                    saveFileDialog1.Title = "ذخیره مدارک قرداد"
    '                    strFileName = contractid

    '                    With saveFileDialog1

    '                        .ShowDialog()

    '                        If strFileName.Length > 0 Then
    '                            'Dim ms As New IO.MemoryStream(ImageDictionary.Item(dr1("image_vb")))
    '                            'Dim Stream As Stream = New MemoryStream()
    '                            'Dim myByteArray As Byte = New Byte
    '                            'myByteArray = dr1("image_vb")

    '                            PictureBox2.Image = Image.FromStream(dr1("image_vb"))
    '                            PictureBox2.Image.Save(.FileName)
    '                            MsgBox("عکس مورد نظر در مسیر مربوطه با موفقیت ذخیره شد")
    '                        End If
    '                    End With

    '                End If

    '            Next
    '        Next




    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try


    'End Sub
End Class
