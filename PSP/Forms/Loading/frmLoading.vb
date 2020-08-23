Public Class frmLoading
    Dim DAL As New Dal(ConnectionString)
    Dim dalpos As New ClassDALPos(ConnectionString)
    Dim dalloading As New ClassDALLoading(ConnectionString)
    Dim Pos As Dal.PosTemplate
    Dim Device As Dal.DeviceTemplate

    Dim SerialNumber As String
    Dim ProductNumber As String
    Dim PosCode As String
    Dim Outlet As String
    Dim User As String
    Dim Password As String
    Dim Key As String = "695B1CA8F2942E09"
    Dim PosId As Int64

    'Dim second As Int16 = 0
    Dim outerSecond As Int32 = 0


    Private Sub frmLoading_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.ResetData()
            GetSerialPortNames()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub frmLoading_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPosSerial.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Me.ResetData()
                Pos = DAL.GetPosBySerial(Me.txtPosSerial.Text)
                If Pos.PosID = 0 Then
                    Me.lblContractID.Text = "پز مورد نظر یافت نشد"
                    Me.lblCode_vc.Text = "پز مورد نظر یافت نشد"
                    Me.lblOutlet_vc.Text = "پز مورد نظر یافت نشد"
                    Me.lblPassword_vc.Text = "پز مورد نظر یافت نشد"
                Else
                    Device = DAL.GetDeviceByPosID(Pos.PosID)
                    If Device.DeviceID = 0 Then
                        Me.lblContractID.Text = "پز مورد نظر یافت نشد"
                        Me.lblCode_vc.Text = "پز مورد نظر فاقد دستگاه است"
                        Me.lblOutlet_vc.Text = "پز مورد نظر فاقد دستگاه است"
                        Me.lblPassword_vc.Text = "پز مورد نظر فاقد دستگاه است"
                    Else
                        Dim dt As New DataTable
                        dt = DAL.GetContractByDeviceID(Device.DeviceID)
                        Me.lblContractID.Text = dt.Rows(0).Item("ContractID").ToString
                        Me.lblCode_vc.Text = Device.Code_vc
                        Me.lblOutlet_vc.Text = Device.Outlet_vc
                        Me.lblPassword_vc.Text = Device.Code_vc.Replace("0", "")
                    End If
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            dalloading.BeginProc()
            If doInserLoading() Then
                Empty()
            Else
                ShowErrorMessage("بارگذاري انجام نشد")
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            dalloading.EndProc()
            Me.txtPosSerial.Focus()
        End Try
    End Sub
    Private Function doInserLoading() As Boolean
        Try
            If Me.Pos.PosID > 0 AndAlso Me.Device.DeviceID > 0 Then
                If dalloading.GetLoading(Pos.PosID, Device.DeviceID) = 0 Then
                    dalloading.Insert(Device.DeviceID, Pos.PosID)
                End If
                doInserLoading = True
            Else
                doInserLoading = False
            End If
        Catch ex As Exception
            doInserLoading = False
        End Try

    End Function

    Private Sub ResetData()
        Me.Pos.PosID = 0
        Me.Device.DeviceID = 0
    End Sub

#Region "SerialPort"
    Private Function AutoLoading() As Boolean
        Dim oknok As String
        Try
            If comPort.IsOpen = True Then
                AutoLoading = True
                comPort.DiscardInBuffer()
            Else
                AutoLoading = False
                Exit Function
            End If

            Dim ReceivedData As String = ""
            Dim Header As String = ""
            Dim Message As String = ""

            '===ارسال مكررbegin تا دريافت ok از دستگاه 
            Do
                comPort.ReadTimeout = 1000
                If SendSerialDataInLoopUntilReceive(Chr(5), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 'ok
                        ReceivedData = ""
                        Exit Do
                End Select
            Loop
            comPort.ReadTimeout = 15000
            '===wait تا دريافت serialnumber از دستگاه 
            slblStatus.Text = "درانتظار دريافت شماره سريال از دستگاه"
            Application.DoEvents()
            If WaitUntilReceiveData(ReceivedData) = False Then
                Exit Function
            End If
            'If InStr(ReceivedData, Chr(24)) Then 'cancel
            '    Exit Function
            'End If

            Do
                slblStatus.Text = "مرحله دريافت شماره سريال"
                Application.DoEvents()
                Header = ReceivedData.Substring(0, 2)
                Select Case Header.ToUpper
                    Case "SN"
                        Empty()
                        If ReceivedData.Length - 2 = 10 Then
                            SerialNumber = ReceivedData.Substring(2, ReceivedData.Length - 2)
                            ReceivedData = ""
                            Exit Do
                        Else
                            SendSerialDataUntilReceiveData(Chr(21), ReceivedData)
                        End If
                    Case Else
                        SendSerialDataUntilReceiveData(Chr(21), ReceivedData)
                End Select
            Loop
            '===چك serialnumber 
            '===
            Do
                slblStatus.Text = "مرحله چك شماره سريال "
                Application.DoEvents()
                If DoSerialNumberWorking(SerialNumber, Message, PosId) Then
                    Select Case Message
                        Case "Serial OK"
                            Exit Do
                        Case "Invalid Serial"
                            SendSerialData(Chr(16)) 'dle
                            ShowErrorMessage("شماره سريال يافت نشد")
                            Exit Function
                    End Select
                Else
                    SendSerialData(Chr(24)) 'cancel
                    AutoLoading = False
                    Exit Function
                End If
            Loop
            '===ارسال ok تا دريافت productnumber از دستگاه 

            oknok = Chr(6)
            Do
                slblStatus.Text = "مرحله دريافت كد محصول "
                Application.DoEvents()
                If SendSerialDataUntilReceiveData(oknok, ReceivedData) = False Then
                    Exit Function
                End If
                'If InStr(ReceivedData, Chr(24)) Then 'cancel
                '    Exit Function
                'End If
                Header = ReceivedData.Substring(0, 2)
                Select Case Header.ToUpper
                    Case "PN"
                        If ReceivedData.Length - 2 = 12 Then
                            ProductNumber = ReceivedData.Substring(2, ReceivedData.Length - 2)
                            ReceivedData = ""
                            Exit Do
                        Else
                            oknok = Chr(21)
                        End If
                    Case Else
                        oknok = Chr(21)
                End Select
            Loop
            '==Update productnumber
            '===
            slblStatus.Text = "مرحله بروزرساني كد محصول "
            Application.DoEvents()
            If DoProductNumberWorking(PosId, ProductNumber) = False Then
                SendSerialData(Chr(24)) 'cancel
                AutoLoading = False
                Exit Function
            End If
            '===
            slblStatus.Text = " ارسال ok  به دستگاه"
            Application.DoEvents()
            SendSerialData(Chr(6))

            '===گرفتن كدها
            slblStatus.Text = "مرحله گرفتن كدها"
            Application.DoEvents()

            Try
                Device = DAL.GetDeviceByPosID(PosId)
                If Device.DeviceID = 0 Then
                    Me.lblContractID.Text = "پز مورد نظر یافت نشد"
                    Me.lblCode_vc.Text = "پز مورد نظر فاقد دستگاه است"
                    Me.lblOutlet_vc.Text = "پز مورد نظر فاقد دستگاه است"
                    Me.lblPassword_vc.Text = "پز مورد نظر فاقد دستگاه است"
                    SendSerialData(Chr(16))
                    Exit Function
                End If
                Dim dt As New DataTable
                dt = DAL.GetContractByDeviceID(Device.DeviceID)
                Me.txtPosSerial.Text = SerialNumber
                Me.lblContractID.Text = dt.Rows(0).Item("ContractID").ToString
                Me.lblCode_vc.Text = Device.Code_vc
                Me.lblOutlet_vc.Text = Device.Outlet_vc
                Me.lblPassword_vc.Text = Device.Code_vc.Replace("0", "")
                PosCode = Device.Code_vc
                Outlet = Device.Outlet_vc
                User = Device.Code_vc
                Password = Device.Code_vc.Replace("0", "") ' "102410" 'Device.Code_vc.Replace("0", "")
                Me.Pos.PosID = PosId
            Catch ex As Exception
                SendSerialData(Chr(24)) 'cancel
                AutoLoading = False
                Exit Function
            End Try
            '===ارسال posCode تا دريافت ok از دستگاه 
            slblStatus.Text = "مرحله ارسال poscode"
            Application.DoEvents()

            Do
                If SendSerialDataUntilReceiveChar(Chr(2) + "P" + PosCode + Chr(3), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 'ok
                        ReceivedData = ""
                        Exit Do
                    Case 21 'nok
                        ReceivedData = ""
                    Case 24 'error
                        Errorhandle()
                        Exit Function
                End Select
            Loop
            '===ارسال outlet تا دريافت ok از دستگاه 
            Do
                slblStatus.Text = "مرحله ارسال outlet"
                Application.DoEvents()

                If SendSerialDataUntilReceiveChar(Chr(2) + "O" + Outlet + Chr(3), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 'ok
                        ReceivedData = ""
                        Exit Do
                    Case 21 'nok
                        ReceivedData = ""
                    Case 24 'error
                        Errorhandle()
                        Exit Function
                End Select
            Loop
            '===ارسال user تا دريافت ok از دستگاه 
            Do
                slblStatus.Text = "مرحله ارسال user"
                Application.DoEvents()

                If SendSerialDataUntilReceiveChar(Chr(2) + "U" + User + Chr(3), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 'ok
                        ReceivedData = ""
                        Exit Do
                    Case 21 'nok
                        ReceivedData = ""
                    Case 24 'error
                        Errorhandle()
                        Exit Function

                End Select
            Loop
            '===ارسال password تا دريافت ok از دستگاه 
            Do
                slblStatus.Text = "مرحله ارسال password"
                Application.DoEvents()

                If SendSerialDataUntilReceiveChar(Chr(2) + "S" + Password + Chr(3), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 'ok
                        ReceivedData = ""
                        Exit Do
                    Case 21 'nok
                        ReceivedData = ""
                    Case 24 'error
                        Errorhandle()
                        Exit Function
                End Select
            Loop
            '===ارسال key تا دريافت ok از دستگاه 
            Do
                slblStatus.Text = "مرحله ارسال Key"
                Application.DoEvents()

                If SendSerialDataUntilReceiveChar(Chr(2) + "K" + Key + Chr(3), ReceivedData) = False Then
                    Exit Function
                End If
                Select Case ReceivedData
                    Case 6 '"ok"
                        ReceivedData = ""
                        Exit Do
                    Case 21 '"NOK"
                        ReceivedData = ""
                    Case 24 '"ERROR"
                        Errorhandle()
                        Exit Function
                End Select
            Loop
            Try
                slblStatus.Text = "مرحله ثبت بارگذاري"
                Application.DoEvents()
                dalloading.BeginProc()
                If doInserLoading() = True Then
                    SendSerialData(Chr(23)) 'end
                Else
                    SendSerialData(Chr(16)) 'dle
                    AutoLoading = False
                    Exit Function
                End If
            Catch ex As Exception
                SendSerialData(Chr(16)) 'dle
                AutoLoading = False
                Throw ex
            Finally
                dalloading.EndProc()
            End Try
        Catch ex As Exception
            AutoLoading = False
            Throw ex
        End Try
    End Function
    Private Sub Empty()
        SerialNumber = ""
        ProductNumber = ""
        PosCode = ""
        Outlet = ""
        User = ""
        Password = ""
        PosId = 0
        Me.txtPosSerial.Clear()
        Me.lblPassword_vc.Text = ""
        Me.lblCode_vc.Text = ""
        Me.lblOutlet_vc.Text = ""
        Me.lblContractID.Text = ""

    End Sub
    Private Sub Errorhandle()
        Try
            Empty()
            ShowErrorMessage("عمليات بارگذاري با خطا مواجه شد")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function DoSerialNumberWorking(ByVal SerialNumber As String, ByRef Message As String, ByRef posid As Int64) As Boolean
        Try
            DoSerialNumberWorking = True
            Me.ResetData()
            Pos = DAL.GetPosBySerial(SerialNumber)
            posid = Pos.PosID
            If Pos.PosID = 0 Then
                Message = "Invalid Serial"
                Exit Function
            Else
                Message = "Serial OK"
            End If
        Catch ex As Exception
            DoSerialNumberWorking = False
        End Try
    End Function
    Private Function DoProductNumberWorking(ByVal posid As Int64, ByVal ProductNumber As String) As Boolean
        Try
            dalpos.BeginProc()
            dalpos.UpdatePos_onlyProductNumber(posid, ProductNumber)
            DoProductNumberWorking = True
        Catch ex As Exception
            DoProductNumberWorking = False
        Finally
            dalpos.EndProc()
        End Try
    End Function
    Sub SendSerialData(ByVal Senddata As String)
        Try
            Dim Incoming As String = ""
            If comPort.IsOpen = False Then
                MsgBox("The port is not open")
            Else
                comPort.Write(Senddata)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Function SendSerialDataInLoopUntilReceive(ByVal Senddata As String, ByRef ReceiveData As String) As Boolean
        Try
            Dim Incoming As String = ""
            If comPort.IsOpen = False Then
                ReceiveData = ""
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataInLoopUntilReceive = False
                MsgBox("The port is not open")
            Else
                comPort.Write(Senddata)
                'second = 0
                outerSecond = 0
                Do
                    If outerSecond < 20 Then
                        Application.DoEvents()
                        Continue Do
                    End If
                    outerSecond = 0
                    'InnerTimer.Enabled = True
                    'Application.DoEvents()
                    'If second >= 20 Then
                    '    ReceiveData = ""
                    '    InnerTimer.Enabled = False
                    '    Application.DoEvents()
                    '    SendSerialDataInLoopUntilReceive = False
                    '    MsgBox("Timeout!")
                    '    Exit Function
                    'End If
                    Try
                        Incoming = ""
                        Incoming = comPort.ReadChar() 'comPort.ReadTo(Chr(10))
                    Catch ex As Exception
                        If ex.Message <> "The operation has timed out." Then
                            ReceiveData = ""
                            'InnerTimer.Enabled = False
                            Application.DoEvents()
                            SendSerialDataInLoopUntilReceive = False
                            Throw ex
                        End If
                    End Try
                    If Incoming Is Nothing OrElse Incoming <> "" Then
                        Exit Do
                    Else
                        comPort.Write(Senddata)
                    End If
                Loop
                ReceiveData = Incoming
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataInLoopUntilReceive = True
            End If
        Catch ex As Exception
            ReceiveData = ""
            'InnerTimer.Enabled = False
            Application.DoEvents()
            SendSerialDataInLoopUntilReceive = False
            Throw ex
        End Try
    End Function
    Function WaitUntilReceiveData(ByRef ReceiveData As String) As Boolean
        Try
            Dim Incoming As String = ""
            If comPort.IsOpen = False Then
                ReceiveData = ""
                'InnerTimer.Enabled = False
                Application.DoEvents()
                WaitUntilReceiveData = False
                MsgBox("The port is not open")
            Else
                Do
                    'second = 0
                    'InnerTimer.Enabled = True
                    Application.DoEvents()
                    'If second >= 20 Then
                    '    ReceiveData = ""
                    '    'InnerTimer.Enabled = False
                    '    Application.DoEvents()
                    '    WaitUntilReceiveData = False
                    '    MsgBox("Timeout!")
                    '    Exit Function
                    'End If
                    Try
                        Incoming = ""
                        Incoming = comPort.ReadTo(Chr(3)) 'comPort.ReadTo(Chr(10))
                    Catch ex As Exception
                        'If ex.Message <> "The operation has timed out." Then
                        ReceiveData = ""
                        'InnerTimer.Enabled = False
                        Application.DoEvents()
                        WaitUntilReceiveData = False
                        SendSerialData(Chr(24))
                        Exit Function
                        ' End If
                    End Try
                    If Incoming <> "" Then
                        Exit Do
                    End If
                Loop
                ReceiveData = Incoming.Replace(Chr(2), "")
                'InnerTimer.Enabled = False
                Application.DoEvents()
                WaitUntilReceiveData = True

            End If
        Catch ex As Exception
            ReceiveData = ""
            'InnerTimer.Enabled = False
            Application.DoEvents()
            WaitUntilReceiveData = False
            Throw ex
        End Try
    End Function
    Function SendSerialDataUntilReceiveData(ByVal Senddata As String, ByRef ReceiveData As String) As Boolean
        Try
            Dim Incoming As String = ""
            If comPort.IsOpen = False Then
                ReceiveData = ""
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataUntilReceiveData = False
                MsgBox("The port is not open")
            Else
                comPort.Write(Senddata)
                Do
                    'second = 0
                    'InnerTimer.Enabled = True
                    Application.DoEvents()
                    'If second >= 20 Then
                    '    ReceiveData = ""
                    '    InnerTimer.Enabled = False
                    '    Application.DoEvents()
                    '    SendSerialDataUntilReceiveData = False
                    '    MsgBox("Timeout!")
                    '    Exit Function
                    'End If
                    Try
                        Incoming = ""
                        Incoming = comPort.ReadTo(Chr(3)) 'comPort.ReadTo(Chr(10))
                    Catch ex As Exception
                        'If ex.Message <> "The operation has timed out." Then
                        ReceiveData = ""
                        'InnerTimer.Enabled = False
                        Application.DoEvents()
                        SendSerialDataUntilReceiveData = False
                        SendSerialData(Chr(24))
                        Exit Function
                        'End If
                    End Try
                    If Incoming <> "" Then
                        Exit Do
                    End If
                Loop
                ReceiveData = Incoming.Replace(Chr(2), "")
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataUntilReceiveData = True

            End If
        Catch ex As Exception
            ReceiveData = ""
            'InnerTimer.Enabled = False
            Application.DoEvents()
            SendSerialDataUntilReceiveData = False
            Throw ex
        End Try
    End Function
    Function SendSerialDataUntilReceiveChar(ByVal Senddata As String, ByRef ReceiveData As String) As Boolean
        Try
            Dim Incoming As String = ""
            If comPort.IsOpen = False Then
                ReceiveData = ""
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataUntilReceiveChar = False
                MsgBox("The port is not open")
            Else
                comPort.Write(Senddata)
                Do
                    'Second = 0
                    'InnerTimer.Enabled = True
                    Application.DoEvents()
                    'If Second() >= 20 Then
                    '    ReceiveData = ""
                    '    InnerTimer.Enabled = False
                    '    Application.DoEvents()
                    '    SendSerialDataUntilReceiveChar = False
                    '    MsgBox("Timeout!")
                    '    Exit Function
                    'End If
                    Try
                        Incoming = ""
                        Incoming = comPort.ReadChar 'comPort.ReadTo(Chr(10))
                    Catch ex As Exception
                        'If ex.Message <> "The operation has timed out." Then
                        ReceiveData = ""
                        'InnerTimer.Enabled = False
                        Application.DoEvents()
                        SendSerialDataUntilReceiveChar = False
                        SendSerialData(Chr(24))
                        Exit Function
                        'End If
                    End Try
                    If Incoming Is Nothing OrElse Incoming <> "" Then
                        Exit Do
                    End If
                Loop
                ReceiveData = Incoming
                'InnerTimer.Enabled = False
                Application.DoEvents()
                SendSerialDataUntilReceiveChar = True

            End If
        Catch ex As Exception
            ReceiveData = ""
            'InnerTimer.Enabled = False
            Application.DoEvents()
            SendSerialDataUntilReceiveChar = False
            Throw ex
        End Try
    End Function

    Function ReceiveSerialDataUntilReceive() As String
        Dim returnStr As String = ""
        Do
            Dim Incoming As String = comPort.ReadLine
            If Incoming IsNot Nothing Then
                returnStr &= Incoming & vbCrLf
                Exit Do
            End If
        Loop
        Return returnStr
    End Function
    Private Sub SerialPort_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)

    End Sub
    Private Sub btnStartListening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartListening.Click
        Try
            If cboPortName.SelectedIndex = -1 Then
                ShowErrorMessage("پورت را انتخاب كنيد")
                Exit Sub
            End If
            OpenPort(cboPortName.Text)
            txtPosSerial.Enabled = False
            btnLoad.Enabled = False
            slblStatus.Text = "پورت باز شد"
            Application.DoEvents()
            Do
                slblStatus.Text = "آغاز ارسال درخواست به دستگاه"
                Application.DoEvents()
                If AutoLoading() = False Then
                    Exit Do
                End If
            Loop
            slblStatus.Text = "پايان ارسال درخواست به دستگاه"
        Catch ex As Exception
            slblStatus.Text = ""
            ShowMessage(ex.Message)
        End Try
    End Sub


    Private Sub btnFinishListening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinishListening.Click
        Try
            ClosePort()
            txtPosSerial.Enabled = True
            btnLoad.Enabled = True
        Catch ex As Exception
            ShowMessage(ex.Message)
        End Try
    End Sub
    Private Function OpenPort(ByVal PortNo As String) As Boolean
        Try
            With comPort
                If .IsOpen = True Then Close() 'close the port  
                .PortName = PortNo
                .BaudRate = 9600
                .Open()
            End With
            OpenPort = True
        Catch ex As Exception
            OpenPort = False
            Throw ex
        End Try
    End Function
    Private Function ClosePort() As Boolean
        Try
            With comPort
                If .IsOpen = True Then comPort.Close() 'close the port  
            End With
            ClosePort = True
            slblStatus.Text = "پورت بسته شد"
        Catch ex As Exception
            ClosePort = False
            Throw ex
        End Try
    End Function
    Sub GetSerialPortNames()

        ' Show all available COM ports.  

        For Each sp As String In My.Computer.Ports.SerialPortNames

            cboPortName.Items.Add(sp)

        Next

    End Sub

#End Region

    'Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    second += 1
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim returnValue As String = ""

        Try
            returnValue = comPort.ReadTo(Chr(10))

        Catch ex As Exception

        End Try
        MsgBox(returnValue)


        'If returnValue Is Nothing Then
        '    returnValue = ""
        'End If
        'If returnValue <> "" Then
        '    MessageBox.Show(returnValue)
        '    Exit Do
        'End If
        '    Loop

        'Catch ex As Exception
        '    ShowErrorMessage(ex.Message)
        'End Try
    End Sub

    Private Sub comPort_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        'Dim buffer As Char()
        'Dim offset As Integer
        'Dim count As Integer
        'Dim returnValue As String
        'Try
        '    returnValue = comPort.ReadTo("$")
        '    If returnValue Is Nothing Then
        '        returnValue = ""
        '    End If
        '    'If comPort.ReadExisting.Length = 0 Then
        '    '    returnValue = "empty"
        '    'End If

        '    MessageBox.Show(returnValue)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        'Dim buffer As Char() = ""
        'Dim offset As Integer = 0
        'Dim count As Integer = 1
        'Dim returnValue As String

        'comPort.Read(buffer, offset, buffer.Length)
        'MessageBox.Show(buffer)


    End Sub

    
    Private Sub outerTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles outerTimer.Tick
        outerSecond = outerSecond + 1
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class