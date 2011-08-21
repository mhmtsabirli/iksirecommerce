using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Newsletter : ModelBase
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public Newsletter(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string email,bool isActive)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Email = email;
            this.IsActive = isActive;
        }
        public Newsletter()
        {
        }
    }
}
