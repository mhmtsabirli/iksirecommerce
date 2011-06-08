using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Admin : Base
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int SiteId { get; set; }
        public string Password { get; set; }

        public Admin CreateAdmin(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, string username, string name, string email, DateTime lastlogindate, int siteid, string password)
        {
            Admin a = new Admin();
            a.UserName = username;
            a.Name = name;
            a.Email = email;
            a.LastLoginDate = lastlogindate;
            a.SiteId = siteid;
            a.Password = password;
            a.CreateBase(id, createuser, createdate, edituser, editdate);
            return a;
        }
    }
}
