using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class TransferAccount : ModelBase
    {
        public Bank Bank { get; set; }
        public string Iban { get; set; }
        public string Description { get; set; }
        public EnumValue Status { get; set; }
        public string Detail
        {
            get
            {
                return Bank.Name + "<br />" + Description + "<br />" + "IBAN: " + Iban;
            }
        }

        public TransferAccount(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Bank bank, string iban, string description, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Bank = bank;
            this.Iban = iban;
            this.Description = description;
            this.Status = status;
        }
        public TransferAccount()
        {
        }
    }
}
