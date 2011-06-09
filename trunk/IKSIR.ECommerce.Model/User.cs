using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class User : ModelBase
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
        public int SiteId { get; set; }
        public string Password { get; set; }

        public User createUserId(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate,string username, string name,
            string surname, string email, DateTime birthdate, string mobilephone, string tcid, int status, DateTime lastlogindate, int siteid, string password)
        {
            User u = new User();
            u.UserName = username;
            u.Name = name;
            u.SurName = surname;
            u.Email = email;
            u.BirthDate = birthdate;
            u.MobilePhone = mobilephone;
            u.TcId = tcid;
            u.Status = status;
            u.LastLoginDate = lastlogindate;
            u.SiteId = siteid;
            u.Password = password;
            u.CreateBase( id,  createUserId,  createdate,  edituser,  editdate);

            return u;

        }
    }
}
