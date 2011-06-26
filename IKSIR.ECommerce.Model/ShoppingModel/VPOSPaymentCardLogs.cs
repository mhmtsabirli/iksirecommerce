using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ShoppingModel
{
    public class VPOSPaymentCardLogs : ModelBase
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

        public VPOSPaymentCardLogs(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string bankName, string creditCardCode,
            string creditCardName, string creditCardProductCode, string creditCardProductName, string paymentCardBonusMultiplier,
            string currentProductCode, string currentProductName, decimal amount, decimal bonusAmaunt, int transactionId, string rawData)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BankName = bankName;
            this.CreditCardCode = creditCardCode;
            this.CreditCardName = creditCardName;
            this.CreditCardProductCode = creditCardProductCode;
            this.CreditCardProductName = creditCardProductName;
            this.PaymentCardBonusMultiplier = paymentCardBonusMultiplier;
            this.CurrentProductCode = currentProductCode;
            this.CurrentProductName = currentProductName;
            this.Amount = amount;
            this.BonusAmount = bonusAmaunt;
            this.TransactionId = transactionId;
            this.RawData = rawData;
        }
    }
}
