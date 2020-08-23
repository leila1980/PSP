using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewModel.ViewModel.WebPos.PL_CSharp;
using System.Linq;

namespace PL_CSharp.Procedures
{
    public class frmSwitchSendTo
    {

        public List<WebPosDTO> GetSelectedRows(DataGridView dg)
        {
            // DataTable dataTable = (DataTable)dg.DataSource;
            //var rows = dg.Rows;
            //List<WebPosDTO> webPosDTOs = new List<WebPosDTO>();

            //for (int i = 0; i < dg.Rows.Count ; i++)
            //{
            //    if ( (bool) dg.Rows[i].Cells["PSerial_vc"].Value != true )
            //    {
            //        webPosDTOs.Add(new WebPosDTO() { serial = dg.Rows[i].Cells["PSerial_vc"].Value.ToString() , code = (long) dg.Rows[i].Cells["DOutlet_vc"].Value });
            //    }
            // }

           return null;
        }

        public void SelectAllRecords(DataGridView dataGridView)
        {
            dataGridView.EndEdit();
            
            for (int i = 0; i <= dataGridView.Rows.Count  -1 ; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = true;
            }

            dataGridView.EndEdit();
        }

        public void ClearAllRecords(DataGridView dataGridView)
        {
            dataGridView.EndEdit();

            for (int i = 0; i <= dataGridView.Rows.Count - 1; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = false;
            }
            
            dataGridView.EndEdit();
        }

        public DataGridView DesigneGridView(DataGridView dataGridView)
        {
            //  dataGridView.Columns.Count = 
            try
            {
                // dataGridView.Columns.Count = 34
                // datagridcolumn
                //  DataGridTextBox.
                //dataGridView.Columns.
            }
            catch (Exception exp)
            {

                throw exp;
            }
            //Try
            //dgv.Columns("AAccountNO_vc").HeaderText = "شماره حساب"
            //dgv.Columns("AAccountTypeID").Visible = False
            //dgv.Columns("ABranchID").HeaderText = "کد شعبه"
            //dgv.Columns("AAccountTypeName_vc").HeaderText = "نوع حساب"
            //dgv.Columns("CIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"
            //dgv.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            //dgv.Columns("SCityID").Visible = False
            //dgv.Columns("SStateID").Visible = False
            //dgv.Columns("SFax_vc").HeaderText = "فکس"
            //dgv.Columns("STel1_vc").HeaderText = "تلفن1"
            //dgv.Columns("STel2_vc").HeaderText = "تلفن2"
            //dgv.Columns("SAddress_nvc").HeaderText = "آدرس"
            //dgv.Columns("SPostCode_vc").HeaderText = "کد پستی"
            //dgv.Columns("SGroupID").Visible = False
            //dgv.Columns("SCityName_nvc").HeaderText = "شهر"
            //dgv.Columns("Email_nvc").HeaderText = "Email"
            //dgv.Columns("FirstName_nvc").HeaderText = "نام"
            //dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            //dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            //dgv.Columns("CityID").Visible = False
            //dgv.Columns("StateID").Visible = False
            //dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
            //dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
            //dgv.Columns("Mobile_vc").HeaderText = "موبایل"
            //dgv.Columns("DMerchant_vc").HeaderText = "Merchant"
            //dgv.Columns("DVat_vc").HeaderText = "Vat"
            //dgv.Columns("DOutlet_vc").HeaderText = "Outlet"
            //dgv.Columns("DCode_vc").HeaderText = "Code"
            //dgv.Columns("DSwitch_CardAcceptorID_vc").HeaderText = "Switch_CardAcceptorID"
            //dgv.Columns("DSwitch_TerminalID_vc").HeaderText = "Switch_TerminalID"
            //dgv.Columns("PSerial_vc").HeaderText = "سریال"
            //dgv.Columns("PPropertyNO_vc").HeaderText = "اموال"
            //dgv.Columns("ContractID").HeaderText = "کد قرارداد"
            //dgv.Columns("Switch_FeeID_int").HeaderText = "کارمزد"
            //''  dgv.Columns("cmsprojectid").Visible = False ' comment with leila maghsoodi
            //'' dgv.Columns("essws_nvc").Visible = False ' comment with leila maghsoodi
            //'' dgv.Columns("issent2switch").Visible = False ' comment with leila maghsoodi
            //Catch ex As Exception
            //    Throw ex
            //End Try
            return dataGridView;
        }

        //    public  Sub Visible_Unvisible_Buttons(tabPage As String)
        //    Select Case tabPage
        //        Case Common.HardCodes.TejaratTabPage
        //            Me.btnSend.Visible = True
        //            Me.btnSendToWebPos.Visible = False
        //            Me.btnSendToNetsis.Visible = False
        //            Me.btnView.Visible = True
        //            Me.TejaratToolStripSeparator.Visible = True
        //            Me.WebPosToolStripSeparator.Visible = False
        //            Me.NetsisToolStrip.Visible = False
        //            Me.NetsisTabPage.Visible = False
        //        Case Common.HardCodes.WebPosTabPage
        //            Me.btnSend.Visible = False
        //            Me.btnSendToWebPos.Visible = True
        //            Me.btnSendToNetsis.Visible = False
        //            Me.btnView.Visible = False
        //            Me.TejaratToolStripSeparator.Visible = True
        //            Me.WebPosToolStripSeparator.Visible = True
        //            Me.NetsisToolStrip.Visible = False
        //        Case Common.HardCodes.NetsisTabPage
        //            Me.btnSend.Visible = False
        //            Me.btnSendToWebPos.Visible = False
        //            Me.btnSendToNetsis.Visible = True
        //            Me.btnView.Visible = False
        //            Me.TejaratToolStripSeparator.Visible = True
        //            Me.WebPosToolStripSeparator.Visible = False
        //            Me.NetsisToolStrip.Visible = True
        //    End Select

        //End Sub
    }
}
