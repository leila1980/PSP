Imports System.Data

Public Enum WarehouseStatementType
    Transfer = 1
    Receipt = 2
End Enum

Public Class ClassDALWarehouseStatement
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub

#Region "Public property"

    Public Property StatementType As WarehouseStatementType
    Public Property ProjectID As Integer
    Public Property DeliveryID As Integer
    Public Property AccountID As Integer
    Public Property StatementNo As Integer
    Public Property ReasonID As Integer
    Public Property Date_vc As String
    Public Property Comment As String
    Public Property CreatedDate As DateTime
    Public Property UserID As Integer
    Public Property Details As List(Of ClassBLLWarehouseStatementGoodDetail)

#End Region

#Region "private method"
    Private Function getMaxID(ByVal columnName As String, ByVal tableName As String) As Integer
        Dim id As Integer = 1
        Dim dt As New DataTable
        Dim strSQL As String = String.Format("select max({0}) from {1}", columnName, tableName)
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dt)
        If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)(0)) Then
            id = Int32.Parse(dt.Rows(0)(0) + 1)
        End If
        Return id
    End Function
#End Region

#Region "Insert method"

    Public Sub register()
        Try
            'register warehousestatement
            Dim wsid As Integer = getMaxID("warehousestatement_ID", "warehousestatement_t")
            Dim dateStr As String = CreatedDate.Month.ToString() + "/" + CreatedDate.Day.ToString() + "/" + CreatedDate.Year.ToString()
            Dim strSQL As String = String.Format("insert into warehousestatement_t values({0},{1},{2},{3},{4},{5},{6},'{7}','{8}',To_Date('{9}' , 'mm/dd/YYYY'),{10})", wsid, Convert.ToInt32(StatementType), ProjectID, DeliveryID, AccountID, StatementNo, ReasonID, Date_vc, Comment, dateStr, UserID.ToString())
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL)


            'register warehousestatement detail
            Dim countType As Integer = 1
            If Me.StatementType = WarehouseStatementType.Transfer Then
                countType = -1
            End If

            For Each detail As ClassBLLWarehouseStatementGoodDetail In Me.Details
                Dim wsdid As Integer = getMaxID("warehousestatementdetail_ID", "warehousestatementdetail_t")
                strSQL = String.Format("insert into warehousestatementdetail_t values({0},{1},{2},{3})", wsdid, wsid, countType * detail.Count, detail.GoodID)
                Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL)

                'register  pos serials
                For Each serial As String In detail.serials
                    Dim pos As ClassDALPos = New ClassDALPos(modPublicMethod.ConnectionString)
                    pos.Serial_vc = serial
                    Dim dt As DataTable = pos.GetBySerialPos()
                    If Not IsDBNull(dt.Rows(0)("PosID")) Then
                        Dim posID As Int64 = Int64.Parse(dt.Rows(0)("PosID").ToString())
                        strSQL = String.Format("insert into warehousestatementserials_t values({0},{1},{2})", wsid, wsdid, posID)
                        Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL)
                    End If
                Next
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Select method"

    Public Function GetNextStatementNo() As Integer
      
        Dim id As Integer = 0
        Dim dt As New DataTable
        Dim strSQL As String = "select warehousestatementno.nextval from dual"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dt)
        If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)(0)) Then
            id = Int32.Parse(dt.Rows(0)(0))
        End If
        Return id

    End Function

    Public Function WarehouseState(ByVal goodID As String, ByVal userID As String) As Integer
        Dim dt As New DataTable
        Dim strSql As String = " select sum(count) from warehousestatementdetail_t "
        strSql += "join warehousestatement_t on warehousestatement_t.warehousestatement_id = warehousestatementdetail_t.warehousestatementid "
        strSql += "join warehouse_t on warehouse_t.visitor_id = warehousestatement_t.delivery_id "
        strSql += String.Format("where warehouse_t.User_ID = {0} ", userID)
        strSql += "group by (delivery_id, good_id) "
        strSql += String.Format("having  good_id = {0}", goodID)
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)

        If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)(0)) Then
            Return Integer.Parse(dt.Rows(0)(0))
        End If
        Return 0
    End Function

    Public Function GetAll(ByVal visitorID As Integer) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select ws.*,wst.name_nvc statementtype , p.name_nvc projecttitle, NVL(d.FirstName_nvc, '') || ' ' || NVL(d.LastName_nvc, '') delivery, "
        strSql += " NVL(a.FirstName_nvc, '') || ' ' || NVL(a.LastName_nvc, '') account, r.name_nvc reason, u.fullname_vc createdby from warehousestatement_t ws "
        strSql += "join warehousestatementtype_t wst on wst.statement_type_id = ws.warehousestatementtype_id "
        strSql += "join cmsproject_t p on p.cmsprojectid_int = ws.project_id "
        strSql += "join visitor_t d on d.visitorid = ws.delivery_id "
        strSql += "join visitor_t a on a.visitorid = ws.account_id "
        strSql += "join warehousereason_t r on r.reason_id = ws.reason_id "
        strSql += "join user_t u on u.userid = ws.userid "
        strSql += String.Format("where (d.visitorid = {0}) or (a.visitorid = {0} and ws.warehousestatementtype_id = 1) ", visitorID.ToString())
        strSql += "order by ws.warehousestatement_id desc"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

    Public Function GetStatement(ByVal statementID As Integer) As DataTable
        Dim dt As New DataTable
        Dim strSql As String = "select ws.*,wst.name_nvc statementtype , p.name_nvc projecttitle, NVL(d.FirstName_nvc, '') || ' ' || NVL(d.LastName_nvc, '') delivery, "
        strSql += " NVL(a.FirstName_nvc, '') || ' ' || NVL(a.LastName_nvc, '') account, r.name_nvc reason, u.fullname_vc createdby from warehousestatement_t ws "
        strSql += "join warehousestatementtype_t wst on wst.statement_type_id = ws.warehousestatementtype_id "
        strSql += "join cmsproject_t p on p.cmsprojectid_int = ws.project_id "
        strSql += "join visitor_t d on d.visitorid = ws.delivery_id "
        strSql += "join visitor_t a on a.visitorid = ws.account_id "
        strSql += "join warehousereason_t r on r.reason_id = ws.reason_id "
        strSql += "join user_t u on u.userid = ws.userid "
        strSql += String.Format("where ws.warehousestatement_id = {0}", statementID.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt
    End Function

    Public Function GetStatementDetail(ByVal statementID As Integer) As DataTable
        Dim dt As New DataTable
        Dim strsql As String = "select wsd.*,g.name_nvc,g.posmodel_id from warehousestatementdetail_t  wsd join good_t g on g.good_id = wsd.good_id "
        strsql += "where warehousestatementid = " + statementID.ToString()
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strsql, dt)
        Return dt
    End Function

    Public Function GetStatementSerials(ByVal statementID As Integer, ByVal detailID As Integer) As DataTable
        Dim dt As New DataTable
        Dim strSql As String = "select wss.* ,p.serial_vc from warehousestatementserials_t  wss join pos_t  p on wss.pos_id = p.posid "
        strSql += String.Format("where warehousestatement_id = {0} and warehousestatementdetail_id = {1}", statementID.ToString(), detailID.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt
    End Function

    Public Function GetStatementSerials(ByVal statementID As Integer) As DataTable
        Dim dt As New DataTable
        Dim strSql As String = "select wss.* ,p.serial_vc from warehousestatementserials_t  wss join pos_t  p on wss.pos_id = p.posid "
        strSql += String.Format("where warehousestatement_id = {0}", statementID.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt
    End Function

    Public Function GetStatementDetailSerials(ByVal statementID As Integer) As DataTable
        Dim dt As New DataTable
        Dim strSql As String = "select wsd.*, g.name_nvc,g.posmodel_id,p.serial_vc from warehousestatementdetail_t wsd "
        strSql += "left join warehousestatementserials_t wss on wss.warehousestatement_id = wsd.warehousestatementid and wss.warehousestatementdetail_id = wsd.warehousestatementdetail_id "
        strSql += "join good_t g on g.good_id = wsd.good_id "
        strSql += "left join pos_t  p on wss.pos_id = p.posid "
        strSql += String.Format("where warehousestatementid = {0}", statementID.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt
    End Function

    Public Function GetStatementByStatementNO(ByVal statementNO As Integer) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select * from warehousestatement_t ws "
        strSql += String.Format("where ws.statementno = {0}", statementNO.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

    Public Function GetWareHouseState(ByVal visitorID As Integer) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select g.good_id,g.name_nvc, sum(wsd.count) as totalcount from warehousestatementdetail_t wsd "
        strSql += "join warehousestatement_t ws on wsd.warehousestatementid = ws.warehousestatement_id "
        strSql += " join visitor_t d on d.visitorid = ws.delivery_id "
        strSql += "right join good_t g on g.good_id = wsd.good_id  "
        strSql += String.Format("where(d.visitorid = {0} Or d.visitorid Is null) ", visitorID.ToString())
        strSql += "group by g.good_id,g.name_nvc "
        strSql += " order by g.good_id"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

    Public Function GetWarehouseSerialsState(ByVal goodID As Integer, ByVal visitorID As Integer) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select p.serial_vc from warehousestatementserials_t wss "
        strSql += "join warehousestatementdetail_t wsd on wsd.warehousestatementid = wss.warehousestatement_id and wsd.warehousestatementdetail_id = wss.warehousestatementdetail_id "
        strSql += "join warehousestatement_t ws on ws.warehousestatement_id = wsd.warehousestatementid "
        strSql += "join pos_t p on p.posid = wss.pos_id  "
        strSql += String.Format("where wsd.good_id = {0} and ws.delivery_id = {1} and ws.warehousestatementtype_id = 2 and ws.warehousestatement_id in ", goodID.ToString(), visitorID.ToString())
        strSql += "(select max(wss.warehousestatement_id) from warehousestatementserials_t wss "
        strSql += "group by wss.pos_id)"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

    Public Function GetSerialLastState(ByVal serial As String) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select * from warehousestatement_t ws where ws.warehousestatement_id =  "
        strSql += "(select max(wss.warehousestatement_id) from warehousestatementserials_t wss "
        strSql += "join pos_t p on p.posid = wss.pos_id "
        strSql += "group by p.serial_vc "
        strSql += String.Format("having p.serial_vc = '{0}')", serial)
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

    Public Function GetSerialHistory(ByVal serial As String) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "  select ws.*,wst.name_nvc statementtype , p.name_nvc projecttitle, NVL(d.FirstName_nvc, '') || ' ' || NVL(d.LastName_nvc, '') delivery,  "
        strSql += "NVL(a.FirstName_nvc, '') || ' ' || NVL(a.LastName_nvc, '') account, r.name_nvc reason, u.fullname_vc createdby from warehousestatementserials_t wss  "
        strSql += "join warehousestatement_t ws on ws.warehousestatement_id = wss.warehousestatement_id "
        strSql += "join warehousestatementtype_t wst on wst.statement_type_id = ws.warehousestatementtype_id "
        strSql += "join cmsproject_t p on p.cmsprojectid_int = ws.project_id "
        strSql += "join visitor_t d on d.visitorid = ws.delivery_id "
        strSql += "join visitor_t a on a.visitorid = ws.account_id "
        strSql += "join warehousereason_t r on r.reason_id = ws.reason_id "
        strSql += "join user_t u on u.userid = ws.userid "
        strSql += "join pos_t p on p.posid = wss.pos_id "
        strSql += String.Format("where p.serial_vc = '{0}' ", serial)
        strSql += "order by ws.warehousestatement_id desc"
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        Return dt

    End Function

#End Region

End Class

