using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _PosnetDotNetTDSOOSModule;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class posnettds_resp : System.Web.UI.Page
    {
        private string message = "YKB Posnet <font color='#FF0000'>3D-Secure</font>  sisteminde, Kredi Kartı 'nızın doğrulaması yapılmıştır. İşlemi onlayıp, Kredi Kartı çekiminin yapılması için lütfen aşağıdaki linke tıklayınız. <BR>";
        private string message2 = "<font color='#FF0000'>3D-Secure</font> doğrulaması yapılamadığı için işleminize devam edilememektedir. Lütfen Kredi Kartı bilgilerinizi kontrol ediniz. <BR>";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Table1.Rows[3].Visible = false;
            this.Table1.Rows[4].Visible = false;

            C_PosnetOOSTDS posnetOOSTDSObj = new C_PosnetOOSTDS();

            string merchantPacket = null;
            string bankPacket = null;
            string sign = null;
            string tranType = null;

            merchantPacket = Request.Form.Get("MerchantPacket");
            bankPacket = Request.Form.Get("BankPacket");
            sign = Request.Form.Get("Sign");
            tranType = Request.Form.Get("TranType");

            this.merchantPacket.Value = merchantPacket;
            this.bankPacket.Value = bankPacket;
            this.sign.Value = sign;
            this.tempTranType.Value = tranType;

            posnetOOSTDSObj.SetMid(posnettds_config.MERCHANT_ID);
            posnetOOSTDSObj.SetTid(posnettds_config.TERMINAL_ID);
            posnetOOSTDSObj.SetPosnetID(posnettds_config.POSNET_ID);
            posnetOOSTDSObj.SetKey(posnettds_config.ENCKEY);
            posnetOOSTDSObj.SetURL(posnettds_config.XML_SERVICE_URL);
            //İşlem bilgilerinin çözümlenmesi

            if (this.cctran.Value!="")
            {
                string WPAmount = Request.Form["WPAmount"];
                if ((!string.IsNullOrEmpty(WPAmount)))
                {
                    posnetOOSTDSObj.SetPointAmount(WPAmount);
                }

                Response.Write("<html>");
                Response.Write("<head>");
                Response.Write("<META HTTP-EQUIV='Content-Type' content='text/html; charset=Windows-1254'>");

                Response.Write("<script language='JavaScript'>");

                Response.Write("function submitForm(form) {");
                Response.Write("\t form.submit();");
                Response.Write("}");

                Response.Write("</script>");

                Response.Write("<title>YKB - POSNET Redirector</title></head>");
                Response.Write("<body bgcolor='#02014E' OnLoad='submitForm(document.form2);' >");

                //3DS Kredi kartı onay İşlemini başlat
                posnetOOSTDSObj.ConnectAndDoTDSTransaction(merchantPacket, bankPacket, sign);

                Response.Write(" <form name='form2' method='post' action='Order.aspx' >");
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
                //İşlemin kredi kartı finansallanın başlatılması
                posnetOOSTDSObj.CheckAndResolveMerchantData(merchantPacket, bankPacket, sign);

                if ((tranType == "SaleWP"))
                {
                    this.Table1.Rows[3].Visible = true;
                }

                if ((posnetOOSTDSObj.GetTDSMDStatus() != "9"))
                {
                    this.Table1.Rows[4].Visible = true;
                }

                this.tempTotalPointAmount.Value = posnetOOSTDSObj.GetTotalPointAmount();
                this.tempAmount.Value = posnetOOSTDSObj.GetAmount();
                this.cctran.Value = "1";
                this.orderID.Text = posnetOOSTDSObj.GetXID();
                this.amount.Text = posnetOOSTDSObj.GetAmount();
                this.errorMessage.Text = posnetOOSTDSObj.GetResponseText();

                if ((posnetOOSTDSObj.GetTotalPoint() == "-1"))
                {
                    this.totalPoint.Text = "";
                    this.totalPointAmount.Text = "";
                }
                else
                {
                    this.totalPoint.Text = posnetOOSTDSObj.GetTotalPoint();
                    if ((totalPoint.Text.Length > 0))
                    {
                        this.totalPoint.Text = Convert.ToInt32(totalPoint.Text).ToString();
                    }
                    this.totalPointAmount.Text = posnetOOSTDSObj.GetTotalPointAmount();
                }

                this.currencyCode.Text = posnetOOSTDSObj.GetCurrencyCode();

                try
                {
                    if ((Convert.ToInt32(posnetOOSTDSObj.GetTotalPointAmount()) == 0))
                    {
                        this.WPAmount.Enabled = false;
                    }
                }
                catch (InvalidCastException ex)
                {
                    this.WPAmount.Enabled = false;
                }

                this.tdsErrorCode.Text = posnetOOSTDSObj.GetTDSTXStatus();
                this.tdsStatus.Text = posnetOOSTDSObj.GetTDSMDStatus();
                this.tdsErrorMessage.Text = posnetOOSTDSObj.GetTDSMDErrorMessage();

                this.imageField.OnClientClick = "if(formKontrol()) { document.formResp.submit();this.disabled=true;} else {return false;}";

            }
        }
    }
}