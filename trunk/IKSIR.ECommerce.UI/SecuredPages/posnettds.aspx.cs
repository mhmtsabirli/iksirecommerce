using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _PosnetDotNetTDSOOSModule;
using IKSIR.ECommerce.Model.Bank;
namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class posnettds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            C_PosnetOOSTDS posnetOOSTDSObj = new C_PosnetOOSTDS();
            PaymetInfo paymentInfo = new PaymetInfo();
            if (Session["PaymentInfo"] != null)
            {
                paymentInfo = (IKSIR.ECommerce.Model.Bank.PaymetInfo)Session["PaymentInfo"];
            }
            string custName = paymentInfo.Name;
            string xid = Session["porderid"].ToString();
            string Month = "";
            if (paymentInfo.Month.ToString().Length == 1)
                Month = "0" + paymentInfo.Month.ToString();
            else
                Month = paymentInfo.Month.ToString();

            string ccno = paymentInfo.CreditCardNumber;
            string expdate = paymentInfo.Year.ToString().Replace("20", "") + Month;
            string cvv = paymentInfo.Cvc;
             
            string amount = Session["pamount"].ToString();
            string currencyCode = "YT";
            string instalment = Session["ptaknum"].ToString();
            string tranType = "Sale";
            string vftCode = "K001";

            imageField.OnClientClick = "submitFormEx(formName, " + posnettds_config.OPEN_NEW_WINDOW + ", 'YKBWindow');";

            posnetOOSTDSObj.SetMid(posnettds_config.MERCHANT_ID);
            posnetOOSTDSObj.SetTid(posnettds_config.TERMINAL_ID);
            posnetOOSTDSObj.SetPosnetID(posnettds_config.POSNET_ID);
            posnetOOSTDSObj.SetKey(posnettds_config.ENCKEY);



            lblamount.Text = amount.Substring(0,amount.Length-2)+","+amount.Substring(amount.Length - 2, 2);
            instNumber.Text = instalment;
            XID.Text = xid;

            if (!posnetOOSTDSObj.CreateTranRequestDatas(custName, amount, currencyCode, instalment, xid, tranType,
                                                   ccno, expdate, cvv))
            {
                Response.Write("Posnet Data 'ları olusturulamadi (" + posnetOOSTDSObj.GetResponseText() + ")<br>");
                Response.Write("Error Code : " + posnetOOSTDSObj.GetResponseCode());
                Response.End();
            }
            //'Hidden fields
            mid.Value = posnettds_config.MERCHANT_ID;
            posnetID.Value = posnettds_config.POSNET_ID;
            posnetData.Value = posnetOOSTDSObj.GetPosnetData();
            posnetData2.Value = posnetOOSTDSObj.GetPosnetData2();
            digest.Value = posnetOOSTDSObj.GetSign();
            lblvftCode.Value = vftCode;
            merchantReturnURL.Value = posnettds_util.GetReturnURL(Request);
            openANewWindow.Value = posnettds_config.OPEN_NEW_WINDOW;
        }
    }
}