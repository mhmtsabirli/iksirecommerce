using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Enum : ModelBase
    {
        public string Name { get; set; }

        public Enum(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string name)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Name = name;
        }
    }
}
