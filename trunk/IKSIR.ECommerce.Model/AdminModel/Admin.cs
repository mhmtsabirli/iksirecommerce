using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Model.AdminModel
{
    public class Admin : ModelBase
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Site Site { get; set; }

        public Admin(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string userName, string name, string email, string password, DateTime lastLoginDate, Site site)
         : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.UserName = userName;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.LastLoginDate = lastLoginDate;
            this.Site = site;
        }
    }
}
