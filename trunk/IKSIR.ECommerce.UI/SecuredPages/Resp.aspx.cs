using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _PosnetDotNetTDSOOSModule;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class Resp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //      Table1.Rows.Item(3).Visible = false;
            //Table1.Rows.Item(4).Visible = false;

            _PosnetDotNetTDSOOSModule.C_PosnetOOSTDS posnetOOSTDSObj = new C_PosnetOOSTDS();

            string merchantPacket, bankPacket, sign, tranType;

            merchantPacket = Request.Form.Get("MerchantPacket");
            bankPacket = Request.Form.Get("BankPacket");
            sign = Request.Form.Get("Sign");
            tranType = Request.Form.Get("TranType");

            merchantPackets.Value = merchantPacket;
            bankPackets.Value = bankPacket;
            signs.Value = sign;
            tempTranTypes.Value = tranType;

            posnetOOSTDSObj.SetMid("6734273367");
            posnetOOSTDSObj.SetTid("67932822");
            posnetOOSTDSObj.SetKey("10,10,10,10,10,10,10,10");
            posnetOOSTDSObj.SetPosnetID("3261");
            posnetOOSTDSObj.SetURL("http://setmpos.ykb.com/PosnetWebService/XML");
            

            if (cctrans.Value != "")
            {

                string WPAmount = Request.Form.Get("WPAmount");
                if (WPAmount != "")
                {
                    posnetOOSTDSObj.SetPointAmount(WPAmount);
                }

                Response.Write("<html>");
                Response.Write("<head>");
                Response.Write("<META HTTP-EQUIV='Content-Type' content='text/html; charset=Windows-1254'>");

                Response.Write("<script language='JavaScript'>");

                Response.Write("function submitForm(form) {");
                Response.Write("	 form.submit();");
                Response.Write("}");

                Response.Write("</script>");

                Response.Write("<title>YKB - POSNET Redirector</title></head>");
                Response.Write("<body bgcolor='#02014E' OnLoad='submitForm(document.form2);' >");


                posnetOOSTDSObj.ConnectAndDoTDSTransaction(merchantPacket, bankPacket, sign);

                Response.Write(" <form name='form2' method='post' action='OrderPayment.aspx' >");
                Response.Write("   <input type='hidden' name='XID' value='" + posnetOOSTDSObj.GetXID() + "'>");
                Response.Write("   <input type='hidden' name='Amount' value='" + posnetOOSTDSObj.GetAmount() + "'>");
                Response.Write("   <input type='hidden' name='WPAmount' value='" + WPAmount + "'>");
                Response.Write("   <input type='hidden' name='Currency' value='" + posnetOOSTDSObj.GetCurrencyCode() + "'>");

                Response.Write("   <input type='hidden' name='ApprovedCode' value='" + posnetOOSTDSObj.GetApprovedCode() + "'>");
                Response.Write("   <input type='hidden' name='AuthCode' value='" + posnetOOSTDSObj.GetAuthcode() + "'>");
                Response.Write("   <input type='hidden' name='HostLogKey' value='" + posnetOOSTDSObj.GetHostlogkey() + "'>");
                Response.Write("   <input type='hidden' name='RespCode' value='" + posnetOOSTDSObj.GetResponseCode() + "'>");
                Response.Write("   <input type='hidden' name='RespText' value='" + posnetOOSTDSObj.GetResponseText() + "'>");

                Response.Write("   <input type='hidden' name='Point' value='" + posnetOOSTDSObj.GetPoint() + "'>");
                Response.Write("   <input type='hidden' name='PointAmount' value='" + posnetOOSTDSObj.GetPointAmount() + "'>");
                Response.Write("   <input type='hidden' name='TotalPoint' value='" + posnetOOSTDSObj.GetTotalPoint() + "'>");
                Response.Write("   <input type='hidden' name='TotalPointAmount' value='" + posnetOOSTDSObj.GetTotalPointAmount() + "'>");

                Response.Write("   <input type='hidden' name='InstalmentNumber' value='" + posnetOOSTDSObj.GetInstalmentNumber() + "'>");
                Response.Write("   <input type='hidden' name='InstalmentAmount' value='" + posnetOOSTDSObj.GetInstalmentAmount() + "'>");

                Response.Write("   <input type='hidden' name='VftAmount' value='" + posnetOOSTDSObj.GetVFTAmount() + "'>");
                Response.Write("   <input type='hidden' name='VftDayCount' value='" + posnetOOSTDSObj.GetVFTDayCount() + "'>");
                Response.Write(" </form>");
                Response.Write(" </body>");
                Response.Write(" </html>");
                Response.End();
            }
            else
            {
                posnetOOSTDSObj.CheckAndResolveMerchantData(merchantPacket, bankPacket, sign);


                tempTotalPointAmounts.Value = posnetOOSTDSObj.GetTotalPointAmount();
                tempAmounts.Value = posnetOOSTDSObj.GetAmount();
                cctrans.Value = "1";
                orderID.Text = posnetOOSTDSObj.GetXID();
                amount.Text = posnetOOSTDSObj.GetAmount();
                errorMessage.Text = posnetOOSTDSObj.GetResponseText();

                if (posnetOOSTDSObj.GetTotalPoint() == "-1")
                {
                    totalPoint.Text = "";
                    totalPointAmount.Text = "";
                }
                else
                {
                    totalPoint.Text = posnetOOSTDSObj.GetTotalPoint();
                    if (totalPoint.Text.Length > 0)
                    {
                    }
                    totalPointAmount.Text = posnetOOSTDSObj.GetTotalPointAmount();
                }

                currencyCode.Text = posnetOOSTDSObj.GetCurrencyCode();

                try
                {
                    if (Convert.ToInt32(posnetOOSTDSObj.GetTotalPointAmount()) == 0)
                    {
                        WPAmount.Enabled = false;
                    }
                }
                catch
                {
                    WPAmount.Enabled = false;
                }


                tdsErrorCode.Text = posnetOOSTDSObj.GetTDSTXStatus();
                tdsStatus.Text = posnetOOSTDSObj.GetTDSMDStatus();
                tdsErrorMessage.Text = posnetOOSTDSObj.GetTDSMDErrorMessage();


                imageField.OnClientClick = "if(formKontrol()) { document.formResp.submit();this.disabled=true;} else {return false;}";

            }
        }
    }
}