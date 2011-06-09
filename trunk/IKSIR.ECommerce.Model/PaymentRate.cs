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
        public Bank Bank { get; set; }

        public PaymentRate(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string term, decimal rate, Bank bank)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Term = term;
            this.Rate = rate;
            this.Bank = bank;

     
        }
    }
}
