using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class AdminRights : ModelBase
    {
        public Admin Admin { get; set; }
        public List<Right> Rights { get; set; }

        public AdminRights(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Admin admin, List<Right> rights)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Admin = admin;
            this.Rights = rights;
        }
    }
}
