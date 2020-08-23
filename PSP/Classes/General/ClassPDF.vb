Public Class ClassPDF

    Public Sub CreatePDF(ByVal pdfpath As String, ByVal pdfname As String, ByVal CrReport As CrystalDecisions.CrystalReports.Engine.ReportClass)
        Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
        If IO.Directory.Exists(pdfpath) = False Then
            IO.Directory.CreateDirectory(pdfpath)
        End If
        CrDiskFileDestinationOptions.DiskFileName = pdfpath & "\" & pdfname & ".pdf" '"c:\mhd.pdf"
        CrFormatTypeOptions.UsePageRange = False
        CrExportOptions = CrReport.ExportOptions
        CrExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
        CrExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
        CrExportOptions.FormatOptions = CrFormatTypeOptions
        CrReport.Export()
    End Sub
    Public Sub CreatePDF(ByVal pdfpath As String, ByVal pdfname As String, ByVal CrReport As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
        If IO.Directory.Exists(pdfpath) = False Then
            IO.Directory.CreateDirectory(pdfpath)
        End If
        CrDiskFileDestinationOptions.DiskFileName = pdfpath & "\" & pdfname & ".pdf" '"c:\mhd.pdf"
        CrFormatTypeOptions.UsePageRange = False
        CrExportOptions = CrReport.ExportOptions
        CrExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
        CrExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
        CrExportOptions.FormatOptions = CrFormatTypeOptions
        CrReport.Export()
    End Sub
End Class
