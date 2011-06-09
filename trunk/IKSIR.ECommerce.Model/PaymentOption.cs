using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class PaymentOption : ModelBase
    {
        public EnumValue EnumValue { get; set; }
        public string CreditCardHolder { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string Cvv2 { get; set; }

        public PaymentOption(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, EnumValue enumValue, string creditcardholder, string creditcardnumber, string expiredate, string cvv2)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.EnumValue = enumValue;
            this.CreditCardHolder = creditcardholder;
            this.CreditCardNumber = creditcardnumber;
            this.ExpireDate = expiredate;
            this.Cvv2 = cvv2;

            

            
        }
    }
}
