using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class CreditCardRates : ModelBase
    {

        public string CreditCardName { get; set; }
        public string BankName { get; set; }
        public string CreditCardImage { get; set; }
        public List<Rates> Rates { get; set; }


        public CreditCardRates(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            string creditCardName,string bankName, string creditCardImage, List<Rates> rates)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.CreditCardName = creditCardName;
            this.CreditCardImage = creditCardImage;
            this.Rates = rates;
            this.BankName = bankName;
        }

        public CreditCardRates()
        {
        }
    }
}
