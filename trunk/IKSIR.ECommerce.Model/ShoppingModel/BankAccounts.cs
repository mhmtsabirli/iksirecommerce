using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ShoppingModel
{
    class BankAccounts : ModelBase
    {
        public int BankId { get; set; }
        public string AccountNo { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }

        public BankAccounts(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int bankId, string accountNo, string branch, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BankId = bankId;
            this.AccountNo = accountNo;
            this.Branch = branch;
            this.Description = description;
        }

    }
}
