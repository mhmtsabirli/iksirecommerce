using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class Bank : ModelBase
    {
        public string Name { get; set; }
        public EnumValue Status { get; set; }
        public Bank(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string name, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Name = name;
            this.Status = Status;
        }
        public Bank()
        {
        }
    }
}
