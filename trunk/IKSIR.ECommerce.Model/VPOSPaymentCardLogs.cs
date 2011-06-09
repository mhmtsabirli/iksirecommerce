using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class VPOSPaymentCardLogs : ModelBase
    {
        public string BankName { get; set; }
        public string CreditCardCode { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardProductCode { get; set; }
        public string CreditCardProductName { get; set; }
        public string PaymentCardBonusMultiplier { get; set; }
        public string CurrentProductCode { get; set; }
        public string CurrentProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal BonusAmount { get; set; }
        public int TransactionId { get; set; }
        public string RawData { get; set; }

        public VPOSPaymentCardLogs CreateVPOSPaymentCardLogs(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, string bankname, string creditcardcode,
            string creditcardname, string creditcardproductcode, string creditcardproductname, string paymentcardbonusmultiplier,
            string currentproductcode, string currentproductname, decimal amount, decimal bonusamount, int transactionid, string rawdata)
        {
            VPOSPaymentCardLogs Vpcl = new VPOSPaymentCardLogs();
            Vpcl.BankName = bankname;
            Vpcl.CreditCardCode = creditcardcode;
            Vpcl.CreditCardName = creditcardname;
            Vpcl.CreditCardProductCode = creditcardproductcode;
            Vpcl.CreditCardProductName = creditcardproductname;
            Vpcl.PaymentCardBonusMultiplier = paymentcardbonusmultiplier;
            Vpcl.CurrentProductCode = currentproductname;
            Vpcl.CurrentProductName = currentproductcode;
            Vpcl.Amount = amount;
            Vpcl.BonusAmount = bonusamount;
            Vpcl.TransactionId = transactionid;
            Vpcl.RawData = rawdata;

            Vpcl.CreateBase(id, createUserId, createdate, edituser, editdate);

            return Vpcl;
        }
    }
}
