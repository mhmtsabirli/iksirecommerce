using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class BinNumber : ModelBase
    {
        public Bank Bank { get; set; }
        public string Number { get; set; }
        public EnumValue Status { get; set; }

        public BinNumber(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,Bank bank, string number, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Bank = bank;
            this.Number = number;
            this.Status = Status;
        }
        public BinNumber()
        {
        }
    }
}
