using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Newsletter : ModelBase
    {
        public string Email { get; set; }

        public Newsletter(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string email)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Email = email;
        }
        public Newsletter()
        {
        }
    }
}
