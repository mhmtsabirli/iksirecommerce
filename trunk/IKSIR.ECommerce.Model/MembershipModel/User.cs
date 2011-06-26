using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Model.MembershipModel
{
    public class User : ModelBase
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string TcId { get; set; }
        public int Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Site Site { get; set; }
        public string Password { get; set; }

        public User(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string userName, string name,
            string surName, string eMail, DateTime birthDate, string mobilePhone, string tcId, int status, DateTime lastLoginDate, Site site, string password)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.UserName = userName;
            this.Name = name;
            this.SurName = surName;
            this.Email = eMail;
            this.BirthDate = birthDate;
            this.MobilePhone = mobilePhone;
            this.TcId = tcId;
            this.Status = status;
            this.LastLoginDate = lastLoginDate;
            this.Site = site;
            this.Password = password;
        }
        public User()
        {
        }
    }
}
