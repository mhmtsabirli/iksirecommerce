using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class PaymetTermRate : ModelBase
    {
        public CreditCard CreditCard{ get; set; }
        public int Month { get; set; }
        public decimal Rate { get; set; }
        public EnumValue Status { get; set; }
        public PaymetTermRate(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, CreditCard creditCard,int month,decimal rate,EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.CreditCard = creditCard;
            this.Month = month;
            this.Rate = rate;
            this.Status = status;
        }
        public PaymetTermRate()
        {
        }
    }
}
