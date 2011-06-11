using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ShoppingModel
{
    public class Bank : ModelBase
    {
        public string BankName { get; set; }

        public Bank(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string bankName)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BankName = bankName;
        }
    }
}
