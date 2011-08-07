using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class CreditCard : ModelBase
    {
        public Bank Bank { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public EnumValue Status { get; set; }
        public string VposId { get; set; }
        public string VposName { get; set; }
        public string VposPassword { get; set; }
        public string VposHost { get; set; }
        public string VposUser { get; set; }
        public CreditCard(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, 
            string vposId,string vposName,string vposPassword,string vposHost,string vposUser,
            Bank bank, string image, string name, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.VposHost = vposHost;
            this.VposId = vposId;
            this.VposName = vposName;
            this.VposPassword = vposPassword;
            this.VposUser = vposUser;
            this.Bank = bank;
            this.Image = image;
            this.Name = name;
            this.Status = status;
        }
        public CreditCard()
        {
        }
    }
}
