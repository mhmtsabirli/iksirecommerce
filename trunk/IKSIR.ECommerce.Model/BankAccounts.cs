using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class BankAccounts : Base
    {
        public int BankId { get; set; }
        public string AccountNo { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }

        public BankAccounts CreateBankAccounts(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int bankid, string accountno, string branch, string description)
        {
            BankAccounts ba = new BankAccounts();
            ba.BankId = bankid;
            ba.AccountNo = accountno;
            ba.Branch = branch;
            ba.Description = description;
            ba.CreateBase(id, createuser, createdate, edituser, editdate);

            return ba;
        }

    }
}
