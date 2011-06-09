using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class EnumValues : ModelBase
    {
        public Enum Enum { get; set; }
        public string Value { get; set; }

        public EnumValues(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Enum @enum, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Enum = @enum;
            this.Value = value;
        }
    }
}
