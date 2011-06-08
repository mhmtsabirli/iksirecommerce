using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Bank : Base
    {
        public string BankName { get; set; }

        public Bank CreateBank(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, string bankname)
        {
            Bank b = new Bank();
            b.BankName = bankname;
            b.CreateBase(id, createuser, createdate, edituser, editdate);

            return b;
        }
    }
}
