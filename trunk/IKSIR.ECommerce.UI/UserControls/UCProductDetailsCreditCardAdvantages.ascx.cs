using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsCreditCardAdvantages : UCProductDetailsMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && productId != 0)
            {
                GetProductCreditCartAdvantages(productId);
            }
        }

        private void GetProductCreditCartAdvantages(int productId)
        {
            try
            {
                rptCreditCards.DataSource = CreditCardData.GetAktiveCreditCardList();
                rptCreditCards.DataBind();

                dlCreditCards.DataSource = CreditCardData.GetAktiveCreditCardList();
                dlCreditCards.DataBind();
            }
            catch (Exception exception)
            {
            }
        }

        protected void rptCreditCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnCardId = e.Item.FindControl("hdnCardId") as HiddenField;

                Repeater rptCreditCardAdvantages = e.Item.FindControl("rptCreditCardAdvantages") as Repeater;
                int cardId;

                if (rptCreditCardAdvantages != null && hdnCardId.Value != "" && int.TryParse(hdnCardId.Value, out cardId))
                {
                    rptCreditCardAdvantages.DataSource = PaymetTermRateData.GetAktivePaymetTermRateList(cardId);
                    rptCreditCardAdvantages.DataBind();
                }
            }
        }

        protected void dlCreditCards_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnCardId = e.Item.FindControl("hdnCardId") as HiddenField;
                Repeater rptCreditCardAdvantages = e.Item.FindControl("rptCreditCardAdvantages") as Repeater;
                int cardId;

                if (rptCreditCardAdvantages != null && hdnCardId.Value != "" && int.TryParse(hdnCardId.Value, out cardId))
                {
                    rptCreditCardAdvantages.DataSource = PaymetTermRateData.GetAktivePaymetTermRateList(cardId);
                    rptCreditCardAdvantages.DataBind();
                }
            }
        }
    }
}