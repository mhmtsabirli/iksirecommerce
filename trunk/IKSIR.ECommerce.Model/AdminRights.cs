using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class AdminRights : Base
    {
        public int AdminId { get; set; }
        public int RightId { get; set; }

        public AdminRights CreateAdminRights(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int adminid, int rightid)
        {
            AdminRights Ar = new AdminRights();
            Ar.AdminId = adminid;
            Ar.RightId = rightid;
            Ar.CreateBase(id, createuser, createdate, edituser,editdate);
            return Ar;
        }
    }
}
