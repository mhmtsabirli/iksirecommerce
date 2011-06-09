using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Site : ModelBase
    {
        public string Name { get; set; }

        public Site CreateSite(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, string name)
        {
            Site s = new Site();
            s.Name = name;

            s.CreateBase(id, createUserId, createdate, edituser, editdate);

            return s;
        }
    }
}
