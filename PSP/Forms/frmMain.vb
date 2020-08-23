Imports log4net
Public Class frmMain

#Region "First"
    Dim Logger As ILog = log4net.LogManager.GetLogger(GetType(frmMain))
    Private Sub mnuDatabaseSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatabaseSetting.Click
        Dim _frmDatabaseSetting As New frmDatabaseSetting
        _frmDatabaseSetting.ShowDialog()
    End Sub

    Private Sub mnuAssignPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub mnuAccountingBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmAccounting
        frm.ShowDialog()
    End Sub
    Private Sub mnuAccountingMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmAccountingMakeFile
        frm.ShowDialog()
    End Sub
    Private Sub mnuAccountingUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub mnuSwitchBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub mnuSwitchMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub mnuInstallBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub mnuPrintInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub mnuLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub mnuUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUser.Click
        Dim frm As New frmDefUser
        frm.ShowDialog()
    End Sub
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'mnuReports.DropDownItems.Remove(mnuTransaction) 
        'mnuReports.DropDownItems.Remove(mnuRptTerminal)
        Dim frm As New frmLogin
        Config.XmlConfigurator.Configure()
      
        Logger.Info("This is test ...")
        frm.ShowDialog()
        SetIcons()
        tm_Tick(Me, e)
        SetFavorite()
    End Sub

    Private clsDALVariz As New ClassDALVariz(modPublicMethod.ConnectionString)
    Private Sub tm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tm.Tick
        tm.Stop()
        tsTime.Text = "ساعت: " & Format(Now, "HH:mm:ss")
        tsDay.Text = "روز: " & GetPersianWeekDay(Today)
        tsDate.Text = "تاریخ: " & GetDateNow()
        tsUser.Text = "کاربر: " & ClassUserLoginDataAccess.ThisUser.FullName_vc
        tm.Start()
    End Sub
    Public Sub SetFavorite()
        'Try
        '    Me.ExplorerBar1.Groups.RemoveAt(0)
        '    Dim myGroup As New Janus.Windows.ExplorerBar.ExplorerBarGroup
        '    myGroup.Text = "Favorite"
        '    myGroup.Key = "Group1"
        '    myGroup.Icon = My.Resources.FormGroupIcon
        '    Me.ExplorerBar1.Groups.Add(myGroup)
        '    Dim da As New ClassDalFormHistory(ConnectionString)
        '    Dim dt As New DataTable
        '    Dim myTamplate As ClassDalFormHistory.FormHistoryTemplate
        '    myTamplate.UserID = ClassUserLoginDataAccess.ThisUser.UserID
        '    dt = da.GetByUserID(myTamplate)
        '    For Each dr As DataRow In dt.Rows
        '        'Dim MyItem As New Janus.Windows.ExplorerBar.ExplorerBarItem
        '        MyItem.Key = dr.Item("Name_vc")
        '        MyItem.Text = dr.Item("Text_vc")
        '        MyItem.TagString = dr.Item("BasicType")
        '        MyItem.Icon = My.Resources.FormIcon
        '        Me.ExplorerBar1.Groups.Item(0).Items.Add(MyItem)
        '    Next
        'Catch ex As Exception
        '    ShowErrorMessage(ex.Message)
        'End Try
    End Sub
    'Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick
    '    'ShowForm(e.Item.Key)
    'End Sub
    Private Sub ShowForm(ByVal FormName As String)
        Dim ProjectName As String = Reflection.Assembly.GetExecutingAssembly.GetName.Name
        Try
            Dim tyOfStringVariable As Type = Type.GetType(ProjectName + "." + FormName)
            Dim frmObject As Object = Activator.CreateInstance(tyOfStringVariable)
            DirectCast(frmObject, Form).ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SetIcons()
        Try
            tsTime.Image = Image.FromFile(Application.StartupPath + "\Icons\Clock.gif")
            tsDay.Image = Image.FromFile(Application.StartupPath + "\Icons\Day.png")
            tsDate.Image = Image.FromFile(Application.StartupPath + "\Icons\Date.png")
            tsUser.Image = Image.FromFile(Application.StartupPath + "\Icons\User.gif")
        Catch ex As Exception
            'ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub mnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmGlobalSetting
        frm.ShowDialog()
    End Sub


    Private Sub mnuRptAllContractingParty_Contract_Account_Store_Device_Pos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptAllContractingParty_Contract_Account_Store_Device_Pos.Click
        Dim _frm As New frmRptGeneral
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptVisitorContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptVisitorContract.Click
        Dim _frm As New frmRptVisitorContracts
        _frm.ShowDialog()
    End Sub
    Private Sub mnuTransactionsByStoreID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _frm As New frmRptTransactionsByStoreID
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptTerminalGroupMass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTerminalGroupMass.Click
        Dim _frm As New frmRptMccMass
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptTerminalStateMass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTerminalStateMass.Click
        Dim _frm As New frmRptStateMass
        _frm.ShowDialog()

    End Sub

    Private Sub mnuRptTerminalCityMass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTerminalCityMass.Click
        Dim _frm As New frmrptCityByStateMass
        _frm.ShowDialog()

    End Sub

    Private Sub mnuRptTerminalMunicipalAreaNoMass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTerminalMunicipalAreaNoMass.Click
        Dim _frm As New frmRptMunicipalAreaNoByCityMass
        _frm.ShowDialog()

    End Sub

    Private Sub mnuMSwitch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMLoading.Click
        Dim frm As New frmLoading
        frm.ShowDialog()

    End Sub




    Private Sub mnuReassignPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _frm As New frmDeviceReAssigning
        _frm.ShowDialog()
    End Sub



    Private Sub mnuMSwitchMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmSwitchMakeFile
        frm.ShowDialog()
    End Sub

    Private Sub mnuIInstallBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIInstallBatch.Click

    End Sub

    'Private Sub mnuIInstallingConfirmation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim _frm As New frmInstallingConfirmation
    '    '_frm.ConfirmationType = frmInstallingConfirmation.ConfirmationTypeEnum.General
    '    _frm.ShowDialog()

    'End Sub
    'Private Sub mnuIInstallingDetailConfirmation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Dim _frm As New frmInstallingConfirmation
    '    ''_frm.ConfirmationType = frmInstallingConfirmation.ConfirmationTypeEnum.Detail
    '    '_frm.ShowDialog()
    'End Sub

    Private Sub mnuTTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTTransfer.Click

    End Sub




    Private Sub كارتابلبخشفنيToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كارتابلبخشفنيToolStripMenuItem.Click
        Dim _frm As New frmCallsFolowing
        _frm.ReferTo = 1
        _frm.Text = كارتابلبخشفنيToolStripMenuItem.Text
        _frm.ShowDialog()

    End Sub

    Private Sub كارتابلبخشبازاريابيToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كارتابلبخشبازاريابيToolStripMenuItem.Click
        Dim _frm As New frmCallsFolowing
        _frm.ReferTo = 2
        _frm.Text = كارتابلبخشبازاريابيToolStripMenuItem.Text
        _frm.ShowDialog()

    End Sub

    Private Sub كارتابلبانكToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كارتابلبانكToolStripMenuItem.Click
        Dim _frm As New frmCallsFolowing
        _frm.ReferTo = 3
        _frm.Text = كارتابلبانكToolStripMenuItem.Text
        _frm.ShowDialog()

    End Sub

    Private Sub mnuInstaller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInstaller.Click
        Dim _frm As New frmInstaller
        _frm.ShowDialog()

    End Sub



    Private Sub mnuIInstallingConfirmation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIInstallingConfirmation.Click
        Dim _frm As New frmInstallingConfirmation
        '_frm.ConfirmationType = frmInstallingConfirmation.ConfirmationTypeEnum.General
        _frm.ShowDialog()

    End Sub

    Sub ExecuteSqlScriptsWithOsql(ByVal dbName As String, _
    ByVal isWinAuth As Boolean, ByVal login As String, ByVal pwd As String, _
    ByVal scriptFile As String)
        'Dim osqlParams As String = ""
        '' the OSQL utility requires different parameters if using the Win or SQL 
        '' server security
        'If (isWinAuth) Then
        '    osqlParams = String.Format("-E -d {0} -i ", dbName)
        'Else
        '    osqlParams = String.Format("-U {0} -P {1} -d {2} -i ", login, pwd, _
        '        dbName)
        'End If
        '' execute each script file in the scripts array
        'Dim proc As New Process
        'proc.StartInfo.FileName = "osql.exe"
        'proc.StartInfo.CreateNoWindow = True
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        'proc.StartInfo.Arguments = osqlParams & """" & scriptFile + """"
        'proc.Start()
        '' wait until the scrip execution ends
        'proc.WaitForExit()


        Dim Str As String = "Insert Into Openrowset('SQLOLEDB','Netsisserver\sql2005';'mhosseini';'pspmaskan',CallCenter.dbo.temp_test_1) " & _
                            "(temname) " & _
                            "Select Case firstname_nvc " & _
                            "From Visitor_T  "
        Dim osqlParams As String = ""
        If (isWinAuth) Then
            osqlParams = String.Format("-E -d {0} -i ", dbName)
        Else
            osqlParams = String.Format("-U {0} -P {1} -d {2} -q ", login, pwd, _
                dbName)
        End If
        Dim proc As New Process
        proc.StartInfo.FileName = "osql.exe"
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.StartInfo.Arguments = osqlParams & """" & Str + """"
        proc.Start()
        proc.WaitForExit()
    End Sub

    Private Sub smnuTMSSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuTMSSendTo.Click
        Dim _frm As New frmTMSSendTo
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptTransactionDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTransactionDetail.Click
        'Dim _frm As New frmRptTransactionByMany()
        '_frm.FormType = frmRptTransactionByMany.Type.transaction_Detail
        '_frm.ShowDialog()
        Dim _frm As New frmRptGetAllTransactionsInDetail
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptTransactionNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTransactionNone.Click
        Dim _frm As New frmRptTransactionByMany()
        _frm.FormType = frmRptTransactionByMany.Type.Transaction_None
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptAgentActivitiesByTrns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptAgentActivitiesByTrns.Click
        Dim _frm As New frmrptAgentActivityByTrns()
        _frm.ShowDialog()
    End Sub


    Private Sub mnuRptCntTakhsisDiscordant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptCntTakhsisDiscordant.Click
        Dim _frm As New frmRptAgentDiscordantActivity()
        _frm.FormType = frmRptAgentDiscordantActivity.Type.ContractTakhsis
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptAgentActivities_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptAgentActivities.Click
        Dim _frm As New frmRptAgentActivities()
        _frm.ShowDialog()
    End Sub


    Private Sub mnuRptwithoutamountpercent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptwithoutamountpercent.Click
        Dim _frm As New frmRptwithoutamountpercent
        _frm.ShowDialog()
    End Sub



    Private Sub mnuMDeviceCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMDeviceCancel.Click
        Dim _frm As New frmDeviceCancel
        _frm.DeviceCancelType = frmDeviceCancel.DeviceCancelTypeEnum.DeviveCancelOK
        _frm.Text = mnuMDeviceCancel.Text
        _frm.ShowDialog()

    End Sub

    Private Sub mnuMDeviceCancelMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMDeviceCancelMakeFile.Click
        Dim _frm As New frmDeviceCancelMakeFile
        _frm.ShowDialog()

    End Sub



    Private Sub mnuMChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMChange.Click
        Dim _frm As New frmChangeMakeFile
        _frm.ShowDialog()

    End Sub

    Private Sub mnuVisitorPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisitorPayment.Click
        Dim _frm As New frmVisitorPayment
        _frm.ShowDialog()

    End Sub



    Private Sub mnuVariz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVariz.Click
        Dim _frm As New frmVariz
        _frm.ShowDialog()

    End Sub

    Private Sub mnuSwitchFeeSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSwitchFeeSchema.Click
        Dim _frm As New frmSwitchFeeSchema
        _frm.ShowDialog()
    End Sub




    Private Sub mnuTransfer_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransfer.Click
        Dim _frm As New frmTransfer
        _frm.ShowDialog()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Frm As New test
        _Frm.ShowDialog()

    End Sub

    Private Sub MnuProduceCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuProduceCode.Click
        Dim frm As New Frm_ProduceCode
        frm.ShowDialog()

    End Sub
    Private Sub MnuReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReprint.Click
        Dim frm As New Frm_MyReprint
        frm.ShowDialog()

    End Sub
    Private Sub MnuPosSeria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPosSeria.Click
        Dim frm As New Frm_PosSerials
        frm.ShowDialog()

    End Sub
    Private Sub MnuViewPosInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuViewPosInfo.Click
        Dim frm As New Frm_ViewPosInfo
        frm.ShowDialog()

    End Sub

    Private Sub frmProgressReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmProgressReport.Click
        Dim frm As New frmProgressReport
        frm.ShowDialog()
    End Sub

    Private Sub گزارشتراکنشهاینمایندگانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisitorTransactions.Click

        Dim frm As New frmVisitorTransactions
        frm.ShowDialog()

    End Sub

    Private Sub mnuRptTransaction_All_Count_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTransaction_All_Count.Click
        Dim frm As New frmRptTransaction_All_Count
        frm.ShowDialog()

    End Sub


    Private Sub mnuIncompleteContracts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIncompleteContracts.Click
        Dim _frm As New frmIncompleteContracts
        _frm.Text = mnuIncompleteContracts.Text
        _frm.ShowDialog()

    End Sub



    Private Sub mnuChangeProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeProject.Click
        Dim _frm As New frmChangeProject
        _frm.ShowDialog()
        Me.Text = modPublicMethod.AppName
    End Sub

    Private Sub mnuTransferContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransferContract.Click
        Dim _frm As New frmTransferContract
        _frm.ShowDialog()
    End Sub


    Private Sub mnuChangeVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeVisitor.Click
        Dim _frm As New frmChangeVisitorOfImportedRequest
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub

    Private Sub mnuRequestState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRequestState.Click
        Dim _frm As New frmRptRequestStatus
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuChangeequestStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeequestStatus.Click
        Dim _frm As New frmChangeRequestStatus
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub

    Private Sub mnuAllInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllInformation.Click
        Dim _frm As New frmRptGetAllInformation
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuChangeContractOfRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeContractOfRequest.Click
        Dim _frm As New frmChangeContractOfRequest
        _frm.ShowDialog()

    End Sub
    Private Sub mnuVisit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisit.Click
        Dim _frm As New frmRptPeriodicVisit
        _frm.VisitState = frmRptPeriodicVisit.VisitStateEnum.Visit
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuNoVisit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNoVisit.Click
        Dim _frm As New frmRptPeriodicVisit
        _frm.VisitState = frmRptPeriodicVisit.VisitStateEnum.NoVisit
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub MNUChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUChart.Click
        Dim _frm As New frmRptAgentActivityGroupByDate
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnufrmTransferRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufrmTransferRequest.Click
        Dim _frm As New frmTransferRequest
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub

    Private Sub mnuRptGetMonthlyAllInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptGetMonthlyAllInformation.Click
        Dim _frm As New frmRptGetMonthlyAllInformation
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptReverseAfterCutOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptReverseAfterCutOff.Click
        Dim _frm As New frmRptReverseAfterCutOff
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptwithoutamount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptwithoutamount.Click
        Dim _frm As New frmRptwithoutamount
        _frm.ShowDialog()

    End Sub

    Private Sub mnuRptCallsInfoDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptCallsInfoDelay.Click
        Dim _frm As New frmRptCallsInfoDelay()
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptPosVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptPosVersion.Click
        Dim _frm As New frmRptPosVersion
        _frm.ShowDialog()
    End Sub

#End Region


#Region "Marketing"
    Private Sub smnuImportRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuImportRequest.Click
        Dim _frm As New frmImportRequest
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub
    Private Sub smnuAssignVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAssignVisitor.Click
        Dim _frm As New frmAssignVisitorToImportedRequest
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub
    Private Sub smnuRequestToContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuRequestToContract.Click
        Dim _frm As New frmRequestToContract
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub
    Private Sub mnuMContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMContract.Click
        Dim _frmContractingparty_Contract_Account_Store_Device As New frmContractingparty_Contract_Account_Store_Device
        _frmContractingparty_Contract_Account_Store_Device.ShowDialog()

    End Sub
    Private Sub mnuMAccountingBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMAccountingBatch.Click
        Dim frm As New frmAccounting
        frm.ShowDialog()
    End Sub

    Private Sub mnuMAccountingMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMAccountingMakeFile.Click
        Dim frm As New frmAccountingMakeFile
        frm.ShowDialog()

    End Sub

    Private Sub mnuMAccountingUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMAccountingUpdate.Click
        Dim frm As New frmAccountingUpdate
        frm.ShowDialog()

    End Sub

    Private Sub mnuMPOsAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMPOsAssign.Click
        Dim _frmDeviceAssigning As New frmDeviceAssigning
        _frmDeviceAssigning.ShowDialog()
    End Sub
    Private Sub mnuMSwitchBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMSwitchBatch.Click
        Dim frm As New frmSwitch
        frm.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMAssignPosToVisitor.Click
        Dim _frm As New frmAssignPosToVisitor
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub


    Private Sub mnuMAssignContractToVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMAssignContractToVisitor.Click
        Dim _frm As New frmAssignContractToVisitor
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub
#End Region

#Region "Installing"
    Private Sub mnnIInstallBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnnIInstallBatch.Click
        Dim frm As New frmInstalling
        frm.ShowDialog()
    End Sub

    Private Sub mnuIPrintInstalling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIPrintInstalling.Click
        Dim frm As New frmInstallingPrint
        frm.ShowDialog()

    End Sub


#End Region

#Region "Other"
    Private Sub mnuPosChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPosChange.Click
        Dim _frm As New frmPosChange
        _frm.ShowDialog()

    End Sub

    Private Sub mnuBlockContracts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBlockContracts.Click
        Dim _frm As New frmBlockContract
        _frm.ShowDialog()

    End Sub
    Private Sub mnuChangeVisitors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeVisitors.Click
        Dim _frm As New frmChangeVisitors
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()

    End Sub


#End Region

#Region "Transfer"
    Private Sub mnuSwitchSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSwitchSendTo.Click
        Dim frm As New frmSwitchSendTo
        frm.ShowDialog()
    End Sub

    Private Sub mnuSendToCMSSwitch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSendToCMSSwitch.Click
        Dim frm As New frmSendToCMSSwitch
        frm.ShowDialog()
    End Sub

    Private Sub mnuSwitch_modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSwitch_modify.Click
        Dim _frm As New frmSwitchSendTo_Modify
        _frm.ShowDialog()

    End Sub

    Private Sub mnuSwitchPaymentMethodType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSwitchPaymentMethodType.Click
        Dim _frm As New frmSwitchPaymentMethodType
        _frm.Text = mnuSwitchPaymentMethodType.Text
        _frm.ShowDialog()

    End Sub
#End Region

#Region "Basic Form"

    Private Sub mnuState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuState.Click
        Dim _frmState As New frmState
        _frmState.ShowDialog()
    End Sub
    Private Sub mnuCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCity.Click
        Dim _frmCity As New frmCity
        _frmCity.ShowDialog()
    End Sub
    Private Sub mnuGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGroup.Click
        Dim _frmGroup As New frmGroup
        _frmGroup.ShowDialog()
    End Sub
    Private Sub mnuBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBranch.Click
        Dim _frmBranch As New frmBranch
        _frmBranch.ShowDialog()
    End Sub
    Private Sub mnuVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVisitor.Click
        Dim _frm As New frmVisitor
        _frm.ShowDialog()
    End Sub
    Private Sub mnuContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub mnuPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPos.Click
        Dim _frmPos As New frmPos
        _frmPos.ShowDialog()
    End Sub
    Private Sub mnuCIdentityType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCIdentityType.Click
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.CIdentityType
        _frmBasicTypes.ShowDialog()
    End Sub
    Private Sub mnuSIdentityType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSIdentityType.Click
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.SIdentityType
        _frmBasicTypes.ShowDialog()
    End Sub
    Private Sub mnuDegree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDegree.Click
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.Degree
        _frmBasicTypes.ShowDialog()
    End Sub
    Private Sub mnuAccountType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccountType.Click
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.AccountType
        _frmBasicTypes.ShowDialog()
    End Sub
    Private Sub mnuEstateCondition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstateCondition.Click
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.EstateCondition
        _frmBasicTypes.ShowDialog()
    End Sub
    Private Sub mnuMunicipalArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMunicipalArea.Click
        Dim frm As New frmMunicipal
        frm.ShowDialog()
    End Sub
    Private Sub mnuAgentMonthlyGoalsGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgentMonthlyGoalsGrid.Click
        Dim frm As New frmAgentMonthlyGoalsGrid
        frm.ShowDialog()
    End Sub
    Private Sub mnuAgentPerformanceGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgentPerformanceGrid.Click
        Dim frm As New frmAgentPerformanceGrid
        frm.ShowDialog()
    End Sub
    Private Sub mnuAgentGivenPOSGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgentGivenPOSGrid.Click
        Dim frm As New frmAgentGivenPOSGrid
        frm.ShowDialog()
    End Sub
    Private Sub mnuPosCancelDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPosCancelDesc.Click

        Dim _Frm As New frmDeviceCancelDescGrid
        _Frm.ShowDialog()

    End Sub
    Private Sub mnuCMSProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCMSProject.Click
        Dim frm As New frmCMSProject
        frm.ShowDialog()
    End Sub
    Private Sub mnuErrorAndWarrnings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuErrorAndWarrnings.Click
        Dim frm As New frmError
        frm.ShowDialog()

    End Sub

#End Region

#Region "last"



    Private Sub mnuUndoDeviceCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndoDeviceCancel.Click
        Dim frm As New frmUndoDeviceCancel
        frm.ShowDialog()
    End Sub

    Private Sub mnuVoucherReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVoucherReport.Click
        Dim frm As New frmVoucherReport
        frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        frm.ShowDialog()
    End Sub

    Private Sub mnuRptGetPazirandeInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptGetPazirandeInfo.Click
        Dim _frm As New frmRptGetPazirandehInfo
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub



    Private Sub mnuRPTvisitorPosCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRPTvisitorPosCount.Click
        Dim _frm As New frmVisitorPos
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuChangePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangePass.Click
        Dim frm As New frmChangePass
        frm.ShowDialog()
    End Sub

    Private Sub mnurptAssignPosToVisitorConflict_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurptAssignPosToVisitorConflict.Click
        Dim _frm As New frmrptAssignPosToVisitorConflict
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptSerialCirculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptSerialCirculation.Click
        Dim _frm As New frmRptSerialCirculation
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuTransferContractVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransferContractVisitor.Click
        Dim _frm As New frmTransferVisitor
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptInstalledPosStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptInstalledPosStatus.Click
        Dim _frm As New frmRptPosStatus
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

    Private Sub mnuRptGetTransactionSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptGetTransactionSummary.Click
        Dim _frm As New frmRptGetAllTransactionsSummary
        _frm.Text = DirectCast(sender, ToolStripMenuItem).Text
        _frm.ShowDialog()
    End Sub

#End Region




    Private Sub حوالهToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles حوالهToolStripMenuItem.Click
        Dim _frm As New frmWarehouseTransfer(WarehouseStatementType.Transfer)
        _frm.ShowDialog()
    End Sub

    Private Sub رسیدToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles رسیدToolStripMenuItem.Click
        Dim _frm As New frmWarehouseTransfer(WarehouseStatementType.Receipt)
        _frm.ShowDialog()
    End Sub

    Private Sub تماماسنادToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تماماسنادToolStripMenuItem.Click
        Dim _frm As New frmWarehouse()
        _frm.ShowDialog()
    End Sub

    Private Sub گردشسریالToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گردشسریالToolStripMenuItem.Click
        Dim _frm As New frmWarehouseSerialHistoryReport()
        _frm.ShowDialog()
    End Sub

    Private Sub mnuLogViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogViewer.Click
        Dim _frm As New frmLogViewer()
        _frm.ShowDialog()
    End Sub

    Private Sub mnuFanavaBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFanavaBatch.Click
        Dim frm As New frmFanavaBatch
        frm.ShowDialog()
    End Sub

    Private Sub mnuPasargadBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPasargadBatch.Click
        Dim frm As New frmPasargadBatch
        frm.ShowDialog()
    End Sub

    Private Sub mnuFanavaContractImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFanavaContractImport.Click
        Dim frm As New frmFanavaContractImport
        frm.ShowDialog()
    End Sub


End Class
