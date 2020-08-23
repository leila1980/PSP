Public Class frmDeviceAssigningReprint
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private dtAssigningPos As New DataTable
    Private Sub Print()
        Dim dt As New DataTable
        Try

            If PrintRequiredValidator() = False Then
                Exit Sub
            End If
            clsDalContract.BeginProc()
            clsDalCity.BeginProc()
            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            'dtAssigningPos = clsDalContract.GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE(txtSerial_vc.Text.Trim, 1)
            dtAssigningPos = clsDalContract.GetByContractIDSerialContractingParty_Contract_Account_Store_Device_Pos_PURE(txtSerial_vc.Text.Trim, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtAssigningPos.Rows.Count > 0 Then
                clsDalContract.DOutlet_vc = dtAssigningPos.Rows(0).Item("DOutlet_vc")
                clsDalContract.DCode_vc = dtAssigningPos.Rows(0).Item("DCode_vc")
                clsDalContract.SName_nvc = dtAssigningPos.Rows(0).Item("SName_nvc")
                clsDalContract.FirstName_nvc = dtAssigningPos.Rows(0).Item("FirstName_nvc")
                clsDalContract.LastName_nvc = dtAssigningPos.Rows(0).Item("LastName_nvc")
                clsDalContract.SCityID = dtAssigningPos.Rows(0).Item("SCityID")
                clsDalCity.CityID = clsDalContract.SCityID
                dt = clsDalCity.GetByID()
                If dt.Rows.Count > 0 Then
                    clsDalContract.SCityname_nvc = dt.Rows(0).Item("Name_nvc")
                Else
                    clsDalContract.SCityname_nvc = ""
                End If

                Me.PrintLabel()
                Me.EmptyTextBoxes()
            Else
                ShowErrorMessage("اطلاعات وارد شده نامعتبر می باشد")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
            clsDalCity.EndProc()
        End Try

    End Sub
    Private Function PrintRequiredValidator()
        Dim res As Boolean = True
        If txtContractID.Text.Trim = "" Then
            ErrorProvider.SetError(txtContractID, "کد قرارداد را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtContractID, "")
        End If
        If txtSerial_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtSerial_vc, "")
        End If
        Return res
    End Function
    Private Sub EmptyTextBoxes()
        txtContractID.Text = ""
        txtSerial_vc.Text = ""
    End Sub
#Region "Print"
#End Region

    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)
    End Sub
    Private Sub frmDeviceAssigningReprint_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If

    End Sub
    Private Sub PrintLabel()
        'Try
        '    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_PoseCode_Outlet
        '    m_pd.Print()
        '    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
        '    m_pd.Print()
        'Catch ex As Exception
        '    Throw ex
        'End Try
        If txtContractID.Text.Trim <> "" Then
            Try
                Dim dt As New DataTable
                ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
                PrintDocument.Print()
            Catch ex As Exception
                Throw ex
            Finally
                Me.clsDalContract.EndProc()
            End Try
        Else
            Throw New KeyNotFoundException
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Print()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgPrintFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub txtSerial_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial_vc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Print()
            End If
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgPrintFailed)
            ClassError.LogError(ex)
        End Try

    End Sub
    '****************************************************************************************************
    '********************************************************************************************

    ' <remarks>
    '   Erweitert den Druckvorschau-Dialog
    '   um einige optische Effekte.
    ' </remarks>
    'Public Class ExtendedPrintPreviewDialog
    '    Inherits System.Windows.Forms.PrintPreviewDialog

    'End Class

    '-- Ende ExtendedPrintPreviewDialog.vb --
    '---------- Anfang MainForm.vb ----------

    ' <remarks>
    '   Hauptformular der Anwendung.
    ' </remarks>


    'Private m_pd As New Printing.PrintDocument()
    'Private m_intCurrentPage As Integer


    'Private Sub MainForm_Load( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs) _
    '        Handles MyBase.Load
    '    With cboPrinters
    '        Dim s As String
    '        For Each s In Printing.PrinterSettings.InstalledPrinters
    '            .Items.Add(s)
    '        Next s
    '        If .Items.Count > 0 Then
    '            .SelectedIndex = 0
    '        Else
    '            MessageBox.Show("No printers installed, quitting!", _
    '                Application.ProductName, _
    '                MessageBoxButtons.OK, _
    '                MessageBoxIcon.Exclamation)
    '            Me.Close()
    '        End If
    '    End With
    '    m_pd.DocumentName = "Unser erstes Dokument"
    '    AddHandler m_pd.PrintPage, AddressOf m_pd_PrintPage
    '    m_intCurrentPage = 0
    'End Sub

    'Private Sub cboPrinters_SelectedIndexChanged( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs)

    '    If cboPrinters.SelectedIndex <> -1 Then
    '        m_pd.PrinterSettings.PrinterName = cboPrinters.Text
    '    End If
    'End Sub

    'Private Sub m_pd_PrintPage( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    '    ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)
    '    'm_intCurrentPage += 1

    '    'Select Case m_intCurrentPage

    '    '    ' Drucken der ersten Seite.
    '    '    Case 1

    '    '        ' Zeichnen eines elliptischen Bereichs
    '    '        ' über die gesamte Seite (ohne Randabstände).
    '    '        e.Graphics.FillEllipse( _
    '    '            New Drawing2D.HatchBrush( _
    '    '            HatchStyle.Percent10, _
    '    '            Color.Red, _
    '    '            Color.White _
    '    '            ), _
    '    '            e.MarginBounds _
    '    '            )

    '    '        ' Text genau in der Mitte der Seite ausgeben.
    '    '        ' Je nach Randabständen muss das
    '    '        ' nicht unbedingt genau in der Mitte der Ellipse sein!
    '    '        Dim strText As String = "Das ist die Seite 1"
    '    '        Dim fntFont As New Font("Arial", 18)
    '    '        e.Graphics.DrawString( _
    '    '            strText, _
    '    '            fntFont, _
    '    '            New SolidBrush(Color.Blue), _
    '    '            CSng( _
    '    '            ( _
    '    '            e.PageBounds.Width - _
    '    '            e.Graphics.MeasureString(strText, fntFont).Width _
    '    '            ) * 0.5 _
    '    '            ), _
    '    '            CSng(200) _
    '    '            )

    '    '        ' Es folgen noch weitere Seiten.
    '    '        e.HasMorePages = True

    '    '        ' Drucken der zweiten Seite.
    '    '    Case 2

    '    '        ' Seitennummer im linken oberen Eck ausgeben.
    '    '        e.Graphics.DrawString( _
    '    '            "Seite 2", _
    '    '            New Font("Times New Roman", 12), _
    '    '            New SolidBrush(Color.Black), _
    '    '            e.MarginBounds.Left, _
    '    '            e.MarginBounds.Top _
    '    '            )

    '    '        ' Das war die letzte Seite.
    '    '        e.HasMorePages = False

    '    '        ' Seitenzähler wieder zurücksetzen.
    '    '        m_intCurrentPage = 0
    '    'End Select
    'End Sub

    'Private Sub btnPrint_Click( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs) _
    '        Handles btnPrint.Click
    '    Try
    '        If Me.PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            PrintLabel()
    '        End If
    '    Catch ex As KeyNotFoundException
    '        ShowErrorMessage(modApplicationMessage.msgPrintNotFound)
    '        ClassError.LogError(ex)
    '    Catch ex As Exception
    '        ShowErrorMessage(modApplicationMessage.msgPrintFailed)
    '        ClassError.LogError(ex)
    '    End Try


    'End Sub

    'Private Sub btnPreview_Click( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs)


    '    ' Seitenzähler initialisieren.
    '    m_intCurrentPage = 0

    '    ' Vorschaudialog erstellen und anzeigen.
    '    Dim ppdlg As ExtendedPrintPreviewDialog = _
    '        New ExtendedPrintPreviewDialog()
    '    With ppdlg

    '        ' Der Druckvorschau das Dokument zuweisen.
    '        .Document = m_pd

    '        ' Die Druckvorschau soll maximiert gezeigt werden.
    '        .WindowState = FormWindowState.Maximized

    '        ' Druckvorschau anzeigen.
    '        .ShowDialog(Me)
    '    End With
    'End Sub

    'Private Sub btnChoosePrinter_Click( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs)

    '    Dim pdlg As PrintDialog = New PrintDialog()
    '    With pdlg

    '        ' Dokument an Printerdialog weiterreichen.
    '        .Document = m_pd

    '        .PrinterSettings = m_pd.PrinterSettings
    '        .AllowPrintToFile = False
    '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            Print()
    '            'SelectPrinter(cboPrinters, .PrinterSettings.PrinterName)
    '        End If
    '    End With
    'End Sub

    'Private Sub btnPageSetup_Click( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs)

    '    Dim psdlg As PageSetupDialog = New PageSetupDialog()
    '    With psdlg
    '        .PrinterSettings = m_pd.PrinterSettings
    '        .PageSettings = m_pd.DefaultPageSettings
    '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

    '            ' Hier wird ein Fehler (?!) ausgebügelt: VB .NET
    '            ' konvertiert anscheinend alle Werte von Inch in
    '            ' Millimeter, da (vermutlich) im englischen Dialog
    '            ' die(Werte) in Inch eingegeben werden. Allerdings
    '            ' ist der Umrechnungsfaktor nicht genau Inch:Millimeter,
    '            ' sondern etwas mehr, sodass beim Wert 10 bei
    '            ' erneutem Aufruf 9.9 in der TextBox steht.
    '            .PageSettings.Margins = _
    '                Printing.PrinterUnitConvert.Convert( _
    '                .PageSettings.Margins, _
    '                Drawing.Printing.PrinterUnit.ThousandthsOfAnInch, _
    '                Drawing.Printing.PrinterUnit.HundredthsOfAMillimeter)

    '            ' Die Einstellungen in unserem Formular
    '            ' werden nun angepasst...
    '            SelectPrinter(cboPrinters, .PrinterSettings.PrinterName)
    '        End If
    '    End With
    'End Sub

    ' <summary>
    '   Wählt den in <paramref name="strPrinterName"/>
    '   angegebenen Drucker in den Einträgen
    '   der im Parameter <paramref name="cboComboBox"/> ComboBox aus.
    ' </summary>
    ' <param name="cboComboBox"></param>
    ' <param name="strPrinterName"></param>
    'Private Sub SelectPrinter( _
    '        ByVal cboComboBox As ToolStripComboBox, _
    '        ByVal strPrinterName As String)
    '    Dim i As Integer
    '    For i = 0 To cboComboBox.Items.Count - 1
    '        If Convert.ToString(cboComboBox.Items(i)) = strPrinterName Then
    '            cboComboBox.SelectedIndex = i
    '            Exit For
    '        End If
    '    Next i
    'End Sub
    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Try
    '        If Me.PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            Me.Print()
    '        End If
    '    Catch ex As Exception
    '        modPublicMethod.ShowErrorMessage(ex.Message)
    '        ClassError.LogError(ex)
    '    End Try
    'End Sub
    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Try
    '        If Me.PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            Me.Print()
    '        End If
    '    Catch ex As Exception
    '        modPublicMethod.ShowErrorMessage(ex.Message)
    '        ClassError.LogError(ex)
    '    End Try
    'End Sub

    Private Sub frmDeviceAssigningReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class