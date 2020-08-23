Public Class frmRptViewDetail
    Private dt As New DataTable
    Private dv As DataView
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Public Enum ReportTypeEnum As Short
        AccountDetail = 1
        ContractDetail = 2
        TakhsisDetail = 3
        ConfigedDetail = 4
        InstalledDetail = 5
        InstalledAndConfirmedInstallDetail = 6
        CanceledDetail = 7
        CanceledAndInstalledDetail = 8
        NoThakhsisDetail = 9
        NoConfigedDetail = 10
        NoInstalledDetail = 11
        NoConfirmedInstallDetail = 12
    End Enum
    Public Enum DateConditionEnum As Short
        Until = 1
        Between = 2
    End Enum
    Public ReportType As ReportTypeEnum
    Public DateCondition As DateConditionEnum
    Public DateFrom As String
    Public DateTo As String
    Public VisitorID As Int32
    Public VisitorFullName As String
    Public ProjectID As Int32

    Private Sub frmRptViewDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dt.Clear()
            Select Case ReportType
                Case ReportTypeEnum.ContractDetail
                    dt = clsDALReport.GetContractDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.ReportType, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.AccountDetail
                    dt = clsDALReport.GetContractDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.ReportType, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.TakhsisDetail
                    dt = clsDALReport.GetTakhsisDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.ConfigedDetail
                    dt = clsDALReport.GetConfigedDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.InstalledDetail
                    dt = clsDALReport.GetInstalledDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.InstalledAndConfirmedInstallDetail
                    dt = clsDALReport.GetInstalledAndConfirmedInstallDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.CanceledDetail
                    dt = clsDALReport.GetCanceledDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.DateCondition, Me.ProjectID)
                Case ReportTypeEnum.CanceledAndInstalledDetail
                    dt = clsDALReport.GetCanceledAndInstalledDetailByVisitorIDAndDate(DateFrom, DateTo, VisitorID, Me.ProjectID)

                Case ReportTypeEnum.NoThakhsisDetail
                    dt = clsDALReport.GetNoTakhsisDetailByVisitorIDAndDate(DateTo, VisitorID, Me.ProjectID)
                Case ReportTypeEnum.NoConfigedDetail
                    dt = clsDALReport.GetNoConfigedDetailByVisitorIDAndDate(DateTo, VisitorID, Me.ProjectID)
                Case ReportTypeEnum.NoInstalledDetail
                    dt = clsDALReport.GetNoInstalledDetailByVisitorIDAndDate(DateTo, VisitorID, Me.ProjectID)

                Case ReportTypeEnum.NoConfirmedInstallDetail
                    dt = clsDALReport.GetNoConfirmedInstallDetailByVisitorIDAndDate(DateTo, VisitorID, Me.ProjectID)


            End Select
            dv = dt.DefaultView
            dgv.DataSource = dv
            InitGrid()
            ReportSearchToolStrip1.Init(dgv, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            Select Case ReportType
                Case ReportTypeEnum.ContractDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                Case ReportTypeEnum.AccountDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                Case ReportTypeEnum.TakhsisDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                Case ReportTypeEnum.ConfigedDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                    dgv.Columns("ConfigDate").HeaderText = "تاریخ پیکربندی"

                Case ReportTypeEnum.InstalledDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                    dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
                    dgv.Columns("TheLastSuccessfulTranDateUtilDateTo").HeaderText = "تاریخ آخرین تراکنش تا انتهای بازه"
                    dgv.Columns("TheLastSuccessfulTranDate").HeaderText = "تاریخ آخرین تراکنش"
                Case ReportTypeEnum.InstalledAndConfirmedInstallDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                    dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
                    dgv.Columns("TheLastSuccessfulTranDateUtilDateTo").HeaderText = "تاریخ آخرین تراکنش تا انتهای بازه"
                    dgv.Columns("TheLastSuccessfulTranDate").HeaderText = "تاریخ آخرین تراکنش"
                    dgv.Columns("ConfirmedInstallDate").HeaderText = "تاریخ تایید نصب"
                Case ReportTypeEnum.CanceledDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                    dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
                    dgv.Columns("TheLastSuccessfulTranDateUtilDateTo").HeaderText = "تاریخ آخرین تراکنش تا انتهای بازه"
                    dgv.Columns("TheLastSuccessfulTranDate").HeaderText = "تاریخ آخرین تراکنش"
                    dgv.Columns("CancelDate").HeaderText = "تاریخ فسخ"

                Case ReportTypeEnum.CanceledAndInstalledDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"
                    dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
                    dgv.Columns("TheLastSuccessfulTranDateUtilDateTo").HeaderText = "تاریخ آخرین تراکنش تا انتهای بازه"
                    dgv.Columns("TheLastSuccessfulTranDate").HeaderText = "تاریخ آخرین تراکنش"
                    dgv.Columns("CancelDate").HeaderText = "تاریخ فسخ"
                Case ReportTypeEnum.NoThakhsisDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("NoThakhsisCount").HeaderText = "تعداد دستگاه تخصیص نیافته"

                Case ReportTypeEnum.NoConfigedDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"

                Case ReportTypeEnum.NoInstalledDetail

                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("TakhsisDate").HeaderText = "تاریخ تخصیص"

                Case ReportTypeEnum.NoConfirmedInstallDetail
                    dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                    dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                    dgv.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت"
                    dgv.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
                    dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                    dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
                    dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
                    dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
                    dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
                    dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
                    dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
                    dgv.Columns("Mobile_vc").HeaderText = "موبایل"
                    dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
                    dgv.Columns("CardNo_vc").HeaderText = "شماره کارت"
                    dgv.Columns("BranchName_nvc").HeaderText = "شعبه"
                    dgv.Columns("AccountTypeName_nvc").HeaderText = "نوع حساب"
                    dgv.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
                    dgv.Columns("StateName_nvc").HeaderText = "استان"
                    dgv.Columns("CityName_nvc").HeaderText = "شهر"
                    dgv.Columns("GroupName_nvc").HeaderText = "صنف"
                    dgv.Columns("Address_nvc").HeaderText = "آدرس"
                    dgv.Columns("Tel1_vc").HeaderText = "تلفن"
                    dgv.Columns("PostCode_vc").HeaderText = "کدپستی"
                    dgv.Columns("Payaneh").HeaderText = "پایانه"
                    dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                    dgv.Columns("Serial_vc").HeaderText = "سریال"
                    dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
                    dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
                    dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount

    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount

    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            Dim _frm As New frmContractingparty_Contract_Account_Store_Device
            _frm.SearchingContractID = dgv.Rows(e.RowIndex).Cells("ContractID").Value
            _frm.ShowDialog()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class