using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class PaymetInfo : ModelBase
    {
        public EnumValue PaymentType { get; set; }
        public TransferAccount TransferAccount { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Name { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvc { get; set; }
        public decimal Rate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public PaymetInfo(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, decimal rate, EnumValue paymentType, TransferAccount transferAccount, CreditCard creditCard, string name, string creditCardNumber, string cvc, int year, int month)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.PaymentType = paymentType;
            this.TransferAccount = transferAccount;
            this.CreditCard = creditCard;
            this.Name = name;
            this.CreditCardNumber = creditCardNumber;
            this.Cvc = cvc;
            this.Rate = rate;
            this.Month = month;
            this.Year = year;
        }
        public PaymetInfo()
        {
        }
    }
}
