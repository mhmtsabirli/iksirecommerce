using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    class Comment : ModelBase
    {
        public User User { get; set; }
        public string Value { get; set; }
        public string Ip { get; set; }
        public int WebSite { get; set; }

        public Comment(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, User user, string value, string ip, int webSite)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.User = user;
            this.Value = value;
            this.Ip = ip;
            this.WebSite = webSite;
        }
    }
}
