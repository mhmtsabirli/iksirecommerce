using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class PaymentOption : ModelBase
    {
        public int EnumValueId { get; set; }
        public string CreditCardHolder { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string Cvv2 { get; set; }

        public PaymentOption CreatePaymentOption(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, int enumvalueid, string creditcardholder, string creditcardnumber, string expiredate, string cvv2)
        {
            PaymentOption Op = new PaymentOption();
            Op.EnumValueId = enumvalueid;
            Op.CreditCardHolder = creditcardholder;
            Op.CreditCardNumber = creditcardnumber;
            Op.ExpireDate = expiredate;
            Op.Cvv2 = cvv2;

            Op.CreateBase(id, createUserId, createdate, edituser, editdate);

            return Op;
        }
    }
}
