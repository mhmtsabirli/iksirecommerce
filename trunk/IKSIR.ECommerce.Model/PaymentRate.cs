using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class PaymentRate : ModelBase
    {
        public string Term { get; set; }
        public decimal Rate { get; set; }
        public int BankId { get; set; }

        public PaymentRate CreatePaymentRate(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, string term, decimal rate, int bankid)
        {
            PaymentRate Pr = new PaymentRate();
            Pr.Term = term;
            Pr.Rate = rate;
            Pr.BankId = bankid;

            Pr.CreateBase(id, createUserId, createdate, edituser, editdate);

            return Pr;
        }
    }
}
