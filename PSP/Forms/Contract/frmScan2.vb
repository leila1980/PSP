Public Class frmScan2



    Public ContractId As String

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Dim CD As New WIA.CommonDialog
    Dim F As WIA.ImageFile



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim strFileName As String = cboDocType.Text
            Dim strBasePath As String = Nothing

            If ContractId IsNot Nothing And Not Me.PictureBox1.Image Is Nothing Then
                strBasePath = My.Settings.ContractDocImg_Path.Trim & "\DocumentsPhotos\" + ContractId
                ' >> Check if Folder Exists 
                If System.IO.Directory.Exists(strBasePath) = False Then
                    Call System.IO.Directory.CreateDirectory(strBasePath)
                End If
                ' >> Save Picture 



                Dim saveFileDialog1 As New SaveFileDialog()
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
                saveFileDialog1.Title = "ذخیره مدارک قرداد"
                saveFileDialog1.ShowDialog()


                If saveFileDialog1.FileName <> "" Then

                   
              

                    'If System.IO.File.Exists(saveFileDialog1.FileName) = False Then

                    F.SaveFile(saveFileDialog1.FileName)
                    Me.SaveImageDocInDb(saveFileDialog1.FileName)

                    'F.SaveFile(strBasePath + "\" + strFileName + "." + F.FileExtension)
                    'Me.SaveImageDocInDb(strBasePath & "\" & strFileName + "." + F.FileExtension)

                    MsgBox("عکس " + " " + cboDocType.Text + "درمسیر" + strBasePath + _
                           "  ودیتابیس با موفقیت ذخیره شد")
                    'Else
                    '    MessageBox.Show("این عکس  قبلا ذخیره شده است")
                    'End If

                End If



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("مشکلی در ذخیره سازی عکس وجود دارد")
        End Try
    End Sub

    Private Sub FrmScan2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FillcboDocType()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillcboDocType()
        Try
            clsDalContract.BeginProc()
            Me.cboDocType.DataSource = clsDalContract.GetAllImageTypes()
            Me.cboDocType.DisplayMember = "ImageType"
            Me.cboDocType.ValueMember = "ImageTypeID"

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub


    Private Sub SaveImageDocInDb(ByVal ImageURL As String)

        Try

            If GetImageSize(Me.PictureBox1.Image) > 320 And GetImageSize(Me.PictureBox1.Image) < 420 Then

                Me.PictureBox1.Image = Me.ResizeImage(Me.PictureBox1.Image, New Size(600, 800))
            ElseIf GetImageSize(Me.PictureBox1.Image) > 420 Then
                ShowMessage(" سایز عکس اسکن شده باید کوچکتر از 420 کیلوبایت باشد")
                Exit Sub
            End If


            clsDalContract.BeginProc()

            clsDalContract.ImageTypeID = cboDocType.SelectedValue
            clsDalContract.ImageURL_vc = ImageURL

            Dim converter As New ImageConverter
            clsDalContract.Image_vb = converter.ConvertTo(Me.PictureBox1.Image, GetType(Byte()))

            clsDalContract.ContractID = Convert.ToInt64(Me.ContractId)

            clsDalContract.InsertContractDocImg()

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()

        End Try
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Try

       
        F = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)

        If F IsNot Nothing Then
            Dim MStream As IO.MemoryStream = Nothing
            Try
                'Convert the raw scanner output into a byte array
                Dim ImgBytes() As Byte = DirectCast(F.FileData.BinaryData, Byte())
                'Read the image data bytes into a MemoryStream
                MStream = New IO.MemoryStream(ImgBytes)
                'Create a Bitmap from the memory stream data
                Dim Bmp As New Drawing.Bitmap(MStream)
                'Assign the bitmap as the PictureBox Image
                PictureBox1.Image = Bmp
                    'Do a victory dance. It worked!

            Catch ex As Exception
                MsgBox("An error occurred while converting scan data to a bitmap: " & ex.Message)
            End Try
                If MStream IsNot Nothing Then
                    MStream.Dispose()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("مشکلی در اسکن عکس وجود دارد")
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

    Private Function GetImageSize(ByVal img As Image) As Decimal

        Dim File As String = IO.Path.ChangeExtension(IO.Path.GetTempFileName, "jpg")
        img.Save(File, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim fInfo As New IO.FileInfo(File)
        Dim Imagesize As String = fInfo.Length / 1024
        'MessageBox.Show(Imagesize & "KB")
        IO.File.Delete(File)
        Return Imagesize

    End Function

End Class